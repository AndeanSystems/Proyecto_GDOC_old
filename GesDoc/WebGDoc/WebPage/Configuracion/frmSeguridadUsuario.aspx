<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Inicio/mpFEPCMAC.Master"
    AutoEventWireup="true" CodeBehind="frmSeguridadUsuario.aspx.cs" Inherits="WebSite.WebPage.Configuracion.frmSeguridadUsuario" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%" cellpadding="0" cellspacing="0">
        <tr>
            <td class="TituloPagina">
                &nbsp; &nbsp;
                <asp:Label runat="server" ID="lblTituloPagina" Text="Usuarios " />
            </td>
            
            <td class="AccesoDirecto">
                                
                <asp:ImageButton runat="server" ID="ibtnBuscar" AlternateText="Buscar" CssClass='LinkURL' onclick="ibtnBuscar_Click" />
                                                
                <asp:ImageButton runat="server" ID="ibtnNuevo" AlternateText="Nuevo" CssClass='LinkURL' onclick="ibtnNuevo_Click" />
            </td>
        </tr>
    </table>
    
    <div>
        <table runat="server" id="tbPrincipal" class="Principal1">
            <tr>
                <td>
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" BorderColor="Silver" BorderWidth="1"
                        CssClass="panel">
                        <table class="Principal1">
                            <tr>
                                <td align="center">
                                    <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" BorderColor="Silver" BorderWidth="1"
                                        CssClass="panel">
                                        <table class="Principal1">
                                            <tr>
                                                <td class="labelSombreadoPequenio" align="right">
                                                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                                                </td>
                                                <td colspan="5" align="left">
                                                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="textboxPequenio"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="button" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="labelSombreadoPequenio" align="right">
                                                    <asp:Label ID="lblApeMat" runat="server" Text="Ap. Materno"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtApeMat" runat="server" CssClass="textboxPequenio"></asp:TextBox>
                                                </td>
                                                <td class="labelSombreadoPequenio" align="right">
                                                    <asp:Label ID="lblApePat" runat="server" Text="Ap. Paterno"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtApePat" runat="server" CssClass="textboxPequenio"></asp:TextBox>
                                                </td>
                                                <td class="labelSombreadoPequenio" align="right">
                                                    <asp:Label ID="lblNombres" runat="server" Text="Nombres"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNombres" runat="server" CssClass="textbox"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="button" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="7">
                                                    <asp:GridView ID="gvwSeguridadUsuarios" runat="server" CssClass="GVPrincipal" AutoGenerateColumns="False">
                                                        <Columns>
                                                            <asp:BoundField DataField="sUsuario" HeaderText="Usuario">
                                                                <ItemStyle Width="120" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="sNombApell" HeaderText="Nombres y Apellidos">
                                                                <ItemStyle Width="250px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="sArea" HeaderText="Área">
                                                                <ItemStyle Width="100" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="sTipoRol" HeaderText="Tipo Rol">
                                                                <ItemStyle Width="200" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="sFecUltAcceso" HeaderText="Fecha de Último Acceso">
                                                                <ItemStyle Width="120" />
                                                            </asp:BoundField>
                                                            <asp:CommandField HeaderText="Agregar" ShowSelectButton="True" SelectText='<img runat="server" id="imgLink" src="../../Resources/Imagenes/img_AddItem_A.jpg" border="0"/>'>
                                                                <ItemStyle Width="25px" />
                                                            </asp:CommandField>
                                                            <asp:CommandField HeaderText="Editar" ShowSelectButton="True" SelectText='<img runat="server" id="imgLink" src="../../Resources/Imagenes/img_EditarItem_A.jpg" border="0"/>'>
                                                                <ItemStyle Width="25px" />
                                                            </asp:CommandField>
                                                            <asp:CommandField HeaderText="Eliminar" ShowSelectButton="True" SelectText='<img runat="server" id="imgLink" src="../../Resources/Imagenes/img_EliminarItem_A.jpg" border="0"/>'>
                                                                <ItemStyle Width="25px" />
                                                            </asp:CommandField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="GVHeader" />
                                                        <RowStyle CssClass="GVItems" />
                                                        <AlternatingRowStyle CssClass="GVItemsAlt" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="label">
                                    <asp:Label ID="lblSeguridadUsuario" runat="server" Text="Usuarios"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
