<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Inicio/mpFEPCMAC.Master"
    AutoEventWireup="true" CodeBehind="frmActividad.aspx.cs" Inherits="WebGdoc.WebPage.Configuracion.frmActividad" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
<script language="javascript" type="text/javascript">

function AcceptNum(e)

{ 
    var nav4 = window.Event ? true : false;
    var key = nav4 ? evt.which : e.keyCode; 

    return (key <= 13 || (key >= 48 && key <= 57) || key == 46);
}

</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="BarraHerramientas"  cellpadding="0" cellspacing="0">
        <tr>
            <td class="TituloPagina">
                &nbsp; &nbsp;
                <asp:Label runat="server" ID="lblTituloPagina" Text="Actividad" />
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
                                <table style="width:100%" >
                                    <tr>
                                        <td class="FondoEtiqueta1" >
                                            <asp:Label ID="lblRucEmpresa" runat="server" Text="Periodo: " CssClass="label" />
                                        </td>
                                        <td colspan="3">
                                           <asp:DropDownList ID="dllPeriodo" runat="server" CssClass="dropdownlist" AutoPostBack ="true" 
                                                             OnSelectedIndexChanged="dllPeriodo_SelectedIndexChanged" Width="120px" />
                                        </td>                                              
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="Label1" runat="server" Text="Obj. Estrategico" 
                                                CssClass="label" />
                                        </td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="ddlEstrategico" runat="server" CssClass="dropdownlist" AutoPostBack="True"
                                                                onselectedindexchanged="ddlEstrategico_SelectedIndexChanged" Width="100%"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="Label2" runat="server" Text="Obj. Operativo" CssClass="label" />
                                        </td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="ddlOperativo" runat="server" CssClass="dropdownlist" AutoPostBack="True"
                                                                            onselectedindexchanged="ddlOperativo_SelectedIndexChanged" Width="100%"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="Label3" runat="server" Text="Proyecto" CssClass="label" />
                                        </td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="ddlProyecto" runat="server" CssClass="dropdownlist" AutoPostBack="True"
                                                                onselectedindexchanged="ddlProyecto_SelectedIndexChanged" Width="100%"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblRazon" runat="server" Text="Código" CssClass="label"/>
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtCodigo" runat="server"  CssClass="textbox" Width="120px"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblComentario" runat="server" Text="Descripcion" CssClass="label" />
                                        </td>
                                        <td colspan="3">
                                            <table cellpadding="0" cellspacing="0" style="width:100%;">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtDescipcion" runat="server" CssClass="textbox" Width="99%" />
                                                    </td>
                                                </tr>
                                                    <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlActividad" runat="server" CssClass="dropdownlist" AutoPostBack="True"
                                                                onselectedindexchanged="ddlActividad_SelectedIndexChanged" Width="100%"/>
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblDpto" runat="server" CssClass="label" Text="Abreviatura:" />     
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtAbrev" runat="server" CssClass="textbox" Width="99%"/>
                                         </td>
                                    </tr> 
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblProv" runat="server" CssClass="label" Text="Estado:" />     
                                        </td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="dllEstado" runat="server" CssClass="dropdownlist" AutoPostBack ="true" 
                                                              Width="138px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="Label4" runat="server" CssClass="label" Text="Unidad de Medida: " />     
                                        </td>
                                         <td>                                            
                                            <asp:TextBox ID="txtUnidad" runat="server" CssClass="textbox" Width="138px"></asp:TextBox>                                            
                                         </td>
                                          <td class="FondoEtiqueta1">
                                            <asp:Label ID="Label7" runat="server" CssClass="label" Text="Responsable:" />     
                                        </td>
                                         <td>                                            
                                            <asp:DropDownList ID="dllReponsable" runat="server" CssClass="dropdownlist" 
                                                AutoPostBack ="true" Width="138px" />
                                         </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table style="width:100%" >
                                            <tr>
                                                <td colspan ="4">
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align ="center">
                                                    <asp:Label ID="Label8" runat="server"  Text="PERIODO" Font-Bold="True" CssClass="label" Font-Size="Medium" />     
                                                </td>
                                                <td align ="left" >
                                                    <asp:Label ID="Label9" runat="server"  Text="COMPROMISO" Font-Bold="True" CssClass="label" Font-Size="Medium" />     
                                                </td>
                                                <td align ="left">
                                                    <asp:Label ID="Label10" runat="server"  Text="AVANCE" Font-Bold="True" CssClass="label" Font-Size="Medium" />     
                                                </td>
                                                <td align ="left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                 <td class="FondoEtiqueta1">
                                                    <asp:Label ID="Label11" runat="server" CssClass="label" Text="Enero: " />     
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtEneComp" runat="server" CssClass="textbox" Width="138px" Text="0"></asp:TextBox>                                            
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtEneAvan" runat="server" CssClass="textbox" Width="138px" 
                                                        Text="0" ontextchanged="txtEneAvan_TextChanged" AutoPostBack="true"></asp:TextBox>                                            
                                                </td>
                                                <td style="Width:530px">                                            
                                                    <asp:TextBox ID="txtEneCome" runat="server" CssClass="textbox" Width="530px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="FondoEtiqueta1">
                                                    <asp:Label ID="Label12" runat="server" CssClass="label" Text="Febrero:" />     
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtFebComp" runat="server" CssClass="textbox" Width="138px" Text="0"></asp:TextBox>                                            
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtFebAvan" runat="server" CssClass="textbox" Width="138px" 
                                                        Text="0" ontextchanged="txtFebAvan_TextChanged" AutoPostBack="true"></asp:TextBox>                                            
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtFebCome" runat="server" CssClass="textbox" Width="99%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="FondoEtiqueta1">
                                                    <asp:Label ID="Label13" runat="server" CssClass="label" Text="Marzo:" />     
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtMarComp" runat="server" CssClass="textbox" Width="138px" Text="0"></asp:TextBox>                                            
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtMarAvan" runat="server" CssClass="textbox" Width="138px" 
                                                    Text="0" ontextchanged="txtMarAvan_TextChanged" AutoPostBack="true"></asp:TextBox>                                            
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtMarCome" runat="server" CssClass="textbox" Width="99%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="FondoEtiqueta1">
                                                    <asp:Label ID="Label14" runat="server" CssClass="label" Text="Abril:" />     
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtAbrComp" runat="server" CssClass="textbox" Width="138px" Text="0"></asp:TextBox>                                            
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtAbrAvan" runat="server" CssClass="textbox" Width="138px" 
                                                    Text="0" ontextchanged="txtAbrAvan_TextChanged" AutoPostBack="true"></asp:TextBox>                                            
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtAbrCome" runat="server" CssClass="textbox" Width="99%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="FondoEtiqueta1">
                                                    <asp:Label ID="Label15" runat="server" CssClass="label" Text="Mayo:" />     
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtMayComp" runat="server" CssClass="textbox" Width="138px" Text="0"></asp:TextBox>                                            
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtMayAvan" runat="server" CssClass="textbox" Width="138px" 
                                                    Text="0" ontextchanged="txtMayAvan_TextChanged" AutoPostBack="true"></asp:TextBox>                                            
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtMayCome" runat="server" CssClass="textbox" Width="99%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="FondoEtiqueta1">
                                                    <asp:Label ID="Label16" runat="server" CssClass="label" Text="Junio" />     
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtJunComp" runat="server" CssClass="textbox" Width="138px" Text="0"></asp:TextBox>                                            
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtJunAvan" runat="server" CssClass="textbox" Width="138px" 
                                                    Text="0" ontextchanged="txtJunAvan_TextChanged" AutoPostBack="true"></asp:TextBox>                                            
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtJunCome" runat="server" CssClass="textbox" Width="99%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="FondoEtiqueta1">
                                                    <asp:Label ID="Label18" runat="server" CssClass="label" Text="Julio:" />     
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtJulComp" runat="server" CssClass="textbox" Width="138px" Text="0"></asp:TextBox>                                            
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtJulAvan" runat="server" CssClass="textbox" Width="138px" 
                                                    Text="0" ontextchanged="txtJulAvan_TextChanged" AutoPostBack="true"></asp:TextBox>                                            
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtJulCome" runat="server" CssClass="textbox" Width="99%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="FondoEtiqueta1">
                                                    <asp:Label ID="Label19" runat="server" CssClass="label" Text="Agosto:" />     
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtAgoComp" runat="server" CssClass="textbox" Width="138px" Text="0"></asp:TextBox>                                            
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtAgoAvan" runat="server" CssClass="textbox" Width="138px" 
                                                    Text="0" ontextchanged="txtAgoAvan_TextChanged" AutoPostBack="true"></asp:TextBox>                                            
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtAgoCome" runat="server" CssClass="textbox" Width="99%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="FondoEtiqueta1">
                                                    <asp:Label ID="Label20" runat="server" CssClass="label" Text="Setiembre:" />     
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtSetComp" runat="server" CssClass="textbox" Width="138px" Text="0"></asp:TextBox>                                            
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtSetAvan" runat="server" CssClass="textbox" Width="138px" 
                                                    Text="0" ontextchanged="txtSetAvan_TextChanged" AutoPostBack="true"></asp:TextBox>                                            
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtSetCome" runat="server" CssClass="textbox" Width="99%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="FondoEtiqueta1">
                                                    <asp:Label ID="Label21" runat="server" CssClass="label" Text="Octubre" />     
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtOctComp" runat="server" CssClass="textbox" Width="138px" Text="0"></asp:TextBox>                                            
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtOctAvan" runat="server" CssClass="textbox" Width="138px" 
                                                    Text="0" ontextchanged="txtOctAvan_TextChanged" AutoPostBack="true"></asp:TextBox>                                            
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtOctCome" runat="server" CssClass="textbox" Width="99%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="FondoEtiqueta1">
                                                    <asp:Label ID="Label22" runat="server" CssClass="label" Text="Noviembre:" />     
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtNovComp" runat="server" CssClass="textbox" Width="138px" Text="0"></asp:TextBox>                                            
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtNovAvan" runat="server" CssClass="textbox" Width="138px" 
                                                    Text="0" ontextchanged="txtNovAvan_TextChanged" AutoPostBack="true"></asp:TextBox>                                            
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtNovCome" runat="server" CssClass="textbox" Width="99%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="FondoEtiqueta1">
                                                    <asp:Label ID="Label23" runat="server" CssClass="label" Text="Diciembre:" />     
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtDicComp" runat="server" CssClass="textbox" Width="138px" Text="0"></asp:TextBox>                                            
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtDicAvan" runat="server" CssClass="textbox" Width="138px" 
                                                    Text="0" ontextchanged="txtDicAvan_TextChanged" AutoPostBack="true"></asp:TextBox>                                            
                                                </td>
                                                <td>                                            
                                                    <asp:TextBox ID="txtDicCome" runat="server" CssClass="textbox" Width="99%"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>    
                                    </ContentTemplate>
                                
                                </asp:UpdatePanel>
                            
                            
                                
                            </td>
                        </tr>
                    </table>
                    <asp:Label ID="lblCodRuc" runat="server" CssClass="label" Visible ="false"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
