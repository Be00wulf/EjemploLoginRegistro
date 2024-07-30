<%@ Page Title="Acerca de" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="pmLOGIN.About" %>

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
        <h2 id="title">Acerca de mí</h2>
        <h3><br> ¡Hola! Soy Majo</h3>
        <p class="txt"> 
            Soy una programadora que ha estado explorando el mundo<br> de la tecnología con ASP.NET. 
            Actualmente estoy trabajando <br> en un proyecto emocionante que aprovecha los recursos de esta <br> plataforma 
            para crear múltiples soluciones. Mi objetivo es seguir<br> avanzando y compartiendo mi 
            crecimiento con la comunidad. <br>
            ¡Gracias por visitar mi página! <br>
           
        </p>
    </main>
</asp:Content>
