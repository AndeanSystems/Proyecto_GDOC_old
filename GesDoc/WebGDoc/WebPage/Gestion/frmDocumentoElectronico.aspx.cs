using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using WebGdoc.ServicesControllers;
using WebGdoc.DigitalizacionServRef;
using WebGdoc.WebPage.Inicio;
using WebGdoc.WebPage.Controles;
using WebGdoc.GestionServRef;
using Entity.Entities;

namespace WebGdoc.WebPage.Gestion
{
    public partial class frmDocumentoElectronico : WebGdoc.Resources.Utility
    {

        #region Variables Iniciales

        string sTipoOperacion = "DE";
        string sTipoEvento;
        string sCodOper;
        string cadDestino = string.Empty;
        string sError;
        string sPageLoad = "../Gestion/frmDocumentoElectronico.aspx";
        string sNumOper = "";
        string sIdeUser = string.Empty;
        Int64 sCodOperacion = 0;
        DataTable TempGvw = new DataTable();
        DataRow TemDr;

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            ConfigurarCKEditor(ckeTextoDocumento);
            ibtnEditar.Enabled = false;
            ibtnEnviar.Enabled = false;

            if (Request.QueryString["NumOper"] != null)
            {
                sNumOper = Request.QueryString["NumOper"];
            }
            if (Request.QueryString["IdeUser"] != null)
            {
                sIdeUser = Request.QueryString["IdeUser"];
            }

            if (Request.QueryString["CodOper"] != null)
            {
                sCodOperacion = Convert.ToInt64(Request.QueryString["CodOper"]);
            }

            txtPlazoConfirmacion.Text = CalculaFechaPlazo(5, DateTime.Now);

            if (VerificarSessionUsuario(tbPrincipal))
            {
                if (!IsPostBack)
                {
                    ibtnMemos.Visible = false;
                    ibtnReenviar.Enabled = false;

                    Session.Remove("sURLActual");
                    Session.Add("sURLActual", Request.Url.ToString());

                    CargarDefault();
                    if (sNumOper != "" && sNumOper != null || sCodOperacion != 0)
                    {
                        LimpiarControles(ctlUserRemitente);
                        BuscarDocumentoElectronico(sNumOper, sCodOperacion);

                        UsuarioRpt(sIdeUser);
                        ibtnNuevo.Enabled = false;
                        txtNroDoc.Enabled = false;
                        ibtnBuscar.Enabled = false;
                        ibtnEditar.Enabled = false;

                        if (ibtnMemos.Visible)
                            MostrarPopupComentarios(true);
                    }
                }
                else
                {
                    if (ValidarUserDiferenteEmi_Remi())
                    {
                        ibtnEnviar.Enabled = false;
                    }
                    else
                    {
                        ibtnEnviar.Enabled = true;
                    }
                }

                CargarImagen();
                EnviarAlertaRemit();
            }
        }

        private void EnviarAlertaRemit()
        {
            if (string.IsNullOrEmpty(txtNroDoc.Text))
                lblEnvNotRem.Text = EnviarAlertaRemitentes().ToString();
            else
                lblEnvNotRem.Text = string.Empty;
        }

        protected void CargarImagen()
        {
            ibtnNuevo.ImageUrl = _UrlImagen + "img_Nuevo_" + (ibtnNuevo.Enabled ? "A" : "I") + ".jpg";
            ibtnEditar.ImageUrl = _UrlImagen + "img_Editar_" + (ibtnEditar.Enabled ? "A" : "I") + ".jpg";
            ibtnGuardar.ImageUrl = _UrlImagen + "img_Guardar_" + (ibtnGuardar.Enabled ? "A" : "I") + ".jpg";
            ibtnEnviar.ImageUrl = _UrlImagen + "img_Enviar_" + (ibtnEnviar.Enabled ? "A" : "I") + ".jpg";
            ibtnReenviar.ImageUrl = _UrlImagen + "img_Reenviar_" + (ibtnReenviar.Enabled ? "A" : "I") + ".jpg";
            ibtnEliminar.ImageUrl = _UrlImagen + "img_Eliminar_" + (ibtnEliminar.Enabled ? "A" : "I") + ".jpg";
            ibtnRegresar.ImageUrl = _UrlImagen + "img_Inicio_" + (ibtnRegresar.Enabled ? "A" : "I") + ".jpg";
            ibtnBuscar.ImageUrl = _UrlImagen + "img_Buscar_" + (ibtnBuscar.Enabled ? "A" : "I") + ".jpg";
            ibtnFecPlazo.ImageUrl = _UrlImagen + "img_Calendario_" + (ibtnFecPlazo.Enabled ? "A" : "I") + ".jpg";

            ibtnMemos.ImageUrl = _UrlImagen + "img_Adjuntar_A.jpg";
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            /* Listar control de FileServer */
        }

