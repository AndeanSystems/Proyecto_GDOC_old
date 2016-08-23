<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Inicio/mpFEPCMAC.Master"
    AutoEventWireup="true" CodeBehind="frmDocumentosDigitales.aspx.cs" Inherits="WebGdoc.WebPage.Busquedas.frmDocumentosDigitales" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="../Controles/ValidarUsuario_Grupo.ascx" tagname="ValidarUsuario_Grupo" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" class="BarraHerramientas">
        <tr>
            <td class="TituloPagina">
                &nbsp; &nbsp;
                <asp:Label runat="server" ID="lblTituloPagina" Text="Buscador Documentos Digitales" />
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
                                <asp:Label ID="lblTipoBusq" runat="server" Text="Tipo Búsqueda" CssClass="label" />
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
                                <asp:Label ID="lblTipoArch" runat="server" Text="Tipo de Documento" CssClass="label" />
                            </td>
                            <td style="width:180px">
                                <asp:DropDownList ID="ddlTipoArch" runat="server" CssClass="dropdownlist" />
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
                                <asp:Label ID="Label2" runat="server" Text="Remitente:" CssClass="label" style="width:75px;"/>
                            </td>
                            <td colspan="7">
                                <uc1:ValidarUsuario_Grupo ID="ctlUserRemitente" runat="server" WithTexto="99" CantidadUser="1" AprobacionUser="false"  UserModeText=""  TituloControl =" SELECCIONE USUARIO"/>
                            </td>
                        </tr>
                        <tr>
                            <td class="FondoEtiqueta1">
                                <asp:Label ID="Label1" runat="server" Text="Destinatario:" CssClass="label" />
                            </td>
                            <td colspan="7">
                                <uc1:ValidarUsuario_Grupo ID="ctlUserParticipante" runat="server" WithTexto="99" CantidadUser="1" AprobacionUser="false"  UserModeText="" TituloControl="SELECCIONE USUARIO" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="Panel2" runat="server" CssClass="panel" GroupingText="Resultados: registros encontrados">
                    <table border="0" cellspacing="0" cellpadding="0" style="width: 100%;" class="GVHeader">
                        <tr>
                            <td align="center" style="Width:30px;">Ver</td>
                            <td align="center" style="Width:140px;">N° Documento</td>
                            <td align="center" style="Width:150px;">Tipo Documento</td>
                            <td align="center" style="Width:450px;">Asunto</td>                            
                            <td align="center" style="Width:150px;">Fecha Emisión</td>                            
                        </tr>
                    </table>
                    <div id="scroll" class="divBusqueda" >
                        <asp:GridView ID="gvwDocD" runat="server" AutoGenerateColumns="False" CssClass="GVPrincipal" 
                                      DataKeyNames="NumDocuDigi" ShowHeader="False"
                                      onselectedindexchanged="gvwDocD_SelectedIndexChanged" 
                                      OnRowDataBound="gvwDocD_RowDataBound"
                                      onrowcommand="gvwDocD_RowCommand" >
                            <Columns>
                                <asp:CommandField HeaderText="Ver" 
                                    SelectText="&lt;img runat=&quot;server&quot; id=&quot;imgLink&quot; src=&quot;../../Resources/Imagenes/img_Detalle_A.jpg&quot; border=&quot;0&quot;/&gt;" 
                                    ShowSelectButton="True">
                                    <ItemStyle Width="30px" HorizontalAlign ="Center" />
                                </asp:CommandField>
                                <asp:BoundField DataField="NumDocuDigi" HeaderText="N° Documento" Visible="true" >
                                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                                </asp:BoundField> 
                                 <asp:BoundField DataField="NomTipoDocu" HeaderText="Tipo Documento" Visible="true" >
                                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                                </asp:BoundField> 
                                <asp:TemplateField HeaderText="Asunto">
                                    <ItemTemplate>                                           
                                       <asp:HyperLink ID="lnkTransfer" runat="server"  Text='<%# Eval("AsunDocuDigi") %>'  Width="450px" ForeColor="Blue" ></asp:HyperLink>                                               
                                    </ItemTemplate>
                                </asp:TemplateField>                              
                                <asp:TemplateField HeaderText="Título" Visible="false">
                                    <ItemTemplate>                                           
                                       <asp:Label ID="lblRutaFisica" runat="server" ForeColor="#33CC33" Visible="true" Text='<%# Eval("RutaFisi") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                <asp:BoundField DataField="FechRegi" HeaderText="Fecha Emisión" >
                                    <ItemStyle HorizontalAlign="Center" Width="150px" />
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
