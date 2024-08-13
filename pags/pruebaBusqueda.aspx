<%@ Page Title="pruebaBusqueda" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pruebaBusqueda.aspx.cs" Inherits="pmLOGIN.pags.pruebaBusqueda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../css/Stylenuevo.css" rel="stylesheet" type="text/css" />
    <h2>Filtro de Búsqueda</h2>

    <div class="info">
        <table class="custom-table">
            <tr>
                <td class="alinJustify">Código:</td>
                <td>
                    <asp:TextBox ID="txtCodigo" runat="server" type="number"  CssClass="estilotxtBox"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="alinJustify">Sede:</td>
                <td>
                    <asp:TextBox ID="txtSede" runat="server" type="number"  CssClass="estilotxtBox"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="alinJustify">Carrera:</td>
                <td>
                    <asp:TextBox ID="txtCarrera" runat="server" type="number"  CssClass="estilotxtBox"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="alinJustify">Jornada:</td>
                <td>
                    <asp:TextBox ID="txtJornada" runat="server" type="number"  CssClass="estilotxtBox"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnBuscar" runat="server" Text="AplicarFiltros" OnClick="btnBuscar_Click" CssClass="btn-primary" />
                &nbsp;<br />
                    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Button ID="ButtonGuardar" runat="server" Text="Guardar" CssClass="btn-primary" OnClick="ButtonGuardar_Click" />
                </td>
            </tr>
        </table>


        <h2>Resultados</h2>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True">
        </asp:GridView>
        <asp:Label ID="lblNoResults" runat="server" Text="No se encontraron resultados." ForeColor="Red" Visible="false"></asp:Label>

    </div>
</asp:Content>
