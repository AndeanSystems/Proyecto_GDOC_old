using System;
using System.Collections.Generic;
using System.Data;//
using System.Data.SqlClient;//
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
    public partial class frmDocumentosElectronicos : WebGdoc.Resources.Utility
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
                    CargarTipoDocumento();
                    txtFecFin.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtFecRegistro.Text = "01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
                }

                CargarImagen();
            }
        }

        protected void CargarImagen()
        {
            ibtnBuscar.ImageUrl = _UrlImagen + "img_Buscar_" + (ibtnBuscar.Enabled ? "A" : "I") + ".jpg";

            ibtnFecRegistro.ImageUrl = _UrlImagen + "img_Calendario_" + (ibtnFecRegistro.Enabled ? "A" : "I") + ".jpg";
            ibtnFecFin.ImageUrl = _UrlImagen + "img_Calendario_" + (ibtnFecFin.Enabled ? "A" : "I") + ".jpg";
        }

        protected void ConfigurarBarraHerramientas()
        {
            /*List<string> sLstLink = new List<string>();
            sLstLink.Add("WebPage/Gestion/frmDocumentoElectronico.aspx|Nuevo documento electrónico|u17_original.png");
            sLstLink.Add("WebPage/Busquedas/frmDocumentosElectronicos.aspx|Buscar documento electrónico|u21_original.png");
            sLstLink.Add("WebPage/Gestion/frmMesaVirtual.aspx|Organizar mesa de trabajo virtual|u25_original.jpg");
            sLstLink.Add("WebPage/Digitalizacion/frmDocumentosFisicos.aspx|Digitalización de documentos|u29_original.jpg");
            */
            ReferenciarTitulo(this, "Buscador Doc-D");
            //ReferenciarLink(this, sLstLink);
        }

        protected void ValidarGridView()
        {
            VerificarGridView(gvwDocE);
        }

        protected void CargarTipoDocumento()
        {
            DigitalizacionController TipoDocumentoController = new DigitalizacionController();
            eDocDigListTD TipoDocumentoCriteria = new eDocDigListTD();

            TipoDocumentoCriteria.EstTipoDocumento = "A";
            object sTipoDocumento = (object)TipoDocumentoController.GetTipoDocumDigital(TipoDocumentoCriteria);

            CargarDropDownList(ddlTipoArch, sTipoDocumento, "NombTipoDocu", "CodiTipoDocu");
        }

        protected void ibtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            //MensajeAlerta(ibtnBuscar, "No se encontro registros en los rangos seleccionados ");

            if (rdnRangoFecha.SelectedValue.Equals("S") && VerificarTipoDato(txtFecRegistro, "Date") && VerificarTipoDato(txtFecFin, "Date"))
                this.ListaDocumentosElectronicos();
            else if (rdnRangoFecha.SelectedValue.Equals("N"))
                this.ListaDocumentosElectronicos();
            else
                MensajeAlerta(ibtnBuscar, "Los datos ingresados no son correctos o estan incompletos");
        }

        protected void ibtnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            MensajeAlerta(ibtnBuscar, "Ingrese Nuevos rangos de Busqueda");
        }

        protected void ListaDocumentosElectronicos()
        {
            BusquedaController sBusquedaController = new BusquedaController();
            eBuscarDocumentos CtrDocumentoElectronico = new eBuscarDocumentos();
            IList<eBuscarDocumentos> MensDocumentoElectronico = new List<eBuscarDocumentos>();

            CtrDocumentoElectronico.sDocElect = new eDocumentoElectronico
            {
                AsunDocuElec = txtBuscarDocE.Text,
                CodiTipoDocu = ddlTipoArch.SelectedValue.Trim(),
                FechEmi = rdnRangoFecha.SelectedValue.Equals("S") ? Convert.ToDateTime(txtFecRegistro.Text) : (DateTime?)null
            };

            CtrDocumentoElectronico.FecReg2 = rdnRangoFecha.SelectedValue.Equals("S") ? Convert.ToDateTime(txtFecFin.Text) : (DateTime?)null;
            CtrDocumentoElectronico.CodiUsuRem = CapturarUsuario(ctlUserRemitente);
            CtrDocumentoElectronico.CodiUsuDes = CapturarUsuario(ctlUserParticipante);
            CtrDocumentoElectronico.TipoBusq = Convert.ToInt32(ddlTipoBusq.SelectedValue.ToString());

            MensDocumentoElectronico = sBusquedaController.GetDocumentosElectronicos(CtrDocumentoElectronico);
            CargarGrigViewSubClase(gvwDocE, MensDocumentoElectronico);

            if (MensDocumentoElectronico.Count <= 0)
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
            IList<eDocumentoElectronico> sLstDocElect = new List<eDocumentoElectronico>();
            sBusqueda = (IList<eBuscarDocumentos>)sDataTable;


            if (sBusqueda.Count > 0)
            {
                for (int i = 0; i < sBusqueda.Count; i++)
                {
                    sLstDocElect.Add(sBusqueda[i].sDocElect);
                }
            }
            int[] sColumn = { };
            CargarGridView(sGridView, sLstDocElect, sColumn);
        }

        protected void gvwDocE_SelectedIndexChanged(object sender, EventArgs e)
        {


            int sRows = gvwDocE.SelectedIndex;
            string sNumDocu;
            //lblNumOper.Text = gvwDocE.Rows[sRows].Cells[3].Text;
            sNumDocu = gvwDocE.DataKeys[sRows].Value.ToString();

            if (gvwDocE.SelectedIndex > -1)
            {
                if (ValidaAccesoDocumento(0, sNumDocu, Convert.ToInt64(Session["sCodUsu"].ToString())))
                {
                    MensajeAlerta(gvwDocE, "El Documento a buscar es de caracter Privado. Ud no es usuario participante del documento");
                    return;
                }
                string sPageInicio = "../Gestion/frmDocumentoElectronico.aspx?NumOper=" + sNumDocu.Trim();
                RedireccionarPage(gvwDocE, sPageInicio);
            }


        }

        protected void gvwDocE_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                String sNumDocu = e.Row.Cells[1].Text;

                HyperLink link = (HyperLink)e.Row.Cells[3].FindControl("lnktransfer");
                Label lblRuta = (Label)e.Row.Cells[2].FindControl("lblRutaFisica");
                //string[] sRutaFisica = lblRuta.Text.Split('/');
                String sDirectorio = lblRuta.Text;

                String sExtension = ".pdf";
                link.NavigateUrl = "../Digitalizacion/frmVerArchivo.aspx?Archivo=" + sDirectorio + "/" + sNumDocu.Trim() + sExtension;
                link.Target = "_blank";
            }
        }

        protected void rdnRangoFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdnRangoFecha.SelectedValue.Equals("N"))
            {
                txtFecRegistro.Text = String.Empty;
                txtFecFin.Text = String.Empty;

                txtFecRegistro.Enabled = false;
                ibtnFecRegistro.Enabled = false;

                txtFecFin.Enabled = false;                
                ibtnFecFin.Enabled = false;
            }
            else
            {
                txtFecFin.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtFecRegistro.Text = "01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();

                txtFecRegistro.Enabled = true;             
                ibtnFecRegistro.Enabled = true;

                txtFecFin.Enabled = true;               
                ibtnFecFin.Enabled = true;
            }
        }
    }
}
