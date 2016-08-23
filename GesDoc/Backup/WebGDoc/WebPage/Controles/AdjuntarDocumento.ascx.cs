using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGdoc.ServicesControllers;
using WebGdoc.BusquedaServRef;
using Entity.Entities;
using System.Configuration;
using System.IO;

namespace WebGdoc.WebPage.Controles
{
    public partial class AdjuntarDocumento : System.Web.UI.UserControl
    {
        WebGdoc.Resources.Utility sUtility = new WebGdoc.Resources.Utility();
        string sEstTipoDocumento = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (sUtility.VerificarSessionUsuario(gvwDocumentoAdjunto))
            {
                if (!IsPostBack)
                {
                    sUtility.VerificarGridView(gvwDocumentoAdjunto, ValidarAprobacionUser(1));
                    sUtility.VerificarGridView(gvwDocumentoAdjuntoSeleccionado, ValidarAprobacionUser(1));
                    LimpiarArchivoDatos();
                }

                CargarImagen();
                if (Session["nuevoArchivosDato"] == null)
                    Session["nuevoArchivosDato"] = new List<eDocDig>();
            }
        }

        protected void CargarImagen()
        {
            string _UrlImagen = "~/Resources/Imagenes/";

            imgBuscar.ImageUrl = _UrlImagen + "img_Adjunto_" + (imgBuscar.Enabled ? "A" : "I") + ".jpg";
            imgBuscar0.ImageUrl = _UrlImagen + "img_Buscar_" + (imgBuscar0.Enabled ? "A" : "I") + ".jpg";
            ibtnFecEmision.ImageUrl = _UrlImagen + "img_Calendario_" + (ibtnFecEmision.Enabled ? "A" : "I") + ".jpg";
        }

        protected void imgBuscar0_Click(object sender, ImageClickEventArgs e)
        {
            BuscarDocumentoAdjuntar(0);
        }

        protected void gvwDocumentoAdjunto_SelectedIndexChanged(object sender, EventArgs e)
        {
            SleccionarAdjuntoTmp(false);

        }

        protected void gvwDocumentoAdjuntoSeleccionado_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sRows = gvwDocumentoAdjuntoSeleccionado.SelectedIndex;

            if (sRows > -1)
            {
                DataTable TempGvw = new DataTable();
                DataRow TemDr;
                //TempGvw.Columns.Add("CodiDocuDigi");
                //TempGvw.Columns.Add("NumDocuDigi");
                //TempGvw.Columns.Add("NombOrig");
                //TempGvw.Columns.Add("RutaFisi");
                TempGvw.Columns.Add("CodiDocuDigi");
                TempGvw.Columns.Add("NumDocuDigi");
                TempGvw.Columns.Add("NombOrig");
                TempGvw.Columns.Add("TipoBUsqueda");
                TempGvw.Columns.Add("Extension");
                TempGvw.Columns.Add("Directorio");

                for (int i = 0; i < gvwDocumentoAdjuntoSeleccionado.Rows.Count; i++)
                {
                    if (i != sRows)
                    {
                        TemDr = TempGvw.NewRow();
                        TemDr[0] = gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[0].Text;
                        TemDr[1] = gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[1].Text;
                        TemDr[2] = gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[2].Text;
                        TemDr[3] = gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[3].Text;
                        TemDr[4] = gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[4].Text;
                        TemDr[5] = gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[5].Text;
                        //TemDr[2] = ((HyperLink)gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[2].FindControl("lnkTransfer")).Text;
                        //TemDr[3] = ((Label)gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[2].FindControl("lblRutaFisica")).Text;
                        TempGvw.Rows.Add(TemDr);
                    }
                }

                sUtility.CargarGridView(gvwDocumentoAdjuntoSeleccionado, TempGvw, ValidarAprobacionUser(1));
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            mpeAdjuntar.Hide();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            RetornarDocumentoAdjuntoSelect();
            MostrarPopup(false);
        }

        protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
        {
            MostrarPopup(true);
        }

