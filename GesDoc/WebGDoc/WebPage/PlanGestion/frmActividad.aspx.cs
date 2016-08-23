using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGdoc.PlanGestionServRef;
using WebGdoc.WebPage.Controles;
using WebGdoc.ServicesControllers;
using WebGdoc.GestionServRef;
using Entity.Entities;

namespace WebGdoc.WebPage.Configuracion
{
    public partial class frmActividad : WebGdoc.Resources.Utility
    {
        string UserCrea = "ANDSYS";
        string sPageLoad = "../PlanGestion/frmActividad.aspx";
        string _V1 = "0";
        string _Page = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (VerificarSessionUsuario(tbPrincipal))
            {
                if (!IsPostBack)
                {
                    Session.Remove("sURLActual");
                    Session.Add("sURLActual", Request.Url.ToString());

                    ConfigurarBarraHerramientas();

                    ConfigurarInicial();

                    CargaPeriodo();
                    CargaObjetivoE(1,  " -- Seleccione --");
                    CargaObjetivoO(2,  " -- Seleccione --");
                    CargaProyecto(3,  " -- Seleccione --");
                    CargaActividad(4,  " -- Seleccione --");
                    CargaEstado();
                    CargarResponsable();
                    MostrarControles();
                    if (Request.QueryString["Act"] != null)
                    {
                        _Page = Request.QueryString["Act"].ToString();
                        if (_Page == "0")
                            lblTituloPagina.Text = "Actividades";
                        else
                            lblTituloPagina.Text = "Avance de Actividades";
                    }
                    ddlActividad.Visible = true;
                    txtDescipcion.Visible = false;
                    ConfigurarControles(false);

                    CargaActividad(5,  "");
                }

                CargarImagen();
            }
        }

        protected void CargarImagen()
        {
            ibtnBuscar.ImageUrl = _UrlImagen + "img_Buscar_" + (ibtnBuscar.Enabled ? "A" : "I") + ".jpg";
            ibtnNuevo.ImageUrl = _UrlImagen + "img_Nuevo_" + (ibtnNuevo.Enabled ? "A" : "I") + ".jpg";
            ibtnEditar.ImageUrl = _UrlImagen + "img_Editar_" + (ibtnEditar.Enabled ? "A" : "I") + ".jpg";
            ibtnGuardar.ImageUrl = _UrlImagen + "img_Guardar_" + (ibtnGuardar.Enabled ? "A" : "I") + ".jpg";
            ibtnEliminar.ImageUrl = _UrlImagen + "img_Eliminar_" + (ibtnEliminar.Enabled ? "A" : "I") + ".jpg";
            ibtnRegresar.ImageUrl = _UrlImagen + "img_Inicio_" + (ibtnRegresar.Enabled ? "A" : "I") + ".jpg";
        }

        protected void ConfigurarBarraHerramientas()
        {
            /*List<string> sLstLink = new List<string>();
            sLstLink.Add("WebPage/Gestion/frmDocumentoElectronico.aspx|Nuevo documento electrónico|u17_original.png");
            sLstLink.Add("WebPage/Busquedas/frmDocumentosElectronicos.aspx|Buscar documento electrónico|u21_original.png");
            sLstLink.Add("WebPage/Gestion/frmMesaVirtual.aspx|Organizar mesa de trabajo virtual|u25_original.jpg");
            sLstLink.Add("WebPage/Digitalizacion/frmDocumentosFisicos.aspx|Digitalización de documentos|u29_original.jpg");
*/
            ReferenciarTitulo(this, "Acctividad");
            //ReferenciarLink(this, sLstLink);
        }

#region CargarComboBox

        protected void CargaPeriodo()
        {
            PlanGestionController _PlanGestionController = new PlanGestionController();
            ePlanGestion _ePlanGestion = new ePlanGestion();
            IList<ePlanGestion> LstPeriodo = new List<ePlanGestion>();
            ePlanGestion _Periodo;

            for (int y = 2012; y <= DateTime.Now.Year; y++)
            {
                _Periodo = new ePlanGestion();
                _Periodo.PeriObjEstr = y;
                _Periodo.PeriPlanGes = y;
                LstPeriodo.Add(_Periodo);
            }

            CargarDropDownList(dllPeriodo, LstPeriodo, "PeriObjEstr", "PeriPlanGes");
        }

        protected void CargarResponsable()
        {
            GestionController _GestionController = new GestionController();
            eUsuario _eUsuario = new eUsuario();
            IList<eUsuario> LstReturnUser = new List<eUsuario>();

            _eUsuario.Codigo = 0;
            LstReturnUser = GetListaUsuarioPer(_eUsuario, true);
            CargarDropDownList(dllReponsable, LstReturnUser, "IdeUsuario", "Codigo");
        }

        protected void CargaObjetivoE(Int16 _TypeOperacion, String _Items)
        {
            PlanGestionController _PlanGestionController = new PlanGestionController();
            ePlanGestion _ePlanGestion = new ePlanGestion();
            IList<ePlanGestion> LstEstrategico = new List<ePlanGestion>();

            _ePlanGestion.TypeOperacion = _TypeOperacion;
            _ePlanGestion.PeriObjEstr = Convert.ToInt32(dllPeriodo.SelectedValue);
            if (ddlEstrategico.SelectedValue != "")
                _ePlanGestion.CodiObjEstr = Convert.ToInt32(ddlEstrategico.SelectedValue);

            LstEstrategico = _PlanGestionController.GetObetivoEstrategico(_ePlanGestion, _Items);

            CargarDropDownList(ddlEstrategico, LstEstrategico, "DescObjEstr", "CodiObjEstr");

        }

