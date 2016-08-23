using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using WebGdoc.ServicesControllers;
using WebGdoc.BusquedaServRef;
using WebGdoc.WebPage.Inicio;
using WebGdoc.WebPage.Controles;
using Entity.Entities;
using WebGdoc.Resources;

namespace WebGdoc.WebPage.Gestion
{
    public partial class frmBandejaES : WebGdoc.Resources.Utility
    {

        string sSession;
        DataTable TempGvw = new DataTable();
        DataRow TemDr;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (VerificarSessionUsuario(tbPrincipal))
            {
                if (!IsPostBack)
                {
                    Session.Remove("sURLActual");
                    Session.Add("sURLActual", Request.Url.ToString());

                    ConfigurarBarraHerramientas();
                    CargarTipoPrioridad();
                    CargarTipoParticipante();
                    CargarTipoDocumento();
                    ValidarGridView();
                    ddlOpcionES.SelectedIndex = 1;
                    ddlClase.SelectedIndex = 1;
                    ddlPrioridad.SelectedIndex = 1;
                    Load_Bandeja(1);
                    CargaTipoMV();
                    
                    TabContainer2.ActiveTabIndex = 0;
                    CargaGrillaMV(0);
                }

                CargarImagen();
            }
        }

        protected void CargarImagen()
        {
            ibtnBuscar.ImageUrl = _UrlImagen + "img_Buscar_" + (ibtnBuscar.Enabled ? "A" : "I") + ".jpg";
        }

        protected void ConfigurarBarraHerramientas()
        { 
            ReferenciarTitulo(this, "Bandeja de Entrada y Salida");            
        }

        protected void ValidarGridView()
        {
            VerificarGridView(gvwDocE);
            VerificarGridView(gvwMesaV);
        }

        protected void iptTab1_Click(object sender, EventArgs e)
        {
            iptTab1.CssClass = "TabHeaderSelect";
            iptTab2.CssClass = "TabHeader";
        }

        protected void iptTab2_Click(object sender, EventArgs e)
        {
            iptTab1.CssClass = "TabHeader";
            iptTab2.CssClass = "TabHeaderSelect";
        }

