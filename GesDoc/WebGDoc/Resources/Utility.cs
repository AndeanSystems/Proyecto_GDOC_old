using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGdoc.WebPage;
using WebGdoc.WebPage.Inicio;
using WebGdoc.WebPage.Controles;
using Entity.Entities;
using WebGdoc.ServicesControllers;

namespace WebGdoc.Resources
{
    public class Utility : System.Web.UI.Page
    {
        public const string _UrlImagen = "~/Resources/Imagenes/";

        #region Configuracion

        #region Configuracion : Seguridad

        public bool VerificarSessionUsuario(Control sOutControl)
        {
            string sMensje = "Su sesion ha expirado: debera registrarse nuevamente.";
            string sPageInicio = "../../frmInicio.aspx";
            bool sValidarSession = true;

            if (Session["sUsuario"] == null ||
                 Session["sNombre"] == null ||
                 Session["sCargo"] == null ||
                 Session["sArea"] == null ||
                 Session["sCodUsu"] == null)
            {
                MensajeAlerta(sOutControl, sMensje, sPageInicio);
                sValidarSession = false;
            }
            else if (Session["sUsuario"].ToString() == "" ||
                      Session["sNombre"].ToString() == "" ||
                      Session["sCargo"].ToString() == "" ||
                      Session["sArea"].ToString() == "" ||
                      Session["sCodUsu"].ToString() == "")
            {
                MensajeAlerta(sOutControl, sMensje, sPageInicio);
                sValidarSession = false;
            }

            return sValidarSession;
        }

        protected override void OnError(EventArgs e)
        {
            // At this point we have information about the error
            HttpContext ctx = HttpContext.Current;

            Exception exception = ctx.Server.GetLastError();

            string errorInfo =
               "<br>Offending URL: " + ctx.Request.Url.ToString() +
               "<br>Source: " + exception.Source +
               "<br>Message: " + exception.Message +
               "<br>Stack trace: " + exception.StackTrace;

            ctx.Response.Write(errorInfo);

            // --------------------------------------------------
            // To let the page finish running we clear the error
            // --------------------------------------------------
            ctx.Server.ClearError();

            base.OnError(e);
        }

        #endregion

        #region Configuracion : Master Page

        public void ReferenciarBanner(Page sPage, string sTituloBannerSistema, string sType)
        {
            Literal divSistema = (Literal)sPage.Master.FindControl("divSistema");

            if (sTituloBannerSistema != "")
            {
                string sLtl = string.Empty;
                char sDelimitador = '|';
                string[] sDato = sTituloBannerSistema.ToString().Split(sDelimitador);

                if (sType == "Default")
                {
                    sLtl = "<strong runat='server' id='h1' class='SistemaNombre'>" + sDato[0] + "</strong>" +
                           "<br>" +
                           "<strong runat='server' id='h2' class='SistemaNombre'>" + sDato[1] + "</strong>" +
                           "<br>" +
                           "<strong runat='server' id='h3' class='SistemaNombre'>" + sDato[2] + "</strong>";
                }
                else
                {
                    sLtl = "<strong runat='server' id='h1' class='UsuarioNombre'>" + sDato[0] + "</strong>" +
                           "<br>" +
                           "<strong runat='server' id='h2' class='UsuarioCargo'>" + sDato[1] + "</strong>" +
                           "<br>" +
                           "<strong runat='server' id='h3' class='UsuarioOficina'>" + sDato[2] + "</strong>";
                }

                divSistema.Text = sLtl;
            }
        }

        #endregion

        #region Configuracion : Barra de Herramientas

        public void ReferenciarTitulo(Page sPage, string sTituloPagina)
        {
            BarraHerramientas bhrPrincipal = (BarraHerramientas)sPage.Master.FindControl("bhrPrincipal");

            if (bhrPrincipal != null)
                bhrPrincipal.TituloPagina = sTituloPagina;
        }

        public void ReferenciarLink(Page sPage, List<string> sLink)
        {
            BarraHerramientas bhrPrincipal = (BarraHerramientas)sPage.Master.FindControl("bhrPrincipal");

            bhrPrincipal.LinkPagina = sLink;

        }

        #endregion

        #region Configuracion : Tipo Participante

        public enum UserTipo
        {
            DocElecRemitente = 5,
            DocElecEmisor = 3,
            DocElecParticipante = 2,

            DocDigEmisor = 6,
            DocDigDestinatario = 7,

        }

        #endregion

        #region Configuracion : Control CKEditor

        protected void ConfigurarCKEditor(CKEditor.NET.CKEditorControl sControlCKEditor)
        {
            sControlCKEditor.config.toolbar = new object[]
            {
                new object[] { "Source", "-", "Templates" },
                new object[] { "Cut", "Copy", "Paste", "PasteText", "PasteFromWord", "-", "SpellChecker", "Scayt" },
                new object[] { "Bold", "Italic", "Underline", "Strike", "-", "Subscript", "Superscript" },
                new object[] { "JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock" },
                "/",
                new object[] { "Styles", "Format", "Font", "FontSize" },
                new object[] { "TextColor", "BGColor" },
                new object[] { "BidiLtr", "BidiRtl" },
                new object[] { "Link", "Unlink", "Anchor" }
            };
        }

        #endregion

        #region Configuracion : Carga de Menu Dinamico

        public void CargarMenuPorUsuario()
        {
            System.Text.StringBuilder sTextXML = new System.Text.StringBuilder();
            //string sTextXML = string.Empty;

            WebGdoc.ServicesControllers.GestionController GesController = new WebGdoc.ServicesControllers.GestionController();
            IList<eAccesoSistema> lstAccesoXUsuario = new List<eAccesoSistema>();
            eAccesoSistema CtrAcceso = new eAccesoSistema();

            CtrAcceso.Usuario = new eUsuario
                                    {
                                        Codigo = (long)Session["sCodUsu"]
                                    };

            lstAccesoXUsuario = GesController.GetMenuUsuario(CtrAcceso);

            sTextXML.AppendLine("<?xml version='1.0' encoding='utf-8' ?>");
            sTextXML.AppendLine("<menu>");

            sTextXML.AppendLine(ObtenerItemMenu(lstAccesoXUsuario).ToString());

            sTextXML.AppendLine("</menu>");

            GenerarMenuUser(sTextXML);

        }

