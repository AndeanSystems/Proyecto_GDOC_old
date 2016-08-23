using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGdoc.DigitalizacionServRef;
//using WebGdoc.GestionServRef;
using WebGdoc.ServicesControllers;
using System.Data;
using System.Data.SqlClient;
using Entity.Entities;

namespace WebGdoc.WebPage.Inicio
{
    public partial class frmEscritorioVirtual : WebGdoc.Resources.Utility
    {
        //DataTable TempGvw = new DataTable();
        //DataRow TemDr;
        //Int64 sUsuario;
        //string sSession;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (VerificarSessionUsuario(tbPrincipal))
            {
                if (!IsPostBack)
                {
                    Session.Remove("sURLActual");
                    Session.Add("sURLActual", Request.Url.ToString());

                    ConfigurarBarraHerramientas();
                    InicializarCarga();
                }

                CargarImagen();
            }
        }

#region Iniciar Page : Cargar configuraciones


        protected void CargarImagen()
        {
            ibtnActualizar.ImageUrl = _UrlImagen + "img_Actualizar_" + (ibtnActualizar.Enabled ? "A" : "I") + ".jpg";
            ibtBuscar.ImageUrl = _UrlImagen + "img_Buscar_Documento_" + (ibtBuscar.Enabled ? "A" : "I") + ".jpg";
        }

        protected void InicializarCarga()
        {
            CargarListaAlertas();

            CargarListaDocumentos();

            CargarListaMesaVirtual();

            Buscar_alerta(this.txtBuscarAll.Text);

            CantidadReg(); 
        }

        protected void ConfigurarBarraHerramientas()
        {
            /*
            List<string> sLstLink = new List<string>();
            sLstLink.Add("WebPage/Gestion/frmDocumentoElectronico.aspx|Nuevo documento electrónico|u17_original.png");
            sLstLink.Add("WebPage/Busquedas/frmDocumentosElectronicos.aspx|Buscar documento electrónico|u21_original.png");
            sLstLink.Add("WebPage/Gestion/frmMesaVirtual.aspx|Organizar mesa de trabajo virtual|u25_original.jpg");
            sLstLink.Add("WebPage/Digitalizacion/frmDocumentosFisicos.aspx|Digitalización de documentos|u29_original.jpg");
            */
            ReferenciarTitulo(this, "Escritorio Virtual");
            /*ReferenciarLink(this, sLstLink);*/
        }

        protected void CargarListaAlertas()
        {
            using (DataTable TempGvw = new DataTable())
            {
                DigitalizacionController MensajeController = new DigitalizacionController();
                eMensajeAlerta CtrMensaje = new eMensajeAlerta();
                IList<eMensajeAlerta> MensAlrt = new List<eMensajeAlerta>();
                
                string sSession = string.Empty;
                DataRow TemDr;

                sSession = Session["sCodUsu"].ToString();

                CtrMensaje.EstMensAler = "A";
                CtrMensaje.CodiOper = 0;
                CtrMensaje.CodiUsu = Convert.ToInt64(sSession);
                CtrMensaje.FechAler = DateTime.Now;
                CtrMensaje.FechAler2 = System.DateTime.Now;

                MensAlrt = MensajeController.GetMensajAlerta(CtrMensaje);

                TempGvw.Columns.Add("sHora");
                TempGvw.Columns.Add("sMensaje");
                TempGvw.Columns.Add("sCodiOper");
                TempGvw.Columns.Add("sTipoOper");

                for (int i = 0; i < MensAlrt.Count; i++)
                {
                    TemDr = TempGvw.NewRow();
                    TemDr[0] = MensAlrt[i].FechAler.ToShortTimeString();
                    TemDr[1] = MensAlrt[i].DescEven;
                    TemDr[2] = MensAlrt[i].CodiOper;
                    TemDr[3] = MensAlrt[i].TipoOper;
                    TempGvw.Rows.Add(TemDr);
                }
                
                CargarGridView(gvwAlertasRec, TempGvw);
            }
        }

        protected void CargarListaDocumentos()
        {
            using (DataTable TempGvw = new DataTable())
            {
                GestionController OperDes = new GestionController();
                eOperaciones OperCrit = new eOperaciones();
                IList<eOperaciones> Oper = new List<eOperaciones>();
                eUsuario eUsuario = new eUsuario();
                IList<eUsuario> UsuPer = new List<eUsuario>();

                string sSession = string.Empty;
                DataRow TemDr;
                DateTime Hora = System.DateTime.Now;

                sSession = Session["sCodUsu"].ToString();
                OperCrit.Type = 3;
                OperCrit.CodUsu = Convert.ToInt64(sSession);
                OperCrit.Fecha = System.DateTime.Now;

                Oper = OperDes.GetListaOper(OperCrit);

                TempGvw.Columns.Add("sCodDoc");
                TempGvw.Columns.Add("sHora");
                TempGvw.Columns.Add("sAutor");
                TempGvw.Columns.Add("sTipo");
                TempGvw.Columns.Add("sAsunto");

                for (int i = 0; i < Oper.Count; i++)
                {
                    Hora = Oper[i].Fecha;
                    TemDr = TempGvw.NewRow();
                    TemDr[0] = Oper[i].NumOper;
                    TemDr[1] = Hora.ToShortTimeString();

                    eUsuario.Codigo = Oper[i].CodUsu;
                    eUsuario.IdeUsuario = string.Empty;

                    UsuPer = GetListaUsuarioPer(eUsuario, true);

                    if (UsuPer.Count > 0)
                        TemDr[2] = UsuPer[0].IdeUsuario;
                    
                    TemDr[3] = Oper[i].TipoOper;
                    TemDr[4] = Oper[i].Asunto;

                    TempGvw.Rows.Add(TemDr);
                }
                int[] Oculto = { 3 };
                CargarGridView(gvwDocumentos, TempGvw, Oculto);
            }
        }

