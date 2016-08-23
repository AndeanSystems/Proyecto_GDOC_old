
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
    public partial class frmLogOperaciones :  WebGdoc.Resources.Utility
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
                }

                CargarImagen();
            }
        }

        protected void CargarImagen()
        {
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
            ReferenciarTitulo(this, "Buscador de Log Doc");
            //ReferenciarLink(this, sLstLink);
        }

        protected void ValidarGridView()
        {
            VerificarGridView(gvwLogOper);
        }

        protected void ibtnBuscar_Click(object sender, ImageClickEventArgs e)
        {


            if (VerificarTipoDato(ddlTipoOper, "DropDownList") && VerificarTipoDato(txtBuscarLogDoc, "Len"))
            {

                this.ListaLogOperaciones();
                ValidarGridView();
            }
            else
                MensajeAlerta(ibtnBuscar, "Ingresar el codigo de operacion para realizar la busqueda");


        }

        protected void ListaLogOperaciones()
        {
            BusquedaController sBusquedaController = new BusquedaController();
            eBuscarLogOperacion CtrLogOperaciones = new eBuscarLogOperacion();
            IList<eBuscarLogOperacion> MensLogOper = new List<eBuscarLogOperacion>();
            CtrLogOperaciones.TipoBusq =Convert.ToInt32(this.ddlTipoOper.SelectedValue);
            CtrLogOperaciones.NumDocu = txtBuscarLogDoc.Text.Trim();
            MensLogOper = sBusquedaController.GetLogOper(CtrLogOperaciones);

            int[] sIndex = { 2 };
            CargarGridView(this.gvwLogOper, MensLogOper, sIndex);

            if (MensLogOper.Count <= 0)
                MensajeAlerta(ibtnBuscar, "Los parametros ingresados no retornaron resultados.");
        }
        
    }
}
