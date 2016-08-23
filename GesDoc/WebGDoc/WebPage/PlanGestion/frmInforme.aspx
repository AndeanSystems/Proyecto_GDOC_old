<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Inicio/mpFEPCMAC.Master"
    AutoEventWireup="true" CodeBehind="frmInforme.aspx.cs" Inherits="WebGdoc.WebPage.PlanGestion.frmInforme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="../Controles/ValidarUsuario_Grupo.ascx" tagname="ValidarUsuario_Grupo" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <table cellpadding="0" cellspacing="0" class="BarraHerramientas">
        <tr>
            <td class="TituloPagina">
                &nbsp; &nbsp;
                <asp:Label runat="server" ID="lblTituloPagina" Text="Generar Informe" />
            </td>
            
            <td class="AccesoDirecto">
                <asp:ImageButton runat="server" ID="ibtnBuscar" AlternateText="Buscar" CssClass='LinkURL' onclick="ibtnBuscar_Click" />                
                <asp:ImageButton runat="server" ID="ibtnExportar" AlternateText="Exportar Resultado" CssClass='LinkURL' onclick="ibtnExportar_Click"/>
                <asp:ImageButton runat="server" ID="ibtnGenerarInforme" AlternateText="Generar Informe" CssClass='LinkURL' onclick="ibtnGenerarInforme_Click"/>
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
                                            <asp:Label ID="lblperiodo" runat="server" Text="Periodo: " CssClass="label" />
                                        </td>
                                        <td>
                                           <asp:DropDownList ID="dllPeriodo" runat="server" CssClass="dropdownlist" AutoPostBack ="true" 
                                                             OnSelectedIndexChanged="dllPeriodo_SelectedIndexChanged" Width="120px" />
                                        </td>     
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblFecRegistro" runat="server" Text="Desde" CssClass="label" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlIni" runat="server" CssClass="dropdownlist" 
                                                Width="120px" AutoPostBack="True" 
                                                onselectedindexchanged="ddlIni_SelectedIndexChanged" >
                                            </asp:DropDownList>
                                        </td>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblFecFin" runat="server" Text="Hasta" CssClass="label" />
                                        </td>
                                        <td >
                                            <asp:DropDownList ID="ddlFin" runat="server" CssClass="dropdownlist" 
                                                Width="120px" onselectedindexchanged="ddlFin_SelectedIndexChanged" >
                                           </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblOEstrategico" runat="server" Text="Obj. Estrategico" 
                                                CssClass="label" />
                                        </td>
                                        <td colspan="5">
                                            <asp:DropDownList ID="ddlEstrategico" runat="server" CssClass="dropdownlist" AutoPostBack="True"
                                                                onselectedindexchanged="ddlEstrategico_SelectedIndexChanged" Width="100%"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblOOperativo" runat="server" Text="Obj. Operativo" CssClass="label" />
                                        </td>
                                        <td colspan="5">
                                            <asp:DropDownList ID="ddlOperativo" runat="server" CssClass="dropdownlist" AutoPostBack="True"
                                                                            onselectedindexchanged="ddlOperativo_SelectedIndexChanged" Width="100%"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblProyecto" runat="server" Text="Proyecto" CssClass="label" />
                                        </td>
                                        <td colspan="5">
                                            <asp:DropDownList ID="ddlProyecto" runat="server" CssClass="dropdownlist" AutoPostBack="True"
                                                                onselectedindexchanged="ddlProyecto_SelectedIndexChanged" Width="100%"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblActividad" runat="server" Text="Actividad" CssClass="label" />
                                        </td>
                                        <td colspan="5">
                                            <asp:DropDownList ID="ddlActividad" runat="server" CssClass="dropdownlist" AutoPostBack="True"
                                                                onselectedindexchanged="ddlActividad_SelectedIndexChanged" Width="100%"/>
                                                    
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="Label2" runat="server" Text="Responsable:" CssClass="label" />
                                        </td>
                                        <td colspan="5">
                                            <uc1:ValidarUsuario_Grupo ID="ctlUserRemitente" runat="server" WithTexto="99" CantidadUser="1" AprobacionUser="false"  UserModeText="" TituloControl="SELECCIONE Responsable" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel2" runat="server" CssClass="panel" GroupingText="Resultados: registros encontrados">
                                    <div id="scroll" class="divBusquedaPG" runat ="server" style="width:945px" >
                                        <asp:GridView ID="gvwPG" runat="server" CssClass="GVPrincipal" AutoGenerateColumns="false"
                                                      EnableModelValidation="True" OnRowDataBound="gvwPG_OnRowDataBound" Width="1560px">
                                            <Columns>
                                                <asp:BoundField DataField="DescObjEstr" HeaderText="Obj. Estrategico">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                                
                                                <asp:BoundField DataField="DescObjOper" HeaderText="Obj. Operativo">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                                
                                                <asp:BoundField DataField="DescProy" HeaderText="Proyecto">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                                
                                                <asp:BoundField DataField="DescActi" HeaderText="Actividad">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                                
                                                <asp:BoundField DataField="CompEne" HeaderText="Enero">
                                                    <ItemStyle Width="80px"/>
                                                </asp:BoundField>
                                                
                                                <asp:BoundField DataField="CompFeb" HeaderText="Febrero">
                                                    <ItemStyle Width="80px"/>
                                                </asp:BoundField>
                                                
                                                <asp:BoundField DataField="CompMar" HeaderText="Marzo">
                                                    <ItemStyle Width="80px"/>
                                                </asp:BoundField>
                                                
                                                <asp:BoundField DataField="CompAbr" HeaderText="Abril">
                                                    <ItemStyle Width="80px"/>
                                                </asp:BoundField>
                                                
                                                <asp:BoundField DataField="CompMay" HeaderText="Mayo">
                                                    <ItemStyle Width="80px"/>
                                                </asp:BoundField>
                                                
                                                <asp:BoundField DataField="CompJun" HeaderText="Junio">
                                                    <ItemStyle Width="80px"/>
                                                </asp:BoundField>
                                                
                                                <asp:BoundField DataField="CompJul" HeaderText="Julio">
                                                    <ItemStyle Width="80px"/>
                                                </asp:BoundField>
                                                
                                                <asp:BoundField DataField="CompAgo" HeaderText="Agosto">
                                                    <ItemStyle Width="80px"/>
                                                </asp:BoundField>
                                                
                                                <asp:BoundField DataField="CompSet" HeaderText="Setiembre">
                                                    <ItemStyle Width="80px"/>
                                                </asp:BoundField>
                                                
                                                <asp:BoundField DataField="CompOct" HeaderText="Octubre">
                                                    <ItemStyle Width="80px"/>
                                                </asp:BoundField>
                                                
                                                <asp:BoundField DataField="CompNov" HeaderText="Noviembre">
                                                    <ItemStyle Width="80px"/>
                                                </asp:BoundField>
                                                
                                                <asp:BoundField DataField="CompDic" HeaderText="Diciembre">
                                                    <ItemStyle Width="80px"/>
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
                        
                        
                        <% 
                            /*
                            <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
                                               DataKeyNames="IdPrincipal"
                                               onrowcommand="GridView1_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="TextoSimple"  HeaderText="TextoSimple" 
                                                     SortExpression="TextoSimple" />
                                                     
                                        <asp:ButtonField ButtonType="link" CommandName="Campo1" 
                                                     DataTextField="Campo1" HeaderText="Campo1" 
                                                     SortExpression="Campo1" />

                                        <asp:ButtonField ButtonType="link" CommandName="Campo2" 
                                                     DataTextField="Campo2" HeaderText="Campo2" 
                                                     SortExpression="Campo2" />
                                                     
                                        <asp:ButtonField ButtonType="link" CommandName="Campo3" 
                                                     DataTextField="Campo3" HeaderText="Campo3" 
                                                     SortExpression="Campo3" />
                                                     
                                        <asp:ButtonField ButtonType="link" CommandName="Campo4" 
                                                     DataTextField="Campo4" HeaderText="Campo4" 
                                                     SortExpression="Campo4" />
                                        
                                    </Columns>  
                                </asp:GridView>
                            </td>
                        </tr>
                        */
                            %>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>