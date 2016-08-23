using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;//
using System.Data.SqlClient;//
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGdoc.WebPage.Controles;
using System.Web.UI.HtmlControls;
using WebGdoc.PlanGestionServRef;
using WebGdoc.ServicesControllers;
using Entity.Entities;
using System.Text;
using System.IO;

using Word = Microsoft.Office.Interop.Word;
using System.Reflection;

namespace WebGdoc.WebPage.PlanGestion
{
    public partial class frmInforme : WebGdoc.Resources.Utility
    {
        string UserCrea = "ANDSYS";
        string sPageLoad = "../PlanGestion/frmInforme.aspx";
        String _repetOE = String.Empty;
        String _repetOO = String.Empty;
        String _repetP = String.Empty;
        String _repetA = String.Empty;
        IList<ePlanGestion> _LstPlanGestion;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (VerificarSessionUsuario(tbPrincipal))
            {
                if (!IsPostBack)
                {
                    Session.Remove("sURLActual");
                    Session.Add("sURLActual", Request.Url.ToString());

                    ConfigurarBarraHerramientas();

                    CargaPeriodo();
                    CargaPeriodoMensual(ddlIni, 0);
                    CargaPeriodoMensual(ddlFin, 0);
                    CargaObjetivoE(1, " -- Todos --");
                    CargaObjetivoO(2, " -- Todos --");
                    CargaProyecto(3, " -- Todos --");
                    CargaActividad(4, " -- Todos --");
                    CargaActividad(5, "");

                    //BusquedaInforme(0, gvwPG, -1, -1, -1, -1, true);
                }

                CargarImagen();
            }
        }

        protected void CargarImagen()
        {
            ibtnBuscar.ImageUrl = _UrlImagen + "img_Buscar_" + (ibtnBuscar.Enabled ? "A" : "I") + ".jpg";
            ibtnExportar.ImageUrl = _UrlImagen + "img_Excel_" + (ibtnExportar.Enabled ? "A" : "I") + ".jpg";
            ibtnGenerarInforme.ImageUrl = _UrlImagen + "img_Informe_" + (ibtnGenerarInforme.Enabled ? "A" : "I") + ".jpg";
        }

        protected void ConfigurarBarraHerramientas()
        {
            /*List<string> sLstLink = new List<string>();
            sLstLink.Add("WebPage/Gestion/frmDocumentoElectronico.aspx|Nuevo documento electrónico|u17_original.png");
            sLstLink.Add("WebPage/Busquedas/frmDocumentosElectronicos.aspx|Buscar documento electrónico|u21_original.png");
            sLstLink.Add("WebPage/Gestion/frmMesaVirtual.aspx|Organizar mesa de trabajo virtual|u25_original.jpg");
            sLstLink.Add("WebPage/Digitalizacion/frmDocumentosFisicos.aspx|Digitalización de documentos|u29_original.jpg");
*/
            ReferenciarTitulo(this, "Acctividad");
            //ReferenciarLink(this, sLstLink);
        }

#region CargarComboBox

        protected void CargaPeriodo()
        {
            PlanGestionController _PlanGestionController = new PlanGestionController();
            ePlanGestion _ePlanGestion = new ePlanGestion();
            IList<ePlanGestion> LstPeriodo = new List<ePlanGestion>();
            ePlanGestion _Periodo;

            for (int y = 2012; y <= DateTime.Now.Year; y++)
            {
                _Periodo = new ePlanGestion();
                _Periodo.PeriObjEstr = y;
                _Periodo.PeriPlanGes = y;
                LstPeriodo.Add(_Periodo);
            }

            CargarDropDownList(dllPeriodo, LstPeriodo, "PeriObjEstr", "PeriPlanGes");
        }

        protected void CargaPeriodoMensual(DropDownList _DropDownList, Int16 _FechaIni)
        {
            PlanGestionController _PlanGestionController = new PlanGestionController();
            ePlanGestion _ePlanGestion = new ePlanGestion();
            IList<ePlanGestion> LstPeriodo = new List<ePlanGestion>();
            ePlanGestion _PeriodoMensual;

            for (int y = _FechaIni; y <= 12; y++)
            {
                _PeriodoMensual = new ePlanGestion();
                _PeriodoMensual.PeriPlanGes = y;
                _PeriodoMensual.DescObjEstr = (y == 1 ? "Enero" :
                                              (y == 2 ? "Febrero" :
                                              (y == 3 ? "Marzo" :
                                              (y == 4 ? "Abril" :
                                              (y == 5 ? "Mayo" :
                                              (y == 6 ? "Junio" :
                                              (y == 7 ? "Julio" :
                                              (y == 8 ? "Agosto" :
                                              (y == 9 ? "Setiembre" :
                                              (y == 10 ? "Octubre" :
                                              (y == 11 ? "Noviembre" :
                                              (y == 12 ? "Diciembre" : "-- Seleccione --"))))))))))));
                LstPeriodo.Add(_PeriodoMensual);
            }

            CargarDropDownList(_DropDownList, LstPeriodo, "DescObjEstr", "PeriPlanGes");
        }

