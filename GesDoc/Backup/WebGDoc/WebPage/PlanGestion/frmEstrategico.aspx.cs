using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGdoc.PlanGestionServRef;
using WebGdoc.WebPage.Controles;
using WebGdoc.ServicesControllers;
using Entity.Entities;

namespace WebGdoc.WebPage.Configuracion
{
    public partial class frmEstrategico : WebGdoc.Resources.Utility
    {
        string UserCrea = "ANDSYS";
        string sPageLoad = "../PlanGestion/frmEstrategico.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (VerificarSessionUsuario(tbPrincipal))
            {
                if (!IsPostBack)
                {
                    Session.Remove("sURLActual");
                    Session.Add("sURLActual", Request.Url.ToString());

                    ConfigurarBarraHerramientas();

                    CargaPeriodo();
                    CargaObjetivoE(1, " -- Seleccione --");
                    CargaEstado();

                    ddlEstrategico.Visible = true;
                    txtDescipcion.Visible = false;
                    ConfigurarControles(false);

                    CargaObjetivoE(2, "");
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
            ReferenciarTitulo(this, "Objetivo Estrategico");
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

        protected void CargaObjetivoE(Int16 _TypeOperacion, String _Items)
        {
            PlanGestionController _PlanGestionController = new PlanGestionController();
            ePlanGestion _ePlanGestion = new ePlanGestion();
            IList<ePlanGestion> LstEstrategico = new List<ePlanGestion>();

            _ePlanGestion.TypeOperacion = _TypeOperacion;
            _ePlanGestion.PeriObjEstr = Convert.ToInt32(dllPeriodo.SelectedValue);
            if(ddlEstrategico.SelectedValue != "")
                _ePlanGestion.CodiObjEstr = Convert.ToInt32(ddlEstrategico.SelectedValue);

            LstEstrategico = _PlanGestionController.GetObetivoEstrategico(_ePlanGestion, _Items);

            if (_TypeOperacion == 1)
                CargarDropDownList(ddlEstrategico, LstEstrategico, "DescObjEstr", "CodiObjEstr");
            else if (_TypeOperacion == 2)
            {
                if (LstEstrategico.Count > 0)
                {
                    txtCodigo.Text = LstEstrategico[0].CodiObjEstr.ToString();
                    Session.Add("sCodiOE", txtCodigo);
                    txtDescipcion.Text = LstEstrategico[0].DescObjEstr.ToString();
                    txtAbrev.Text = LstEstrategico[0].AbreObjEstr.ToString();
                    dllEstado.SelectedValue = LstEstrategico[0].EstaObjEstr.ToString();
                }
                ibtnEditar.Enabled = true;
            }
        }

        protected void CargaEstado()
        {
            PlanGestionController _PlanGestionController = new PlanGestionController();
            ePlanGestion _ePlanGestion = new ePlanGestion();
            IList<ePlanGestion> LstEstado = new List<ePlanGestion>();
            ePlanGestion _Estado;

            _Estado = new ePlanGestion();
            _Estado.EstaObjEstr = "A";
            _Estado.Coment = "Activo";
            LstEstado.Add(_Estado);

            _Estado = new ePlanGestion();
            _Estado.EstaObjEstr = "I";
            _Estado.Coment = "Inactivo";
            LstEstado.Add(_Estado);

            _Estado = new ePlanGestion();
            _Estado.EstaObjEstr = "E";
            _Estado.Coment = "Eliminado";
            LstEstado.Add(_Estado);

            CargarDropDownList(dllEstado, LstEstado, "Coment", "EstaObjEstr");
        }

#endregion

#region Configuraciones

        protected void ConfigurarControles(bool status)
        {
            //txtCodigo.Enabled = false;

            txtDescipcion.Enabled = status;
            txtAbrev.Enabled = status;
            dllEstado.Enabled = status;
        }

        protected bool ValidarCamposObligatorios()
        {
            bool sValidar = true;

            //if (sValidar)
            //    sValidar = VerificarTipoDato(txtRUC, "Len");

            if (sValidar)
                sValidar = VerificarTipoDato(txtCodigo, "Len");

            if (sValidar)
                sValidar = VerificarTipoDato(txtDescipcion, "Len");

            return sValidar;
        }

        protected void LimpiarControles()
        {
            txtCodigo.Text = "";
            txtDescipcion.Text = "";
            txtAbrev.Text = "";
            dllEstado.SelectedValue = "A";
        }

#endregion

#region Botonera

        protected void ibtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            // MensajeAlerta(ibtnBuscar, "Ingrese el RUC a buscar");


        }

        protected void ibtnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            ddlEstrategico.Visible = false;
            txtDescipcion.Visible = true;
            botonera(this.ibtnNuevo);
            ConfigurarControles(true);
            LimpiarControles();
        }

        protected void ibtnEditar_Click(object sender, ImageClickEventArgs e)
        {
            ddlEstrategico.Visible = false;
            txtDescipcion.Visible = true;

            ibtnNuevo.Enabled = true;
            ibtnEditar.Enabled = false;
            ibtnGuardar.Enabled = true;
            ConfigurarControles(true);
        }

        protected void ibtnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            Int64 oReturn = 0;
            //String sCodiOE = Session["sCodiOE"].ToString();
            if (ValidarCamposObligatorios())
            {
                if (txtCodigo.Text.Length > 0)
                //    oReturn = Mantenimiento(1, "");
                //else
                {
                    if(Session["sCodiOE"] != null && Session["sCodiOE"].ToString()!="")
                    {
                        if (((TextBox)Session["sCodiOE"]).Text == txtCodigo.Text)
                        {
                            oReturn = Mantenimiento(2, "");
                        }
                        else
                        {
                            Mantenimiento(3, "E");
                            oReturn = Mantenimiento(1, "");
                        }
                    }
                    else
                        oReturn = Mantenimiento(1, "");
                    
                }

                if (oReturn > 0)
                {
                    MensajeAlerta(ibtnGuardar, "Los datos ingresados satisfactoriamente");

                    CargaObjetivoE(1, " -- Seleccione --");
                    
                    ddlEstrategico.Visible = true;
                    txtDescipcion.Visible = false;

                    LimpiarControles();
                    botonera(this.ibtnGuardar);
                    CargaObjetivoE(2, "");
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
            CargaObjetivoE(2, "");

            ibtnNuevo.Enabled = true;
            ibtnEditar.Enabled = true;
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

            if (Session["sCodiOE"] != null && Session["sCodiOE"].ToString() != "")
            {
                if (Type == 3)
                    PlanGestionCtr.CodiObjEstr = Convert.ToInt32(((TextBox)Session["sCodiOE"]).Text);
                else
                    PlanGestionCtr.CodiObjEstr = Convert.ToInt32(txtCodigo.Text);
            }
            else
                PlanGestionCtr.CodiObjEstr = Convert.ToInt32(txtCodigo.Text);

            PlanGestionCtr.DescObjEstr = txtDescipcion.Text;
            PlanGestionCtr.AbreObjEstr = txtAbrev.Text;
            if(Type!=3)
                PlanGestionCtr.EstaObjEstr = dllEstado.SelectedValue;
            else
                PlanGestionCtr.EstaObjEstr = Estado;

            sPlanEstrategico = PlanGestionController.SetObetivoEstrategico(PlanGestionCtr);

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

#endregion

    }
}
