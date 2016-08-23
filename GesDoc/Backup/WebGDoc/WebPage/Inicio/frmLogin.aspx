<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Inicio/mpFEPCMAC.Master" AutoEventWireup="true" 
         CodeBehind="frmLogin.aspx.cs" Inherits="WebGdoc.WebPage.Inicio.frmLogin" %>
     
         
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">    
    .tbPrincipal
    {
        margin-top: -25px;       
    }
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Fondo">
        <center>
            <div class="Ubicacion">
                <asp:Panel ID="pnlLogin" runat="server" CssClass="panelBorder">
                    <table>
                        <tr>
                            <td colspan="6" style="height:15px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td rowspan="6" style="width:15px">&nbsp;</td>
                            <td rowspan="6"> 
                                <img runat="server" id="imgSecurity" src="~/Resources/Imagenes/Login.jpg" class="imgSecurity" />   
                            </td>
                            <td rowspan="6" style="width:15px">&nbsp;</td>
                            <td class="TextoLogin1">
                                Usuario: 
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtUsuario" CssClass="TextoLogin0" />
                            </td>
                            <td rowspan="6" style="width:15px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="TextoLogin1">
                                Contraseña: 
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtContrasena" CssClass="TextoLogin00" TextMode="Password" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="2" align="left">
                                <asp:CheckBox ID="ckbRecordarUser" runat="server" Text="Recordar su Usuario" CssClass="TextoLogin2" />
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="btnLogin" runat="server" CssClass="buttonLogin" Text="Aceptar" 
                                    onclick="btnLogin_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                <asp:HyperLink ID="PasswordRecoveryLink" runat="server" CssClass="TextoLogin3">¿Olvido su clave de acceso?</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="height:15px">&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
        </center>
    </div>
</asp:Content>
