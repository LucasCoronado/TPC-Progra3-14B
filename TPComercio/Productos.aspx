<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TPComercio.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2"
ContentPlaceHolderID="MainContent"
runat="server">

<div class="bg-white p-6 rounded-xl shadow">

    <div class="flex justify-between mb-5">

        <h2 class="text-2xl font-bold">
            Gestión de Productos
        </h2>

        <button class="bg-blue-600 text-white px-4 py-2 rounded">
            Nuevo Producto
        </button>

    </div>

    <div class="grid grid-cols-4 gap-4 mb-5">

        <input type="text"
               placeholder="Buscar producto"
               class="border p-2 rounded">

        <select class="border p-2 rounded">
            <option>Categoria</option>
        </select>

        <select class="border p-2 rounded">
            <option>Marca</option>
        </select>

        <button class="bg-slate-800 text-white rounded">
            Buscar
        </button>

    </div>

    <asp:GridView ID="dgvProductos"
        runat="server"
        CssClass="table-auto w-full border">
    </asp:GridView>

</div>

</asp:Content>