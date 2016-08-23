<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Inicio/mpFEPCMAC.Master"
    AutoEventWireup="true" CodeBehind="frmCambiarClave.aspx.cs" Inherits="WebGdoc.WebPage.Inicio.frmCambiarClave" %>

<%@ Register src="../Controles/ValidarUsuario_Grupo.ascx" tagname="ValidarUsuario_Grupo" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
   <table class="BarraHerramientas" cellpadding="0" cellspacing="0">
        <tr>
            <td class="TituloPagina">
                &nbsp; &nbsp;
                <asp:Label runat="server" ID="lblTituloPagina" Text="Cambiar Contraseña" />
            </td>
            
            <td class="AccesoDirecto">        
                <asp:ImageButton runat="server" ID="ibtnGuardar"  AlternateText="Guardar" CssClass='LinkURL' 
                    onclick="ibtnGuardar_Click" OnClientClick="return confirm('Desea Actualizar la contraseña');"/>  
                
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
                            <td valign="top" style="width:50%" >
                                <asp:Panel ID="Panel3" runat="server" CssClass="panel" GroupingText="Contraseña">
                                    <table>
                                        <tr>
                                            <td rowspan="3">
                                                <img runat="server" id="imgCambioClave" class="imagenFirma"/>
                                            </td>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblPassActual" runat="server" Text="Contraseña Actual:" CssClass="label"/>
                                            </td>
                                            <td style="width:190px">
                                                <asp:TextBox ID="txtPassAct" runat="server" CssClass="textboxSegurity" TextMode="Password" MaxLength="15"/>
                                            </td>                                            
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblNuevoPass" runat="server" Text="Nueva Contraseña:" CssClass="label"/>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNuevoPass" runat="server" CssClass="textboxSegurity" TextMode="Password" MaxLength="15"/>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblRepitePass" runat="server" Text="Repetir Contraseña:" CssClass="label"/>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRepitePass" runat="server" CssClass="textboxSegurity" TextMode="Password" MaxLength="15"/>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>                          

                           
                        </tr>
                    </table>
                </td>
            </tr>
             
        </table>     
        <asp:Label ID="lblPass" runat="server"  CssClass="label" Visible ="false"/>
        <asp:Label ID="lblFirm" runat="server"  CssClass="label" Visible ="false"/>     
  </div>
</asp:Content>
