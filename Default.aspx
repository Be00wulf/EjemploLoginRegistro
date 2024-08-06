<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="pmLOGIN._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="css/StyleSitios.css" rel="stylesheet" type="text/css" />
    <style>
    </style>

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <%--<h1 id="aspnetTitle">Inicio</h1>--%>
            <%--<p class="lead">  </p>--%>
            <%--<p><a href="https://github.com/Be00wulf" class="btn btn-primary btn-md">GitHub &raquo;</a></p>--%>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="hostingTitle">
                <h2 id="hostingTitle"><b>Descubriendo ASP.NET</b>   </h2>
                <br>
                <p class="txt">
                    ASP.NET es un marco de desarrollo web desarrollado por Microsoft que permite a los desarrolladores 
                    crear aplicaciones web dinámicas, sitios web y servicios web. Utiliza el lenguaje de programación .NET 
                    y es conocido por su capacidad de crear aplicaciones robustas y de alto rendimiento.
                    <br>
                    <br>
                    ASP.NET soporta 
                    varios lenguajes de programación, incluyendo C# y VB.NET, y proporciona una variedad de herramientas 
                    y bibliotecas que facilitan el desarrollo web.

                    <br>
                    <br>
                    ASP.NET fue lanzado por primera vez en enero de 2002 como parte del .NET Framework de Microsoft. 
                    Su predecesor, ASP (Active Server Pages), era una tecnología basada en scripts utilizada para generar 
                    contenido web dinámico, pero ASP.NET representó un avance significativo, proporcionando una arquitectura 
                    mucho más potente y flexible.
                </p>

                <p class="txtB">
                    <%--<a class="btn btn-default " href="https://github.com/Be00wulf"> <strong> <i>  Mi GitHub &raquo;  </i> </strong></a>--%>
                </p>
            </section>
        </div>
    </main>

</asp:Content>
