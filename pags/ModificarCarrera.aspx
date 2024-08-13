<%@ Page Title="EditarCarrera" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarCarrera.aspx.cs" Inherits="pmLOGIN.pags.ModificarCarrera" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../css/Stylenuevo.css" rel="stylesheet" type="text/css" />

    <div class="info">
        <main>
            <section class="content-section" aria-labelledby="inventTitle">
                <h1 id="inventTitle">Edición de carreras</h1>

                <table class="custom-table">
                    <tr>
                        <td class="alinJustify">CODIGO: </td>
                        <td class="auto-style4">
                            <asp:TextBox ID="TextBoxCodigo" runat="server" class="estilotxtBox" type="number" placeholder="Ej: 12"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td class="auto-style2">CARRERA: </td>
                        <td class="auto-style4">
                            <asp:TextBox ID="TextBoxProducto" runat="server" CssClass="estilotxtBox" placeholder="Ej: Psicología"></asp:TextBox>
                        </td>
                    </tr>
                </table>



                <table class="custom-table">
                    <tr class="alinCentro">
                        <td class="alinCentro">
                            <br />
                            <asp:Button ID="btnGUARDAR" CssClass="btn-primary" runat="server" Text="GUARDAR" OnClick="btnGUARDAR_Click" />
                        </td>
                        <td class="alinCentro">
                            <br />
                            <asp:Button ID="btnEDITAR" CssClass="btn-primary" runat="server" Text="EDITAR" Enabled="False" OnClick="btnEDITAR_Click" />
                        </td>
                        <td class="alinCentro">
                            <br />
                            <asp:Button ID="btnELIMINAR" CssClass="btn-primary" runat="server" Text="ELIMINAR" Enabled="False" OnClick="btnELIMINAR_Click" />
                        </td>
                    </tr>
                </table>

                <table class="custom-table">
                    <tr>
                        <td class="alineaCentro">
                            <asp:Button ID="ButtonBuscar" runat="server" CssClass="btn-primary" Text="BUSCAR CODIGO" OnClick="ButtonBuscar_Click" />
                            &nbsp;<asp:TextBox ID="TextBoxBuscar" type="number" runat="server" CssClass="estilotxtBox" placeholder="Ingresar CODIGO"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td class="alinD">
                            <asp:Button ID="ButtonLimpiar" runat="server" CssClass="btn-primary " Text="ACTUALIZAR" OnClick="ButtonLimpiar_Click" />
                            &nbsp;<asp:Button ID="ButtonINGnuevo0" runat="server" CssClass="btn-primary " Text="CERRAR SESION" OnClick="ButtonINGnuevo0_Click" />
                        </td>
                    </tr>
                </table>

                <table class="custom-table alineaCentro">
                    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                </table>

            </section>
        </main>
    </div>



</asp:Content>
