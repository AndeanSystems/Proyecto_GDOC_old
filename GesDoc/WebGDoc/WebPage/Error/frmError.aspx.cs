using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebGdoc.WebPage.Error
{
    public partial class FrmError : WebGdoc.Resources.Utility
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sURLActual"] != null)
            {
                string sURLActual = Session["sURLActual"].ToString();

                if (sURLActual != null)
                {
                    if (sURLActual != "")
                    {
                        Response.Redirect(sURLActual + "?sError=0");
                    }
                }
            }
        }
    }
}
