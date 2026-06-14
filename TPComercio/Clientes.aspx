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

    <div class="grid grid-cols-5 gap-4 mb-5">

         <asp:TextBox runat="server" ID="txtNombreCliente" CssClass="border p-2 rounded w-full mb-4" placeholder="Nombre"/>
         <asp:TextBox runat="server" ID="txtApellidoCliente" CssClass="border p-2 rounded w-full mb-4" placeholder="Apellido"/>
         <asp:TextBox runat="server" ID="txtDniCliente" CssClass="border p-2 rounded w-full mb-4" placeholder="Dni"/>
         <asp:TextBox runat="server" ID="txtTelefonoCliente" CssClass="border p-2 rounded w-full mb-4" placeholder="Telefono"/>
         <asp:TextBox runat="server" ID="txtEmailCliente" CssClass="border p-2 rounded w-full mb-4" placeholder="Email"/>

    </div>

     <asp:Button Text="Nuevo Cliente" ID="btnAgregarCliente" OnClick="btnAgregarCliente_Click" runat="server" CssClass="bg-green-600 text-white px-4 py-2 rounded mb-5"/>

     <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

<asp:GridView ID="dgvClientes"
runat="server"
CssClass="table-auto w-full border">
</asp:GridView>

</div>

</asp:Content>