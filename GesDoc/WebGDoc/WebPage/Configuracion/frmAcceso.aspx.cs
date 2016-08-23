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
using System.IO;
using Entity.Entities;

namespace WebGdoc.WebPage.Configuracion
{
    public partial class frmAcceso : WebGdoc.Resources.Utility

    {
        string sPageLocal = "../Configuracion/frmAcceso.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (VerificarSessionUsuario(tbPrincipal))
            {
                if (!IsPostBack)
                {
                    Session.Remove("sURLActual");
                    Session.Add("sURLActual", Request.Url.ToString());

                    ConfigurarBarraHerramientas();

                    CargarListaPaginas();
                }

                VerificarUsuarioSeleccionado();

                CargarImagen();
            }
        }

        protected void CargarImagen()
        {
            ibtnGuardar.ImageUrl = _UrlImagen + "img_Guardar_" + (ibtnGuardar.Enabled ? "A" : "I") + ".jpg";
            ibtnRegresar.ImageUrl = _UrlImagen + "img_Inicio_" + (ibtnRegresar.Enabled ? "A" : "I") + ".jpg";
        }

        protected void ConfigurarBarraHerramientas()
        {
            /*List<string> sLstLink = new List<string>();
            sLstLink.Add("WebPage/Gestion/frmDocumentoElectronico.aspx|Nuevo documento electrónico|u17_original.png");
            sLstLink.Add("WebPage/Busquedas/frmDocumentosElectronicos.aspx|Buscar documento electrónico|u21_original.png");
            sLstLink.Add("WebPage/Gestion/frmMesaVirtual.aspx|Organizar mesa de trabajo virtual|u25_original.jpg");
            sLstLink.Add("WebPage/Digitalizacion/frmDocumentosFisicos.aspx|Digitalización de documentos|u29_original.jpg");
*/
            ReferenciarTitulo(this, "Acceso Pagina");
            //ReferenciarLink(this, sLstLink);
        }

        protected void ibtnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            GestionController GesController = new GestionController();
            eAccesoSistema CtrAcceso = new eAccesoSistema();
            IList<eAccesoSistema> Acceso = new List<eAccesoSistema>();

            Int64 CodUsu = 0;
            Int64 CodPag = 0;

