using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGdoc.ServicesControllers;
using WebGdoc.GestionServRef;
using Entity.Entities;

namespace WebGdoc.WebPage.Controles
{
    public partial class ValidarUsuario_Grupo : System.Web.UI.UserControl
    {
        WebGdoc.Resources.Utility sUtility = new WebGdoc.Resources.Utility();
        private string _UrlImagen = "~/Resources/Imagenes/";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (sUtility.VerificarSessionUsuario(gvwUsuarioGrupo))
            {

                if (!IsPostBack)
                {
                    //sUtility.VerificarGridView(gvwUsuarioGrupo, ValidarAprobacionUser(1));
                    //sUtility.VerificarGridView(gvwUsuarioGrupoSeleccionado, ValidarAprobacionUser(2));
                }

                CargarImagen();
            }
        }

        protected void CargarImagen()
        {
            imgBuscar.ImageUrl = _UrlImagen + "img_Usuario_" + (imgBuscar.Enabled ? "A" : "I") + ".jpg";
            imgBuscar0.ImageUrl = _UrlImagen + "img_Buscar_" + (imgBuscar0.Enabled ? "A" : "I") + ".jpg";
        }

        protected void imgBuscar0_Click(object sender, ImageClickEventArgs e)
        {
            if (txtBuscarPersona.Text.Length > 0)
            {
                GestionController UsuarioPerController = new GestionController();
                eUsuario eUsuario = new eUsuario();
                IList<eUsuario> UsuPer = new List<eUsuario>();

                eUsuario.NombPers = txtBuscarPersona.Text;

                UsuPer = UsuarioPerController.GetListaUsuarioGrupo(eUsuario);

                sUtility.CargarGridView(gvwUsuarioGrupo, UsuPer, ValidarAprobacionUser(1));
            }
            else
            {
                sUtility.MensajeAlerta(imgBuscar0, "Ingrese criterio a buscar");
            }
        } 

