<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoUsuario.aspx.cs" Inherits="pmLOGIN.pags.NuevoUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../css/StyleLOGIN.css" rel="stylesheet" type="text/css" />

    <%-- tabla titulo subtitulo texto --%>
    <table class="custom-table">
        <tr>
            <td>
                <h1 class="textoSimple">¿No tienes una 
                                 <strong class="textoResaltado"> cuenta?</strong>
                </h1>
            </td>
        </tr>

        <tr>
            <td>
                <h6 class="textoResaltado">Sitio de registro 
                                 <strong class="textoSimple"> Crea una cuenta</strong>
                </h6>
            </td>
        </tr>

        <tr>
            <td>
                <asp:TextBox ID="TextBoxNuevoUsuario" CssClass="estilotxtBox" placeholder="Nombre de usuario" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:TextBox ID="TextBoxNuevaContrasenia" CssClass="estilotxtBox"  placeholder="Nueva clave" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Button ID="ButtonNuevoIngreso" class="boton" runat="server" Text="Nuevo registro" OnClick="ButtonNuevoIngreso_Click" />
                <br />
                <asp:Label ID="lblMessage" class="textoSimple" runat="server" Text="Registro"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