        protected void CargaObjetivoO(Int16 _TypeOperacion, String _Items)
        {
            PlanGestionController _PlanGestionController = new PlanGestionController();
            ePlanGestion _ePlanGestion = new ePlanGestion();
            IList<ePlanGestion> LstEstrategico = new List<ePlanGestion>();

            _ePlanGestion.TypeOperacion = _TypeOperacion;
            _ePlanGestion.PeriObjEstr = Convert.ToInt32(dllPeriodo.SelectedValue);
            if (ddlEstrategico.SelectedValue != "")
                _ePlanGestion.CodiObjEstr = Convert.ToInt32(ddlEstrategico.SelectedValue);
            if (ddlOperativo.SelectedValue != "")
                _ePlanGestion.CodiObjOper = Convert.ToInt32(ddlOperativo.SelectedValue);

            LstEstrategico = _PlanGestionController.GetObetivoOperativo(_ePlanGestion, _Items);

            if (_TypeOperacion == 2)
                CargarDropDownList(ddlOperativo, LstEstrategico, "DescObjOper", "CodiObjOper");

            else if (_TypeOperacion == 3)
            {
                txtCodigo.Text = LstEstrategico[0].CodiObjOper.ToString();
                
                txtDescipcion.Text = LstEstrategico[0].DescObjOper.ToString();
                txtAbrev.Text = LstEstrategico[0].AbreObjOper.ToString();
                dllEstado.SelectedValue = LstEstrategico[0].EstaObjOper.ToString();
            }
        }

        protected void CargaProyecto(Int16 _TypeOperacion, String _Items)
        {
            PlanGestionController _PlanGestionController = new PlanGestionController();
            ePlanGestion _ePlanGestion = new ePlanGestion();
            IList<ePlanGestion> LstEstrategico = new List<ePlanGestion>();

            _ePlanGestion.TypeOperacion = _TypeOperacion;
            _ePlanGestion.PeriObjEstr = Convert.ToInt32(dllPeriodo.SelectedValue);
            if (ddlEstrategico.SelectedValue != "")
                _ePlanGestion.CodiObjEstr = Convert.ToInt32(ddlEstrategico.SelectedValue);

            if (ddlOperativo.SelectedValue != "")
                _ePlanGestion.CodiObjOper = Convert.ToInt32(ddlOperativo.SelectedValue);

            if (ddlProyecto.SelectedValue != "")
                _ePlanGestion.CodiProy = Convert.ToInt32(ddlProyecto.SelectedValue);

            LstEstrategico = _PlanGestionController.GetProyecto(_ePlanGestion, _Items);

            if (_TypeOperacion == 3)
                CargarDropDownList(ddlProyecto, LstEstrategico, "DescProy", "CodiProy");

            else if (_TypeOperacion == 4)
            {
                txtCodigo.Text = LstEstrategico[0].CodiProy.ToString();
                txtDescipcion.Text = LstEstrategico[0].DescProy.ToString();
                txtAbrev.Text = LstEstrategico[0].AbreProy.ToString();
                dllEstado.SelectedValue = LstEstrategico[0].EstaProy.ToString();
            }
        }