        protected void CargaObjetivoE(Int16 _TypeOperacion, String _Items)
        {
            PlanGestionController _PlanGestionController = new PlanGestionController();
            ePlanGestion _ePlanGestion = new ePlanGestion();
            IList<ePlanGestion> LstEstrategico = new List<ePlanGestion>();

            _ePlanGestion.TypeOperacion = _TypeOperacion;
            _ePlanGestion.PeriObjEstr = Convert.ToInt32(dllPeriodo.SelectedValue);
            if (ddlEstrategico.SelectedValue != "")
                _ePlanGestion.CodiObjEstr = Convert.ToInt32(ddlEstrategico.SelectedValue);

            LstEstrategico = _PlanGestionController.GetObetivoEstrategico(_ePlanGestion, _Items);

            CargarDropDownList(ddlEstrategico, LstEstrategico, "DescObjEstr", "CodiObjEstr");

        }

        protected void CargaObjetivoO(Int16 _TypeOperacion, String _Items)
        {
            PlanGestionController _PlanGestionController = new PlanGestionController();
            ePlanGestion _ePlanGestion = new ePlanGestion();
            IList<ePlanGestion> LstEstrategico = new List<ePlanGestion>();

            _ePlanGestion.TypeOperacion = _TypeOperacion;
            _ePlanGestion.PeriObjEstr = Convert.ToInt32(dllPeriodo.SelectedValue);
            if (ddlEstrategico.SelectedValue != "")
                _ePlanGestion.CodiObjEstr = Convert.ToInt32(ddlEstrategico.SelectedValue);
            if (ddlOperativo.SelectedValue != "")
                _ePlanGestion.CodiObjOper = Convert.ToInt32(ddlOperativo.SelectedValue);

            LstEstrategico = _PlanGestionController.GetObetivoOperativo(_ePlanGestion, _Items);

            if (_TypeOperacion == 2)
                CargarDropDownList(ddlOperativo, LstEstrategico, "DescObjOper", "CodiObjOper");
        }

        protected void CargaProyecto(Int16 _TypeOperacion, String _Items)
        {
            PlanGestionController _PlanGestionController = new PlanGestionController();
            ePlanGestion _ePlanGestion = new ePlanGestion();
            IList<ePlanGestion> LstEstrategico = new List<ePlanGestion>();

            _ePlanGestion.TypeOperacion = _TypeOperacion;
            _ePlanGestion.PeriObjEstr = Convert.ToInt32(dllPeriodo.SelectedValue);
            if (ddlEstrategico.SelectedValue != "")
                _ePlanGestion.CodiObjEstr = Convert.ToInt32(ddlEstrategico.SelectedValue);

            if (ddlOperativo.SelectedValue != "")
                _ePlanGestion.CodiObjOper = Convert.ToInt32(ddlOperativo.SelectedValue);

            if (ddlProyecto.SelectedValue != "")
                _ePlanGestion.CodiProy = Convert.ToInt32(ddlProyecto.SelectedValue);

            LstEstrategico = _PlanGestionController.GetProyecto(_ePlanGestion, _Items);

            if (_TypeOperacion == 3)
                CargarDropDownList(ddlProyecto, LstEstrategico, "DescProy", "CodiProy");

        }

        protected void CargaActividad(Int16 _TypeOperacion, String _Items)
        {
            PlanGestionController _PlanGestionController = new PlanGestionController();
            ePlanGestion _ePlanGestion = new ePlanGestion();
            IList<ePlanGestion> LstEstrategico = new List<ePlanGestion>();

            _ePlanGestion.TypeOperacion = _TypeOperacion;
            _ePlanGestion.PeriObjEstr = Convert.ToInt32(dllPeriodo.SelectedValue);
            if (ddlEstrategico.SelectedValue != "")
                _ePlanGestion.CodiObjEstr = Convert.ToInt32(ddlEstrategico.SelectedValue);

            if (ddlOperativo.SelectedValue != "")
                _ePlanGestion.CodiObjOper = Convert.ToInt32(ddlOperativo.SelectedValue);

            if (ddlProyecto.SelectedValue != "")
                _ePlanGestion.CodiProy = Convert.ToInt32(ddlProyecto.SelectedValue);

            if (ddlActividad.SelectedValue != "")
                _ePlanGestion.CodiActi = Convert.ToInt32(ddlActividad.SelectedValue);

            LstEstrategico = _PlanGestionController.GetActividad(_ePlanGestion, _Items);

            if (_TypeOperacion == 4)
                CargarDropDownList(ddlActividad, LstEstrategico, "DescActi", "CodiActi");

        }

