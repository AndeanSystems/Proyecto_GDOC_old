<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Inicio/mpFEPCMAC.Master"
    AutoEventWireup="true" CodeBehind="frmAcceso.aspx.cs" Inherits="WebGdoc.WebPage.Configuracion.frmAcceso" %>

<%@ Register src="../Controles/ValidarUsuario_Grupo.ascx" tagname="ValidarUsuario_Grupo" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="BarraHerramientas"  cellpadding="0" cellspacing="0">
        <tr>
            <td class="TituloPagina">
                &nbsp; &nbsp;
                <asp:Label runat="server" ID="lblTituloPagina" Text="Acceso" />
            </td>
            
            <td class="AccesoDirecto">                                
                <asp:ImageButton runat="server" ID="ibtnGuardar"  AlternateText="Guardar" CssClass='LinkURL' onclick="ibtnGuardar_Click" OnClientClick="return confirm('Desea generar los permisos para el usuario seleccionado');"/>
                
                <asp:ImageButton runat="server" ID="ibtnRegresar" AlternateText="Regresar" CssClass='LinkURL' onclick="ibtnRegresar_Click"/> 
                &nbsp; &nbsp;                   

            </td>
        </tr>
    </table>
    
    <div>
        <table runat="server" id="tbPrincipal" class="Principal">
            <tr>
                <td>
                    <table class="FontSistema" style="width:100%">
                        <tr>
                            <td class="FondoEtiqueta1">
                                <asp:Label ID="lblUsuario" runat="server" Text="Usuario " CssClass="label" />
                            </td>
                            <td style="width:850px">
                                <uc1:ValidarUsuario_Grupo ID="ctlUser" runat="server" WithTexto="98" CantidadUser="1" AprobacionUser="false" TituloControl="Busqueda de Usuario" UserModeText="" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table border="0" cellspacing="0" cellpadding="0" style="width: 100%" class="GVHeader">
                                    <tr>
                                        <td align="center" style="width:300px;">Pagina</td>
                                        <td align="center" style="width:600px;">DireccionUrl</td>
                                        <td align="center" style="width:35px;">Habilitar</td>
                                   </tr>
                                </table>
                                <div class="divAcceso">
                                    <asp:GridView ID="gvwAcceso" runat="server" CssClass="GVPrincipal" 
                                            AutoGenerateColumns="False" DataKeyNames ="sCodigo" ShowHeader = "false">
                                        <Columns>
                                            <asp:BoundField DataField="sPagina" HeaderText="Pagina">
                                                <ItemStyle Width="300px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="sDireccionUrl" HeaderText="DireccionUrl">
                                                <ItemStyle Width="600px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="sCodigo" HeaderText="Codigo">
                                                <ItemStyle Width="0px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Habilitar">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ckbHabilita" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                                            </asp:TemplateField>
                                            
                                        </Columns>
                                        <HeaderStyle CssClass="GVHeader" />
                                        <RowStyle CssClass="GVItems" />
                                        <AlternatingRowStyle CssClass="GVItemsAlt" />
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="UserSelect" Value="-1" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
