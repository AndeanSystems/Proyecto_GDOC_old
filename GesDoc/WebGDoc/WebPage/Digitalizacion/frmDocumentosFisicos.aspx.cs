using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using WebGdoc.ServicesControllers;
using WebGdoc.DigitalizacionServRef;
using WebGdoc.GestionServRef;
using WebGdoc.WebPage.Inicio;
using WebGdoc.WebPage.Controles;
using Microsoft.VisualBasic;
using System.IO;
using Entity.Entities;
using AjaxControlToolkit;

namespace WebGdoc.WebPage.Digitalizacion
{
    public partial class frmDocumentosFisicos : WebGdoc.Resources.Utility
    {

#region Variables

        string sTipoOperacion = "DD";
        string sEstTipoDocumento = string.Empty;
        DataTable TempGvw = new DataTable();
        DataRow TemDr;
        bool sInd;
        string sTipoEvento;
        string sCodOper;
        string sRefDig;
        Int64 iCodDocDig;
        Int64 Cont;
        ArrayList ArrCodInd = new ArrayList();
        ArrayList ArrDesInd = new ArrayList();
        string sSession;
        string sVacio = string.Empty;
        string smn;
        
        string sPageLocal = "../Digitalizacion/frmDocumentosFisicos.aspx";
        string sNumOper = "";
        Int64  sCodOperacion = 0;

#endregion
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ibtnEditar.Enabled = false;
            if (Request.QueryString["NumOper"] != null){
                sNumOper = Request.QueryString["NumOper"];
            }

            if (Request.QueryString["CodOper"] != null){
                sCodOperacion = Convert.ToInt64(Request.QueryString["CodOper"]);
            }

            
            if (VerificarSessionUsuario(tbPrincipal))
            {
                if (!IsPostBack)
                {
                    Session.Remove("sURLActual");
                    Session.Add("sURLActual", Request.Url.ToString());

                    if (Request.QueryString["sError"] != null)
                    {
                        Int64 sLongitub = Convert.ToInt64(ConfigurationManager.AppSettings.Get("MB_Cargar").ToString());

                        MensajeAlerta(ImageButton3, "La carga maxima permitida es " + sLongitub.ToString() + " KB");
                    }
            

                    CargarDefault();

                    CargarComboBoxInicial();

                    if (sNumOper != "" && sNumOper != null || sCodOperacion != 0)
                    {
                        LimpiarControles(ctlUser);
                        Buscar(sCodOperacion, sNumOper);
                        ibtnBuscar.Enabled = false;
                    }

                    ConfigurarBarraHerramientas();

                    EstadoControlPage(false);

                    ValidarGridView();

                    ibtnEnviar.Visible = false;

                    rdnDeriva.SelectedValue = "S";
                }

                CargarImagen();
            }
        }

        protected void CargarImagen()
        {
            ibtnNuevo.ImageUrl = _UrlImagen + "img_Nuevo_" + (ibtnBuscar.Enabled ? "A" : "I") + ".jpg";
            ibtnEditar.ImageUrl = _UrlImagen + "img_Editar_" + (ibtnEditar.Enabled ? "A" : "I") + ".jpg";
            ibtnGuardar.ImageUrl = _UrlImagen + "img_Guardar_" + (ibtnGuardar.Enabled ? "A" : "I") + ".jpg";
            ibtnEnviar.ImageUrl = _UrlImagen + "img_Enviar_" + (ibtnEnviar.Enabled ? "A" : "I") + ".jpg";
            ibtnEliminar.ImageUrl = _UrlImagen + "img_Eliminar_" + (ibtnEliminar.Enabled ? "A" : "I") + ".jpg";
            ibtnRegresar.ImageUrl = _UrlImagen + "img_Inicio_" + (ibtnRegresar.Enabled ? "A" : "I") + ".jpg";

            ibtnBuscar.ImageUrl = _UrlImagen + "img_Buscar_" + (ibtnBuscar.Enabled ? "A" : "I") + ".jpg";

            ibtnFecEmision.ImageUrl = _UrlImagen + "img_Calendario_" + (ibtnFecEmision.Enabled ? "A" : "I") + ".jpg";
            ibtnFecReferencia.ImageUrl = _UrlImagen + "img_Calendario_" + (ibtnFecReferencia.Enabled ? "A" : "I") + ".jpg";

            ImageButton3.ImageUrl = _UrlImagen + "img_CargarArchivo_" + (ImageButton3.Enabled ? "A" : "I") + ".jpg";

            ibtnReferencia.ImageUrl = _UrlImagen + "img_IndiceDocumento_" + (ibtnReferencia.Enabled ? "A" : "I") + ".jpg";
        }

        protected void ibtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            LimpiarControles(ctlUser);
            if (ValidaAccesoDocumento(0, txtNroDoc.Text.Trim(), Convert.ToInt64(Session["sCodUsu"].ToString())))
            {
                MensajeAlerta(ibtnBuscar, "El Documento a buscar es de caracter Privado. Ud no es usuario participante del documento");
                return;
            }
            Buscar(0, txtNroDoc.Text.Trim());

        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Int64 sLongitub = Convert.ToInt64(ConfigurationManager.AppSettings.Get("MB_Cargar").ToString());
            Int64 sConvercion = Convert.ToInt64(ConfigurationManager.AppSettings.Get("MB_").ToString());
            HttpPostedFile mifichero = uplServerFTP.PostedFile;

