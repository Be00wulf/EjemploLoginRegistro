<%@ Page Title="EditarCampos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarCampos.aspx.cs" Inherits="pmLOGIN.pags.EditarCampos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../css/Stylenuevo.css" rel="stylesheet" type="text/css" />

    <div class="info">
        <main>
            <section class="content-section" aria-labelledby="inventTitle">
                <h1 id="inventTitle">Edicion de datos de la universidad: Seleccione los campos que desee modificar:</h1>

                <table class="custom-table">
                    <tr class="alinCentro">
                        <td class="alinCentro">
                            <br />
                            <asp:Button ID="btnSede" CssClass="btn-primary" runat="server" Text="EDITAR SEDE" OnClick="btnSede_Click" />
                        </td>
                        <td class="alinCentro">
                            <br />
                            <asp:Button ID="btnCarrera" CssClass="btn-primary" runat="server" Text="EDITAR CARRERA" OnClick="btnCarrera_Click"  />
                        </td>
                        <td class="alinCentro">
                            <br />
                            <asp:Button ID="btnPlan" CssClass="btn-primary" runat="server" Text="EDITAR PLAN" OnClick="btnPlan_Click" />
                        </td>
                        <td class="alinCentro">
                            <br />
                            <asp:Button ID="ButtonBuscar" CssClass="btn-primary" runat="server" Text="FILTRO" OnClick="ButtonBuscar_Click"  />
                        </td>
                    </tr>
                </table>
                </section>
            </main>
        </div>

</asp:Content>
