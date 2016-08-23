<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Inicio/mpFEPCMAC.Master" ValidateRequest="false"
    AutoEventWireup="true" CodeBehind="frmDocumentoElectronico.aspx.cs" Inherits="WebGdoc.WebPage.Gestion.frmDocumentoElectronico" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="../Controles/ValidarUsuario_Grupo.ascx" tagname="ValidarUsuario_Grupo" tagprefix="uc1" %>
<%@ Register src="../Controles/AdjuntarDocumento.ascx" tagname="ValidarAdjuntarDocumento" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script>
    function ConfirmarEnvioRemitente() {
        var enviar = $("[id$='lblEnvNotRem']").text();
        if (enviar == "True") {
            if (confirm("¿Desea enviar notificación a los remitentes?"))
                return true;
            else
                return false;
        }
        else
            return true;
    }
</script> 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input id="envioAlerta" type="hidden" runat="server"/>
    <table class="BarraHerramientas" cellpadding="0" cellspacing="0">
        <tr>
            <td class="TituloPagina">
                &nbsp; &nbsp;
                <asp:Label runat="server" ID="lblTituloPagina" Text="Documento Electronico" />
            </td>
            
            <td class="AccesoDirecto">
                <asp:ImageButton runat="server" ID="ibtnNuevo" AlternateText="Nuevo Documento" CssClass='LinkURL' onclick="ibtnNuevo_Click" />
                <asp:ImageButton runat="server" ID="ibtnEditar" AlternateText="Editar" CssClass='LinkURL' onclick="ibtnEditar_Click"/>
                <asp:ImageButton runat="server" ID="ibtnGuardar" OnClientClick ="return ConfirmarEnvioRemitente()"  AlternateText="Guardar Documento sin Enviar" CssClass='LinkURL' onclick="ibtnGuardar_Click"/>
                <asp:ImageButton runat="server" ID="ibtnEnviar" AlternateText="Guardar y Enviar" CssClass='LinkURL' onclick="ibtnEnviar_Click" OnClientClick="return confirm('Desea Enviar el Documento Electronico');"/>
                <asp:ImageButton runat="server" ID="ibtnReenviar" AlternateText="Reenviar" CssClass='LinkURL' onclick="ibtnReenviar_Click" />
                <asp:ImageButton runat="server" ID="ibtnEliminar" AlternateText="Eliminar" CssClass='LinkURL' onclick="ibtnEliminar_Click" OnClientClick="return confirm('Desea Eliminar el Documento Electronico');"/>
                <asp:ImageButton runat="server" ID="ibtnRegresar" AlternateText="Regresar" CssClass='LinkURL' onclick="ibtnRegresar_Click"/>
                &nbsp; &nbsp;
            </td>
        </tr>
    </table>

    <table runat="server" id="tbPrincipal" class="Principal">
        <tr>
            <td align="left" valign="top">
                <table class="FontSistema" style="width:100%" >
                    <tr>
                        <td>
                            <asp:Panel ID="pnlDstntrConfEnvio" runat="server" GroupingText="Opciones del Documento" CssClass="panel">
                                <table class="FontSistema" style="width:100%" >
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label runat="server" ID="lblNroDoc" Text="N° de Documento:" CssClass="label" />
                                        </td>
                                        <td style="width:320px">
                                            <table cellpadding="0" cellspacing="0" > 
                                                <tr>
                                                    <td style="width:295px">
                                                        <asp:TextBox runat="server" ID="txtNroDoc" Text="" CssClass="textbox" />
                                                    </td>
                                                    <td style="width:5px">
                                                    
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton runat="server" ID="ibtnBuscar" AlternateText = "Buscar Documento" CssClass="imagen" onclick="ibtnBuscar_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td colspan="2" style="text-align:right;">
                                            <asp:ImageButton runat="server" ID="ibtnMemos" AlternateText="Ver comentarios" 
                                                CssClass='LinkURL' onclick="ibtnVerComentarios_Click" Height="20px"
                                                Width="20px"/>    
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label runat="server" ID="lblTipoAcceso" Text="Tipo de Acceso:" CssClass="label" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="dllTipoAcceso" runat="server" CssClass="dropdownlist" />
                                        </td>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label runat="server" ID="lblTipoDoc" Text="Tipo de Documento:" CssClass="label" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlTipoDoc" runat="server" CssClass="dropdownlist" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label runat="server" ID="lblTipoComunicacion" Text="Tipo de Comunicación:" CssClass="label" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="dropdownlist">
                                                <asp:ListItem Text="INTERNA" Value="1" />
                                                <asp:ListItem Text="EXTERNA" Value="2" />
                                            </asp:DropDownList>
                                        </td>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label runat="server" ID="lblPlazoConfirmacion" Text="Plazo de Confirmación:" CssClass="label" />

                                        </td>
                                        <td>
                                        <table cellpadding="0" cellspacing="0"> 
                                            <tr>                                        
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtPlazoConfirmacion" Text="" CssClass="calendar" />
                                                </td>    
                                                <td>
                                                    <asp:ImageButton ID="ibtnFecPlazo" runat="server" CssClass="imagen" />
                                                    <asp:CalendarExtender ID="calFecCon" runat="server" PopupButtonID="ibtnFecPlazo" TargetControlID="txtPlazoConfirmacion" Format="dd/MM/yyyy" />
                                               </td>
                                            </tr>
                                        </table>
                                       </td>
                                        
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label runat="server" ID="lblPrioridadDeAtencion" Text="Prioridad de Atención:" CssClass="label" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPrioridaddeAtencion" runat="server" CssClass="dropdownlist" />
                                        </td>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label runat="server" ID="lblEstadoDocE" Text="Estado :"  CssClass="label" />                                        
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblEstado" Text="" CssClass="label" />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblAlertasConf" Text="Alerta de Confirmación:" CssClass="label" Visible="false" />
                                        </td>
                                        <td class="radioButton" align="left">
                                            <asp:RadioButtonList runat="server" ID="rbtnAlerta" CssClass="radioButton" RepeatDirection="Horizontal" Visible="false">
                                                <asp:ListItem Text="Si" Value="0" />
                                                <asp:ListItem Text="No" Value="1" />
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlContenidoDoc" runat="server" GroupingText="Contenido del Documento" CssClass="panel">
                                <table class="FontSistema" style="width:100%">
                                <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="Label3" runat="server" Text="Emisor:" CssClass="label" />
                                        </td>
                                        <td colspan="2">
                                            <uc1:ValidarUsuario_Grupo ID="ctlUserEmisor" runat="server" WithTexto="99" AprobacionUser="false" UserModeText=""  UserSesion="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="Label2" runat="server" Text="Remitente (De):" CssClass="label" />
                                        </td>
                                        <td colspan="2">
                                            <uc1:ValidarUsuario_Grupo ID="ctlUserRemitente" runat="server" WithTexto="99" AprobacionUser="false" UserModeText=""  TituloControl="SELECCIONE REMITENTE" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="Label1" runat="server" Text="Destinatario (Para):" CssClass="label" />
                                        </td>
                                        <td colspan="2">
                                            <uc1:ValidarUsuario_Grupo ID="ctlUserParticipante" runat="server" WithTexto="99" UserModeText="MultiLine" TituloControl="SELECCIONE DESTINATARIOS" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label runat="server" ID="lblAsunto" Text="Asunto:" CssClass="label" />
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox runat="server" ID="txtAsunto" Text="" CssClass="textboxMayus" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label runat="server" ID="lblAdjunto" Text="Documento Adjunto:" CssClass="label" />
                                        </td>
                                        <td colspan="2">
                                            <uc1:ValidarAdjuntarDocumento ID="ctlAdjuntarDocumento" runat="server" WithTexto="99" TituloControl="SELECCIONE ARCHIVO ADJUNTAR" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label runat="server" ID="lblTexto" Text="Texto:" CssClass="label" />
                                        </td>
                                        <td colspan="2">
                                            <%/*
                                            <asp:TextBox runat="server" ID="txtTexto" Text="" TextMode="MultiLine" CssClass="htmlEditor" />
                                            <asp:HtmlEditorExtender ID="HtmlEdit" runat="server" TargetControlID="txtTexto"/>
                                            */ %>
                                            <CKEditor:CKEditorControl runat="server" ID="ckeTextoDocumento">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </CKEditor:CKEditorControl>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" align="right">
                                            <asp:Button runat="server" ID="btnEnviar" Text="Enviar" CssClass="button" />
                                            
                                            <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="button"/>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        <div runat="server" id="divRpst" class="PopupOcultar">
                                <asp:Panel ID="Panel3" runat="server" GroupingText="Respuestas" CssClass="panel">
                                    <table class="FontSistema" style="width:100%" >
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblAprobados" runat="server" Text="Aprobado" CssClass="label" />
                                            </td>
                                            <td >
                                                <div runat="server" id="divMargen" class="textbox" style="height:18px;" >
                                                   <asp:Literal runat="server" id = "ltrLAprobado"/>
                                                </div>
                                           </td>                                            
                                        </tr>
                                        <tr>                                          
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="ldlDesaprobados" runat="server" CssClass="label" 
                                                    Text="Rechazado" />
                                            </td>
                                            <td>
                                                <div runat="server" id="divMargen2" class="textbox" style="height:18px;" >
                                                    <asp:Literal runat="server" ID = "ltrLRechazo" />                                                                                                    
                                                </div>
                                            </td>                                                                                        
                                        </tr>
                                  </table>
                                 </asp:Panel>
                             </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div runat="server" id="divPopup"  class="PopupOcultar">
                                <asp:Panel ID="Panel1" runat="server" GroupingText="Aprobaciones" CssClass="panel">
                                    <table class="FontSistema" style="width:100%" >
                                        <tr>
                                            <td class="FondoEtiqueta1" rowspan="2">
                                                <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones" CssClass="label" />
                                            </td>
                                            <td rowspan="2" style="width:680px">
                                                <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" CssClass="multiline"/>
                                            </td>
                                            <td class="Fondobutton">
                                                <asp:Button ID="btnAutorizAprobar" runat="server" Text="Aprobar" 
                                                    CssClass="button" onclick="btnAutorizAprobar_Click" OnClientClick="return confirm('Desea Aprobar el Documento Electronico?');"/>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Fondobutton">
                                                <asp:Button ID="btnAutorizRechazar" runat="server" Text="Rechazar" 
                                                    CssClass="button" onclick="btnAutorizRechazar_Click" OnClientClick="return confirm('Desea Rechazar el Documento Electronico?');"/>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </div>
                        </td>
                    </tr>                    
                    <tr>
                        <td>
                            <div runat="server" id="divComentatioReeviar"  class="PopupOcultar">
                                <asp:Panel ID="pnlComentario" runat="server" GroupingText="Reenviar" CssClass="panel">
                                    <table class="FontSistema" style="width:100%" >
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblComentario" runat="server" Text="Comentario" CssClass="label" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtComentario" runat="server" TextMode="MultiLine" CssClass="multiline"/>
                                            </td>
                                        </tr> 
                                        <tr>
                                            <td class="FondoEtiqueta1" rowspan="2">
                                                <asp:Label ID="Label6" runat="server" Text="Destinatario" CssClass="label" />
                                            </td>
                                            <td rowspan="2">                                                
                                                <uc1:ValidarUsuario_Grupo ID="ctlUserReenvio" EnabledControl="true" runat="server" WithTexto="99" UserModeText="MultiLine" TituloControl="SELECCIONE DESTINATARIOS" />
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
    
    <div runat="server" id="divFirmaDigital" class="PopupOcultar">
        <asp:ModalPopupExtender ID="mpeFirmaDigital" runat="server" TargetControlID="txtNroDoc" 
                            PopupControlID="pnlSearching" PopupDragHandleControlID="pnlSearching"
                            OkControlID="txtNroDoc" 
                            BackgroundCssClass="modalPopup" DropShadow="false"  />
                            
        <asp:Panel ID="pnlSearching" runat="server" CssClass="panel" Height="80px" Width="300px">
            <table runat="server" class="FontSistema" id="tbFirmaDigital" style="width:100%">
                <tr>
                    <td colspan="2">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="CabeceraPopup">
                                    <asp:Label runat="server" ID="lblTituloControl" Text="Ingrese Firma Electronica" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="FondoEtiqueta2">
                        <asp:Label ID="Label4" runat="server" Text="Firma Digital:" CssClass="label" />
                    </td>
                    <td style="width:190px">
                        <asp:TextBox runat="server" ID="txtFirmaActual" CssClass="textboxSegurity" TextMode="Password" MaxLength="15"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <table>
                            <tr>
                                <td>
                                    <asp:Button runat="server" ID="Button1" Text="Cancelar" CssClass="button" onclick="btnCancelar_Click" />
                                </td>
                                <td>
                                    <asp:Button runat="server" ID="btnAceptar" Text="Aceptar" CssClass="button" onclick="btnAceptar_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel> 
    </div>
    
    <div runat="server" id="divComentariosReenvio" class="PopupOcultar"> 
        <asp:ModalPopupExtender ID="mpeComentarioReenvio" runat="server" TargetControlID="txtNroDoc" 
                            PopupControlID="pnlComentarioReenvio" PopupDragHandleControlID="pnlComentarioReenvio"
                            OkControlID="txtNroDoc" 
                            BackgroundCssClass="modalPopup" DropShadow="false"  />
                            
        <asp:Panel ID="pnlComentarioReenvio" runat="server" CssClass="panelAviso" Height="80px" Width="500px">
            <table runat="server" class="FontSistema" id="Table1" style="width:100%; background-color:White;">
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="CabeceraPopup">
                                    <asp:Label runat="server" ID="Label5" Text="Comentarios" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div runat="server" id="divMemo" style="height:300px; width:400px;font-size:12px;overflow-y:auto;" 
                        class="FontSistema">                            
                        </div>                        
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table>
                            <tr>
                                <td>
                                    <asp:Button runat="server" ID="btnCerrarComentarios" Text="Cerrar" 
                                        CssClass="button" onclick="btnCerrarComentarios_Click" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel> 
    </div>
    
    <asp:Label runat="server" ID="lblCodElec"  CssClass="label"  Visible="false"/>
    <asp:Label runat="server" ID="lblNumElec"  CssClass="label" Visible="false"/>
    <asp:Label runat="server" ID="lblNumPart"  CssClass="label" Visible="false"/>
    <asp:Label runat="server" ID="lblEnvNotRem"  CssClass="label" style="display:none;"/>
    
</asp:Content>