        protected void CargaActividad(Int16 _TypeOperacion, String _Items)
        {
            PlanGestionController _PlanGestionController = new PlanGestionController();
            ePlanGestion _ePlanGestion = new ePlanGestion();
            IList<ePlanGestion> LstEstrategico = new List<ePlanGestion>();

            _ePlanGestion.TypeOperacion = _TypeOperacion;
            _ePlanGestion.PeriObjEstr = Convert.ToInt32(dllPeriodo.SelectedValue);
            if (ddlEstrategico.SelectedValue != "")
                _ePlanGestion.CodiObjEstr = Convert.ToInt32(ddlEstrategico.SelectedValue);

            if (ddlOperativo.SelectedValue != "")
                _ePlanGestion.CodiObjOper = Convert.ToInt32(ddlOperativo.SelectedValue);

            if (ddlProyecto.SelectedValue != "")
                _ePlanGestion.CodiProy = Convert.ToInt32(ddlProyecto.SelectedValue);

            if (ddlActividad.SelectedValue != "")
                _ePlanGestion.CodiActi = Convert.ToInt32(ddlActividad.SelectedValue);

            LstEstrategico = _PlanGestionController.GetActividad(_ePlanGestion, _Items);

            if (_TypeOperacion == 4)
                CargarDropDownList(ddlActividad, LstEstrategico, "DescActi", "CodiActi");

            else if (_TypeOperacion == 5)
            {
                if (LstEstrategico.Count > 0)
                {
                    txtCodigo.Text = LstEstrategico[0].CodiActi.ToString();
                    Session.Add("sActiv", txtCodigo.Text);
                    txtDescipcion.Text = LstEstrategico[0].DescActi.ToString();
                    txtAbrev.Text = LstEstrategico[0].AbreActi.ToString();
                    dllEstado.SelectedValue = LstEstrategico[0].EstaActi.ToString();
                    txtUnidad.Text = LstEstrategico[0].UnidMedMeta.ToString();
                    if(LstEstrategico[0].CodiUsu>0)
                        dllReponsable.SelectedValue = LstEstrategico[0].CodiUsu.ToString();

                    txtEneComp.Text = LstEstrategico[0].CompEne.ToString();
                    txtFebComp.Text = LstEstrategico[0].CompFeb.ToString();
                    txtMarComp.Text = LstEstrategico[0].CompMar.ToString();
                    txtAbrComp.Text = LstEstrategico[0].CompAbr.ToString();
                    txtMayComp.Text = LstEstrategico[0].CompMay.ToString();
                    txtJunComp.Text = LstEstrategico[0].CompJun.ToString();
                    txtJulComp.Text = LstEstrategico[0].CompJul.ToString();
                    txtAgoComp.Text = LstEstrategico[0].CompAgo.ToString();
                    txtSetComp.Text = LstEstrategico[0].CompSet.ToString();
                    txtOctComp.Text = LstEstrategico[0].CompOct.ToString();
                    txtNovComp.Text = LstEstrategico[0].CompNov.ToString();
                    txtDicComp.Text = LstEstrategico[0].CompDic.ToString();

                    txtEneAvan.Text = LstEstrategico[0].AvanEne.ToString();
                    txtFebAvan.Text = LstEstrategico[0].AvanFeb.ToString();
                    txtMarAvan.Text = LstEstrategico[0].AvanMar.ToString();
                    txtAbrAvan.Text = LstEstrategico[0].AvanAbr.ToString();
                    txtMayAvan.Text = LstEstrategico[0].AvanMay.ToString();
                    txtJunAvan.Text = LstEstrategico[0].AvanJun.ToString();
                    txtJulAvan.Text = LstEstrategico[0].AvanJul.ToString();
                    txtAgoAvan.Text = LstEstrategico[0].AvanAgo.ToString();
                    txtSetAvan.Text = LstEstrategico[0].AvanSet.ToString();
                    txtOctAvan.Text = LstEstrategico[0].AvanOct.ToString();
                    txtNovAvan.Text = LstEstrategico[0].AvanNov.ToString();
                    txtDicAvan.Text = LstEstrategico[0].AvanDic.ToString();

                    txtEneCome.Text = CargarComentarioAvance(6, 1);
                    txtFebCome.Text = CargarComentarioAvance(6, 2);
                    txtMarCome.Text = CargarComentarioAvance(6, 3);
                    txtAbrCome.Text = CargarComentarioAvance(6, 4);
                    txtMayCome.Text = CargarComentarioAvance(6, 5);
                    txtJunCome.Text = CargarComentarioAvance(6, 6);
                    txtJulCome.Text = CargarComentarioAvance(6, 7);
                    txtAgoCome.Text = CargarComentarioAvance(6, 8);
                    txtSetCome.Text = CargarComentarioAvance(6, 9);
                    txtOctCome.Text = CargarComentarioAvance(6, 10);
                    txtNovCome.Text = CargarComentarioAvance(6, 11);
                    txtDicCome.Text = CargarComentarioAvance(6, 12);


                    _V1 = Request.QueryString["Act"].ToString();

                    if (Convert.ToInt16(_V1) == 1)
                    {
                        if (Convert.ToDecimal(txtEneAvan.Text) > 0)
                            txtEneCome.Visible = true;
                        else
                            txtEneCome.Visible = false;


                        if (Convert.ToDecimal(txtFebAvan.Text) > 0)
                            txtFebCome.Visible = true;
                        else
                            txtFebCome.Visible = false;


                        if (Convert.ToDecimal(txtMarAvan.Text) > 0)
                            txtMarCome.Visible = true;
                        else
                            txtMarCome.Visible = false;


                        if (Convert.ToDecimal(txtAbrAvan.Text) > 0)
                            txtAbrCome.Visible = true;
                        else
                            txtAbrCome.Visible = false;


                        if (Convert.ToDecimal(txtMayAvan.Text) > 0)
                            txtMayCome.Visible = true;
                        else
                            txtMayCome.Visible = false;


                        if (Convert.ToDecimal(txtJunAvan.Text) > 0)
                            txtJunCome.Visible = true;
                        else
                            txtJunCome.Visible = false;


                        if (Convert.ToDecimal(txtJulAvan.Text) > 0)
                            txtJulCome.Visible = true;
                        else
                            txtJulCome.Visible = false;


                        if (Convert.ToDecimal(txtAgoAvan.Text) > 0)
                            txtAgoCome.Visible = true;
                        else
                            txtAgoCome.Visible = false;


                        if (Convert.ToDecimal(txtSetAvan.Text) > 0)
                            txtSetCome.Visible = true;
                        else
                            txtSetCome.Visible = false;


                        if (Convert.ToDecimal(txtOctAvan.Text) > 0)
                            txtOctCome.Visible = true;
                        else
                            txtOctCome.Visible = false;


                        if (Convert.ToDecimal(txtNovAvan.Text) > 0)
                            txtNovCome.Visible = true;
                        else
                            txtNovCome.Visible = false;


                        if (Convert.ToDecimal(txtDicAvan.Text) > 0)
                            txtDicCome.Visible = true;
                        else
                            txtDicCome.Visible = false;

                    }


                    ibtnEditar.Enabled = true;
                }

            }
        }

        protected void CargaEstado()
        {
            PlanGestionController _PlanGestionController = new PlanGestionController();
            ePlanGestion _ePlanGestion = new ePlanGestion();
            IList<ePlanGestion> LstEstado = new List<ePlanGestion>();
            ePlanGestion _Estado;

            _Estado = new ePlanGestion();
            _Estado.EstaObjOper = "A";
            _Estado.Coment = "Activo";
            LstEstado.Add(_Estado);

            _Estado = new ePlanGestion();
            _Estado.EstaObjOper = "I";
            _Estado.Coment = "Inactivo";
            LstEstado.Add(_Estado);

            _Estado = new ePlanGestion();
            _Estado.EstaObjOper = "E";
            _Estado.Coment = "Eliminado";
            LstEstado.Add(_Estado);

            CargarDropDownList(dllEstado, LstEstado, "Coment", "EstaObjOper");
        }

