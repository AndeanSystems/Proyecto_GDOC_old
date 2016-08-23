using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebGdoc.WebPage.Digitalizacion
{
    public partial class frmVerArchivo : WebGdoc.Resources.Utility
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VisualizarDocumento();
        }

        protected void VisualizarDocumento()
        {
            try
            {
                string sArchivo = Request.QueryString["Archivo"];
                string sFile = "TMP";

                if (sArchivo != "")
                {
                    if (sArchivo.IndexOf('/') > -1)
                    {
                        sFile = sArchivo.Substring(0, sArchivo.IndexOf('/'));
                        sArchivo = sArchivo.Substring((sArchivo.IndexOf('/') + 1), ((sArchivo.Length - sArchivo.IndexOf('/')) - 1));
                    }
                    CopyArchivoFTP(sFile, sArchivo);

                    VisualizarArchivoPDF("TmpVisor", sFile, sArchivo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
