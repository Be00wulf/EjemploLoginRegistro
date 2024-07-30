<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="pmLOGIN.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <style>
        body {
            background-image: url('../img/MAJO LINEAS.png');
            background-size: cover;
            background-position: center;
        }

        .txt{
            color: white;
        }

        .txtB{
            text-align: right;
        }

    </style>

    <main aria-labelledby="title">
        <h2 id="title">Contacto</h2>
        <h3> <br> Mis redes:</h3>
        <address>
            <%--One Microsoft Way<br />
            Redmond, WA 98052-6399<br />
            <abbr title="Phone">P:</abbr>
            425.555.0100--%>
        </address>

        <ul class="txt">
            <li>
                <a class="btn btn-default txt" href="https://github.com/Be00wulf"> <strong> <i> <u> GitHub</u> &raquo;    </i> </strong> </a>
            </li>

            <li>
                <a class="btn btn-default txt" href="https://www.linkedin.com/in/mar%C3%ADa-jos%C3%A9-baquiax-rodr%C3%ADguez-su/"> <strong> <i>  <u> LinkedIn</u> &raquo;  </i> </strong></a>            </li>

            <li>

            </li>

            <li>

            </li>

            <li>

            </li>
        </ul>

        <address>
            <%--<strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
            <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>--%>
        </address>
    </main>
</asp:Content>
