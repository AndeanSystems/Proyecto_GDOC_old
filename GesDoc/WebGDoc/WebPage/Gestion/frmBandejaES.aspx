<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Inicio/mpFEPCMAC.Master"
    AutoEventWireup="true" CodeBehind="frmBandejaES.aspx.cs" Inherits="WebGdoc.WebPage.Gestion.frmBandejaES" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(document).ready(function() {
      
    });

    function changeTab(iptTab) {
        if (iptTab == "iptTab1") {
            $('input[name$="iptTab1"]').removeClass("TabHeader").addClass("TabHeaderSelect");
            $('input[name$="iptTab2"]').removeClass("TabHeaderSelect").addClass("TabHeader");
        }
        if (iptTab == "iptTab2") {
            $('input[name$="iptTab1"]').removeClass("TabHeaderSelect").addClass("TabHeader");
            $('input[name$="iptTab2"]').removeClass("TabHeader").addClass("TabHeaderSelect");
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="BarraHerramientas" cellpadding="0" cellspacing="0">
        <tr>
            <td class="TituloPagina">
                &nbsp; &nbsp;
                <asp:Label runat="server" ID="lblTituloPagina" Text="Bandeja de Entrada y Salida" />
            </td>
            <td>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <center>
                            <img src="../../Resources/Imagenes/img_Progress_A.gif" class="imagen" />
                        </center>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td class="AccesoDirecto">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton runat="server" ImageUrl="~/Resources/Imagenes/img_Buscar_A.jpg" ID="ibtnBuscar" AlternateText="Buscar" CssClass='LinkURL' onclick="ibtnBuscar_Click" />
                     </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    
    <div>
        <table runat="server" id="tbPrincipal" class="Principal" style="width:100%">
            <tr>
                <td align="left" valign="top">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <asp:TabContainer ID="TabContainer2" runat="server" CssClass="Tab" 
                                ActiveTabIndex="0" >
                                <asp:TabPanel runat="server" ID="TabPanel1">
                                    <HeaderTemplate>
                                        <asp:Button runat="server" ID="iptTab1" Text="Documentos - E" OnClientClick="changeTab('iptTab1');" CssClass="TabHeaderSelect"/>
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <asp:Panel runat="server" ID="pnlTab1" CssClass="panelBorder">
                                            <table class="FontSistema" style="width:100%">
                                                <tr>
                                                    <td class="FondoEtiqueta">
                                                        <asp:Label ID="lblTipoDoc" runat="server" Text="Tipo Doc-E" CssClass="label"/>
                                                    </td>
                                                    <td class="FondoCombobox">
                                                        <asp:DropDownList ID="ddlTipoDoc" runat="server" CssClass="dropdownlist" />
                                                    </td>
                                                    <td class="FondoEtiqueta">
                                                        <asp:Label ID="lblOpcionES" runat="server" Text="Opción E/S " CssClass="label"/>
                                                    </td>
                                                    <td class="FondoCombobox">
                                                        <asp:DropDownList ID="ddlOpcionES" runat="server" CssClass="dropdownlist" >
                                                            <asp:ListItem Value="0">TODOS</asp:ListItem>
                                                            <asp:ListItem Value="2">ENTRADA</asp:ListItem>
                                                            <asp:ListItem Value="3">SALIDA</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="FondoEtiqueta">
                                                        <asp:Label ID="lblClase" runat="server" Text="Comunicacion" CssClass="label"/>
                                                    </td>
                                                    <td class="FondoCombobox">
                                                        <asp:DropDownList ID="ddlClase" runat="server" CssClass="dropdownlist" >
                                                            <asp:ListItem Value="0">TODOS</asp:ListItem>
                                                            <asp:ListItem Value="1">INTERNA</asp:ListItem>
                                                            <asp:ListItem Value="2">EXTERNA</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="FondoEtiqueta">
                                                        <asp:Label ID="lblPrioridad" runat="server" Text="Prioridad" CssClass="label"/>
                                                    </td>
                                                    <td class="FondoCombobox">
                                                        <asp:DropDownList ID="ddlPrioridad" runat="server" CssClass="dropdownlist" />
                                                    </td>
                                                    <td class="FondoEtiqueta">
                                                        <asp:Label runat="server" ID="lblPeriodo" Text="Periodo" CssClass="label" />
                                                    </td>
                                                    <td class="FondoCombobox">
                                                        <asp:DropDownList ID="ddlPeriodo" runat="server" CssClass="dropdownlist" >
                                                            <asp:ListItem Value="M">MES</asp:ListItem>
                                                            <asp:ListItem Value="D">DIA</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="FondoEtiqueta">
                                                        <asp:Label ID="lblAsunto" runat="server" Text="Asunto" CssClass="label" />
                                                    </td>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="txtAsunto" runat="server" CssClass="textbox" />
                                                    </td>
                                                    <td class="FondoEtiqueta">
                                                        <asp:Label runat="server" ID="lblNDocE" Text="N° Doc-E" CssClass="label" />
                                                    </td>
                                                    <td colspan = "2">
                                                        <asp:TextBox ID="txtNDocE" runat="server" CssClass="textbox" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="10">
                                                        <table border="0" cellspacing="0" cellpadding="0" style="width: 100%" class="GVHeader">
                                                            <tr>
                                                                <td align="center" style="width:30px;">E </td>
                                                                <td align="center" style="Width:30px;">A</td>
                                                                <td align="center" style="Width:30px;">P</td>
                                                                <td align="center" style="width:120px;">Nro Documento</td>
                                                                <td align="center" style="width:140px;">Fecha y Hora</td>
                                                                <td align="center" style="width:60px;">De</td>
                                                                <td align="center" style="width:210px;">Para</td>
                                                                <td align="center" style="width:25px;">Tipo</td>
                                                                <td align="center" style="width:330px;">Asunto</td>
                                                                <td align="left" style="width:35px;">Ver</td>
                                                            </tr>
                                                        </table>
                                                        <div id="scroll" class="divBandeja" >
                                                            <asp:GridView ID="gvwDocE" runat="server" AutoGenerateColumns="False" ShowHeader="False" CssClass="GVPrincipal" 
                                                                          onselectedindexchanged="gvwDocE_SelectedIndexChanged" DataKeyNames="sNumOper" EnableViewState="false">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>E</HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <img runat="server" id="imgLink1" src="../../Resources/Imagenes/img_EMail_A.jpg" border="0" class="imgBE"/>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="25px" HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>A</HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <img runat="server" id="imgLink2" src="../../Resources/Imagenes/img_Adjunto_A.jpg" border="0" class="imgBE"/>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="25px" HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>P</HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <img runat="server" id="imgLink3" src="~/Resources/Imagenes/img_Punto_Amarillo_A.jpg" border="0" class="imgBE"/>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="25px" HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="sNumOper" HeaderText="Documento" >
                                                                        <ItemStyle  Width="120px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="sPrioridad" HeaderText="Prioridad" >
                                                                        <ItemStyle  Width="0px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="sLeido" HeaderText="Leido" >
                                                                        <ItemStyle  Width="0px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="sFechayHora" HeaderText="Fecha y Hora">
                                                                        <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="sDe" HeaderText="De">
                                                                        <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="sPara" HeaderText="Para">
                                                                        <ItemStyle Width="210px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="sTipo" HeaderText="Tipo">
                                                                        <ItemStyle HorizontalAlign="Center" Width="25px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="sAsunto" HeaderText="Asunto">
                                                                        <ItemStyle Width="330px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="sFecAtencion" HeaderText="Fecha Atención">
                                                                        <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                                    </asp:BoundField>
                                                                    <asp:CommandField HeaderText="Ver" SelectText="<img runat='server' id='imgLink' src='../../Resources/Imagenes/img_Banderin_Azul_A.jpg' border='0' class='imgBE'/>" ShowSelectButton="True">
                                                                        <ItemStyle Width="25px" HorizontalAlign="Center" />
                                                                    </asp:CommandField>
                                                                    <asp:BoundField DataField="sCodigo" HeaderText="Codigo">
                                                                        <ItemStyle HorizontalAlign="Center" Width="0px" />
                                                                    </asp:BoundField>
                                                                </Columns>
                                                                <AlternatingRowStyle CssClass="GVItemsAlt" />
                                                                <HeaderStyle CssClass="GVHeader"/>
                                                                <RowStyle CssClass="GVItems"/>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="10">
                                                        <asp:Label runat="server" ID="lblInfBandejaES" Text="" class="label" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:TabPanel>

                                <asp:TabPanel runat="server" ID="TabPanel2">
                                    <HeaderTemplate>
                                        <asp:Button runat="server" ID="iptTab2" Text="Mesa Virtual" CssClass="TabHeader" OnClientClick="changeTab('iptTab2');"/>
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <asp:Panel runat="server" ID="pnlTab2" CssClass="panelBorder">
                                            <table class="FontSistema" style="width:100%">
                                                <tr>
                                                    <td class="FondoEtiqueta">
                                                        <asp:Label ID="lblTipoMesaV" runat="server" CssClass="label" Text="Tipo Mesa-V" />
                                                    </td>
                                                    <td class="FondoCombobox">
                                                        <asp:DropDownList ID="ddlTipoMesaV" runat="server" CssClass="dropdownlist">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="FondoEtiqueta">
                                                        <asp:Label ID="lblParticipacion" runat="server" CssClass="label" Text="Participación" />
                                                    </td>
                                                    <td class="FondoCombobox" style="width: 500px;">
                                                        <asp:DropDownList ID="ddlParticipacion" runat="server" CssClass="dropdownlist">
                                                            <asp:ListItem Value="0">TODOS</asp:ListItem>
                                                            <asp:ListItem Value="C">CREADO</asp:ListItem>
                                                            <asp:ListItem Value="V">VIGENTE</asp:ListItem>
                                                            <asp:ListItem Value="R">CERRADO</asp:ListItem>
                                                            <asp:ListItem Value="F">FINALIZADO</asp:ListItem>
                                                            <asp:ListItem Value="N">ANULADO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="FondoEtiqueta">
                                                        <asp:Label ID="lblMesaVEstado" runat="server" CssClass="label" Text="Estado" />
                                                    </td>
                                                    <td class="FondoCombobox">
                                                        <asp:DropDownList ID="ddlMesaVEstado" runat="server" CssClass="dropdownlist">
                                                            <asp:ListItem Value="0">TODOS</asp:ListItem>
                                                            <asp:ListItem Value="C">CREADO</asp:ListItem>
                                                            <asp:ListItem Value="V">VIGENTE</asp:ListItem>
                                                            <asp:ListItem Value="R">CERRADO</asp:ListItem>
                                                            <asp:ListItem Value="F">FINALIZADO</asp:ListItem>
                                                            <asp:ListItem Value="N">ANULADO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="FondoEtiqueta">
                                                        <asp:Label runat="server" ID="lblPrior" Text="Prioridad" CssClass="label"/>
                                                    </td>
                                                    <td class="FondoCombobox">
                                                        <asp:DropDownList ID="ddlPrio" runat="server" CssClass="dropdownlist"/>
                                                    </td>
                                                    <td class="FondoEtiqueta">
                                                        <asp:Label runat="server" ID="lblTema" Text="Tema" CssClass="label"/>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox runat="server" ID="txtTema" CssClass="textbox" />
                                                    </td>
                                                    <td class="FondoEtiqueta">
                                                        <asp:Label runat="server" ID="lblMesaVPeriodo" Text="Periodo" CssClass="label"/>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddlPeriod" runat="server" CssClass="dropdownlist" >
                                                            <asp:ListItem Value="M">MES</asp:ListItem>
                                                            <asp:ListItem Value="D">DIA</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="9">
                                                        <table border="0" cellpadding="0" cellspacing="0" class="GVHeader" style="width: 100%">
                                                            <tr>
                                                                <td align="center" style="width: 30px;">E </td>
                                                                <td align="center" style="Width: 30px;">A</td>
                                                                <td align="center" style="Width: 30px;">P</td>
                                                                <td align="center" style="width: 130px;">Fecha y Hora</td>
                                                                <td align="center" style="width: 75px;">Organiza</td>
                                                                <td align="center" style="width: 180px;">Participante(s)</td>
                                                                <td align="center" style="width: 35px;">Tipo</td>
                                                                <td align="center" style="width: 240px;">Tema</td>
                                                                <td align="center" style="width: 130px;">Fecha Cierre</td>
                                                                <td align="left" style="width: 35px;">Ver</td>
                                                            </tr>
                                                        </table>
                                                        <div id="scroll" class="divBandeja">
                                                            <asp:GridView ID="gvwMesaV" runat="server" AutoGenerateColumns="False" CssClass="GVPrincipal" DataKeyNames="sNumOper" 
                                                                          onselectedindexchanged="gvwMesaV_SelectedIndexChanged" ShowHeader="False">
                                                                <AlternatingRowStyle CssClass="GVItemsAlt" />
                                                                    <Columns>
                                                                        <asp:TemplateField>
                                                                            <HeaderTemplate>E</HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <img id="imgLink1" runat="server" border="0" class="imgBE" src="../../Resources/Imagenes/img_EMail_A.jpg" />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="25px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <HeaderTemplate>A</HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <img id="imgLink2" runat="server" border="0" class="imgBE" src="../../Resources/Imagenes/img_Adjunto_A.jpg" />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="25px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <HeaderTemplate>P</HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <img id="imgLink3" runat="server" border="0" class="imgBE" src="../../Resources/Imagenes/img_Punto_Amarillo.jpg" />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="25px" />
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="sNumOper" HeaderText="Mesa Virtual">
                                                                            <ItemStyle Width="0px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="sPrioridad" HeaderText="Mesa Virtual">
                                                                            <ItemStyle Width="0px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="sLeido" HeaderText="Leido" >
                                                                        <ItemStyle  Width="0px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="sFechayHora" HeaderText="Fecha y Hora">
                                                                            <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="sOrganiza" HeaderText="Organiza">
                                                                            <ItemStyle HorizontalAlign="Center" Width="75px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="sParticipantes" HeaderText="Participante(s)">
                                                                            <ItemStyle Width="200px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="sTipo" HeaderText="Tipo">
                                                                            <ItemStyle HorizontalAlign="Center" Width="35px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="sTema" HeaderText="Tema">
                                                                            <ItemStyle Width="240px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="sFecCierre" HeaderText="Fecha Cierre">
                                                                            <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                                        </asp:BoundField>
                                                                        <asp:CommandField HeaderText="Ver" SelectText="&lt;img runat='server' id='imgLink' src='../../Resources/Imagenes/img_Banderin_Azul_A.jpg' border='0' class='imgBE'/&gt;" ShowSelectButton="True">
                                                                            <ItemStyle HorizontalAlign="Center" Width="25px" />
                                                                        </asp:CommandField>
                                                                        <asp:BoundField DataField="sCodigo" HeaderText="Codigo">
                                                                            <ItemStyle HorizontalAlign="Center" Width="0px" />
                                                                        </asp:BoundField>
                                                                        <asp:ImageField>
                                                                        </asp:ImageField>
                                                                    </Columns>
                                                                <HeaderStyle CssClass="GVHeader" />
                                                                <RowStyle CssClass="GVItems" />
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:Label ID="lblNumOper" runat="server" CssClass="label" Visible="False"/>
                                            <asp:Label ID="lblNumMV" runat="server" CssClass="label" Visible="False"/>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:TabPanel>
                            </asp:TabContainer>
                        </ContentTemplate>
                        <Triggers>
                          <%--  <asp:AsyncPostBackTrigger ControlID ="iptTab1" EventName="iptTab1_Click"/>
                            <asp:AsyncPostBackTrigger ControlID ="iptTab2" EventName="iptTab2_Click"/>--%>
                        </Triggers>
                    </asp:UpdatePanel>                    
                </td>
            </tr>
            
        </table>
    </div>
</asp:Content>