        protected StringBuilder ObtenerItemMenu(IList<eAccesoSistema> sMenuTmps)
        {
            Int32 sTotalRegistros = sMenuTmps.Count;
            List<String> sLstModulo = new List<String>();
            List<String> sLstPagina = new List<String>();
            bool sPermitir = true;

            for (int i = 0; i < sTotalRegistros; i++)
            {
                sPermitir = true;

                foreach (String sModuloTmp in sLstModulo)
                {
                    long sCodPadre = Convert.ToInt64(sModuloTmp.Split('|')[0]);

                    if (sMenuTmps[i].Pagina.CodigoPadre == sCodPadre)
                    {
                        sPermitir = false;
                        break;
                    }
                }

                if (sPermitir)
                    sLstModulo.Add(sMenuTmps[i].Pagina.CodigoPadre.ToString() + "|" +
                                   sMenuTmps[i].Pagina.Comentario);
            }

            for (int i = 0; i < sTotalRegistros; i++)
            {
                sLstPagina.Add(sMenuTmps[i].Pagina.CodigoPadre.ToString() + "|" +
                               sMenuTmps[i].Pagina.Nombre + "|" +
                               sMenuTmps[i].Pagina.DireccionURL);
            }


            System.Text.StringBuilder sTextXML = new System.Text.StringBuilder();

            sTextXML.AppendLine(SincronizarMenuItems(sLstModulo, sLstPagina).ToString());

            return sTextXML;
        }

        protected StringBuilder SincronizarMenuItems(List<string> sLstModulo, List<string> sLstPagina)
        {
            System.Text.StringBuilder sTextXML = new System.Text.StringBuilder();

            foreach (string sModuloUser in sLstModulo)
            {
                sTextXML.AppendLine("<menuItem>");
                sTextXML.AppendLine("<text>" + sModuloUser.Split('|')[1] + "</text>");
                sTextXML.AppendLine("<horizontalalign>" + "center" + "</horizontalalign>");
                sTextXML.AppendLine("<width>" + "100" + "</width>");

                sTextXML.AppendLine("<subMenu>");
                foreach (string sPaginaUser in sLstPagina)
                {
                    if (sModuloUser.Split('|')[0] == sPaginaUser.Split('|')[0])
                    {

                        sTextXML.AppendLine("<menuItem>");
                        sTextXML.AppendLine("<text>" + "► " + sPaginaUser.Split('|')[1] + "</text>");
                        sTextXML.AppendLine("<horizontalalign>" + "left" + "</horizontalalign>");
                        sTextXML.AppendLine("<width>" + "170" + "</width>");
                        sTextXML.AppendLine("<url>" + sPaginaUser.Split('|')[2] + "</url>");
                        sTextXML.AppendLine("</menuItem>");

                    }
                }

                sTextXML.AppendLine("</subMenu>");
                sTextXML.AppendLine("</menuItem>");

            }
            return sTextXML;
        }

        protected void GenerarMenuUser(StringBuilder sTextXML)
        {
            string sFileXML = Server.MapPath("~/Resources/Menu");
            string sFileUserXML = System.IO.Path.Combine(sFileXML, Session["sUsuario"] + ".xml");

            if (!System.IO.File.Exists(sFileUserXML))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(sFileUserXML))
                {

                }
            }