        protected void ibt_close_Click(object sender, ImageClickEventArgs e)
        {
            MostrarPopup(false);
        }


        protected void SleccionarAdjuntoTmp(bool sIndexSelect)
        {
            if (sIndexSelect)
                gvwDocumentoAdjunto.SelectedIndex = 0;


            if (ValidarCantidadUser())
            {
                if (gvwDocumentoAdjunto.Rows.Count > 0)
                {
                    int sRows = gvwDocumentoAdjunto.SelectedIndex;

                    bool sPermitir = true;
                    DataTable TempGvw = new DataTable();
                    DataRow TemDr;
                    TempGvw.Columns.Add("CodiDocuDigi");
                    TempGvw.Columns.Add("NumDocuDigi");
                    TempGvw.Columns.Add("NombOrig");
                    TempGvw.Columns.Add("TipoBUsqueda");
                    TempGvw.Columns.Add("Extension");
                    TempGvw.Columns.Add("Directorio");

                    if (sRows > -1)
                    {
                        TemDr = TempGvw.NewRow();

                        TemDr[0] = Convert.ToInt32(gvwDocumentoAdjunto.Rows[sRows].Cells[0].Text);
                        TemDr[1] = gvwDocumentoAdjunto.Rows[sRows].Cells[1].Text;
                        TemDr[2] = gvwDocumentoAdjunto.Rows[sRows].Cells[2].Text;
                        TemDr[3] = gvwDocumentoAdjunto.Rows[sRows].Cells[3].Text;
                        TemDr[4] = gvwDocumentoAdjunto.Rows[sRows].Cells[4].Text;
                        TemDr[5] = gvwDocumentoAdjunto.Rows[sRows].Cells[5].Text;

                        TempGvw.Rows.Add(TemDr);
                    }

                    for (int i = 0; i < gvwDocumentoAdjuntoSeleccionado.Rows.Count; i++)
                    {
                        if (!gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[0].Text.Equals("&nbsp;"))
                        {
                            if (gvwDocumentoAdjunto.Rows[sRows].Cells[1].Text == gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[1].Text)
                                sPermitir = false;

                            if (sPermitir)
                            {
                                TemDr = TempGvw.NewRow();

                                TemDr[0] = Convert.ToInt32(gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[0].Text);
                                TemDr[1] = gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[1].Text;
                                TemDr[2] = gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[2].Text;
                                TemDr[3] = gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[3].Text;
                                TemDr[4] = gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[4].Text;
                                TemDr[5] = gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[5].Text;

                                TempGvw.Rows.Add(TemDr);
                            }
                        }

                        sPermitir = true;
                    }

                    sUtility.CargarGridView(gvwDocumentoAdjuntoSeleccionado, TempGvw, ValidarAprobacionUser(1));

                }
            }
            else
            {
                sUtility.MensajeAlerta(gvwDocumentoAdjunto, "Solo esta permitido seleccionar " + hdnCantidadUser.Value + " documento(s).");
            }
        }

        protected void BuscarDocumentoAdjuntar(long sCodiDocuDigi)
        {
            if (txtBuscarPersona.Text.Length > 0 || sCodiDocuDigi > 0)
            {
                BusquedaController BusquedaAdjuntoController = new BusquedaController();
                eBuscarDocumentos BusquedaCriteria = new eBuscarDocumentos();
                IList<eBuscarDocumentos> BsqDoc = new List<eBuscarDocumentos>();

                BusquedaCriteria.TipoBusq = Convert.ToInt32(ddlTipoOper.SelectedValue);
                BusquedaCriteria.sDocDig = new eDocDig
                {
                    CodiDocuDigi = sCodiDocuDigi,
                    NumDocuDigi = txtBuscarPersona.Text,
                    TituDocuDigi = txtBuscarPersona.Text,
                    AsunDocuDigi = txtBuscarPersona.Text
                };

                BsqDoc = BusquedaAdjuntoController.GetDocumentoAdjunto(BusquedaCriteria);

                sUtility.CargarGridView(gvwDocumentoAdjunto, CargarTableTemp(BsqDoc), ValidarAprobacionUser(1));
            }
            else
            {
                sUtility.MensajeAlerta(imgBuscar0, "Ingrese criterio a buscar");
            }
        }