        protected string CargarComentarioAvance(Int16 _TypeOperacion,  Int16 _Periodo)
        {
            string _Coment = string.Empty;

            PlanGestionController _PlanGestionController = new PlanGestionController();
            ePlanGestion _ePlanGestion = new ePlanGestion();
            IList<ePlanGestion> LstEstrategico = new List<ePlanGestion>();

            _ePlanGestion.TypeOperacion = _TypeOperacion;
            _ePlanGestion.PeriObjEstr = Convert.ToInt32(dllPeriodo.SelectedValue);

            if (ddlEstrategico.SelectedValue != "")
                _ePlanGestion.CodiObjEstr = Convert.ToInt32(ddlEstrategico.SelectedValue);

            if (ddlOperativo.SelectedValue != "")
                _ePlanGestion.CodiObjOper = Convert.ToInt32(ddlOperativo.SelectedValue);

            if (ddlProyecto.SelectedValue != "")
                _ePlanGestion.CodiProy = Convert.ToInt32(ddlProyecto.SelectedValue);

            if (ddlActividad.SelectedValue != "")
                _ePlanGestion.CodiActi = Convert.ToInt32(ddlActividad.SelectedValue);

            _ePlanGestion.MesAvan = _Periodo;

            LstEstrategico = _PlanGestionController.GetComentarioAvance(_ePlanGestion, "");

            if (LstEstrategico.Count > 0)
                _Coment = LstEstrategico[0].Coment;

            return _Coment;
        }

#endregion

#region Configuraciones

        protected void ConfigurarInicial()
        {
            this.txtEneComp.Attributes.Add("OnKeyPress", "return AcceptNum(event)"); //, '')");
            this.txtEneAvan.Attributes.Add("OnKeyPress", "return AcceptNum(event)"); //, 'txtEneComp')");

            this.txtFebComp.Attributes.Add("OnKeyPress", "return AcceptNum(event)"); //, '')");
            this.txtFebAvan.Attributes.Add("OnKeyPress", "return AcceptNum(event)"); //, 'txtFebAvan')");

            this.txtMarComp.Attributes.Add("OnKeyPress", "return AcceptNum(event)"); //, '')");
            this.txtMarAvan.Attributes.Add("OnKeyPress", "return AcceptNum(event)"); //, 'txtMarAvan')");

            this.txtAbrComp.Attributes.Add("OnKeyPress", "return AcceptNum(event)"); //, '')");
            this.txtAbrAvan.Attributes.Add("OnKeyPress", "return AcceptNum(event)"); //, 'txtAbrAvan')");

            this.txtMayComp.Attributes.Add("OnKeyPress", "return AcceptNum(event)"); //, '')");
            this.txtMayAvan.Attributes.Add("OnKeyPress", "return AcceptNum(event)"); //, 'txtMayAvan')");

            this.txtJunComp.Attributes.Add("OnKeyPress", "return AcceptNum(event)"); //, '')");
            this.txtJunAvan.Attributes.Add("OnKeyPress", "return AcceptNum(event)"); //, 'txtJunAvan')");

            this.txtJulComp.Attributes.Add("OnKeyPress", "return AcceptNum(event)"); //, '')");
            this.txtJulAvan.Attributes.Add("OnKeyPress", "return AcceptNum(event)"); //, 'txtJulAvan')");

            this.txtAgoComp.Attributes.Add("OnKeyPress", "return AcceptNum(event)"); //, '')");
            this.txtAgoAvan.Attributes.Add("OnKeyPress", "return AcceptNum(event)"); //, 'txtAgoAvan')");

            this.txtSetComp.Attributes.Add("OnKeyPress", "return AcceptNum(event)"); //, '')");
            this.txtSetAvan.Attributes.Add("OnKeyPress", "return AcceptNum(event)"); //, 'txtSetAvan')");

            this.txtOctComp.Attributes.Add("OnKeyPress", "return AcceptNum(event)"); //, '')");
            this.txtOctAvan.Attributes.Add("OnKeyPress", "return AcceptNum(event)"); //, 'txtOctAvan')");

            this.txtNovComp.Attributes.Add("OnKeyPress", "return AcceptNum(event)"); //, '')");
            this.txtNovAvan.Attributes.Add("OnKeyPress", "return AcceptNum(event)"); //, 'txtNovAvan')");

            this.txtDicComp.Attributes.Add("OnKeyPress", "return AcceptNum(event)"); //, '')");
            this.txtDicAvan.Attributes.Add("OnKeyPress", "return AcceptNum(event)"); //, 'txtDicAvan')");
        }

        protected void ConfigurarControles(bool status)
        {
            _V1 = Request.QueryString["Act"].ToString();

            txtCodigo.Enabled = status;

            if (Convert.ToInt16(_V1) == 0 || status == false)
            {
                dllReponsable.Enabled = status;
                txtDescipcion.Enabled = status;
                txtAbrev.Enabled = status;
                dllEstado.Enabled = status;
                txtUnidad.Enabled = status;

                txtEneComp.Enabled = status;
                txtFebComp.Enabled = status;
                txtMarComp.Enabled = status;
                txtAbrComp.Enabled = status;
                txtMayComp.Enabled = status;
                txtJunComp.Enabled = status;
                txtJulComp.Enabled = status;
                txtAgoComp.Enabled = status;
                txtSetComp.Enabled = status;
                txtOctComp.Enabled = status;
                txtNovComp.Enabled = status;
                txtDicComp.Enabled = status;
            }

            txtEneAvan.Enabled = status;
            txtFebAvan.Enabled = status;
            txtMarAvan.Enabled = status;
            txtAbrAvan.Enabled = status;
            txtMayAvan.Enabled = status;
            txtJunAvan.Enabled = status;
            txtJulAvan.Enabled = status;
            txtAgoAvan.Enabled = status;
            txtSetAvan.Enabled = status;
            txtOctAvan.Enabled = status;
            txtNovAvan.Enabled = status;
            txtDicAvan.Enabled = status;

        }