        public void BusquedaInforme(Int16 _TypeOperacion, GridView _GridView, Int64 _OE, Int64 _OO, Int64 _P, Int64 _A, Boolean _Actualizar)
        {
            PlanGestionController _PlanGestionController = new PlanGestionController();
            ePlanGestion _ePlanGestion = new ePlanGestion();
            IList<ePlanGestion> LstPlanGestion = new List<ePlanGestion>();
            _LstPlanGestion = new List<ePlanGestion>();

            _ePlanGestion.TypeOperacion = _TypeOperacion;

            _ePlanGestion.PeriObjEstr = Convert.ToInt32(dllPeriodo.SelectedItem.ToString());

            _ePlanGestion.CodiObjEstr = (_OE > 0 ? _OE : Convert.ToInt64(ddlEstrategico.SelectedValue.ToString()));

            _ePlanGestion.CodiObjOper = (_OE > 0 ? _OO : Convert.ToInt64(ddlOperativo.SelectedValue.ToString()));

            _ePlanGestion.CodiProy = (_OE > 0 ? _P : Convert.ToInt64(ddlProyecto.SelectedValue.ToString()));

            _ePlanGestion.CodiActi = (_OE > 0 ? _A : Convert.ToInt64(ddlActividad.SelectedValue.ToString()));

            _ePlanGestion.CodiUsu = CapturarUsuario(ctlUserRemitente);

            LstPlanGestion = _PlanGestionController.GetInforme(_ePlanGestion);
            _LstPlanGestion = LstPlanGestion;

            if (_Actualizar)
            {
                OcultarCampos(-1, _GridView, true);

                _GridView.DataSource = LstPlanGestion;
                _GridView.DataBind();
                VerificarGridView(_GridView);

                OcultarCampos(-1, _GridView, false);
                OcultarCampos(_TypeOperacion, _GridView, true);
            }

            /* Eliminar */
            //GridView1.DataSource = LstPlanGestion;
            //GridView1.DataBind();
        }

#endregion

#region Controles

        protected void dllPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlEstrategico_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaObjetivoO(2, " -- Todos --");

            CargaProyecto(3, " -- Todos --");
            CargaActividad(4, " -- Todos --");
            CargaActividad(5, "");
        }

        protected void ddlOperativo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaProyecto(3, " -- Todos --");

            CargaActividad(4, " -- Todos --");
            CargaActividad(5, "");
        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaActividad(4, " -- Todos --");

            CargaActividad(5, "");
        }

        protected void ddlActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaActividad(5, "");
        }

        protected void ddlIni_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaPeriodoMensual(ddlFin, Convert.ToInt16(ddlIni.SelectedValue));
        }

        protected void ddlFin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvwPG_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text == _repetOE)
                    e.Row.Cells[0].Text = "";
                else
                    _repetOE = e.Row.Cells[0].Text;


                if (e.Row.Cells[1].Text == _repetOO)
                    e.Row.Cells[1].Text = "";
                else
                    _repetOO = e.Row.Cells[1].Text;


                if (e.Row.Cells[2].Text == _repetP)
                    e.Row.Cells[2].Text = "";
                else
                    _repetP = e.Row.Cells[2].Text;


                if (e.Row.Cells[3].Text == _repetA)
                    e.Row.Cells[3].Text = "";
                else
                    _repetA = e.Row.Cells[3].Text;


                for (int i = 1; i <= 12; i++)
                {
                    if (Convert.ToDecimal(e.Row.Cells[i + 3].Text) <= 0)
                        e.Row.Cells[i + 3].Text = "";
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

#endregion

#region Botonera

        protected void ibtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            BusquedaInforme(0, gvwPG, Convert.ToInt64(ddlEstrategico.SelectedValue), Convert.ToInt64(ddlOperativo.SelectedValue), Convert.ToInt64(ddlProyecto.SelectedValue), Convert.ToInt64(ddlActividad.SelectedValue), true);
        }

        protected void ibtnExportar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string style = @"<style> .text { mso-number-format:\@; } </script> ";
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment; filename=PlanGestion_" + dllPeriodo.SelectedValue + ".xls");
                Response.ContentType = "application/excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                gvwPG.RenderControl(htw);
                // Style is added dynamically
                Response.Write(style);
                Response.Write(sw.ToString());
                Response.End();


            }
            catch (Exception exp)
            {
                //en c# web lo mensajes en pantalla hay que realizarlos con javascript, en c# windform son por defecto asi            
                string script = @"<script language = ""JavaScript"">alert('Filtre más la informacion por que se sobrepaso de los 65.536 registros del excel');</script>";
                ClientScript.RegisterStartupScript(typeof(Page), "Alerta", script);
                return;
            }
        }

        protected void ibtnGenerarInforme_Click(object sender, ImageClickEventArgs e)
        {
            BusquedaInforme(0, gvwPG, -1, -1, -1, -1, false);

            int _RowAdd = 1;
            String _OE = String.Empty;
            String _OO = String.Empty;
            String _P = String.Empty;
            String _A = String.Empty;

            for (int _PG = 0; _PG <= _LstPlanGestion.Count - 1; _PG++)
            {
                if (_OE != _LstPlanGestion[_PG].DescObjEstr)
                {
                    _OE = _LstPlanGestion[_PG].DescObjEstr;
                    _RowAdd = _RowAdd + 1;
                }

                if (_OE == _LstPlanGestion[_PG].DescObjEstr &&
                    _OO != _LstPlanGestion[_PG].DescObjOper)
                {
                    _OO = _LstPlanGestion[_PG].DescObjOper;
                    _RowAdd = _RowAdd + 1;
                }

                if (_OE == _LstPlanGestion[_PG].DescObjEstr &&
                    _OO == _LstPlanGestion[_PG].DescObjOper &&
                    _P != _LstPlanGestion[_PG].DescProy)
                {
                    _P = _LstPlanGestion[_PG].DescProy;
                    _RowAdd = _RowAdd + 1;
                }

                if (_OE == _LstPlanGestion[_PG].DescObjEstr &&
                    _OO == _LstPlanGestion[_PG].DescObjOper &&
                    _P == _LstPlanGestion[_PG].DescProy &&
                    _A != _LstPlanGestion[_PG].DescActi)
                {
                    _A = _LstPlanGestion[_PG].DescActi;
                    _RowAdd = _RowAdd + 1;

                }

            }

            GenerarDocumentoWord(dllPeriodo.SelectedValue,
                                 (ddlIni.SelectedItem.Text.IndexOf("-") != -1 ? "Enero" : ddlIni.SelectedItem.Text),
                                 (ddlFin.SelectedItem.Text.IndexOf("-") != -1 ? "Diciembre" : ddlFin.SelectedItem.Text),
                                 _RowAdd);
        }

