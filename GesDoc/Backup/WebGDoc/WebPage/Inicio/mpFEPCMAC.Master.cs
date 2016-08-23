using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGdoc.Resources;

namespace WebGdoc.WebPage.Inicio
{
    public partial class mpFEPCMAC : System.Web.UI.MasterPage
    {
        protected Utility sUtility = new Utility();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sUsuario"] != null && Session["sUsuario"].ToString() != "")
            {
                CargarMenuXML();
                CargarAutenticacion();
                tbBanner.Visible = true;
            }
            
        }

        protected void CargarMenuXML()
        {
            //string sURLMenuUser = Server.MapPath("~/Resources/Menu/MenuFEPCMAC.xml");

            string sURLMenu = Server.MapPath("~/Resources/Menu");
            string sURLMenuUser = System.IO.Path.Combine(sURLMenu, Session["sUsuario"] + ".xml");

            axmMenu.DataSource = sURLMenuUser;
            axmMenu.DataBind();
        }

        protected void CargarAutenticacion()
        {
            /*string sTextoPrincipal = "Sanchez, Juan Antonio |" +
                                     "Jefe de Administracción & Finanzas |" +
                                     "Oficina Principal";*/
            string sTextoPrincipal = Session["sNombre"] + "|" +
                                     Session["sCargo"] + "|" +
                                     Session["sArea"];
            sUtility.ReferenciarBanner(this.Page, sTextoPrincipal, "Personal");
        }
    }
}
