<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdjuntarDocumento.ascx.cs" 
    Inherits="WebGdoc.WebPage.Controles.AdjuntarDocumento" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="../Controles/ValidarUsuario_Grupo.ascx" tagname="ValidarUsuario_Grupo" tagprefix="uc1" %>

<table cellpadding="0" cellspacing="0" class="FontSistema" style="width:100%">
    <tr>
        <td runat="server" id="tdUser">
            <div runat="server" id="divMargen" class="textbox" style="height:18px;" >
                <asp:Literal runat="server" ID="ltrLink"/>
                <asp:Label runat="server" ID="lblDocAdj" Text=""/>
            </div>
        </td>
        <td style="width:5px">
                                               
        </td>
        <td>
            <asp:ImageButton ID="imgBuscar" runat="server" CssClass="imagen" onclick="imgBuscar_Click" />
        </td>
    </tr>
</table>


<div runat="server" id="divPopup" class="PopupOcultar">
    <asp:ModalPopupExtender ID="mpeAdjuntar" runat="server" TargetControlID="lblDocAdj" 
                            PopupControlID="pnlSearching" PopupDragHandleControlID="pnlSearching"
                            OkControlID="lblDocAdj" 
                            BackgroundCssClass="modalPopup" DropShadow="false"  />

    <asp:Panel ID="pnlSearching" runat="server" CssClass="panel" Height="440px" Width="600px">
        
        <table runat="server" class="FontSistema" id="tbUsuarioParticipante" style="width:100%">
            <tr>
                <td colspan="3">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="CabeceraPopup">
                                <asp:Label runat="server" ID="lblTituloControl" Text="" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="FondoEtiqueta1">
                    <asp:Label ID="Label2" runat="server" Text="Tipo de Busqueda :" CssClass="label" />
                </td>
                <td style="width:500px">
                    <asp:DropDownList ID="ddlTipoOper" runat="server" CssClass="dropdownlist" 
                        AutoPostBack="true" onselectedindexchanged="ddlTipoOper_SelectedIndexChanged">
                        <asp:ListItem Value="2" Selected="True">Documento Electronico</asp:ListItem>
                        <asp:ListItem Value="1">Documento Digital</asp:ListItem>
                        <asp:ListItem Value="0">Archivo de Datos</asp:ListItem>
                        <asp:ListItem Value="3">Archivo Local</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                
                </td>
            </tr>
            <tr>
                <td class="FondoEtiqueta1">
                    <asp:Label ID="Label1" runat="server" Text="N° Documento :" CssClass="label" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtBuscarPersona" Text="" CssClass="textbox"/>
                </td>
                <td>
                    <asp:ImageButton ID="imgBuscar0" runat="server" CssClass="imagen" 
                        OnClick="imgBuscar0_Click" style="width: 14px" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table class="FontSistema"  style="width:100%">
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlUserGrupo" runat="server" GroupingText="Busqueda" CssClass="panel">
                                            <table border="0" cellspacing="0" cellpadding="0" style="width: 100%" class="GVHeader">
                                                <tr> 
                                                    <td align="center" style="width:150px;">N° Documento</td>
                                                    <td align="center" style="width:550px;">Descripcion</td>
                                                    
                                                </tr>
                                            </table>
                                            <div id="scroll" class="divControl">
                                                <asp:GridView ID="gvwDocumentoAdjunto" runat="server" CssClass="GVPrincipal" 
                                                    AutoGenerateColumns="False" ShowHeader="false"
                                                    OnSelectedIndexChanged="gvwDocumentoAdjunto_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:BoundField DataField="CodiDocuDigi" HeaderText="Codigo">
                                                            
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="NumDocuDigi" HeaderText="N° Documento">
                                                            <ItemStyle Width="150" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="NombOrig" HeaderText="Descripcion">
                                                            <ItemStyle Width="550" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TipoBUsqueda" HeaderText="Tipo">
                                                            
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Extension" HeaderText="Extension">
                                                            
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Directorio" HeaderText="File">
                                                            
                                                        </asp:BoundField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID ="ibtnSelec" runat="server"  CommandName="Select" ImageUrl="~/Resources/Imagenes/img_Banderin_Azul_A.jpg" Width ="20px" Height ="15px"/>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
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
                                    <td>
                                        <asp:Panel ID="pnlUserGrupoSeleccionado" runat="server" GroupingText="Seleccionado" CssClass="panel">
                                            <table border="0" cellspacing="0" cellpadding="0" style="width: 100%" class="GVHeader">
                                                <tr> 
                                                    <td align="center" style="width:150px;">N° Documento</td>
                                                    <td align="center" style="width:550px;">Descripcion</td>
                                                    
                                                </tr>
                                            </table>
                                            <div id="scroll" class="divControl">
                                                <asp:GridView ID="gvwDocumentoAdjuntoSeleccionado" runat="server" 
                                                    CssClass="GVPrincipal" AutoGenerateColumns="False" ShowHeader="false"
                                                    OnSelectedIndexChanged="gvwDocumentoAdjuntoSeleccionado_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:BoundField DataField="CodiDocuDigi" HeaderText="Codigo">
                                                            
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="NumDocuDigi" HeaderText="N° Documento">
                                                            <ItemStyle Width="150" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="NombOrig" HeaderText="Descripcion">
                                                            <ItemStyle Width="550" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TipoBUsqueda" HeaderText="Tipo">
                                                            
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Extension" HeaderText="Extension">
                                                            
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Directorio" HeaderText="File">
                                                            
                                                        </asp:BoundField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID ="ibtnSelec" runat="server"  CommandName="Select" ImageUrl="~/Resources/Imagenes/img_EliminarItem_A.jpg" Width ="20px" Height ="15px"/>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
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
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="imgBuscar0" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="ddlTipoOper" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="gvwDocumentoAdjunto" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="gvwDocumentoAdjuntoSeleccionado" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="right">
                    <table>
                        <tr>
                            <td>
                                <asp:Button runat="server" ID="btnAceptar" Text="Aceptar" CssClass="button" onclick="btnAceptar_Click" />
                            </td>
                            <td>
                                <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="button" onclick="btnCancelar_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <input type="hidden" runat="server" id="hdnCantidadUser" value="0" />
                    <!--<input type="hidden" runat="server" id="hdnAprobacionUser" value="true" />-->
                    <input type="hidden" runat="server" id="hdnUserSession" value="false" />
                </td>
            </tr>
        </table>
    </asp:Panel> 
