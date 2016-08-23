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
    public partial class frmGrupo : WebGdoc.Resources.Utility
    {
        string UserCrea = "ANDSYS";
        DataTable TempGvw = new DataTable();
        DataRow TemDr;
        string sPageLocal = "../Configuracion/frmGrupo.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (VerificarSessionUsuario(tbPrincipal))
            {
                if (!IsPostBack)
                {
                    Session.Remove("sURLActual");
                    Session.Add("sURLActual", Request.Url.ToString());

                    ConfigurarBarraHerramientas();
                    ListaGrupo();
                }

                CargarImagen();
            }
        }

        protected void CargarImagen()
        {
            ibtnNuevo.ImageUrl = _UrlImagen + "img_Nuevo_" + (ibtnNuevo.Enabled ? "A" : "I") + ".jpg";
            ibtnGuardar.ImageUrl = _UrlImagen + "img_Guardar_" + (ibtnGuardar.Enabled ? "A" : "I") + ".jpg";
            ibtnEliminar.ImageUrl = _UrlImagen + "img_Eliminar_" + (ibtnEliminar.Enabled ? "A" : "I") + ".jpg";
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
            ReferenciarTitulo(this, "Grupos");
            //ReferenciarLink(this, sLstLink);
        }

        protected void ibtnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            Limpiar_Control();
            lblCod.Text = "";
            txtGrupo.Enabled = true;
        }

        protected Int64 Mantenimiento_GrupoUser(Int64 iCodUsuGrupo, Int64 iCodGrupo, ValidarUsuario_Grupo ctlUsuario, string sEstado)
        {
            GestionController GrupoUserController = new GestionController();
            eUsuarioGrupo CtrGUser = new eUsuarioGrupo();
            Int64 oReturn = 0;
            Int64 sCodUsuario = 0;

            GridView sUserSelect = ctlUsuario.UsuarioSelect;
            for (int i = 0; i < sUserSelect.Rows.Count; i++)
            {
                sCodUsuario = Convert.ToInt64(sUserSelect.Rows[i].Cells[0].Text);
                CtrGUser.CodiUsuGrup = 0;
                CtrGUser.Usuario = new eUsuario { Codigo = sCodUsuario };
                CtrGUser.Grupo = new eGrupo { CodiGrup = iCodGrupo };
                CtrGUser.UsuCrea = UserCrea;
                CtrGUser.FechCrea = System.DateTime.Now;
                CtrGUser.EstUsuGrup = sEstado;

                oReturn = GrupoUserController.SetGrupoUserAdd(CtrGUser);


            }
            return oReturn;
        }

        protected void Mantenimiento_Grupo(Int64 CodGrupo, string sEstado)
        {
            GestionController GrupoController = new GestionController();
            eGrupo CtrGrupo = new eGrupo();
            Int64 oReturn = 0;
            CtrGrupo.CodiGrup = CodGrupo;
            CtrGrupo.NombGrup = txtGrupo.Text;
            CtrGrupo.FechCrea = System.DateTime.Now;
            CtrGrupo.UsuCrea = UserCrea;
            CtrGrupo.ComeGrup = txtComentario.Text;
            CtrGrupo.EstGrup = sEstado;

            oReturn = GrupoController.SetGrupoAdd(CtrGrupo);
            if (oReturn > 0)
            {
                lblCodGrup.Text = CtrGrupo.CodiGrup.ToString();

            }
            //return oReturn;
        }

        protected void ListaGrupo()
        {
            GestionController GestController = new GestionController();
            eUsuarioGrupo CtrUserG = new eUsuarioGrupo();
            IList<eUsuarioGrupo> UserG = new List<eUsuarioGrupo>();

            string Cadena = string.Empty;

            CtrUserG.Grupo = new eGrupo
            {
                CodiGrup = 0,
                NombGrup = ""
            };

            UserG = GestController.GetUsuarioGrupo(CtrUserG);

            if (UserG.Count > 0)
            {
                TempGvw.Columns.Add("sCodGrupo");
                TempGvw.Columns.Add("sNomGrupo");
                TempGvw.Columns.Add("sParticipante");
                TempGvw.Columns.Add("sEstado");
                for (int i = 0; i < UserG.Count; i++)
                {
                    TemDr = TempGvw.NewRow();
                    if (Cadena != UserG[i].Grupo.NombGrup.ToString())
                    {
                        TemDr[0] = UserG[i].Grupo.CodiGrup;
                        Cadena = UserG[i].Grupo.NombGrup.ToString();
                        TemDr[1] = UserG[i].Grupo.NombGrup;
                        TemDr[2] = ReturnUsuaPart(UserG[i].Grupo.CodiGrup);
                        TemDr[3] = UserG[i].Grupo.EstGrup;
                        TempGvw.Rows.Add(TemDr);
                    }
                }
            }
            gvwGrupos.DataSource = TempGvw;
            gvwGrupos.DataBind();
            TempGvw.Clear();
        }

        protected string ReturnUsuaPart(Int64 CodGrupo)
        {
            IList<eUsuario> LstReturnUser = new List<eUsuario>();
            eUsuario UserCriteria = new eUsuario();
            GestionController GestController = new GestionController();
            eUsuarioGrupo CtrUserG = new eUsuarioGrupo();
            IList<eUsuarioGrupo> UserG = new List<eUsuarioGrupo>();

            string oCadena = string.Empty;


            CtrUserG.Grupo = new eGrupo
            {
                CodiGrup = 0,
                NombGrup = ""
            };

            UserG = GestController.GetUsuarioGrupo(CtrUserG);
            if (UserG.Count > 0)
            {
                for (int x = 0; x < UserG.Count; x++)
                {
                    if (UserG[x].Grupo.CodiGrup == CodGrupo)
                    {
                        UserCriteria.Codigo = UserG[x].Usuario.Codigo;
                        LstReturnUser = GetListaUsuarioPer(UserCriteria, true);
                        if (LstReturnUser.Count > 0)
                        {
                            for (int i = 0; i < LstReturnUser.Count; i++)
                            {
                                if (oCadena == "")
                                { oCadena = LstReturnUser[i].IdeUsuario; }
                                else { oCadena = oCadena + "; " + LstReturnUser[i].IdeUsuario; }
                            }
                        }
                    }
                }
            }

            return oCadena;
        }

        protected void ibtnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            Int64 oReturn = 0;
            if (ValidarCamposObligatorios())
            {
                if (txtGrupo.Enabled != true)
                {
                    Mantenimiento_Grupo(Convert.ToInt64(lblCod.Text), "A");
                    AnulaUserGrupo(0, Convert.ToInt64(lblCodGrup.Text));
                    oReturn = Mantenimiento_GrupoUser(0, Convert.ToInt64(lblCod.Text), ct1UserPart, "A");
                    if (oReturn > 0)
                    {
                        ListaGrupo();
                        txtGrupo.Enabled = true;
                        lblCod.Text = "";
                        MensajeAlerta(ibtnGuardar, "El grupo : " + txtGrupo.Text + " fue actualizado con exito", sPageLocal);
                    }
                }
                else
                {

                    Mantenimiento_Grupo(0, "A");
                    oReturn = Mantenimiento_GrupoUser(0, Convert.ToInt64(lblCodGrup.Text), ct1UserPart, "A");
                    if (oReturn > 0)
                    {
                        ListaGrupo();
                        txtGrupo.Enabled = true;
                        lblCod.Text = "";
                        MensajeAlerta(ibtnGuardar, "El grupo : " + txtGrupo.Text + " fue generado con exito", sPageLocal);
                    }
                }
            }
            else
                MensajeAlerta(ibtnGuardar, "Los datos ingresados no son correctos o estan incompletos");
        }

        protected void ibtnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            if (lblCod.Text != "")
            {
                Mantenimiento_Grupo(Convert.ToInt64(lblCod.Text), "N");
                AnulaUserGrupo(0, Convert.ToInt64(lblCodGrup.Text));
                ListaGrupo();
                Limpiar_Control();
                lblCod.Text = "";
            }
            else
            {
                MensajeAlerta(ibtnEliminar, "Seleccione el grupo que desea eliminar");
            }
        }

        protected void ibtnRegresar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void gvwGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GestionController GestController = new GestionController();
            eUsuarioGrupo CtrUserG = new eUsuarioGrupo();
            IList<eUsuarioGrupo> UserG = new List<eUsuarioGrupo>();

            int sRows = gvwGrupos.SelectedIndex;
            //;
            CtrUserG.Grupo = new eGrupo
            {
                CodiGrup = Convert.ToInt64(gvwGrupos.DataKeys[sRows].Value.ToString()),
                NombGrup = ""
            };
            lblCod.Text = gvwGrupos.DataKeys[sRows].Value.ToString();
            UserG = GestController.GetUsuarioGrupo(CtrUserG);

            if (UserG.Count > 0)
            {
                txtGrupo.Text = UserG[0].Grupo.NombGrup;
                ReturnUsuaGrupo(UserG[0].Grupo.CodiGrup, ct1UserPart);
                txtComentario.Text = UserG[0].Grupo.ComeGrup;
                txtGrupo.Enabled = false;
            }
        }

        protected void ReturnUsuaGrupo(Int64 CodGrupo, ValidarUsuario_Grupo ctlUsuarioValido)
        {
            GestionController GestCon = new GestionController();
            eUsuario ReturnUser = new eUsuario();
            IList<eUsuario> LstReturnUser = new List<eUsuario>();
            eUsuario UserCriteria = new eUsuario();
            eUsuarioGrupo CtrUserG = new eUsuarioGrupo();
            IList<eUsuarioGrupo> UserG = new List<eUsuarioGrupo>();

            int sRows = gvwGrupos.SelectedIndex;
            //;
            LimpiarControles(ctlUsuarioValido);
            CtrUserG.Grupo = new eGrupo
            {
                CodiGrup = CodGrupo,
                NombGrup = ""
            };

            UserG = GestCon.GetUsuarioGrupo(CtrUserG);

            for (int i = 0; i < UserG.Count; i++)
            {

                UserCriteria.Codigo = UserG[i].Usuario.Codigo;
                LstReturnUser = GetListaUsuarioPer(UserCriteria, true);
                ctlUsuarioValido.UsuarioInsert = LstReturnUser;

            }
        }

        protected void AnulaUserGrupo(Int64 iCodUsuGrupo, Int64 iCodGrupo)
        {
            GestionController GestCon = new GestionController();
            eUsuarioGrupo CtrGUser = new eUsuarioGrupo();
            Int64 oReturn = 0;
            CtrGUser.Usuario = new eUsuario { Codigo = iCodUsuGrupo };
            CtrGUser.Grupo = new eGrupo { CodiGrup = iCodGrupo };
            oReturn = GestCon.SetGrupoUserAnula(CtrGUser);
        }

        protected void Limpiar_Control()
        {
            LimpiarControles(txtComentario);
            LimpiarControles(txtGrupo);
            LimpiarControles(ct1UserPart);
        }

        protected void txtGrupo_TextChanged(object sender, EventArgs e)
        {
            GestionController GestController = new GestionController();
            eUsuarioGrupo CtrUserG = new eUsuarioGrupo();
            IList<eUsuarioGrupo> UserG = new List<eUsuarioGrupo>();


            CtrUserG.Grupo = new eGrupo
            {
                CodiGrup = 0,
                NombGrup = txtGrupo.Text
            };

            UserG = GestController.GetUsuarioGrupo(CtrUserG);

            if (UserG.Count > 0)
            {
                lblCod.Text = UserG[0].Grupo.CodiGrup.ToString();
                txtGrupo.Text = UserG[0].Grupo.NombGrup;
                ReturnUsuaGrupo(UserG[0].Grupo.CodiGrup, ct1UserPart);
                txtComentario.Text = UserG[0].Grupo.ComeGrup;
                txtGrupo.Enabled = false;
            }
            else
            {
                MensajeAlerta(txtGrupo, "No se encontro el Grupo: " + txtGrupo.Text);
            }
        }

        protected bool ValidarCamposObligatorios()
        {
            bool sValidar = true;

            if (sValidar)
                sValidar = VerificarTipoDato(txtGrupo, "Len");

            if (sValidar)
                sValidar = VerificarTipoDato(txtComentario, "Len");

            if (sValidar)
                sValidar = VerificarTipoDato(ct1UserPart, "Len");

            return sValidar;
        }
    }
}
