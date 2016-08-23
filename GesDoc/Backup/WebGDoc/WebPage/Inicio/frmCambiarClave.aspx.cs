using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using WebGdoc.ServicesControllers;
using WebGdoc.DigitalizacionServRef;
using WebGdoc.GestionServRef;
using WebGdoc.WebPage.Inicio;
using WebGdoc.WebPage.Controles;
using Microsoft.VisualBasic;
using Entity.Entities;

namespace WebGdoc.WebPage.Inicio
{
    public partial class frmCambiarClave : WebGdoc.Resources.Utility
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (VerificarSessionUsuario(tbPrincipal))
            {
                if (!IsPostBack)
                {
                    Session.Remove("sURLActual");
                    Session.Add("sURLActual", Request.Url.ToString());

                    ListaUsuario();
                }
                CargarImagen();
            }
        }

        protected void CargarImagen()
        {
            ibtnGuardar.ImageUrl = _UrlImagen + "img_Guardar_" + (ibtnGuardar.Enabled ? "A" : "I") + ".jpg";
            ibtnRegresar.ImageUrl = _UrlImagen + "img_Inicio_" + (ibtnRegresar.Enabled ? "A" : "I") + ".jpg";
            imgCambioClave.Src = _UrlImagen + "img_Cambio_Clave_" + (ibtnRegresar.Enabled ? "A" : "I") + ".jpg";
        }

        protected void ibtnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            Int64 oReturn = 0;
            Int64 sUserSession = Convert.ToInt64(Session["sCodUsu"].ToString());
            string sPageInicio = "../Inicio/frmEscritorioVirtual.aspx";

            if (txtPassAct.Text != "")
            {
                if (txtPassAct.Text == lblPass.Text)
                {
                    if (valida_Pass())
                        oReturn = EstadoUsuarioPer(1, sUserSession, 0, txtNuevoPass.Text, string.Empty);
                }
                else
                    MensajeAlerta(ibtnGuardar, "La contraseña actual ingresa no coincide con la del sistema");

            }


            if (oReturn > 0)
                MensajeAlerta(ibtnGuardar, "Su Contraseña se actualizo con exito.", sPageInicio);

        }


        protected void ibtnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            string sPageInicio = "../Inicio/frmEscritorioVirtual.aspx";
            RedireccionarPage(tbPrincipal, sPageInicio);
        }

        protected Int64 EstadoUsuarioPer(Int64 Type, Int64 CodUser, Int64 CodPer, string Pass, string FirElec)
        {
            GestionController GController = new GestionController();
            eUsuario CtrUser = new eUsuario();
            Int64 oReturn = 0;

            CtrUser.CodiTipUsu = Type; //replazanto este parametro por un tipo Type
            CtrUser.Codigo = CodUser;
            CtrUser.CodigoPersona = CodPer;
            CtrUser.Pasword = Pass;
            CtrUser.FirmaElectronica = FirElec;

            oReturn = GController.SetUsuarioEstadp(CtrUser);
            return oReturn;
        }

        protected void ListaUsuario()
        {
            GestionController GController = new GestionController();
            eUsuario CtrUser = new eUsuario();
            IList<eUsuario> User = new List<eUsuario>();

            CtrUser.Codigo = Convert.ToInt64(Session["sCodUsu"].ToString());

            User = GetListaUsuarioPer(CtrUser, false);
            if (User.Count > 0)
            {
                lblPass.Text = User[0].Pasword;
                lblFirm.Text = User[0].FirmaElectronica;
            }
        }

        protected bool valida_Pass()
        {
            bool Veri = false;

            if (txtPassAct.Text != txtNuevoPass.Text)
            {
                if (txtNuevoPass.Text == "" || txtRepitePass.Text == "")
                {
                    MensajeAlerta(ibtnGuardar, "La contraseña no puede tener valores en blanco");
                }
                else
                {
                    if (txtNuevoPass.Text == txtRepitePass.Text)
                        Veri = true;
                    else
                        MensajeAlerta(ibtnGuardar, "La contraseña ingresada no coincide");
                }
            }
            else
                MensajeAlerta(ibtnGuardar, "La nueva contraseña no puede ser igual a la anterior");

            return Veri;
        }

    }
}
