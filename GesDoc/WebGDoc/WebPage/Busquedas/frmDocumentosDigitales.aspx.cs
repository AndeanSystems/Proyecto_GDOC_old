using System;
using System.Collections.Generic;
using System.Data;//
using System.Data.SqlClient;//
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGdoc.WebPage.Controles;
using WebGdoc.BusquedaServRef;
using WebGdoc.ServicesControllers;
using System.IO;
using System.Configuration;
using Entity.Entities;

namespace WebGdoc.WebPage.Busquedas
{
    public partial class frmDocumentosDigitales : WebGdoc.Resources.Utility
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

            ibtnFecEmision.ImageUrl = _UrlImagen + "img_Calendario_" + (ibtnFecEmision.Enabled ? "A" : "I") + ".jpg";
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
            VerificarGridView(gvwDocD);
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
                this.ListaDocumentosDigitales();
            else if (rdnRangoFecha.SelectedValue.Equals("N"))
                this.ListaDocumentosDigitales();         
            else
                MensajeAlerta(ibtnBuscar, "Los datos ingresados no son correctos o estan incompletos");
        }

        protected void ibtnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            MensajeAlerta(ibtnBuscar, "Ingrese Nuevos rangos de Busqueda");
        }

        protected void ListaDocumentosDigitales()
        {
            BusquedaController sBusquedaController = new BusquedaController();
            eBuscarDocumentos CtrDocumentoDigital = new eBuscarDocumentos();
            IList<eBuscarDocumentos> MensDocumentodigital = new List<eBuscarDocumentos>();

            CtrDocumentoDigital.sDocDig = new eDocDig
            {
                AsunDocuDigi = txtBuscarDocE.Text,
                ClasDocu = ddlTipoArch.SelectedValue.Trim(),                
                FechRegi = rdnRangoFecha.SelectedValue.Equals("S") ? Convert.ToDateTime(txtFecRegistro.Text) : (DateTime?)null
            };
            
            CtrDocumentoDigital.FecReg2 = rdnRangoFecha.SelectedValue.Equals("S") ? Convert.ToDateTime(txtFecFin.Text) : (DateTime?)null;
            CtrDocumentoDigital.CodiUsuRem = CapturarUsuario(ctlUserRemitente);
            CtrDocumentoDigital.CodiUsuDes = CapturarUsuario(ctlUserParticipante);
            CtrDocumentoDigital.TipoBusq = Convert.ToInt32(ddlTipoBusq.SelectedValue.ToString());

            MensDocumentodigital = sBusquedaController.GetDocumentosDigitales(CtrDocumentoDigital);

            CargarGrigViewSubClase(gvwDocD, MensDocumentodigital);

            if (MensDocumentodigital.Count <= 0)
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
            IList<eDocDig> sLstDocDig = new List<eDocDig>();
            sBusqueda = (IList<eBuscarDocumentos>)sDataTable;

            if (sBusqueda.Count > 0)
            {
                for (int i = 0; i < sBusqueda.Count; i++)
                {
                    sLstDocDig.Add(sBusqueda[i].sDocDig);

                }
            }
            int[] var = { };
            CargarGridView(sGridView, sLstDocDig, var);
        }

        protected void gvwDocD_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sRows = gvwDocD.SelectedIndex;
            string sNumDocu;
            //lblNumOper.Text = gvwDocE.Rows[sRows].Cells[3].Text;
            sNumDocu = gvwDocD.DataKeys[sRows].Value.ToString();

            if (gvwDocD.SelectedIndex > -1)
            {
                if (ValidaAccesoDocumento(0, sNumDocu, Convert.ToInt64(Session["sCodUsu"].ToString())))
                {
                    MensajeAlerta(gvwDocD, "El Documento a buscar es de caracter Privado. Ud no es usuario participante del documento");
                    return;
                }
                string sPageInicio = "../Digitalizacion/frmDocumentosFisicos.aspx?NumOper=" + sNumDocu.Trim();
                RedireccionarPage(gvwDocD, sPageInicio);
            }

        }

        protected void gvwDocD_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvwDocD_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                String sNumDocu = e.Row.Cells[1].Text;

                HyperLink link = (HyperLink)e.Row.Cells[1].FindControl("lnktransfer");
                Label lblRuta = (Label)e.Row.Cells[1].FindControl("lblRutaFisica");
                string[] sRutaFisica = lblRuta.Text.Split('/');
                String sDirectorio = sRutaFisica[0];

                String sExtension = Path.GetExtension(lblRuta.Text);
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