        protected object CargarTableTemp(object BsqDoc)
        {
            IList<eBuscarDocumentos> sBsqDoc = new List<eBuscarDocumentos>();
            IList<eDocDig> sLstDocDig = new List<eDocDig>();

            DataTable TempGvw = new DataTable();
            DataRow TemDr;
            TempGvw.Columns.Add("CodiDocuDigi");
            TempGvw.Columns.Add("NumDocuDigi");
            TempGvw.Columns.Add("NombOrig");
            TempGvw.Columns.Add("TipoBUsqueda");
            TempGvw.Columns.Add("Extension");
            TempGvw.Columns.Add("Directorio");

            sBsqDoc = (IList<eBuscarDocumentos>)BsqDoc;

            for (int i = 0; i < sBsqDoc.Count; i++)
            {
                TemDr = TempGvw.NewRow();

                TemDr[0] = sBsqDoc[i].sDocDig.CodiDocuDigi.ToString();
                TemDr[1] = sBsqDoc[i].sDocDig.NumDocuDigi;
                TemDr[2] = sBsqDoc[i].sDocDig.NombOrig + " - " + sBsqDoc[i].sDocDig.AsunDocuDigi;

                if (sBsqDoc[i].TipoBusq == 0)
                    TemDr[3] = (ddlTipoOper.SelectedValue.ToString() == "0" ? "AD" : ddlTipoOper.SelectedValue.ToString() == "1" ? "DD" : "DE");
                else
                    TemDr[3] = (sBsqDoc[i].TipoBusq == 0 ? "AD" : sBsqDoc[i].TipoBusq == 1 ? "DD" : "DE");

                TemDr[4] = sBsqDoc[i].sDocDig.ExteDocu;
                TemDr[5] = sBsqDoc[i].sTipoDocumento.NombTipoDocu;

                TempGvw.Rows.Add(TemDr);
            }

            return TempGvw;
        }

        protected void RetornarDocumentoAdjuntoSelect()
        {
            string sNameDoc = string.Empty;
            string sNameExt = string.Empty;
            string sNameFil = string.Empty;

            string sLtl = string.Empty;
            Int32 sIndex = 0;

            for (int i = 0; i < gvwDocumentoAdjuntoSeleccionado.Rows.Count; i++)
            {
                sNameDoc = gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[1].Text;
                sNameExt = gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[4].Text;
                sNameFil = gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[5].Text;

                sLtl = sLtl + "<a runat='server' id='aLink" + sIndex + "' " +
                              "target='popup' " +
                              "href='../Digitalizacion/frmVerArchivo.aspx?Archivo=" + sNameFil.Trim() + "/" + sNameDoc.Trim() + sNameExt + "'>" +
                       sNameDoc.Trim() + ";</a> " + "&nbsp;";
            }


            ltrLink.Text = sLtl;
        }

        protected void CargarAdjuntoInsert(IList<eDocAdj> gvwDocuAdjInsert)
        {
            for (int z = 0; z < gvwDocuAdjInsert.Count; z++)
            {
                ddlTipoOper.SelectedValue = (gvwDocuAdjInsert[z].TipoDocAdju == "AD" ? "0" : gvwDocuAdjInsert[z].TipoDocAdju == "DD" ? "1" : "2");
                BuscarDocumentoAdjuntar(gvwDocuAdjInsert[z].CodiDocAdju);
                SleccionarAdjuntoTmp(true);
            }

        }

        protected void MostrarPopup(bool sMostOcul)
        {
            if (sMostOcul)
            {
                divPopup.Attributes["class"] = "PopupMostrar";
                divArchivoDatos.Attributes["class"] = "PopupMostrar";
                mpeAdjuntar.Show();
            }
            else
            {
                divPopup.Attributes["class"] = "PopupOcultar";
                mpeAdjuntar.Hide();
            }
        }

