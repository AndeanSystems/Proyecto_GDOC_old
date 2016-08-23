using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGdoc.GestionServRef;
using WebGdoc.BusquedaServRef;
using WebGdoc.WebPage.Controles;
using WebGdoc.ServicesControllers;
using Entity.Entities;

namespace WebGdoc.WebPage.Configuracion
{
    public partial class frmEmpresa : WebGdoc.Resources.Utility

    {
        string UserCrea = "ANDSYS";
        string sPageLoad = "../Configuracion/frmEmpresa.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (VerificarSessionUsuario(tbPrincipal))
            {
                if (!IsPostBack)
                {
                    Session.Remove("sURLActual");
                    Session.Add("sURLActual", Request.Url.ToString());

                    ConfigurarBarraHerramientas();
                    this.txtRUC.Attributes.Add("OnKeyPress", "return AcceptNum(event)");
                    CargarDepartamento();
                    CargarProvincia(Convert.ToInt32(this.ddlDpto.SelectedValue.ToString()));
                    enable_control(false);
                }

                CargarImagen();
            }
        }

        protected void CargarImagen()
        {
            ibtnNuevo.ImageUrl = _UrlImagen + "img_Nuevo_" + (ibtnNuevo.Enabled ? "A" : "I") + ".jpg";
            ibtnGuardar.ImageUrl = _UrlImagen + "img_Guardar_" + (ibtnGuardar.Enabled ? "A" : "I") + ".jpg";
            ibtnEliminar.ImageUrl = _UrlImagen + "img_Eliminar_" + (ibtnEliminar.Enabled ? "A" : "I") + ".jpg";
            ibtnRegresar.ImageUrl = _UrlImagen + "img_Inicio_" + (ibtnRegresar.Enabled ? "A" : "I") + ".jpg";

            ibtnBuscar.ImageUrl = _UrlImagen + "img_Buscar_" + (ibtnBuscar.Enabled ? "A" : "I") + ".jpg";
        }

        protected void ConfigurarBarraHerramientas()
        {
            /*List<string> sLstLink = new List<string>();
            sLstLink.Add("WebPage/Gestion/frmDocumentoElectronico.aspx|Nuevo documento electrónico|u17_original.png");
            sLstLink.Add("WebPage/Busquedas/frmDocumentosElectronicos.aspx|Buscar documento electrónico|u21_original.png");
            sLstLink.Add("WebPage/Gestion/frmMesaVirtual.aspx|Organizar mesa de trabajo virtual|u25_original.jpg");
            sLstLink.Add("WebPage/Digitalizacion/frmDocumentosFisicos.aspx|Digitalización de documentos|u29_original.jpg");
*/
            ReferenciarTitulo(this, "Empresa");
            //ReferenciarLink(this, sLstLink);
        }
        
