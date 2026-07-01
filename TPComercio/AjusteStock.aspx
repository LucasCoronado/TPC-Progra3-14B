<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AjusteStock.aspx.cs" Inherits="TPComercio.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="max-w-2xl mx-auto mt-10 p-6 bg-white rounded-lg shadow-md border border-gray-200">
    <h2 class="text-2xl font-bold text-gray-800 mb-6 border-b pb-2">Ajuste Manual de Stock</h2>
    
    <div class="space-y-4">
        <div>
            <label class="block text-sm font-medium text-gray-700">Seleccionar Producto:</label>
            <asp:DropDownList ID="ddlProductos" runat="server" CssClass="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500" AutoPostBack="true" OnSelectedIndexChanged="ddlProductos_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        
        <div>
            <label class="block text-sm font-medium text-gray-700">Stock Actual:</label>
            <asp:Label ID="lblStockActual" runat="server" CssClass="mt-1 block w-full px-3 py-2 bg-gray-50 border border-gray-300 rounded-md font-bold text-gray-600"></asp:Label>
        </div>

        <div>
            <label class="block text-sm font-medium text-gray-700">Cantidad a Ajustar (+/-):</label>
            <asp:TextBox ID="txtCantidad" runat="server" CssClass="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" TextMode="Number" placeholder="Ej: -5 o 10"></asp:TextBox>
        </div>

        <div>
            <label class="block text-sm font-medium text-gray-700">Motivo:</label>
            <asp:DropDownList ID="ddlMotivos" runat="server" CssClass="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500">
                <asp:ListItem Text="Ajuste por Rotura" Value="Rotura" />
                <asp:ListItem Text="Ingreso Manual" Value="Ingreso" />
                <asp:ListItem Text="Error de Inventario" Value="Error" />
                <asp:ListItem Text="Otro" Value="Otro" />
            </asp:DropDownList>
        </div>

        <div class="pt-4">
            <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar Ajuste" CssClass="w-full bg-blue-600 text-white font-bold py-2 px-4 rounded hover:bg-blue-700 transition duration-200" OnClick="btnConfirmar_Click" />
        </div>

        <asp:Button ID="btnVerHistorial" runat="server" Text="Ver Historial de Movimientos"
            CssClass="w-full bg-gray-600 text-white font-bold py-2 px-4 rounded mt-4 hover:bg-gray-700 transition"
            PostBackUrl="~/HistorialMovimientos.aspx" />

        <asp:Label ID="lblMensaje" runat="server" CssClass="block text-sm font-semibold mt-2"></asp:Label>
    </div>
</div>
</asp:Content>