</div>


<div runat="server" id="divArchivoDatos" class="PopupOcultar">
    <asp:ModalPopupExtender ID="mpeArchivoDatos" runat="server" TargetControlID="txtNroDoc" 
                        PopupControlID="pnlArchivoDatos" PopupDragHandleControlID="pnlArchivoDatos"
                        OkControlID="txtNroDoc" 
                        BackgroundCssClass="modalPopup" DropShadow="false"  />
                        
    <asp:Panel ID="pnlArchivoDatos" runat="server" CssClass="panel" Height="300px" Width="450px">
        <table class="FontSistema" style="width:100%;" >               
            <tr>
                <td colspan="3">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="CabeceraPopup">
                                <asp:Label runat="server" ID="Label3" Text="Archivo de Datos" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="FondoEtiqueta1">
                    <asp:Label ID="lblNomOrigArch" runat="server" Text="Nombre Original:" CssClass="label"/>
                </td>
                <td>
                    <asp:TextBox ID="txtNomOrigArch" runat="server" CssClass="textbox"/>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="FondoEtiqueta1">
                    <asp:Label ID="lblClaseDoc" runat="server" Text="Clase de Documento:" CssClass="label"/>
                </td>
                <td>
                    <asp:DropDownList ID="ddlClaseDoc" runat="server" CssClass="dropdownlist" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="FondoEtiqueta1">
                    <asp:Label ID="lblTitulo" runat="server" Text="Título:" CssClass="label"/>
                </td>
                <td>
                    <asp:TextBox ID="txtTitulo" runat="server" CssClass="textbox" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="FondoEtiqueta1">
                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:" CssClass="label"/>
                </td>
                <td>
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="textbox" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="FondoEtiqueta1">
                    <asp:Label ID="lblFecEmision" runat="server" Text="Fecha de Emisión:" CssClass="label"/>
                </td>
                <td valign="bottom">
                    <% //Ejemplo de centrado calendar %>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtFecEmision" runat="server" CssClass="calendar"/>
                            </td>
                            <td style="width:5px">
                                
                            </td>
                            <td>
                                <asp:ImageButton ID="ibtnFecEmision" runat="server" CssClass="imagen"/>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="ibtnFecEmision" TargetControlID="txtFecEmision" Format="dd/MM/yyyy" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="FondoEtiqueta1">
                    <asp:Label ID="Label8" runat="server" Text="Tipo de Acceso:" CssClass="label"/>
                </td>
                <td class="radioButton" align="left" >
                    <asp:RadioButtonList runat="server" ID="rbtnNivelAcceso" CssClass="radioButton" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Público" Value="PU" />
                        <asp:ListItem Text="Privado" Value="PR" />
                    </asp:RadioButtonList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="FondoEtiqueta1">
                    <asp:Label ID="lblUsuRemi" runat="server" Text="Propietario:" CssClass="label"/>
                </td>
                <td>                    
                    <uc1:ValidarUsuario_Grupo ID="ctlUser" runat="server" WithTexto="98" UserSesion="true" AprobacionUser="false" UserModeText="" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="FondoEtiqueta1">
                    <asp:Label ID="lblElegirArch" runat="server" Text="Elegir Archivo:" CssClass="label"/>
                </td>
                <td style="width:300px">
                    <asp:FileUpload ID="uplServerFTP" runat="server" class="examinar"/>                
                </td>
                <td>                    
                </td> 
            </tr>
             <tr>
                <td colspan="3" align="right">
                    <br />
                    <table>
                        <tr>
                            <td>
                                <asp:Button runat="server" ID="btnAceptarArchivoDatos" Text="Aceptar" CssClass="button" onclick="btnAceptarArchivoDatos_Click" />
                            </td>
                            <td>
                                <asp:Button runat="server" ID="btnCancelarArchivoDatos" Text="Cancelar" CssClass="button" onclick="btnCancelarArchivoDatos_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:Label ID="lblCodDig" runat="server"  CssClass="label" Visible="false"/>
        <asp:Label ID="lblNumDig" runat="server"  CssClass="label" Visible="false"/>
    </asp:Panel> 
</div>