        protected void ibtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            if (txtRUC.Text != "")
            {
                ListaEmpresa(Convert.ToInt64(txtRUC.Text));
                enable_control(true);
                txtRUC.Enabled = false;
            }
            else
                MensajeAlerta(ibtnBuscar, "Ingrese el RUC a buscar");
           
           
        }

        protected void ibtnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            lblCodRuc.Text = "";
            txtRUC.Text = "";
            txtDireccion.Text = "";
            txtRazon.Text = "";
            txtRUC.Enabled = true;
            enable_control(true);


        }

        protected Int64 Mantenimiento_Empresa(string Type, string Estado)
        {
            Int64 sEmpresa = 0;

            GestionController EmpresaController = new GestionController();
            eEmpresa EmpresaCtr = new eEmpresa();
            EmpresaCtr.Type = Type;
            EmpresaCtr.RucEmpr = Convert.ToInt64(txtRUC.Text.Trim());
            EmpresaCtr.RazoSoci = txtRazon.Text;
            EmpresaCtr.DireEmpr = txtDireccion.Text;
            EmpresaCtr.CodiUbig = GeneraUbigeo();
            EmpresaCtr.FechRegi = System.DateTime.Now;
            EmpresaCtr.CodiUsu = Convert.ToInt64(Session["sCodUsu"].ToString());
            EmpresaCtr.EstEmpr = Estado;

            sEmpresa = EmpresaController.SetEmpresaAdd(EmpresaCtr);

            return sEmpresa;
        }

        protected void ibtnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            Int64 oReturn = 0;
            if (ValidarCamposObligatorios())
            {
                if (lblCodRuc.Text == "")
                {
                    oReturn = Mantenimiento_Empresa("1", "A");
                    if (oReturn > 0)
                    {
                        MensajeAlerta(ibtnGuardar, "La Empresa :" + txtRazon.Text + " fue registrada con exito");
                    }
                    else { MensajeAlerta(ibtnGuardar, "Error al realizar el registro"); }
                }
                else
                {
                    oReturn = Mantenimiento_Empresa("2", "A");
                    if (oReturn > 0)
                    {
                        MensajeAlerta(ibtnGuardar, "La Empresa :" + txtRazon.Text + " fue actualizada con exito");
                    }
                    else { MensajeAlerta(ibtnGuardar, "Error al realizar la actualización"); }
                }
            }
            else
                MensajeAlerta(ibtnGuardar, "Los datos ingresados no son correctos o estan incompletos");
        }

        protected void ibtnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            Int64 oReturn = 0;
            if (lblCodRuc.Text != "")
            {
                oReturn = Mantenimiento_Empresa("2", "N");
                if (oReturn > 0)
                {
                    MensajeAlerta(ibtnEliminar, "La Empresa :" + txtRazon.Text + " fue eliminada con exito");
                }
                else { MensajeAlerta(ibtnEliminar, "Error al realizar la eliminación de la empresa", sPageLoad); }
            }
        }

        protected void ListaEmpresa(Int64 Ruc)
        {
            GestionController GesController = new GestionController();
            eEmpresa CtrEmpr = new eEmpresa();
            IList<eEmpresa> EmprDTO = new List<eEmpresa>();

            CtrEmpr.RucEmpr = Ruc;
            EmprDTO = GesController.GetEmpresa(CtrEmpr);

            if (EmprDTO.Count > 0)
            {
                lblCodRuc.Text = EmprDTO[0].RucEmpr.ToString();
                txtRazon.Text = EmprDTO[0].RazoSoci;
                txtDireccion.Text = EmprDTO[0].DireEmpr;
                //txtCodUbi.Text = EmprDTO[0].CodiUbig;
                ListaUbigeo(EmprDTO[0].CodiUbig);
            }
            else
                MensajeAlerta(ibtnBuscar, "No se encontro el RUC : " + txtRUC.Text);
        }

        protected void enable_control(bool status)
        {
            //txtRUC.Enabled = status;
            txtRazon.Enabled = status;
            txtDireccion.Enabled = status;
            ddlDistrito.Enabled = status;
            ddlDpto.Enabled = status;
            ddlProv.Enabled = status;

        }

        protected void CargarDepartamento()
        {
            BusquedaController BusController = new BusquedaController();
            eUbigeo CtrUbig = new eUbigeo();
            IList<eUbigeo> UbigDTO = new List<eUbigeo>();

            CtrUbig.TipoCod = "TIPDTO";
            CtrUbig.Cod_Dpto = 0;
            CtrUbig.Cod_Prov = 0;
            UbigDTO = BusController.GetUbigeo(CtrUbig);

            CargarDropDownList(ddlDpto, UbigDTO, "Descripcion", "CodUbi");

        }
        protected void CargarProvincia(int Cod_Dpto)
        {
            BusquedaController BusController = new BusquedaController();
            eUbigeo CtrUbig = new eUbigeo();
            IList<eUbigeo> UbigDTO = new List<eUbigeo>();

            CtrUbig.TipoCod = "TIPPROV";
            CtrUbig.Cod_Dpto = Cod_Dpto;
            CtrUbig.Cod_Prov = 0;
            UbigDTO = BusController.GetUbigeo(CtrUbig);

            CargarDropDownList(ddlProv, UbigDTO, "Descripcion", "CodUbi");

        }
        protected void CargarDistrito(int Cod_Dpto,int Cod_Prov)
        {
            BusquedaController BusController = new BusquedaController();
            eUbigeo CtrUbig = new eUbigeo();
            IList<eUbigeo> UbigDTO = new List<eUbigeo>();

            CtrUbig.TipoCod = "TIPDIST";
            CtrUbig.Cod_Dpto = Cod_Dpto;
            CtrUbig.Cod_Prov = Cod_Prov;
            UbigDTO = BusController.GetUbigeo(CtrUbig);

            CargarDropDownList(ddlDistrito, UbigDTO, "Descripcion", "CodUbi");

        }

        protected void ddlDpto_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarProvincia(Convert.ToInt32(this.ddlDpto.SelectedValue.ToString()));
            CargarDistrito(Convert.ToInt32(this.ddlDpto.SelectedValue.ToString()), Convert.ToInt32(this.ddlProv.SelectedValue.ToString()));
        }

        protected void ddlProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDistrito(Convert.ToInt32(ddlDpto.SelectedValue.ToString()), Convert.ToInt32(this.ddlProv.SelectedValue.ToString()));
        }

        protected string GeneraUbigeo()
        {
            string CodDpto = string.Empty;
            string CodProv = string.Empty;
            string CodDist = string.Empty;
            string Ubigeo = string.Empty;

            if (ddlDpto.SelectedValue.Length > 1)
                CodDpto = ddlDpto.SelectedValue.ToString();
            else
                CodDpto = "0" + ddlDpto.SelectedValue.ToString();

            if (ddlProv.SelectedValue.Length > 1)
                CodProv = ddlProv.SelectedValue.ToString();
            else
                CodProv = "0" + ddlProv.SelectedValue.ToString();

            if (ddlDistrito.SelectedValue.Length > 1)
                CodDist = ddlDistrito.SelectedValue.ToString();
            else
                CodDist = "0" + ddlDistrito.SelectedValue.ToString();

            Ubigeo = CodDpto + CodProv + CodDist;
            
            return Ubigeo;
        }

        protected void ListaUbigeo(string Ubigeo)
        {
            if (Ubigeo.Substring(0, 2).Substring(0, 1) != "0")
                ddlDpto.SelectedValue = Ubigeo.Substring(0, 2);
            else
                ddlDpto.SelectedValue = Ubigeo.Substring(0, 2).Substring(1, 1);

            CargarProvincia(Convert.ToInt32(ddlDpto.SelectedValue.ToString()));

            if (Ubigeo.Substring(2, 2).Substring(0, 1) != "0")
                ddlProv.SelectedValue = Ubigeo.Substring(2, 2);
            else
                ddlProv.SelectedValue = Ubigeo.Substring(2, 2).Substring(1, 1);

            CargarDistrito(Convert.ToInt32(ddlDpto.SelectedValue.ToString()), Convert.ToInt32(ddlProv.SelectedValue.ToString()));

            if (Ubigeo.Substring(4, 2).Substring(0, 1) != "0")
                ddlDistrito.SelectedValue = Ubigeo.Substring(4, 2);
            else
                ddlDistrito.SelectedValue = Ubigeo.Substring(4, 2).Substring(1, 1);
        }


        protected bool ValidarCamposObligatorios()
        {
            bool sValidar = true;

            if (sValidar)
                sValidar = VerificarTipoDato(txtRUC, "Len");

            if (sValidar)
                sValidar = VerificarTipoDato(txtDireccion, "Len");

            if (sValidar)
                sValidar = VerificarTipoDato(txtRazon, "Len");
            
            if (sValidar)
                sValidar = VerificarTipoDato(ddlProv, "Len");
            
            if (sValidar)
                sValidar = VerificarTipoDato(ddlDistrito, "Len");
            return sValidar;
        }

        protected void ibtnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            string sPageInicio = "../Inicio/frmEscritorioVirtual.aspx";
            RedireccionarPage(tbPrincipal, sPageInicio);
        }
    }
}
