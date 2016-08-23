<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Inicio/mpFEPCMAC.Master"
    AutoEventWireup="true" CodeBehind="frmEscritorioVirtual.aspx.cs" Inherits="WebGdoc.WebPage.Inicio.frmEscritorioVirtual" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="BarraHerramientas" cellpadding="0" cellspacing="0">
        <tr>
            <td class="TituloPagina">
                &nbsp; &nbsp;
                <asp:Label runat="server" ID="lblTituloPagina" Text="Escritorio Virtual " />
            </td>
            
            <td class="AccesoDirecto">
                <asp:ImageButton runat="server" ID="ibtnActualizar" AlternateText="Actualizar" CssClass='LinkURL' onclick="ibtnActualizar_Click" />
                 &nbsp; &nbsp;                               
            </td>
        </tr>
    </table>
    
    <table runat="server" id="tbPrincipal">
        <tr>
            <td style="width: 50%;" valign="top">
                <asp:Panel ID="pnlAlertas" runat="server" GroupingText="Alertas recibidas: " CssClass="panel">
                    <table border="0" cellspacing="0" cellpadding="0" style="width: 100%" class="GVHeader">
                        <tr>
                            <td align="center" style="width:65px;">Hora </td>
                            <td align="center" style="Width:350px;">Mensaje</td>
                            <td align="left" style="Width:35px;">Ver</td>
                       </tr>
                    </table>
                    <div id="scroll" class="divTotal" >
                        <asp:GridView ID="gvwAlertasRec" runat="server" AutoGenerateColumns="False" 
                            CssClass="GVPrincipal" ShowHeader="False" 
                            DataKeyNames="sCodiOper,sTipoOper" 
                            onselectedindexchanged="gvwAlertasRec_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="sHora" HeaderText="Hora">
                                    <ItemStyle Width="65px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="sMensaje" HeaderText="Mensaje">
                                    <ItemStyle Width="350px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="sCodiOper" HeaderText="Codigo" Visible="False" />
                                <asp:BoundField DataField="sTipoOper" HeaderText="Tipo Operacion" 
                                    Visible="False" />
                                <asp:CommandField HeaderText="Ver" 
                                    SelectText="&lt;img runat='server' id='imgLink' src='../../Resources/Imagenes/img_Alerta_A.jpg' border='0' class='imgBE'/&gt;" 
                                    ShowSelectButton="True">
                                    <ItemStyle HorizontalAlign="Center" Width="25px" />
                                </asp:CommandField>
                            </Columns>
                            <HeaderStyle CssClass="GVHeader" />
                            <RowStyle CssClass="GVItems" />
                            <AlternatingRowStyle CssClass="GVItemsAlt" />
                        </asp:GridView>
                    </div>
                </asp:Panel>
            </td>
            
            <td style="width: 50%" valign="top">
                <asp:Panel ID="pnlMesasV" runat="server" GroupingText="Documentos Recibidos: " CssClass="panel">
                    <table border="0" cellspacing="0" cellpadding="0" style="width: 100%" class="GVHeader">
                        <tr> 
                            <td align="center" style="width:65px;">Hora </td>
                            <td align="center" style="width:90px;">Emisor</td>
                           <!-- <td align="center" style="width:35px;">Tipo</td> -->
                            <td align="center" style="width:255px;">Asunto</td>
                            <td align="left" style="Width:35px;">Ver</td>
                       </tr>
                    </table>
                 
                    <div id="scroll" class="divTotal">
                        <asp:GridView ID="gvwDocumentos" runat="server" AutoGenerateColumns="False" ShowHeader="false"
                                      CssClass="GVPrincipal" DataKeyNames="sCodDoc" 
                                      onselectedindexchanged="gvwDocumentos_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="sCodDoc" HeaderText="Codigo" Visible="false">
                                    <ItemStyle Width="0px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="sHora" HeaderText="Hora">
                                    <ItemStyle Width="65px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="sAutor" HeaderText="Emisor">
                                    <ItemStyle Width="90px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="sTipo" HeaderText="Tipo">
                                    <ItemStyle Width="35px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="sAsunto" HeaderText="Asunto">
                                    <ItemStyle Width="255px" />
                                </asp:BoundField>
                                <asp:CommandField HeaderText="Ver" 
                                    SelectText="&lt;img runat='server' id='imgLink' src='../../Resources/Imagenes/img_Documento_A.jpg' border='0' class='imgBE'/&gt;" 
                                    ShowSelectButton="True">
                                    <ItemStyle HorizontalAlign="Center" Width="25px" />
                                </asp:CommandField>
                            </Columns>
                            <HeaderStyle CssClass="GVHeader" />
                            <RowStyle CssClass="GVItems" />
                            <AlternatingRowStyle CssClass="GVItemsAlt" />
                        </asp:GridView>
                    </div>    
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Panel ID="pnlBusqueda" runat="server" GroupingText ="Buscar Mis Documentos:" CssClass="panel">
                    <table>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblBuscar" Text="Buscar" CssClass="label"/>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtBuscarAll" Text="" Width="380px" 
                                    CssClass="textbox" ontextchanged="txtBuscarAll_TextChanged" />
                            </td>
                            <td>
                                <asp:ImageButton runat="server" ID="ibtBuscar" Width="25px" Height="25px" onclick="ibtBuscar_Click" />
                            </td>
                        </tr>
                        <tr style="display:none">
                            <td class="label" colspan="3" align="right">
                                <asp:Label runat="server" ID="lblResultado" Text="Resultados: 0 registros encontrados" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" valign="top">
                                <table border="0" cellspacing="0" cellpadding="0" style="width: 100%;" class="GVHeader">
                                    <tr>
                                        <td align="center" style="Width:150px;">Documento</td>
                                        <td align="center" style="Width:350px;">Asunto</td>                                 
                                        <td align="left" style="Width:35px;">Ver</td>
                                   </tr>
                                </table>
                            
                                <div id="scroll" class="divTotal1">
                                    <asp:GridView ID="gvwBusquedaAlertas" runat="server" ShowHeader="false" 
                                                  AutoGenerateColumns="False" CssClass="GVPrincipal" DataKeyNames="sCodigo"
                                                  onselectedindexchanged="gvwBusquedaAlertas_SelectedIndexChanged" >
                                        <Columns>
                                            <asp:BoundField DataField="sNumDoc" HeaderText="Documento">
                                                <ItemStyle Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="sAsunto" HeaderText="Asunto">
                                                <ItemStyle Width="350px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="sCodigo" Visible="false" />
                                            <asp:CommandField HeaderText="Ver" 
                                                SelectText="&lt;img runat='server' id='imgLink' src='../../Resources/Imagenes/img_Documento_A.jpg' border='0' class='imgBE'/&gt;" 
                                                ShowSelectButton="True">
                                                <ItemStyle HorizontalAlign="Center" Width="25px" />
                                            </asp:CommandField>
                                        </Columns>
                                        <HeaderStyle CssClass="GVHeader" />
                                        <RowStyle CssClass="GVItems" />
                                        <AlternatingRowStyle CssClass="GVItemsAlt" />
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td valign="top">
                <asp:Panel ID="pnlDocRec" runat="server" GroupingText="Mesas de Trabajo Virtual: Activas" CssClass="panel">
                    <table border="0" cellspacing="0" cellpadding="0" style="width: 100%;" class="GVHeader">
                        <tr>
                            <td align="center" style="Width:80px;">Fecha Org.</td>
                            <td align="center" style="Width:100px;">Organiza</td>
                            <td align="center" style="Width:240px;">Asunto</td>                      
                            <td align="left" style="Width:35px;">Ver</td>
                        </tr>
                    </table>
                
                    <div id="scroll" class="divTotal">
                        <asp:GridView ID="gvwMesaVirtual" runat="server" AutoGenerateColumns="False" 
                                      CssClass="GVPrincipal" DataKeyNames="sMesaVirtual" ShowHeader="false"
                                      onselectedindexchanged="gvwMesaVirtual_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="sMesaVirtual" HeaderText="Mesa Virtual" Visible="false">
                                    <ItemStyle Width="0px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="sFecOrganizacion" HeaderText="Fecha Org.">
                                    <ItemStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="sOrganizador" HeaderText="Organiza">
                                    <ItemStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="sAsunto" HeaderText="Asunto">
                                    <ItemStyle Width="240px" />
                                </asp:BoundField>
                                <asp:CommandField HeaderText="Ver" 
                                    SelectText="&lt;img runat='server' id='imgLink' src='../../Resources/Imagenes/img_Documento_A.jpg' border='0' class='imgBE'/&gt;" 
                                    ShowSelectButton="True">
                                    <ItemStyle HorizontalAlign="Center" Width="25px" />
                                </asp:CommandField>
                            </Columns>
                            <HeaderStyle CssClass="GVHeader" />
                            <RowStyle CssClass="GVItems" />
                            <AlternatingRowStyle CssClass="GVItemsAlt" />
                        </asp:GridView>
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="height:10px">
            
            </td>
        </tr>
    </table>
    
    <asp:Label ID="lblCodDoc" runat="server"  CssClass="label" Visible="false"/>
</asp:Content>
