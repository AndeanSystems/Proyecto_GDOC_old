using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using WebGdoc.ServicesControllers;
using WebGdoc.DigitalizacionServRef;
//using WebGdoc.GestionServRef;
using WebGdoc.WebPage.Inicio;
using WebGdoc.WebPage.Controles;
using WebGdoc.GestionServRef;
using Entity.Entities;

namespace WebGdoc.WebPage.Gestion
{
    public partial class frmMesaVirtual : WebGdoc.Resources.Utility
    {
        string sTipoEvento;
        string sTipoOperacion = "MV";
        string sPageLoad = "../Gestion/frmMesaVirtual.aspx";
        DataTable TempGvw = new DataTable();
        DataRow TemDr;
        string sNumOper = "";
        Int64 sCodOper = 0;
        Int64 CodMesaComen = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (VerificarSessionUsuario(tbPrincipal))
            {
                if (!IsPostBack)
                {
                    Session.Remove("sURLActual");
                    Session.Add("sURLActual", Request.Url.ToString());

                    ConfigurarBarraHerramientas();
                    CargaTipoMV();

                    if(Request.QueryString["NumOper"]!=null){
                      sNumOper = Request.QueryString["NumOper"];
                    }

                    if (Request.QueryString["CodOper"] != null){
                        sCodOper = Convert.ToInt64(Request.QueryString["CodOper"]);
                    }

                    CargarTipoPrioridad();
                    CargarTipoAcceso();
                    ValidarGridView();
                    enabled_control(false);
                    txtFecOrganizacion.Enabled = false;
                    rbtNotificarAccion.SelectedValue = "S";
                    //Asigna Fecha del día
                    txtFecOrganizacion.Text = DateTime.Now.ToShortDateString();
                    txtFecCierre.Text = CalculaFechaPlazo(5, DateTime.Now);//DateTime.Now.AddDays(5).ToShortDateString();

                    txtNroDoc.Focus();
                    if (sNumOper != "" && sNumOper != null || sCodOper != 0 )
                    {
                        LimpiarControles(ctlUserInagurador);
                        //txtNroDoc.Text = sNumOper;
                        txtNroDoc.Enabled = false;
                        ibtnBuscar.Enabled = false;
                        ibtnNuevo.Enabled = false;
                        ibtnEditar.Enabled = false;
                        Buscar_MesaVirtual(sNumOper, sCodOper);
                    }
                }

                CargarImagen();
            }
        }

        protected void CargarImagen()
        {
            ibtnNuevo.ImageUrl = _UrlImagen + "img_Nuevo_" + (ibtnBuscar.Enabled ? "A" : "I") + ".jpg";
            ibtnEditar.ImageUrl = _UrlImagen + "img_Editar_" + (ibtnEditar.Enabled ? "A" : "I") + ".jpg";
            ibtnGuardar.ImageUrl = _UrlImagen + "img_Guardar_" + (ibtnGuardar.Enabled ? "A" : "I") + ".jpg";
            ibtnEnviar.ImageUrl = _UrlImagen + "img_Publicar_" + (ibtnEnviar.Enabled ? "A" : "I") + ".jpg";
            ibtnCerrar.ImageUrl = _UrlImagen + "img_CerrarMesa_" + (ibtnCerrar.Enabled ? "A" : "I") + ".jpg";
            ibtnEliminar.ImageUrl = _UrlImagen + "img_Eliminar_" + (ibtnEliminar.Enabled ? "A" : "I") + ".jpg";
            ibtnRegresar.ImageUrl = _UrlImagen + "img_Inicio_" + (ibtnRegresar.Enabled ? "A" : "I") + ".jpg";

            ibtnBuscar.ImageUrl = _UrlImagen + "img_Buscar_" + (ibtnBuscar.Enabled ? "A" : "I") + ".jpg";

            ibtnFecOrganizacion.ImageUrl = _UrlImagen + "img_Calendario_" + (ibtnFecOrganizacion.Enabled ? "A" : "I") + ".jpg";
            ibtnCalendFCier.ImageUrl = _UrlImagen + "img_Calendario_" + (ibtnCalendFCier.Enabled ? "A" : "I") + ".jpg";

            ibtnNuevoComent.ImageUrl = _UrlImagen + "img_Nuevo_" + (ibtnNuevoComent.Enabled ? "A" : "I") + ".jpg";
            ibtnActualizar.ImageUrl = _UrlImagen + "img_Actualizar_" + (ibtnActualizar.Enabled ? "A" : "I") + ".jpg";
        }

        protected void ConfigurarBarraHerramientas()
        {
            /*List<string> sLstLink = new List<string>();
            sLstLink.Add("WebPage/Busquedas/frmDocumentosDigitales.aspx|Ver historial|u507.bmp");
            sLstLink.Add("WebPage/Busquedas/frmDocumentosDigitales.aspx||u413.bmp");
            sLstLink.Add("WebPage/Busquedas/frmDocumentosDigitales.aspx|Nuevo documento|u460.jpeg");
            sLstLink.Add("WebPage/Busquedas/frmDocumentosDigitales.aspx||u499_original.png");*/

            ReferenciarTitulo(this, "Mesa de Trabajo Virtual");
            //ReferenciarLink(this, sLstLink);
        }