        protected bool ValidarCantidadUser()
        {
            bool sPermitirUser = true;

            if (Convert.ToInt16(hdnCantidadUser.Value) > 0)
                if (gvwDocumentoAdjuntoSeleccionado.Rows.Count >= Convert.ToInt16(hdnCantidadUser.Value))
                    if (!gvwDocumentoAdjuntoSeleccionado.Rows[0].Cells[0].Text.Equals("&nbsp;"))
                        sPermitirUser = false;

            return sPermitirUser;
        }

        protected int[] ValidarAprobacionUser(int sTypeGriw)
        {
            int[] sIndexGV1 = { 0, 3, 4, 5 };
            //int[] sIndexGV2 = { 0, 1, 2, 5 };
            int[] sIndexGV;

            switch (sTypeGriw)
            {
                case 1:
                    sIndexGV = sIndexGV1;
                    break;

                //case 2 :
                //    sIndexGV = (Convert.ToBoolean(hdnAprobacionUser.Value)) ? sIndexGV1 : sIndexGV2;
                //    break;

                default:
                    sIndexGV = sIndexGV1;
                    break;
            }

            return sIndexGV;
        }


        public GridView DocumentoAdjuntoSelect
        {
            get
            {
                return gvwDocumentoAdjuntoSeleccionado;
            }
        }

        public IList<eDocAdj> DocumentoAdjuntoInsert
        {
            set
            {
                CargarAdjuntoInsert(value);
                RetornarDocumentoAdjuntoSelect();
            }
        }

        public int WithTexto
        {
            set
            {
                tdUser.Width = value.ToString() + "%";
                //txtUsuarios.Width = Unit.Percentage(value);
                divMargen.Attributes.Add("Width", Unit.Percentage(value).ToString());
            }
        }

        public bool EnabledControl
        {
            set
            {
                imgBuscar.Enabled = value;
            }
        }

        public int CantidadDocumentoAdjunto
        {
            set
            {
                hdnCantidadUser.Value = value.ToString();
            }
        }

        /*
        public bool AprobacionUser
        {
            set
            {
                hdnAprobacionUser.Value = value.ToString();
            }
        }
        */
        /*
        public bool UserSesion
        {
            set
            {
                if (value)
                {
                    imgBuscar.Enabled = false;
                    CargarUsuarioInsert(CargarUsuarioSession());
                    RetornarDocumentoAdjuntoSelect();
                    
                }
            }
        }
        */
        public bool LimpiarControl
        {
            set
            {
                if (value)
                {
                    gvwDocumentoAdjunto.DataSource = null;
                    gvwDocumentoAdjunto.DataBind();
                    sUtility.VerificarGridView(gvwDocumentoAdjunto, ValidarAprobacionUser(1));

                    gvwDocumentoAdjuntoSeleccionado.DataSource = null;
                    gvwDocumentoAdjuntoSeleccionado.DataBind();
                    sUtility.VerificarGridView(gvwDocumentoAdjuntoSeleccionado, ValidarAprobacionUser(1));

                    ltrLink.Text = "";
                }
            }
        }

        public string TituloControl
        {
            set
            {
                lblTituloControl.Text = value;
            }
        }

        public string UserText
        {
            get
            {
                return ltrLink.Text;
            }
        }


        protected void MostrarPopupArchivoDatos(bool sMostOcul)
        {
            if (sMostOcul)
            {
                divArchivoDatos.Attributes["class"] = "PopupMostrar";
                mpeArchivoDatos.Show();
            }
            else
            {
                divArchivoDatos.Attributes["class"] = "PopupOcultar";
                mpeArchivoDatos.Hide();

            }
        }