        protected bool ValidarCamposObligatorios()
        {
            bool sValidar = true;

            //if (sValidar)
            //    sValidar = VerificarTipoDato(txtRUC, "Len");

            return sValidar;
        }

        protected void LimpiarControles()
        {
            txtCodigo.Text = "";
            txtDescipcion.Text = "";
            txtAbrev.Text = "";
            dllEstado.SelectedValue = "A";

            txtUnidad.Text = "";
            txtEneComp.Text = "";
            txtFebComp.Text = "";
            txtMarComp.Text = "";
            txtAbrComp.Text = "";
            txtMayComp.Text = "";
            txtJunComp.Text = "";
            txtJulComp.Text = "";
            txtAgoComp.Text = "";
            txtSetComp.Text = "";
            txtOctComp.Text = "";
            txtNovComp.Text = "";
            txtDicComp.Text = "";

            txtEneAvan.Text = "";
            txtFebAvan.Text = "";
            txtMarAvan.Text = "";
            txtAbrAvan.Text = "";
            txtMayAvan.Text = "";
            txtJunAvan.Text = "";
            txtJulAvan.Text = "";
            txtAgoAvan.Text = "";
            txtSetAvan.Text = "";
            txtOctAvan.Text = "";
            txtNovAvan.Text = "";
            txtDicAvan.Text = "";
            
            txtEneCome.Text = "";
            txtFebCome.Text = "";
            txtMarCome.Text = "";
            txtAbrCome.Text = "";
            txtMayCome.Text = "";
            txtJunCome.Text = "";
            txtJulCome.Text = "";
            txtAgoCome.Text = "";
            txtSetCome.Text = "";
            txtOctCome.Text = "";
            txtNovCome.Text = "";
            txtDicCome.Text = "";

        }

        protected void MostrarControles()
        {
            _V1 = Request.QueryString["Act"].ToString();

            if (Convert.ToInt16(_V1) == 1)
            {
                Label10.Visible = true;
                txtEneAvan.Visible = true;
                txtFebAvan.Visible = true;
                txtMarAvan.Visible = true;
                txtAbrAvan.Visible = true;
                txtMayAvan.Visible = true;
                txtJunAvan.Visible = true;
                txtJulAvan.Visible = true;
                txtAgoAvan.Visible = true;
                txtSetAvan.Visible = true;
                txtOctAvan.Visible = true;
                txtNovAvan.Visible = true;
                txtDicAvan.Visible = true;
            }
            else
            {
                Label10.Visible = false;
                txtEneAvan.Visible = false;
                txtFebAvan.Visible = false;
                txtMarAvan.Visible = false;
                txtAbrAvan.Visible = false;
                txtMayAvan.Visible = false;
                txtJunAvan.Visible = false;
                txtJulAvan.Visible = false;
                txtAgoAvan.Visible = false;
                txtSetAvan.Visible = false;
                txtOctAvan.Visible = false;
                txtNovAvan.Visible = false;
                txtDicAvan.Visible = false;
            }

            txtEneCome.Visible = false;
            txtFebCome.Visible = false;
            txtMarCome.Visible = false;
            txtAbrCome.Visible = false;
            txtMayCome.Visible = false;
            txtJunCome.Visible = false;
            txtJulCome.Visible = false;
            txtAgoCome.Visible = false;
            txtSetCome.Visible = false;
            txtOctCome.Visible = false;
            txtNovCome.Visible = false;
            txtDicCome.Visible = false;
        }

#endregion

#region Botonera

