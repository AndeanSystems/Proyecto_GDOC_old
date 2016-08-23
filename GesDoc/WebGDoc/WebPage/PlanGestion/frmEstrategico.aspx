<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Inicio/mpFEPCMAC.Master"
    AutoEventWireup="true" CodeBehind="frmEstrategico.aspx.cs" Inherits="WebGdoc.WebPage.Configuracion.frmEstrategico" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="BarraHerramientas"  cellpadding="0" cellspacing="0">
        <tr>
            <td class="TituloPagina">
                &nbsp; &nbsp;
                <asp:Label runat="server" ID="lblTituloPagina" Text="Objetivo Estrategico" />
            </td>            
            <td class="AccesoDirecto">
                
                <asp:ImageButton runat="server" ID="ibtnBuscar" AlternateText="Buscar" CssClass='LinkURL' onclick="ibtnBuscar_Click" Visible ="false" />

                <asp:ImageButton runat="server" ID="ibtnNuevo" AlternateText="Nuevo" CssClass='LinkURL' onclick="ibtnNuevo_Click" />
                    
                <asp:ImageButton runat="server" ID="ibtnGuardar"  AlternateText="Guardar" CssClass='LinkURL' onclick="ibtnGuardar_Click" Enabled="False"/>
                
                <asp:ImageButton runat="server" ID="ibtnEditar" AlternateText="Editar" CssClass='LinkURL' onclick="ibtnEditar_Click" Enabled="False"/>

                <asp:ImageButton runat="server" ID="ibtnEliminar" AlternateText="Eliminar" CssClass='LinkURL' Visible ="false" onclick="ibtnEliminar_Click" Enabled="False"/>  
                                                
                <asp:ImageButton runat="server" ID="ibtnRegresar" AlternateText="Regresar" CssClass='LinkURL' onclick="ibtnRegresar_Click" />
                
            </td>
        </tr>
    </table>
    
    <div>
        <table runat="server" id="tbPrincipal" class="Principal">
            <tr>
                <td align="left" valign="top">
                    <table class="FontSistema" style="width:100%">
                        <tr>
                            <td>
                                <table style="width:100%">
                                    <tr>
                                        <td class="FondoEtiqueta1" >
                                            <asp:Label ID="lblRucEmpresa" runat="server" Text="Periodo: " CssClass="label" />
                                        </td>
                                        <td>
                                           <asp:DropDownList ID="dllPeriodo" runat="server" CssClass="dropdownlist" AutoPostBack ="true" 
                                                             OnSelectedIndexChanged="dllPeriodo_SelectedIndexChanged" Width="120px" />
                                        </td>  
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblRazon" runat="server" Text="Código" CssClass="label"/>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCodigo" runat="server"  CssClass="textbox" Width="120px"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblComentario" runat="server" Text="Descripcion" CssClass="label" />
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0" style="width:100%;">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtDescipcion" runat="server" CssClass="textbox" width="99%"/>
                                                    </td>
                                                </tr>
                                                    <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlEstrategico" runat="server" CssClass="dropdownlist" AutoPostBack="True"
                                                                            onselectedindexchanged="ddlEstrategico_SelectedIndexChanged"/>
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblDpto" runat="server" CssClass="label" Text="Abreviatura:" />     
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAbrev" runat="server" CssClass="textbox" width="99%"/>
                                         </td>
                                    </tr> 
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblProv" runat="server" CssClass="label" Text="Estado:" />     
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="dllEstado" runat="server" CssClass="dropdownlist" AutoPostBack ="true" 
                                                              Width="138px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="label">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
