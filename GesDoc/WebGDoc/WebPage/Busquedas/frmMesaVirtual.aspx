<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Inicio/mpFEPCMAC.Master"
    AutoEventWireup="true" CodeBehind="frmMesaVirtual.aspx.cs" Inherits="WebGdoc.WebPage.Busquedas.frmMesaVirtual" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="../Controles/ValidarUsuario_Grupo.ascx" tagname="ValidarUsuario_Grupo" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" class="BarraHerramientas">
        <tr>
            <td class="TituloPagina">
                &nbsp; &nbsp;
                <asp:Label runat="server" ID="lblTituloPagina" Text="Buscador Mesas de Trabajo Virtuales" />
            </td>
            
            <td class="AccesoDirecto">
                <asp:ImageButton runat="server" ID="ibtnBuscar" AlternateText="Buscar" CssClass='LinkURL' onclick="ibtnBuscar_Click" />
                <!--<asp:ImageButton runat="server" ID="ibtnNuevo" AlternateText="Nuevo" ImageUrl="~/Resources/Imagenes/Nuevo.jpg" CssClass='LinkURL' onclick="ibtnNuevo_Click" />-->
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
                                <asp:Label runat="server" ID="lblBuscarDocE" Text="Buscar:" CssClass="label" />
                            </td>
                            <td colspan="7">
                                <asp:TextBox ID="txtBuscarDocE" runat="server" CssClass="textboxMayus"/>
                            </td>
                        </tr>
                        <tr>
                            <td class="FondoEtiqueta1">
                                <asp:Label ID="lblTipoBusqueda" runat="server" Text="Tipo de Busqueda" CssClass="label" />
                            </td>
                            <td colspan="7">
                                <asp:DropDownList ID="ddlTipoBusq" runat="server" CssClass="dropdownlist">
                                    <asp:ListItem Value="0">COMPLEMENTARIO</asp:ListItem>
                                    <asp:ListItem Value="1">EXCLUYENTE</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="FondoEtiqueta1">
                                <asp:Label ID="lblEstado" runat="server" Text="Estado" CssClass="label" />
                            </td>
                            <td style="width:180px">
                                <asp:DropDownList ID="ddlEstado" runat="server" Width="180" 
                                        CssClass="dropdownlist">
                                        <asp:ListItem Value="A">ACTIVO</asp:ListItem>
                                        <asp:ListItem Value="C">CREADO</asp:ListItem>
                                        <asp:ListItem Value="F">FINALIZADO</asp:ListItem>
                                        <asp:ListItem Value="N">ANULADO</asp:ListItem>
                                        <asp:ListItem Value="P">PENDIENTE</asp:ListItem>
                                        <asp:ListItem Value="S">ENVIADO</asp:ListItem>
                                    </asp:DropDownList>
                            </td>
                            <td class="FondoEtiqueta1" style="width:100px;">
                                <asp:Label ID="lblPorFecha" runat="server" Text="Por Fecha:" CssClass="label"/>
                            </td>
                            <td align="left" class="radioButton">
                                <asp:RadioButtonList ID="rdnRangoFecha" runat="server" CssClass="radioButton" 
                                    RepeatDirection="Horizontal" AutoPostBack="True" 
                                    onselectedindexchanged="rdnRangoFecha_SelectedIndexChanged">
                                    <asp:ListItem Text="Si" Value="S" Selected="True" />
                                    <asp:ListItem Text="No" Value="N" />
                                </asp:RadioButtonList>
                            </td>
                            <td class="FondoEtiqueta1" style="width:100px;">
                                <asp:Label ID="lblFecRegistro" runat="server" Text="Fecha Registro" CssClass="label" />
                            </td>
                            <td valign="bottom">
                                <% //Ejemplo de centrado calendar %>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtFecRegistro" runat="server" CssClass="calendar" style="width:75px;"/>
                                        </td>
                                        <td style="width:5px">
                                            
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ibtnFecEmision" runat="server" CssClass="imagen" />
                                            <asp:CalendarExtender ID="calFecCon" runat="server" PopupButtonID="ibtnFecEmision" TargetControlID="txtFecRegistro" Format="dd/MM/yyyy" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td class="FondoEtiqueta1" style="width:80px;">
                                <asp:Label ID="lblFecFin" runat="server" Text="Hasta" CssClass="label" />
                            </td>
                            <td valign="bottom">
                                <% //Ejemplo de centrado calendar %>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtFecFin" runat="server" CssClass="calendar" style="width:75px;"/>
                                        </td>
                                        <td style="width:5px">
                                            
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ibtnFecFin" runat="server" CssClass="imagen" />
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="ibtnFecFin" TargetControlID="txtFecFin" Format="dd/MM/yyyy" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="FondoEtiqueta1">
                                <asp:Label ID="Label2" runat="server" Text="Organizador:" CssClass="label" />
                            </td>
                            <td colspan="7">
                                <uc1:ValidarUsuario_Grupo ID="ctlUserRemitente" runat="server" WithTexto="99" CantidadUser="1" AprobacionUser="false"  UserModeText="" TituloControl="SELECCIONE USUARIO" />
                            </td>
                        </tr>
                        <tr>
                            <td class="FondoEtiqueta1">
                                <asp:Label ID="Label1" runat="server" Text="Participante:" CssClass="label" />
                            </td>
                            <td colspan="7">
                                <uc1:ValidarUsuario_Grupo ID="ctlUserParticipante" runat="server" WithTexto="99" CantidadUser="1" AprobacionUser="false" UserModeText="" TituloControl="SELECCIONE USUARIO" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="Panel2" runat="server" CssClass="panel" GroupingText="Resultados: registros encontrados">
                    <table border="0" cellspacing="0" cellpadding="0" style="width: 100%;" class="GVHeader">
                        <tr>
                            <td align="center" style="Width:35px;">Ver</td>
                            <td align="center" style="Width:120px;">Nro Documento</td>
                            <td align="center" style="Width:480px;">Título</td>
                            <td align="center" style="Width:150px;">Fecha Organización</td>
                            <td align="center" style="Width:150px;">Fecha Cierre</td>                            
                        </tr>
                    </table>
                    <div id="scroll" class="divBusqueda" >
                        <asp:GridView runat="server" ID="gvwMesaVir" CssClass="GVPrincipal" DataKeyNames="NumOper" 
                            AutoGenerateColumns="False" ShowHeader="false"
                            onselectedindexchanged="gvwMesaVir_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField HeaderText="Ver" 
                                    SelectText='<img runat="server" id="imgLink" src="../../Resources/Imagenes/img_Detalle_A.jpg" border="0" class="imagen"/>' 
                                    ShowSelectButton="True">
                                    <ItemStyle Width="25px" HorizontalAlign ="Center" />
                                </asp:CommandField>
                                <asp:BoundField DataField="NumOper" HeaderText="Nro Documento">
                                    <ItemStyle Width="120px" />
                                </asp:BoundField>                                
                                <asp:BoundField DataField="Titulo" HeaderText="Título">
                                    <ItemStyle Width="480px" />
                                </asp:BoundField>                                
                                 <asp:BoundField DataField="Fecha" HeaderText="FechOrga">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>                                
                                <asp:BoundField DataField="FechaFin" HeaderText="FechCie">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>                                
                                <asp:BoundField DataField="NumOper" HeaderText="N° Mesa" Visible="False" />
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
