<%@ Page Title="Acerca de" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="pmLOGIN.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="css/StyleSitios.css" rel="stylesheet" type="text/css" />
    <style>
        </style>

    <main aria-labelledby="title">
        <div class="row">
            <section class="col-md-4" aria-labelledby="hostingTitle">
                <h2 id="hostingTitle"><b>Hola, soy Majo</b>   </h2>
                <br>
                <p class="txt">
                    Soy una artista y programadora que ha estado explorando el mundo
                    de la tecnología con ASP.NET.
                    <br>
                    <br>
                    Actualmente estoy trabajando en un proyecto emocionante que aprovecha
                    los recursos de esta plataforma para crear múltiples soluciones. 
                    <br>
                    <br>
                    Mi objetivo es seguir
                    avanzando y compartiendo mi 
                    crecimiento con la comunidad.
                </p>

                <p class="txtB">
                    <%--<a class="btn btn-default " href="https://github.com/Be00wulf"> <strong> <i>  Mi GitHub &raquo;  </i> </strong></a>--%>
                </p>
            </section>
        </div>
    </main>
</asp:Content>
