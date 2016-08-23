using System;
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
using System.Collections;
using Microsoft.VisualBasic;
using Entity.Entities;



namespace WebGdoc.WebPage.Configuracion
{
    public partial class frmUsuarios : WebGdoc.Resources.Utility
    {

#region Variables

        string sTipOperacion = "DD";
        DataTable TempGvw = new DataTable();
        DataRow TemDr;
        string sTipoEvento;
        bool sInd;
        string UserCrea = "ANDSYS";

#endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (VerificarSessionUsuario(tbPrincipal))
            {
                if (!IsPostBack)
                {
                    Session.Remove("sURLActual");
                    Session.Add("sURLActual", Request.Url.ToString());

                    txtIdUser.Focus();

                    ConfigurarBarraHerramientas();
                    //ValidarGridView();
                    this.txtNroDoc.Attributes.Add("OnKeyPress", "return AcceptNum(event)");
                    this.txtCelular.Attributes.Add("OnKeyPress", "return AcceptNum(event)");
                    this.txtTelef.Attributes.Add("OnKeyPress", "return AcceptNum(event)");
                    enabled_control(false);
                    CargarEmpresa();
                    CargarArea();
                    CargarCargo();
                    CargarTipoUsuario();
                    txtFecNac.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + (DateTime.Now.Year - 31);
                    ibtnEditar.Enabled = false;
                    ibtnEliminar.Enabled = false;
                    ibtnGuardar.Enabled = false;
                }

                CargarImagen();
            }
        }

        protected void CargarImagen()
        {
            ibtnNuevo.ImageUrl = _UrlImagen + "img_Nuevo_" + (ibtnNuevo.Enabled ? "A" : "I") + ".jpg";
            ibtnEditar.ImageUrl = _UrlImagen + "img_Editar_" + (ibtnEditar.Enabled ? "A" : "I") + ".jpg";
            ibtnGuardar.ImageUrl = _UrlImagen + "img_Guardar_" + (ibtnGuardar.Enabled ? "A" : "I") + ".jpg";
            ibtnEliminar.ImageUrl = _UrlImagen + "img_Eliminar_" + (ibtnEliminar.Enabled ? "A" : "I") + ".jpg";
            ibtnRegresar.ImageUrl = _UrlImagen + "img_Inicio_" + (ibtnRegresar.Enabled ? "A" : "I") + ".jpg";

            ibtnBuscar.ImageUrl = _UrlImagen + "img_Buscar_" + (ibtnBuscar.Enabled ? "A" : "I") + ".jpg";

            ibtnFecNac.ImageUrl = _UrlImagen + "img_Calendario_" + (ibtnFecNac.Enabled ? "A" : "I") + ".jpg";
        }

        protected void ConfigurarBarraHerramientas()
        {
            /*List<string> sLstLink = new List<string>();
            sLstLink.Add("WebPage/Gestion/frmDocumentoElectronico.aspx|Nuevo documento electrónico|u17_original.png");
            sLstLink.Add("WebPage/Busquedas/frmDocumentosElectronicos.aspx|Buscar documento electrónico|u21_original.png");
            sLstLink.Add("WebPage/Gestion/frmMesaVirtual.aspx|Organizar mesa de trabajo virtual|u25_original.jpg");
            sLstLink.Add("WebPage/Digitalizacion/frmDocumentosFisicos.aspx|Digitalización de documentos|u29_original.jpg");
*/
            ReferenciarTitulo(this, "Digitalización de Documentos");
            //ReferenciarLink(this, sLstLink);
        }

        protected void ValidarGridView()
        {
            //VerificarGridView();

        }


        protected void LogOperacion(string sCodOper,string UserDes)
        {
            DigitalizacionController LogOperacionController = new DigitalizacionController();
            eLogOperacion eLogOperacion = new eLogOperacion();

            eLogOperacion.CodiLogOper = 0;
            eLogOperacion.FechEven = System.DateTime.Now;
            eLogOperacion.TipoOper = sTipOperacion;
            eLogOperacion.CodiOper = sCodOper;
            eLogOperacion.CodiEven = sTipoEvento;
            eLogOperacion.CodiUsu = Convert.ToInt64(UserDes);
            eLogOperacion.CodiCnx = 0;

            LogOperacionController.SetLogOperacion(eLogOperacion);

        }

