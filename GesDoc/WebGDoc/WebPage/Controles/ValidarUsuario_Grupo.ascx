<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ValidarUsuario_Grupo.ascx.cs" 
    Inherits="WebGdoc.WebPage.Controles.ValidarUsuario_Grupo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<table cellpadding="0" cellspacing="0" class="FontSistema" style="width:100%">
    <tr>
        <td runat="server" id="tdUser">
            <asp:TextBox runat="server" ID="txtUsuarios" Enabled="false" />
        </td>
        <td style="width:5px">
                                               
        </td>
        <td>
            <asp:ImageButton ID="imgBuscar" runat="server" CssClass="imagen" onclick="imgBuscar_Click" />
        </td>
    </tr>
</table>


<div runat="server" id="divPopup" class="PopupOcultar">
    <asp:ModalPopupExtender ID="mpeAdjuntar" runat="server" TargetControlID="txtUsuarios" 
                            PopupControlID="pnlSearching" PopupDragHandleControlID="pnlSearching"
                            OkControlID="txtUsuarios" 
                            BackgroundCssClass="modalPopup" DropShadow="false"  />

    <asp:Panel ID="pnlSearching" runat="server" CssClass="panel" Height="425px" Width="600px">
        
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
                <td class="FondoEtiqueta">
                    <asp:Label ID="Label1" runat="server" Text="Nombre :" CssClass="label" />
                </td>
                <td style="width:500px">
                    <asp:TextBox runat="server" ID="txtBuscarPersona" Text="" CssClass="textbox"/>
                </td>
                <td>
                    <asp:ImageButton ID="imgBuscar0" runat="server" CssClass="imagen" OnClick="imgBuscar0_Click" />
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
                                                    <td align="center" style="width:250px;">Nombre(s) y Apellido(s)</td>
                                                    <td align="center" style="width:270px;">Cargo</td>
                                                    <td align="left" style="Width:35px;">Ver</td>
                                                </tr>
                                            </table>
                                            <div id="scroll" class="divControl">
                                                <asp:GridView ID="gvwUsuarioGrupo" runat="server" CssClass="GVPrincipal" 
                                                    AutoGenerateColumns="False"  ShowHeader="false"
                                                    OnSelectedIndexChanged="gvwUsuarioGrupo_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:BoundField DataField="Codigo" HeaderText="CodUser">
                                                            
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="IdeUsuario" HeaderText="Usuario">
                                                            <ItemStyle Width="100" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CodigoPersona" HeaderText="CodigoPersona">
                                                            
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="NombPers" HeaderText="Nombre(s) y Apellido(s)" HtmlEncode="false">
                                                            <ItemStyle Width="250" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DescCarg" HeaderText="Cargo" HtmlEncode="false">
                                                            <ItemStyle Width="270" />
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
                                                    <td align="center" style="width:250px;">Nombre(s) y Apellido(s)</td>
                                                    <td align="center" style="width:270px;">Cargo</td>
                                                    <td align="left" style="Width:35px;">Seleccione</td>
                                                </tr>
                                            </table>
                                            <div id="scroll" class="divControl">
                                                <asp:GridView ID="gvwUsuarioGrupoSeleccionado" runat="server" 
                                                    CssClass="GVPrincipal" AutoGenerateColumns="False" ShowHeader="false"
                                                    OnSelectedIndexChanged="gvwUsuarioGrupoSeleccionado_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:BoundField DataField="Codigo" HeaderText="CodUser">
                                                            
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="IdeUsuario" HeaderText="Usuario">
                                                            <ItemStyle Width="100" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CodigoPersona" HeaderText="CodigoPersona">
                                                            
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="NombPers" HeaderText="Nombre(s) y Apellido(s)" HtmlEncode="false">
                                                            <ItemStyle Width="250" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DescCarg" HeaderText="Cargo" HtmlEncode="false">
                                                            <ItemStyle Width="270" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                A
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="cbxAutorizar" runat="server" Checked='<%#Eval("Autorizar") %>'  />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
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
                            <asp:AsyncPostBackTrigger ControlID="gvwUsuarioGrupo" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="gvwUsuarioGrupoSeleccionado" EventName="SelectedIndexChanged" />
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
                    <input type="hidden" runat="server" id="hdnAprobacionUser" value="true" />
                    <input type="hidden" runat="server" id="hdnUserSession" value="false" />
                </td>
            </tr>
        </table>
    </asp:Panel> 
</div>