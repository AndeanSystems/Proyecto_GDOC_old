<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BarraHerramientas.ascx.cs"
    Inherits="WebGdoc.WebPage.Controles.BarraHerramientas" %>
    
<table style="width:100%" cellpadding="0" cellspacing="0">
    <tr>
        <td class="TituloPagina">
            &nbsp; &nbsp;
            <asp:Label runat="server" ID="lblTituloPagina" Text="" />
        </td>
        
        <td class="AccesoDirecto">
            <asp:Literal runat="server" ID="ltrLink" />
        </td>
    </tr>
</table>
