using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebGdoc.WebPage.Controles
{
    public partial class BarraHerramientas : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string TituloPagina
        {
            get
            {
                return lblTituloPagina.Text;
            }
            set
            {
                lblTituloPagina.Text = value;
            }
        }

        public List<string> LinkPagina
        {
            set
            {
                if (value.Count > 0)
                {
                    string sControl = string.Empty;

                    for (int i = 0; i < value.Count; i++)
                    {
                        char sDelimitador = '|';
                        string[] sDato = value[i].ToString().Split(sDelimitador);

                        string sLtl = string.Empty;

                        //sLtl = "<a runat='server' id='aLink" + i + "' href='../../" + sDato[0].ToString() + "'>" +
                        //       "<img runat='server' id='imgLink" + i + "' src='../../Resources/Imagenes/" + sDato[2].ToString() + "' title='" + sDato[1].ToString() + "' class='LinkURL' />" +
                        //       "</a>";

                        sLtl = "<a runat='server' id='aLink" + i + "' OnClick='btnEnviar_Click'>" +
                               "<img runat='server' id='imgLink" + i + "' src='../../Resources/Imagenes/" + sDato[2].ToString() + "' title='" + sDato[1].ToString() + "' class='LinkURL' />" +
                               "</a>";
                        


                        sControl = sControl + sLtl + "&nbsp;";
                    }

                    ltrLink.Text = sControl;
                }
            }
        }
    }
}