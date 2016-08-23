<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Inicio/mpFEPCMAC.Master"
    AutoEventWireup="true" CodeBehind="frmCambiaFirmaElec.aspx.cs" Inherits="WebGdoc.WebPage.Inicio.frmCambiaFirmaElec" %>
<%@ OutputCache Location="None" VaryByParam="None" Duration="1"%>

<%@ Register src="../Controles/ValidarUsuario_Grupo.ascx" tagname="ValidarUsuario_Grupo" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .style1
        {
            width: 170px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
   <table class="BarraHerramientas" cellpadding="0" cellspacing="0">
        <tr>
            <td class="TituloPagina">
                &nbsp; &nbsp;
                <asp:Label runat="server" ID="lblTituloPagina" 
                    Text="Cambiar Firma Electronica" />
            </td>
            
            <td class="AccesoDirecto">        
                <asp:ImageButton runat="server" ID="ibtnGuardar"  AlternateText="Guardar" CssClass='LinkURL' 
                    onclick="ibtnGuardar_Click" OnClientClick="return confirm('Desea Actualizar la Firma Electronica');"/>  
                
               <asp:ImageButton runat="server" ID="ibtnRegresar" AlternateText="Regresar" CssClass='LinkURL' onclick="ibtnRegresar_Click" />            
                &nbsp; &nbsp;                                
            </td>
        </tr>
    </table>
   
  <div>  
        <table runat="server" id="tbPrincipal" class="Principal">
            <tr>
                <td align="left" valign="top">
                    <table style="width:100%">
                        <tr>                                        
                            <td valign="top">
                                <asp:Panel runat="server" CssClass="panel" GroupingText ="Firma Electronica">
                                    <table>
                                        <tr>
                                            <td rowspan="3">
                                                <img runat="server" id="imgCambioFirma" class="imagenFirma"/>
                                            </td>
                                            <td class="FondoEtiqueta3">
                                                <asp:Label ID="lblFirmaActual" runat="server" Text="Firma Electronica Actual:" CssClass="label"/>
                                            </td>
                                            <td style="width:190px">
                                                <asp:TextBox ID="txtFirmaActual" runat="server" CssClass="textboxSegurity" TextMode="Password" MaxLength="15"/>
                                            </td>
                                        
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblElegirArch" runat="server" Text="Elegir Archivo:" CssClass="label"/>
                                            </td>
                                            <td style="width:300px">
                                                <asp:FileUpload ID="uplServerFTP" runat="server" class="examinar" />
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="cargarImagen" runat="server" CssClass="imagen" 
                                                    ImageUrl="~/Resources/Imagenes/img_CargarArchivo_A.jpg" 
                                                    onclick="cargarImagen_Click" ToolTip="Cargar Documento" />
                                            </td>                                            
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta3">
                                                <asp:Label ID="lblNuevaFirma" runat="server" Text="Nueva Firma Electronica:" CssClass="label"/>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNuevaFirma" runat="server" CssClass="textboxSegurity" TextMode="Password" MaxLength="15"/>
                                            </td>
                                            <td class="style1">
                                                &nbsp;</td>
                                            <td class="style1" rowspan="3">
                                                <asp:Image ID="imgPicture" runat="server" Height="100px" Width="200px" />
                                            </td>
                                            <td class="style1">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta3">
                                                <asp:Label ID="lblRepiteFirma" runat="server" Text="Repetir Firma Electronica:" CssClass="label"/>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRepiteFirma" runat="server" CssClass="textboxSegurity" TextMode="Password" MaxLength="15"/>
                                            </td>
                                            <td class="style1">
                                                &nbsp;</td>
                                            <td class="style1">
                                                &nbsp;</td>
                                        </tr> 
                                        <tr>
                                            <td class="FondoEtiqueta3">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                            <td class="style1">
                                                &nbsp;</td>
                                             <td class="style1">
                                                &nbsp;</td>
                                        </tr>                    
                                    </table>                                   
                                    <asp:Label ID="lblPass" runat="server"  CssClass="label" Visible ="false"/>
                                    <asp:Label ID="lblFirm" runat="server"  CssClass="label" Visible ="false"/>                            
                                </asp:Panel>
                            </td>                            
                        </tr>
                    </table>
                </td>
            </tr>
        </table>        
  </div>
</asp:Content>
