<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Inicio/mpFEPCMAC.Master"
    AutoEventWireup="true" CodeBehind="frmOpciones.aspx.cs" Inherits="WebGdoc.WebPage.Configuracion.frmOpciones" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width:100%" cellpadding="0" cellspacing="0">
        <tr>
            <td class="TituloPagina">
                &nbsp; &nbsp;
                <asp:Label runat="server" ID="lblTituloPagina" Text="Opciones " />
            </td>
            
            <td class="AccesoDirecto">
                <asp:ImageButton runat="server" ID="ibtnGuardar" AlternateText="Guardar" ImageUrl="~/Resources/Imagenes/Guardar.png" CssClass='LinkURL' />
                
                <asp:ImageButton runat="server" ID="ibtnBuscar" AlternateText="Buscar" ImageUrl="~/Resources/Imagenes/Buscar.png" CssClass='LinkURL' />
                                                
                <asp:ImageButton runat="server" ID="ibtnNuevo"  AlternateText="Nuevo" ImageUrl="~/Resources/Imagenes/Nuevo.jpg" CssClass='LinkURL' />
            </td>
        </tr>
    </table>
    
    <div>
        <table runat="server" id="tbPrincipal" class="Principal">
            <tr>
                <td align="left" valign="top">
                    <table class="FontSistema" style="width:100%" >
                        <tr>
                            <td style="width:50%">
                                <asp:Panel ID="Panel2" runat="server" CssClass="panelBorder">
                                    <table class="FontSistema" style="width:100%" >
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblPlazoDocE" runat="server" Text="Plazo de Doc-E" CssClass="label"/>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlPlazoDocE" runat="server" CssClass="dropdownlist" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblExtPlazo" runat="server" Text="Extenciones de Plazo" CssClass="label"/>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlExtPlazo" runat="server" CssClass="dropdownlist" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblAlertConf" runat="server" Text="Alertas de Confirmación:" CssClass="label"/>
                                            </td>
                                            <td class="radioButton" align="left">
                                                <asp:RadioButtonList runat="server" ID="rbtnAlerta" CssClass="radioButton" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Si" Value="0" />
                                                    <asp:ListItem Text="No" Value="1" />
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblTipDocE" runat="server" Text="Tipos de Doc-E" CssClass="label"/>
                                            </td>
                                            <td>
                                                <table class="FontSistema">
                                                    <tr>
                                                        <td style="width:300px">
                                                            <asp:DropDownList ID="ddlTipDocE" runat="server" CssClass="dropdownlist" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="ibtnTipDocEMas" runat="server" ImageUrl="~/Resources/Imagenes/u90_original.gif" CssClass="imagen" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="ibtnTipDocEMenos" runat="server" ImageUrl="~/Resources/Imagenes/u39_original.gif" CssClass="imagen"/>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:ListBox ID="lstTipDocE" runat="server" CssClass="listbox" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblClasesDocE" runat="server" Text="Clases de Doc-E" CssClass="label"/>
                                            </td>
                                            <td>
                                                <table class="FontSistema">
                                                    <tr>
                                                        <td style="width:300px">
                                                            <asp:DropDownList ID="ddlClasesDocE" runat="server" CssClass="dropdownlist" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="ibtnClasesDocEMas" runat="server" ImageUrl="~/Resources/Imagenes/u90_original.gif" CssClass="imagen" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="ibtnClasesDocEMenos" runat="server" ImageUrl="~/Resources/Imagenes/u39_original.gif" CssClass="imagen" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:ListBox ID="lstClasesDocE" runat="server" CssClass="listbox" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                            <td style="width:50%">
                                <asp:Panel ID="Panel3" runat="server" CssClass="panelBorder">
                                    <table class="FontSistema" style="width:100%" >
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblPlazoMesaV" runat="server" Text="Plazo de Mesa-V" CssClass="label"/>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlPlazoMesaV" runat="server" CssClass="dropdownlist" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblExtPlazoMesaV" runat="server" Text="Extenciones de Plazo" CssClass="label"/>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlExtPlazoMesaV" runat="server" CssClass="dropdownlist" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblAlertConfMesaV" runat="server" Text="Alertas de Confirmación:" CssClass="label"/>
                                            </td>
                                            <td class="radioButton" align="left">
                                                <asp:RadioButtonList runat="server" ID="rbtnAlertaConfir" CssClass="radioButton" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Si" Value="0" />
                                                    <asp:ListItem Text="No" Value="1" />
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblTiposMesaV" runat="server" Text="Tipos de Mesa-V" CssClass="label"/>
                                            </td>
                                            <td>
                                                <table class="FontSistema">
                                                    <tr>
                                                        <td style="width:300px">
                                                            <asp:DropDownList ID="ddlTiposMesaV" runat="server" CssClass="dropdownlist" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="ibtnTiposMesaVMas" runat="server" ImageUrl="~/Resources/Imagenes/u90_original.gif" CssClass="imagen" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="ibtnTiposMesaVMenos" runat="server" ImageUrl="~/Resources/Imagenes/u39_original.gif" CssClass="imagen" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:ListBox ID="lstTiposMesaV" runat="server" CssClass="listbox" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblClasesMesaV" runat="server" Text="Clases de Mesa-V" CssClass="label"/>
                                            </td>
                                            <td>
                                                <table class="FontSistema">
                                                    <tr>
                                                        <td style="width:300px">
                                                            <asp:DropDownList ID="ddlClasesMesaV" runat="server" CssClass="dropdownlist" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="ibtnClasesMesaVMas" runat="server" ImageUrl="~/Resources/Imagenes/u90_original.gif" CssClass="imagen" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="ibtnClasesMesaVMenos" runat="server" ImageUrl="~/Resources/Imagenes/u39_original.gif" CssClass="imagen" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:ListBox ID="lstClasesMesaV" runat="server" CssClass="listbox" />
                                                        </td>
                                                    </tr>
                                                </table>
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
    </div>
</asp:Content>