        protected void CargarTipoPrioridad()
        {
            GestionController TipoPrioridadController = new GestionController();
            eTipoPrioridad eTipoPrioridad = new eTipoPrioridad();

            eTipoPrioridad.EstaTipoPrio = "";
            object sTipoPrioridad = (object)TipoPrioridadController.GetTipoPrioridad(eTipoPrioridad);

            CargarDropDownList(ddlPriorAtenc, sTipoPrioridad, "DescTipoPrio", "CodiTipoPrio");
        }

        protected void CargarTipoAcceso()
        {
            GestionController TipoAccesoController = new GestionController();
            eTipoAcceso eAccesoSistema = new eTipoAcceso();

            eAccesoSistema.EstAcc = "";
            object sTipoAcceso = (object)TipoAccesoController.GetTipoAcceso(eAccesoSistema);

            CargarDropDownList(ddlTipoAcceso, sTipoAcceso, "DescAcc", "TipoAcc");
    
        }

        protected void ibtnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            Int64 oReturn = 0;
            if (ValidarCamposObligatorios())
            {
                if (txtNroDoc.Text == "")
                {
                    oReturn = Mantenimiento_MesaVirtual(0, "C", 1);
                    if (oReturn > 0)
                    {
                        RegistrarUsuarioParticipante(Convert.ToInt64(lblCodOper.Text), ctlUserInagurador, 4, "N");
                        RegistrarUsuarioParticipante(Convert.ToInt64(lblCodOper.Text), ctlUserParticipante, 1, "N");
                        sTipoEvento = "MV001";
                        RegistrarLogOperaciones(lblCodOper.Text);
                        if (ctlAdjuntarDocumento.UserText.Length > 0)
                        {
                            DocumentoAdjunto(0, 0,lblCodOper.Text, ctlAdjuntarDocumento);
                        }
                        MensajeAlerta(ibtnGuardar, "Mesa Virtual :" + lblNumOper.Text.Trim() + " guardada Correctamente", sPageLoad);
                    }
                    else { MensajeAlerta(ibtnGuardar, "Error al generar la Mesa Virtual"); }
                }
                else
                {
                    oReturn = Mantenimiento_MesaVirtual(Convert.ToInt64(lblCodOper.Text), "C", 2);
                    if (oReturn > 0)
                    {
                        AnulaParticipante(Convert.ToInt64(lblCodOper.Text), 0);
                        RegistrarUsuarioParticipante(Convert.ToInt64(lblCodOper.Text), ctlUserInagurador, 4, "N");
                        RegistrarUsuarioParticipante(Convert.ToInt64(lblCodOper.Text), ctlUserParticipante, 1, "N");
                        sTipoEvento = "MV013";
                        RegistrarLogOperaciones(lblCodOper.Text);
                        if (ctlAdjuntarDocumento.UserText.Length > 0)
                        {
                            AnulaDocAdj();

                            DocumentoAdjunto(0, 0,lblCodOper.Text, ctlAdjuntarDocumento);
                        }
                        MensajeAlerta(ibtnGuardar, "Mesa Virtual :" + lblNumOper.Text.Trim() + " actualizada Correctamente", sPageLoad);
                    }
                    else { MensajeAlerta(ibtnGuardar, "Error al Actualizar la Mesa Virtual"); }
                }
            }
            else
            {
                MensajeAlerta(ibtnGuardar, "Los datos ingresados no son correctos o estan incompletos");
            }
        }

        protected void ibtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            if (txtNroDoc.Text != "")
            {
                if (ValidaAccesoDocumento(0, txtNroDoc.Text, Convert.ToInt64(Session["sCodUsu"].ToString())))
                {
                    MensajeAlerta(ibtnBuscar, "El Documento a buscar es de caracter Privado. Ud no es usuario participante del documento");
                    return;
                }
                Buscar_MesaVirtual(txtNroDoc.Text,0); 
            }
            else { MensajeAlerta(ibtnBuscar, "Ingrese el Nro de Mesa Virtual"); }

        }

        protected void ibtnEnviar_Click(object sender, ImageClickEventArgs e)
        {
            Int64 oReturn = 0;
            Int64 sCodUsuario = 0;
            if (ValidarCamposObligatorios())
            {
                if (txtNroDoc.Text == "")
                {
                    oReturn = Mantenimiento_MesaVirtual(0, "V", 1);
                    if (oReturn > 0)
                    {
                        RegistrarUsuarioParticipante(Convert.ToInt64(lblCodOper.Text), ctlUserInagurador, 4, "N");
                        RegistrarUsuarioParticipante(Convert.ToInt64(lblCodOper.Text), ctlUserParticipante, 1, "S");

                        GridView sUserSelect = ctlUserParticipante.UsuarioSelect;
                        sTipoEvento = "MV012";
                        RegistrarLogOperaciones(lblCodOper.Text);
                        for (int i = 0; i < sUserSelect.Rows.Count; i++)
                        {
                            sTipoEvento = "MV011";
                            sCodUsuario = Convert.ToInt64(sUserSelect.Rows[i].Cells[0].Text);
                            MensajeAlerta(lblCodOper.Text, Convert.ToString(sCodUsuario));
                        }
                        if (ctlAdjuntarDocumento.UserText.Length > 0)
                        {
                            DocumentoAdjunto(0,0, lblCodOper.Text, ctlAdjuntarDocumento);
                        }
                        MensajeAlerta(ibtnEnviar, "Mesa Virtual: " + lblNumOper.Text.Trim() + " publicada Correctamente", sPageLoad);
                    }
                    else { MensajeAlerta(ibtnEnviar, "Error al publicar Mesa Virtual"); }
                }
                else
                {
                    oReturn = Mantenimiento_MesaVirtual(Convert.ToInt64(lblCodOper.Text), "V", 2);
                    if (oReturn > 0)
                    {
                        AnulaParticipante(Convert.ToInt64(lblCodOper.Text), 0);
                        RegistrarUsuarioParticipante(Convert.ToInt64(lblCodOper.Text), ctlUserInagurador, 4, "N");
                        RegistrarUsuarioParticipante(Convert.ToInt64(lblCodOper.Text), ctlUserParticipante, 1, "S");
                        GridView sUserSelect = ctlUserParticipante.UsuarioSelect;
                        sTipoEvento = "MV012";
                        RegistrarLogOperaciones(lblCodOper.Text);
                        for (int i = 0; i < sUserSelect.Rows.Count; i++)
                        {
                            sTipoEvento = "MV011";
                            sCodUsuario = Convert.ToInt64(sUserSelect.Rows[i].Cells[0].Text);
                            MensajeAlerta(lblCodOper.Text, Convert.ToString(sCodUsuario));
                        }
                        if (ctlAdjuntarDocumento.UserText.Length > 0)
                        {
                            AnulaDocAdj();

                            DocumentoAdjunto(0,0, lblCodOper.Text, ctlAdjuntarDocumento);
                        }
                        MensajeAlerta(ibtnEnviar, "Mesa Virtual: " + txtNroDoc.Text.Trim() + " publicada Correctamente", sPageLoad);
                    }
                    else { MensajeAlerta(ibtnEnviar, "Error al publicar Mesa Virtual"); }
                }
            }

        }

        protected void ibtnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            Int64 oReturn = 0;

            oReturn = Mantenimiento_MesaVirtual(Convert.ToInt64(lblCodOper.Text), "N", 2);
            if (oReturn > 0)
            {

                AnulaParticipante(Convert.ToInt64(lblCodOper.Text), 0);
                MensajeAlerta(ibtnEliminar, "Mesa Virtual Eliminado Correctamente", sPageLoad);
            }
        }

        protected void ibtnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            Limpiar_Controles();
            txtNroDoc.Enabled = false;
            ibtnBuscar.Enabled = false;
            ddlTipoAcceso.Focus();
            txtFecCierre.Text = CalculaFechaPlazo(5, DateTime.Now);
            enabled_control(true);
            divApro.Attributes["class"] = "PopupOcultar";
            divComen.Attributes["class"] = "PopupOcultar";
            divHistorial.Attributes["class"] = "PopupOcultar";

        }

        protected void ibtnCerrar_Click(object sender, ImageClickEventArgs e)
        {
            Int64 oReturn = 0;
            Int64 sCodUsuario = 0;

            oReturn = Mantenimiento_MesaVirtual(Convert.ToInt64(lblCodOper.Text), "R", 2);
            if (oReturn > 0)
            {
                GridView sUserSelect = ctlUserParticipante.UsuarioSelect;
                for (int i = 0; i < sUserSelect.Rows.Count; i++)
                {
                    sTipoEvento = "MV008";
                    sCodUsuario = Convert.ToInt64(sUserSelect.Rows[i].Cells[0].Text);
                    MensajeAlerta(lblCodOper.Text, Convert.ToString(sCodUsuario));
                }
                AnulaParticipante(Convert.ToInt64(lblCodOper.Text), 0);
                MensajeAlerta(ibtnEliminar, "Mesa Virtual :" + lblNumOper.Text.Trim() + " fue cerrada", sPageLoad);
            }
        }

        protected void RegistrarUsuarioParticipante(Int64 CodOper, ValidarUsuario_Grupo ctlUserParti, int sTipoPart, string sEnviNoti)
        {
            GestionController UsuarioPerController = new GestionController();
            eParticipante UsuarioPar = new eParticipante();
            eUsuarioGrupo UsuarioGrupo = new eUsuarioGrupo();
            IList<eUsuarioGrupo> LsteUsuarioGrupo = new List<eUsuarioGrupo>();
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

        protected Int64 Mantenimiento_MesaVirtual(Int64 CodOper, string sEstado, int Tipo)
        {
            DigitalizacionController MesaVirController = new DigitalizacionController();
            eMesaVirtual CtrMesaVirtual = new eMesaVirtual();

            Int64 oReturn = 0;
            CtrMesaVirtual.Type = Tipo;
            CtrMesaVirtual.CodiOper = CodOper;
            CtrMesaVirtual.Fecha = Convert.ToDateTime(txtFecOrganizacion.Text + " " + DateTime.Now.TimeOfDay);
            CtrMesaVirtual.FechaFin = Convert.ToDateTime((txtFecCierre.Text + " " + DateTime.Now.TimeOfDay));
            CtrMesaVirtual.Estado = sEstado;//rbtMesaAbierta.SelectedValue.ToString();
            CtrMesaVirtual.Titulo = txtTitulo.Text;
            CtrMesaVirtual.Prioridad = ddlPriorAtenc.SelectedValue.ToString();
            CtrMesaVirtual.Notifica = rbtNotificarAccion.SelectedValue.ToString();
            CtrMesaVirtual.DesMesaVir = txtAsunto.Text;
            CtrMesaVirtual.Acceso = ddlTipoAcceso.SelectedValue.ToString();
            CtrMesaVirtual.ClaseMV = Convert.ToInt16(ddlTipoMesaV.SelectedValue.ToString());
            CtrMesaVirtual.NumOper = txtNroDoc.Text;
            CtrMesaVirtual.CodiUsu = Convert.ToInt64(Session["sCodUsu"].ToString());
            oReturn = MesaVirController.SetMesaVirtual(CtrMesaVirtual);

            lblCodOper.Text = CtrMesaVirtual.CodiOper.ToString();
            lblNumOper.Text = CtrMesaVirtual.NumOper;

            return oReturn;


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

        protected void RegistrarLogOperaciones(string sCodOper)
        {
            DigitalizacionController LogOperacionController = new DigitalizacionController();
            eLogOperacion eLogOperacion = new eLogOperacion();

            eLogOperacion.CodiLogOper = 0;
            eLogOperacion.FechEven = System.DateTime.Now;
            eLogOperacion.TipoOper = sTipoOperacion;
            eLogOperacion.CodiOper = sCodOper;
            eLogOperacion.CodiEven = sTipoEvento;
            eLogOperacion.CodiUsu = Convert.ToInt64(Session["sCodUsu"].ToString());
            eLogOperacion.CodiCnx = 0;

            LogOperacionController.SetLogOperacion(eLogOperacion);

        }

        protected void Buscar_MesaVirtual(string NumOper, Int64 sCodOper)
        {
            DigitalizacionController MesVirController = new DigitalizacionController();
            eMesaVirtual MesVirCtr = new eMesaVirtual();
            IList<eMesaVirtual> MesaVir = new List<eMesaVirtual>();

            MesVirCtr.CodiOper = sCodOper;
            MesVirCtr.CodiUsu = 0;
            MesVirCtr.NumOper = NumOper.Trim();

            MesaVir = MesVirController.GetMesaVirtual(MesVirCtr);

            if (MesaVir.Count > 0)
            {
               
                ddlTipoAcceso.SelectedValue = MesaVir[0].Acceso.ToString();
                ddlTipoMesaV.SelectedValue = MesaVir[0].ClaseMV.ToString();
                ddlPriorAtenc.SelectedValue = MesaVir[0].Prioridad.ToString();
                txtFecOrganizacion.Text = MesaVir[0].Fecha.Value.ToShortDateString();
                txtFecCierre.Text = MesaVir[0].FechaFin.ToShortDateString();
                rbtNotificarAccion.SelectedValue = MesaVir[0].Notifica.ToString();
                lblCodOper.Text = MesaVir[0].CodiOper.ToString();
                txtNroDoc.Text = MesaVir[0].NumOper.ToString();
                lblNumOper.Text = txtNroDoc.Text;
                txtAsunto.Text = MesaVir[0].Asunto;
              
                txtTitulo.Text = MesaVir[0].Titulo;
                //txtAsunto.Text = MesaVir[0].DesMesaVir;
                LimpiarControles(ctlUserInagurador);
                ReturnUsuaPart(Convert.ToInt64(lblCodOper.Text), 4, ctlUserInagurador);
                ReturnUsuaPart(Convert.ToInt64(lblCodOper.Text), 1, ctlUserParticipante);
                ListaApro(Convert.ToInt64(lblCodOper.Text), Convert.ToInt64(Session["sCodUsu"].ToString()), 0);
                ListaDocAdju(Convert.ToInt64(lblCodOper.Text),0,ctlAdjuntarDocumento);
                MarcarLeido(MesaVir);
                switch (MesaVir[0].Estado.ToString())
                {
                    case "C":
                        lblEstadoMV.Text = "Creado";
                        enabled_control(true);
                        divComen.Attributes["class"] = "PopupOcultar";
                        divHistorial.Attributes["class"] = "PopupOcultar";
                        divApro.Attributes["class"] = "PopupOcultar";
                        Panel3.Enabled = false;
                        break;
                    case "V":
                        lblEstadoMV.Text = "Vigente";
                        //ibtnCerrar.Visible = true;
                        Panel3.Enabled = true;
                        pnlAprobar.Enabled = true;
                        pnlComentario.Enabled = true;
                        ibtnEditar.Enabled = false;
                        ibtnGuardar.Enabled = false;
                        ibtnEnviar.Enabled = false;
                        break;
                    case "N":
                        lblEstadoMV.Text = "Anulado";
                        enabled_control(false);
                        break;
                    case "R":
                        lblEstadoMV.Text = "Cerrado";
                        enabled_control(false);
                        break;
                    case "F":
                        lblEstadoMV.Text = "Finalizado";
                        enabled_control(false);
                        break;
                    default:
                        break;
                }
            }
            else
            { MensajeAlerta(ibtnBuscar, "La Mesa Virtual:" + txtNroDoc.Text + " no existe"); }
        }

        private void MarcarLeido(IList<eMesaVirtual> mesaVirtualLista)
        {
            var codiUsu = (Int64)Session["sCodUsu"];

            var mesaVirtual = new List<eMesaVirtual>(mesaVirtualLista).Find(x => x.CodiUsu == codiUsu);            
            if (mesaVirtual != null)
            {
                var participante = new eParticipante();
                participante.CodiOper = mesaVirtual.CodiOper;
                participante.CodiUsu = codiUsu;
                participante.ConfLect = "S";
                new GestionController().UpdateUsuParticipante(participante);
            }
        }

        protected void Limpiar_Controles()
        {
            LimpiarControles(ddlPriorAtenc);
            CargarTipoPrioridad();
            LimpiarControles(ddlTipoAcceso);
            CargarTipoAcceso();
            //LimpiarControles(txtFecOrganizacion);
            LimpiarControles(txtFecCierre);
            LimpiarControles(txtTitulo);
            LimpiarControles(txtAsunto);
            LimpiarControles(txtNroDoc);
            LimpiarControles(lblEstadoMV);
            LimpiarControles(ctlUserParticipante);
            ctlAdjuntarDocumento.LimpiarControl = true;

        }

        protected void enabled_control(bool status)
        {
            txtTitulo.Enabled = status;
            txtAsunto.Enabled = status;
            ddlPriorAtenc.Enabled = status;
            ddlTipoAcceso.Enabled = status;
            ddlTipoMesaV.Enabled = status;
            //rbtMesaAbierta.Enabled = status;
            rbtNotificarAccion.Enabled = status;
            ibtnEliminar.Enabled = status;
            ibtnGuardar.Enabled = status;
            ibtnEnviar.Enabled = status;
            ibtnEditar.Enabled = status;
            //txtComentario.Enabled = status;
            //txtObservaciones.Enabled = status;
            txtFecOrganizacion.Enabled = status;
            pnlAprobar.Enabled = status;
            pnlComentario.Enabled = status;
            //txtFecCierre.Enabled = status;
            //ibtnCalendFCier.Enabled = status;
            //ibtnFecOrganizacion.Enabled = false;

            ibtnCerrar.Visible = false;
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

            for (int i = 0; i < UserPart.Count; i++)
            {
                if (UserPart[i].CodiUsu == Convert.ToInt64(Session["sCodUsu"].ToString()))
                {
                    divComen.Attributes["class"] = "PopupMostrar";
                    divHistorial.Attributes["class"] = "PopupMostrar";
                    ComentariosGrilla(Convert.ToInt64(lblCodOper.Text), 0);
                    if (UserPart[i].ApruOper == "S")
                    {
                        //lblNumPart.Text = UserPart[i].CodiUsuPart.ToString();
                        divApro.Attributes["class"] = "PopupMostrar";
                    }
                }
                if (UserPart[i].TipoPart == 4)
                {
                    lblNumPart.Text = UserPart[i].CodiUsu.ToString();
                    if (UserPart[i].CodiUsu.ToString() == Session["sCodUsu"].ToString())
                    {
                        divRpst.Attributes["class"] = "PopupMostrar";
                        ListaApro(Convert.ToInt64(lblCodOper.Text), 0, 1);
                        enabled_control(true);
                    }
                }
               if (UserPart[i].TipoPart == 4 && UserPart[i].CodiUsu == Convert.ToInt64(Session["sCodUsu"].ToString()))
                    ibtnCerrar.Visible = true;

                if (UserPart[i].CodiUsu == Convert.ToInt64(Session["sCodUsu"].ToString()) && UserPart[i].TipoPart == 4)
                {
                    ibtnCerrar.Visible = true;// Revisar: Solo cuando es usuario Organizador
                    //break;

                }
            }

            for (int i = 0; i < UserPart.Count; i++)
            {
                if (UserPart[i].TipoPart == sTipoPart)
                {
                    UserCriteria.Codigo = UserPart[i].CodiUsu;
                    LstReturnUser = GetListaUsuarioPer(UserCriteria, true);

                    ctlUsuarioValido.UsuarioInsert = LstReturnUser;
                }
            }
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

        protected bool ValidarCamposObligatorios()
        {
            bool sValidar = true;

            if (sValidar)
                sValidar = VerificarTipoDato(txtFecCierre, "Date");

            if (sValidar)
                sValidar = VerificarTipoDato(txtFecOrganizacion, "Date");

            return sValidar;
        }

        protected void ValidarGridView()
        {
            VerificarGridView(gvwComentarios);

        }

        protected void ComentarioMesaVirtual(string Comentario)
        {
            DigitalizacionController ComentMesaVirt = new DigitalizacionController();
            eMesaVirtual CtrComent = new eMesaVirtual();

            Int64 oReturn = 0;


            CtrComent.Type = 1;
            CtrComent.CodiMesaComent = 0;
            CtrComent.Asunto = Comentario;
            CtrComent.Fecha = System.DateTime.Now;
            CtrComent.Estado = "A";
            CtrComent.CodiOper = Convert.ToInt64(lblCodOper.Text);
            CtrComent.CodiUsu = Convert.ToInt64(Session["sCodUsu"].ToString());

            oReturn = ComentMesaVirt.SetMesaComentario(CtrComent);
            CodMesaComen = CtrComent.CodiMesaComent;
        }

        protected void btnComentar_Click(object sender, EventArgs e)
        {
            ComentarioMesaVirtual(txtComentario.Text);
            if (ComentarioAdjuntarDocumento.UserText.Length > 0)
            {
                DocumentoAdjunto(0, CodMesaComen, lblCodOper.Text, ComentarioAdjuntarDocumento);
                ComentarioAdjuntarDocumento.LimpiarControl = true;
            }
            sTipoEvento = "MV005";
            RegistrarLogOperaciones(lblCodOper.Text);
            txtComentario.Text = "";
            ComentariosGrilla(Convert.ToInt64(lblCodOper.Text), 0);
            txtComentario.Focus();
        }

        protected void ComentariosGrilla(Int64 CodOper, Int64 CodUsu)
        {
            DigitalizacionController ComentController = new DigitalizacionController();
            eMesaVirtual CtrMVC = new eMesaVirtual();
            IList<eMesaVirtual> Comentario = new List<eMesaVirtual>();

            CtrMVC.CodiOper = CodOper;
            CtrMVC.CodiUsu = CodUsu;
            Comentario = ComentController.GetMesaComentario(CtrMVC);
            if (Comentario.Count > 0 && Comentario != null)
            {
                TempGvw.Columns.Add("sCodiComen");
                TempGvw.Columns.Add("sFechaHora");
                TempGvw.Columns.Add("sParticipante");
                TempGvw.Columns.Add("sComentario");

                for (int i = 0; i < Comentario.Count; i++)
                {
                    TemDr = TempGvw.NewRow();
                    TemDr[0] = Comentario[i].CodiMesaComent;
                    TemDr[1] = Comentario[i].Fecha;
                    TemDr[2] = Returnusuario(Comentario[i].CodiUsu);
                    TemDr[3] = Comentario[i].Asunto;
                    TempGvw.Rows.Add(TemDr);
                }
                if (TempGvw.Rows.Count > 0)
                {
                   /* gvwComentarios.DataSource = TempGvw;
                    gvwComentarios.DataBind();

                    TempGvw.Columns.Clear();
                    TempGvw.Clear();*/

                    int[] sColumn = { 0 };

                    CargarGridView(gvwComentarios, TempGvw, sColumn);
                    TempGvw.Columns.Clear();
                    TempGvw.Clear();
                }
               /* else
                {
                    gvwComentarios.DataSource = null;
                    gvwComentarios.DataBind();
                    VerificarGridView(gvwComentarios);
                }
                */
                CargaIconoAdjunto(gvwComentarios);
                TempGvw.Columns.Clear();
                TempGvw.Clear();
            }
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

        protected Int64 RespAutoriza(string Rpta)
        {
            Int64 oReturn = 0;
            GestionController AutoController = new GestionController();
            eAutorizador CtrAutoriz = new eAutorizador();

            CtrAutoriz.Type = "2";
            CtrAutoriz.CodiUsuPart = Convert.ToInt64(Session["sCodUsu"].ToString());
            CtrAutoriz.CodiOper = Convert.ToInt64(lblCodOper.Text);
            CtrAutoriz.TipoOper = "MV";
            CtrAutoriz.RespUsuAuto = Rpta;
            CtrAutoriz.FechUsuAuto = System.DateTime.Now;
            CtrAutoriz.ComeUsuAuto = txtObservaciones.Text;
            CtrAutoriz.EstaAuto = "A";
            oReturn = AutoController.SetAutorizaAdd(CtrAutoriz);

            return oReturn;
        }

        protected void btnAutorizAprobar_Click(object sender, EventArgs e)
        {
            Int64 oReturn = 0;
            string Rpta = "A";
            string cadena;

            GridView sUserSelect = ctlUserInagurador.UsuarioSelect;
            
                oReturn = RespAutoriza(Rpta);
                if (oReturn > 0)
                {
                    sTipoEvento = "MV003";
                    RegistrarLogOperaciones(lblCodOper.Text);
                    MensajeAlerta(lblCodOper.Text, sUserSelect.Rows[0].Cells[0].Text);
                    cadena = "APROBADO. " + txtObservaciones.Text;
                    ComentarioMesaVirtual(cadena);
                    txtObservaciones.Text = "";
                    ComentariosGrilla(Convert.ToInt64(lblCodOper.Text), 0);
                    txtObservaciones.Focus();
                    divApro.Attributes["class"] = "PopupOcultar";
                    MensajeAlerta(btnAutorizAprobar, "Acaba de Aprobar La Mesa de Trabajo Virtual :" + txtNroDoc.Text.Trim(), sPageLoad);
                }
            
            
        }

        protected void btnAutorizRechazar_Click(object sender, EventArgs e)
        {
            Int64 oReturn = 0;
            string Rpta = "D";
            string cadena;
            GridView sUserSelect = ctlUserInagurador.UsuarioSelect;

                oReturn = RespAutoriza(Rpta);

                if (oReturn > 0)
                {
                    sTipoEvento = "MV004";
                    RegistrarLogOperaciones(lblCodOper.Text);
                    MensajeAlerta(lblCodOper.Text, sUserSelect.Rows[0].Cells[0].Text);
                    cadena = "RECHAZADO. " + txtObservaciones.Text;
                    ComentarioMesaVirtual(cadena);
                    txtObservaciones.Text = "";
                    ComentariosGrilla(Convert.ToInt64(lblCodOper.Text), 0);
                    txtObservaciones.Focus();
                    divApro.Attributes["class"] = "PopupOcultar";
                    MensajeAlerta(btnAutorizRechazar, "Acaba de Rechazar La Mesa de Trabajo Virtua :" + txtNroDoc.Text.Trim(), sPageLoad);
                }
            
            
        }

        protected void ListaApro(Int64 Oper,Int64 User,int Type)
        {
            GestionController ListApro = new GestionController();
            eAutorizador CtrAutoriz = new eAutorizador();
            IList<eAutorizador> Autoriz = new List<eAutorizador>();
            string sApro = string.Empty;
            string sDesa = string.Empty;

            CtrAutoriz.Type = "3";
            CtrAutoriz.CodiOper = Oper;
            CtrAutoriz.CodiUsuPart = User;
            Autoriz = ListApro.GetAutoriza(CtrAutoriz);

            if (Autoriz.Count > 0)
            {
                if (Type == 0)
                {
                    if (Autoriz[0].RespUsuAuto != "")
                    {
                        divApro.Attributes["class"] = "PopupOcultar";
                    }
                }
                else if (Type == 1)
                {
                    for (int i = 0; i < Autoriz.Count; i++)
                    {
                        if (Autoriz[i].RespUsuAuto != "" && Autoriz[i].RespUsuAuto != null)
                        {
                            if (Autoriz[i].RespUsuAuto == "A")
                            {
                                if (sApro == "")
                                {
                                    sApro = Returnusuario(Autoriz[i].CodiUsuPart);
                                }
                                else { sApro = sApro + "; " + Returnusuario(Autoriz[i].CodiUsuPart); }
                            }
                            else if (Autoriz[i].RespUsuAuto == "D")
                            {
                                if (sDesa == "")
                                {
                                    sDesa = Returnusuario(Autoriz[i].CodiUsuPart);
                                }
                                else { sDesa = sDesa + "; " + Returnusuario(Autoriz[i].CodiUsuPart); }
                            }
                        }
                    }

                    txtAprobados.Text = sApro;
                    txtRechazado.Text = sDesa;
                
                }
            }
        }

        protected void ibtnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            ComentariosGrilla(Convert.ToInt64(lblCodOper.Text), 0);
        }

        protected void CargaTipoMV()
        {
            BusquedaController TipoMVControlle = new BusquedaController();
            eMesaVirtual TipoMvCriteria = new eMesaVirtual();
            IList<eMesaVirtual> TipoMV = new List<eMesaVirtual>();

            TipoMvCriteria.Estado = "";
            TipoMV = TipoMVControlle.GetTipoMV(TipoMvCriteria);

            CargarDropDownList(ddlTipoMesaV, TipoMV, "DesMesaVir", "ClaseMV");

            ddlTipoMesaV.SelectedValue = "0";

        }

       /* protected void ListaDocAdju()
        {
            DigitalizacionController DigController = new DigitalizacionController();
            eDocAdj CtrAdj = new eDocAdj();
            IList<eDocAdj> DocAdj = new List<eDocAdj>();

            CtrAdj.CodiOper = Convert.ToInt64(lblCodOper.Text);
            CtrAdj.CodiComenMesaV = 0;
            DocAdj = DigController.GetDocumentosAdjunto(CtrAdj);

            if (DocAdj.Count > 0)
            {
                ctlAdjuntarDocumento.DocumentoAdjuntoInsert = DocAdj;
            }
        }*/

        protected void AnulaDocAdj()
        {
            DigitalizacionController DigController = new DigitalizacionController();
            eDocAdj CtrAdj = new eDocAdj();
            Int64 oReturn = 0;

            CtrAdj.CodiOper = Convert.ToInt64(lblCodOper.Text);
            CtrAdj.CodiComenMesaV = 0;
            oReturn = DigController.SetAnulaDocumentosAdjunto(CtrAdj);
        }

        protected void DocumentoAdjunto(Int64 CodAdj,Int64 CodiComenMesaV,string sCodOper,AdjuntarDocumento oControl)
        {
            DigitalizacionController DigController = new DigitalizacionController();
            eDocAdj CtrAdj = new eDocAdj();
            Int64 oReturn = 0;

            GridView sDocAdjSelect = oControl.DocumentoAdjuntoSelect;
            for (int i = 0; i < sDocAdjSelect.Rows.Count; i++)
            {
                //CtrAdj.Type = "1";
                CtrAdj.CodiAdj = CodAdj;
                CtrAdj.CodiOper = Convert.ToInt64(sCodOper);
                CtrAdj.TipoOper = sTipoOperacion;
                CtrAdj.CodiDocAdju = Convert.ToInt64(sDocAdjSelect.Rows[i].Cells[0].Text);
                CtrAdj.TipoDocAdju = sDocAdjSelect.Rows[i].Cells[3].Text;
                CtrAdj.CodiComenMesaV = CodiComenMesaV;
                CtrAdj.EstDocuAdju = "A";
                oReturn = DigController.SetAddDocumentosAdjunto(CtrAdj);
            }
        }

        protected void ibtnEditar_Click(object sender, ImageClickEventArgs e)
        {
            enabled_control(true);
        }

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

        protected void txtFecOrganizacion_TextChanged(object sender, EventArgs e)
        {
            this.txtFecCierre.Text = CalculaFechaPlazo(5, Convert.ToDateTime(this.txtFecOrganizacion.Text));
        }

        protected void ListaDocAdju(Int64 CodOper, Int64 CodMesaComent, AdjuntarDocumento oControl)
        {
            DigitalizacionController DigController = new DigitalizacionController();
            eDocAdj CtrAdj = new eDocAdj();
            IList<eDocAdj> DocAdj = new List<eDocAdj>();

            CtrAdj.CodiOper = CodOper;
            CtrAdj.CodiComenMesaV = CodMesaComent;
            DocAdj = DigController.GetDocumentosAdjunto(CtrAdj);
            
                if (DocAdj.Count > 0)
                {
                    oControl.DocumentoAdjuntoInsert = DocAdj;
                }          
        }

        protected void CargaIconoAdjunto(GridView GvwData)
        {
            for (int i = 0; i < GvwData.Rows.Count; i++)
            {
                System.Web.UI.HtmlControls.HtmlImage imgLink1 = (System.Web.UI.HtmlControls.HtmlImage)GvwData.Rows[i].Cells[4].FindControl("imgLink2");

                if (DocAdjuGrilla(0, Convert.ToInt64(GvwData.DataKeys[i].Value.ToString())))
                    imgLink1.Src = _UrlImagen + "img_Adjunto_" + (imgLink1.Disabled ? "A" : "I") + ".jpg";
                    
                else
                    imgLink1.Src = _UrlImagen + "img_transparent_" + (imgLink1.Disabled ? "A" : "I") + ".gif";
            }
        }

        protected bool DocAdjuGrilla(Int64 CodOper, Int64 CodMesaComent)
        {
            DigitalizacionController DigController = new DigitalizacionController();
            eDocAdj CtrAdj = new eDocAdj();
            IList<eDocAdj> DocAdj = new List<eDocAdj>();

            bool Verifica = false;

            CtrAdj.CodiOper = CodOper;
            CtrAdj.CodiComenMesaV = CodMesaComent;
            DocAdj = DigController.GetDocumentosAdjunto(CtrAdj);

            if (DocAdj.Count > 0)
            {
                Verifica = true;
            }

            return Verifica;
        }

        protected void gvwComentarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iRows = gvwComentarios.SelectedIndex;

            ComentarioAdjuntarDocumento.LimpiarControl = true;

            txtComentario.Text = gvwComentarios.Rows[iRows].Cells[3].Text;

            ListaDocAdju(0, Convert.ToInt64(gvwComentarios.Rows[iRows].Cells[0].Text), ComentarioAdjuntarDocumento);
            
            this.ibtnNuevoComent.Visible = true;
           

        }

        protected void ibtnNuevoComent_Click(object sender, ImageClickEventArgs e)
        {
            txtComentario.Text = "";
            ComentarioAdjuntarDocumento.LimpiarControl = true;

            this.ibtnNuevoComent.Visible = false;
        }

        protected void ibtnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            string sPageInicio = "../Inicio/frmEscritorioVirtual.aspx";
            RedireccionarPage(tbPrincipal, sPageInicio);
        }
    }
}