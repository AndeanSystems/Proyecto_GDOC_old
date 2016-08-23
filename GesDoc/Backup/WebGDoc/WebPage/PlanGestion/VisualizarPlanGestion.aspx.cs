using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace WebGdoc.WebPage.PlanGestion
{
    public partial class VisualizarPlanGestion : WebGdoc.Resources.Utility
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VisualizarDocumento();
        }

        protected void VisualizarDocumento()
        {
            string sArchivo = Request.QueryString["PG"];
            string sFile = "../Digitalizacion/TmpVisor/";

            if (sArchivo != "")
            {
                VisualizarArchivoPlanGestion(sFile  + sArchivo + ".docx");
            }
        }
    }
}