        protected void gvwUsuarioGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ValidarCantidadUser())
            {
                if (gvwUsuarioGrupo.Rows.Count > 0)
                {
                    int sRows = gvwUsuarioGrupo.SelectedIndex;

                    bool sPermitir = true;
                    DataTable TempGvw = new DataTable();
                    DataRow TemDr;
                    TempGvw.Columns.Add("Codigo");
                    TempGvw.Columns.Add("IdeUsuario");
                    TempGvw.Columns.Add("CodigoPersona");
                    TempGvw.Columns.Add("NombPers");
                    TempGvw.Columns.Add("DescCarg");
                    TempGvw.Columns.Add("Autorizar", typeof(Boolean));

                    if (sRows > -1)
                    {
                        TemDr = TempGvw.NewRow();

                        TemDr[0] = Convert.ToInt32(gvwUsuarioGrupo.Rows[sRows].Cells[0].Text);
                        TemDr[1] = gvwUsuarioGrupo.Rows[sRows].Cells[1].Text;
                        TemDr[2] = Convert.ToInt32(gvwUsuarioGrupo.Rows[sRows].Cells[2].Text);
                        TemDr[3] = gvwUsuarioGrupo.Rows[sRows].Cells[3].Text;
                        TemDr[4] = gvwUsuarioGrupo.Rows[sRows].Cells[4].Text; 
                        TemDr[5] = false;

                        for (int i = 0; i < gvwUsuarioGrupoSeleccionado.Rows.Count; i++)
                        {
                            if (!gvwUsuarioGrupoSeleccionado.Rows[i].Cells[0].Text.Equals("&nbsp;"))
                            {
                                if (gvwUsuarioGrupo.Rows[sRows].Cells[1].Text == gvwUsuarioGrupoSeleccionado.Rows[i].Cells[1].Text)
                                    TemDr[5] = ((CheckBox)gvwUsuarioGrupoSeleccionado.Rows[i].FindControl("cbxAutorizar")).Checked;
                            }
                        }

                        TempGvw.Rows.Add(TemDr);
                    }

                    for (int i = 0; i < gvwUsuarioGrupoSeleccionado.Rows.Count; i++)
                    {
                        if (!gvwUsuarioGrupoSeleccionado.Rows[i].Cells[0].Text.Equals("&nbsp;"))
                        {
                            if (gvwUsuarioGrupo.Rows[sRows].Cells[1].Text == gvwUsuarioGrupoSeleccionado.Rows[i].Cells[1].Text)
                                sPermitir = false;
                            

                            if (sPermitir)
                            {
                                TemDr = TempGvw.NewRow();

                                TemDr[0] = Convert.ToInt32(gvwUsuarioGrupoSeleccionado.Rows[i].Cells[0].Text);
                                TemDr[1] = gvwUsuarioGrupoSeleccionado.Rows[i].Cells[1].Text;
                                TemDr[2] = Convert.ToInt32(gvwUsuarioGrupoSeleccionado.Rows[i].Cells[2].Text);
                                TemDr[3] = gvwUsuarioGrupoSeleccionado.Rows[i].Cells[3].Text;
                                TemDr[4] = gvwUsuarioGrupoSeleccionado.Rows[i].Cells[4].Text;
                                TemDr[5] = ((CheckBox)gvwUsuarioGrupoSeleccionado.Rows[i].FindControl("cbxAutorizar")).Checked;

                                TempGvw.Rows.Add(TemDr);
                            }
                        }

                        sPermitir = true;
                    }

                    sUtility.CargarGridView(gvwUsuarioGrupoSeleccionado, TempGvw, ValidarAprobacionUser(2));

                }
            }
            else
            {
                sUtility.MensajeAlerta(gvwUsuarioGrupo, "Solo esta permitido seleccionar " + hdnCantidadUser.Value + " usuario(s).");
            }
            ScrollGrid(gvwUsuarioGrupo);
        }

        protected void gvwUsuarioGrupoSeleccionado_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sRows = gvwUsuarioGrupoSeleccionado.SelectedIndex;

            if (sRows > -1)
            {
                DataTable TempGvw = new DataTable();
                DataRow TemDr;
                TempGvw.Columns.Add("Codigo");
                TempGvw.Columns.Add("IdeUsuario");
                TempGvw.Columns.Add("CodigoPersona");
                TempGvw.Columns.Add("NombPers");
                TempGvw.Columns.Add("DescCarg");
                TempGvw.Columns.Add("Autorizar", typeof(Boolean));

                for (int i = 0; i < gvwUsuarioGrupoSeleccionado.Rows.Count; i++)
                {
                    if (i != sRows)
                    {
                        TemDr = TempGvw.NewRow();
                        TemDr[0] = gvwUsuarioGrupoSeleccionado.Rows[i].Cells[0].Text;
                        TemDr[1] = gvwUsuarioGrupoSeleccionado.Rows[i].Cells[1].Text;
                        TemDr[2] = gvwUsuarioGrupoSeleccionado.Rows[i].Cells[2].Text;
                        TemDr[3] = gvwUsuarioGrupoSeleccionado.Rows[i].Cells[3].Text;
                        TemDr[4] = gvwUsuarioGrupoSeleccionado.Rows[i].Cells[4].Text;
                        TemDr[5] = false;
                        TempGvw.Rows.Add(TemDr);
                    }
                }

                sUtility.CargarGridView(gvwUsuarioGrupoSeleccionado, TempGvw, ValidarAprobacionUser(2));
            }
            ScrollGrid(gvwUsuarioGrupoSeleccionado);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            mpeAdjuntar.Hide();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            RetornarUsuarioSelect();
            MostrarPopup(false);
        }

        protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
        {
            MostrarPopup(true);
        }

        protected void ibt_close_Click(object sender, ImageClickEventArgs e)
        {
            MostrarPopup(false);
        }

        protected void RetornarUsuarioSelect()
        {
            string sLoginUser = string.Empty;

            for (int i = 0; i < gvwUsuarioGrupoSeleccionado.Rows.Count; i++)
            {
                sLoginUser = sLoginUser + gvwUsuarioGrupoSeleccionado.Rows[i].Cells[1].Text + "; ";
            }

            txtUsuarios.Text = sLoginUser;
        }

        protected void CargarUsuarioInsert(IList<eUsuario> gvwUsuarioInsert)
        {
            if (gvwUsuarioInsert.Count > 0)
            {
                bool sPermitir = true;
                DataTable TempGvw = new DataTable();
                DataRow TemDr;
                TempGvw.Columns.Add("Codigo");
                TempGvw.Columns.Add("IdeUsuario");
                TempGvw.Columns.Add("CodigoPersona");
                TempGvw.Columns.Add("NombPers");
                TempGvw.Columns.Add("DescCarg");
                TempGvw.Columns.Add("Autorizar", typeof(Boolean));

                TemDr = TempGvw.NewRow();

                TemDr[0] = Convert.ToInt32(gvwUsuarioInsert[0].Codigo);
                TemDr[1] = gvwUsuarioInsert[0].IdeUsuario;
                TemDr[2] = gvwUsuarioInsert[0].Codigo;                                                  //Convert.ToInt32(gvwUsuarioInsert[0].CodigoPersona);
                TemDr[3] = gvwUsuarioInsert[0].IdeUsuario + " - " + gvwUsuarioInsert[0].Pers.NombPers + " " + gvwUsuarioInsert[0].Pers.ApePers;  //gvwUsuarioInsert[0].NombPers + " " + gvwUsuarioInsert[0].ApePers;
                TemDr[4] = gvwUsuarioInsert[0].DescCarg;
                TemDr[5] = (gvwUsuarioInsert[0].Participante == null ? false : (gvwUsuarioInsert[0].Participante.ApruOper == "S" ? true : false));

                TempGvw.Rows.Add(TemDr);
                
                for (int i = 0; i < gvwUsuarioGrupoSeleccionado.Rows.Count; i++)
                {
                    if (!gvwUsuarioGrupoSeleccionado.Rows[i].Cells[0].Text.Equals("&nbsp;"))
                    {
                        if (gvwUsuarioInsert[0].IdeUsuario == gvwUsuarioGrupoSeleccionado.Rows[i].Cells[1].Text)
                            sPermitir = false;

                        if (sPermitir)
                        {
                            TemDr = TempGvw.NewRow();

                            TemDr[0] = Convert.ToInt32(gvwUsuarioGrupoSeleccionado.Rows[i].Cells[0].Text);
                            TemDr[1] = gvwUsuarioGrupoSeleccionado.Rows[i].Cells[1].Text;
                            TemDr[2] = Convert.ToInt32(gvwUsuarioGrupoSeleccionado.Rows[i].Cells[2].Text);
                            TemDr[3] = gvwUsuarioGrupoSeleccionado.Rows[i].Cells[3].Text;
                            TemDr[4] = gvwUsuarioGrupoSeleccionado.Rows[i].Cells[4].Text;
                            TemDr[5] = ((CheckBox)gvwUsuarioGrupoSeleccionado.Rows[i].FindControl("cbxAutorizar")).Checked;

                            TempGvw.Rows.Add(TemDr);
                        }
                    }

                    sPermitir = true;
                }

                sUtility.CargarGridView(gvwUsuarioGrupoSeleccionado, TempGvw, ValidarAprobacionUser(2));

            }
        }

        protected void MostrarPopup(bool sMostOcul)
        {
            if (sMostOcul)
            {
                divPopup.Attributes["class"] = "PopupMostrar";
                mpeAdjuntar.Show();
            }
            else
            {
                divPopup.Attributes["class"] = "PopupOcultar";
                mpeAdjuntar.Hide();
            }
        }

        protected bool ValidarCantidadUser()
        {
            bool sPermitirUser = true;
            
            if (Convert.ToInt16(hdnCantidadUser.Value) > 0)
                if (gvwUsuarioGrupoSeleccionado.Rows.Count >= Convert.ToInt16(hdnCantidadUser.Value))
                    if (!gvwUsuarioGrupoSeleccionado.Rows[0].Cells[0].Text.Equals("&nbsp;"))
                        sPermitirUser = false;    
                    
            return sPermitirUser;
        }

        protected int[] ValidarAprobacionUser(int sTypeGriw)
        {
            int[] sIndexGV1 = {0, 1, 2};
            int[] sIndexGV2 = { 0, 1, 2, 5 };
            int[] sIndexGV;

            switch (sTypeGriw)
            {
                case 1 :
                    sIndexGV = sIndexGV1;
                    break;

                case 2 :
                    sIndexGV = (Convert.ToBoolean(hdnAprobacionUser.Value)) ? sIndexGV1 : sIndexGV2;
                    break;

                default:
                    sIndexGV = sIndexGV1;
                    break;
            }

            return sIndexGV;
        }

        protected IList<eUsuario> CargarUsuarioSession()
        {
            IList<eUsuario> UsuPer = new List<eUsuario>();

            if (sUtility.VerificarSessionUsuario(gvwUsuarioGrupo))
            {

                GestionController DocElectController = new GestionController();
                eUsuario eUsuario = new eUsuario();

                eUsuario.Codigo = Convert.ToInt64(Session["sCodUsu"].ToString());
                eUsuario.IdeUsuario = "";
                UsuPer = sUtility.GetListaUsuarioPer(eUsuario, true);                
            }
            return UsuPer;
        }

        public GridView UsuarioSelect
        {
            get
            {
                return gvwUsuarioGrupoSeleccionado;
            }
        }

        public IList<eUsuario> UsuarioInsert
        {
            set 
            {
                CargarUsuarioInsert(value);
                RetornarUsuarioSelect();
            }
        }

        public int WithTexto
        {
            set
            {
                tdUser.Width = value.ToString() + "%";
                txtUsuarios.Width = Unit.Percentage(value);
            }
        }

        public bool EnabledControl
        {
            set
            {
                imgBuscar.Enabled = value;
            }
        }

        public int CantidadUser
        {
            set
            {
                hdnCantidadUser.Value = value.ToString();
            }
        }

        public bool AprobacionUser
        {
            set
            {
                hdnAprobacionUser.Value = value.ToString();
            }
        }

        public bool UserSesion
        {
            set
            {
                if (value)
                {
                    imgBuscar.Enabled = false;
                    CargarUsuarioInsert(CargarUsuarioSession());
                    RetornarUsuarioSelect();
                    
                }
            }
        }

        public bool LimpiarControl
        {
            set
            {
                if (value)
                {
                    gvwUsuarioGrupo.DataSource = null;
                    gvwUsuarioGrupo.DataBind();
                    //sUtility.VerificarGridView(gvwUsuarioGrupo, ValidarAprobacionUser(1));

                    gvwUsuarioGrupoSeleccionado.DataSource = null;
                    gvwUsuarioGrupoSeleccionado.DataBind();
                    //sUtility.VerificarGridView(gvwUsuarioGrupoSeleccionado, ValidarAprobacionUser(2));

                    txtUsuarios.Text = "";
                }
            }
        }

        public string TituloControl
        {
            set
            {
                lblTituloControl.Text = value;
            }
        }

        public string UserText
        {
            get
            {
                return txtUsuarios.Text;
            }
        }

        public string UserModeText
        {
            set 
            {
                if (value == "MultiLine")
                {
                    txtUsuarios.CssClass = "multiline";
                    txtUsuarios.TextMode = TextBoxMode.MultiLine;
                    imgBuscar.ImageUrl = _UrlImagen + "img_UsuarioAll_" + (imgBuscar.Enabled ? "A" : "I") + ".jpg";
                }
                else
                {
                    txtUsuarios.CssClass = "textbox";
                    txtUsuarios.TextMode = TextBoxMode.SingleLine;
                    imgBuscar.ImageUrl = _UrlImagen + "img_Usuario_" + (imgBuscar.Enabled ? "A" : "I") + ".jpg"; 
                }
            }
        }

        public void ScrollGrid(GridView gvwUsuarioGrupo)
        {
            int intScrollTo = gvwUsuarioGrupo.SelectedIndex * 15;
            string strScript = string.Empty;
            strScript += "var gridView = document.getElementById('" + gvwUsuarioGrupo.ClientID + "');\n";
            strScript += "if (gridView != null && gridView.parentElement != null && gridView.parentElement.parentElement != null)\n";
            strScript += "  gridView.parentElement.parentElement.scrollTop = " + intScrollTo + ";\n";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "ScrollGrid", strScript, true);
        }              
    }
}