        protected void ddlTipoOper_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoOper.SelectedValue == "3")
            {
                MostrarPopupArchivoDatos(true);
                MostrarPopup(false);                
                LimpiarArchivoDatos();
            }
            else
            {
                MostrarPopup(true);
            }
        }

        protected void btnAceptarArchivoDatos_Click(object sender, EventArgs e)
        {
            try
            {
                int DocElecEmisor = 3;

                if (ValidarCamposObligatorios())
                {
                    MostrarPopup(true);
                    MostrarPopupArchivoDatos(false);

                    string sSession = Session["sCodUsu"].ToString();
                    FileUpload sCtlUplServerFTP = uplServerFTP;
                    Mantenimiento_ArchivoDato(0, "N", "1", Convert.ToInt64(sSession), sCtlUplServerFTP);
                    RegistroUsuarioParticipante(Convert.ToInt64(lblCodDig.Text), DocElecEmisor, ctlUser, "N");
                    LimpiarArchivoDatos();
                    GuardarArchivoFTP(lblNumDig.Text.Trim());
                }
                else
                {
                    MostrarPopup(false);
                    MostrarPopupArchivoDatos(true);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnCancelarArchivoDatos_Click(object sender, EventArgs e)
        {
            MostrarPopup(true);
            MostrarPopupArchivoDatos(false);
        }

        protected void LimpiarArchivoDatos()
        {
            txtNomOrigArch.Text = string.Empty;
            txtTitulo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtFecEmision.Text = string.Empty;
            DropDownList oDropDownList = (DropDownList)ddlClaseDoc;
            oDropDownList.Items.Clear();
            oDropDownList.DataBind();
            CargarComboBoxInicial();

            txtFecEmision.Text = System.DateTime.Now.ToShortDateString();
            rbtnNivelAcceso.SelectedValue = "PU";
            txtNomOrigArch.Focus();
            //txtPropietario.Text = Session["sUsuario"].ToString().ToUpper();
        }

        protected void CargarComboBoxInicial()
        {
            DigitalizacionController DocDigiController = new DigitalizacionController();
            eDocDigListTD eDocDigListTD = new eDocDigListTD();
            IList<eDocDigListTD> ListeDocDigListTD = new List<eDocDigListTD>();

            eDocDigListTD.EstTipoDocumento = sEstTipoDocumento;
            ListeDocDigListTD = DocDigiController.GetTipoDocumDigital(eDocDigListTD);

            sUtility.CargarDropDownList(ddlClaseDoc, ListeDocDigListTD, "NombTipoDocu", "CodiTipoDocu");
        }

        protected void Mantenimiento_ArchivoDato(Int64 CodOper, string sEstado, string Tipo, Int64 CodUsu, FileUpload sCtlUplServerFTP)
        {
            Int64 oReturn = 0;
            DigitalizacionController DocDigController = new DigitalizacionController();
            eDocDig eDocDig = new eDocDig();

            eDocDig.CodiDocuDigi = CodOper;
            eDocDig.Type = Tipo;
            eDocDig.NombOrig = txtNomOrigArch.Text;
            eDocDig.TituDocuDigi = txtTitulo.Text;

            eDocDig.RutaFisi = ddlClaseDoc.SelectedItem.Text;
            eDocDig.TamaDocu = 0;
            eDocDig.ExteDocu = Path.GetExtension(sCtlUplServerFTP.PostedFile.FileName);
            eDocDig.NombFisi = Path.GetFileNameWithoutExtension(sCtlUplServerFTP.PostedFile.FileName);
            eDocDig.ClasDocu = null;
            eDocDig.EstDocuDigi = sEstado;
            eDocDig.FechEmiDocu = Convert.ToDateTime(txtFecEmision.Text + " " + DateTime.Now.TimeOfDay);
            eDocDig.FechRece = System.DateTime.Now;
            eDocDig.FechRegi = System.DateTime.Now;
            eDocDig.FechActu = System.DateTime.Now;
            eDocDig.AcceDocuDigi = rbtnNivelAcceso.SelectedValue;
            eDocDig.CodiTipoDocu = ddlClaseDoc.SelectedValue;
            eDocDig.CodUsu = CodUsu;


            oReturn = DocDigController.SetAddDocumentosDigitales(eDocDig);
            lblCodDig.Text = eDocDig.CodiDocuDigi.ToString();
            lblNumDig.Text = eDocDig.NumDocuDigi;

            var nuevoArchivosDatos = (List<eDocDig>)Session["nuevoArchivosDato"];
            nuevoArchivosDatos.Add(eDocDig);
            AgregarNuevoAdjuntoTmp(eDocDig);
        }

        protected void RegistroUsuarioParticipante(Int64 CodOper, int sTipoPart, ValidarUsuario_Grupo ctlUsuario, string sEnviNoti)
        {
            string sTipoOperacion = "AD";
            GestionController UsuarioPerController = new GestionController();
            eParticipante UsuarioPar = new eParticipante();

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

                oReturn = UsuarioPerController.SetUsuParticipante(UsuarioPar);
            }
        }

        public void GuardarArchivoFTP(string numDig)
        {
            Int64 sLongitub = Convert.ToInt64(ConfigurationManager.AppSettings.Get("MB_Cargar").ToString());
            Int64 sConvercion = Convert.ToInt64(ConfigurationManager.AppSettings.Get("MB_").ToString());

            try
            {

                if (sLongitub > (uplServerFTP.FileBytes.Length / sConvercion))
                {
                    string sExtencionArchivo = sUtility.ReturnExtensionArchivo(uplServerFTP.PostedFile.FileName);
                    sUtility.CargarArchivoFTP(uplServerFTP, ddlClaseDoc.SelectedItem.Text, numDig, sExtencionArchivo);
                }
                else
                {
                    sUtility.MensajeAlerta(btnAceptarArchivoDatos, "La carga maxima permitida es " + sLongitub.ToString() + " KB");
                }
            }
            catch (Exception ex)
            {
                sUtility.MensajeAlerta(btnAceptarArchivoDatos, "La carga maxima permitida es " + sLongitub.ToString() + " KB");
            }
        }

        protected void AgregarNuevoAdjuntoTmp(eDocDig documento)
        {
            DataTable TempGvw = new DataTable();
            DataRow TemDr;
            TempGvw.Columns.Add("CodiDocuDigi");
            TempGvw.Columns.Add("NumDocuDigi");
            TempGvw.Columns.Add("NombOrig");
            TempGvw.Columns.Add("TipoBUsqueda");
            TempGvw.Columns.Add("Extension");
            TempGvw.Columns.Add("Directorio");

            TemDr = TempGvw.NewRow();

            TemDr[0] = documento.CodiDocuDigi;
            TemDr[1] = documento.NumDocuDigi;
            TemDr[2] = documento.NombOrig;
            TemDr[3] = "AD";
            TemDr[4] = documento.ExteDocu;
            TemDr[5] = documento.RutaFisi;

            TempGvw.Rows.Add(TemDr);


            for (int i = 0; i < gvwDocumentoAdjuntoSeleccionado.Rows.Count; i++)
            {
                TemDr = TempGvw.NewRow();

                TemDr[0] = Convert.ToInt32(gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[0].Text);
                TemDr[1] = gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[1].Text;
                TemDr[2] = gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[2].Text;
                TemDr[3] = gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[3].Text;
                TemDr[4] = gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[4].Text;
                TemDr[5] = gvwDocumentoAdjuntoSeleccionado.Rows[i].Cells[5].Text;

                TempGvw.Rows.Add(TemDr);
            }

            sUtility.CargarGridView(gvwDocumentoAdjuntoSeleccionado, TempGvw, ValidarAprobacionUser(1));
        }

        protected bool ValidarCamposObligatorios()
        {
            bool sValidar = true;

            if (sValidar)
                sValidar = sUtility.VerificarTipoDato(txtFecEmision, "Date");

            if (sValidar)
                sValidar = sUtility.VerificarTipoDato(txtFecEmision, "Date");

            if (sValidar)
                sValidar = sUtility.VerificarTipoDato(rbtnNivelAcceso, "String");

            if (sValidar && txtTitulo.Text == string.Empty)
                sValidar = false;

            if (sValidar && uplServerFTP.FileName == string.Empty)
                sValidar = false;

            return sValidar;
        }
    }
}