        protected void ibtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            if (this.TabContainer2.ActiveTabIndex == 0)
            {
                Load_Bandeja(1);
                iptTab1_Click(null, null);
            }
            else
            {
                CargaGrillaMV(1);
                iptTab2_Click(null, null);
            }
        }

        protected void ibtnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            MensajeAlerta(ibtnBuscar, "Ingrese Nuevos rangos de Busqueda");
        }

        protected void gvwDocE_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sRows = gvwDocE.SelectedIndex;
            string NumOper;
            NumOper = gvwDocE.DataKeys[sRows].Value.ToString();

            if (gvwDocE.SelectedIndex > -1)
            {
                string sPageInicio = "frmDocumentoElectronico.aspx?NumOper=" + NumOper.Trim();
                RedireccionarPage(gvwDocE, sPageInicio);
            }
        }

        protected void gvwMesaV_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sRows = gvwMesaV.SelectedIndex;
            string NumOper;
            NumOper = gvwMesaV.DataKeys[sRows].Value.ToString();

            if (gvwMesaV.SelectedIndex > -1)
            {
                string sPageInicio = "frmMesaVirtual.aspx?NumOper=" + NumOper.Trim();
                RedireccionarPage(gvwMesaV, sPageInicio);
            }
        }

        protected void CargarTipoPrioridad()
        {
            GestionController TipoPrioridadController = new GestionController();
            eTipoPrioridad eTipoPrioridad = new eTipoPrioridad();

            eTipoPrioridad.EstaTipoPrio = "A";
            object sTipoPrioridad = (object)TipoPrioridadController.GetTipoPrioridad(eTipoPrioridad);

            CargarDropDownList(ddlPrioridad, sTipoPrioridad, "DescTipoPrio", "CodiTipoPrio");
            CargarDropDownList(ddlPrio, sTipoPrioridad, "DescTipoPrio", "CodiTipoPrio");
        }

        protected void CargarTipoDocumento()
        {
            DigitalizacionController TipoDocumentoController = new DigitalizacionController();
            eDocDigListTD TipoDocumentoCriteria = new eDocDigListTD();

            TipoDocumentoCriteria.EstTipoDocumento = "A";
            object sTipoDocumento = (object)TipoDocumentoController.GetTipoDocumDigital(TipoDocumentoCriteria);

            CargarDropDownList(ddlTipoDoc, sTipoDocumento, "NombTipoDocu", "CodiTipoDocu");
        }

        protected void CargarTipoParticipante()
        {
            GestionController TipParticipController = new GestionController();
            eTipoParticipacion eTipoParticipacion = new eTipoParticipacion();

            eTipoParticipacion.EstTipoParticipacion = "A";
            object sTipParticip = (object)TipParticipController.GetListaTipoParticip(eTipoParticipacion);

            CargarDropDownList(ddlParticipacion, sTipParticip, "DescParticip", "CodiTipoPart");
        }         

        protected void Load_Bandeja(int Type)
        {
            GestionController UserOper = new GestionController();
            BusquedaController OperDes = new BusquedaController();
            eOperaciones OperCrit = new eOperaciones();
            IList<eOperaciones> Oper = new List<eOperaciones>();
            eUsuario eUsuario = new eUsuario();
            IList<eUsuario> UsuPer = new List<eUsuario>();
            sSession = Session["sCodUsu"].ToString();
            /*OperCrit.Type = 1;
            OperCrit.CodUsu = Convert.ToInt64(sSession);
            OperCrit.Fecha = System.DateTime.Now;*/
            OperCrit.Type = Type;
            OperCrit.CodUsu = Convert.ToInt64(sSession);
            OperCrit.Fecha = System.DateTime.Now;
            if (ddlOpcionES.SelectedIndex != 0)
            { OperCrit.TipoPart = Convert.ToInt16(ddlOpcionES.SelectedValue.ToString()); }
            else { OperCrit.TipoPart = 0; }
            if (ddlClase.SelectedIndex != 0)
            { OperCrit.TipoComu = ddlClase.SelectedValue.ToString(); }
            else { OperCrit.TipoComu = string.Empty; }
            if (ddlTipoDoc.SelectedIndex != 0)
            { OperCrit.TipoOper = ddlTipoDoc.SelectedValue.ToString(); }
            else { OperCrit.TipoOper = string.Empty; }
            OperCrit.AsunOper = txtAsunto.Text;
            if (ddlPrioridad.SelectedIndex != 0)
            { OperCrit.PrioDoc = ddlPrioridad.SelectedValue.ToString(); }
            else { OperCrit.PrioDoc = string.Empty; }
            OperCrit.Periodo = ddlPeriodo.SelectedValue.ToString();
            OperCrit.NumOper = txtNDocE.Text;

            Oper = OperDes.GetBandejaDoc(OperCrit);

            TempGvw.Columns.Add("sNumOper");
            TempGvw.Columns.Add("sPrioridad");
            TempGvw.Columns.Add("sFechayHora");
            //TempGvw.Columns.Add("sHora");
            TempGvw.Columns.Add("sDe");
            TempGvw.Columns.Add("sPara");
            TempGvw.Columns.Add("sTipo");
            TempGvw.Columns.Add("sAsunto");
            TempGvw.Columns.Add("sFecAtencion");
            TempGvw.Columns.Add("sCodigo");
            TempGvw.Columns.Add("sLeido");
            
            //Obtener Usuarios Participantes.
            GestionController GestCon = new GestionController();
            var listCodiOper = new List<long>();
            for (int i = 0; i < Oper.Count; i++)
            {
                listCodiOper.Add(Oper[i].CodiOper);
            }
            var listUsuarioPart = new List<eParticipante>(GestCon.GetUserPartBatch(listCodiOper, new List<long>()));
            var listOperaciones = new List<long>();
            if (Oper.Count > 0)
            {
                for (int i = 0; i < Oper.Count; i++)
                {
                    if (!listOperaciones.Exists(x => x == Oper[i].CodiOper))
                    {
                        listOperaciones.Add(Oper[i].CodiOper);
                    }
                    else
                    {
                        continue;
                    }

                    TemDr = TempGvw.NewRow();
                    TemDr[0] = Oper[i].NumOper;
                    TemDr[1] = Oper[i].PrioDoc;
                    TemDr[2] = Oper[i].Fecha;                    
                    eUsuario.Codigo = Oper[i].CodUsu;
                    eUsuario.IdeUsuario = string.Empty;
                    UsuPer = GetListaUsuarioPer(eUsuario, true);
                    if (UsuPer.Count > 0)
                    {
                        TemDr[3] = UsuPer[0].IdeUsuario;
                    }
                    TemDr[4] = this.ReturnUsuaPart(listUsuarioPart, Oper[i].CodiOper, 2); 
                    TemDr[5] = Oper[i].TipoOper;
                    TemDr[6] = Oper[i].Asunto;
                    TemDr[7] = "";
                    TemDr[8] = Oper[i].CodiOper;
                    TemDr[9] = EstablecerLeido(listUsuarioPart, Oper[i].CodiOper); 
                    TempGvw.Rows.Add(TemDr);
                }
            }

            int[] sColumn = { 4, 5, 11, 13 };

            CargarGridView(gvwDocE, TempGvw, sColumn);
            
            TempGvw.Columns.Clear();
            TempGvw.Clear();
            CargaIconos(gvwDocE);
            MostrarMensajeEspera();
        }

        private string EstablecerLeido(List<eParticipante> listUsuarioPart, Int64 CodDoc)
        {
            var participantes = new List<eParticipante>(listUsuarioPart).FindAll(x => x.CodiOper == CodDoc);
            if (participantes != null && participantes.Count > 0)
            {
                var codiUsu = (Int64)Session["sCodUsu"];
                var participante = participantes.Find(x => x.CodiUsu == codiUsu);
                if (participante != null && participante.ConfLect == "S")
                {
                    return "S";
                }
            }
            return "N";
        }

        protected string ReturnUsuaPart(List<eParticipante> listUsuarioPart, Int64 CodDoc, int sTipoPart)
        {
            GestionController GestCon = new GestionController();
            eParticipante CtrUser = new eParticipante();

            IList<eParticipante> UserPart = new List<eParticipante>();

            eUsuario ReturnUser = new eUsuario();
            IList<eUsuario> LstReturnUser = new List<eUsuario>();
            eUsuario UserCriteria = new eUsuario();
            string oCadena = string.Empty;
            
            UserPart = listUsuarioPart.FindAll(x => x.CodiOper == CodDoc);

            for (int i = 0; i < UserPart.Count; i++)
            {
                if (UserPart[i].TipoPart == sTipoPart)
                {
                    UserCriteria.Codigo = UserPart[i].CodiUsu;
                    LstReturnUser = GetListaUsuarioPer(UserCriteria, true);
                    if (LstReturnUser.Count > 0)
                    {
                        for (int o = 0; o < LstReturnUser.Count; o++)
                        {
                            if (oCadena == "")
                            { oCadena = LstReturnUser[o].IdeUsuario; }
                            else { oCadena = oCadena + "; " + LstReturnUser[o].IdeUsuario; }
                        }
                    }
                }
            }

            return oCadena;
        }

        protected void CargaGrillaMV(int type)
        {
            BusquedaController MesVirController = new BusquedaController();
            eMesaVirtual MesVirCtr = new eMesaVirtual();
            eUsuario eUsuario = new eUsuario();
            IList<eMesaVirtual> MesaVir = new List<eMesaVirtual>();
            IList<eUsuario> UsuPer = new List<eUsuario>();
            sSession = Session["sCodUsu"].ToString();

            MesVirCtr.Type = type;
            MesVirCtr.CodiUsu = Convert.ToInt64(sSession);
            if (ddlParticipacion.SelectedIndex != 0)
            { MesVirCtr.TipoPart = Convert.ToInt16(ddlParticipacion.SelectedValue.ToString()); }
            else { MesVirCtr.TipoPart = 0; }
            if (ddlMesaVEstado.SelectedIndex != 0)
            { MesVirCtr.Estado = ddlMesaVEstado.SelectedValue.ToString(); }
            else { MesVirCtr.Estado = string.Empty; }
            if (ddlTipoMesaV.SelectedIndex != 0)
            { MesVirCtr.ClaseMV = Convert.ToInt16(ddlTipoMesaV.SelectedValue.ToString()); }
            else { MesVirCtr.ClaseMV = 0; }
            MesVirCtr.Asunto = txtTema.Text;
            MesVirCtr.Periodo = ddlPeriod.SelectedValue.ToString();
            MesVirCtr.Fecha = System.DateTime.Now;
            if (ddlPrio.SelectedIndex != 0)
            { MesVirCtr.Prioridad = ddlPrio.SelectedValue.ToString(); }
            else { MesVirCtr.Prioridad = string.Empty; }
            MesaVir = MesVirController.GetBandejaMV(MesVirCtr);
            if (MesaVir.Count > 0)
            {
                TempGvw.Columns.Add("sNumOper");
                TempGvw.Columns.Add("sPrioridad");
                TempGvw.Columns.Add("sFechayHora");
                //TempGvw.Columns.Add("sHora");
                TempGvw.Columns.Add("sOrganiza");
                TempGvw.Columns.Add("sParticipantes");
                TempGvw.Columns.Add("sTipo");
                TempGvw.Columns.Add("sTema");
                TempGvw.Columns.Add("sFecCierre");
                TempGvw.Columns.Add("sCodigo");
                TempGvw.Columns.Add("sLeido");

                //Obtener Usuarios Participantes.
                GestionController GestCon = new GestionController();
                var listCodiOper = new List<long>();
                for (int i = 0; i < MesaVir.Count; i++){
                    listCodiOper.Add(MesaVir[i].CodiOper);
                }
                var listUsuarioPart = new List<eParticipante>(GestCon.GetUserPartBatch(listCodiOper, new List<long>()));

                for (int i = 0; i < MesaVir.Count; i++)
                {
                    TemDr = TempGvw.NewRow();
                    TemDr[0] = MesaVir[i].NumOper;
                    TemDr[1] = MesaVir[i].Prioridad;
                    TemDr[2] = MesaVir[i].Fecha;
                    TemDr[3] = ReturnUsuaPart(listUsuarioPart, MesaVir[i].CodiOper, 4);
                    TemDr[4] = ReturnUsuaPart(listUsuarioPart, MesaVir[i].CodiOper, 1);
                    TemDr[5] = "";
                    TemDr[6] = MesaVir[i].Asunto;
                    TemDr[7] = MesaVir[i].FechaFin;
                    TemDr[8] = MesaVir[i].CodiOper;
                    TemDr[9] = EstablecerLeido(listUsuarioPart, MesaVir[i].CodiOper);
                    TempGvw.Rows.Add(TemDr);
                }   
            }

            int[] sColumn = { 3, 4, 5, 13 };

            CargarGridView(gvwMesaV, TempGvw, sColumn);

            TempGvw.Columns.Clear();
            TempGvw.Clear();

            CargaIconos(gvwMesaV);
            MostrarMensajeEspera();
        }

        protected void CargaTipoMV()
        {
            BusquedaController TipoMVControlle = new BusquedaController();
            eMesaVirtual TipoMvCriteria = new eMesaVirtual();
            IList<eMesaVirtual> TipoMV = new List<eMesaVirtual>();

            TipoMvCriteria.Estado = "A";
            TipoMV = TipoMVControlle.GetTipoMV(TipoMvCriteria);

            CargarDropDownList(ddlTipoMesaV, TipoMV, "DesMesaVir", "ClaseMV");

            ddlTipoMesaV.SelectedValue = "0";

        }

        protected void CargaIconos(GridView GvwData)
        {
            for (int i = 0; i < GvwData.Rows.Count; i++)
            {
                try
                {
                    System.Web.UI.HtmlControls.HtmlImage imgLink0 = (System.Web.UI.HtmlControls.HtmlImage)GvwData.Rows[i].Cells[0].FindControl("imgLink1");
                    if (GvwData.Rows[i].Cells[5].Text == "S")
                        imgLink0.Src = _UrlImagen + "img_EMail_I.jpg";

                    System.Web.UI.HtmlControls.HtmlImage imgLink = (System.Web.UI.HtmlControls.HtmlImage)GvwData.Rows[i].Cells[2].FindControl("imgLink3");
                    if (GvwData.Rows[i].Cells[4].Text == "1")
                        imgLink.Src = _UrlImagen + "img_punto_verde_" + (imgLink.Disabled ? "I" : "A") + ".jpg";
                    else if (GvwData.Rows[i].Cells[4].Text == "2")
                        imgLink.Src = _UrlImagen + "img_punto_amarillo_" + (imgLink.Disabled ? "I" : "A") + ".jpg";
                    else
                        imgLink.Src = _UrlImagen + "img_punto_rojo_" + (imgLink.Disabled ? "I" : "A") + ".jpg";

                    System.Web.UI.HtmlControls.HtmlImage imgLink1 = (System.Web.UI.HtmlControls.HtmlImage)GvwData.Rows[i].Cells[1].FindControl("imgLink2");

                    if (ListaDocAdju(Convert.ToInt64(GvwData.Rows[i].Cells[13].Text)))
                        imgLink1.Src = _UrlImagen + "img_Adjunto_" + (imgLink1.Disabled ? "I" : "A") + ".jpg";
                    else
                        imgLink1.Src = _UrlImagen + "img_Transparent_" + (imgLink1.Disabled ? "I" : "A") + ".gif";
                }
                catch (Exception)
                {                     
                    throw;
                }
               
            }
        }

        protected bool ListaDocAdju(Int64 CodDoc)
        {
            DigitalizacionController DigController = new DigitalizacionController();
            eDocAdj CtrAdj = new eDocAdj();
            IList<eDocAdj> DocAdj = new List<eDocAdj>();
            bool Verifica = false;

            CtrAdj.CodiOper = CodDoc;
            CtrAdj.CodiComenMesaV = 0;
            DocAdj = DigController.GetDocumentosAdjunto(CtrAdj);

            if (DocAdj.Count > 0)
            {
                Verifica = true;
            }
            return Verifica;
        }

    }
}

