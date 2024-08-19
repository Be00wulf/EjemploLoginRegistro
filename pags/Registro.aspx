<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="pmLOGIN.pags.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%--<main aria-labelledby="title">--%>
    <link href="../css/Stylenuevo.css" rel="stylesheet" type="text/css" />

    <%-- tabla encabezado --%>
    <table class="custom-table">
        <tr>
            <td class="alinCentro">
                <img class="imgEncabezado" src="../img/icoForm.png" alt="Logo PB" />
            </td>
        </tr>
    </table>

    <%-- tabla titulo subtitulo texto --%>
    <table class="custom-table">
        <tr>
            <td>
                <h1 class="textoSimple">Formulario 
                                    <strong class="textoResaltado">de registro</strong>
                </h1>
            </td>
        </tr>

        <tr>
            <td>
                <h6 class="textoResaltado">Canpos obligatorios.
                                    <strong class="textoSimple">Debe rellenar todos los campos para validar correctamente su formulario.</strong>
                </h6>
            </td>
        </tr>

    </table>

    <%-- tabla campos --%>
    <table class="custom-table">
        <tr>
            <td>
                <h6 class="textoSimple">DATOS PERSONALES</h6>
            </td>
            <td></td>
            <td></td>
        </tr>

        <%-- Nombres --%>
        <tr>
            <td>
                <asp:TextBox ID="TextBoxName1" runat="server" CssClass="estilotxtBox" placeholder="Primer nombre"> </asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBoxName2" runat="server" CssClass="estilotxtBox" placeholder="Segundo nombre"> </asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBoxNameN" runat="server" CssClass="estilotxtBox" placeholder="Otros nombres"> </asp:TextBox>
            </td>
        </tr>

        <%-- Apellidos --%>
        <tr>
            <td>
                <asp:TextBox ID="TextBoxLn1" runat="server" CssClass="estilotxtBox" placeholder="Primer apellido"> </asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBoxLn2s" runat="server" CssClass="estilotxtBox" placeholder="Segundo apellido"> </asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBoxLnN" runat="server" CssClass="estilotxtBox" placeholder="Apellido de casada"> </asp:TextBox>
            </td>
        </tr>

        <%-- Datos --%>
        <tr>
            <td>
                <br />
                <asp:TextBox ID="TextBoxCUI" runat="server" type="number" CssClass="estilotxtBox" placeholder="Documento de Identificación (CUI)"></asp:TextBox>
            </td>
            <td>
                <h6 class="textoResaltado"> <strong class="textoSimple">Fecha de nacimiento</strong></h6>
                <asp:TextBox ID="TextBoxNacimiento" runat="server" CssClass="estilotxtBox" type="date" placeholder="Fecha de Nacimiento"></asp:TextBox>
            </td>
            <td>
                <br />
                <asp:DropDownList ID="DropDownListPais" class="dropstilo" runat="server" OnFocus="loadDropDownListData();" AutoPostBack="true"></asp:DropDownList>
                <br />
            </td>
        </tr>

        <tr>
            <td>
                <asp:DropDownList ID="DropDownListGenero" runat="server" class="dropstilo" AutoPostBack="true" >
                </asp:DropDownList>
                <br />
            </td>
            <td>
                <asp:DropDownList ID="DropDownListEstadoCivil" class="dropstilo" runat="server" AutoPostBack="true">
                </asp:DropDownList>
                <br />
            </td>
            <td>
                <asp:TextBox ID="TextBoxDireccion" runat="server" CssClass="estilotxtBox" placeholder="Dirección de residencaia"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:DropDownList ID="DropDownListDepto" runat="server" class="dropstilo" AutoPostBack="True" OnSelectedIndexChanged="DropDownListDepto_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
            </td>
            <td>
                <asp:DropDownList ID="DropDownListMunicipio" runat="server" class="dropstilo" AutoPostBack="True" >
                </asp:DropDownList>
                <br />
            </td>
            <td>
                <asp:TextBox ID="TextBoxTel" type="number" runat="server" CssClass="estilotxtBox" placeholder="Teléfono Celular"></asp:TextBox>
            </td>
        </tr>
    </table>

    <%-- datos de emergencia --%>
    <table class="custom-table">
        <tr>
            <td></td>
            <td>
                <h6 class="textoSimple">CONTACTO DE EMERGENCIA:</h6>
            </td>
            <td></td>
        </tr>

        <tr>
            <td>
                <%-- ojo type o TextMode --%>
                <asp:TextBox ID="TextBoxEmail" runat="server" type="email" CssClass="estilotxtBox" placeholder="Correo electrónico"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBoxEmergName" runat="server" CssClass="estilotxtBox" placeholder="Nombres y apellidos"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBoxEmergTel" runat="server" type="number" CssClass="estilotxtBox" placeholder="Teléfono de emergencia"></asp:TextBox>
            </td>
        </tr>
    </table>

    <%-- datos academicos --%>
    <table class="custom-table">
        <tr>
            <td>
                <h6 class="textoSimple">DATOS ACADÉMICOS</h6>
            </td>
            <td></td>
            <td></td>
        </tr>

        <tr>
            <td>
                <asp:DropDownList ID="DropDownListSede" class="dropstilo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListSede_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
            </td>
            <td>
                <asp:DropDownList ID="DropDownListCarrera" runat="server" class="dropstilo" AutoPostBack="True" >
                </asp:DropDownList>
                <br />
            </td>
            <td>
                <asp:DropDownList ID="DropDownListPlan" class="dropstilo" runat="server" AutoPostBack="True" >
                </asp:DropDownList>
                <br />
            </td>
        </tr>

        <tr>
            <td>
                <br />
                <asp:TextBox ID="TextBoxTitulo" runat="server" CssClass="estilotxtBox" placeholder="Título"></asp:TextBox>
            </td>
            <td>
                <h6 class="textoResaltado"> <strong class="textoSimple">Fecha del título</strong></h6>
                <asp:TextBox ID="TextBoxTituloFecha" runat="server" type="date" CssClass="estilotxtBox" placeholder="Fecha del Título"></asp:TextBox>
            </td>
            <td>
                <br />
                <asp:TextBox ID="TextBoxInstitucion" runat="server" CssClass="estilotxtBox" placeholder="Nombre de la Institución"></asp:TextBox>
            </td>
        </tr>
    </table>

    <table class="custom-table">
        <tr class="centered-cell">
            <td>
                <asp:Button ID="ButtonGenerarForm" class="btn-primary" runat="server" Text="Generar formulario" OnClick="ButtonGenerarForm_Click"  />
            </td>
        </tr>

    </table> 
</asp:Content>