        protected void CargarListaMesaVirtual()
        {
            using (DataTable TempGvw = new DataTable())
            {
                GestionController GMesVirController = new GestionController();
                eUsuario eUsuario = new eUsuario();

                DigitalizacionController MesVirController = new DigitalizacionController();
                eMesaVirtual MesVirCtr = new eMesaVirtual();

                IList<eMesaVirtual> MesaVir = new List<eMesaVirtual>();
                eParticipante UserCtr = new eParticipante();
                IList<eParticipante> User = new List<eParticipante>();
                IList<eUsuario> UsuPer = new List<eUsuario>();

                string sSession = string.Empty;
                DataRow TemDr;
                Int64 sUsuario = 0;

                sSession = Session["sCodUsu"].ToString();

                MesVirCtr.CodiUsu = Convert.ToInt64(sSession);
                MesVirCtr.CodiOper = 0;
                MesVirCtr.NumOper = "";
                MesaVir = MesVirController.GetMesaVirtual(MesVirCtr);

                TempGvw.Columns.Add("sMesaVirtual");
                TempGvw.Columns.Add("sFecOrganizacion");
                TempGvw.Columns.Add("sOrganizador");
                TempGvw.Columns.Add("sAsunto");
                TempGvw.Columns.Add("sSituacion");

                for (int i = 0; i < MesaVir.Count; i++)
                {
                    TemDr = TempGvw.NewRow();
                    TemDr[0] = MesaVir[i].NumOper;
                    TemDr[1] = MesaVir[i].Fecha.Value.ToShortDateString();
                    UserCtr.CodiOper = MesaVir[i].CodiOper;
                    UserCtr.CodiUsu = 0;

                    User = GMesVirController.GetUserPart(UserCtr);

                    if (User.Count > 0)
                    {
                        for (int o = 0; o < User.Count; o++)
                        {
                            if (User[o].TipoPart == 4)
                                sUsuario = User[o].CodiUsu;
                        }
                    }

                    eUsuario.Codigo = sUsuario;
                    eUsuario.IdeUsuario = string.Empty;
                    UsuPer = GetListaUsuarioPer(eUsuario, true);

                    if (UsuPer.Count > 0)
                        TemDr[2] = UsuPer[0].IdeUsuario;

                   // TemDr[3] = MesaVir[i].NumOper + " " + MesaVir[i].Asunto;
                    TemDr[3] = MesaVir[i].Asunto;
                    TemDr[4] = MesaVir[i].Estado;
                    TempGvw.Rows.Add(TemDr);
                }

                CargarGridView(gvwMesaVirtual, TempGvw);
            }
        }

        protected void CantidadReg()
        {
            this.pnlAlertas.GroupingText = "Alertas recibidas: " + this.gvwAlertasRec.Rows.Count.ToString() + " registros";
            this.pnlDocRec.GroupingText = "Mesas de Trabajo Virtual: Activas " + this.gvwMesaVirtual.Rows.Count.ToString() + " registros";
            this.pnlBusqueda.GroupingText = "Buscar Mis Documentos: " + this.gvwBusquedaAlertas.Rows.Count.ToString() + " registros";
            this.pnlMesasV.GroupingText = "Documentos Recibidos: " + this.gvwDocumentos.Rows.Count.ToString() + " registros";
        }

        protected void Buscar_alerta(string sTexto)
        {
            using (DataTable TempGvw = new DataTable())
            {
                GestionController DescController = new GestionController();
                eVariable DescCriteria = new eVariable();
                IList<eVariable> Desc = new List<eVariable>();

                string sSession = string.Empty;
                DataRow TemDr;

                TempGvw.Columns.Add("sNumDoc");
                TempGvw.Columns.Add("sAsunto");
                TempGvw.Columns.Add("sCodigo");

                if (sTexto.Length > 0)
                {
                    lblCodDoc.Text = "";
                    sSession = Session["sCodUsu"].ToString();
                    DescCriteria.Descrip = sTexto;
                    DescCriteria.CodUsu = Convert.ToInt64(sSession);

                    Desc = DescController.GetListaDesc(DescCriteria);
                    if (Desc.Count > 0)
                    {
                        for (int i = 0; i < Desc.Count; i++)
                        {
                            TemDr = TempGvw.NewRow();
                            TemDr[0] = Desc[i].Numdoc;
                            TemDr[1] = Desc[i].Descrip;
                            TemDr[2] = Desc[i].Codigo;

                            TempGvw.Rows.Add(TemDr);
                        }
                    }
                    else
                        MensajeAlerta(ibtBuscar, "No se encontro el documento ingresado");
                }

                CargarGridView(gvwBusquedaAlertas, TempGvw);
            }
        }

#endregion

