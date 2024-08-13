<%@ Page Title="LogIn" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="pmLOGIN.pags.LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../css/Stylenuevo.css" rel="stylesheet" type="text/css" />

    <%-- tabla titulo subtitulo texto --%>
    <table class="custom-table">
        <tr>
            <td>
                <h1 class="textoSimple">INICIAR 
                                    <strong class="textoResaltado">SESION</strong>
                </h1>
            </td>
        </tr>

        <tr>
            <td>
                <h6 class="textoResaltado">Sitio de administradores
                                    <strong class="textoSimple"> Ingresar datos</strong>
                </h6>
            </td>
        </tr>

        <tr>
            <td>
                <asp:TextBox ID="TextBoxUsuario" CssClass="estilotxtBox" placeholder="Usuario" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:TextBox ID="TextBoxContrasenia" CssClass="estilotxtBox" TextMode="Password" placeholder="Clave" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Button ID="ButtonIngresar" class="boton" runat="server" Text="Ingresar" OnClick="ButtonIngresar_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
