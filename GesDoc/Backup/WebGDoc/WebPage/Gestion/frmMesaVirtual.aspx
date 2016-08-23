<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Inicio/mpFEPCMAC.Master"
    AutoEventWireup="true" CodeBehind="frmMesaVirtual.aspx.cs" Inherits="WebGdoc.WebPage.Gestion.frmMesaVirtual" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../Controles/ValidarUsuario_Grupo.ascx" TagName="ValidarUsuario_Grupo"
    TagPrefix="uc1" %>
<%@ Register Src="../Controles/AdjuntarDocumento.ascx" TagName="ValidarAdjuntarDocumento"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="BarraHerramientas" cellpadding="0" cellspacing="0">
        <tr>
            <td class="TituloPagina">
                &nbsp; &nbsp;
                <asp:Label runat="server" ID="lblTituloPagina" Text="Mesa de Trabajo Virtual" />
            </td>
            <td class="AccesoDirecto">
                <asp:ImageButton runat="server" ID="ibtnNuevo" AlternateText="Nuevo" CssClass='LinkURL'
                    OnClick="ibtnNuevo_Click" />
                <asp:ImageButton runat="server" ID="ibtnEditar" AlternateText="Editar" CssClass='LinkURL'
                    OnClick="ibtnEditar_Click" />
                <asp:ImageButton runat="server" ID="ibtnGuardar" AlternateText="Guardar" CssClass='LinkURL'
                    OnClick="ibtnGuardar_Click" />
                <asp:ImageButton runat="server" ID="ibtnEnviar" AlternateText="Publicar" CssClass='LinkURL'
                    OnClick="ibtnEnviar_Click" OnClientClick="return confirm('Desea Publica la Mesa de Trabajo Virtual');" />
                <asp:ImageButton runat="server" ID="ibtnCerrar" AlternateText="Cerrar Mesa Virtual"
                    CssClass='LinkURL' OnClick="ibtnCerrar_Click" OnClientClick="return confirm('Desea Cerrar la Mesa de Trabajo Virtual');" />
                <asp:ImageButton runat="server" ID="ibtnEliminar" AlternateText="Eliminar" CssClass='LinkURL'
                    OnClick="ibtnEliminar_Click" OnClientClick="return confirm('Desea Eliminar la Mesa de Trabajo Virtual');" />
                <asp:ImageButton runat="server" ID="ibtnRegresar" AlternateText="Regresar" CssClass='LinkURL'
                    OnClick="ibtnRegresar_Click" />
                &nbsp; &nbsp;
            </td>
        </tr>
    </table>
    <table runat="server" id="tbPrincipal" class="Principal" style="width: 100%">
        <tr>
            <td align="left" valign="top">
                <table class="FontSistema" style="width: 100%">
                    <tr>
                        <td>
                            <asp:Panel ID="Panel1" runat="server" GroupingText="Opciones de la Mesa Virtual"
                                CssClass="panel">
                                <table class="FontSistema" style="width: 100%">
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label runat="server" ID="lblNroDoc" Text="N° de Mesa:" CssClass="label" />
                                        </td>
                                        <td style="width: 350px">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 320px">
                                                        <asp:TextBox ID="txtNroDoc" runat="server" CssClass="textbox" />
                                                    </td>
                                                    <td style="width: 5px">
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton runat="server" ID="ibtnBuscar" AlternateText="Buscar" CssClass='imagen'
                                                            OnClick="ibtnBuscar_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label runat="server" ID="lblTipoMesaV" Text="Tipo Mesa-V:" CssClass="label" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlTipoMesaV" runat="server" CssClass="dropdownlist">
                                                <asp:ListItem Value="1">PROYECTOS</asp:ListItem>
                                                <asp:ListItem Value="2">DOCUMENTOS</asp:ListItem>
                                                <asp:ListItem Value="3">INFORMES</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label runat="server" ID="lblTipoAcceso" Text="Tipo de Acceso:" CssClass="label" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlTipoAcceso" runat="server" CssClass="dropdownlist" />
                                        </td>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label runat="server" ID="lblPriorAtenc" Text="Prioridad Atención:" CssClass="label" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPriorAtenc" runat="server" CssClass="dropdownlist" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label runat="server" ID="lblFecOrganizacion" Text="Fecha de Apertura:" CssClass="label" />
                                        </td>
                                        <td valign="bottom">
                                            <% //Ejemplo de centrado calendar %>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtFecOrganizacion" runat="server" CssClass="calendar" AutoPostBack="True"
                                                            OnTextChanged="txtFecOrganizacion_TextChanged" />
                                                    </td>
                                                    <td style="width: 5px">
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="ibtnFecOrganizacion" runat="server" CssClass="imagen" />
                                                        <asp:CalendarExtender ID="calFecCon" runat="server" PopupButtonID="ibtnFecOrganizacion"
                                                            TargetControlID="txtFecOrganizacion" Format="dd/MM/yyyy" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label runat="server" ID="lblFecCierre" Text="Fecha de Cierre:" CssClass="label" />
                                        </td>
                                        <td align="left">
                                            <% //Ejemplo de centrado calendar %>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtFecCierre" runat="server" CssClass="calendar" AutoPostBack="True" />
                                                    </td>
                                                    <td style="width: 5px">
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="ibtnCalendFCier" runat="server" CssClass="imagen" />
                                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="ibtnCalendFCier"
                                                            TargetControlID="txtFecCierre" Format="dd/MM/yyyy" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label runat="server" ID="lblNotificarAccion" Text="Notificar Acciones:" CssClass="label" />
                                        </td>
                                        <td align="left" class="radioButton">
                                            <asp:RadioButtonList runat="server" ID="rbtNotificarAccion" CssClass="radioButton"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Si" Value="S" />
                                                <asp:ListItem Text="No" Value="N" />
                                            </asp:RadioButtonList>
                                        </td>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label runat="server" ID="lblEstadoMesa" Text="Estado Mesa:" CssClass="label" />
                                        </td>
                                        <td align="left">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 105px">
                                                        <asp:Label runat="server" ID="lblEstadoMV" CssClass="label" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel2" runat="server" GroupingText="Contenido de la Mesa Virtual"
                                CssClass="panel">
                                <table class="FontSistema" style="width: 100%">
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label runat="server" ID="lblTitulo" Text="Título:" CssClass="label" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTitulo" runat="server" CssClass="textbox" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label runat="server" ID="lblAsunto" Text="Asunto:" CssClass="label" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAsunto" runat="server" CssClass="textbox" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label runat="server" ID="lblParticipantes" Text="Organizador:" CssClass="label" />
                                        </td>
                                        <td colspan="3">
                                            <uc1:ValidarUsuario_Grupo ID="ctlUserInagurador" runat="server" UserSesion="true"
                                                WithTexto="99" AprobacionUser="false" UserModeText="" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="Label1" runat="server" Text="Invitados :" CssClass="label" />
                                        </td>
                                        <td colspan="3">
                                            <uc1:ValidarUsuario_Grupo ID="ctlUserParticipante" runat="server" WithTexto="99"
                                                TituloControl="Participantes Invitados" UserModeText="MultiLine" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label runat="server" ID="lblAdjunto" Text="Documento Adjunto:" CssClass="label" />
                                        </td>
                                        <td colspan="3">
                                            <uc1:ValidarAdjuntarDocumento ID="ctlAdjuntarDocumento" runat="server" WithTexto="99"
                                                TituloControl="SELECCIONE ARCHIVO ADJUNTAR" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:Label runat="server" ID="lblCodOper" CssClass="label" Visible="false" />
                                <asp:Label runat="server" ID="lblNumOper" CssClass="label" Visible="false" />
                                <asp:Label runat="server" ID="lblNumPart" CssClass="label" Visible="false" />
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div runat="server" id="divRpst" class="PopupOcultar">
                                <asp:Panel ID="Panel3" runat="server" GroupingText="Respuestas" CssClass="panel">
                                    <table class="FontSistema" style="width: 100%">
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblAprobados" runat="server" Text="Aprobado" CssClass="label" />
                                            </td>
                                            <td style="width: 100%">
                                                <asp:TextBox ID="txtAprobados" runat="server" CssClass="textbox" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="ldlDesaprobados" runat="server" CssClass="label" Text="Rechazado" />
                                            </td>
                                            <td style="width: 100%">
                                                <asp:TextBox ID="txtRechazado" runat="server" CssClass="textbox" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div runat="server" id="divComen" class="PopupOcultar">
                                <asp:Panel ID="pnlComentario" runat="server" GroupingText="Comentarios" CssClass="panel">
                                    <table class="FontSistema" style="width: 100%">
                                        <tr>
                                            <td class="FondoEtiqueta1" rowspan="2">
                                                <asp:Label ID="lblComentario" runat="server" Text="Comentario" CssClass="label" />
                                            </td>
                                            <td rowspan="2" style="width: 680px">
                                                <asp:TextBox ID="txtComentario" runat="server" TextMode="MultiLine" CssClass="multiline" />
                                            </td>
                                            <td class="Fondobutton">
                                                <asp:Button ID="btnComentar" runat="server" Text="Comentar" CssClass="button" OnClick="btnComentar_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label runat="server" ID="Label2" Text="Documento Adjunto:" CssClass="label" />
                                            </td>
                                            <td>
                                                <uc1:ValidarAdjuntarDocumento ID="ComentarioAdjuntarDocumento" runat="server" WithTexto="99"
                                                    TituloControl="SELECCIONE ARCHIVO ADJUNTAR" />
                                            </td>
                                            <td align="center">
                                                <asp:ImageButton runat="server" ID="ibtnNuevoComent" AlternateText="Limpiar" CssClass='LinkURL'
                                                    OnClick="ibtnNuevoComent_Click" Visible="false" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div runat="server" id="divHistorial" class="PopupOcultar">
                                <asp:Panel ID="pnlHistorial" runat="server" GroupingText="Historial de Comentarios"
                                    CssClass="panel">
                                    <table border="0" cellspacing="0" cellpadding="0" style="width: 100%">
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="right">
                                                <asp:ImageButton runat="server" ID="ibtnActualizar" AlternateText="Actualizar" CssClass='LinkURL'
                                                    OnClick="ibtnActualizar_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table border="0" cellspacing="0" cellpadding="0" style="width: 100%" class="GVHeader">
                                                    <tr>
                                                        <td align="center" style="width: 140px;">
                                                            Fecha y Hora
                                                        </td>
                                                        <td align="center" style="width: 80px;">
                                                            Participante(s)
                                                        </td>
                                                        <td align="center" style="width: 500px;">
                                                            Comentario
                                                        </td>
                                                        <td align="center" style="width: 15px;">
                                                            Adjunto
                                                        </td>
                                                        <td align="center" style="width: 35px;">
                                                            Ver
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div runat="server" id="divGrupo" class="divControl">
                                                    <asp:GridView ID="gvwComentarios" runat="server" AutoGenerateColumns="False" CssClass="GVPrincipal"
                                                        DataKeyNames="sCodiComen" OnSelectedIndexChanged="gvwComentarios_SelectedIndexChanged"
                                                        ShowHeader="false" Width="98%">
                                                        <Columns>
                                                            <asp:BoundField DataField="sCodiComen" HeaderText="CodiCOmen" HtmlEncode="false"
                                                                Visible="false">
                                                                <ItemStyle Width="1px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="sFechaHora" HeaderText="Fecha y Hora" HtmlEncode="false">
                                                                <ItemStyle Width="135px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="sParticipante" HeaderText="Participante(s)" HtmlEncode="false">
                                                                <ItemStyle Width="80px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="sComentario" HeaderText="Comentario" HtmlEncode="false">
                                                                <ItemStyle Width="500px" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="A">
                                                                <ItemTemplate>
                                                                    <img runat="server" id="imgLink2" src="../../Resources/Imagenes/img_Adjuntar_A.jpg"
                                                                        border="0" class="imgBE" />
                                                                </ItemTemplate>
                                                                <ItemStyle Width="35px" HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:CommandField HeaderText="Ver" SelectText="&lt;img runat='server' id='imgLink' src='../../Resources/Imagenes/img_Banderin_Azul_A' border='0' class='imgBE'/&gt;"
                                                                ShowSelectButton="True">
                                                                <ItemStyle HorizontalAlign="Center" Width="10px" />
                                                            </asp:CommandField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="GVHeader" />
                                                        <RowStyle CssClass="GVItems" />
                                                        <AlternatingRowStyle CssClass="GVItemsAlt" />
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                            <tr>
                                                <td>
                                                </td>
                                            </tr>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div runat="server" id="divApro" class="PopupOcultar">
                                <asp:Panel ID="pnlAprobar" runat="server" GroupingText="Aprobaciones" CssClass="panel">
                                    <table class="FontSistema" style="width: 100%">
                                        <tr>
                                            <td class="FondoEtiqueta1" rowspan="2">
                                                <asp:Label ID="lblObservaciones" runat="server" Text="Comentario" CssClass="label" />
                                            </td>
                                            <td rowspan="2" style="width: 680px">
                                                <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" CssClass="multiline" />
                                            </td>
                                            <td class="Fondobutton">
                                                <asp:Button ID="btnAutorizAprobar" runat="server" Text="Aprobar" CssClass="button"
                                                    OnClick="btnAutorizAprobar_Click" OnClientClick="return confirm('Desea Aprobar la Mesa de Trabajo Virtual?');" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Fondobutton">
                                                <asp:Button ID="btnAutorizRechazar" runat="server" Text="Rechazar" CssClass="button"
                                                    OnClick="btnAutorizRechazar_Click" OnClientClick="return confirm('Desea Rechazar la Mesa de Trabajo Virtual?');" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
