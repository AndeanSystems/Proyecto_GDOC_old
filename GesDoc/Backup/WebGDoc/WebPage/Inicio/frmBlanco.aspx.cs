using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebGdoc.WebPage.Inicio
{
    public partial class frmBlanco : WebGdoc.Resources.Utility
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel pnlPrincipal = (Panel)this.Master.FindControl("pnlFondo1");

            if (pnlPrincipal != null)
                pnlPrincipal.CssClass = "FondoPrincipal";
        }
    }
}
