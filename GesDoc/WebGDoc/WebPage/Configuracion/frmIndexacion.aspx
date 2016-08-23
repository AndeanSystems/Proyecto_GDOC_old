<%@ Page Language="C#" MasterPageFile="~/WebPage/Inicio/mpFEPCMAC.Master" AutoEventWireup="true"
    CodeBehind="frmIndexacion.aspx.cs" Inherits="WebSite.WebPage.Configuracion.frmIndexacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table style="width:100%" cellpadding="0" cellspacing="0">
        <tr>
            <td class="TituloPagina">
                &nbsp; &nbsp;
                <asp:Label runat="server" ID="lblTituloPagina" Text="Digitalización de Documentos " />
            </td>
            
            <td class="AccesoDirecto">
                <asp:ImageButton runat="server" ID="ibtnGuardar" AlternateText="Guardar" ImageUrl="~/Resources/Imagenes/Guardar.png" CssClass='LinkURL' />
                
                <asp:ImageButton runat="server" ID="ibtnBuscar" AlternateText="Buscar" ImageUrl="~/Resources/Imagenes/Buscar.png" CssClass='LinkURL' />
                              
                <asp:ImageButton runat="server" ID="ibtnNuevo" AlternateText="Nuevo" ImageUrl="~/Resources/Imagenes/Nuevo.jpg" CssClass='LinkURL' />
            </td>
        </tr>
    </table>
    
    <div>
        <table  runat="server" id = "tbPrincipal" class ="Principal">
            <tr>
                <td>
                    <asp:Panel ID="pnlTodo" runat="server" BorderStyle="Solid" BorderColor="Silver"
                        BorderWidth="1" CssClass="panel">
                        <table class="Principal1">
                            <tr>
                                <td style="width: 50%">
                                    <asp:Panel ID="pnlSub1" runat="server" CssClass="panel" BorderStyle="Solid" BorderColor="Silver"
                                        BorderWidth="1">
                                        <table>
                                            <tr>
                                                <td class="labelSombreado" align="right">
                                                    <asp:Label ID="lblFecEmision" runat="server" Text="Fecha de Emisión:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:CheckBox ID="chkFecEmision" runat="server" Width="230" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="labelSombreado" align="right">
                                                    <asp:Label ID="lblFecRecepcion" runat="server" Text="Fecha de Recepción:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:CheckBox ID="chkFecRecepcion" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="labelSombreado" align="right">
                                                    <asp:Label ID="lblFecDigitalizacion" runat="server" Text="Fecha de Digitalización:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:CheckBox ID="chkFecDigitalizacion" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="labelSombreado" align="right">
                                                    <asp:Label ID="lblTitulo" runat="server" Text="Título o Asunto:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:CheckBox ID="chkTitulo" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="labelSombreado" align="right">
                                                    <asp:Label ID="lblNroDoc" runat="server" Text="Número de Documento:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:CheckBox ID="chkNroDoc" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="labelSombreado" align="right">
                                                    <asp:Label ID="lblDestinatario" runat="server" Text="Destinatario:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:CheckBox ID="chkDestinatario" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                                <td style="width: 50%">
                                    <asp:Panel ID="pnlSub2" runat="server" CssClass="panel" BorderStyle="Solid" BorderColor="Silver"
                                        BorderWidth="1">
                                        <table class="Principal1">
                                            <tr>
                                                <td class="labelSombreado" align="right" style="width: 35%">
                                                    <asp:Label ID="lblTipoDoc" runat="server" Text="Tipo de Documento:"></asp:Label>
                                                </td>
                                                <td align="left" rowspan="3" style="width: 65%">
                                                    <asp:GridView ID="gvwParticipantes" runat="server" CssClass="GVPrincipal" AutoGenerateColumns="False">
                                                        <Columns>
                                                            <asp:BoundField DataField="sNum" HeaderText="N°">
                                                                <ItemStyle Width="33px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="sTipoDoc" HeaderText="Tipo Documento">
                                                                <ItemStyle Width="150px" />
                                                            </asp:BoundField>
                                                            <asp:CheckBoxField ItemStyle-Width="33" />
                                                        </Columns>
                                                        <HeaderStyle CssClass="GVHeader" />
                                                        <RowStyle CssClass="GVItems" />
                                                        <AlternatingRowStyle CssClass="GVItemsAlt" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
