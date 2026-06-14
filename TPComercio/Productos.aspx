<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TPComercio.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="bg-white p-6 rounded-xl shadow">

    <h2 class="text-2xl font-bold mb-5">
        Gestión de Productos
    </h2>

    <div class="grid grid-cols-4 gap-4 mb-5">
        <asp:TextBox runat="server" ID="txtCodigo" CssClass="border p-2 rounded w-full" placeholder="Código"/>
        <asp:TextBox runat="server" ID="txtNombre" CssClass="border p-2 rounded w-full" placeholder="Nombre"/>
        <asp:TextBox runat="server" ID="txtStockActual" CssClass="border p-2 rounded w-full" placeholder="Stock Actual"/>
        <asp:TextBox runat="server" ID="txtStockMinimo" CssClass="border p-2 rounded w-full" placeholder="Stock Mínimo"/>
        <asp:TextBox runat="server" ID="txtPrecioCompra" CssClass="border p-2 rounded w-full" placeholder="Precio Compra"/>
        <asp:TextBox runat="server" ID="txtPorcentaje" CssClass="border p-2 rounded w-full" placeholder="% Ganancia"/>
        <asp:TextBox runat="server" ID="txtIdMarca" CssClass="border p-2 rounded w-full" placeholder="ID Marca"/>
        <asp:TextBox runat="server" ID="txtIdCategoria" CssClass="border p-2 rounded w-full" placeholder="ID Categoría"/>
    </div>

    <asp:Button Text="Nuevo Producto" ID="btnAgregarProducto" OnClick="btnAgregarProducto_Click" runat="server" CssClass="bg-blue-600 text-white px-4 py-2 rounded mb-5"/>
    
    <div class="mb-4">
        <asp:Label ID="lblError" runat="server" Text="" CssClass="text-red-600 font-bold"></asp:Label>
    </div>

    <asp:GridView ID="dgvProductos" runat="server" CssClass="table-auto w-full border" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" Visible="false" />
            <asp:BoundField DataField="Codigo" HeaderText="Código" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="StockActual" HeaderText="Stock Actual" />
        </Columns>
    </asp:GridView>

</div>

</asp:Content>