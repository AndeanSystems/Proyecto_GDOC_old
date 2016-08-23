<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Inicio/mpFEPCMAC.Master"
    AutoEventWireup="true" CodeBehind="frmSeguridadGrupo.aspx.cs" Inherits="WebSite.WebPage.Configuracion.frmSeguridadGrupo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%" cellpadding="0" cellspacing="0">
        <tr>
            <td class="TituloPagina">
                &nbsp; &nbsp;
                <asp:Label runat="server" ID="lblTituloPagina" Text="Grupos " />
            </td>
            
            <td class="AccesoDirecto">
                                
                <asp:ImageButton runat="server" ID="ibtnBuscar" AlternateText="Buscar" 
                    ImageUrl="~/Resources/Imagenes/Buscar.png" CssClass='LinkURL' 
                    onclick="ibtnBuscar_Click" />
                                                
                <asp:ImageButton runat="server" ID="ibtnNuevo" AlternateText="Nuevo" 
                    ImageUrl="~/Resources/Imagenes/Nuevo.jpg" CssClass='LinkURL' 
                    onclick="ibtnNuevo_Click" />
            </td>
        </tr>
    </table>
    
    <div>
        <table runat="server" id="tbPrincipal" class="Principal">
            <tr>
                <td align="left" valign="top">
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" BorderColor="Silver" BorderWidth="1"
                        CssClass="panel">
                        <table class="Principal1">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" BorderColor="Silver" BorderWidth="1"
                                        CssClass="panel">
                                        <table class="Principal1">
                                            <tr>
                                                <td class="labelSombreadoPequenio" align="right">
                                                    <asp:Label ID="lblGrupo" runat="server" Text="Grupo"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtGrupo" runat="server" Width="380"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="button" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="button" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:GridView ID="gvwSeguridadGrupo" runat="server" CssClass="GVPrincipal" AutoGenerateColumns="False">
                                                        <Columns>
                                                            <asp:BoundField DataField="sNombres" HeaderText="Nombres">
                                                                <ItemStyle Width="370px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="sArea" HeaderText="Area">
                                                                <ItemStyle Width="185px" />
                                                            </asp:BoundField>
                                                            <asp:CommandField HeaderText="Agregar" ShowSelectButton="True" SelectText='<img runat="server" id="imgLink" src="../../Resources/Imagenes/u167_original.png" border="0" class="imagen"/>'>
                                                                <ItemStyle Width="25px" />
                                                            </asp:CommandField>
                                                            <asp:CommandField HeaderText="Editor" ShowSelectButton="True" SelectText='<img runat="server" id="imgLink" src="../../Resources/Imagenes/u278_original.png" border="0"/>'>
                                                                <ItemStyle Width="25px" />
                                                            </asp:CommandField>
                                                            <asp:CommandField HeaderText="Eliminar" ShowSelectButton="True" SelectText='<img runat="server" id="imgLink" src="../../Resources/Imagenes/u290_original.png" border="0"/>'>
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
                                    <asp:Label ID="lblSeguridadGrupo" runat="server" Text="Grupos"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
