using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGdoc.WebPage.Controles;
//using WebGdoc.WebPage.Inicio;
using WebGdoc.BusquedaServRef;
//using WebGdoc.GestionServRef;
using WebGdoc.ServicesControllers;
using Entity.Entities;

namespace WebGdoc.WebPage.Busquedas
{
    public partial class frmMesaVirtual : WebGdoc.Resources.Utility
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (VerificarSessionUsuario(tbPrincipal))
            {
                if (!IsPostBack)
                {
                    Session.Remove("sURLActual");
                    Session.Add("sURLActual", Request.Url.ToString());


                    ConfigurarBarraHerramientas();
                    
                    txtFecFin.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtFecRegistro.Text = "01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
                }

                CargarImagen();
            }
        }

        protected void CargarImagen()
        {
            ibtnBuscar.ImageUrl = _UrlImagen + "img_Buscar_" + (ibtnBuscar.Enabled ? "A" : "I") + ".jpg";

            ibtnFecEmision.ImageUrl = _UrlImagen + "img_Calendario_" + (ibtnFecEmision.Enabled ? "A" : "I") + ".jpg";
            ibtnFecFin.ImageUrl = _UrlImagen + "img_Calendario_" + (ibtnFecFin.Enabled ? "A" : "I") + ".jpg";
        }

        protected void ConfigurarBarraHerramientas()
        {
            /*List<string> sLstLink = new List<string>();
            sLstLink.Add("WebPage/Gestion/frmDocumentoElectronico.aspx|Nuevo documento electrónico|u17_original.png");
            sLstLink.Add("WebPage/Busquedas/frmDocumentosElectronicos.aspx|Buscar documento electrónico|u21_original.png");
            sLstLink.Add("WebPage/Gestion/frmMesaVirtual.aspx|Organizar mesa de trabajo virtual|u25_original.jpg");
            sLstLink.Add("WebPage/Digitalizacion/frmDocumentosFisicos.aspx|Digitalización de documentos|u29_original.jpg");*/

            ReferenciarTitulo(this, "Buscador Mesa-V");
            //ReferenciarLink(this, sLstLink);
        }

        protected void ValidarGridView()
        {
            VerificarGridView(gvwMesaVir);
        }

        protected void CargarTipoDocumento()
        {
            DigitalizacionController TipoDocumentoController = new DigitalizacionController();
            eDocDigListTD TipoDocumentoCriteria = new eDocDigListTD();

            TipoDocumentoCriteria.EstTipoDocumento = "";
            object sTipoDocumento = (object)TipoDocumentoController.GetTipoDocumDigital(TipoDocumentoCriteria);

            CargarDropDownList(ddlTipoBusq, sTipoDocumento, "NombTipoDocu", "CodiTipoDocu");
        }

        protected void ibtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            //MensajeAlerta(ibtnBuscar, "No se encontro registros en los rangos seleccionados ");
            ListaMesaVirtual();

        }

        protected void ibtnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            MensajeAlerta(ibtnBuscar, "Ingrese Nuevos rangos de Busqueda");
        }

        protected void ListaMesaVirtual()
        {
            BusquedaController sBusquedaController = new BusquedaController();
            eBuscarDocumentos CtrMesaVirtual = new eBuscarDocumentos();
            IList<eBuscarDocumentos> MensMesaVirtual = new List<eBuscarDocumentos>();

            CtrMesaVirtual.sMesaVirtual = new eMesaVirtual 
            {
                Asunto  = txtBuscarDocE.Text,
                CodiOper = Convert.ToInt32(ddlTipoBusq.SelectedValue.Trim()),                
                Fecha = rdnRangoFecha.SelectedValue.Equals("S") ? Convert.ToDateTime(txtFecRegistro.Text) : (DateTime?)null,
            };
                        
            CtrMesaVirtual.FecReg2 = rdnRangoFecha.SelectedValue.Equals("S") ? Convert.ToDateTime(txtFecFin.Text) : (DateTime?)null;
            CtrMesaVirtual.CodiUsuRem = CapturarUsuario(ctlUserRemitente);
            CtrMesaVirtual.CodiUsuDes = CapturarUsuario(ctlUserParticipante);
            CtrMesaVirtual.TipoBusq = Convert.ToInt32(ddlTipoBusq.SelectedValue.ToString());

            MensMesaVirtual = sBusquedaController.GetMesaVirtual(CtrMesaVirtual);

            CargarGrigViewSubClase(gvwMesaVir, MensMesaVirtual);

            if (MensMesaVirtual.Count <= 0)
                MensajeAlerta(ibtnBuscar, "Los parametros ingresados no retornaron resultados.");
        }

        protected Int64 CapturarUsuario(ValidarUsuario_Grupo sControlUser)
        {
            Int64 sCodUsuario = 0;
            GridView sUserSelect = sControlUser.UsuarioSelect;

            if (sUserSelect.Rows.Count > 0)
            {
                if (sUserSelect.Rows[0].Cells[0].Text != "&nbsp;")
                {
                    for (int i = 0; i < sUserSelect.Rows.Count; i++)
                    {
                        sCodUsuario = Convert.ToInt64(sUserSelect.Rows[i].Cells[0].Text);
                    }
                }
            }
            return sCodUsuario;
        }

        protected void CargarGrigViewSubClase(GridView sGridView, object sDataTable)
        {
            IList<eBuscarDocumentos> sBusqueda = new List<eBuscarDocumentos>();
            IList<eMesaVirtual> sLstMesaVirtual = new List<eMesaVirtual>();
            sBusqueda = (IList<eBuscarDocumentos>)sDataTable;

            if (sBusqueda.Count > 0)
            {
                for (int i = 0; i < sBusqueda.Count; i++)
                {
                    sLstMesaVirtual.Add(sBusqueda[i].sMesaVirtual);
                }
            }
            CargarGridView(sGridView, sLstMesaVirtual);
        }

        protected void gvwMesaVir_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sRows = gvwMesaVir.SelectedIndex;
            string sNumDocu;
            //lblNumOper.Text = gvwDocE.Rows[sRows].Cells[3].Text;
            sNumDocu = gvwMesaVir.DataKeys[sRows].Value.ToString();
            if (gvwMesaVir.SelectedIndex > -1)
            {
                if (ValidaAccesoDocumento(0, sNumDocu, Convert.ToInt64(Session["sCodUsu"].ToString())))
                {
                    MensajeAlerta(gvwMesaVir, "El Documento a buscar es de caracter Privado. Ud no es usuario participante del documento");
                    return;
                }
                string sPageInicio = "../Gestion/frmMesaVirtual.aspx?NumOper=" + sNumDocu.Trim();
                RedireccionarPage(gvwMesaVir, sPageInicio);
            }
        }

        protected void rdnRangoFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdnRangoFecha.SelectedValue.Equals("N"))
            {
                txtFecRegistro.Text = String.Empty;
                txtFecFin.Text = String.Empty;

                txtFecRegistro.Enabled = false;
                ibtnFecEmision.Enabled = false;

                txtFecFin.Enabled = false;
                ibtnFecFin.Enabled = false;
            }
            else
            {
                txtFecFin.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtFecRegistro.Text = "01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();

                txtFecRegistro.Enabled = true;
                ibtnFecEmision.Enabled = true;

                txtFecFin.Enabled = true;
                ibtnFecFin.Enabled = true;
            }
        }
    }
}
