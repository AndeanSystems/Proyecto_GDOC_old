<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Inicio/mpFEPCMAC.Master"
    AutoEventWireup="true" CodeBehind="frmGrupo.aspx.cs" Inherits="WebGdoc.WebPage.Configuracion.frmGrupo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="../Controles/ValidarUsuario_Grupo.ascx" tagname="ValidarUsuario_Grupo" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="BarraHerramientas"  cellpadding="0" cellspacing="0">
        <tr>
            <td class="TituloPagina">
                &nbsp; &nbsp;
                <asp:Label runat="server" ID="lblTituloPagina" Text="Grupos " />
            </td>
            
            <td class="AccesoDirecto">
                                
                <asp:ImageButton runat="server" ID="ibtnNuevo" AlternateText="Nuevo" CssClass='LinkURL' onclick="ibtnNuevo_Click" />
                <asp:ImageButton runat="server" ID="ibtnGuardar"  AlternateText="Guardar" CssClass='LinkURL' onclick="ibtnGuardar_Click" />
                <asp:ImageButton runat="server" ID="ibtnEliminar" AlternateText="Eliminar" CssClass='LinkURL' onclick="ibtnEliminar_Click" OnClientClick="return confirm('Desea Elimina el Grupo');"/>
                <asp:ImageButton runat="server" ID="ibtnRegresar" AlternateText="Regresar" CssClass='LinkURL' onclick="ibtnRegresar_Click"/>
                &nbsp; &nbsp;
            </td>
        </tr>
    </table>
    
    <div>      
       <table runat="server" id="tbPrincipal" class="Principal">
            <tr>
                <td align="left" valign="top">
                    <asp:Panel ID="Panel1" runat="server" CssClass="panelBorder">
                        <table class="Principal1" width="100%">
                            <tr>
                                <td>
                                    <table width="100%">
                                        <tr>
                                            <td class="FondoEtiqueta1" >
                                                <asp:Label ID="lblGrupo" runat="server" Text="Grupo" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="width:380">
                                                <asp:TextBox ID="txtGrupo" runat="server" CssClass="textbox" ontextchanged="txtGrupo_TextChanged"></asp:TextBox>
                                            </td>                                              
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblParticipantes" runat="server" Text="Participantes" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="width:380">
                                                <uc1:ValidarUsuario_Grupo ID="ct1UserPart" runat="server" WithTexto="98" AprobacionUser="false" TituloControl="SELECCIONE USUARIO" UserModeText="MultiLine" />
                                            </td>
                                           
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblComentario" runat="server" Text="Comentario" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="width:380">
                                                <asp:TextBox ID="txtComentario" runat="server" TextMode="MultiLine" CssClass="multiline" ></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                <asp:Panel ID="pnlHistorial" runat="server" GroupingText="Grupos" CssClass="panel">
                                <table border="0" cellspacing="0" cellpadding="0" style="width: 100%" class="GVHeader">
                                    <tr>
                                        <td align="center" style="width:150px;">Grupo</td>
                                        <td align="center" style="width:450px;">Participante(s)</td>
                                        <td align="center" style="width:60px;">Estado</td>
                                        <td align="center" style="width:15px;">Ver</td>
                                   </tr>
                                </table>
                                    <div runat="server" id="divGrupo" class="divGrupos">
                                        <asp:GridView ID="gvwGrupos" runat="server" AutoGenerateColumns="False" 
                                            CssClass="GVPrincipal" onselectedindexchanged="gvwGrupos_SelectedIndexChanged" 
                                            DataKeyNames ="sCodGrupo" ShowHeader ="false">
                                            <Columns>
                                                <asp:BoundField DataField="sCodGrupo" HeaderText="Grupo" HtmlEncode="false" Visible="false">
                                                    <ItemStyle Width="10" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="sNomGrupo" HeaderText="Grupo" HtmlEncode="false">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="sParticipante" HeaderText="Participante(s)" 
                                                    HtmlEncode="false">
                                                    <ItemStyle Width="690px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="sEstado" HeaderText="Estado" HtmlEncode="false">
                                                    <ItemStyle Width="60px" />
                                                </asp:BoundField>
                                                <asp:CommandField HeaderText="Ver" 
                                                    SelectText="&lt;img runat='server' id='imgLink' src='../../Resources/Imagenes/img_Banderin_Azul_A.jpg' border='0' class='imgBE'/&gt;" 
                                                    ShowSelectButton="True" >
                                                    <ItemStyle HorizontalAlign="Center" Width="10px" />
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
                        </table>    
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <asp:Label ID="lblCodGrup" runat="server" CssClass="label" Visible ="false"></asp:Label>
        <asp:Label ID="lblCod" runat="server" CssClass="label" Visible ="false"></asp:Label>
    </div>
</asp:Content>