#endregion

#region Procesos

        protected Int64 CapturarUsuario(ValidarUsuario_Grupo sControlUser)
        {
            Int64 sCodUsuario = 0;
            GridView sUserSelect = sControlUser.UsuarioSelect;

            if (sUserSelect.Rows.Count > 0)
            {
                if (sUserSelect.Rows[0].Cells[0].Text != "&nbsp;")
                {
                    for (int i = 0; i < sUserSelect.Rows.Count; i++)
                    {
                        sCodUsuario = Convert.ToInt64(sUserSelect.Rows[i].Cells[0].Text);
                    }
                }
            }
            return sCodUsuario;
        }

        protected void OcultarCampos(Int16 TypeOperacion, GridView _GridView, bool _bool)
        {
            Int16 _Count = 0;
            Int16 _FIni = 1;
            Int16 _FFin = 12;

            switch (TypeOperacion)
            {
                case -1:
                    for (int i = 1; i <= 12; i++)
                        _GridView.Columns[i + 3].Visible = _bool;
                    break;
                case 0:
                    if (ddlIni.SelectedIndex > 0)
                        _FIni = Convert.ToInt16(ddlIni.SelectedValue);

                    if (ddlIni.SelectedIndex > 0)
                        _FFin = Convert.ToInt16(ddlFin.SelectedValue);

                    for (Int16 i = _FIni; i <= _FFin; i++)
                    {
                        _Count++;
                        _GridView.Columns[i + 3].Visible = _bool;
                    }

                    if (ddlIni.SelectedIndex > 0 || ddlFin.SelectedIndex > 0)
                    {
                        gvwPG.Width = 600 + (80 * _Count);
                    }

                    break;
                case 1:
                    _GridView.Columns[0].Visible = _bool;
                    break;
                case 2:
                    _GridView.Columns[0].Visible = _bool;
                    _GridView.Columns[1].Visible = _bool;
                    break;
                case 3:
                    _GridView.Columns[0].Visible = _bool;
                    _GridView.Columns[1].Visible = _bool;
                    _GridView.Columns[2].Visible = _bool;
                    break;
            }
        }


        public void GenerarDocumentoWord(String _Periodo, String _MesInicial, String _MesFinal, Int32 _RowAdd)
        {
            try
            {
                object oMissing = System.Reflection.Missing.Value;
                object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

                string sRutaTMP = ConfigurationManager.AppSettings.Get("CarpetaTMP");
                string sNombreTmp = Session["sUsuario"].ToString() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                object fileName = sRutaTMP + "\\" + sNombreTmp + ".docx";

                //Start Word and create a new document.
                Word._Application oWord = new Word.Application(); ;
                //Word._Document oDoc;
                Word._Document oDoc = new Word.Document();
                try
                {
                    //oWord.Visible = true;
                    oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
        
                    String _Tab = "\t";
                    String _Sangria = "      ";
                    String _Space = "   ";

                    InsertarParafo(oDoc, oMissing, "INFORME DE GESTIÓN OPERATIVA " + _Periodo, 1, Word.WdUnderline.wdUnderlineNone, 10, 2, Word.WdParagraphAlignment.wdAlignParagraphCenter);
                    InsertarParafo(oDoc, oMissing, _MesInicial + " - " + _MesFinal, 1, Word.WdUnderline.wdUnderlineNone, 10, 10, Word.WdParagraphAlignment.wdAlignParagraphCenter);
                    InsertarParafo(oDoc, oMissing, "I." + _Space + "INTRODUCCIÓN", 1, Word.WdUnderline.wdUnderlineNone, 9, 10, Word.WdParagraphAlignment.wdAlignParagraphLeft);

                    InsertarParafo(oDoc, oMissing, (_Sangria + "El presente informe expone lo sustantivo del conjunto de actividades realizadas por los distintos"), 0, Word.WdUnderline.wdUnderlineNone, 8, 0, Word.WdParagraphAlignment.wdAlignParagraphDistribute);
                    InsertarParafo(oDoc, oMissing, (_Sangria + "departamentos y unidades de la Federación Peruana de Cajas Municipales de Ahorro y Crédito"), 0, Word.WdUnderline.wdUnderlineNone, 8, 0, Word.WdParagraphAlignment.wdAlignParagraphDistribute);
                    InsertarParafo(oDoc, oMissing, (_Sangria + "(FEPCMAC), al periodo " + _MesInicial + " - " + _MesFinal + " las cuales han tenido como marco el Plan de Gestión"), 0, Word.WdUnderline.wdUnderlineNone, 8, 0, Word.WdParagraphAlignment.wdAlignParagraphDistribute);
                    InsertarParafo(oDoc, oMissing, (_Sangria + "aprobado para el presente año. Cabe señalar que los departamentos de la FEPCMAC intervinientes"), 0, Word.WdUnderline.wdUnderlineNone, 8, 0, Word.WdParagraphAlignment.wdAlignParagraphDistribute);
                    InsertarParafo(oDoc, oMissing, (_Sangria + "en la ejecución de este plan de gestión, son los siguientes:"), 0, Word.WdUnderline.wdUnderlineNone, 8, 5, Word.WdParagraphAlignment.wdAlignParagraphJustify);

                    InsertarParafo(oDoc, oMissing, (_Sangria + "1." + _Space + "Gerencia Mancomunada (GM)"), 0, Word.WdUnderline.wdUnderlineNone, 8, 0, Word.WdParagraphAlignment.wdAlignParagraphJustify);
                    InsertarParafo(oDoc, oMissing, (_Sangria + "2." + _Space + "Dirección de Auditoria (DAU)"), 0, Word.WdUnderline.wdUnderlineNone, 8, 0, Word.WdParagraphAlignment.wdAlignParagraphJustify);
                    InsertarParafo(oDoc, oMissing, (_Sangria + "3." + _Space + "Instituto de Microfinanzas (MF)"), 0, Word.WdUnderline.wdUnderlineNone, 8, 0, Word.WdParagraphAlignment.wdAlignParagraphJustify);
                    InsertarParafo(oDoc, oMissing, (_Sangria + "4." + _Space + "Departamento de Cooperación Técnica y Financiera (CTF)"), 0, Word.WdUnderline.wdUnderlineNone, 8, 0, Word.WdParagraphAlignment.wdAlignParagraphJustify);
                    InsertarParafo(oDoc, oMissing, (_Sangria + "5." + _Space + "Departamento de Asesoría (DAS)"), 0, Word.WdUnderline.wdUnderlineNone, 8, 0, Word.WdParagraphAlignment.wdAlignParagraphJustify);
                    InsertarParafo(oDoc, oMissing, (_Sangria + "6." + _Space + "Unidad de Prensa (Prensa)"), 0, Word.WdUnderline.wdUnderlineNone, 8, 5, Word.WdParagraphAlignment.wdAlignParagraphJustify);

                    InsertarParafo(oDoc, oMissing, (_Sangria + "De igual forma se determina el grado de cumplimiento de los Objetivos Operativos al periodo"), 0, Word.WdUnderline.wdUnderlineNone, 8, 0, Word.WdParagraphAlignment.wdAlignParagraphDistribute);
                    InsertarParafo(oDoc, oMissing, (_Sangria + _MesInicial + " - " + _MesFinal + " " + _Periodo + " , así como las actividades y sub actividades relacionadas con cada objetivo."), 0, Word.WdUnderline.wdUnderlineNone, 8, 5, Word.WdParagraphAlignment.wdAlignParagraphJustify);

                    InsertarParafo(oDoc, oMissing, (_Sangria + "Asimismo, se informa sobre las brechas obtenidas por cada proyecto o actividad y las propuestas de"), 0, Word.WdUnderline.wdUnderlineNone, 8, 0, Word.WdParagraphAlignment.wdAlignParagraphDistribute);
                    InsertarParafo(oDoc, oMissing, (_Sangria + "planes de acción que realizará cada unidad o departamento de la institución, con la finalidad de cubrir"), 0, Word.WdUnderline.wdUnderlineNone, 8, 0, Word.WdParagraphAlignment.wdAlignParagraphDistribute);
                    InsertarParafo(oDoc, oMissing, (_Sangria + "las diferencias o brechas identificadas."), 0, Word.WdUnderline.wdUnderlineNone, 8, 15, Word.WdParagraphAlignment.wdAlignParagraphJustify);

                    InsertarParafo(oDoc, oMissing, "II." + _Space + "CONTENIDO", 1, Word.WdUnderline.wdUnderlineNone, 9, 10, Word.WdParagraphAlignment.wdAlignParagraphLeft);

                    InsertarParafo(oDoc, oMissing, (_Sangria + "1." + _Space + "Cumplimiento en el nivel de los objetivos operativos y atividades"), 1, Word.WdUnderline.wdUnderlineNone, 9, 10, Word.WdParagraphAlignment.wdAlignParagraphLeft);

                    InsertarParafo(oDoc, oMissing, (_Sangria + _Sangria + "El cumplimiento consolidado del Plan de Gestión " + _Periodo + " al periodo " + _MesInicial + " - " + _MesFinal + " fue del orden del"), 0, Word.WdUnderline.wdUnderlineNone, 8, 0, Word.WdParagraphAlignment.wdAlignParagraphDistribute);
                    InsertarParafo(oDoc, oMissing, (_Sangria + _Sangria + "66% aproximadamente, con respecto del 100% de actividades comprometidas y ejecutadas para el"), 0, Word.WdUnderline.wdUnderlineNone, 8, 0, Word.WdParagraphAlignment.wdAlignParagraphDistribute);
                    InsertarParafo(oDoc, oMissing, (_Sangria + _Sangria + "periodo en cuestión. Debe señalarse que el total de actividades comprometidas asciende a 41, de las"), 0, Word.WdUnderline.wdUnderlineNone, 8, 0, Word.WdParagraphAlignment.wdAlignParagraphDistribute);
                    InsertarParafo(oDoc, oMissing, (_Sangria + _Sangria + "cuales 27 no generaron brecha en tanto que 14 sí lo hicieron, tal como se detalla a continuación:"), 0, Word.WdUnderline.wdUnderlineNone, 8, 5, Word.WdParagraphAlignment.wdAlignParagraphJustify);
                    InsertarParafo(oDoc, oMissing, "", 0, Word.WdUnderline.wdUnderlineNone, 8, 5, Word.WdParagraphAlignment.wdAlignParagraphJustify);

                    InsertarTablaCumplimiento(oDoc, oEndOfDoc, oMissing, 7, 3, 1, 9);

                    InsertarParafo(oDoc, oMissing, "", 0, Word.WdUnderline.wdUnderlineNone, 8, 5, Word.WdParagraphAlignment.wdAlignParagraphJustify);
                    InsertarParafo(oDoc, oMissing, (_Sangria + _Sangria + "Cabe señalar que a la presentación del presente informe el porcentaje se encuentra en 71%, debido"), 0, Word.WdUnderline.wdUnderlineNone, 8, 5, Word.WdParagraphAlignment.wdAlignParagraphJustify);
                    InsertarParafo(oDoc, oMissing, (_Sangria + _Sangria + "al cierre de la brecha de 2 actividades, la 1.2.C.4 y la 2.3.A.1."), 0, Word.WdUnderline.wdUnderlineNone, 8, 5, Word.WdParagraphAlignment.wdAlignParagraphJustify);

                    InsertarParafo(oDoc, oMissing, (_Sangria + _Sangria + "Asimismo, debe indicarse que 3 actividades fueron adelantadas, a pesar de no hallarse compromiso"), 0, Word.WdUnderline.wdUnderlineNone, 8, 5, Word.WdParagraphAlignment.wdAlignParagraphJustify);
                    InsertarParafo(oDoc, oMissing, (_Sangria + _Sangria + "para el periodo. Es el caso de 1.2.D, 1.2.E y 1.6.A.1."), 0, Word.WdUnderline.wdUnderlineNone, 8, 5, Word.WdParagraphAlignment.wdAlignParagraphJustify);

                    InsertarParafo(oDoc, oMissing, (_Sangria + _Sangria + "A continuación se presenta el Plan de Gestión " + _Periodo + " con el detalle de los objetivos y sus proyectos y"), 0, Word.WdUnderline.wdUnderlineNone, 8, 5, Word.WdParagraphAlignment.wdAlignParagraphJustify);
                    InsertarParafo(oDoc, oMissing, (_Sangria + _Sangria + "actividades, así como su correspondiente nivel de cumplimiento."), 0, Word.WdUnderline.wdUnderlineNone, 8, 5, Word.WdParagraphAlignment.wdAlignParagraphJustify);

                    InsertarSaltoPagina(oWord, oDoc, oEndOfDoc);

                    InsertarParafo(oDoc, oMissing, ("PLAN DE GETION DE LA FEPCMAC " + _Periodo), 0, Word.WdUnderline.wdUnderlineSingle, 8, 5, Word.WdParagraphAlignment.wdAlignParagraphCenter);

                    InsertarTablaPlanGestion(oDoc, oEndOfDoc, oMissing, _RowAdd, 6, 1, 9);

                    InsertarSaltoPagina(oWord, oDoc, oEndOfDoc);
                    InsertarParafo(oDoc, oMissing, (_Sangria + "2." + _Space + "Cumplimiento a Nivel de Actividades"), 1, Word.WdUnderline.wdUnderlineNone, 9, 10, Word.WdParagraphAlignment.wdAlignParagraphLeft);
                    InsertarParafo(oDoc, oMissing, (_Sangria + _Sangria + "A continuación se presente el detalle del cumplimiento de cada actividad, sus variaciones, brechas y"), 0, Word.WdUnderline.wdUnderlineNone, 8, 0, Word.WdParagraphAlignment.wdAlignParagraphDistribute);
                    InsertarParafo(oDoc, oMissing, (_Sangria + _Sangria + "los planes de acción a desarrollar por los departamentos y unidades responsables."), 0, Word.WdUnderline.wdUnderlineNone, 8, 20, Word.WdParagraphAlignment.wdAlignParagraphJustify);

                    String _OE = String.Empty;
                    String _OO = String.Empty;
                    String _P = String.Empty;
                    String _A = String.Empty;

                    for (int _PG = 0; _PG <= _LstPlanGestion.Count - 1; _PG++)
                    {
                        if (_OE != _LstPlanGestion[_PG].DescObjEstr)
                        {
                            _OE = _LstPlanGestion[_PG].DescObjEstr;

                            InsertarParafo(oDoc, oMissing, ("OBJETIVO ESTRATÉGICO:" + _Tab + _OE), 1, Word.WdUnderline.wdUnderlineSingle, 9, 10, Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        }

                        if (_OE == _LstPlanGestion[_PG].DescObjEstr &&
                            _OO != _LstPlanGestion[_PG].DescObjOper)
                        {
                            _OO = _LstPlanGestion[_PG].DescObjOper;

                            InsertarParafo(oDoc, oMissing, (_Sangria + _Sangria + "Objetivo Operativo:" + _Tab + _OO), 1, Word.WdUnderline.wdUnderlineSingle, 9, 10, Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        }

                        if (_OE == _LstPlanGestion[_PG].DescObjEstr &&
                            _OO == _LstPlanGestion[_PG].DescObjOper &&
                            _P != _LstPlanGestion[_PG].DescProy)
                        {
                            _P = _LstPlanGestion[_PG].DescProy;

                            InsertarParafo(oDoc, oMissing, (_Sangria + _Sangria + _P), 1, Word.WdUnderline.wdUnderlineSingle, 9, 10, Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        }

                        if (_OE == _LstPlanGestion[_PG].DescObjEstr &&
                            _OO == _LstPlanGestion[_PG].DescObjOper &&
                            _P == _LstPlanGestion[_PG].DescProy &&
                            _A != _LstPlanGestion[_PG].DescActi)
                        {
                            _A = _LstPlanGestion[_PG].DescActi;

                            InsertarParafo(oDoc, oMissing, (_Sangria + _Sangria + _Sangria + _A), 1, Word.WdUnderline.wdUnderlineSingle, 9, 10, Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            InsertarParafo(oDoc, oMissing, (_Sangria + _Sangria + _Sangria + "Unidad Responsable: "), 1, Word.WdUnderline.wdUnderlineNone, 9, 10, Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        }

                    }

                    oDoc.SaveAs(ref fileName, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                    oWord.Application.Quit(ref oMissing, ref oMissing, ref oMissing);

                    ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", "VisualizarPlanGestion.aspx?PG=" + sNombreTmp));

                }
                catch (Exception ex)
                {
                    MensajeAlerta(ibtnExportar, "Error Doc:" + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MensajeAlerta(ibtnExportar, "Error:" + ex.Message);
            }
        }

        protected void InsertarParafo(Word._Document oDoc, object oMissing, string _Texto, int _Bold, Word.WdUnderline _Underline, int _Size, float _SpaceLine, Word.WdParagraphAlignment _Align)
        {
            Word.Paragraph oPara1;
            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            oPara1.Range.Text = _Texto;
            oPara1.Range.Font.Name = "Arial";
            oPara1.Range.Font.Bold = _Bold;
            oPara1.Range.Font.Underline = _Underline;   //Word.WdUnderline.wdUnderlineSingle; 
            oPara1.Range.Font.Size = _Size;
            oPara1.Format.SpaceAfter = _SpaceLine;      // 24;
            oPara1.Format.Alignment = _Align;           // Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oPara1.Range.InsertParagraphAfter();
        }

        protected void InsertarSaltoPagina(Word._Application oWord, Word._Document oDoc, object oEndOfDoc)
        {
            object oPos;
            double dPos = oWord.InchesToPoints(7);
            Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;

            oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range.InsertParagraphAfter();
            do
            {
                wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                wrdRng.ParagraphFormat.SpaceAfter = 6;
                wrdRng.InsertAfter("");
                wrdRng.InsertParagraphAfter();
                oPos = wrdRng.get_Information
                               (Word.WdInformation.wdVerticalPositionRelativeToPage);
            }
            while (dPos >= Convert.ToDouble(oPos));

            object oCollapseEnd = Word.WdCollapseDirection.wdCollapseEnd;
            object oPageBreak = Word.WdBreakType.wdPageBreak;
            wrdRng.Collapse(ref oCollapseEnd);
            wrdRng.InsertBreak(ref oPageBreak);
            wrdRng.Collapse(ref oCollapseEnd);
        }

        protected void InsertarTablaCumplimiento(Word._Document oDoc, object oEndOfDoc, object oMissing, int _Rows, int _Columns, int _HeaderBold, int _HeaderSize)
        {
            Word.Table oTable;
            Word.Cell cellInitiationHeader = null;
            Word.Cell cellLastHeader = null;

            Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oDoc.Tables.Add(wrdRng, _Rows, _Columns, ref oMissing, ref oMissing);
            oTable.Range.ParagraphFormat.SpaceAfter = 6;

            oTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            oTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;

            //Stilo Cabecera
            oTable.Rows[1].Range.Font.Bold = _HeaderBold;
            oTable.Rows[1].Range.Font.Name = "Arial";
            oTable.Rows[1].Range.Font.Size = _HeaderSize;
            //Stilo Cabecera
            oTable.Rows[2].Range.Font.Bold = _HeaderBold;
            oTable.Rows[2].Range.Font.Name = "Arial";
            oTable.Rows[2].Range.Font.Size = _HeaderSize;

            //Fusionar filas (Rowspan)
            cellInitiationHeader = oTable.Cell(1, 1);
            cellLastHeader = oTable.Cell(2, 1);
            cellInitiationHeader.Merge(cellLastHeader);

            //Fusionar Columnas (Colspan)
            cellInitiationHeader = oTable.Cell(1, 2);
            cellLastHeader = oTable.Cell(1, 3);
            cellInitiationHeader.Merge(cellLastHeader);

            oTable.Cell(1, 1).Range.Text = "Estado";
            oTable.Cell(1, 2).Range.Text = "A la fecha de corte (" + System.DateTime.Now.ToShortDateString() + ")";
            oTable.Cell(2, 2).Range.Text = "Número de proyectos/actividades comprometidas";
            oTable.Cell(2, 3).Range.Text = "Porcentaje";
            oTable.Cell(3, 1).Range.Text = "Ejecutadas";
            oTable.Cell(4, 1).Range.Text = "   Meta del periodo completada";
            oTable.Cell(5, 1).Range.Text = "   Meta del periodo por completar";
            oTable.Cell(6, 1).Range.Text = "Sin ejecutar";
            oTable.Cell(7, 1).Range.Text = "Total";
        }

        protected void InsertarTablaPlanGestion(Word._Document oDoc, object oEndOfDoc, object oMissing, int _Rows, int _Columns, int _HeaderBold, int _HeaderSize)
        {
            Word.Table oTable;
            Word.Cell cellInitiationHeader = null;
            Word.Cell cellLastHeader = null;

            Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oDoc.Tables.Add(wrdRng, _Rows, _Columns, ref oMissing, ref oMissing);
            oTable.Range.ParagraphFormat.SpaceAfter = 6;

            oTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            oTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;

            //Stilo Cabecera
            oTable.Rows[1].Range.Font.Bold = _HeaderBold;
            oTable.Rows[1].Range.Font.Name = "Arial";
            oTable.Rows[1].Range.Font.Size = _HeaderSize;

            oTable.Cell(1, 1).Range.Text = "Proyecto / Actividades";
            oTable.Cell(1, 2).Range.Text = "Unidad de Medida";
            oTable.Cell(1, 3).Range.Text = "Meta Anual";
            oTable.Cell(1, 4).Range.Text = "Esperado a la Fecha";
            oTable.Cell(1, 5).Range.Text = "Acumulado a la Fecha";
            oTable.Cell(1, 6).Range.Text = "Brecha";

            String _OE = String.Empty;
            String _OO = String.Empty;
            String _P = String.Empty;
            String _A = String.Empty;
            Int32 _CC = 1;
            Int32 _CCTmp = 0;

            for (int _PG = 0; _PG <= _LstPlanGestion.Count - 1; _PG++)
            {
                if (_OE != _LstPlanGestion[_PG].DescObjEstr)
                {
                    _OE = _LstPlanGestion[_PG].DescObjEstr;
                    _CC = _CC + 1;
                    _CCTmp = _CCTmp + 1;
                    //Fusionar Columnas (Colspan)
                    cellInitiationHeader = oTable.Cell(_CC, 1);
                    cellLastHeader = oTable.Cell(_CC, _Columns);
                    cellInitiationHeader.Merge(cellLastHeader);

                    oTable.Cell(_CC, 1).Range.Text = _OE;
                }

                if (_OE == _LstPlanGestion[_PG].DescObjEstr &&
                    _OO != _LstPlanGestion[_PG].DescObjOper)
                {
                    _OO = _LstPlanGestion[_PG].DescObjOper;
                    _CC = _CC + 1;
                    _CCTmp = _CCTmp + 1;
                    //Fusionar Columnas (Colspan)
                    cellInitiationHeader = oTable.Cell(_CC, 1);
                    cellLastHeader = oTable.Cell(_CC, _Columns);
                    cellInitiationHeader.Merge(cellLastHeader);

                    oTable.Cell(_CC, 1).Range.Text = _OO;
                }

                if (_OE == _LstPlanGestion[_PG].DescObjEstr &&
                    _OO == _LstPlanGestion[_PG].DescObjOper &&
                    _P != _LstPlanGestion[_PG].DescProy)
                {
                    _P = _LstPlanGestion[_PG].DescProy;
                    _CC = _CC + 1;
                    _CCTmp = _CCTmp + 1;
                    //Fusionar Columnas (Colspan)
                    cellInitiationHeader = oTable.Cell(_CC, 2);
                    cellLastHeader = oTable.Cell(_CC, _Columns);
                    cellInitiationHeader.Merge(cellLastHeader);

                    oTable.Cell(_CC, 1).Range.Text = _P;
                }

                if (_OE == _LstPlanGestion[_PG].DescObjEstr &&
                    _OO == _LstPlanGestion[_PG].DescObjOper &&
                    _P == _LstPlanGestion[_PG].DescProy &&
                    _A != _LstPlanGestion[_PG].DescActi)
                {
                    _A = _LstPlanGestion[_PG].DescActi;
                    _CC = _CC + 1;

                    oTable.Cell(_CC, 1).Range.Text = _A;
                }

            }
        }

#endregion


        //protected void GridView1_RowCommand(object sender,System.Web.UI.WebControls.GridViewCommandEventArgs e)
        //{
        //    //Capturamos accion a realizar (Propiedad establecida en "CommandName" del link)
        //    string currentCommand = e.CommandName;

        //    //Capturamos el IDPrincipal (Propiedad establecida en "DataKeyNames" de la Grilla)
        //    int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
        //    string ProductID = GridView1.DataKeys[currentRowIndex].Value.ToString();

        //    /* Establecer if con condicionantes*/
        //    ...
        //}

    }
}