        protected void txtBuscarAll_TextChanged(object sender, EventArgs e)
        {
            Buscar_alerta(this.txtBuscarAll.Text);
        }

        protected void ibtBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Buscar_alerta(this.txtBuscarAll.Text);
            this.pnlBusqueda.GroupingText = "Buscar Mis Documentos: " + this.gvwBusquedaAlertas.Rows.Count.ToString() + " registros";
        }

        protected void ibtnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            if (VerificarSessionUsuario(tbPrincipal))
            {
                InicializarCarga();
            }
        }

        protected void gvwBusquedaAlertas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sPageInicio = string.Empty;
            string sCodigo = string.Empty;
            string sNumOper = string.Empty;
            int sRows = gvwBusquedaAlertas.SelectedIndex;


            if (sRows > -1)
            {
                sCodigo = gvwBusquedaAlertas.DataKeys[sRows].Value.ToString();
                sNumOper = gvwBusquedaAlertas.Rows[sRows].Cells[0].Text;
            }
                        
            if (sCodigo != "")
            {
                if (sCodigo.Substring(0, 1).ToString() == "1")
                {
                    if (ReturnUsuaPart(Convert.ToInt64(sCodigo)) > 1)
                        sPageInicio = "../Digitalizacion/frmDocumentosFisicos.aspx?NumOper=" + sNumOper;
                    else
                        sPageInicio = "../Digitalizacion/frmArchivoDatos.aspx?NumOper=" + sNumOper;
                }
                else if (sCodigo.Substring(0, 1).ToString() == "2")
                    sPageInicio = "../Gestion/frmDocumentoElectronico.aspx?NumOper=" + sNumOper;

                if(sPageInicio != "")
                    RedireccionarPage(tbPrincipal, sPageInicio);

            }
        }

        protected void gvwDocumentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sRows = gvwDocumentos.SelectedIndex;
            string sPageInicio = string.Empty;
            string NumOper = string.Empty;

            if (sRows > -1)
                NumOper = gvwDocumentos.DataKeys[sRows].Value.ToString();


            if (NumOper.Length > 2)
            {
                if (NumOper.Substring(0, 2).ToString() == "DE")
                    sPageInicio = "../Gestion/frmDocumentoElectronico.aspx?NumOper=" + NumOper.Trim();
                else if (NumOper.Substring(0, 2).ToString() == "DD")
                        sPageInicio = "../Digitalizacion/frmDocumentosFisicos.aspx?NumOper=" + NumOper.Trim();

                if (sPageInicio != "")
                    RedireccionarPage(gvwDocumentos, sPageInicio);
            }
        }

        protected void gvwMesaVirtual_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sRows = gvwMesaVirtual.SelectedIndex;
            string sPageInicio = string.Empty;
            string NumOper = string.Empty;
            
            if (sRows > -1)
                NumOper = gvwMesaVirtual.DataKeys[sRows].Value.ToString();

            if (NumOper != "")
                sPageInicio = "../Gestion/frmMesaVirtual.aspx?NumOper=" + NumOper.Trim();

            if (sPageInicio != "")
                RedireccionarPage(gvwMesaVirtual, sPageInicio);
        }

        protected void gvwAlertasRec_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sRows = gvwAlertasRec.SelectedIndex;
            string sPageInicio = string.Empty;
            string sCodiOper = string.Empty;
            string sTipoOper = string.Empty;

            if (sRows > -1)
            {
                sCodiOper = gvwAlertasRec.DataKeys[sRows].Values["sCodiOper"].ToString();
                sTipoOper = gvwAlertasRec.DataKeys[sRows].Values["sTipoOper"].ToString();
            }

            if (sTipoOper.Trim() == "MV")
                sPageInicio = "../Gestion/frmMesaVirtual.aspx?CodOper=" + sCodiOper.Trim();
            else if (sTipoOper.Trim() == "DE")
                sPageInicio = "../Gestion/frmDocumentoElectronico.aspx?CodOper=" + sCodiOper.Trim();
            else if (sTipoOper.Trim() == "DD")
                sPageInicio = "../Digitalizacion/frmDocumentosFisicos.aspx?CodOper=" + sCodiOper.Trim();

            if (sPageInicio != "")
                RedireccionarPage(gvwAlertasRec, sPageInicio);
        }

        protected Int64 ReturnUsuaPart(Int64 CodDoc)
        {
            GestionController GestCon = new GestionController();
            eParticipante CtrUser = new eParticipante();
            IList<eParticipante> UserPart = new List<eParticipante>();
            Int64 oReturn = 0;

            CtrUser.CodiOper = CodDoc;
            CtrUser.CodiUsu = 0;
            UserPart = GestCon.GetUserPart(CtrUser);

            if (UserPart.Count > 0)
            {
                oReturn = UserPart.Count;
            }

            return oReturn;
        }
    }
}