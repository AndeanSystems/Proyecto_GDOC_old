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
using System.Drawing;
using System.IO;

namespace WebGdoc.WebPage.Inicio
{
    public partial class frmCambiaFirmaElec : WebGdoc.Resources.Utility
    {
#region Variables



#endregion

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
                CargarImagenFirma();
            }
        }

        protected void CargarImagen()
        {
            ibtnGuardar.ImageUrl = _UrlImagen + "img_Guardar_" + (ibtnGuardar.Enabled ? "A" : "I") + ".jpg";
            ibtnRegresar.ImageUrl = _UrlImagen + "img_Inicio_" + (ibtnRegresar.Enabled ? "A" : "I") + ".jpg";
            imgCambioFirma.Src = _UrlImagen + "img_Firma_Electronica_" + (ibtnRegresar.Enabled ? "A" : "I") + ".jpg";
        }

        protected void CargarImagenFirma()
        {
            string _UrlImagen = "~/Resources/Imagenes/";
            string sRutaFTP = ConfigurationManager.AppSettings.Get("DirectorioFTP");
            string sFilename = Session["sUsuario"].ToString() + ".jpg";
            string sDirectorio = "FirmaUsers";
            string sSavePath = sRutaFTP + "\\" + sDirectorio + "\\";

            if (System.IO.File.Exists(sSavePath + sFilename))
            {
                imgPicture.ImageUrl = "~/WebPage/Digitalizacion/TmpVisor/FirmaUsers/" + sFilename;
            }
            else
            {
                imgPicture.ImageUrl = _UrlImagen + "img_Transparent_A.gif";
            }
        }
          
        protected void ibtnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            Int64 oReturn = 0;
            Int64 sUserSession = Convert.ToInt64(Session["sCodUsu"].ToString());
            string sPageInicio = "../Inicio/frmEscritorioVirtual.aspx";

            if (txtFirmaActual.Text != "")
            {
                if (txtFirmaActual.Text == lblFirm.Text)
                {
                    if (valida_FirmaE())
                        oReturn = EstadoUsuarioPer(2, sUserSession, 0, string.Empty, txtNuevaFirma.Text);
                }else
                    MensajeAlerta(ibtnGuardar, "La Firma Electronica actual ingresa no coincide con la del sistema");
            }

            if (oReturn > 0)
                MensajeAlerta(ibtnGuardar, "Su Firma Electronica se actualizo con exito.", sPageInicio);

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
                
                lblFirm.Text = User[0].FirmaElectronica;
            }
        }
       
        protected bool valida_FirmaE()
        {
            bool Veri = false;

            if (txtFirmaActual.Text != txtNuevaFirma.Text)
            {
                if (txtNuevaFirma.Text == "" || txtRepiteFirma.Text == "")
                {
                    MensajeAlerta(ibtnGuardar, "La Firma Electronica no puede tener valores en blanco");
                }
                else
                {
                    if (txtNuevaFirma.Text == txtRepiteFirma.Text)
                        Veri = true;
                    else
                        MensajeAlerta(ibtnGuardar, "La Firma Electronica ingresada no coincide");
                }
            }
            else
                MensajeAlerta(ibtnGuardar, "La nueva Firma Electronica no puede ser igual a la anterior");

            return Veri;
        }  
        protected void cargarImagen_Click(object sender, ImageClickEventArgs e)
        {
            // Initialize variables
            string sSavePath;           
            int intThumbWidth;
            int intThumbHeight;
            string sThumbExtension;

            // Set constant values
            sSavePath = string.Empty;
            intThumbWidth = 200;
            intThumbHeight = 100;
            sThumbExtension = "_thumb";
            string sRutaFTP = ConfigurationManager.AppSettings.Get("CarpetaTMP");
            string sDirectorio = "FirmaUsers";
            sSavePath = sRutaFTP + "\\" + sDirectorio + "\\";

            if (!Directory.Exists(sSavePath))
                Directory.CreateDirectory(sSavePath);
 
            // If file field isn’t empty
            if (uplServerFTP.PostedFile != null)
            {
                // Check file size (mustn’t be 0)
                HttpPostedFile myFile = uplServerFTP.PostedFile;
                int nFileLen = myFile.ContentLength;
                if (nFileLen == 0)
                {                       
                    MensajeAlerta(ibtnGuardar, "No hubo ningún archivo cargado");
                    return;
                }

                // Check file extension (must be JPG)
                if (System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".jpg")
                {                       
                    MensajeAlerta(ibtnGuardar, "El archivo deber tener una extensión JPG");
                    return;
                }
                                                                           
                string sFilename = Session["sUsuario"].ToString() + ".jpg";
                try
                {   // Read file into a data stream
                    byte[] myData = new Byte[nFileLen];
                    myFile.InputStream.Read(myData, 0, nFileLen);

                    // Make sure a duplicate file doesn’t exist.  If it does, keep on appending an incremental numeric until it is unique                   
                    if (System.IO.File.Exists(sSavePath + sFilename))
                    {
                        System.IO.File.Delete(sSavePath + sFilename);
                    }

                    // Save the stream to disk
                    System.IO.FileStream newFile = new System.IO.FileStream(sSavePath + sFilename, System.IO.FileMode.Create);
                    newFile.Write(myData, 0, myData.Length);
                    newFile.Close();
                    imgPicture.ImageUrl = "~/WebPage/Digitalizacion/TmpVisor/FirmaUsers/" + sFilename + "?" + Guid.NewGuid().ToString();

                    // Displaying success information
                    MensajeAlerta(ibtnGuardar, "El archivo fue cargado exitosamente");       
                }
                catch (Exception)
                {                       
                    MensajeAlerta(ibtnGuardar, "Error al guardar archivo.");
                    return;
                }    
            }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }
    }
}
