<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPComercio.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2"
ContentPlaceHolderID="MainContent"
runat="server">

<div class="bg-white p-6 rounded-xl shadow">

<h2 class="text-2xl font-bold mb-5">
Clientes
</h2>

<div class="grid grid-cols-2 gap-4 mb-5">

    <input type="text"
           placeholder="Nombre"
           class="border p-2 rounded">

    <input type="text"
           placeholder="DNI"
           class="border p-2 rounded">

</div>

<button class="bg-green-600 text-white px-4 py-2 rounded mb-5">
Nuevo Cliente
</button>

<asp:GridView ID="dgvClientes"
runat="server"
CssClass="table-auto w-full border">
</asp:GridView>

</div>

</asp:Content>