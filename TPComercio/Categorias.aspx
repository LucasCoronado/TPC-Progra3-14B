<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="TPComercio.Categorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <div class="bg-white p-6 rounded-xl shadow">

        <h2 class="text-2xl font-bold mb-5">Categorías
        </h2>

        <asp:TextBox runat="server" ID="txtNuevaCategoria" CssClass="border p-2 rounded w-full mb-4" placeholder="Nombre de Categoria" />

        <asp:Button Text="Agregar" ID="btnAgregarCategoria" OnClick="btnAgregarCategoria_Click" runat="server" CssClass="bg-blue-600 text-white px-4 py-2 rounded" />

        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

        <asp:GridView ID="dgvCategorias"
            runat="server"
            CssClass="table-auto w-full border mt-5">
        </asp:GridView>

    </div>

</asp:Content>
