<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="pmLOGIN.pags.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../css/Stylenuevo.css" rel="stylesheet" type="text/css" />
         <%-- tabla encabezado --%>
     <table class="custom-table">
         <tr>
             <td class="alinCentro">
                 <h1 class="textoSimple">Hola  
                    <strong class="textoResaltado"> de nuevo :3 </strong>
                     <asp:Label ID="LabelWC" runat="server" ></asp:Label>
                </h1>
             </td>
         </tr>

         <tr>
             <td>
                 <asp:Button ID="ButtonCerrarSesion" class="boton" runat="server" Text="Cerrar sesión" OnClick="ButtonCerrarSesion_Click" />
             </td>
         </tr>
     </table>
</asp:Content>
