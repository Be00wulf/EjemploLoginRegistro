<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="pmLOGIN.Login_aa.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <link href="../css/StyleLOGIN.css" rel="stylesheet" type="text/css" />
            <%-- RECREANDO --%>
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
                                    <strong class="textoSimple">Ingresar datos</strong>
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
        </div>
    </form>
</body>
</html>

<%-- PIE DE PAG --%>
<div class="container-fluid body-content alinCentro">
    <footer>
        <p>
            <u>&copy; <%: DateTime.Now.DayOfWeek %> - María José Baquiax Rodríguez</u>
            <a class="nav-link" runat="server" href="~/">MJBR</a>
        </p>
    </footer>
</div>