            System.IO.StreamWriter sw = new System.IO.StreamWriter(sFileUserXML);
            sw.WriteLine(sTextXML.ToString());
            sw.Close();

        }

        #endregion

        public void MostrarMensajeEspera()
        {
            System.Threading.Thread.Sleep(10);
        }

        #endregion

        #region Utilitario

        #region Utilitario : Verificar Varidacion de Datos

        public bool VerificarTipoDato(Control oControl, string oTipoDato)
        {
            bool sValidar = true;

            try
            {
                switch (oControl.GetType().Name)
                {
                    case "Label":
                        Label oLabel = (Label)oControl;

                        if (oTipoDato == "String")
                            Convert.ToString(oLabel.Text);
                        else if (oTipoDato == "Int16")
                            Convert.ToInt16(oLabel.Text);
                        else if (oTipoDato == "Int32")
                            Convert.ToInt32(oLabel.Text);
                        else if (oTipoDato == "Int64")
                            Convert.ToInt64(oLabel.Text);
                        else if (oTipoDato == "Date")
                            Convert.ToDateTime(oLabel.Text);
                        else if (oTipoDato == "Boolean")
                            Convert.ToBoolean(oLabel.Text);
                        else
                        { }
                        break;

                    case "TextBox":
                        TextBox oTextBox = (TextBox)oControl;

                        if (oTipoDato == "String")
                            Convert.ToString(oTextBox.Text);
                        else if (oTipoDato == "Int16")
                            Convert.ToInt16(oTextBox.Text);
                        else if (oTipoDato == "Int32")
                            Convert.ToInt32(oTextBox.Text);
                        else if (oTipoDato == "Int64")
                            Convert.ToInt64(oTextBox.Text);
                        else if (oTipoDato == "Date")
                            Convert.ToDateTime(oTextBox.Text);
                        else if (oTipoDato == "Boolean")
                            Convert.ToBoolean(oTextBox.Text);
                        else if (oTipoDato == "Len")
                            sValidar = oTextBox.Text.Length == 0 ? false : true;
                        else
                        { }
                        break;

                    case "DropDownList":
                        DropDownList oDropDownList = (DropDownList)oControl;

                        if (oTipoDato == "String")
                            Convert.ToString(oDropDownList.SelectedValue);
                        else if (oTipoDato == "Int16")
                            Convert.ToInt16(oDropDownList.SelectedValue);
                        else if (oTipoDato == "Int32")
                            Convert.ToInt32(oDropDownList.SelectedValue);
                        else if (oTipoDato == "Int64")
                            Convert.ToInt64(oDropDownList.SelectedValue);
                        else if (oTipoDato == "Date")
                            Convert.ToDateTime(oDropDownList.SelectedValue);
                        else if (oTipoDato == "Boolean")
                            Convert.ToBoolean(oDropDownList.SelectedValue);
                        else
                        { }
                        break;

                    case "CheckBox":
                        CheckBox oCheckBox = (CheckBox)oControl;

                        if (oTipoDato == "String")
                            Convert.ToString(oCheckBox.Checked);
                        else if (oTipoDato == "Int16")
                            Convert.ToInt16(oCheckBox.Checked);
                        else if (oTipoDato == "Int32")
                            Convert.ToInt32(oCheckBox.Checked);
                        else if (oTipoDato == "Int64")
                            Convert.ToInt64(oCheckBox.Checked);
                        else if (oTipoDato == "Date")
                            Convert.ToDateTime(oCheckBox.Checked);
                        else if (oTipoDato == "Boolean")
                            Convert.ToBoolean(oCheckBox.Checked);
                        else
                        { }
                        break;

                    case "RadioButtonList":
                        RadioButtonList oRadioButtonList = (RadioButtonList)oControl;

                        if (oTipoDato == "String")
                            Convert.ToString(oRadioButtonList.SelectedValue);
                        else if (oTipoDato == "Int16")
                            Convert.ToInt16(oRadioButtonList.SelectedValue);
                        else if (oTipoDato == "Int32")
                            Convert.ToInt32(oRadioButtonList.SelectedValue);
                        else if (oTipoDato == "Int64")
                            Convert.ToInt64(oRadioButtonList.SelectedValue);
                        else if (oTipoDato == "Date")
                            Convert.ToDateTime(oRadioButtonList.SelectedValue);
                        else if (oTipoDato == "Boolean")
                            Convert.ToBoolean(oRadioButtonList.SelectedValue);
                        else
                        { }
                        break;

                    case "webpage_controles_validarusuario_grupo_ascx":
                        ValidarUsuario_Grupo oValidarUsuario_Grupo = (ValidarUsuario_Grupo)oControl;

                        if (oTipoDato == "String")
                            Convert.ToString(oValidarUsuario_Grupo.UserText);
                        else if (oTipoDato == "Int16")
                            Convert.ToInt16(oValidarUsuario_Grupo.UserText);
                        else if (oTipoDato == "Int32")
                            Convert.ToInt32(oValidarUsuario_Grupo.UserText);
                        else if (oTipoDato == "Int64")
                            Convert.ToInt64(oValidarUsuario_Grupo.UserText);
                        else if (oTipoDato == "Date")
                            Convert.ToDateTime(oValidarUsuario_Grupo.UserText);
                        else if (oTipoDato == "Boolean")
                            Convert.ToBoolean(oValidarUsuario_Grupo.UserText);
                        else if (oTipoDato == "Len")
                            sValidar = oValidarUsuario_Grupo.UserText.Length == 0 ? false : true;
                        else
                        { }
                        break;

                    case "CKEditorControl":
                        CKEditor.NET.CKEditorControl oCKEditor = (CKEditor.NET.CKEditorControl)oControl;

                        if (oTipoDato == "String")
                            Convert.ToString(oCKEditor.Text);
                        else if (oTipoDato == "Int16")
                            Convert.ToInt16(oCKEditor.Text);
                        else if (oTipoDato == "Int32")
                            Convert.ToInt32(oCKEditor.Text);
                        else if (oTipoDato == "Int64")
                            Convert.ToInt64(oCKEditor.Text);
                        else if (oTipoDato == "Date")
                            Convert.ToDateTime(oCKEditor.Text);
                        else if (oTipoDato == "Boolean")
                            Convert.ToBoolean(oCKEditor.Text);
                        else if (oTipoDato == "Len")
                            sValidar = oCKEditor.Text.Length == 0 ? false : true;
                        else
                        { }
                        break;

                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                sValidar = false;
            }

            return sValidar;
        }

        #endregion

        #region Utilitario : Limpiar Controles

        protected void LimpiarControles(Control oControl)
        {
            switch (oControl.GetType().Name)
            {
                case "Label":
                    Label oLabel = (Label)oControl;
                    oLabel.Text = "";
                    break;

                case "TextBox":
                    TextBox oTextBox = (TextBox)oControl;
                    oTextBox.Text = "";
                    break;

                case "DropDownList":
                    DropDownList oDropDownList = (DropDownList)oControl;
                    oDropDownList.Items.Clear();
                    oDropDownList.DataBind();
                    break;

                case "CheckBox":
                    CheckBox oCheckBox = (CheckBox)oControl;
                    oCheckBox.Checked = false;
                    break;

                case "GridView":
                    GridView oGridView = (GridView)oControl;
                    //oGridView.DataSource = null;
                    //oGridView.DataBind();
                    VerificarGridView(oGridView);
                    break;

                case "webpage_controles_validarusuario_grupo_ascx":
                    ValidarUsuario_Grupo oValidarUsuario_Grupo = (ValidarUsuario_Grupo)oControl;
                    oValidarUsuario_Grupo.LimpiarControl = true;
                    break;

                case "CKEditorControl":
                    CKEditor.NET.CKEditorControl oCKEditor = (CKEditor.NET.CKEditorControl)oControl;
                    oCKEditor.Text = "";
                    break;

                default:
                    break;
            }

        }
        protected void LimpiarControles(List<Control> oControl)
        {
            int oCount = oControl.Count;
            for (int i = 1; i <= oCount; i++)
            {
                switch (oControl[i - 1].GetType().Name)
                {
                    case "Label":
                        Label oLabel = (Label)oControl[i - 1];
                        oLabel.Text = "";
                        break;

                    case "TextBox":
                        TextBox oTextBox = (TextBox)oControl[i - 1];
                        oTextBox.Text = "";
                        break;

                    case "DropDownList":
                        DropDownList oDropDownList = (DropDownList)oControl[i - 1];
                        oDropDownList.SelectedValue = "0";
                        break;

                    case "CheckBox":
                        CheckBox oCheckBox = (CheckBox)oControl[i - 1];
                        oCheckBox.Checked = false;
                        break;

                    case "GridView":
                        GridView oGridView = (GridView)oControl[i - 1];
                        //oGridView.DataSource = null;
                        //oGridView.DataBind();
                        VerificarGridView(oGridView);
                        break;

                    case "CKEditorControl":
                        CKEditor.NET.CKEditorControl oCKEditor = (CKEditor.NET.CKEditorControl)oControl[i - 1];
                        oCKEditor.Text = "";
                        break;

                    case "webpage_controles_validarusuario_grupo_ascx":
                        ValidarUsuario_Grupo oValidarUsuario_Grupo = (ValidarUsuario_Grupo)oControl[i - 1];
                        oValidarUsuario_Grupo.LimpiarControl = true;

                        break;

                    default:
                        break;
                }

            }
        }

        #endregion

        #region Utilitario : Verificar GridView, Cargar GridView

        public void VerificarGridView(GridView sGridView)
        {
            try
            {
                if (sGridView.Rows.Count <= 0)
                {
                    DataTable dtGridView = new DataTable();

                    if (sGridView.Columns.Count > 0)
                    {
                        for (int i = 0; i < sGridView.Columns.Count; i++)
                        {
                            if (sGridView.Columns[i].GetType().Name == "BoundField")
                            {
                                dtGridView.Columns.Add(((BoundField)sGridView.Columns[i]).DataField.ToString(), typeof(string));
                            }
                        }

                        //if (dtGridView.Columns.Count > 0)
                        //{
                        //    for (int ii = 0; ii < 1; ii++)
                        //    {
                        //        DataRow dr = dtGridView.NewRow();
                        //        dr[0] = "";
                        //        dtGridView.Rows.Add(dr);
                        //    }
                        //}
                    }

                    sGridView.DataSource = dtGridView;
                    sGridView.DataBind();
                }

            }
            catch (Exception ex)
            {

            }
        }
        public void VerificarGridView(GridView sGridView, int[] sIndexs)
        {
            try
            {
                if (sIndexs.Length > 0)
                    foreach (int sIndex in sIndexs)
                        sGridView.Columns[sIndex].Visible = true;


                if (sGridView.Rows.Count <= 0)
                {
                    DataTable dtGridView = new DataTable();

                    if (sGridView.Columns.Count > 0)
                    {
                        for (int i = 0; i < sGridView.Columns.Count; i++)
                        {
                            if (sGridView.Columns[i].GetType().Name == "BoundField")
                            {
                                dtGridView.Columns.Add(((BoundField)sGridView.Columns[i]).DataField.ToString(), typeof(string));
                            }
                        }

                        //if (dtGridView.Columns.Count > 0)
                        //{
                        //    for (int ii = 0; ii < 1; ii++)
                        //    {
                        //        DataRow dr = dtGridView.NewRow();
                        //        dr[0] = "";
                        //        dtGridView.Rows.Add(dr);
                        //    }
                        //}
                    }

                    sGridView.DataSource = dtGridView;
                    sGridView.DataBind();
                }

                if (sIndexs.Length > 0)
                    foreach (int sIndex in sIndexs)
                        sGridView.Columns[sIndex].Visible = false;
            }
            catch (Exception ex)
            {

            }
        }

        public void CargarGridView(GridView sGridView, object sDataTable)
        {
            try
            {
                sGridView.DataSource = sDataTable;
                sGridView.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
        public void CargarGridView(GridView sGridView, object sDataTable, int[] sIndexs)
        {
            try
            {
                if (sIndexs.Length > 0)
                    foreach (int sIndex in sIndexs)
                        sGridView.Columns[sIndex].Visible = true;

                sGridView.DataSource = sDataTable;
                sGridView.DataBind();

                if (sIndexs.Length > 0)
                    foreach (int sIndex in sIndexs)
                        sGridView.Columns[sIndex].Visible = false;
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Utilitario : Cargar DropDownList

        public void VerificarDropDownList(DropDownList sDropDownList, string sDataTextField, string sDataValueField)
        {
            DataTable dtDropDownList = new DataTable();

            dtDropDownList.Columns.Add(sDataTextField, typeof(string));
            dtDropDownList.Columns.Add(sDataValueField, typeof(string));


            sDropDownList.DataSource = dtDropDownList;
            sDropDownList.DataTextField = sDataTextField;
            sDropDownList.DataValueField = sDataValueField;
            sDropDownList.DataBind();
        }

        public void CargarDropDownList(DropDownList sDropDownList, object sDataTable, string sDataTextField, string sDataValueField)
        {
            VerificarDropDownList(sDropDownList, sDataTextField, sDataValueField);

            sDropDownList.DataSource = sDataTable;
            sDropDownList.DataTextField = sDataTextField;
            sDropDownList.DataValueField = sDataValueField;
            sDropDownList.DataBind();
        }

        #endregion

        #region Utilitario : Mensajeria, Direccionamiento, Confirmaciones

        public void MensajeAlerta(System.Web.UI.Control oupControl, string strScript)
        {
            ScriptManager.RegisterStartupScript(oupControl, oupControl.GetType(), Guid.NewGuid().ToString(), String.Format("alert('{0}');", strScript), true);
        }

        public void MensajeConfirmacion(System.Web.UI.Control oupControl, string strScript)
        {
            ScriptManager.RegisterStartupScript(oupControl, oupControl.GetType(), Guid.NewGuid().ToString(), String.Format("confir('{0}');", strScript), true);
        }

        public void MensajeAlerta(System.Web.UI.Control oupControl, string strScript, string Redirect)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"alert( """ + strScript + @""" );");
            if (Redirect != "")
                sb.Append(@"{location.href='" + Redirect + "',true}");

            ScriptManager.RegisterStartupScript(oupControl, oupControl.GetType(), Guid.NewGuid().ToString(), sb.ToString(), true);
        }

        public void RedireccionarPage(System.Web.UI.Control oupControl, string Redirect)
        {
            StringBuilder sb = new StringBuilder();
            if (Redirect != "")
                sb.Append(@"{location.href='" + Redirect + "',true}");

            ScriptManager.RegisterStartupScript(oupControl, oupControl.GetType(), Guid.NewGuid().ToString(), sb.ToString(), true);
        }

        public void OpenNewTab(System.Web.UI.Control oupControl, string url)
        {
            StringBuilder sb = new StringBuilder();
            if (url != "")
                sb.Append(@"{window.open('" + url + "'),'_blank'}");

            ScriptManager.RegisterStartupScript(oupControl, oupControl.GetType(), Guid.NewGuid().ToString(), sb.ToString(), true);
        }

        #endregion


        #region Utilitario : Cargar archivos a Servidor FTP
        /*
        protected string SubirArchivoFTP(FileUpload sFileServer, string sNombreCarpeta, string sNombreArchivo, string sExtencionArchivo)
        {
            string sRutaFTP = ConfigurationManager.AppSettings.Get("ServidorFTP");
            string sUserName = ConfigurationManager.AppSettings.Get("UserFTP");
            string sUserPwd = ConfigurationManager.AppSettings.Get("PwdFTP");

            string sRutaFTPFile = sRutaFTP + sNombreCarpeta;
            string sRutaFTPArchivo = sRutaFTP + sNombreCarpeta + "/" + sNombreArchivo + sExtencionArchivo;
            string sRutaArchivo = sFileServer.PostedFile.FileName;

            string sValidar = string.Empty;
            string sMensaje = string.Empty;

            //Vadida Extension de Archivo
            ValidarExtensionArchivo(sRutaArchivo, sExtencionArchivo, ref sMensaje);
            if (sMensaje == string.Empty)
            {
                //Listar directorio FTP
                string[] sDirF = ListarFTP(sRutaFTP, sUserName, sUserPwd);

                //Valida que no exista el directorio en el FTP
                sValidar = ValidarExistenciaFTP(sDirF, sNombreCarpeta);

                if (sValidar == "No Existe")
                    //Creacion del directorio Principal
                    sMensaje = CreacionDirectorioFTP(sRutaFTPFile, sUserName, sUserPwd);


                if (sMensaje == string.Empty)
                {
                    //Listar Archivos FTP
                    string[] sDirA = ListarFTP(sRutaFTPFile, sUserName, sUserPwd);

                    //Valida que no exista el directorio en el FTP
                    sValidar = ValidarExistenciaFTP(sDirA, sNombreArchivo);

                    if (sValidar == "No Existe")
                    {
                        //Creacion del archivo    
                        byte[] sbyteContent = (byte[])Session["sUplServerFileBytes"];
                        sMensaje = CreacionArchivoFTP(sRutaFTPArchivo, sRutaArchivo, sUserName, sUserPwd, sbyteContent);
                        
                        //{
                        //    sFileServer.PostedFile.SaveAs(@"C:\Inetpub\ftproot\FEPCMAC\" + sNombreArchivo + sExtencionArchivo);
                        //}
                    }

                }

            }


            return sMensaje;
        }

        protected void ValidarExtensionArchivo(string sRutaArchivo, string sExtencionArchivo, ref string sMensajeError)
        {
            string sExtArchivo = string.Empty;
            //if (sRutaArchivo.IndexOf(".") > -1)
            //    sExtArchivo = sRutaArchivo.Substring(sRutaArchivo.IndexOf("."), sRutaArchivo.Length - sRutaArchivo.IndexOf("."));
            sExtArchivo = Path.GetExtension(sRutaArchivo);

            if (sExtencionArchivo.ToUpper() != sExtArchivo.ToUpper())
                sMensajeError = "El Archivo seleccionado no cumple con la extension indicada: " + sExtencionArchivo;
        }
        
        

        protected string ReturnNombreArchivo(string sRutaArchivo)
        {
            string sExtArchivo = string.Empty;

            //if (sRutaArchivo.IndexOf(".") > -1)
            //    sExtArchivo = sRutaArchivo.Substring(sRutaArchivo.IndexOf("."), sRutaArchivo.Length - sRutaArchivo.IndexOf("."));
            sExtArchivo = Path.GetFileName(sRutaArchivo);

            return sExtArchivo;
        }

        protected string[] ListarFTP(string sRutaFTP, string sUserName, string sUserPwd)
        {
            FtpWebRequest peticionFTP = ((FtpWebRequest)WebRequest.Create(new Uri(sRutaFTP)));

            peticionFTP.Credentials = new NetworkCredential(sUserName, sUserPwd);
            peticionFTP.Method = WebRequestMethods.Ftp.ListDirectory;

            return new System.IO.StreamReader(peticionFTP.GetResponse().GetResponseStream()).ReadToEnd().Trim().Split('\n');

        }
        
        protected string ValidarExistenciaFTP(string[] sDirectoryList, string sNombreFA)
        {
            string sMsg = "No Existe";

            foreach (string word in sDirectoryList)
            {
                if (word.ToString().Replace('\r', ' ').Trim() == sNombreFA)
                    sMsg = "Si Existe";
            }

            return sMsg;
        }

        protected string CreacionDirectorioFTP(string sRutaFTPFile, string sUserName, string sUserPwd)
        {
            string sDirectory = string.Empty;

            try
            {
                FtpWebRequest sReqTmp = (FtpWebRequest)WebRequest.Create(sRutaFTPFile);
                sReqTmp.Method = WebRequestMethods.Ftp.MakeDirectory;
                sReqTmp.Credentials = new NetworkCredential(sUserName, sUserPwd);

                FtpWebResponse respuestaFTP = (FtpWebResponse)sReqTmp.GetResponse();
                respuestaFTP.Close();
                                
                return sDirectory;
            }
            catch (Exception ex)
            {
                //sDirectory = ex.Message;
                sDirectory = "Error al crear directorio.";
                return sDirectory;
            }
        }
       
        protected string CreacionArchivoFTP(string sRutaFTPArchivo, string sRutaArchivo, string sUserName, string sUserPwd, byte[] sFileServerBytes)
        {
            string sFile = string.Empty;

            try
            {
                FtpWebRequest sReqObj = (FtpWebRequest)WebRequest.Create(sRutaFTPArchivo);

                sReqObj.Method = WebRequestMethods.Ftp.UploadFile;
                sReqObj.Credentials = new NetworkCredential(sUserName, sUserPwd);
                sReqObj.GetRequestStream().Write(sFileServerBytes, 0, sFileServerBytes.Length);
                sReqObj.GetRequestStream().Flush();
                sReqObj.GetRequestStream().Close();
                sReqObj.GetRequestStream().Dispose();
                sReqObj = null;               
                

                return sFile;
            }
            catch (Exception ex)
            {                
                //string str = ex.Message;
                sFile = "Error al crear archivo.";
                return sFile;
            }
        }
        
        protected void AcreditacionArchivoFTP(string sNombreFile, string sNombreArchivo)
        {
            string sRutaFTP = ConfigurationManager.AppSettings.Get("ServidorFTP");
            string sUserName = ConfigurationManager.AppSettings.Get("UserFTP");
            string sUserPwd = ConfigurationManager.AppSettings.Get("PwdFTP");

            FtpWebRequest reqFTP;
            try
            {
                string sTMPFile = ConfigurationManager.AppSettings.Get("CarpetaTMP"); //@"E:\Documents\Jonny_Marinos\Mis Documentos\Visual Studio 2008\Projects\FEPCMAC\WebSite\WebPage\Digitalizacion\TmpVisor";
                FileStream outputStream = new FileStream(sTMPFile + "\\" + sNombreArchivo, FileMode.Create);

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(sRutaFTP + sNombreFile + "/" + sNombreArchivo));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(sUserName, sUserPwd);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                
            }


        }
        
        */

        public string ReturnExtensionArchivo(string sRutaArchivo)
        {
            string sExtArchivo = string.Empty;

            sExtArchivo = Path.GetExtension(sRutaArchivo);

            return sExtArchivo;
        }

        public string CargarArchivoFTP(FileUpload _FileUpload, string sNombreCarpeta, string sNombreArchivo, string sExtencionArchivo)
        {
            string _MensajeError = string.Empty;

            if (_FileUpload.HasFile)
            {
                try
                {
                    string sRutaFTP = ConfigurationManager.AppSettings.Get("DirectorioFTP");

                    if (!Directory.Exists(sRutaFTP + sNombreCarpeta))
                        Directory.CreateDirectory(sRutaFTP + "/" + sNombreCarpeta);

                    if (!File.Exists(sRutaFTP + sNombreCarpeta + sNombreArchivo + sExtencionArchivo))
                        _FileUpload.SaveAs(sRutaFTP + "/" + sNombreCarpeta + "/" + sNombreArchivo + sExtencionArchivo);


                }
                catch (Exception ex)
                {
                    _MensajeError = ex.Message;
                }
            }

            return _MensajeError;

            /*
            If FileUpload1.HasFile Then
                Try
                    FileUpload1.SaveAs("C:\Uploads\" & FileUpload1.FileName)
                    Label1.Text = "File name: " & FileUpload1.PostedFile.FileName & "<br>" & _
                                  "File Size: " & FileUpload1.PostedFile.ContentLength & " kb<br>" & _
                                  "Content type: " & FileUpload1.PostedFile.ContentType
                Catch ex As Exception
                    Label1.Text = "ERROR: " & ex.Message.ToString()
                End Try
            Else
                Label1.Text = "You have not specified a file."
            End If
            */

        }

        protected string GuardarArchivoFTP(string sNombreOrigen, string sNombreCarpeta, string sNombreArchivo, string sExtencionArchivo)
        {
            string _MensajeError = string.Empty;

            if (sNombreOrigen.Length > 0)
            {
                try
                {
                    string sRutaFTP = ConfigurationManager.AppSettings.Get("DirectorioFTP");
                    string sRutaOriFTP = sRutaFTP + sNombreOrigen + sExtencionArchivo;
                    string sRutaDesFTP = sRutaFTP + "\\" + sNombreCarpeta + "\\" + sNombreArchivo + sExtencionArchivo;

                    if (!Directory.Exists(sRutaFTP + "\\" + sNombreCarpeta))
                        Directory.CreateDirectory(sRutaFTP + "\\" + sNombreCarpeta);

                    if (!File.Exists(sRutaDesFTP))
                        File.Copy(sRutaOriFTP, sRutaDesFTP, false);
                }
                catch (Exception ex)
                {
                    _MensajeError = ex.Message;
                }
            }

            return _MensajeError;
        }

        protected string CopyArchivoFTP(string sNombreFile, string sNombreArchivo)
        {
            string _MensajeError = string.Empty;

            try
            {
                string sRutaFTP = ConfigurationManager.AppSettings.Get("DirectorioFTP");
                string sRutaTMP = ConfigurationManager.AppSettings.Get("CarpetaTMP");

                if (!Directory.Exists(sRutaTMP + "\\" + Session["sUsuario"].ToString()))
                    Directory.CreateDirectory(sRutaTMP + "\\" + Session["sUsuario"].ToString());

                if (!Directory.Exists(sRutaTMP + "\\" + Session["sUsuario"].ToString() + "\\" + sNombreFile))
                    Directory.CreateDirectory(sRutaTMP + "\\" + Session["sUsuario"].ToString() + "\\" + sNombreFile);

                if (!File.Exists(sRutaTMP + "\\" + Session["sUsuario"].ToString() + "\\" + sNombreFile + "\\" + sNombreArchivo))
                {
                    if (!File.Exists(sRutaFTP + "\\" + sNombreFile + "\\" + sNombreArchivo))
                        File.Copy(sRutaTMP + "\\" + sNombreFile + "\\" + sNombreArchivo, sRutaTMP + "\\" + Session["sUsuario"].ToString() + "\\" + sNombreFile + "\\" + sNombreArchivo);
                    else
                        File.Copy(sRutaFTP + "\\" + sNombreFile + "\\" + sNombreArchivo, sRutaTMP + "\\" + Session["sUsuario"].ToString() + "\\" + sNombreFile + "\\" + sNombreArchivo);
                }
            }
            catch (Exception ex)
            {
                _MensajeError = ex.Message;
            }

            return _MensajeError;

        }

        protected void VisualizarArchivoPDF(string sNombreFile, string sNombreFileDes, string sNombreArchivo)
        {
            Response.Redirect(sNombreFile + "/" + Session["sUsuario"].ToString() + "/" + sNombreFileDes + "/" + sNombreArchivo, false);
        }

        protected void VisualizarArchivoPlanGestion(string sNombreFile)
        {
            Response.Redirect(sNombreFile);
        }

        #endregion

        #region Utilitario : Convertir documento a PDF

        protected void GenerarArchivoPDF(string sNumeroDocumentoElectronico, string sCarpetaOrigen, string sBodyTexto)
        {
            string sFEPCMAC = ConfigurationManager.AppSettings.Get("FooterPDF1");
            string sDireccion = ConfigurationManager.AppSettings.Get("FooterPDF2");
            string sTelefono = ConfigurationManager.AppSettings.Get("FooterPDF3");
            string sWebSite = ConfigurationManager.AppSettings.Get("FooterPDF4");
            string[] sFooter = { sFEPCMAC, (sDireccion + sTelefono + sWebSite) };


            iTextSharp.text.Document oDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4);

            MemoryStream ms = new MemoryStream();
            PdfWriter.GetInstance(oDoc, ms);

            oDoc.Header = GenerarHeader("~/Resources/Imagenes/", "FEPCMAC_Logo2.jpg");
            oDoc.Footer = GenerarFooter(sFooter); ;

            oDoc.Open();
            GenerarBody(ref oDoc, sBodyTexto);
            oDoc.Close();

            byte[] byteArray = ms.ToArray();


            ms.Flush();
            ms.Close();

            //Response.Clear();
            //Response.AddHeader("Content-Disposition", "attachment; filename=" + sNumeroDocumentoElectronico + "_" + string.Format("{0:ddMMyyy}", DateTime.Now) + ".pdf");
            //Response.AddHeader("Content-Length", byteArray.Length.ToString());
            //Response.ContentType = "application/octet-stream";
            //Response.BinaryWrite(byteArray);

            SubirArchivoFTP(sCarpetaOrigen, sNumeroDocumentoElectronico, ".pdf", byteArray);
        }

        protected HeaderFooter GenerarHeader(string sURLFolder, string sNameImagen)
        {
            iTextSharp.text.Image sFepcmac = iTextSharp.text.Image.GetInstance(string.Concat(Server.MapPath(sURLFolder), sNameImagen));
            sFepcmac.ScaleAbsolute(60, 70);

            Chunk chkLogoFepcmac = new Chunk(sFepcmac, -10, -10, true);

            HeaderFooter header = new HeaderFooter(new Phrase(chkLogoFepcmac), false);
            header.Alignment = 2;
            header.Border = 0;

            return header;
        }

        protected HeaderFooter GenerarFooter(string[] sTexto)
        {
            iTextSharp.text.Font fontTexto1 = FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD, new iTextSharp.text.Color(System.Drawing.Color.Red));
            iTextSharp.text.Font fontTexto2 = FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.NORMAL, new iTextSharp.text.Color(System.Drawing.Color.Gray));

            Chunk chkTexto1 = new Chunk(@sTexto[0], fontTexto1);
            Chunk chkTexto2 = new Chunk(@sTexto[1], fontTexto2);

            Phrase sPhrase = new Phrase();
            sPhrase.Add(chkTexto1);
            sPhrase.Add("\n");
            sPhrase.Add(chkTexto2);

            HeaderFooter footer = new HeaderFooter(sPhrase, false);
            footer.SetAlignment("center");
            footer.Border = 0;
            return footer;
        }

        protected void GenerarBody(ref iTextSharp.text.Document sBody, string sBodyTexto)
        {
            string sSoloTexto = ConvertirHtmlText(sBodyTexto);

            iTextSharp.text.Font fontTexto1 = FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD, new iTextSharp.text.Color(System.Drawing.Color.Black));
            Chunk chkTexto1 = new Chunk(sSoloTexto, fontTexto1);

            Phrase sPhrase = new Phrase();
            sPhrase.Add(chkTexto1);
            sBody.Add(sPhrase);
            //sBody.NewPage();
        }

        private string ConvertirHtmlText(string source)
        {
            try
            {
                string result;

                // Remove HTML Development formatting
                // Replace line breaks with space
                // because browsers inserts space
                result = source.Replace("\r", " ");
                // Replace line breaks with space
                // because browsers inserts space
                result = result.Replace("\n", " ");
                // Remove step-formatting
                result = result.Replace("\t", string.Empty);
                // Remove repeating spaces because browsers ignore them
                result = System.Text.RegularExpressions.Regex.Replace(result,
                                                                      @"( )+", " ");

                // Remove the header (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*head([^>])*>", "<head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*head( )*>)", "</head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<head>).*(</head>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all scripts (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*script([^>])*>", "<script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*script( )*>)", "</script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                //result = System.Text.RegularExpressions.Regex.Replace(result,
                //         @"(<script>)([^(<script>\.</script>)])*(</script>)",
                //         string.Empty,
                //         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<script>).*(</script>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all styles (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*style([^>])*>", "<style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*style( )*>)", "</style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<style>).*(</style>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert tabs in spaces of <td> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*td([^>])*>", "\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line breaks in places of <BR> and <LI> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*br( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*li( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line paragraphs (double line breaks) in place
                // if <P>, <DIV> and <TR> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*div([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*tr([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*p([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // Remove remaining tags like <a>, links, images,
                // comments etc - anything that's enclosed inside < >
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<[^>]*>", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // replace special characters:
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @" ", " ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&bull;", " * ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lsaquo;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&rsaquo;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&trade;", "(tm)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&frasl;", "/",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lt;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&gt;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&copy;", "(c)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&reg;", "(r)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove all others. More can be added, see
                // http://hotwired.lycos.com/webmonkey/reference/special_characters/
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&(.{2,6});", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // for testing
                //System.Text.RegularExpressions.Regex.Replace(result,
                //       this.txtRegex.Text,string.Empty,
                //       System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // make line breaking consistent
                result = result.Replace("\n", "\r");

                // Remove extra line breaks and tabs:
                // replace over 2 breaks with 2 and over 4 tabs with 4.
                // Prepare first to remove any whitespaces in between
                // the escaped characters and remove redundant tabs in between line breaks
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\t)", "\t\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\r)", "\t\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\t)", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove redundant tabs
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove multiple tabs following a line break with just one tab
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Initial replacement target string for line breaks
                string breaks = "\r\r\r";
                // Initial replacement target string for tabs
                string tabs = "\t\t\t\t\t";
                for (int index = 0; index < result.Length; index++)
                {
                    result = result.Replace(breaks, "\r\r");
                    result = result.Replace(tabs, "\t\t\t\t");
                    breaks = breaks + "\r";
                    tabs = tabs + "\t";
                }

                // That's it.
                return result;
            }
            catch
            {
                //MessageBox.Show("Error");
                return source;
            }
        }

        protected string SubirArchivoFTP(string sNombreCarpeta, string sNombreArchivo, string sExtencionArchivo, byte[] sbyteContent)
        {
            string _MensajeError = string.Empty;

            if (sbyteContent.Length > 0)
            {
                try
                {
                    string sRutaFTP = ConfigurationManager.AppSettings.Get("CarpetaTMP");

                    if (!Directory.Exists(sRutaFTP + sNombreCarpeta))
                        Directory.CreateDirectory(sRutaFTP + "/" + sNombreCarpeta);

                    if (!File.Exists(sRutaFTP + sNombreCarpeta + sNombreArchivo + sExtencionArchivo))
                        File.WriteAllBytes(sRutaFTP + "/" + sNombreCarpeta + "/" + sNombreArchivo + sExtencionArchivo, sbyteContent);
                }
                catch (Exception ex)
                {
                    _MensajeError = ex.Message;
                }
            }

            return _MensajeError;
        }

        #endregion

        #endregion

        #region Validacion de Acceso

        protected bool ValidaAccesoDocumento(Int64 CodiOper, string NumOper, Int64 CodUser)
        {
            bool AccesoDocumento = false;

            string sCodigo = Convert.ToString(CodiOper);
            if (sCodigo.Length > 5)
            {
                if (sCodigo.Substring(0, 1).ToString() == "1" || NumOper.Substring(0, 2).ToString() == "DD")
                {
                    WebGdoc.ServicesControllers.DigitalizacionController DocDigController = new WebGdoc.ServicesControllers.DigitalizacionController();
                    eDocDig DocDigCtr = new eDocDig();
                    IList<eDocDig> DocDigDT = new List<eDocDig>();

                    DocDigCtr.EstDocuDigi = string.Empty;
                    DocDigCtr.CodiDocuDigi = CodiOper;
                    DocDigCtr.NumDocuDigi = NumOper;
                    DocDigCtr.User = new eUsuario { Codigo = 0 };
                    DocDigDT = DocDigController.GetDocDigital(DocDigCtr);
                    if (DocDigDT.Count > 0)
                    {
                        //for (int i = 0; i < DocDigDT.Count; i++)
                        //{
                        if (DocDigDT[0].AcceDocuDigi == "PR")
                        {
                            AccesoDocumento = true;

                            if (ReturnUsuaPart(DocDigDT[0].CodiDocuDigi, CodUser))
                            {
                                AccesoDocumento = false;
                            }

                        }
                        //}
                    }
                }
                else if (sCodigo.Substring(0, 1).ToString() == "2" || NumOper.Substring(0, 2).ToString() == "DE")
                {
                    WebGdoc.ServicesControllers.DigitalizacionController DocElectController = new WebGdoc.ServicesControllers.DigitalizacionController();
                    eDocumentoElectronico DocElecCriteria = new eDocumentoElectronico();
                    IList<eDocumentoElectronico> DocElectDT = new List<eDocumentoElectronico>();

                    DocElecCriteria.EstDocuElec = string.Empty;
                    DocElecCriteria.CodiOper = CodiOper;
                    DocElecCriteria.NumDocuElec = NumOper;
                    DocElecCriteria.User = new eUsuario { Codigo = 1 };

                    DocElectDT = DocElectController.GetDocEle(DocElecCriteria);


                    if (DocElectDT.Count > 0)
                    {
                        //for (int i = 0; i < DocElectDT.Count; i++)
                        //{
                        if (DocElectDT[0].TipoAcc == "PR")
                        {
                            AccesoDocumento = true;

                            if (ReturnUsuaPart(DocElectDT[0].CodiOper, CodUser))
                            {
                                AccesoDocumento = false;
                            }

                        }
                        //}
                    }
                }
                else if (sCodigo.Substring(0, 1).ToString() == "3" || NumOper.Substring(0, 2).ToString() == "MV")
                {
                    WebGdoc.ServicesControllers.DigitalizacionController MesVirController = new WebGdoc.ServicesControllers.DigitalizacionController();
                    eMesaVirtual MesVirCtr = new eMesaVirtual();
                    IList<eMesaVirtual> MesaVir = new List<eMesaVirtual>();

                    MesVirCtr.CodiOper = CodiOper;
                    MesVirCtr.CodiUsu = 0;
                    MesVirCtr.NumOper = NumOper;

                    MesaVir = MesVirController.GetMesaVirtual(MesVirCtr);

                    if (MesaVir.Count > 0)
                    {
                        //for (int i = 0; i < MesaVir.Count; i++)
                        //{
                        if (MesaVir[0].Acceso == "PR")
                        {
                            AccesoDocumento = true;

                            if (ReturnUsuaPart(MesaVir[0].CodiOper, CodUser))
                            {
                                AccesoDocumento = false;
                            }
                        }
                        //}
                    }
                }
            }
            return AccesoDocumento;
        }

        protected bool ReturnUsuaPart(Int64 CodDoc, Int64 CodUser)
        {
            WebGdoc.ServicesControllers.GestionController GestCon = new WebGdoc.ServicesControllers.GestionController();
            eParticipante CtrUser = new eParticipante();
            IList<eParticipante> UserPart = new List<eParticipante>();

            bool Usuario = false;

            CtrUser.CodiOper = CodDoc;
            CtrUser.CodiUsu = 0;
            UserPart = GestCon.GetUserPart(CtrUser);
            for (int i = 0; i < UserPart.Count; i++)
            {
                if (UserPart[i].CodiUsu == CodUser)
                {
                    Usuario = true;
                }
            }

            return Usuario;
        }

        protected bool ReturnUsuaPartBatch(List<eParticipante> listUsuarioPart, Int64 CodDoc, Int64 CodUser)
        {
            WebGdoc.ServicesControllers.GestionController GestCon = new WebGdoc.ServicesControllers.GestionController();
            eParticipante CtrUser = new eParticipante();
            IList<eParticipante> UserPart = new List<eParticipante>();

            bool Usuario = false;

            UserPart = listUsuarioPart.FindAll(x => x.CodiOper == CodDoc);

            for (int i = 0; i < UserPart.Count; i++)
            {
                if (UserPart[i].CodiUsu == CodUser)
                {
                    Usuario = true;
                }
            }

            return Usuario;
        }

        #endregion

        #region Cache Lists
        public IList<eUsuario> GetListaUsuarioPer(eUsuario oUsuarioPer, bool useCache)
        {
            try
            {
                GestionController UserOper = new GestionController();
                var cache = new CacheProvider();
                string key = "ListaUsuarioPer";
                List<eUsuario> listaUsuarioPer = (List<eUsuario>)cache.Get(key);
                if (listaUsuarioPer == null || !useCache)
                {
                    listaUsuarioPer = new List<eUsuario>(UserOper.GetListaUsuarioPer(oUsuarioPer));
                    cache.Set(key, listaUsuarioPer);
                }

                IList<eUsuario> filteredList = listaUsuarioPer;

                //Apply filters            
                if (listaUsuarioPer != null && listaUsuarioPer.Count > 0)
                {
                    //1.  @Codigo <> ''
                    if (oUsuarioPer.Codigo > 0)
                    {
                        filteredList = listaUsuarioPer.FindAll(x => x.Codigo == oUsuarioPer.Codigo);
                    }

                    //2.  @sIdeUsu <> ''
                    if (!string.IsNullOrEmpty(oUsuarioPer.IdeUsuario))
                    {
                        filteredList = listaUsuarioPer.FindAll(x => x.IdeUsuario.ToUpper() == oUsuarioPer.IdeUsuario.ToUpper());
                    }
                    //3.  @sNomUsu <> ''
                    if (!string.IsNullOrEmpty(oUsuarioPer.NombPers))
                    {
                        filteredList = listaUsuarioPer.FindAll(x => (x.NombPers + " " + x.ApePers).ToUpper().Contains(oUsuarioPer.NombPers.ToUpper()));
                    }
                    //4.  @DNI <> ''
                    if (oUsuarioPer.Pers != null && !string.IsNullOrEmpty(oUsuarioPer.Pers.DNI))
                    {
                        filteredList = listaUsuarioPer.FindAll(x => x.Pers.DNI == oUsuarioPer.Pers.DNI);
                    }
                }
                return filteredList;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al obtener la lista de usuarios." + ex.Message);
            }
        }
        #endregion
    }
}


