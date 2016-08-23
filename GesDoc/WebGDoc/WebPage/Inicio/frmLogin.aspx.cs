using System;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using WebGdoc.ServicesControllers;
//using WebGdoc.DigitalizacionServRef;
using WebGdoc.GestionServRef;
using WebGdoc.WebPage.Inicio;
using WebGdoc.WebPage.Controles;
using Entity.Entities;

namespace WebGdoc.WebPage.Inicio
{
    public partial class frmLogin : WebGdoc.Resources.Utility
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Remove("sURLActual");
                
                string sTextoPrincipal = "Sistema de Gestión Documentaria (G-Doc) |" + 
                                          "San Isidro,Lima |" + 
                                         " ";
                ReferenciarBanner(this, sTextoPrincipal, "Default");
                txtUsuario.Focus();
            }
        }

        protected void ValidarCredencialesUsuario()
        {
            if (txtUsuario.Text == "")
                MensajeAlerta(btnLogin, "Ingrese su Usuario.");
            else if (txtContrasena.Text == "")
                MensajeAlerta(btnLogin, "Ingrese su Contraseña.");
        }

        protected bool CargarCredencialesUsuario()
        {
            GestionController UsuarioPerController = new GestionController();
            eUsuario eUsuario = new eUsuario();
            eParticipante UsuarioPar = new eParticipante();
            IList<eUsuario> UsuPer = new List<eUsuario>();

            string sPass = string.Empty;
            string sNombre = string.Empty;
            string sAreaP = string.Empty;
            string sCargoP = string.Empty;
            Int64 sCodUsu;
            string sCodigo = string.Empty; // corregir Ronald

            
            eUsuario.Codigo = 0;
            eUsuario.IdeUsuario = txtUsuario.Text; //lgnLogin.UserName.ToString().ToUpper();

            UsuPer = GetListaUsuarioPer(eUsuario, false);

            if (UsuPer != null && UsuPer.Count > 0)
            {
                sPass = UsuPer[0].Pasword;
                sNombre = UsuPer[0].Pers.ApePers + ", " + UsuPer[0].Pers.NombPers;
                sAreaP = UsuPer[0].DescArea;
                sCargoP = UsuPer[0].DescCarg;
                sCodUsu = UsuPer[0].Codigo;

                if (txtContrasena.Text == sPass) // lgnLogin.Password == sPass)
                {
                    Session.Add("sUsuario", txtUsuario.Text); //lgnLogin.UserName);
                    Session.Add("sNombre", sNombre);
                    Session.Add("sCargo", sCargoP);
                    Session.Add("sArea", sAreaP);
                    Session.Add("sCodUsu", sCodUsu);
                    Session.Add("sCodigo", sCodigo);

                    EstadoUsuarioPer(3, UsuPer[0].Codigo, 0, string.Empty, string.Empty);

                    return true;
                }
                else
                {
                    MensajeAlerta(btnLogin, "La clave ingresada no es la correcta");

                    return false;
                }
            }
            else
            {
                MensajeAlerta(btnLogin, "El usuario ingresado es incorrecto.");
                return false;
            }
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtContrasena.Text == "")
                ValidarCredencialesUsuario();
            else
            {
                if (CargarCredencialesUsuario())
                {
                    CargarMenuPorUsuario();
                    
                    RedireccionarPage(btnLogin, ConfigurationManager.AppSettings.Get("PaginaInicial"));
                }
            }
           
        }

        protected void EstadoUsuarioPer(Int64 Type, Int64 CodUser, Int64 CodPer, string Pass, string FirElec)
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
        }
        
    }
}
