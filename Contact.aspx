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
    <link href="css/StyleSitios.css" rel="stylesheet" type="text/css" />

    <main aria-labelledby="title">
        <h3> Mis redes:</h3>
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
                <a class="btn btn-default txt" href="https://www.linkedin.com/in/mar%C3%ADa-jos%C3%A9-baquiax-rodr%C3%ADguez-su/"> <strong> <i>  <u> LinkedIn</u> &raquo;  </i> </strong></a>            
            </li>

            <li>
                <a class="btn btn-default txt" href="https://www.tiktok.com/@planito.banana?_t=8oV7VbQwrW2&_r=1"> <strong> <i> <u> TikTok</u> &raquo;    </i> </strong> </a>
            </li>

            <li>
                <a class="btn btn-default txt" href="https://www.instagram.com/planito.banana/"> <strong> <i> <u> Instagram</u> &raquo;    </i> </strong> </a>
            </li>

            <li>          
                <a class="btn btn-default txt" href="https://dly.to/NMDWRlvcGmW"> <strong> <i> <u> daily.dev</u> &raquo;    </i> </strong> </a>
            </li>
        </ul>

        <address>
            <%--<strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
            <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>--%>
        </address>
    </main>
</asp:Content>
