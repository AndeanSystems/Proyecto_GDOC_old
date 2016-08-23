<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Inicio/mpFEPCMAC.Master"
    AutoEventWireup="true" CodeBehind="frmUsuarios.aspx.cs" Inherits="WebGdoc.WebPage.Configuracion.frmUsuarios"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script language="javascript" type="text/javascript">

function AcceptNum(e)

{ 

var nav4 = window.Event ? true : false;

var key = nav4 ? evt.which : e.keyCode; 

return (key <= 13 || (key >= 48 && key <= 57) || key == 44);

}
 function disable() 
{ 
        document.getElementById("txt").disabled = true; 
} 


</script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%" cellpadding="0" cellspacing="0">
        <tr>
            <td class="TituloPagina">
                &nbsp; &nbsp;
                <asp:Label runat="server" ID="lblTituloPagina" Text="Usuarios" />
            </td>
            
            <td class="AccesoDirecto">      
                <asp:ImageButton runat="server" ID="ibtnNuevo" AlternateText="Nuevo" CssClass='LinkURL' onclick="ibtnNuevo_Click" />
                <asp:ImageButton runat="server" ID="ibtnEditar" AlternateText="Editar" CssClass='LinkURL' onclick="ibtnEditar_Click"/>
                <asp:ImageButton runat="server" ID="ibtnGuardar"  AlternateText="Guardar" CssClass='LinkURL' onclick="ibtnGuardar_Click" OnClientClick="return confirm('Desea Guardar el usuario ingresado');"/>
                <asp:ImageButton runat="server" ID="ibtnEliminar" AlternateText="Eliminar" CssClass='LinkURL' onclick="ibtnEliminar_Click" OnClientClick="return confirm('Desea Eliminar el usuario seleccionado');"/>
                <asp:ImageButton runat="server" ID="ibtnRegresar" AlternateText="Regresar" CssClass='LinkURL' onclick="ibtnRegresar_Click"/>
                &nbsp; &nbsp;                                               
            </td>
        </tr>
    </table>

    <div>
        <table runat="server" id="tbPrincipal" class="Principal"  style="width: 100%">
            <tr>
                
                            <td valign="top" style="width:50%">
                                <asp:Panel ID="Panel3" runat="server" CssClass="panel" GroupingText="Datos Personales" >
                                    <table class="FontSistema" style="width: 100%">
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblIdUser" runat="server" Text="Id Usuario:" CssClass="label"/>    
                                            </td>
                                            <td style="width:300px">
                                                <table cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>                                                            
                                                            <asp:TextBox ID="txtIdUser" runat="server" CssClass="textboxMayus" Width="200px"/>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton runat="server" ID="ibtnBuscar" AlternateText = "Buscar" CssClass='imagen' onclick="ibtnBuscar_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                           
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblNom" runat="server" Text="Nombre:" CssClass="label"/>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNom" runat="server" CssClass="textbox" />
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblApelli" runat="server" Text="Apellidos:" CssClass="label"/>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtApell" runat="server" CssClass="textbox" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblSexo" runat="server" Text="Sexo:" CssClass="label"/>
                                            </td>
                                            <td align="left"  >
                                                <asp:RadioButtonList ID="rdnSexo" runat="server" CssClass="radioButton" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="M" Value="M" />
                                                    <asp:ListItem Text="F" Value="F" />
                                                </asp:RadioButtonList>
                                            </td>                                             
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblRuc" runat="server" Text="Empresa:" CssClass="label"/>
                                            </td>
                                            <td >
                                                <asp:DropDownList ID="ddlRuc" runat="server" CssClass="dropdownlist"/>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">                                                
                                                <asp:Label ID="lblNroDoc" runat="server" Text="N° de DNI:" CssClass="label"/>
                                            </td>
                                            <td>                                                
                                                <asp:TextBox ID="txtNroDoc" runat="server" CssClass="textbox" MaxLength="8" Width="200px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblFecNac" runat="server" Text="Fecha de Nacimiento:" CssClass="label"/>
                                            </td>
                                            <td >
                                                <asp:TextBox ID="txtFecNac" runat="server" CssClass="calendar" Width="150px" />
                                                <asp:ImageButton ID="ibtnFecNac" runat="server" CssClass="imagen" />
                                                <asp:CalendarExtender ID="calFecCon" runat="server" PopupButtonID="ibtnFecNac" TargetControlID="txtFecNac" Format="dd/MM/yyyy" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblTipUser" runat="server" Text="Tipo de Usuario:" CssClass="label"/>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlTipUser" runat="server" CssClass="dropdownlist">
                                                </asp:DropDownList>
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblEmailPer" runat="server" Text="Email Personal:" 
                                                    CssClass="label"/>
                                            </td>
                                            <td >
                                                <asp:TextBox ID="txtEmailPer" runat="server" CssClass="textbox" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        
                            <td valign="top" style="width:50%">
                                 <asp:Panel ID="Panel1" runat="server" CssClass="panel" GroupingText="Datos Laborales" >
                                    <table class="FontSistema" style="width: 100%">
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblCargo" runat="server" CssClass="label" Text="Cargo:" />
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlCargo" runat="server" CssClass="dropdownlist">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblArea" runat="server" CssClass="label" Text="Area:" />     
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlArea" runat="server" CssClass="dropdownlist">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblEmailLab" runat="server" Text="Email Laboral" 
                                                    CssClass="label"/>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEmailLab" runat="server" CssClass="textbox"/>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblDirec" runat="server" Text="Direccion:" CssClass="label"/>
                                            </td>
                                            <td >
                                                <asp:TextBox ID="txtDirecc" runat="server" CssClass="textbox" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblTerminal" runat="server" Text="Terminal:" CssClass="label"/>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTerminal" runat="server" CssClass="textbox"/>
                                            </td>
                                        </tr>
                                        <tr>
                                           <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblTelef" runat="server" Text="Telefono:" CssClass="label"/>
                                            </td>
                                            <td >
                                                <asp:TextBox ID="txtTelef" runat="server" CssClass="textbox" MaxLength="7" />
                                            </td>
                                        </tr>
                                        <tr>
                                          <td class="FondoEtiqueta1">
                                             <asp:Label ID="lblAnx" runat="server" Text="Anexo:" CssClass="label"/>
                                          </td>
                                          <td >
                                             <asp:TextBox ID="txtAnx" runat="server" CssClass="textbox" MaxLength="5" />
                                         </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                 <asp:Label ID="lblCelular" runat="server" Text="Celular:" CssClass="label"/>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCelular" runat="server" CssClass="textbox" MaxLength="9" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="FondoEtiqueta1">
                                                <asp:Label ID="lblClassUser" runat="server" CssClass="label" Text="Clase de Usuario:" />
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlClaseUser" runat="server" CssClass="dropdownlist">
                                                    <asp:ListItem Value="I">INTERNO</asp:ListItem>
                                                    <asp:ListItem Value="E">EXTERNO</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                </table>
                             </asp:Panel>
                        </td>
                
            </tr>
        </table>
        
        <asp:Label ID="lblCodPer" runat="server"  CssClass="label" Visible="false"/>
        <asp:Label ID="lblCodUser" runat="server"  CssClass="label" Visible="False"/>
        <asp:Label ID="lblArrCod" runat="server"  CssClass="label" Visible="false"/>
        <asp:Label ID="lblArrDes" runat="server"  CssClass="label" Visible="false"/>
        
        
    </div>
</asp:Content>