        protected void ibtnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            string sPageInicio = "../Configuracion/frmUsuarios.aspx";
            if (ValidarCamposObligatorios())
            {
                if (lblCodPer.Text == "")
                {
                    if (ValidaIdUsuario(txtIdUser.Text))
                    {
                        Mantenimiento_Personal(0);
                        MensajeAlerta(ibtnGuardar, "El Usuario  " + txtIdUser.Text.ToUpper() + " fue registrado con exito", sPageInicio);
                    }
                }
                else
                {
                    Mantenimiento_Personal(Convert.ToInt64(lblCodPer.Text));
                    MensajeAlerta(ibtnGuardar, "El Usuario  " + txtIdUser.Text.ToUpper() + " fue Modificado con exito", sPageInicio);
                }
            }
            else
                MensajeAlerta(ibtnGuardar, "Los datos ingresados no son correctos o estan incompletos");
            
        }

        protected void enabled_control(bool status)
        {
            txtNroDoc.Enabled = status;
            txtFecNac.Enabled = status;
            txtNom.Enabled = status;
            ddlRuc.Enabled = status;
            txtTelef.Enabled = status;
            txtTerminal.Enabled = status;
            txtAnx.Enabled = status;
            txtApell.Enabled = status;
            txtDirecc.Enabled = status;
            txtEmailLab.Enabled = status;
            txtEmailPer.Enabled = status;
            txtCelular.Enabled = status;
            ddlArea.Enabled = status;
            ddlCargo.Enabled = status;
            ddlClaseUser.Enabled = status;
            ddlTipUser.Enabled = status;
            rdnSexo.Enabled = status;
            ibtnEliminar.Enabled = status;
            ibtnGuardar.Enabled = status;
        }
    
        protected void ibtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            if (txtIdUser.Text != "")
            {
                ListaUsuario(0, txtIdUser.Text, string.Empty, string.Empty);
                ibtnEliminar.Enabled = true;
                ibtnGuardar.Enabled = true;
                ibtnEditar.Enabled = true;
            }
        }      


        protected void ibtnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            if (lblCodUser.Text != "" && lblCodPer.Text != "")
            {
                EstadoUsuarioPer(0, Convert.ToInt64(lblCodUser.Text), Convert.ToInt64(lblCodPer.Text), string.Empty, string.Empty);
                MensajeAlerta(ibtnEliminar, "El Usuario :" + txtIdUser.Text.Trim() + "fue eliminado");
            }
        }

        protected void ibtnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            LimpiarControl();
            enabled_control(true);
            lblCodPer.Text = string.Empty;
            lblCodUser.Text = string.Empty;
            txtFecNac.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + (DateTime.Now.Year - 31);
            ibtnEliminar.Enabled = false;
            ibtnGuardar.Enabled = true;
        }

        protected void ibtnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            string sPageInicio = "../Inicio/frmEscritorioVirtual.aspx";
            RedireccionarPage(tbPrincipal, sPageInicio);
        }


        protected void Mantenimiento_Personal(Int64 CodiPers)
        {
            GestionController GController = new GestionController();
            ePersonal CtrPer = new ePersonal();
            Int64 oReturn = 0;

            CtrPer.CodigoPersona = CodiPers;
            CtrPer.NombPers = txtNom.Text;
            CtrPer.ApePers = txtApell.Text;
            CtrPer.SexoPers = rdnSexo.SelectedValue.ToString();
            CtrPer.EmaiPers = txtEmailPer.Text;
            CtrPer.EmaiTrab = txtEmailLab.Text;
            CtrPer.FechNac = Convert.ToDateTime(txtFecNac.Text);
            CtrPer.TelePers = txtTelef.Text;
            CtrPer.AnexPers = txtAnx.Text;
            CtrPer.CeluPers = txtCelular.Text;
            CtrPer.EstaPers = "A";
            CtrPer.CodiTipUsu = Convert.ToInt64(ddlTipUser.SelectedValue.ToString());
            CtrPer.CodiArea = Convert.ToInt64(ddlArea.SelectedValue.ToString());
            CtrPer.CodiCarg = Convert.ToInt64(ddlCargo.SelectedValue.ToString());
            CtrPer.ClasPers = ddlClaseUser.SelectedValue;
            CtrPer.RucEmpr = Convert.ToInt64(ddlRuc.SelectedValue.ToString());
            CtrPer.DNI = txtNroDoc.Text;
            CtrPer.DirePers = txtDirecc.Text;

            oReturn = GController.SetAddPersonal(CtrPer);
            lblCodPer.Text = CtrPer.CodigoPersona.ToString();
            if (CodiPers == 0)
                Mantenimiento_Usuario(CtrPer.CodigoPersona,0);
            else 
                Mantenimiento_Usuario(CtrPer.CodigoPersona,Convert.ToInt64(lblCodUser.Text));

        }

        protected void Mantenimiento_Usuario(Int64 CodiPers,Int64 CodiUser)
        {
            GestionController GController = new GestionController();
            eUsuario CtrUser = new eUsuario();
            Int64 oReturn = 0;

            CtrUser.Codigo = CodiUser;
            CtrUser.IdeUsuario = txtIdUser.Text;
            CtrUser.Pasword = "none";
            CtrUser.FirmaElectronica = "none";
            CtrUser.Estado = "A";
            CtrUser.FechaRegistro = System.DateTime.Now;
            CtrUser.FechaUltimoAcceso = System.DateTime.Now;
            CtrUser.FechaModificacion = System.DateTime.Now;
            CtrUser.IntentoErradoPasword = 3;
            CtrUser.IntentoErradoFirma = 2;
            CtrUser.TermUsu = txtTerminal.Text;
            CtrUser.UsuCrea = UserCrea;
            CtrUser.CodiCnx = "";
            CtrUser.CodigoPersona = CodiPers;
            CtrUser.CodiRol = "EMI";
            CtrUser.CodiTipUsu = Convert.ToInt64(ddlTipUser.SelectedValue.ToString());
            CtrUser.ClasUsu = ddlClaseUser.SelectedValue;
            CtrUser.ExpiClav = string.Empty;
            CtrUser.ExpiFirm = string.Empty;
            CtrUser.FechExpiClav = Convert.ToDateTime(DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + (DateTime.Now.Year + 1));
            CtrUser.FechExpiFirm = Convert.ToDateTime(DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + (DateTime.Now.Year + 1));
            
            oReturn = GController.SetAddUsuario(CtrUser);
        }

        protected void CargarEmpresa()
        {
            GestionController GesController = new GestionController();
            eEmpresa CtrEmpr = new eEmpresa();
            IList<eEmpresa> EmprDTO = new List<eEmpresa>();

            CtrEmpr.RucEmpr = 0;
            CtrEmpr.RazoSoci = string.Empty;
            CtrEmpr.EstEmpr = "A";
            EmprDTO = GesController.GetEmpresa(CtrEmpr);

            CargarDropDownList(ddlRuc, EmprDTO, "EmprId", "RucEmpr");
            
        }

        protected void CargarArea()
        {
            GestionController GesController = new GestionController();
            eArea CtrArea = new eArea();
            IList<eArea> AreaDTO = new List<eArea>();

            CtrArea.EstaAre = "";
            AreaDTO = GesController.GetTipoArea(CtrArea);

            CargarDropDownList(ddlArea, AreaDTO, "DescAre", "CodiAre");

        }

        protected void CargarCargo()
        {
            GestionController GesController = new GestionController();
            eTipoCargo CtrCargo = new eTipoCargo();
            IList<eTipoCargo> CargoDTO = new List<eTipoCargo>();

            CtrCargo.EstCargo = "";
            CargoDTO = GesController.GetTipoCargo(CtrCargo);

            CargarDropDownList(ddlCargo, CargoDTO, "DescCarg", "CodiCarg");

        }

        protected void CargarTipoUsuario()
        {
            GestionController GesController = new GestionController();
            eTipoUsuario CtrUser = new eTipoUsuario();
            IList<eTipoUsuario> UserDTO = new List<eTipoUsuario>();

            CtrUser.EstaTipUsu = "";
            UserDTO = GesController.GetTipoUsuario(CtrUser);

            CargarDropDownList(ddlTipUser, UserDTO, "DescTipUsu", "CodiTipUsu");

        }

        protected void ListaUsuario(Int64 Cod,string iduser,string nomuser,string Dni)
        {
            GestionController GController = new GestionController();
            eUsuario  CtrUser = new eUsuario();
            IList<eUsuario> User = new List<eUsuario>();

            CtrUser.Codigo = Cod;
            CtrUser.IdeUsuario = iduser;
            CtrUser.NombPers = nomuser;
            CtrUser.Pers = new ePersonal { DNI = Dni };

            User = GetListaUsuarioPer(CtrUser, false);
            if (User.Count > 0)
            {
                lblCodPer.Text = User[0].Pers.CodigoPersona.ToString();
                lblCodUser.Text = User[0].Codigo.ToString();
                txtNom.Text = User[0].Pers.NombPers;
                txtApell.Text = User[0].Pers.ApePers;
                rdnSexo.SelectedValue = User[0].Pers.SexoPers;
                ddlRuc.SelectedValue = User[0].Pers.RucEmpr.ToString();
                txtNroDoc.Text = User[0].Pers.DNI;
                txtFecNac.Text = User[0].Pers.FechNac.ToShortDateString();
                ddlTipUser.SelectedValue = User[0].Pers.CodiTipUsu.ToString();
                txtEmailPer.Text = User[0].Pers.EmaiPers;
                ddlCargo.SelectedValue = User[0].Pers.CodiCarg.ToString();
                ddlArea.SelectedValue = User[0].Pers.CodiArea.ToString();
                txtEmailLab.Text = User[0].Pers.EmaiTrab;
                txtDirecc.Text = User[0].Pers.DirePers;
                txtTerminal.Text = User[0].TermUsu;
                txtTelef.Text = User[0].Pers.TelePers;
                txtAnx.Text = User[0].Pers.AnexPers;
                txtCelular.Text = User[0].Pers.CeluPers;
                ddlClaseUser.SelectedValue = User[0].ClasUsu.ToString();

            }
            else
                MensajeAlerta(ibtnBuscar, "No se encontro datos para documento ingresado");
        }

        protected void EstadoUsuarioPer(Int64 Type,Int64 CodUser,Int64 CodPer,string Pass,string FirElec)
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

        protected void LimpiarControl()
        {
            LimpiarControles(txtAnx);
            LimpiarControles(txtApell);
            LimpiarControles(txtCelular);
            LimpiarControles(txtDirecc);
            LimpiarControles(txtEmailLab);
            LimpiarControles(txtEmailPer);
            LimpiarControles(txtFecNac);
            LimpiarControles(txtIdUser);
            LimpiarControles(txtNom);
            LimpiarControles(txtNroDoc);
            LimpiarControles(txtTelef);
            LimpiarControles(txtTerminal);
           /* LimpiarControles(ddlArea);
            LimpiarControles(ddlCargo);
            LimpiarControles(ddlRuc);
            LimpiarControles(ddlTipUser);*/

            ddlArea.SelectedIndex = 0;
            ddlCargo.SelectedIndex = 0;
            ddlRuc.SelectedIndex = 0;
            ddlTipUser.SelectedIndex = 0;
        }

        protected void ibtnEditar_Click(object sender, ImageClickEventArgs e)
        {
            enabled_control(true);
            txtNroDoc.Enabled = false;
            txtIdUser.Enabled = false;
        }

        protected bool ValidaIdUsuario(string iduser)
        {
            GestionController GController = new GestionController();
            eUsuario CtrUser = new eUsuario();
            IList<eUsuario> User = new List<eUsuario>();
            bool Verifica = true;

            CtrUser.Codigo = 0;
            CtrUser.IdeUsuario = iduser;
            User = GetListaUsuarioPer(CtrUser, false);
            if (User.Count > 0)
            {
                MensajeAlerta(ibtnGuardar, "El IdUsuario : " + iduser + " ya existe.");
                Verifica = false;
            }
            return Verifica;
        }

        //protected void txtNroDoc_TextChanged(object sender, EventArgs e)
        //{
        //    ListaUsuario(0, string.Empty, string.Empty, txtNroDoc.Text);
        //}

        protected bool ValidarCamposObligatorios()
        {
            bool sValidar = true;

            if (sValidar)
                sValidar = VerificarTipoDato(txtFecNac, "Date");

            if (sValidar)
                sValidar = VerificarTipoDato(rdnSexo, "String");

            if (sValidar)
                sValidar = VerificarTipoDato(txtApell, "Len");

            if (sValidar)
                sValidar = VerificarTipoDato(txtNom, "Len");

            if (sValidar)
                sValidar = VerificarTipoDato(txtIdUser, "Len");

            if (sValidar)
                sValidar = VerificarTipoDato(txtNroDoc, "Len");

            if (sValidar)
                sValidar = VerificarTipoDato(txtDirecc, "Len");

            if (sValidar)
                sValidar = VerificarTipoDato(txtTelef, "Len");

            if (sValidar)
                sValidar = VerificarTipoDato(txtCelular, "Len");
            return sValidar;
        }
    }
}