        protected void ibtnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            if (ValidarCamposObligatorios())
                RegistrarOperacion();
            else
                MensajeAlerta(ibtnGuardar, "Los datos ingresados no son correctos o estan incompletos");
        }

        protected void ibtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            LimpiarControlPage();
            if (txtNroDoc.Text.Trim().Length >= 18)
            {
                if (ValidaAccesoDocumento(0, txtNroDoc.Text.Trim(), Convert.ToInt64(Session["sCodUsu"].ToString())))
                {
                    MensajeAlerta(ibtnBuscar, "El Documento a buscar es de caracter Privado. Ud no es usuario participante del documento");
                    return;
                }
                BuscarDocumentoElectronico(txtNroDoc.Text, 0);
            }
        }

        protected void ibtnEnviar_Click(object sender, ImageClickEventArgs e)
        {
            if (ValidarCamposObligatorios())
            {
                if (ValidarUserDiferenteSesi_Remi())
                {
                    MostrarPopupFirmaDigital(true);
                }
                else
                {
                    RegistrarEnvioDocumentoElectronico();

                    GenerarArchivoPDF(lblNumElec.Text.Trim(), ddlTipoDoc.SelectedItem.Text, ckeTextoDocumento.Text);
                }

            }
            else
                MensajeAlerta(ibtnGuardar, "Los datos ingresados no son correctos o estan incompletos");
        }

        protected void ibtnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            Int64 oReturn;

            oReturn = Mantenimiento_DocumentoElectronico("N", "2");

            if (oReturn >= 1)
            {
                sTipoEvento = "DE015";

                AnulaParticipante(Convert.ToInt64(lblCodElec.Text), 0);

                sCodOper = lblCodElec.Text;

                RegistrarLogOperaciones(sCodOper);

                MensajeAlerta(ibtnGuardar, "El documento electronico Nro " + lblNumElec.Text.Trim() + " se elimino correctamente", sPageLoad);
            }
        }

        protected void ibtnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            txtNroDoc.Text = "";
            dllTipoAcceso.Focus();

            EstadoControlPage(true);
            LimpiarControlPage();
            txtNroDoc.Enabled = false;
            ibtnBuscar.Enabled = false;
            //ibtnGuardar.Enabled = false;
            lblCodElec.Text = "";


            ctlUserEmisor.UserSesion = true;
            ctlUserRemitente.UserSesion = true;
            ctlUserRemitente.EnabledControl = true;

            txtPlazoConfirmacion.Text = CalculaFechaPlazo(5, DateTime.Now);
            MostrarPopup(false);
            MostrarPopupComentarios(false);
        }

        protected void ibtnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            string sPageInicio = "../Inicio/frmEscritorioVirtual.aspx";
            RedireccionarPage(tbPrincipal, sPageInicio);
        }

        protected void BuscarDocumentoElectronico(string NumOper, Int64 sCodOperacion)
        {
            GestionController GDocElectController = new GestionController();
            DigitalizacionController DocElectController = new DigitalizacionController();
            eDocumentoElectronico DocElecCriteria = new eDocumentoElectronico();
            eUsuario eUsuario = new eUsuario();
            IList<eDocumentoElectronico> DocElectDT = new List<eDocumentoElectronico>();
            IList<eUsuario> UsuPer = new List<eUsuario>();

            DocElecCriteria.EstDocuElec = string.Empty;
            DocElecCriteria.CodiOper = sCodOperacion;
            DocElecCriteria.NumDocuElec = NumOper.Trim();
            DocElecCriteria.User = new eUsuario { Codigo = 1 };

            DocElectDT = DocElectController.GetDocEle(DocElecCriteria);
            if (DocElectDT.Count > 0)
            {

                LimpiarControles(ctlUserEmisor);
                LimpiarControles(ctlUserRemitente);

                if (DocElectDT[0].EstDocuElec == "E")
                {
                    EstadoControlPage(false);
                }
                else
                {
                    EstadoControlPage(true);
                }

                for (int i = 0; i < DocElectDT.Count; i++)
                {
                    lblCodElec.Text = DocElectDT[i].CodiOper.ToString();
                    txtNroDoc.Text = DocElectDT[i].NumDocuElec.ToString();
                    txtAsunto.Text = DocElectDT[i].AsunDocuElec;
                    dllTipoAcceso.SelectedValue = DocElectDT[i].TipoAcc;
                    ddlTipoDoc.SelectedValue = DocElectDT[i].CodiTipoDocu.Trim();
                    ddlPrioridaddeAtencion.SelectedValue = DocElectDT[i].PrioDocuElec;
                    ckeTextoDocumento.Text = DocElectDT[i].MensDocuElec;    //txtTexto.Text = DocElectDT[i].MensDocuElec;
                    ddlCategoria.SelectedValue = DocElectDT[i].TipoComu.Trim();
                    txtPlazoConfirmacion.Text = DocElectDT[i].FechCie.ToShortDateString();

                    divMemo.InnerHtml = DocElectDT[i].Memo;
                    ibtnMemos.Visible = (DocElectDT[i].Memo != string.Empty);

                    switch (DocElectDT[i].EstDocuElec)
                    {
                        case "C":
                            lblEstado.Text = "CREADO";
                            break;
                        case "E":
                            lblEstado.Text = "ENVIADO";
                            break;
                        case "N":
                            lblEstado.Text = "ELIMINADO";
                            break;
                        default:
                            break;
                    }
                    eUsuario.Codigo = DocElectDT[i].User.Codigo;
                    eUsuario.IdeUsuario = string.Empty;
                    eUsuario.NombPers = string.Empty;
                    
                    UsuPer = GetListaUsuarioPer(eUsuario, true);

                    // Emisor
                    if (DocElectDT[i].Participante.TipoPart == 3)
                    {
                        ctlUserRemitente.UsuarioInsert = UsuPer;
                        if (DocElectDT[i].Participante.CodiUsu == Convert.ToInt64(Session["sCodUsu"].ToString()))
                        {
                            if (DocElectDT[i].EstDocuElec == "C")
                            {
                                ibtnEditar.Enabled = true;
                                ibtnEnviar.Enabled = true;
                            }
                            if (DocElectDT[i].EstDocuElec == "E")
                                ibtnEnviar.Enabled = true;
                        }
                        else
                            EstadoControlPage(false);

                        if (DocElectDT[i].Participante.CodiUsu == Convert.ToInt64(Session["sCodUsu"].ToString()) && DocElectDT[i].EstDocuElec != "C")
                        {
                            if (ListaApro() > 0)
                                MostrarPopup(true);
                            //divRpst.Attributes["class"] = "PopupMostrar";

                            txtObservaciones.Enabled = false;
                            btnAutorizAprobar.Enabled = false;
                            btnAutorizRechazar.Enabled = false;
                        }
                    }

                    // Participant3 
                    if (DocElectDT[i].Participante.TipoPart == 2 && DocElectDT[i].Participante.Reenvio != "Y")
                    {
                        UsuPer[0].Participante = new eParticipante
                        {
                            ApruOper = DocElectDT[i].Participante.ApruOper
                        };

                        ctlUserParticipante.UsuarioInsert = UsuPer;
                    }

                    if (DocElectDT[i].Participante.TipoPart == 5)
                    {
                        ctlUserEmisor.UsuarioInsert = UsuPer;
                    }

                    if (DocElectDT[i].Participante.CodiUsu.ToString() == Session["sCodUsu"].ToString() && DocElectDT[i].Participante.ApruOper == "S")
                    {
                        MostrarPopup(true);
                        divRpst.Attributes["class"] = "PopupOcultar";
                        ListaApro();
                    }
                    else if (DocElectDT[i].Participante.CodiUsu.ToString() == Session["sCodUsu"].ToString() && DocElectDT[i].Participante.ApruOper != "S")
                    {
                        MostrarPopup(true);
                        divRpst.Attributes["class"] = "PopupMostrar";
                        txtObservaciones.Enabled = false;
                        btnAutorizAprobar.Enabled = false;
                        btnAutorizRechazar.Enabled = false;
                        ListaApro();
                    }
                }

                if (DocElectDT[0].EstDocuElec == "E")
                {
                    ibtnReenviar.Enabled = true;
                    ctlUserParticipante.EnabledControl = true;
                    ckeTextoDocumento.Enabled = true;
                }
                else
                {
                    ibtnReenviar.Enabled = false;
                    ctlUserReenvio.EnabledControl = false;
                    ckeTextoDocumento.Enabled = false;
                }
                CargarImagen();
                panelAutoriza();
                ListaDocAdju();
                MarcarLeido(DocElectDT);
            }
            else
                MensajeAlerta(btnEnviar, "El documento electronico Nro " + txtNroDoc.Text.Trim() + " no existe");

            txtNroDoc.Focus();

        }


        private void MarcarLeido(IList<eDocumentoElectronico> DocElectDT)
        {
            var codiUsu = (Int64)Session["sCodUsu"];
            var documentos = new List<eDocumentoElectronico>(DocElectDT);
            var usuarioParticipante = documentos.Find(x => x.Participante.CodiUsu == codiUsu);
            if (usuarioParticipante != null)
            {
                var participante = usuarioParticipante.Participante;
                participante.CodiOper = usuarioParticipante.CodiOper;
                participante.ConfLect = "S";
                new GestionController().UpdateUsuParticipante(participante);
            }
        }

        protected void btnAutorizAprobar_Click(object sender, EventArgs e)
        {
            Int64 oReturn = 0;
            string Rpta = "A";
            string coment = string.Empty;

            coment = "APROBADO " + txtObservaciones.Text;
            oReturn = RespAutoriza(Rpta, coment);

            if (oReturn > 0)
            {
                // cadena = "APROBADO. " + txtObservaciones.Text;
                //ComentarioMesaVirtual(cadena);
                sTipoEvento = "DE003";
                RegistrarLogOperaciones(lblCodElec.Text);
                RegistrarMensajeAlerta(lblCodElec.Text, ctlUserRemitente);
                txtObservaciones.Text = "";
                // ComentariosGrilla(Convert.ToInt64(lblCodOper.Text), 0);
                txtObservaciones.Focus();
                MensajeAlerta(btnAutorizAprobar, "Acaba de Aprobar el Documento Electronico :" + txtNroDoc.Text.Trim(), sPageLoad);
                //MostrarPopup(false);
            }



        }

        protected void btnAutorizRechazar_Click(object sender, EventArgs e)
        {
            Int64 oReturn = 0;
            string Rpta = "D";
            string coment = string.Empty;

            coment = "DESAPROBADO " + txtObservaciones.Text;

            oReturn = RespAutoriza(Rpta, coment);

            if (oReturn > 0)
            {
                // cadena = "RECHAZADO. " + txtObservaciones.Text;
                // ComentarioMesaVirtual(cadena);
                sTipoEvento = "DE004";
                RegistrarLogOperaciones(lblCodElec.Text);
                RegistrarMensajeAlerta(lblCodElec.Text, ctlUserRemitente);
                txtObservaciones.Text = "";
                //ComentariosGrilla(Convert.ToInt64(lblCodOper.Text), 0);
                txtObservaciones.Focus();
                MensajeAlerta(btnAutorizRechazar, "Acaba de Rechazar el Documento Electronico :" + txtNroDoc.Text.Trim(), sPageLoad);
                //MostrarPopup(false);
            }
        }

        protected void ibt_close_Click(object sender, ImageClickEventArgs e)
        {
            MostrarPopupFirmaDigital(false);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            MostrarPopupFirmaDigital(false);
        }

        protected void btnCerrarComentarios_Click(object sender, EventArgs e)
        {
            MostrarPopupComentarios(false);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Int64 sUserSession = Convert.ToInt64(Session["sCodUsu"].ToString());
            String sFirmaElectronico = txtFirmaActual.Text;

            if (ValidarFirmaDigital(sUserSession, sFirmaElectronico))
            {
                RegistrarEnvioDocumentoElectronico();

                GenerarArchivoPDF(lblNumElec.Text.Trim(), ddlTipoDoc.SelectedItem.Text, ckeTextoDocumento.Text);
            }
            else
            {
                MensajeAlerta(btnAceptar, "La Firma Electronica ingresada no coincide");
            }
        }

        protected void CargarDefault()
        {
            ConfigurarBarraHerramientas();

            CargarTipoAcceso();

            CargarTipoPrioridad();

            CargarTipoDocumento();

            txtNroDoc.Focus();

            EstadoControlPage(false);
        }

        protected void ConfigurarBarraHerramientas()
        {
            //List<string> sLstLink = new List<string>();
            /*sLstLink.Add("WebPage/Busquedas/frmDocumentosDigitales.aspx|Ver historial|u507.bmp");
            sLstLink.Add("WebPage/Busquedas/frmDocumentosDigitales.aspx||u413.bmp");
            sLstLink.Add("WebPage/Busquedas/frmDocumentosDigitales.aspx|Nuevo documento|u460.jpeg");
            sLstLink.Add("WebPage/Busquedas/frmDocumentosDigitales.aspx||u499_original.png");*/

            ReferenciarTitulo(this, "Documento Electrónico (Doc-E)");
            //ReferenciarLink(this, sLstLink);
        }

        protected void CargarTipoAcceso()
        {
            GestionController TipoAccesoController = new GestionController();
            eTipoAcceso eAccesoSistema = new eTipoAcceso();

            eAccesoSistema.EstAcc = "";
            object sTipoAcceso = (object)TipoAccesoController.GetTipoAcceso(eAccesoSistema);

            CargarDropDownList(dllTipoAcceso, sTipoAcceso, "DescAcc", "TipoAcc");
        }

        protected void CargarTipoPrioridad()
        {
            GestionController TipoPrioridadController = new GestionController();
            eTipoPrioridad eTipoPrioridad = new eTipoPrioridad();

            eTipoPrioridad.EstaTipoPrio = "";
            object sTipoPrioridad = (object)TipoPrioridadController.GetTipoPrioridad(eTipoPrioridad);

            CargarDropDownList(ddlPrioridaddeAtencion, sTipoPrioridad, "DescTipoPrio", "CodiTipoPrio");
        }

        protected void CargarTipoDocumento()
        {
            DigitalizacionController TipoDocumentoController = new DigitalizacionController();
            eDocDigListTD TipoDocumentoCriteria = new eDocDigListTD();

            TipoDocumentoCriteria.EstTipoDocumento = "";
            object sTipoDocumento = (object)TipoDocumentoController.GetTipoDocumDigital(TipoDocumentoCriteria);

            CargarDropDownList(ddlTipoDoc, sTipoDocumento, "NombTipoDocu", "CodiTipoDocu");
        }

        protected void EstadoControlPage(bool status)
        {
            ctlAdjuntarDocumento.EnabledControl = status;

            dllTipoAcceso.Enabled = status;

            txtAsunto.Enabled = status;

            txtPlazoConfirmacion.Enabled = status;

            ckeTextoDocumento.Enabled = status; //txtTexto.Enabled = status;

            ddlCategoria.Enabled = status;

            ddlPrioridaddeAtencion.Enabled = status;

            ddlTipoDoc.Enabled = status;

            rbtnAlerta.Enabled = status;

            //HtmlEdit.Enabled = status;

            ibtnEliminar.Enabled = status;

            ibtnGuardar.Enabled = status;

            //ibtnEnviar.Enabled = status;

            //ibtnReenviar.Enabled = status;

            ctlUserRemitente.EnabledControl = status;

            ctlUserParticipante.EnabledControl = status;

            btnCancelar.Visible = false;

            btnEnviar.Visible = false;

            //ibtnEditar.Enabled = status;
        }

        protected void LimpiarControlPage()
        {
            LimpiarControles(ctlAdjuntarDocumento);

            LimpiarControles(txtAsunto);

            LimpiarControles(txtPlazoConfirmacion);

            LimpiarControles(ckeTextoDocumento);    //LimpiarControles(txtTexto);

            LimpiarControles(dllTipoAcceso);
            CargarTipoAcceso();

            //LimpiarControles(ddlCategoria);

            LimpiarControles(ddlPrioridaddeAtencion);
            CargarTipoPrioridad();

            LimpiarControles(ddlTipoDoc);
            CargarTipoDocumento();

            LimpiarControles(rbtnAlerta);

            //LimpiarControles(HtmlEdit);
            LimpiarControles(ctlUserEmisor);
            ctlUserEmisor.UserSesion = true;

            LimpiarControles(ctlUserRemitente);


            LimpiarControles(ctlUserParticipante);
            //LimpiarControles(ctlAdjuntarDocumento);
            ctlAdjuntarDocumento.LimpiarControl = true;

            divMemo.InnerHtml = string.Empty;
        }

        protected bool ValidarCamposObligatorios()
        {
            bool sValidar = true;

            if (sValidar)
                sValidar = VerificarTipoDato(txtPlazoConfirmacion, "Date");

            if (sValidar)
                sValidar = VerificarTipoDato(ctlUserParticipante, "Len");
            if (sValidar)
                sValidar = VerificarTipoDato(ckeTextoDocumento, "Len");
            if (sValidar)
                sValidar = VerificarTipoDato(txtAsunto, "Len");

            return sValidar;
        }

        protected void MostrarPopup(bool sMostOcul)
        {
            if (sMostOcul)
                divPopup.Attributes["class"] = "PopupMostrar";
            else
                divPopup.Attributes["class"] = "PopupOcultar";
        }

        protected void MostrarPopupFirmaDigital(bool sMostOcul)
        {
            if (sMostOcul)
            {
                divFirmaDigital.Attributes["class"] = "PopupMostrar";
                mpeFirmaDigital.Show();
            }
            else
            {
                divFirmaDigital.Attributes["class"] = "PopupOcultar";
                mpeFirmaDigital.Hide();

            }
        }

        protected void MostrarPopupComentarios(bool sMostOcul)
        {
            if (sMostOcul)
            {
                divComentariosReenvio.Attributes["class"] = "PopupMostrar";
                mpeComentarioReenvio.Show();
            }
            else
            {
                divComentariosReenvio.Attributes["class"] = "PopupOcultar";
                mpeComentarioReenvio.Hide();

            }
        }

        protected bool ValidarUserDiferenteEmi_Remi()
        {
            GridView sUserEmisor = ctlUserEmisor.UsuarioSelect;
            GridView sUserRemitente = ctlUserRemitente.UsuarioSelect;

            Int64 sCodUsuarioEmi = 0;
            Int64 sCodUsuarioRemi = 0;
            Int64 sCodUsuarioSes = Convert.ToInt64(Session["sCodUsu"].ToString());

            for (int i = 0; i < sUserEmisor.Rows.Count; i++)
            {
                sCodUsuarioEmi = Convert.ToInt64(sUserEmisor.Rows[i].Cells[0].Text);

                for (int ii = 0; ii < sUserRemitente.Rows.Count; ii++)
                {
                    sCodUsuarioRemi = Convert.ToInt64(sUserRemitente.Rows[ii].Cells[0].Text);

                    if (sCodUsuarioEmi != sCodUsuarioRemi && sCodUsuarioSes == sCodUsuarioEmi)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        protected bool ValidarUserDiferenteSesi_Remi()
        {
            GridView sUserEmisor = ctlUserEmisor.UsuarioSelect;
            GridView sUserRemitente = ctlUserRemitente.UsuarioSelect;

            Int64 sCodUsuarioSes = Convert.ToInt64(Session["sCodUsu"].ToString());
            Int64 sCodUsuarioEmi = 0;
            Int64 sCodUsuarioRemi = 0;

            for (int i = 0; i < sUserEmisor.Rows.Count; i++)
            {
                sCodUsuarioEmi = Convert.ToInt64(sUserEmisor.Rows[i].Cells[0].Text);

                for (int ii = 0; ii < sUserRemitente.Rows.Count; ii++)
                {
                    sCodUsuarioRemi = Convert.ToInt64(sUserRemitente.Rows[ii].Cells[0].Text);

                    if (sCodUsuarioEmi != sCodUsuarioRemi && sCodUsuarioSes == sCodUsuarioRemi)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        protected bool ValidarFirmaDigital(Int64 sUserSession, String sFirmaElectronico)
        {
            GestionController GController = new GestionController();
            eUsuario CtrUser = new eUsuario();
            IList<eUsuario> User = new List<eUsuario>();

            CtrUser.Codigo = sUserSession;

            User = GetListaUsuarioPer(CtrUser, true);
            if (User.Count > 0)
            {
                if (sFirmaElectronico == User[0].FirmaElectronica)
                    return true;
            }

            return false;
        }


        protected void RegistrarEnvioDocumentoElectronico()
        {
            Int64 oReturn = 0;

            if (txtNroDoc.Text != "")
            {
                oReturn = Mantenimiento_DocumentoElectronico("E", "2");

                if (oReturn >= 1)
                {
                    sCodOper = lblCodElec.Text;

                    AnulaParticipante(Convert.ToInt64(sCodOper), 0);                  
                   
                    RegistrarUsuarioParticipante(Convert.ToInt64(lblCodElec.Text), ctlUserEmisor, 5, "N", "N", "Y");
                    RegistrarUsuarioParticipante(Convert.ToInt64(lblCodElec.Text), ctlUserRemitente, (int)UserTipo.DocElecEmisor, "N", "N", "Y");
                    RegistrarUsuarioParticipante(Convert.ToInt64(lblCodElec.Text), ctlUserParticipante, (int)UserTipo.DocElecParticipante, "S", "N", "Y");

                    RegistrarUsuarioParticipante(Convert.ToInt64(lblCodElec.Text), ctlUserReenvio, (int)UserTipo.DocElecParticipante, "N", "Y", "Y");

                    sTipoEvento = "DE008";

                    RegistrarMensajeAlerta(sCodOper, ctlUserParticipante);

                    if (ctlAdjuntarDocumento.UserText.Length > 0)
                    {
                        AnulaDocAdj();

                        DocumentoAdjunto(0, sCodOper);
                    }

                    RegistrarLogOperaciones(sCodOper);

                    MensajeAlerta(ibtnGuardar, "El documento electronico Nro " + lblNumElec.Text.Trim() + " se envio con exito", sPageLoad);

                }
                else
                    MensajeAlerta(ibtnGuardar, "Error al enviar el Documento Electronico " + lblNumElec.Text.Trim());
            }
            else
            {
                oReturn = Mantenimiento_DocumentoElectronico("E", "1");

                if (oReturn >= 1)
                {
                    RegistrarUsuarioParticipante(Convert.ToInt64(lblCodElec.Text), ctlUserEmisor, 5, "N", "N", "N");
                    RegistrarUsuarioParticipante(Convert.ToInt64(lblCodElec.Text), ctlUserRemitente, (int)UserTipo.DocElecEmisor, "N", "N", "N");
                    RegistrarUsuarioParticipante(Convert.ToInt64(lblCodElec.Text), ctlUserParticipante, (int)UserTipo.DocElecParticipante, "S", "N", "N");

                    sTipoEvento = "DE007";

                    sCodOper = lblCodElec.Text;
                    if (ctlAdjuntarDocumento.UserText.Length > 0)
                        DocumentoAdjunto(0, sCodOper);

                    RegistrarLogOperaciones(sCodOper);

                    RegistrarMensajeAlerta(sCodOper, ctlUserParticipante);

                    MensajeAlerta(ibtnGuardar, "El documento electronico Nro " + lblNumElec.Text.Trim() + " se envio con exito", sPageLoad);
                }
                else
                    MensajeAlerta(ibtnGuardar, "Error al enviar el Documento Electronico " + lblNumElec.Text.Trim());
            }
        }

        protected void RegistrarOperacion()
        {
            Int64 oReturn = 0;
            if (ValidarCamposObligatorios())
            {
                if (txtNroDoc.Text != "")
                {
                    oReturn = Mantenimiento_DocumentoElectronico("C", "2");

                    if (oReturn >= 1)
                    {
                        AnulaParticipante(Convert.ToInt64(lblCodElec.Text), 0);

                        RegistrarUsuarioParticipante(Convert.ToInt64(lblCodElec.Text), ctlUserEmisor, 5, "N", "N", "N");
                        RegistrarUsuarioParticipante(Convert.ToInt64(lblCodElec.Text), ctlUserRemitente, (int)UserTipo.DocElecEmisor, "N", "N", "N");
                        RegistrarUsuarioParticipante(Convert.ToInt64(lblCodElec.Text), ctlUserParticipante, (int)UserTipo.DocElecParticipante, "N", "N", "N");

                        sTipoEvento = "DE009";

                        sCodOper = lblCodElec.Text;

                        RegistrarLogOperaciones(sCodOper);
                        RegistrarMensajeAlerta(sCodOper, ctlUserRemitente);

                        if (ctlAdjuntarDocumento.UserText.Length > 0)
                        {
                            AnulaDocAdj();

                            DocumentoAdjunto(0, sCodOper);
                        }
                        MensajeAlerta(ibtnGuardar, "El documento electronico Nro " + lblNumElec.Text.Trim() + " fue actualizado", sPageLoad);
                    }
                    else
                        MensajeAlerta(ibtnGuardar, "Error al grabar el documento electronico");
                }
                else
                {
                    oReturn = Mantenimiento_DocumentoElectronico("C", "1");

                    if (oReturn >= 1)
                    {
                        RegistrarUsuarioParticipante(Convert.ToInt64(lblCodElec.Text), ctlUserEmisor, 5, "N", "N", "N");
                        RegistrarUsuarioParticipante(Convert.ToInt64(lblCodElec.Text), ctlUserRemitente, (int)UserTipo.DocElecEmisor, "N", "N", "N");
                        RegistrarUsuarioParticipante(Convert.ToInt64(lblCodElec.Text), ctlUserParticipante, (int)UserTipo.DocElecParticipante, "N", "N", "N");

                        sTipoEvento = "DE001";

                        sCodOper = lblCodElec.Text;

                        if (ctlAdjuntarDocumento.UserText.Length > 0)
                            DocumentoAdjunto(0, sCodOper);

                        RegistrarLogOperaciones(sCodOper);
                        RegistrarMensajeAlerta(sCodOper, ctlUserRemitente);

                        MensajeAlerta(btnEnviar, "El documento electronico Nro " + lblNumElec.Text.Trim() + " se grabo con exito", sPageLoad);
                    }
                    else
                        MensajeAlerta(ibtnGuardar, "Error al actualizar el documento electronico Nro " + lblNumElec.Text.Trim());
                }
            }
        }

        protected Int64 Mantenimiento_DocumentoElectronico(string sEstado, string sTipo)
        {
            Int64 oReturn = 0;
            DigitalizacionController DocumentoElctronicoController = new DigitalizacionController();
            eDocumentoElectronico eDocumentoElectronico = new eDocumentoElectronico();
            if (ValidarCamposObligatorios())
            {
                eDocumentoElectronico.Type = sTipo;
                eDocumentoElectronico.CodiDocuElec = 0;
                eDocumentoElectronico.TipoComu = ddlCategoria.SelectedValue;
                eDocumentoElectronico.AsunDocuElec = txtAsunto.Text;
                eDocumentoElectronico.FechEmi = System.DateTime.Now;
                eDocumentoElectronico.FechEnvi = System.DateTime.Now;
                eDocumentoElectronico.PrioDocuElec = ddlPrioridaddeAtencion.SelectedValue;
                eDocumentoElectronico.MensDocuElec = ckeTextoDocumento.Text;     //txtTexto.Text;
                eDocumentoElectronico.FechVige = System.DateTime.Now;
                eDocumentoElectronico.EstDocuElec = sEstado;
                eDocumentoElectronico.CateDocuElec = ""; //Revisar 
                eDocumentoElectronico.FechCie = Convert.ToDateTime(txtPlazoConfirmacion.Text);
                eDocumentoElectronico.TipoAcc = dllTipoAcceso.SelectedValue;
                eDocumentoElectronico.CodiTipoDocu = ddlTipoDoc.SelectedValue;
                eDocumentoElectronico.NumDocuElec = txtNroDoc.Text;
                eDocumentoElectronico.CodUsu = Convert.ToInt64(Session["sCodUsu"].ToString());
                eDocumentoElectronico.Memo = FormatMemo();

                oReturn = DocumentoElctronicoController.SetEnviarDocumentoElectronico(eDocumentoElectronico);

                lblCodElec.Text = eDocumentoElectronico.CodiOper.ToString();
                lblNumElec.Text = eDocumentoElectronico.NumDocuElec;

            }
            return oReturn;
        }

        protected void RegistrarUsuarioParticipante(Int64 CodOper, ValidarUsuario_Grupo ctlUserParti, int sTipoPart, string sEnviNoti, string sReenvio, string sEnvio)
        {
            GestionController UsuarioPerController = new GestionController();
            IList<eUsuarioGrupo> LsteUsuarioGrupo = new List<eUsuarioGrupo>();
            eUsuarioGrupo UsuarioGrupo = new eUsuarioGrupo();

            eParticipante UsuarioPar = new eParticipante();


            Int64 oReturn = 0;
            Int64 sCodUsuario = 0;                    //Se obtendra del control usuario
            string sTipUsu = string.Empty;          //Se obtendra del control usuario
            //string sTipoPart = string.Empty; //"3"; //Se obtendra del control usuario
            string sApruOper = string.Empty; //"N"; //Se obtendra del control usuario

            GridView sUserSelect = ctlUserParti.UsuarioSelect;
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
                UsuarioPar.Reenvio = sReenvio;

                if (sEnvio == "Y" && sCodUsuario == Convert.ToInt64(Session["sCodUsu"].ToString()))
                    UsuarioPar.Envio = "Y";
                else
                    UsuarioPar.Envio = "N";

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

        protected bool EnviarAlertaRemitentes()
        {
            var emisores = ObtenerListaUsuarios(ctlUserEmisor);
            var remitentes = ObtenerListaUsuarios(ctlUserRemitente);

            return !remitentes.Contains(emisores[0]);
        }

        private List<long> ObtenerListaUsuarios(ValidarUsuario_Grupo ctlUser)
        {
            List<long> ResultList = new List<long>();
            Int64 sCodUsuario = 0;

            GridView sUserSelect = ctlUser.UsuarioSelect;
            for (int i = 0; i < sUserSelect.Rows.Count; i++)
            {
                sCodUsuario = Convert.ToInt64(sUserSelect.Rows[i].Cells[0].Text);

                if (sCodUsuario != 0)
                {
                    ResultList.Add(sCodUsuario);
                }
                else
                {
                    eUsuarioGrupo UsuarioGrupo = new eUsuarioGrupo();
                    UsuarioGrupo.Grupo = new eGrupo
                    {
                        NombGrup = sUserSelect.Rows[i].Cells[1].Text
                    };

                    GestionController UsuarioPerController = new GestionController();
                    IList<eUsuarioGrupo> LsteUsuarioGrupo = UsuarioPerController.GetUsuarioGrupo(UsuarioGrupo);

                    foreach (eUsuarioGrupo eUsuarioGrupo in LsteUsuarioGrupo)
                    {
                        ResultList.Add(eUsuarioGrupo.Usuario.Codigo);
                    }
                }
            }

            return ResultList;
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

        protected void DocumentoAdjunto(Int64 CodAdj, string sCodOper)
        {
            DigitalizacionController DigController = new DigitalizacionController();
            eDocAdj CtrAdj = new eDocAdj();
            Int64 oReturn = 0;

            GridView sDocAdjSelect = ctlAdjuntarDocumento.DocumentoAdjuntoSelect;
            for (int i = 0; i < sDocAdjSelect.Rows.Count; i++)
            {
                //CtrAdj.Type = "1";
                CtrAdj.CodiAdj = CodAdj;
                CtrAdj.CodiOper = Convert.ToInt64(sCodOper);
                CtrAdj.TipoOper = sTipoOperacion;
                CtrAdj.CodiDocAdju = Convert.ToInt64(sDocAdjSelect.Rows[i].Cells[0].Text);
                CtrAdj.TipoDocAdju = sDocAdjSelect.Rows[i].Cells[3].Text;
                CtrAdj.CodiComenMesaV = 0;
                CtrAdj.EstDocuAdju = "A";
                oReturn = DigController.SetAddDocumentosAdjunto(CtrAdj);
            }
        }

        protected void RegistrarLogOperaciones(string sCodOper)
        {
            DigitalizacionController LogOperacionController = new DigitalizacionController();
            eLogOperacion eLogOperacion = new eLogOperacion();

            eLogOperacion.CodiLogOper = 0;
            eLogOperacion.FechEven = System.DateTime.Now;
            eLogOperacion.TipoOper = sTipoOperacion;
            eLogOperacion.CodiOper = sCodOper;
            eLogOperacion.CodiEven = sTipoEvento;

            //Revisar : se asigna al usuario de la sesion para grabar el LOG

            eLogOperacion.CodiUsu = Convert.ToInt64(Session["sCodUsu"].ToString());
            eLogOperacion.CodiCnx = 0;

            LogOperacionController.SetLogOperacion(eLogOperacion);

        }

        protected void RegistrarMensajeAlerta(string sCodOper, ValidarUsuario_Grupo sControlUser)
        {
            DigitalizacionController MensajeAlertaController = new DigitalizacionController();
            eMensajeAlerta eMensajeAlerta = new eMensajeAlerta();

            GestionController UsuarioPerController = new GestionController();
            IList<eUsuarioGrupo> LsteUsuarioGrupo = new List<eUsuarioGrupo>();
            eUsuarioGrupo UsuarioGrupo = new eUsuarioGrupo();



            GridView sUserSelect = sControlUser.UsuarioSelect;// ctlUserParticipante.UsuarioSelect;
            for (int i = 0; i < sUserSelect.Rows.Count; i++)
            {
                Int64 sCodUsuario = Convert.ToInt64(sUserSelect.Rows[i].Cells[0].Text);

                eMensajeAlerta.Type = "1";
                eMensajeAlerta.CodiMensAler = 0;
                eMensajeAlerta.CodiOper = Convert.ToInt32(sCodOper);
                eMensajeAlerta.TipoOper = sTipoOperacion;
                eMensajeAlerta.FechAler = System.DateTime.Now;
                eMensajeAlerta.TipoAler = "1";
                eMensajeAlerta.CodiEven = sTipoEvento;
                eMensajeAlerta.EstMensAler = "A";

                if (sCodUsuario != 0)
                {
                    eMensajeAlerta.CodiUsu = sCodUsuario;

                    MensajeAlertaController.SetMensajeAlerta(eMensajeAlerta);

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
                        eMensajeAlerta.CodiUsu = eUsuarioGrupo.Usuario.Codigo;

                        MensajeAlertaController.SetMensajeAlerta(eMensajeAlerta);
                    }
                }
            }
        }

        protected Int64 RespAutoriza(string Rpta, string comentario)
        {
            Int64 oReturn = 0;
            GestionController AutoController = new GestionController();
            eAutorizador CtrAutoriz = new eAutorizador();

            CtrAutoriz.Type = "2";
            CtrAutoriz.CodiUsuPart = Convert.ToInt64(Session["sCodUsu"].ToString());
            CtrAutoriz.CodiOper = Convert.ToInt64(lblCodElec.Text);
            CtrAutoriz.TipoOper = "DE";
            CtrAutoriz.RespUsuAuto = Rpta;
            CtrAutoriz.FechUsuAuto = System.DateTime.Now;
            CtrAutoriz.ComeUsuAuto = comentario;
            CtrAutoriz.EstaAuto = "A";
            oReturn = AutoController.SetAutorizaAdd(CtrAutoriz);

            return oReturn;
        }

        protected int ListaApro()
        {
            GestionController ListApro = new GestionController();
            eAutorizador CtrAutoriz = new eAutorizador();
            IList<eAutorizador> Autoriz = new List<eAutorizador>();

            string ltrAp = string.Empty;
            string ltrRe = string.Empty;

            // LinkButton linkAp = new LinkButton();

            CtrAutoriz.Type = "2";
            CtrAutoriz.CodiOper = Convert.ToInt64(lblCodElec.Text);
            CtrAutoriz.CodiUsuPart = 0;//Convert.ToInt64(Session["sCodUsu"].ToString());
            Autoriz = ListApro.GetAutoriza(CtrAutoriz);

            if (Autoriz.Count > 0)
            {
                divRpst.Attributes["class"] = "PopupMostrar";

                for (int i = 0; i < Autoriz.Count; i++)
                {
                    if (Autoriz[i].RespUsuAuto != "")
                    {
                        if (Autoriz[i].RespUsuAuto == "A")
                        {
                            ltrAp = ltrAp + "<a runat='server' id='aLink" + i + "' href ='../Gestion/frmDocumentoElectronico.aspx?CodOper=" + lblCodElec.Text
                                          + "&IdeUser=" + Returnusuario(Autoriz[i].CodiUsuPart) + "' >"
                                          + Returnusuario(Autoriz[i].CodiUsuPart) + ";" + "</a>" + "&nbsp;";
                            ltrLAprobado.Text = ltrAp;

                        }
                        else if (Autoriz[i].RespUsuAuto == "D")
                        {
                            ltrRe = ltrRe + "<a runat='server' id='aLink" + i + "' href ='../Gestion/frmDocumentoElectronico.aspx?CodOper=" + lblCodElec.Text
                                          + "&IdeUser=" + Returnusuario(Autoriz[i].CodiUsuPart) + "' >"
                                          + Returnusuario(Autoriz[i].CodiUsuPart) + ";" + "</a>" + "&nbsp;";
                            ltrLRechazo.Text = ltrRe;
                        }
                    }

                    if (Autoriz[i].CodiUsuPart == Convert.ToInt64(Session["sCodUsu"].ToString()) && Autoriz[i].RespUsuAuto != "")
                    {
                        txtObservaciones.Enabled = false;
                        btnAutorizAprobar.Enabled = false;
                        btnAutorizRechazar.Enabled = false;
                    }

                }


            }
            return Autoriz.Count;
        }

        //protected void DocumentoAdjunto(Int64 CodAdj)
        //{
        //    DigitalizacionController DigController = new DigitalizacionController();
        //    eDocAdj CtrAdj = new eDocAdj();
        //    Int64 oReturn = 0;

        //    //CtrAdj.Type = "1";
        //    CtrAdj.CodiAdj = CodAdj;
        //    CtrAdj.CodiOper = Convert.ToInt64(lblCodElec.Text);
        //    CtrAdj.TipoOper = sTipoOperacion;
        //    CtrAdj.CodiDocAdju = Convert.ToInt64(txtAdjunto.Text);
        //    CtrAdj.TipoDocAdju = "DD";
        //    CtrAdj.CodiComenMesaV = 0;
        //    CtrAdj.EstDocuAdju = "A";
        //    oReturn = DigController.SetAddDocumentosAdjunto(CtrAdj);
        //}

        protected void ListaDocAdju()
        {
            DigitalizacionController DigController = new DigitalizacionController();
            eDocAdj CtrAdj = new eDocAdj();
            IList<eDocAdj> DocAdj = new List<eDocAdj>();

            CtrAdj.CodiOper = Convert.ToInt64(lblCodElec.Text);
            CtrAdj.CodiComenMesaV = 0;
            DocAdj = DigController.GetDocumentosAdjunto(CtrAdj);

            if (DocAdj.Count > 0)
            {
                ctlAdjuntarDocumento.DocumentoAdjuntoInsert = DocAdj;
            }
        }

        protected void AnulaDocAdj()
        {
            DigitalizacionController DigController = new DigitalizacionController();
            eDocAdj CtrAdj = new eDocAdj();
            Int64 oReturn = 0;

            CtrAdj.CodiOper = Convert.ToInt64(lblCodElec.Text);
            CtrAdj.CodiComenMesaV = 0;
            oReturn = DigController.SetAnulaDocumentosAdjunto(CtrAdj);
        }

        protected void ibtnEditar_Click(object sender, ImageClickEventArgs e)
        {
            EstadoControlPage(true);
        }

        protected void ibtnReenviar_Click(object sender, ImageClickEventArgs e)
        {
            panelReenvia();
        }

        //protected string SelectTipoEvento 
        //{
        //    Tipo1 = "DE009",
        //    Tipo2 = "DE001",
        //    Tipo3 = "DE008",
        //    Tipo4 = "DE007",
        //    Tipo5 = "DE015",
        //}

        protected string CalculaFechaPlazo(int DiasPlazo, DateTime Dias)
        {
            int fecha = 0;
            int DiasMas = DiasPlazo;

            for (int i = 0; i < DiasPlazo; i++)
            {
                fecha = Convert.ToInt32(Dias.AddDays(i).DayOfWeek);

                if (fecha == 6 || fecha == 0)
                {
                    DiasMas += 1;
                }
            }

            return Dias.AddDays(DiasMas).ToShortDateString();
        }

        protected string Returnusuario(Int64 CodUsu)
        {
            GestionController GestCon = new GestionController();
            eUsuario ReturnUser = new eUsuario();
            IList<eUsuario> LstReturnUser = new List<eUsuario>();
            eUsuario UserCriteria = new eUsuario();
            string sUsuario = string.Empty;

            UserCriteria.Codigo = CodUsu;
            LstReturnUser = GetListaUsuarioPer(UserCriteria, true);
            if (LstReturnUser.Count > 0)
            {
                sUsuario = LstReturnUser[0].IdeUsuario;
            }
            return sUsuario;
        }

        protected Int64 ReturnCodigoUser(string Ideuser)
        {
            GestionController GestCon = new GestionController();
            eUsuario ReturnUser = new eUsuario();
            IList<eUsuario> LstReturnUser = new List<eUsuario>();
            eUsuario UserCriteria = new eUsuario();
            Int64 sUsuario = 0;

            UserCriteria.Codigo = 0;
            UserCriteria.IdeUsuario = Ideuser.Trim();
            LstReturnUser = GetListaUsuarioPer(UserCriteria, true);
            if (LstReturnUser.Count > 0)
            {
                sUsuario = LstReturnUser[0].Codigo;
            }

            return sUsuario;
        }

        protected void UsuarioRpt(string IdeUser)
        {
            GestionController ListApro = new GestionController();
            eAutorizador CtrAutoriz = new eAutorizador();
            IList<eAutorizador> Autoriz = new List<eAutorizador>();



            CtrAutoriz.Type = "2";
            CtrAutoriz.CodiOper = Convert.ToInt64(lblCodElec.Text);
            CtrAutoriz.CodiUsuPart = ReturnCodigoUser(IdeUser);
            Autoriz = ListApro.GetAutoriza(CtrAutoriz);
            if (Autoriz.Count > 0)
            {
                txtObservaciones.Text = Autoriz[0].ComeUsuAuto;
                txtObservaciones.Enabled = false;
                btnAutorizAprobar.Enabled = false;
                btnAutorizRechazar.Enabled = false;
            }

        }

        protected void panelAutoriza()
        {
            GestionController ListApro = new GestionController();
            eAutorizador CtrAutoriz = new eAutorizador();
            IList<eAutorizador> Autoriz = new List<eAutorizador>();
            ///bool Verificar = false;
            CtrAutoriz.Type = "2";
            CtrAutoriz.CodiOper = Convert.ToInt64(lblCodElec.Text);
            CtrAutoriz.CodiUsuPart = 0;
            Autoriz = ListApro.GetAutoriza(CtrAutoriz);
            if (Autoriz.Count > 0)
            {
                // Verificar = true;
                divRpst.Attributes["class"] = "PopupMostrar";
                divPopup.Attributes["class"] = "PopupMostrar";
            }
            else
            {
                divRpst.Attributes["class"] = "PopupOcultar";
                divPopup.Attributes["class"] = "PopupOcultar";
            }
        }

        protected void panelReenvia()
        {
            if (lblEstado.Text == "ENVIADO")
            {
                // Verificar = true;
                divComentatioReeviar.Attributes["class"] = "PopupMostrar";
            }
            else
            {
                divComentatioReeviar.Attributes["class"] = "PopupOcultar";
            }
            ctlUserReenvio.EnabledControl = true;
        }

        protected string FormatMemo()
        {
            string formato = "<p><strong>{0} <br/>({1}) Dijo: </strong></p><p>{2}</p>";
            string memo = string.Empty;
            if (lblEstado.Text == "ENVIADO")
            {
                memo = string.Format(formato, Session["sNombre"].ToString(), String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now), txtComentario.Text);
            }
            return memo;
        }

        protected void ibtnVerComentarios_Click(object sender, ImageClickEventArgs e)
        {
            MostrarPopupComentarios(true);
        }
    }
}