            try
            {                   
                if (sLongitub > (mifichero.ContentLength / sConvercion))
                {
                    txtNomOrigArch.Text = Path.GetFileNameWithoutExtension(mifichero.FileName);

                    string sExtencionArchivo = ReturnExtensionArchivo(uplServerFTP.PostedFile.FileName);
                    string sNombreTmp = Session["sUsuario"].ToString() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    Session.Add("sCargarArchivo", sNombreTmp);
                    Session.Add("sUplServerFTP", uplServerFTP);

                    CargarArchivoFTP(uplServerFTP, "\\TMP\\", Session["sCargarArchivo"].ToString(), sExtencionArchivo);
                    OpenNewTab(ImageButton3, "frmVerArchivo.aspx?Archivo=" + sNombreTmp + sExtencionArchivo); 
                    //ifmDocumento.Attributes["src"] = "frmVerArchivo.aspx?Archivo=" + sNombreTmp + sExtencionArchivo;
                }
                else
                {
                    MensajeAlerta(ImageButton3, "La carga maxima permitida es " + sLongitub.ToString() + " KB");
                }
            }
            catch (Exception ex)
            {
                MensajeAlerta(ImageButton3, "La carga maxima permitida es " + sLongitub.ToString() + " KB");
            }
        }

        protected void ibtnReferencia_Click(object sender, ImageClickEventArgs e)
        {
                TempGvw.Columns.Add("sReferencia");

                TemDr = TempGvw.NewRow();
                TemDr[0] = txtReferencia.Text;
                TempGvw.Rows.Add(TemDr);

                if (lblCodDig.Text != "")
                {
                    if (lblArrDes.Text == "")
                    {
                        lblArrDes.Text = txtReferencia.Text;
                    }
                    else
                    {
                        lblArrDes.Text = lblArrDes.Text + "," + txtReferencia.Text;
                    }
                }

                for (int i = 0; i < gvwReferencias.Rows.Count; i++)
                {
                    if (!gvwReferencias.Rows[i].Cells[0].Text.Equals("&nbsp;"))
                    {
                        TemDr = TempGvw.NewRow();
                        TemDr[0] = gvwReferencias.Rows[i].Cells[0].Text;
                        TempGvw.Rows.Add(TemDr);
                    }
                }
                gvwReferencias.DataSource = TempGvw;
                gvwReferencias.DataBind();
                txtReferencia.Text = "";
                txtReferencia.Focus();
                
                
        }
        
        protected void gvwReferencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            DigitalizacionController IndexaController = new DigitalizacionController();
            eDocDigRef IndexaCriteria = new eDocDigRef();
            IList<eDocDigRef> DocRef = new List<eDocDigRef>();

            int sRows = gvwReferencias.SelectedIndex;
            

            if (sRows > -1)
            {
                TempGvw.Columns.Add("sReferencia");
                for (int i = 0; i < gvwReferencias.Rows.Count; i++)
                {
                    if (i != sRows)
                    {
                        TemDr = TempGvw.NewRow();
                        TemDr[0] = gvwReferencias.Rows[i].Cells[0].Text;
                        TempGvw.Rows.Add(TemDr);
                    }
                    else
                    {
                        if (txtNroDoc.Text != "")
                        {
                            sRefDig = gvwReferencias.Rows[sRows].Cells[0].Text;
                            IndexaCriteria.EstaInde = "";
                            IndexaCriteria.CodiOper = Convert.ToInt64(lblCodDig.Text); ;
                            DocRef = IndexaController.GetDocDigRef(IndexaCriteria);
                            if (DocRef.Count > 0)
                            {
                                for (int a = 0; a < DocRef.Count; a++)
                                {
                                    if (DocRef[a].DescInde == sRefDig)
                                    {
                                        if (lblArrCod.Text == "")
                                        {
                                            lblArrCod.Text = DocRef[a].CodiInde.ToString();
                                        }
                                        else
                                        {
                                            lblArrCod.Text = lblArrCod.Text + "," + DocRef[a].CodiInde.ToString();
                                            //ArrCodInd.Add(DocRef[a].CodiInde.ToString());
                                        }

                                    }
                                }
                            }
                        }
                    }
                }

                if (TempGvw.Rows.Count > 0)
                {
                    gvwReferencias.DataSource = TempGvw;
                    gvwReferencias.DataBind();
                    TempGvw.Columns.Clear();
                    TempGvw.Clear();
                }
                else
                {
                    gvwReferencias.DataSource = null;
                    gvwReferencias.DataBind();

                    VerificarGridView(gvwReferencias);
                }                              
            }
        }

        protected void ibtnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            if (ValidarCamposObligatorios())
            {
                if (rdnDeriva.SelectedValue == "S")
                {
                    if (txtNroDoc.Text == "")
                        EnviarDocumentoDigital();
                    else
                        EnviarDocumentoDigitalUpdate();
                }
                else
                {
                    if (txtNroDoc.Text == "")
                        GuardarDocumentoDigital();
                    else
                        GuardarDocumentoDigitalUpdate();
                }

                Session.Remove("sUplServerFTP");
                Session.Remove("sUplServerFileBytes");
            }
            else
                MensajeAlerta(ibtnGuardar, "Los datos ingresados no son correctos o estan incompletos");
        }

        protected void ibtnEnviar_Click(object sender, ImageClickEventArgs e)
        {

            
        }

        protected void ibtnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            sSession = Session["sCodUsu"].ToString();
            FileUpload sCtlUplServerFTP = (FileUpload)Session["sUplServerFTP"];

            Mantenimiento_DocumentoDigital(Convert.ToInt64(lblCodDig.Text), "N", "2", 1, sCtlUplServerFTP);
            Mantenimiento_IndexacionDocDig(Convert.ToInt64(lblCodDig.Text), "", "Delete");

            sCodOper = lblCodDig.Text;
            sTipoEvento = "DD009";

            LogOperacion(sCodOper, sSession);

            MensajeAlerta(ibtnEliminar, "Documento Digital Eliminado Correctamente ");
        }

        protected void ibtnNuevo_Click(object sender, ImageClickEventArgs e)
        {

            /*RedireccionarPage(ibtnNuevo, sPageLocal);
            EstadoControlPage(true);*/
            LimpiarControlPage();
            EstadoControlPage(true);
            lblCodDig.Text = "";
            lblArrCod.Text = "";
            lblArrDes.Text = "";
            txtFecEmision.Text = System.DateTime.Now.ToShortDateString();
            txtFecReferencia.Text = System.DateTime.Now.ToShortDateString();
            rdnDeriva.SelectedValue = "S";
            rbtnNivelAcceso.SelectedValue = "PU";
            ddlClaseDoc.Enabled = true;
            txtNroDoc.Enabled = false;
            txtNroDoc.Text = "";
            txtNomOrigArch.Focus();
            ibtnBuscar.Enabled = false;

            //ibtnNuevo.Enabled = false;
            ibtnEliminar.Enabled = false;

        }

        protected void ibtnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            string sPageInicio = "../Inicio/frmEscritorioVirtual.aspx";
            RedireccionarPage(tbPrincipal, sPageInicio);
        }



        protected void CargarFileFTP(string sFileTmp, string sNombreTmp, string sExtencionArchivo)
        { 
            lnkVerArchivo.Visible = true;
            lnkVerArchivo.CommandName = "frmVerArchivo.aspx?Archivo=" + sFileTmp + "/" + sNombreTmp + sExtencionArchivo;
        }

        protected void lnkVerArchivo_Click(object sender, EventArgs e)
        {
            OpenNewTab(ImageButton3, lnkVerArchivo.CommandName);
        }

        protected void CargarDefault()
        {
            rdnDeriva.SelectedValue = "S";
            txtNroDoc.Focus();

            if (Session["sCodigo"] != null)
            {
                if (Session["sCodigo"].ToString() != "")
                {
                    Buscar(Convert.ToInt64(Session["sCodigo"].ToString()), "");

                    EstadoControlPage(false);

                    txtNroDoc.Enabled = false;
                    ibtnBuscar.Enabled = false;
                    ibtnNuevo.Enabled = false;

                    Session.Add("sCodigo", sVacio);
                }
            }
        }

        protected void CargarComboBoxInicial()
        {
            DigitalizacionController DocDigiController = new DigitalizacionController();
            eDocDigListTD eDocDigListTD = new eDocDigListTD();
            IList<eDocDigListTD> ListeDocDigListTD = new List<eDocDigListTD>();

            eDocDigListTD.EstTipoDocumento = sEstTipoDocumento;
            ListeDocDigListTD = DocDigiController.GetTipoDocumDigital(eDocDigListTD);

            CargarDropDownList(ddlClaseDoc, ListeDocDigListTD, "NombTipoDocu", "CodiTipoDocu");
        }

        protected void ConfigurarBarraHerramientas()
        {
            /*List<string> sLstLink = new List<string>();
            sLstLink.Add("WebPage/Gestion/frmDocumentoElectronico.aspx|Nuevo documento electrónico|u17_original.png");
            sLstLink.Add("WebPage/Busquedas/frmDocumentosElectronicos.aspx|Buscar documento electrónico|u21_original.png");
            sLstLink.Add("WebPage/Gestion/frmMesaVirtual.aspx|Organizar mesa de trabajo virtual|u25_original.jpg");
            sLstLink.Add("WebPage/Digitalizacion/frmDocumentosFisicos.aspx|Digitalización de documentos|u29_original.jpg");
*/
            ReferenciarTitulo(this, "Digitalización de Documentos");
            //ReferenciarLink(this, sLstLink);
        }        

        protected void ValidarGridView()
        {
            VerificarGridView(gvwReferencias);

        }

        protected void LimpiarControlPage()
        {
            lnkVerArchivo.Visible = false;

            LimpiarControles(txtAsunto);

            LimpiarControles(txtTitulo);

            LimpiarControles(txtComentario);

            LimpiarControles(txtNomOrigArch);

            LimpiarControles(txtReferencia);
            
            LimpiarControles(gvwReferencias);
            
            LimpiarControles(ddlClaseDoc);
            CargarComboBoxInicial();
            
            LimpiarControles(ctlUser);
            ctlUser.UserSesion = true;

            LimpiarControles(ct1UserRec);
            
            LimpiarControles(rbtnNivelAcceso);
            
            LimpiarControles(rdnDeriva);            
        }

        protected void EstadoControlPage(bool status)
        {
            txtAsunto.Enabled = status;
            txtNomOrigArch.Enabled = status;
            txtReferencia.Enabled = status;
            uplServerFTP.Enabled = status;// ? false : true ;
            ImageButton3.Enabled = status;
            ibtnReferencia.Enabled = status;
            txtTitulo.Enabled = status;
            txtComentario.Enabled = status;
            gvwReferencias.Enabled = status;
            ddlClaseDoc.Enabled = status;
            btnAgregar.Visible = false;
            ibtnEliminar.Enabled = status;
            ibtnGuardar.Enabled = status;
            ibtnEnviar.Enabled = status;
            ibtnFecEmision.Enabled = status;
            ibtnFecReferencia.Enabled = status;
            ctlUser.EnabledControl = status;
            ct1UserRec.EnabledControl = status;
            rbtnNivelAcceso.Enabled = status;
            rdnDeriva.Enabled = status;
            ctlUser.EnabledControl = false;
        }
        
        protected void ReturnUsuaPart(Int64 CodDoc, int sTipoPart, ValidarUsuario_Grupo ctlUsuarioValido)
        {
            GestionController GestCon = new GestionController();
            eParticipante CtrUser = new eParticipante();
            IList<eParticipante> UserPart = new List<eParticipante>();

            eUsuario ReturnUser = new eUsuario();
            IList<eUsuario> LstReturnUser = new List<eUsuario>();
            eUsuario UserCriteria = new eUsuario();

            CtrUser.CodiOper = CodDoc;
            CtrUser.CodiUsu = 0;
            UserPart = GestCon.GetUserPart(CtrUser);
            for(int i = 0; i<UserPart.Count;i++)
            {
                if (UserPart[i].TipoPart == sTipoPart)
                {
                    UserCriteria.Codigo = UserPart[i].CodiUsu;
                    LstReturnUser = GetListaUsuarioPer(UserCriteria, true);

                    ctlUsuarioValido.UsuarioInsert = LstReturnUser;
                }
                if (UserPart[i].TipoPart == 6)
                {
                    if (UserPart[i].CodiUsu == Convert.ToInt64(Session["sCodUsu"].ToString()))
                    {
                        ibtnEditar.Enabled = true;
                        ibtnEliminar.Enabled = true;
                        ibtnGuardar.Enabled = true;
                    }
                    else
                        EstadoControlPage(false);
                }

            }
        }



        protected void GuardarDocumentoDigital()
        {
            if (Session["sUplServerFTP"] != null)
            {
                FileUpload sCtlUplServerFTP = (FileUpload)Session["sUplServerFTP"];

                if (sCtlUplServerFTP.PostedFile.FileName != "")
                {
                    //string sPageInicio = "../Digitalizacion/frmDocumentosFisicos.aspx";

                    DigitalizacionController DocDigController = new DigitalizacionController();
                    eDocDig eDocDig = new eDocDig();

                    sSession = Session["sCodUsu"].ToString();

                    if (txtNroDoc.Text == "")
                    {
                        Mantenimiento_DocumentoDigital(0, "C", "1", Convert.ToInt64(sSession), sCtlUplServerFTP);

                        for (int i = 0; i < gvwReferencias.Rows.Count; i++)
                            if (gvwReferencias.Rows[0].Cells[0].Text != "" && gvwReferencias.Rows[0].Cells[0].Text !="&nbsp;")
                                Mantenimiento_IndexacionDocDig(Convert.ToInt64(lblCodDig.Text), gvwReferencias.Rows[i].Cells[0].Text, "");

                        //SubirArchivoFTP(sCtlUplServerFTP, ddlClaseDoc.SelectedItem.Text, lblNumDig.Text.Trim(), Path.GetExtension(sCtlUplServerFTP.PostedFile.FileName));
                        GuardarArchivoFTP("\\TMP\\" + Session["sCargarArchivo"], ddlClaseDoc.SelectedItem.Text, lblNumDig.Text.Trim(), Path.GetExtension(sCtlUplServerFTP.PostedFile.FileName));

                        if (lblNumDig.Text != "")
                        {
                            sCodOper = lblCodDig.Text;
                            sTipoEvento = "DD001";
                            RegistroUsuarioParticipante(Convert.ToInt64(lblCodDig.Text), (int)UserTipo.DocDigEmisor, ctlUser, "N");

                            RegistroUsuarioParticipante(Convert.ToInt64(lblCodDig.Text), (int)UserTipo.DocDigDestinatario, ct1UserRec, "N");

                            LogOperacion(sCodOper, sSession);

                            MensajeAlerta(btnAgregar, "El Documento Digital Nro " + lblNumDig.Text.Trim() + " se grabo con exito", sPageLocal);
                        }
                        else
                            MensajeAlerta(btnAgregar, "Error al grabar documento digital");
                    }
                    else
                    {
                        sTipoEvento = "DD003";
                        LogOperacion(sCodOper, sSession);

                        sTipoEvento = "DD006";
                        LogOperacion(sCodOper, sSession);

                        AnulaParticipante(Convert.ToInt64(lblCodDig.Text), 0);

                        RegistroUsuarioParticipante(Convert.ToInt64(lblCodDig.Text), (int)UserTipo.DocDigEmisor, ctlUser, "N");

                        RegistroUsuarioParticipante(Convert.ToInt64(lblCodDig.Text), (int)UserTipo.DocDigDestinatario, ct1UserRec, "N");

                        Mantenimiento_DocumentoDigital(Convert.ToInt64(lblCodDig.Text), "C", "2", 1, sCtlUplServerFTP);

                        Mantenimiento_IndexacionDocDig(Convert.ToInt64(lblCodDig.Text), "", "N");

                        Mantenimiento_IndexacionDocDig(Convert.ToInt64(lblCodDig.Text), "", "");

                        MensajeAlerta(btnAgregar, "El Documento Digital Nro " + lblNumDig.Text.Trim() + " se actualizo con exito", sPageLocal);
                    }
                }
            }
        }

        protected void GuardarDocumentoDigitalUpdate()
        {
            DigitalizacionController DocDigController = new DigitalizacionController();
            eDocDig eDocDig = new eDocDig();

            sSession = Session["sCodUsu"].ToString();

            if (txtNroDoc.Text == "")
            {
                Mantenimiento_DocumentoDigitalUpdate(0, "C", "1", Convert.ToInt64(sSession), "");

                for (int i = 0; i < gvwReferencias.Rows.Count; i++)
                    if (gvwReferencias.Rows[0].Cells[0].Text != "" && gvwReferencias.Rows[0].Cells[0].Text != "&nbsp;")
                        Mantenimiento_IndexacionDocDig(Convert.ToInt64(lblCodDig.Text), gvwReferencias.Rows[i].Cells[0].Text, "");

                if (lblNumDig.Text != "")
                {
                    sCodOper = lblCodDig.Text;
                    sTipoEvento = "DD001";
                    RegistroUsuarioParticipante(Convert.ToInt64(lblCodDig.Text), (int)UserTipo.DocDigEmisor, ctlUser, "N");

                    RegistroUsuarioParticipante(Convert.ToInt64(lblCodDig.Text), (int)UserTipo.DocDigDestinatario, ct1UserRec, "N");

                    LogOperacion(sCodOper, sSession);

                    MensajeAlerta(btnAgregar, "El Documento Digital Nro " + lblNumDig.Text.Trim() + " se grabo con exito", sPageLocal);
                }
                else
                    MensajeAlerta(btnAgregar, "Error al grabar documento digital");
            }
            else
            {
                sTipoEvento = "DD003";
                LogOperacion(sCodOper, sSession);

                sTipoEvento = "DD006";
                LogOperacion(sCodOper, sSession);

                AnulaParticipante(Convert.ToInt64(lblCodDig.Text), 0);

                RegistroUsuarioParticipante(Convert.ToInt64(lblCodDig.Text), (int)UserTipo.DocDigEmisor, ctlUser, "N");

                RegistroUsuarioParticipante(Convert.ToInt64(lblCodDig.Text), (int)UserTipo.DocDigDestinatario, ct1UserRec, "N");

                Mantenimiento_DocumentoDigitalUpdate(Convert.ToInt64(lblCodDig.Text), "C", "2", Convert.ToInt64(Session), "");

                Mantenimiento_IndexacionDocDig(Convert.ToInt64(lblCodDig.Text), "", "N");

                Mantenimiento_IndexacionDocDig(Convert.ToInt64(lblCodDig.Text), "", "");

                MensajeAlerta(btnAgregar, "El Documento Digital Nro " + lblNumDig.Text.Trim() + " se actualizo con exito", sPageLocal);
            }
               
        }

        protected void EnviarDocumentoDigital()
        {
            FileUpload sCtlUplServerFTP = (FileUpload)Session["sUplServerFTP"];
            if (sCtlUplServerFTP.PostedFile.FileName != "")
            {
                DigitalizacionController DocDigController = new DigitalizacionController();
                eDocDig eDocDig = new eDocDig();
                IList<eDocDig> DocDigDT = new List<eDocDig>();
                Int64 sCodUsuario = 0;
                eDocDig.EstDocuDigi = string.Empty;
                eDocDig.CodiDocuDigi = 0;
                eDocDig.NumDocuDigi = txtNroDoc.Text.Trim();
                eDocDig.User = new eUsuario { Codigo = 0 };
                DocDigDT = DocDigController.GetDocDigital(eDocDig);
                sSession = Session["sCodUsu"].ToString();

                if (DocDigDT.Count > 0)
                {
                    Mantenimiento_DocumentoDigital(DocDigDT[0].CodiDocuDigi, "E", "2", Convert.ToInt64(sSession), sCtlUplServerFTP);
                    AnulaParticipante(Convert.ToInt64(lblCodDig.Text), 0);
                }
                else
                {
                    Mantenimiento_DocumentoDigital(0, "E", "1", Convert.ToInt64(sSession), sCtlUplServerFTP);


                    for (int i = 0; i < gvwReferencias.Rows.Count; i++)
                    {
                        if (gvwReferencias.Rows[0].Cells[0].Text != "" && gvwReferencias.Rows[0].Cells[0].Text != "&nbsp;")
                        {
                            Mantenimiento_IndexacionDocDig(Convert.ToInt64(lblCodDig.Text), gvwReferencias.Rows[i].Cells[0].Text, "");
                        }
                    }
                }

                //SubirArchivoFTP(sCtlUplServerFTP, ddlClaseDoc.SelectedItem.Text, lblNumDig.Text.Trim(), Path.GetExtension(sCtlUplServerFTP.PostedFile.FileName));
                GuardarArchivoFTP("\\TMP\\" + Session["sCargarArchivo"], ddlClaseDoc.SelectedItem.Text, lblNumDig.Text.Trim(), Path.GetExtension(sCtlUplServerFTP.PostedFile.FileName));

                RegistroUsuarioParticipante(Convert.ToInt64(lblCodDig.Text), (int)UserTipo.DocDigEmisor, ctlUser, "N");

                RegistroUsuarioParticipante(Convert.ToInt64(lblCodDig.Text), (int)UserTipo.DocDigDestinatario, ct1UserRec, "S");

                sCodOper = lblCodDig.Text;
                sTipoEvento = "DD007";

                GridView sUserSelect = ct1UserRec.UsuarioSelect;

                for (int i = 0; i < sUserSelect.Rows.Count; i++)
                {
                    sCodUsuario = Convert.ToInt64(sUserSelect.Rows[i].Cells[0].Text);
                    LogOperacion(sCodOper, Convert.ToString(sCodUsuario));
                    MensajeAlerta(sCodOper, Convert.ToString(sCodUsuario));
                }

                //MensajeAlerta(ibtnEnviar, "Documento Digital Enviado Correctamente ", sPageLocal);
                MensajeAlerta(btnAgregar, "El Documento Digital Nro " + lblNumDig.Text.Trim() + " se registro correctamente", sPageLocal);
            }
        }

        protected void EnviarDocumentoDigitalUpdate()
        {

                DigitalizacionController DocDigController = new DigitalizacionController();
                eDocDig eDocDig = new eDocDig();
                IList<eDocDig> DocDigDT = new List<eDocDig>();
                Int64 sCodUsuario = 0;
                eDocDig.EstDocuDigi = string.Empty;
                eDocDig.CodiDocuDigi = 0;
                eDocDig.NumDocuDigi = txtNroDoc.Text.Trim();
                eDocDig.User = new eUsuario { Codigo = 0 };
                DocDigDT = DocDigController.GetDocDigital(eDocDig);
                if (DocDigDT.Count > 0)
                {
                    Mantenimiento_DocumentoDigitalUpdate(DocDigDT[0].CodiDocuDigi, "E", "2", 1, "");
                    AnulaParticipante(Convert.ToInt64(lblCodDig.Text), 0);
                }
                else
                {
                    Mantenimiento_DocumentoDigitalUpdate(0, "E", "1", 1, "");


                    for (int i = 0; i < gvwReferencias.Rows.Count; i++)
                    {
                        if (gvwReferencias.Rows[0].Cells[0].Text != "" && gvwReferencias.Rows[0].Cells[0].Text != "&nbsp;")
                        {
                            Mantenimiento_IndexacionDocDig(Convert.ToInt64(lblCodDig.Text), gvwReferencias.Rows[i].Cells[0].Text, "");
                        }
                    }
                }
                RegistroUsuarioParticipante(Convert.ToInt64(lblCodDig.Text), (int)UserTipo.DocDigEmisor, ctlUser, "N");

                RegistroUsuarioParticipante(Convert.ToInt64(lblCodDig.Text), (int)UserTipo.DocDigDestinatario, ct1UserRec, "S");

                sCodOper = lblCodDig.Text;
                sTipoEvento = "DD007";

                GridView sUserSelect = ct1UserRec.UsuarioSelect;

                for (int i = 0; i < sUserSelect.Rows.Count; i++)
                {
                    sCodUsuario = Convert.ToInt64(sUserSelect.Rows[i].Cells[0].Text);
                    LogOperacion(sCodOper, Convert.ToString(sCodUsuario));
                    MensajeAlerta(sCodOper, Convert.ToString(sCodUsuario));
                }

                //MensajeAlerta(ibtnEnviar, "Documento Digital Enviado Correctamente ", sPageLocal);
                MensajeAlerta(btnAgregar, "El Documento Digital Nro " + lblNumDig.Text.Trim() + " se registro correctamente", sPageLocal);

        }

        protected void Buscar(Int64 CodDocDig,string NumDocDig)
        {
            DigitalizacionController DocDigController = new DigitalizacionController();
            GestionController GestControl = new GestionController();
            eDocDig DocDigCtr = new eDocDig();
            IList<eDocDig> DocDigDT = new List<eDocDig>();
            IList<eDocDigRef> DocRef = new List<eDocDigRef>();
            eDocDigRef RefCtr = new eDocDigRef();

            EstadoControlPage(true);

            DocDigCtr.EstDocuDigi = string.Empty;
            DocDigCtr.CodiDocuDigi = CodDocDig; //0;
            DocDigCtr.NumDocuDigi = NumDocDig.ToUpper();  //txtNroDoc.Text.Trim();
            DocDigCtr.User = new eUsuario { Codigo = Convert.ToInt64(Session["sCodUsu"].ToString()) };
            DocDigDT = DocDigController.GetDocDigital(DocDigCtr);

            if (DocDigDT.Count > 0)
            {
                if (DocDigDT[0].EstDocuDigi != "N")
                {
                   
                    //if (Session["sCodigo"].ToString() != "")
                    //{
                    //    txtNroDoc.Text = DocDigDT[0].NumDocuDigi;
                    //}

                    rdnDeriva.ClearSelection();

                    txtNroDoc.Text = DocDigDT[0].NumDocuDigi;
                    txtNomOrigArch.Text = DocDigDT[0].NombOrig;
                    ddlClaseDoc.SelectedValue = DocDigDT[0].CodiTipoDocu.Trim();
                    txtFecEmision.Text = DocDigDT[0].FechEmiDocu.ToShortDateString();
                    txtFecReferencia.Text = DocDigDT[0].FechRece.ToShortDateString();
                    rbtnNivelAcceso.SelectedValue = DocDigDT[0].AcceDocuDigi;
                    rdnDeriva.SelectedValue = !string.IsNullOrEmpty(DocDigDT[0].ClasDocu.Trim()) ? DocDigDT[0].ClasDocu.Trim() : "N";
                    txtAsunto.Text = DocDigDT[0].AsunDocuDigi;
                    txtTitulo.Text = DocDigDT[0].TituDocuDigi;
                    txtComentario.Text = DocDigDT[0].Comentario;
                    iCodDocDig = DocDigDT[0].CodiDocuDigi;
                    lblCodDig.Text = iCodDocDig.ToString();

                   

                    ReturnUsuaPart(DocDigDT[0].CodiDocuDigi, 6, ctlUser);

                    ReturnUsuaPart(DocDigDT[0].CodiDocuDigi, 7, ct1UserRec);

                    if (DocDigDT[0].EstDocuDigi != "C")
                    {
                        EstadoControlPage(false);
                        ibtnEditar.Enabled = false;
                        ibtnEliminar.Enabled = false;
                        ibtnGuardar.Enabled = false;
                    }
                 

                    RefCtr.EstaInde = "E";
                    RefCtr.CodiOper = DocDigDT[0].CodiDocuDigi;

                    Session.Add("sUplServerFTP", "");
                    CargarFileFTP(ddlClaseDoc.SelectedItem.Text.Trim(), DocDigDT[0].NumDocuDigi.Trim(), DocDigDT[0].ExteDocu.Trim());

                    DocRef = DocDigController.GetDocDigRef(RefCtr);
                    TempGvw.Columns.Add("sReferencia");

                    if (DocRef.Count > 0)
                    {

                        for (int i = 0; i < DocRef.Count; i++)
                        {
                            smn = DocRef[i].DescInde.ToString();

                            TemDr = TempGvw.NewRow();
                            TemDr[0] = smn;
                            TempGvw.Rows.Add(TemDr);
                        }

                        gvwReferencias.DataSource = TempGvw;
                        gvwReferencias.DataBind();
                    }
                    TempGvw.Clear();
                }
            }
            else
            { MensajeAlerta(ibtnBuscar, "El Documento Digital N°" + txtNroDoc.Text.Trim() + " no existe "); EstadoControlPage(false); }
        }

        protected void Mantenimiento_DocumentoDigital(Int64 CodOper, string sEstado, string Tipo, Int64 CodUsu, FileUpload sCtlUplServerFTP)
        {
            Int64 oReturn = 0;
            DigitalizacionController DocDigController = new DigitalizacionController();
            eDocDig eDocDig = new eDocDig();
                        
            eDocDig.CodiDocuDigi = CodOper;
            eDocDig.Type = Tipo;
            eDocDig.NumDocuDigi = txtNroDoc.Text;
            eDocDig.NombOrig = txtNomOrigArch.Text;
            eDocDig.TituDocuDigi = txtTitulo.Text;
            eDocDig.Comentario = txtComentario.Text;
            eDocDig.AsunDocuDigi = txtAsunto.Text;

            eDocDig.RutaFisi = ConfigurationManager.AppSettings.Get("ServidorFTP");
            eDocDig.TamaDocu = 0;
            eDocDig.ExteDocu = Path.GetExtension(sCtlUplServerFTP.PostedFile.FileName);
            eDocDig.NombFisi = Path.GetFileNameWithoutExtension(sCtlUplServerFTP.PostedFile.FileName);
            eDocDig.ClasDocu = rdnDeriva.SelectedValue;
            eDocDig.EstDocuDigi = sEstado;
            eDocDig.FechEmiDocu = Convert.ToDateTime(txtFecEmision.Text + " " + DateTime.Now.TimeOfDay);
            eDocDig.FechRece = Convert.ToDateTime(txtFecReferencia.Text + " " + DateTime.Now.TimeOfDay);
            eDocDig.FechRegi = System.DateTime.Now;
            eDocDig.FechActu = System.DateTime.Now;
            eDocDig.AcceDocuDigi = rbtnNivelAcceso.SelectedValue;
            eDocDig.CodiTipoDocu = ddlClaseDoc.SelectedValue;
            eDocDig.CodUsu = CodUsu;

            
            oReturn = DocDigController.SetAddDocumentosDigitales(eDocDig);
            iCodDocDig = eDocDig.CodiDocuDigi;
            lblNumDig.Text = eDocDig.NumDocuDigi;
            lblCodDig.Text = iCodDocDig.ToString(); ;
        }

        protected void Mantenimiento_DocumentoDigitalUpdate(Int64 CodOper, string sEstado, string Tipo, Int64 CodUsu, string sCtlUplServerFTP)
        {
            Int64 oReturn = 0;
            DigitalizacionController DocDigController = new DigitalizacionController();
            eDocDig eDocDig = new eDocDig();

            eDocDig.CodiDocuDigi = CodOper;
            eDocDig.Type = Tipo;
            eDocDig.NumDocuDigi = txtNroDoc.Text;
            eDocDig.NombOrig = txtNomOrigArch.Text;
            eDocDig.TituDocuDigi = txtTitulo.Text;
            eDocDig.AsunDocuDigi = txtAsunto.Text;

            eDocDig.RutaFisi = ConfigurationManager.AppSettings.Get("ServidorFTP");
            eDocDig.TamaDocu = 0;
            //eDocDig.ExteDocu = Path.GetExtension(sCtlUplServerFTP.PostedFile.FileName);
            //eDocDig.NombFisi = Path.GetFileNameWithoutExtension(sCtlUplServerFTP.PostedFile.FileName);
            eDocDig.ClasDocu = rdnDeriva.SelectedValue;
            eDocDig.EstDocuDigi = sEstado;
            eDocDig.FechEmiDocu = Convert.ToDateTime(txtFecEmision.Text + " " + DateTime.Now.TimeOfDay);
            eDocDig.FechRece = Convert.ToDateTime(txtFecReferencia.Text + " " + DateTime.Now.TimeOfDay);
            eDocDig.FechRegi = System.DateTime.Now;
            eDocDig.FechActu = System.DateTime.Now;
            eDocDig.AcceDocuDigi = rbtnNivelAcceso.SelectedValue;
            eDocDig.CodiTipoDocu = ddlClaseDoc.SelectedValue;
            eDocDig.CodUsu = CodUsu;


            oReturn = DocDigController.SetAddDocumentosDigitales(eDocDig);
            iCodDocDig = eDocDig.CodiDocuDigi;
            lblNumDig.Text = eDocDig.NumDocuDigi;
            lblCodDig.Text = iCodDocDig.ToString(); ;
        }

        protected void Mantenimiento_IndexacionDocDig(Int64 oper, string sTexto, string sEstado)
        {
            DigitalizacionController IndexaController = new DigitalizacionController();
            eDocDigRef IndexaCriteria = new eDocDigRef();
            IList<eDocDigRef> DocRef = new List<eDocDigRef>();
            IList<eDocDig> DocDigDT = new List<eDocDig>();
            string CodCont;
            string DesInd;
            char[] separator = new char[] { ',' };
            Int64 oReturn = 0;
            IndexaCriteria.EstaInde = "";
            IndexaCriteria.CodiOper = oper;
            DocRef = IndexaController.GetDocDigRef(IndexaCriteria);

            if (sEstado == "Delete")
            {
                IndexaCriteria.CodiInde = 0;
                IndexaCriteria.Type = "3";
                IndexaCriteria.DescInde = sTexto;
                IndexaCriteria.EstaInde = "N";
                IndexaCriteria.CodiOper = oper;
                IndexaCriteria.TipoOper = sTipoOperacion;
                oReturn = IndexaController.SetAddDocDigRef(IndexaCriteria);
            }
            else
            {
                if (DocRef.Count > 0 && sInd == false)
                {
                    if (sEstado == "N")
                    {
                        CodCont = lblArrCod.Text;
                        string[] strSplitArr = CodCont.Split(separator);
                        foreach (string arrStr in strSplitArr) { ArrCodInd.Add(arrStr); }
                        for (int a = 0; a < DocRef.Count; a++)
                        {
                            for (int i = 0; i < ArrCodInd.Count; i++)
                            {
                                if (ArrCodInd[i].ToString() == DocRef[a].CodiInde.ToString())
                                {
                                    IndexaCriteria.CodiInde = DocRef[a].CodiInde;
                                    IndexaCriteria.Type = "2";
                                    IndexaCriteria.DescInde = sTexto;//sgvcont.Rows[i].Cells[0].Text;
                                    IndexaCriteria.EstaInde = "N";
                                    IndexaCriteria.CodiOper = oper;
                                    IndexaCriteria.TipoOper = sTipoOperacion;
                                    oReturn = IndexaController.SetAddDocDigRef(IndexaCriteria);
                                }
                            }
                        }
                    }
                    else
                    {
                        DesInd = lblArrDes.Text;
                        string[] strArrDes = DesInd.Split(separator);
                        foreach (string arrStrDes in strArrDes) { ArrDesInd.Add(arrStrDes); }
                        for (int i = 0; i < ArrDesInd.Count; i++)
                        {
                            IndexaCriteria.CodiInde = 0;
                            IndexaCriteria.Type = "1";
                            IndexaCriteria.DescInde = ArrDesInd[i].ToString();
                            IndexaCriteria.EstaInde = "E";
                            IndexaCriteria.CodiOper = oper;
                            IndexaCriteria.TipoOper = sTipoOperacion;
                            oReturn = IndexaController.SetAddDocDigRef(IndexaCriteria);
                        }
                    }
                }
                else
                {
                    IndexaCriteria.CodiInde = 0;
                    IndexaCriteria.Type = "1";
                    IndexaCriteria.DescInde = sTexto;
                    IndexaCriteria.EstaInde = "E";
                    IndexaCriteria.CodiOper = oper;
                    IndexaCriteria.TipoOper = sTipoOperacion;
                    sInd = true;
                    oReturn = IndexaController.SetAddDocDigRef(IndexaCriteria);
                }
            }
        }

        protected void RegistroUsuarioParticipante(Int64 CodOper, int sTipoPart, ValidarUsuario_Grupo ctlUsuario, string sEnviNoti)
        {
            GestionController UsuarioPerController = new GestionController();
            eParticipante UsuarioPar = new eParticipante();
            eUsuarioGrupo UsuarioGrupo = new eUsuarioGrupo();
            IList<eUsuarioGrupo> LsteUsuarioGrupo = new List<eUsuarioGrupo>();
            Int64 oReturn = 0;
            Int64 sCodUsuario = 0;                    //Se obtendra del control usuario
            string sTipUsu = string.Empty;          //Se obtendra del control usuario
            string sApruOper = string.Empty; //"N"; //Se obtendra del control usuario

            GridView sUserSelect = ctlUsuario.UsuarioSelect;
            for (int i = 0; i < sUserSelect.Rows.Count; i++)
            {
                CheckBox scbxAutorizar = (CheckBox)sUserSelect.Rows[i].Cells[5].FindControl("cbxAutorizar");

                sCodUsuario = Convert.ToInt64(sUserSelect.Rows[i].Cells[0].Text);
                sApruOper = ((scbxAutorizar.Checked == true) ? "S" : "N");

                UsuarioPar.CodiUsuPart = 0;
                UsuarioPar.TipoOper = sTipoOperacion;
                UsuarioPar.CodiOper = CodOper;

                UsuarioPar.TipoPart = sTipoPart;
                UsuarioPar.ApruOper = sApruOper;

                UsuarioPar.EnviNoti = sEnviNoti;
                UsuarioPar.FechNoti = System.DateTime.Now;
                UsuarioPar.EstaUsuaPart = "A";
                UsuarioPar.CodiUsu = sCodUsuario;

                //oReturn = UsuarioPerController.SetUsuParticipante(UsuarioPar);

                if (sCodUsuario != 0)
                {
                    UsuarioPar.CodiUsu = sCodUsuario;

                    oReturn = UsuarioPerController.SetUsuParticipante(UsuarioPar);
                }
                else
                {
                    UsuarioGrupo.Grupo = new eGrupo
                    {
                        NombGrup = sUserSelect.Rows[i].Cells[1].Text
                    };

                    LsteUsuarioGrupo = UsuarioPerController.GetUsuarioGrupo(UsuarioGrupo);

                    foreach (eUsuarioGrupo eUsuarioGrupo in LsteUsuarioGrupo)
                    {
                        UsuarioPar.CodiUsu = eUsuarioGrupo.Usuario.Codigo;

                        oReturn = UsuarioPerController.SetUsuParticipante(UsuarioPar);
                    }
                }
            }
        }

        protected void LogOperacion(string sCodOper, string UserDes)
        {
            DigitalizacionController LogOperacionController = new DigitalizacionController();
            eLogOperacion eLogOperacion = new eLogOperacion();

            eLogOperacion.CodiLogOper = 0;
            eLogOperacion.FechEven = System.DateTime.Now;
            eLogOperacion.TipoOper = sTipoOperacion;
            eLogOperacion.CodiOper = sCodOper;
            eLogOperacion.CodiEven = sTipoEvento;
            eLogOperacion.CodiUsu = Convert.ToInt64(UserDes);
            eLogOperacion.CodiCnx = 0;

            LogOperacionController.SetLogOperacion(eLogOperacion);

        }

        protected void MensajeAlerta(string sCodOper, string UserDes)
        {
            DigitalizacionController MensajeAlertaController = new DigitalizacionController();
            eMensajeAlerta eMensajeAlerta = new eMensajeAlerta();

            eMensajeAlerta.Type = "1";
            eMensajeAlerta.CodiMensAler = 0;
            eMensajeAlerta.CodiOper = Convert.ToInt64(sCodOper);
            eMensajeAlerta.TipoOper = sTipoOperacion;
            eMensajeAlerta.FechAler = System.DateTime.Now;
            eMensajeAlerta.TipoAler = "1";
            eMensajeAlerta.CodiEven = sTipoEvento;
            eMensajeAlerta.EstMensAler = "A";
            eMensajeAlerta.CodiUsu = Convert.ToInt64(UserDes);

            MensajeAlertaController.SetMensajeAlerta(eMensajeAlerta);

        }

        protected void AnulaParticipante(Int64 CodOper, Int64 CodUsu)
        {
            GestionController UsuarioPerController = new GestionController();
            eParticipante UsuarioPar = new eParticipante();
            Int64 oReturn = 0;

            UsuarioPar.CodiOper = CodOper;
            UsuarioPar.CodiUsu = CodUsu;
            oReturn = UsuarioPerController.SetAnulaUserPart(UsuarioPar);
        }  

        protected bool ValidarCamposObligatorios()
        { 
            bool sValidar = true;

            if (sValidar)
                sValidar = VerificarTipoDato(txtFecEmision, "Date");

            if (sValidar)
                sValidar = VerificarTipoDato(txtFecReferencia, "Date");

            if (sValidar)
                sValidar = VerificarTipoDato(rbtnNivelAcceso, "String");

            if (sValidar)
                sValidar = VerificarTipoDato(rdnDeriva, "String");

            if (sValidar)
                sValidar = VerificarTipoDato(ct1UserRec, "Len"); 

            if (Session["sUplServerFTP"] == null)
                sValidar = false;

            return sValidar;
        }

        protected void ibtnEditar_Click(object sender, ImageClickEventArgs e)
        {
            EstadoControlPage(true);
        }  
    }
}
