<%@ Page Title="Datos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DatosRegistrados.aspx.cs" Inherits="pmLOGIN.pags.DatosRegistrados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../css/StyleLOGIN.css" rel="stylesheet" type="text/css" />

     <%-- grid view --%>
 <table class="custom-table">
     <tr>
         <td>
            <h1 class="textoSimple">Datos 
                                <strong class="textoResaltado">registrados</strong>
            </h1>
         </td>
     </tr>

     <tr>
        <td>
            <%-- filtros --%>

                <asp:DropDownList ID="DropDownListPais" class="dropstilo" runat="server" OnFocus="loadDropDownListData();" AutoPostBack="true" Visible="False" ></asp:DropDownList>
                &nbsp;<asp:DropDownList ID="DropDownListGenero" runat="server" class="dropstilo" AutoPostBack="true" Visible="False" >
                </asp:DropDownList>

        &nbsp;<asp:DropDownList ID="DropDownListEstadoCivil" class="dropstilo" runat="server" AutoPostBack="true" Visible="False">
                </asp:DropDownList>
                &nbsp;<asp:DropDownList ID="DropDownListDepto" runat="server" class="dropstilo" AutoPostBack="True" Visible="False" >
                </asp:DropDownList>
                &nbsp;<asp:DropDownList ID="DropDownListMunicipio" runat="server" class="dropstilo" AutoPostBack="True" Visible="False" >
                </asp:DropDownList>
                &nbsp;
                <asp:DropDownList ID="DropDownListSede" class="dropstilo" runat="server" AutoPostBack="True" Visible="False" >
                </asp:DropDownList>
                &nbsp;<asp:DropDownList ID="DropDownListCarrera" runat="server" class="dropstilo" AutoPostBack="True" Visible="False" >
                </asp:DropDownList>
                &nbsp;<asp:DropDownList ID="DropDownListPlan" class="dropstilo" runat="server" AutoPostBack="True" Visible="False" >
                </asp:DropDownList>

        &nbsp;
            <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btnFiltrar" class="btn-primary" runat="server" Text="Buscar" OnClick="btnFiltrar_Click"  />

        </td>
    </tr>

     <tr>
         <td>
             <asp:GridView ID="GridViewDatos" runat="server" BackColor="red" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                 <FooterStyle BackColor="red" />
                 <HeaderStyle BackColor="red" Font-Bold="True" ForeColor="black" />
                 <PagerStyle BackColor="#CCCCCC" ForeColor="red" HorizontalAlign="Left" />
                 <RowStyle BackColor="White" />
                 <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="red" />
                 <SortedAscendingCellStyle BackColor="red" />
                 <SortedAscendingHeaderStyle BackColor="red" />
                 <SortedDescendingCellStyle BackColor="red" />
                 <SortedDescendingHeaderStyle BackColor="red" />
             </asp:GridView>
         </td>
     </tr>
 </table>

</asp:Content>
