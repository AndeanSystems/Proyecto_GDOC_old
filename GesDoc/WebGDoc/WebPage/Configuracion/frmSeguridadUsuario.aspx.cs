using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.WebPage.Configuracion
{
    public partial class frmSeguridadUsuario : WebSite.Resources.Utility

    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (VerificarSessionUsuario(tbPrincipal))
            {
                if (!IsPostBack)
                {
                    ConfigurarBarraHerramientas();
                    ValidarGridView();
                }

                CargarImagen();
            }
        }

        protected void CargarImagen()
        {
            ibtnNuevo.ImageUrl = _UrlImagen + "img_Nuevo_" + (ibtnNuevo.Enabled ? "A" : "I") + ".jpg";
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
            ReferenciarTitulo(this, "Usuarios");
            //ReferenciarLink(this, sLstLink);
        }

        protected void ValidarGridView()
        {
            VerificarGridView(gvwSeguridadUsuarios);

        }
        

        protected void ibtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            MensajeAlerta(ibtnBuscar, "No se encontro registros en los rangos seleccionados ");
        }

        protected void ibtnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            MensajeAlerta(ibtnBuscar, "Ingrese Nuevos rangos de Busqueda");
        }
    }
}
