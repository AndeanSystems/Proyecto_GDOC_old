<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Inicio/mpFEPCMAC.Master"
    AutoEventWireup="true" CodeBehind="frmDocumentosFisicos.aspx.cs" Inherits="WebGdoc.WebPage.Digitalizacion.frmDocumentosFisicos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../Controles/ValidarUsuario_Grupo.ascx" TagName="ValidarUsuario_Grupo"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script language="javascript" type="text/javascript">
// <!CDATA[        
        function validarSeleccionArchivo() {
            if ($('#ctl00_ContentPlaceHolder1_uplServerFTP').val() == '') {
                alert('Seleccione archivo a cargar.');
                return false;
            }
            return true;
        }

// ]]>
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="BarraHerramientas" cellpadding="0" cellspacing="0">
        <tr>
            <td class="TituloPagina">
                &nbsp; &nbsp;
                <asp:Label runat="server" ID="lblTituloPagina" Text="Digitalización de Documentos " />
            </td>
            <td class="AccesoDirecto">
                <asp:ImageButton runat="server" ID="ibtnNuevo" AlternateText="Nuevo" CssClass='LinkURL'
                    OnClick="ibtnNuevo_Click" />
                <asp:ImageButton runat="server" ID="ibtnEditar" AlternateText="Editar" CssClass='LinkURL'
                    OnClick="ibtnEditar_Click" />
                <asp:ImageButton runat="server" ID="ibtnGuardar" AlternateText="Guardar" CssClass='LinkURL'
                    OnClick="ibtnGuardar_Click" />
                <asp:ImageButton runat="server" ID="ibtnEnviar" AlternateText="Enviar" CssClass='LinkURL'
                    OnClick="ibtnEnviar_Click" OnClientClick="return confirm('Desea Enviar el Documento Digital');" />
                <asp:ImageButton runat="server" ID="ibtnEliminar" AlternateText="Eliminar" CssClass='LinkURL'
                    OnClick="ibtnEliminar_Click" OnClientClick="return confirm('Desea Elimina el Documento Digital');" />
                <asp:ImageButton runat="server" ID="ibtnRegresar" AlternateText="Regresar" CssClass='LinkURL'
                    OnClick="ibtnRegresar_Click" />
                &nbsp; &nbsp;
            </td>
        </tr>
    </table>
    <table runat="server" id="tbPrincipal" class="Principal">
        <tr>
            <td align="left" valign="top">
                <table class="FontSistema" style="width: 100%">
                    <tr>
                        <td valign="top">
                            <asp:Panel ID="Panel3" runat="server" CssClass="panelBorder">
                                <table class="FontSistema" style="width: 100%">
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblNroDoc" runat="server" Text="N° de Documento:" CssClass="label" />
                                        </td>
                                        <td colspan="2">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 335px">
                                                        <asp:TextBox ID="txtNroDoc" runat="server" CssClass="textboxMayus" />
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
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblElegirArch" runat="server" Text="Elegir Archivo:" CssClass="label" />
                                        </td>
                                        <td colspan="2">
                                            <div>
                                                <asp:FileUpload runat="server" ID="uplServerFTP" class="examinar" style="text-align:left;"/>
                                                <asp:ImageButton runat="server" ID="ImageButton3" ToolTip="Cargar Documento" CssClass="imagen"
                                                OnClick="ImageButton3_Click" OnClientClick="return validarSeleccionArchivo();"/>   
                                                <asp:LinkButton ID="lnkVerArchivo" runat="server" Text='Visualizar archivo' 
                                                    ForeColor="Blue" Font-Size="Small" Visible="false" 
                                                    onclick="lnkVerArchivo_Click">
                                                </asp:LinkButton>                                               
                                            </div>                                                                                                                                     
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblNomOrigArch" runat="server" Text="Nombre Original:" CssClass="label" />
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtNomOrigArch" runat="server" CssClass="textboxMayus" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblClaseDoc" runat="server" Text="Clase de Documento:" CssClass="label" />
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlClaseDoc" runat="server" CssClass="dropdownlist" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblDerivacion" runat="server" Text="Derivacion:" CssClass="label" />
                                        </td>
                                        <td colspan="2" align="left" class="radioButton">
                                            <asp:RadioButtonList ID="rdnDeriva" runat="server" CssClass="radioButton" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Si" Value="S" />
                                                <asp:ListItem Text="No" Value="N" />
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblUsuRemi" runat="server" Text="Emisor:" CssClass="label" />
                                        </td>
                                        <td colspan="2">
                                            <uc1:ValidarUsuario_Grupo ID="ctlUser" runat="server" WithTexto="98" AprobacionUser="false"
                                                UserModeText="" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblUsuRec" runat="server" Text="Destinatario:" CssClass="label" />
                                        </td>
                                        <td colspan="2">
                                            <uc1:ValidarUsuario_Grupo ID="ct1UserRec" runat="server" WithTexto="98" AprobacionUser="false"
                                                TituloControl="SELECCIONE DESTINATARIOS" UserModeText="MultiLine" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblTitulo" runat="server" Text="Título:" CssClass="label" />
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtTitulo" runat="server" CssClass="textboxMayus" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblAsunto" runat="server" Text="Asunto:" CssClass="label" />
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtAsunto" runat="server" CssClass="textboxMayus" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblFecEmision" runat="server" Text="Fecha de Emisión:" CssClass="label" />
                                        </td>
                                        <td valign="bottom" colspan="2">
                                            <% //Ejemplo de centrado calendar %>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtFecEmision" runat="server" CssClass="calendar" />
                                                    </td>
                                                    <td style="width: 5px">
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="ibtnFecEmision" runat="server" CssClass="imagen" />
                                                        <asp:CalendarExtender ID="calFecCon" runat="server" PopupButtonID="ibtnFecEmision"
                                                            TargetControlID="txtFecEmision" Format="dd/MM/yyyy" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblFecReferencia" runat="server" Text="Fecha de Recepcion:" CssClass="label" />
                                        </td>
                                        <td align="left" colspan="2">
                                            <% //Ejemplo de centrado calendar %>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtFecReferencia" runat="server" CssClass="calendar" />
                                                    </td>
                                                    <td style="width: 5px">
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="ibtnFecReferencia" runat="server" CssClass="imagen" />
                                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="ibtnFecReferencia"
                                                            TargetControlID="txtFecReferencia" Format="dd/MM/yyyy" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblTipoAcceso" runat="server" Text="Tipo de Acceso:" CssClass="label" />
                                            <br />
                                        </td>
                                        <td align="left" class="radioButton" colspan="2">
                                            <asp:RadioButtonList ID="rbtnNivelAcceso" runat="server" CssClass="radioButton" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Público" Value="PU" />
                                                <asp:ListItem Text="Privado" Value="PR" />
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblComentario" runat="server" Text="Comentario:" CssClass="label" />
                                            <br />
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtComentario" runat="server" TextMode="MultiLine" CssClass="multiline"
                                                Rows="5" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 90px" colspan="3">
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>                        
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table class="FontSistema" style="width: 100%">
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblReferencia" runat="server" CssClass="label" Text="Nueva Referencia:" />
                                            </td>
                                            <td style="width: 800px">
                                                <asp:TextBox ID="txtReferencia" runat="server" CssClass="textbox" />
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ibtnReferencia" runat="server" CssClass="imagen" OnClick="ibtnReferencia_Click"
                                                    ToolTip="Adicionar Referencia" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table border="0" cellspacing="0" cellpadding="0" style="width: 100%" class="GVHeader">
                                                    <tr>
                                                        <td align="center" style="width: 920px;">
                                                            Referencia
                                                        </td>
                                                        <td align="center" style="width: 45px;">
                                                            Ver
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <div runat="server" id="divGrupo" class="divControl">
                                                    <asp:GridView ID="gvwReferencias" runat="server" AutoGenerateColumns="False" CssClass="GVPrincipal"
                                                        OnSelectedIndexChanged="gvwReferencias_SelectedIndexChanged" ShowHeader="false">
                                                        <Columns>
                                                            <asp:BoundField DataField="sReferencia" HeaderText="Referencia" HtmlEncode="false">
                                                                <ItemStyle Width="920px" />
                                                            </asp:BoundField>
                                                            <asp:CommandField ShowSelectButton="True" SelectText='<img runat="server" id="imgLink" src="../../Resources/Imagenes/img_EliminarItem_A.jpg" border="0" class="imagen"/>'>
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
                                        <tr>
                                            <td align="right" colspan="3">
                                                <asp:Button ID="btnAgregar" runat="server" CssClass="button" Text="Guardar" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:Label ID="lblCodDig" runat="server" CssClass="label" Visible="false" />
    <asp:Label ID="lblNumDig" runat="server" CssClass="label" Visible="false" />
    <asp:Label ID="lblArrCod" runat="server" CssClass="label" Visible="false" />
    <asp:Label ID="lblArrDes" runat="server" CssClass="label" Visible="false" />
</asp:Content>