        protected void ibtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            // MensajeAlerta(ibtnBuscar, "Ingrese el RUC a buscar");


        }

        protected void ibtnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            ddlActividad.Visible = false;
            txtDescipcion.Visible = true;
            botonera(this.ibtnNuevo);
            ConfigurarControles(true);
            LimpiarControles();
        }

        protected void ibtnEditar_Click(object sender, ImageClickEventArgs e)
        {
            ddlActividad.Visible = false;
            txtDescipcion.Visible = true;

            ibtnNuevo.Enabled = true;
            ibtnEditar.Enabled = false;
            ibtnGuardar.Enabled = true;
            ConfigurarControles(true);
        }

        protected void ibtnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            Int64 oReturn = 0;
            
            if (ValidarCamposObligatorios())
            {
                //if (txtCodigo.Text.Length == 0)
                if (Session["sActiv"] == null)
                    oReturn = Mantenimiento(1, "");
                else
                {
                    _V1 = Request.QueryString["Act"].ToString();

                    if (Convert.ToInt16(_V1) == 0)
                        if (Session["sActiv"].ToString() == txtCodigo.Text)
                        {
                            oReturn = Mantenimiento(2, "");
                        }
                        else 
                        {
                            Mantenimiento(3, "E");
                            oReturn = Mantenimiento(1, "");
                        }
                    else
                    {
                            oReturn = Mantenimiento(4, "");
                            //oReturn = MantenimientoComentario(4, "");

                            if (txtEneCome.Visible)
                                oReturn = MantenimientoComentario(1, txtEneCome.Text);

                            if (txtFebCome.Visible)
                                oReturn = MantenimientoComentario(2, txtFebCome.Text);

                            if (txtMarCome.Visible)
                                oReturn = MantenimientoComentario(3, txtMarCome.Text);

                            if (txtAbrCome.Visible)
                                oReturn = MantenimientoComentario(4, txtAbrCome.Text);

                            if (txtMayCome.Visible)
                                oReturn = MantenimientoComentario(5, txtMayCome.Text);

                            if (txtJunCome.Visible)
                                oReturn = MantenimientoComentario(6, txtJunCome.Text);

                            if (txtJulCome.Visible)
                                oReturn = MantenimientoComentario(7, txtJulCome.Text);

                            if (txtAgoCome.Visible)
                                oReturn = MantenimientoComentario(8, txtAgoCome.Text);

                            if (txtSetCome.Visible)
                                oReturn = MantenimientoComentario(9, txtSetCome.Text);

                            if (txtOctCome.Visible)
                                oReturn = MantenimientoComentario(10, txtOctCome.Text);

                            if (txtNovCome.Visible)
                                oReturn = MantenimientoComentario(11, txtNovCome.Text);

                            if (txtDicCome.Visible)
                                oReturn = MantenimientoComentario(12, txtDicCome.Text);


                        }
                }

                if (oReturn > 0)
                {                                                            
                    if (lblTituloPagina.Text == "Actividades")
                    {
                        if (txtEneComp.Text == "")
                            txtEneComp.Text = "0";

                        if (txtFebComp.Text == "")
                            txtFebComp.Text = "0";

                        if (txtMarComp.Text == "")
                            txtMarComp.Text = "0";

                        if (txtAbrComp.Text == "")
                            txtAbrComp.Text = "0";

                        if (txtMayComp.Text == "")
                            txtMayComp.Text = "0";

                        if (txtJunComp.Text == "")
                            txtJunComp.Text = "0";

                        if (txtJulComp.Text == "")
                            txtJulComp.Text = "0";

                        if (txtAgoComp.Text == "")
                            txtAgoComp.Text = "0";

                        if (txtSetComp.Text == "")
                            txtSetComp.Text = "0";

                        if (txtOctComp.Text == "")
                            txtOctComp.Text = "0";

                        if (txtNovComp.Text == "")
                            txtNovComp.Text = "0";

                        if (txtDicComp.Text == "")
                            txtDicComp.Text = "0";

                        Double _SumaComp = Convert.ToDouble(txtEneComp.Text) + Convert.ToDouble(txtFebComp.Text) + Convert.ToDouble(txtMarComp.Text)
                                     + Convert.ToDouble(txtAbrComp.Text) + Convert.ToDouble(txtMayComp.Text) + Convert.ToDouble(txtJunComp.Text)
                                     + Convert.ToDouble(txtJulComp.Text) + Convert.ToDouble(txtAgoComp.Text) + Convert.ToDouble(txtSetComp.Text)
                                     + Convert.ToDouble(txtOctComp.Text) + Convert.ToDouble(txtNovComp.Text) + Convert.ToDouble(txtDicComp.Text);

                        if (_SumaComp == 100)
                            MensajeAlerta(ibtnGuardar, "Los datos ingresados satisfactoriamente");
                        else if (_SumaComp > 100)
                            MensajeAlerta(ibtnGuardar, "Los datos ingresados satisfactoriamente. El rango de compromisos es Mayor al 100%");
                        else if (_SumaComp < 100)
                            MensajeAlerta(ibtnGuardar, "Los datos ingresados satisfactoriamente. El rango de compromisos es Menor al 100%");
                    }
                    else
                    {
                        if (txtEneAvan.Text == "")
                            txtEneAvan.Text = "0";

                        if (txtFebAvan.Text == "")
                            txtFebAvan.Text = "0";

                        if (txtMarAvan.Text == "")
                            txtMarAvan.Text = "0";

                        if (txtAbrAvan.Text == "")
                            txtAbrAvan.Text = "0";

                        if (txtMayAvan.Text == "")
                            txtMayAvan.Text = "0";

                        if (txtJunAvan.Text == "")
                            txtJunAvan.Text = "0";

                        if (txtJulAvan.Text == "")
                            txtJulAvan.Text = "0";

                        if (txtAgoAvan.Text == "")
                            txtAgoAvan.Text = "0";

                        if (txtSetAvan.Text == "")
                            txtSetAvan.Text = "0";

                        if (txtOctAvan.Text == "")
                            txtOctAvan.Text = "0";

                        if (txtNovAvan.Text == "")
                            txtNovAvan.Text = "0";

                        if (txtDicAvan.Text == "")
                            txtDicAvan.Text = "0";

                        Double _SumaAvan = Convert.ToDouble(txtEneAvan.Text) + Convert.ToDouble(txtFebAvan.Text) + Convert.ToDouble(txtMarAvan.Text)
                                     + Convert.ToDouble(txtAbrAvan.Text) + Convert.ToDouble(txtMayAvan.Text) + Convert.ToDouble(txtJunAvan.Text)
                                     + Convert.ToDouble(txtJulAvan.Text) + Convert.ToDouble(txtAgoAvan.Text) + Convert.ToDouble(txtSetAvan.Text)
                                     + Convert.ToDouble(txtOctAvan.Text) + Convert.ToDouble(txtNovAvan.Text) + Convert.ToDouble(txtDicAvan.Text);

                        if (_SumaAvan == 100)
                            MensajeAlerta(ibtnGuardar, "Los datos ingresados satisfactoriamente");
                        else if (_SumaAvan > 100)
                            MensajeAlerta(ibtnGuardar, "Los datos ingresados satisfactoriamente. El rango de Avance es Mayor al 100%");
                        else if (_SumaAvan < 100)
                            MensajeAlerta(ibtnGuardar, "Los datos ingresados satisfactoriamente. El rango de Avance es Menor al 100%");
                    }
                    CargaObjetivoE(1,  " -- Seleccione --");
                    CargaObjetivoO(2,  " -- Seleccione --");
                    CargaProyecto(3,  " -- Seleccione --");
                    CargaActividad(4,  " -- Seleccione --");

                    ddlActividad.Visible = true;
                    txtDescipcion.Visible = false;

                    LimpiarControles();
                    botonera(this.ibtnGuardar);
                    CargaActividad(5,  "");

                    ConfigurarControles(false);
                }
            }
            else
                MensajeAlerta(ibtnGuardar, "Los datos ingresados no son correctos o estan incompletos");
        }

        protected void ibtnEliminar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibtnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            string sPageInicio = "../Inicio/frmEscritorioVirtual.aspx";
            RedireccionarPage(tbPrincipal, sPageInicio);
        }

