<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Inicio/mpFEPCMAC.Master"
    AutoEventWireup="true" CodeBehind="frmEmpresa.aspx.cs" Inherits="WebGdoc.WebPage.Configuracion.frmEmpresa" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
<script language="javascript" type="text/javascript">

function AcceptNum(e)

{ 
    var nav4 = window.Event ? true : false;
    var key = nav4 ? evt.which : e.keyCode; 
    return (key <= 13 || (key >= 48 && key <= 57) || key == 44);
}

</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="BarraHerramientas"  cellpadding="0" cellspacing="0">
        <tr>
            <td class="TituloPagina">
                &nbsp; &nbsp;
                <asp:Label runat="server" ID="lblTituloPagina" Text="Empresa" />
            </td>
            
            <td class="AccesoDirecto">
                <asp:ImageButton runat="server" ID="ibtnNuevo" AlternateText="Nuevo" CssClass='LinkURL' onclick="ibtnNuevo_Click" />
                    
                <asp:ImageButton runat="server" ID="ibtnGuardar"  AlternateText="Guardar" CssClass='LinkURL' onclick="ibtnGuardar_Click"/>
                
                <asp:ImageButton runat="server" ID="ibtnEliminar" AlternateText="Eliminar" CssClass='LinkURL' onclick="ibtnEliminar_Click"/>  
                                                
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
                                <table  style="width:100%">
                                    <tr>
                                        <td class="FondoEtiqueta1" >
                                            <asp:Label ID="lblRucEmpresa" runat="server" Text="RUC: " CssClass="label" />
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtRUC" runat="server"  CssClass="textbox" Width ="150px" />
                                                    </td>
                                                    <td>
                                                      <asp:ImageButton runat="server" ID="ibtnBuscar" AlternateText="Buscar" CssClass='imagen' onclick="ibtnBuscar_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>                                              
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblRazon" runat="server" Text="Razon Social" CssClass="label"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRazon" runat="server"  CssClass="textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblComentario" runat="server" Text="Direccion" CssClass="label"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblDpto" runat="server" CssClass="label" Text="Departamento: " />     
                                        </td>
                                         <td>
                                            <asp:DropDownList ID="ddlDpto" runat="server" CssClass="dropdownlist" AutoPostBack ="true" onselectedindexchanged="ddlDpto_SelectedIndexChanged" />
                                         </td>
                                    </tr> 
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblProv" runat="server" CssClass="label" Text="Provincia:" />     
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlProv" runat="server" CssClass="dropdownlist" AutoPostBack ="true" onselectedindexchanged="ddlProv_SelectedIndexChanged" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblDistrito" runat="server" CssClass="label" Text="Distrito:" />     
                                        </td>
                                         <td>
                                            <asp:DropDownList ID="ddlDistrito" runat="server" CssClass="dropdownlist" />
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
                    <asp:Label ID="lblCodRuc" runat="server" CssClass="label" Visible ="false"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
