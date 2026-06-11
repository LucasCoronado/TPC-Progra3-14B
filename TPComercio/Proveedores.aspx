<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="TPComercio.Proveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2"
ContentPlaceHolderID="MainContent"
runat="server">

<div class="bg-white p-6 rounded-xl shadow">

<h2 class="text-2xl font-bold mb-5">
Proveedores
</h2>

<div class="grid grid-cols-3 gap-4 mb-5">

<input type="text"
placeholder="Proveedor"
class="border p-2 rounded">

<input type="text"
placeholder="CUIT"
class="border p-2 rounded">

<button class="bg-slate-800 text-white rounded">
Buscar
</button>

</div>

<asp:GridView ID="dgvProveedores"
runat="server"
CssClass="table-auto w-full border">
</asp:GridView>

</div>

</asp:Content>