#endregion

#region Controles

        protected void dllPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlEstrategico_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaObjetivoO(2,  " -- Seleccione --");
            LimpiarControles();

            CargaProyecto(3,  " -- Seleccione --");
            CargaActividad(4,  " -- Seleccione --");
            CargaActividad(5,  "");
        }

        protected void ddlOperativo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaProyecto(3,  " -- Seleccione --");
            LimpiarControles();

            CargaActividad(4,  " -- Seleccione --");
            CargaActividad(5,  "");
        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaActividad(4,  " -- Seleccione --");
            LimpiarControles();

            CargaActividad(5,  "");
        }

        protected void ddlActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaActividad(5,  "");

            ibtnNuevo.Enabled = true;
            ibtnEditar.Enabled = true;
        }

        protected void txtEneAvan_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)(sender)).Text.Length > 0)
                txtEneCome.Visible = true;
            else
                txtEneCome.Visible = false;
        }

        protected void txtFebAvan_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)(sender)).Text.Length > 0)
                txtFebCome.Visible = true;
            else
                txtFebCome.Visible = false;
        }

        protected void txtMarAvan_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)(sender)).Text.Length > 0)
                txtMarCome.Visible = true;
            else
                txtMarCome.Visible = false;
        }

        protected void txtAbrAvan_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)(sender)).Text.Length > 0)
                txtAbrCome.Visible = true;
            else
                txtAbrCome.Visible = false;
        }

        protected void txtMayAvan_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)(sender)).Text.Length > 0)
                txtMayCome.Visible = true;
            else
                txtMayCome.Visible = false;
        }

        protected void txtJunAvan_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)(sender)).Text.Length > 0)
                txtJunCome.Visible = true;
            else
                txtJunCome.Visible = false;
        }

        protected void txtJulAvan_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)(sender)).Text.Length > 0)
                txtJulCome.Visible = true;
            else
                txtJulCome.Visible = false;
        }

        protected void txtAgoAvan_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)(sender)).Text.Length > 0)
                txtAgoCome.Visible = true;
            else
                txtAgoCome.Visible = false;
        }

        protected void txtSetAvan_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)(sender)).Text.Length > 0)
                txtSetCome.Visible = true;
            else
                txtSetCome.Visible = false;
        }

        protected void txtOctAvan_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)(sender)).Text.Length > 0)
                txtOctCome.Visible = true;
            else
                txtOctCome.Visible = false;
        }

        protected void txtNovAvan_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)(sender)).Text.Length > 0)
                txtNovCome.Visible = true;
            else
                txtNovCome.Visible = false;
        }

        protected void txtDicAvan_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)(sender)).Text.Length > 0)
                txtDicCome.Visible = true;
            else
                txtDicCome.Visible = false;
        }


#endregion

