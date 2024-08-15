<%@ Page Title="pruebaBusqueda" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pruebaBusqueda.aspx.cs" Inherits="pmLOGIN.pags.pruebaBusqueda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../css/Stylenuevo.css" rel="stylesheet" type="text/css" />
    <h2>Filtro de Búsqueda</h2>

    <div class="info">
        <table class="custom-table">
            <tr>
                <td class="alinJustify">[Código]:</td>
                <td>
                    <asp:TextBox ID="txtCodigo" runat="server" type="number" placeholder="Ej: 12" CssClass="estilotxtBox"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="alinJustify">[Sede]:</td>
                <td>
                <asp:DropDownList ID="DropDownListAddSede" class="dropstilo" runat="server" AutoPostBack="true">
                </asp:DropDownList>
                        <br />
                    <asp:TextBox ID="txtSede" runat="server" type="number"  CssClass="estilotxtBox" Visible="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="alinJustify">[Carrera]:</td>
                <td>
                <asp:DropDownList ID="DropDownListAddCarrera" class="dropstilo" runat="server" AutoPostBack="true">
                </asp:DropDownList>
                        <br />
                    <asp:TextBox ID="txtCarrera" runat="server" type="number"  CssClass="estilotxtBox" Visible="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="alinJustify">[Jornada]:</td>
                <td>
                <asp:DropDownList ID="DropDownListAddPlan" class="dropstilo" runat="server" AutoPostBack="true">
                </asp:DropDownList>
                        <br />
                    <asp:TextBox ID="txtJornada" runat="server" type="number"  CssClass="estilotxtBox" Visible="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar [Código]" OnClick="btnBuscar_Click" CssClass="btn-primary" />
                &nbsp;
                    <asp:TextBox ID="txtBuscarCodigo" runat="server" type="number" placeholder="Ej: 12" CssClass="estilotxtBox"></asp:TextBox><br />
        <asp:Label ID="lblNoResults" runat="server" Text="No se encontraron resultados." ForeColor="Red" Visible="false"></asp:Label>

                    <br />
                    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label ID="Label1" runat="server" />
                    <br />
                    <asp:Button ID="ButtonGuardar" runat="server" Text="Guardar" CssClass="btn-primary" OnClick="ButtonGuardar_Click" />
                    &nbsp;<asp:Button ID="ButtonRefrescar" runat="server" Text="Refrescar" CssClass="btn-primary" OnClick="ButtonRefrescar_Click" />
                &nbsp;<asp:Button ID="ButtonEliminar" runat="server" Text="Eliminar" CssClass="btn-primary" OnClick="ButtonEliminar_Click"   />
                </td>
            </tr>
        </table>


        <h4>&nbsp;</h4>
        <h4>AGREGAR INFORMACION UNIVERSITARIA</h4>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True" Visible="False">
        </asp:GridView>

        <%--<h4>AGREGAR INFORMACION UNIVERSITARIA</h4>--%>
        <asp:GridView ID="GridViewDetalles" runat="server" AutoGenerateColumns="True">
        </asp:GridView>

    </div>
</asp:Content>
