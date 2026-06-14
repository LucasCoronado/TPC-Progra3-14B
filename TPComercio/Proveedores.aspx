<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="TPComercio.Proveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="bg-white p-6 rounded-xl shadow">

    <h2 class="text-2xl font-bold mb-5">
        Proveedores
    </h2>

    <div class="grid grid-cols-4 gap-4 mb-5">
        <asp:TextBox runat="server" ID="txtRazonSocial" CssClass="border p-2 rounded w-full mb-4" placeholder="Razón Social"/>
        <asp:TextBox runat="server" ID="txtCuit" CssClass="border p-2 rounded w-full mb-4" placeholder="CUIT"/>
        <asp:TextBox runat="server" ID="txtTelefonoProveedor" CssClass="border p-2 rounded w-full mb-4" placeholder="Teléfono"/>
        <asp:TextBox runat="server" ID="txtEmailProveedor" CssClass="border p-2 rounded w-full mb-4" placeholder="Email"/>
    </div>

    <asp:Button Text="Nuevo Proveedor" ID="btnAgregarProveedor" OnClick="btnAgregarProveedor_Click" runat="server" CssClass="bg-green-600 text-white px-4 py-2 rounded mb-5"/>

    <div class="mb-4">
        <asp:Label ID="lblError" runat="server" Text="" CssClass="text-red-600 font-bold"></asp:Label>
    </div>
    <asp:GridView ID="dgvProveedores" runat="server" CssClass="table-auto w-full border" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="ID" Visible="false" />
        <asp:BoundField DataField="RazonSocial" HeaderText="Razón Social" />
        <asp:BoundField DataField="Cuit" HeaderText="CUIT" />
        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
        <asp:BoundField DataField="Email" HeaderText="Email" />
    </Columns>
</asp:GridView>

</div>

</asp:Content>