            if (ValidaCriterioInsert())
            {
                CtrAcceso.Usuario = new eUsuario 
                {
                    Codigo = Convert.ToInt64(ReturnUsuarioSeleccionadoCodigo()) 
                };

                CtrAcceso.Pagina = new eModuloPagina { Codigo = 0 };

                Acceso = GesController.GetAccesoSistema(CtrAcceso);

                AnulaAccesoUsuario(ReturnUsuarioSeleccionadoCodigo(), 0);

                for (int i = 0; i < this.gvwAcceso.Rows.Count; i++)
                {
                    CheckBox scbxhabilitar = (CheckBox)this.gvwAcceso.Rows[i].Cells[3].FindControl("ckbHabilita");

                    if (scbxhabilitar.Checked == true)
                    {
                        bool Verifica = false;
                        Int64 CodAcce = 0;

                        CodUsu = ReturnUsuarioSeleccionadoCodigo();
                        CodPag = Convert.ToInt64(this.gvwAcceso.DataKeys[i].Value.ToString());

                        for (int x = 0; x < Acceso.Count; x++)
                        {
                            if (Acceso[x].Pagina.Codigo == CodPag)
                            {
                                CodAcce = Acceso[x].Codigo;
                                Verifica = true;
                                break;
                            }
                        }

                        if (Verifica)
                            MantenimientoAccesoPersonaPagina(CodUsu, CodPag, CodAcce);
                        else
                            MantenimientoAccesoPersonaPagina(CodUsu, CodPag, 0);
                    }
                }

                MensajeAlerta(ibtnGuardar, "Se asignaron i/o retirarón los permisos al usuario: " + ReturnUsuarioSeleccionadoText(), sPageLocal);
                
            }
            else
                MensajeAlerta(ibtnGuardar, "Seleccione un usuario");

        }

        protected void CargarListaPaginas()
        {
            GestionController GesController = new GestionController();
            eModuloPagina CtrModPag = new eModuloPagina();
            IList<eModuloPagina> ModPag = new List<eModuloPagina>();

            CtrModPag.Estado = string.Empty;
            ModPag = GesController.GetModuloPagina(CtrModPag);

            
            using (DataTable TempGvw = new DataTable())
            {
                DataRow TemDr;

                TempGvw.Columns.Add("sPagina");
                TempGvw.Columns.Add("sDireccionUrl");
                TempGvw.Columns.Add("sCodigo");

                for (int i = 0; i < ModPag.Count; i++)
                {
                    TemDr = TempGvw.NewRow();
                    TemDr[0] = ModPag[i].Nombre;
                    TemDr[1] = ModPag[i].DireccionURL;
                    TemDr[2] = ModPag[i].Codigo;
                    TempGvw.Rows.Add(TemDr);
                }

                int[] sIndex = { 2 };
                CargarGridView(gvwAcceso, TempGvw, sIndex);
            }
        }

        protected void CargarPermisoUsuarioPagina(Int64 CodUsu, Int64 CodPag)
        {
            GestionController GesController = new GestionController();
            eAccesoSistema CtrAcceso = new eAccesoSistema();
            IList<eAccesoSistema> Acceso = new List<eAccesoSistema>();

            CtrAcceso.Usuario = new eUsuario { Codigo = CodUsu };
            CtrAcceso.Pagina = new eModuloPagina { Codigo = CodPag };

            Acceso = GesController.GetAccesoSistema(CtrAcceso);


            for (int i = 0; i < this.gvwAcceso.Rows.Count; i++)
            {
                CheckBox scbxhabilitar = (CheckBox)this.gvwAcceso.Rows[i].Cells[3].FindControl("ckbHabilita");

                if (Acceso.Count == 0)
                    scbxhabilitar.Checked = false;

                for (int x = 0; x < Acceso.Count; x++)
                {
                    if (this.gvwAcceso.DataKeys[i].Value.ToString() == Acceso[x].Pagina.Codigo.ToString() &&
                        Acceso[x].Estado == "A")
                    {
                        scbxhabilitar.Checked = true;
                        break;
                    }
                }
            }

        }

        protected Int64 ReturnUsuarioSeleccionadoCodigo()
        {
            Int64 sCodUsuario = 0;                    //Se obtendra del control usuario

            GridView sUserSelect = ctlUser.UsuarioSelect;
            for (int i = 0; i < sUserSelect.Rows.Count; i++)
            {
                sCodUsuario = Convert.ToInt64(sUserSelect.Rows[i].Cells[0].Text);
            }

            return sCodUsuario;
        }

        protected string ReturnUsuarioSeleccionadoText()
        {
            string sUsuarioText = string.Empty;                    //Se obtendra del control usuario

            GridView sUserSelect = ctlUser.UsuarioSelect;
            for (int i = 0; i < sUserSelect.Rows.Count; i++)
            {
                sUsuarioText = sUserSelect.Rows[i].Cells[1].Text;
            }

            return sUsuarioText;
        }

        protected void CargarMenuPorUsuarioSeleccionado()
        {
            GrillaCheck(false);

            Int64 sCodUsuario = 0;                    //Se obtendra del control usuario

            GridView sUserSelect = ctlUser.UsuarioSelect;
            for (int i = 0; i < sUserSelect.Rows.Count; i++)
            {
                sCodUsuario = Convert.ToInt64(sUserSelect.Rows[i].Cells[0].Text);
            }

            CargarPermisoUsuarioPagina(sCodUsuario, 0);
        }

        protected void MantenimientoAccesoPersonaPagina(Int64 CodUsu, Int64 Pagina,Int64 Codigo)
        {
            GestionController GesController = new GestionController();
            eAccesoSistema CtrAcceso = new eAccesoSistema();
            Int64 oReturn = 0;

            CtrAcceso.Codigo = Codigo;
            CtrAcceso.UsuarioCreacion = new eUsuario { Codigo = Convert.ToInt64(Session["sCodUsu"].ToString()) };
            CtrAcceso.FechaModificacion = System.DateTime.Now;
            CtrAcceso.Estado = "A";
            CtrAcceso.Usuario = new eUsuario { Codigo = CodUsu };
            CtrAcceso.Pagina = new eModuloPagina { Codigo = Pagina };

            oReturn = GesController.SetAccesoSistema(CtrAcceso);
        }

        protected void AnulaAccesoUsuario(Int64 CodUsu, Int64 CodPag)
        {
            GestionController GesController = new GestionController();
            eAccesoSistema CtrAcceso = new eAccesoSistema();
            Int64 oReturn = 0;

            CtrAcceso.Usuario = new eUsuario { Codigo = CodUsu };
            CtrAcceso.Pagina = new eModuloPagina { Codigo = CodPag };

            oReturn = GesController.SetAnulaAcceso(CtrAcceso);
        }

        protected bool ValidaCriterioInsert()
        {
            bool sValidar = true;

            if (sValidar)
                sValidar = VerificarTipoDato(ctlUser, "Len");
            
            return sValidar;
        }

        protected void GrillaCheck(bool status)
        {
            for (int i = 0; i < this.gvwAcceso.Rows.Count; i++)
            {
                CheckBox scbxhabilitar = (CheckBox)this.gvwAcceso.Rows[i].Cells[3].FindControl("ckbHabilita");
                scbxhabilitar.Checked = status;
            }
        }

        protected void VerificarUsuarioSeleccionado()
        {
            if (ReturnUsuarioSeleccionadoCodigo() > 0)
            {
                if (UserSelect.Value == ReturnUsuarioSeleccionadoCodigo().ToString())
                {

                }
                else
                {
                    UserSelect.Value = ReturnUsuarioSeleccionadoCodigo().ToString();
                    CargarMenuPorUsuarioSeleccionado();
                }
            }
            
        }

        protected void ibtnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            string sPageInicio = "../Inicio/frmEscritorioVirtual.aspx";
            RedireccionarPage(tbPrincipal, sPageInicio);
        }
       
    }
}
