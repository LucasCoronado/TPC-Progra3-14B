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
        <p class="text-4xl font-bold mt-3">125</p>
    </div>

    <div class="bg-white p-6 rounded-xl shadow">
        <h3 class="text-gray-500">Clientes</h3>
        <p class="text-4xl font-bold mt-3">56</p>
    </div>

    <div class="bg-white p-6 rounded-xl shadow">
        <h3 class="text-gray-500">Ventas</h3>
        <p class="text-4xl font-bold mt-3">84</p>
    </div>

    <div class="bg-white p-6 rounded-xl shadow">
        <h3 class="text-gray-500">Proveedores</h3>
        <p class="text-4xl font-bold mt-3">18</p>
    </div>

</div>

</asp:Content>
