<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPComercio.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2"
ContentPlaceHolderID="MainContent"
runat="server">

<h2 class="text-3xl font-bold mb-6">
Dashboard
</h2>

<div class="grid grid-cols-4 gap-6">

    <div class="bg-white p-6 rounded-xl shadow">
        <h3 class="text-gray-500">Productos</h3>
        <asp:Label ID="lblTotalProductos" runat="server" CssClass="text-3xl font-bold">0</asp:Label>
    </div>

    <div class="bg-white p-6 rounded-xl shadow">
        <h3 class="text-gray-500">Clientes</h3>
        <asp:Label ID="lblTotalClientes" runat="server" CssClass="text-3xl font-bold">0</asp:Label>
    </div>

    <div class="bg-white p-6 rounded-xl shadow">
        <h3 class="text-gray-500">Ventas</h3>
        <asp:Label ID="lblTotalVentas" runat="server" CssClass="text-3xl font-bold">0</asp:Label>
    </div>

    <div class="bg-white p-6 rounded-xl shadow">
        <h3 class="text-gray-500">Proveedores</h3>
        <asp:Label ID="lblTotalProveedores" runat="server" CssClass="text-3xl font-bold">0</asp:Label>
    </div>

</div>

</asp:Content>