#region Procesos

        protected Int64 Mantenimiento(Int16 Type, string Estado)
        {
            Int64 sPlanEstrategico = 0;

            PlanGestionController PlanGestionController = new PlanGestionController();
            ePlanGestion PlanGestionCtr = new ePlanGestion();

            PlanGestionCtr.TypeOperacion = Type;
            PlanGestionCtr.PeriObjEstr = Convert.ToInt32(dllPeriodo.SelectedValue);

            PlanGestionCtr.CodiObjEstr = Convert.ToInt32(ddlEstrategico.SelectedValue);

            PlanGestionCtr.CodiObjOper = Convert.ToInt32(ddlOperativo.SelectedValue);

            PlanGestionCtr.CodiProy = Convert.ToInt32(ddlProyecto.SelectedValue);

            if (Session["sActiv"] != null && Session["sActiv"].ToString() != "")
            {   
                if(Type==3)
                    PlanGestionCtr.CodiActi = Convert.ToInt32(Session["sActiv"].ToString());
                else
                    PlanGestionCtr.CodiActi = Convert.ToInt32(txtCodigo.Text);
            }
            else
                PlanGestionCtr.CodiActi = Convert.ToInt32(txtCodigo.Text);

            PlanGestionCtr.DescActi = txtDescipcion.Text;
            PlanGestionCtr.AbreActi = txtAbrev.Text;
            if(Type!=3)
                PlanGestionCtr.EstaActi = dllEstado.SelectedValue;
            else
                PlanGestionCtr.EstaActi = Estado;

            PlanGestionCtr.UnidMedMeta = txtUnidad.Text;
            PlanGestionCtr.CodiUsu = Convert.ToInt64(dllReponsable.SelectedValue);
            PlanGestionCtr.CompEne = (txtEneComp.Text.Length > 0 ? Convert.ToDecimal(txtEneComp.Text) : 0);
            PlanGestionCtr.CompFeb = (txtFebComp.Text.Length > 0 ? Convert.ToDecimal(txtFebComp.Text) : 0);
            PlanGestionCtr.CompMar = (txtMarComp.Text.Length > 0 ? Convert.ToDecimal(txtMarComp.Text) : 0);
            PlanGestionCtr.CompAbr = (txtAbrComp.Text.Length > 0 ? Convert.ToDecimal(txtAbrComp.Text) : 0);
            PlanGestionCtr.CompMay = (txtMayComp.Text.Length > 0 ? Convert.ToDecimal(txtMayComp.Text) : 0);
            PlanGestionCtr.CompJun = (txtJunComp.Text.Length > 0 ? Convert.ToDecimal(txtJunComp.Text) : 0);
            PlanGestionCtr.CompJul = (txtJulComp.Text.Length > 0 ? Convert.ToDecimal(txtJulComp.Text) : 0);
            PlanGestionCtr.CompAgo = (txtAgoComp.Text.Length > 0 ? Convert.ToDecimal(txtAgoComp.Text) : 0);
            PlanGestionCtr.CompSet = (txtSetComp.Text.Length > 0 ? Convert.ToDecimal(txtSetComp.Text) : 0);
            PlanGestionCtr.CompOct = (txtOctComp.Text.Length > 0 ? Convert.ToDecimal(txtOctComp.Text) : 0);
            PlanGestionCtr.CompNov = (txtNovComp.Text.Length > 0 ? Convert.ToDecimal(txtNovComp.Text) : 0);
            PlanGestionCtr.CompDic = (txtDicComp.Text.Length > 0 ? Convert.ToDecimal(txtDicComp.Text) : 0);

            PlanGestionCtr.AvanEne = (txtEneAvan.Text.Length > 0 ? Convert.ToDecimal(txtEneAvan.Text) : 0);
            PlanGestionCtr.AvanFeb = (txtFebAvan.Text.Length > 0 ? Convert.ToDecimal(txtFebAvan.Text) : 0);
            PlanGestionCtr.AvanMar = (txtMarAvan.Text.Length > 0 ? Convert.ToDecimal(txtMarAvan.Text) : 0);
            PlanGestionCtr.AvanAbr = (txtAbrAvan.Text.Length > 0 ? Convert.ToDecimal(txtAbrAvan.Text) : 0);
            PlanGestionCtr.AvanMay = (txtMayAvan.Text.Length > 0 ? Convert.ToDecimal(txtMayAvan.Text) : 0);
            PlanGestionCtr.AvanJun = (txtJunAvan.Text.Length > 0 ? Convert.ToDecimal(txtJunAvan.Text) : 0);
            PlanGestionCtr.AvanJul = (txtJulAvan.Text.Length > 0 ? Convert.ToDecimal(txtJulAvan.Text) : 0);
            PlanGestionCtr.AvanAgo = (txtAgoAvan.Text.Length > 0 ? Convert.ToDecimal(txtAgoAvan.Text) : 0);
            PlanGestionCtr.AvanSet = (txtSetAvan.Text.Length > 0 ? Convert.ToDecimal(txtSetAvan.Text) : 0);
            PlanGestionCtr.AvanOct = (txtOctAvan.Text.Length > 0 ? Convert.ToDecimal(txtOctAvan.Text) : 0);
            PlanGestionCtr.AvanNov = (txtNovAvan.Text.Length > 0 ? Convert.ToDecimal(txtNovAvan.Text) : 0);
            PlanGestionCtr.AvanDic = (txtDicAvan.Text.Length > 0 ? Convert.ToDecimal(txtDicAvan.Text) : 0);


            sPlanEstrategico = PlanGestionController.SetActividad(PlanGestionCtr);

            return sPlanEstrategico;
        }

        protected void botonera(ImageButton _ImageButton)
        {
            switch (_ImageButton.AlternateText)
            {
                case "Nuevo":
                    ibtnNuevo.Enabled = false;
                    ibtnGuardar.Enabled = true;
                    ibtnEditar.Enabled = false;
                    ibtnEliminar.Enabled = true;
                    break;

                case "Guardar":
                    ibtnNuevo.Enabled = true;
                    ibtnGuardar.Enabled = false;
                    ibtnEditar.Enabled = false;
                    ibtnEliminar.Enabled = false;
                    break;

                default: break;
            }
        }

        protected Int64 MantenimientoComentario(Int16 Type, string _txtComentario)
        {
            Int64 sPlanEstrategico = 0;

            PlanGestionController PlanGestionController = new PlanGestionController();
            ePlanGestion PlanGestionCtr = new ePlanGestion();

            PlanGestionCtr.TypeOperacion = Type;
            PlanGestionCtr.PeriObjEstr = Convert.ToInt32(dllPeriodo.SelectedValue);

            PlanGestionCtr.CodiObjEstr = Convert.ToInt32(ddlEstrategico.SelectedValue);

            PlanGestionCtr.CodiObjOper = Convert.ToInt32(ddlOperativo.SelectedValue);

            PlanGestionCtr.CodiProy = Convert.ToInt32(ddlProyecto.SelectedValue);

            PlanGestionCtr.CodiActi = Convert.ToInt32(txtCodigo.Text);

            PlanGestionCtr.MesAvan = Type;
            PlanGestionCtr.Coment = _txtComentario;
            PlanGestionCtr.EstaComent = "A";

            sPlanEstrategico = PlanGestionController.SetComentarioAvance(PlanGestionCtr);

            return sPlanEstrategico;
        }

#endregion

    }
}
