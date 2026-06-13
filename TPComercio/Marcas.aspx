<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="TPComercio.Marcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <div class="bg-white p-6 rounded-xl shadow">

        <h2 class="text-2xl font-bold mb-5">Marcas
        </h2>

        <asp:TextBox runat="server" ID="txtNuevaMarca" CssClass="border p-2 rounded w-full mb-4" placeholder="Nombre de Marca"/>

        <asp:Button Text="Agregar" ID="btnAgregarMarca" OnClick="btnAgregarMarca_Click" runat="server" CssClass="bg-blue-600 text-white px-4 py-2 rounded"/>

        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

        <asp:GridView ID="dgvMarcas"
            runat="server"
            CssClass="table-auto w-full border mt-5">
        </asp:GridView>

    </div>

</asp:Content>
