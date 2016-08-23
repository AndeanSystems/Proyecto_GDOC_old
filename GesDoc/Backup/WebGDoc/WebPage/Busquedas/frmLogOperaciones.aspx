
<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Inicio/mpFEPCMAC.Master"
    AutoEventWireup="true" CodeBehind="frmLogOperaciones.aspx.cs" Inherits="WebGdoc.WebPage.Busquedas.frmLogOperaciones" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="../Controles/ValidarUsuario_Grupo.ascx" tagname="ValidarUsuario_Grupo" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" class="BarraHerramientas">
        <tr>
            <td class="TituloPagina">
                &nbsp; &nbsp;
                <asp:Label runat="server" ID="lblTituloPagina" 
                    Text="Log de Operaciones" />
            </td>
            
            <td class="AccesoDirecto">
                <asp:ImageButton runat="server" ID="ibtnBuscar" AlternateText="Buscar" CssClass='LinkURL' onclick="ibtnBuscar_Click" />
                &nbsp; &nbsp;
            </td>
        </tr>
    </table>
    
    <table runat="server" id="tbPrincipal" class="Principal1">
        <tr>
            <td align="left" valign="top">
                <asp:Panel ID="Panel1" runat="server" CssClass="panel" GroupingText="Criterios de busqueda">
                    <table class="FontSistema" style="width:100%" >
                        <tr>
                            <td class="FondoEtiqueta1">
                                <asp:Label ID="lblTipoOper" runat="server" Text="Tipo de Operacion" CssClass="label" />
                            </td>
                            <td >
                                <asp:DropDownList ID="ddlTipoOper" runat="server" CssClass="dropdownlist" 
                                    Height="20px" Width="215px">
                                    <asp:ListItem Value="0">Documento Electronico</asp:ListItem>
                                    <asp:ListItem Value="1">Documento Digital</asp:ListItem>
                                    <asp:ListItem Value="2">Mesa Virtual</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            
                            
                             <td class="FondoEtiqueta1">
                                <asp:Label ID="Label1" runat="server" Text="N° de Operacion" CssClass="label" />
                            </td>
                            <td >
                             <asp:TextBox ID="txtBuscarLogDoc" runat="server" CssClass="textboxMayus"    Height="16px" Width="215px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="Panel2" runat="server" CssClass="panel" GroupingText="Resultados: registros encontrados">
                    <table border="0" cellspacing="0" cellpadding="0" style="width: 100%;" class="GVHeader">
                        <tr>
                            <td align="center" style="Width:90px;">Usuario</td>
                            <td align="left" style="Width:845px;">Comentario</td>
                        </tr>
                    </table>
                    <div id="scroll" class="divBusqueda" >
                        <asp:GridView ID="gvwLogOper" runat="server" AutoGenerateColumns="False" 
                            CssClass="GVPrincipal" ShowHeader="false">
                            <Columns>
                                <asp:BoundField DataField="IdeUsu" HeaderText="Usuario" >
                                    <ItemStyle Width="90" />    
                                </asp:BoundField>
                                    
                                <asp:BoundField DataField="DescEven" HeaderText="Comentario" >
                                    <ItemStyle Width="845" />    
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="CodiDocAdju" HeaderText="Adjunto" >
                                    <ItemStyle Width="0" />    
                                </asp:BoundField>
                                                  
                            </Columns>
                            <HeaderStyle CssClass="GVHeader" />
                            <RowStyle CssClass="GVItems" />
                            <AlternatingRowStyle CssClass="GVItemsAlt" />
                        </asp:GridView>
                    </div>
                </asp:Panel>
            </td>
        </tr>
    </table>

</asp:Content>
