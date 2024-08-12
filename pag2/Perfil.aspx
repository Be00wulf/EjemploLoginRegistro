<%@ Page Title="" Language="C#" MasterPageFile="~/pag2/Admins.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="pmLOGIN.pag2.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- RECREANDO --%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <link href="../css/StyleLOGIN.css" rel="stylesheet" type="text/css" />
      <%-- tabla encabezado --%>
  <table class="custom-table">
      <tr>
          <td class="alinCentro">
              <h1 class="textoSimple">Hola  
                 <strong class="textoResaltado"> de nuevo :3</strong>
                  <asp:Label ID="LabelWC" runat="server" ></asp:Label>
             </h1>
          </td>
      </tr>

      <tr>
          <td>
              <asp:Button ID="ButtonCerrarSesion" class="boton" runat="server" Text="Cerrar sesión"  />
          </td>
      </tr>
  </table>
</asp:Content>
