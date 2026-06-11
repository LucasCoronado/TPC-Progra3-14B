<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TPComercio.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2"
ContentPlaceHolderID="MainContent"
runat="server">

<div class="max-w-2xl mx-auto bg-white p-6 rounded-xl shadow">

<h2 class="text-2xl font-bold mb-5">
Mi Perfil
</h2>

<div class="space-y-4">

<input type="text"
value="Administrador"
class="border p-2 rounded w-full">

<input type="email"
value="admin@comercio.com"
class="border p-2 rounded w-full">

<input type="password"
value="123456"
class="border p-2 rounded w-full">

<button class="bg-blue-600 text-white px-5 py-2 rounded">
Guardar Cambios
</button>

</div>

</div>

</asp:Content>