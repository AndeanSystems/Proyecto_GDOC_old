<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Inicio/mpFEPCMAC.Master"
    AutoEventWireup="true" CodeBehind="frmArchivoDatos.aspx.cs" Inherits="WebGdoc.WebPage.Digitalizacion.frmArchivoDatos" %>

<%@ Register Src="../Controles/ValidarUsuario_Grupo.ascx" TagName="ValidarUsuario_Grupo"
    TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
                <asp:Label runat="server" ID="lblTituloPagina" Text="Archivo de Datos " />
            </td>
            <td class="AccesoDirecto">
                <asp:ImageButton runat="server" ID="ibtnNuevo" AlternateText="Nuevo" CssClass='LinkURL'
                    OnClick="ibtnNuevo_Click" />
                <asp:ImageButton runat="server" ID="ibtnEditar" AlternateText="Editar" CssClass='LinkURL'
                    OnClick="ibtnEditar_Click" />
                <asp:ImageButton runat="server" ID="ibtnGuardar" AlternateText="Guardar" CssClass='LinkURL'
                    OnClick="ibtnGuardar_Click" />
                <asp:ImageButton runat="server" ID="ibtnEliminar" AlternateText="Eliminar" CssClass='LinkURL'
                    OnClick="ibtnEliminar_Click" OnClientClick="return confirm('Desea Eliminar el Archivo de Datos');" />
                <asp:ImageButton runat="server" ID="ibtnRegresar" AlternateText="Regresar" CssClass='LinkURL'
                    OnClick="ibtnRegresar_Click" />
                &nbsp; &nbsp;
            </td>
        </tr>
    </table>
    <div>
        <table runat="server" id="tbPrincipal" class="Principal">
            <tr>
                <td align="left" valign="top">
                    <table class="FontSistema" style="width: 100%">
                        <tr>
                            <td valign="top">
                                <asp:Panel ID="Panel3" runat="server" CssClass="panelBorder">
                                    <table class="FontSistema" style="width: 100%;">
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblNroDoc" runat="server" Text="N° de Documento:" CssClass="label" />
                                            </td>
                                            <td colspan="2">
                                                <table>
                                                    <tr>
                                                        <td style="width: 335px">
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
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblElegirArch" runat="server" Text="Elegir Archivo:" CssClass="label" />
                                            </td>
                                            <td colspan="2" style="width: 300px">
                                                <asp:FileUpload runat="server" ID="uplServerFTP" class="examinar" />
                                                <asp:ImageButton runat="server" ID="ImageButton3" ToolTip="Cargar Documento" CssClass="imagen"
                                                    OnClick="ImageButton3_Click" OnClientClick="return validarSeleccionArchivo();" />
                                                <asp:LinkButton ID="lnkVerArchivo" runat="server" Text='Visualizar archivo' ForeColor="Blue"
                                                    Font-Size="Small" Visible="false" OnClick="lnkVerArchivo_Click">
                                                </asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblNomOrigArch" runat="server" Text="Nombre Original:" CssClass="label" />
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtNomOrigArch" runat="server" CssClass="textbox" />
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
                                                <asp:Label ID="lblTitulo" runat="server" Text="Título:" CssClass="label" />
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtTitulo" runat="server" CssClass="textbox" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:" CssClass="label" />
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtAsunto" runat="server" CssClass="textbox" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblFecEmision" runat="server" Text="Fecha de Emisión:" CssClass="label" />
                                            </td>
                                            <td colspan="2" valign="bottom">
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
                                                <asp:Label ID="lblTipoAcceso" runat="server" Text="Tipo de Acceso:" CssClass="label" />
                                            </td>
                                            <td colspan="2" class="radioButton" align="left">
                                                <asp:RadioButtonList runat="server" ID="rbtnNivelAcceso" CssClass="radioButton" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Público" Value="PU" />
                                                    <asp:ListItem Text="Privado" Value="PR" />
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblUsuRemi" runat="server" Text="Propietario:" CssClass="label" />
                                            </td>
                                            <td>
                                                <uc1:ValidarUsuario_Grupo ID="ctlUser" runat="server" WithTexto="98" UserSesion="true"
                                                    AprobacionUser="false" UserModeText="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 100px">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <table class="FontSistema" style="width: 100%">
                                    <tr>
                                        <td class="FondoEtiqueta1">
                                            <asp:Label ID="lblReferencia" runat="server" Text="Adición de Referencia:" CssClass="label" />
                                        </td>
                                        <td style="width: 800px">
                                            <asp:TextBox ID="txtReferencia" runat="server" CssClass="textbox" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ibtnReferencia" runat="server" CssClass="imagen" OnClick="ibtnReferencia_Click" />
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
                                                <asp:GridView ID="gvwReferencias" runat="server" CssClass="GVPrincipal" AutoGenerateColumns="False"
                                                    OnSelectedIndexChanged="gvwReferencias_SelectedIndexChanged" ShowHeader="false">
                                                    <Columns>
                                                        <asp:BoundField DataField="sReferencia" HeaderText="Referencia">
                                                            <ItemStyle Width="920px" />
                                                        </asp:BoundField>
                                                        <asp:CommandField ShowSelectButton="True" SelectText='<img runat="server" id="imgLink" src="../../Resources/Imagenes/img_EliminarItem_A.jpg" border="0" class="imagen"/>'>
                                                            <ItemStyle Width="25px" HorizontalAlign="Center" />
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
    </div>
</asp:Content>
