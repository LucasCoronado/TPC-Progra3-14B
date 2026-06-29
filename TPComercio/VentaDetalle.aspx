<%@ Page Title="Detalle de Venta" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VentaDetalle.aspx.cs" Inherits="TPComercio.VentaDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="max-w-5xl mx-auto py-8">
        
        <div class="flex items-center justify-between mb-8">
            <div>
                <h1 class="text-3xl font-bold text-slate-800">
                    Detalle de Venta <asp:Label ID="lblNroVenta" runat="server" CssClass="text-blue-600"></asp:Label>
                </h1>
                <p class="text-slate-500 mt-2">Desglose de productos de la operación seleccionada.</p>
            </div>
            <a href="HistorialVentas.aspx" class="bg-slate-200 hover:bg-slate-300 text-slate-700 font-bold py-2 px-6 rounded-lg transition-colors inline-block">
                Volver al Historial
            </a>
        </div>

        <div class="bg-white rounded-2xl shadow-sm border border-slate-200 p-6 mb-8 flex flex-wrap gap-8">
            <div>
                <span class="block text-sm font-semibold text-slate-500 uppercase">Fecha</span>
                <asp:Label ID="lblFecha" runat="server" CssClass="text-lg font-medium text-slate-900"></asp:Label>
            </div>
            <div>
                <span class="block text-sm font-semibold text-slate-500 uppercase">Factura</span>
                <asp:Label ID="lblFactura" runat="server" CssClass="text-lg font-medium text-slate-900"></asp:Label>
            </div>
            <div>
                <span class="block text-sm font-semibold text-slate-500 uppercase">Cliente</span>
                <asp:Label ID="lblCliente" runat="server" CssClass="text-lg font-medium text-slate-900"></asp:Label>
            </div>
            <div>
                <span class="block text-sm font-semibold text-slate-500 uppercase">Vendedor</span>
                <asp:Label ID="lblVendedor" runat="server" CssClass="text-lg font-medium text-slate-900"></asp:Label>
            </div>
            <div class="ml-auto text-right">
                <span class="block text-sm font-semibold text-slate-500 uppercase">Total Operación</span>
                <asp:Label ID="lblTotal" runat="server" CssClass="text-2xl font-bold text-green-600"></asp:Label>
            </div>
        </div>

        <div class="bg-white rounded-2xl shadow-sm border border-slate-200 overflow-hidden">
            <asp:GridView ID="dgvDetalles" runat="server" CssClass="w-full text-left border-collapse" AutoGenerateColumns="false" GridLines="None" EmptyDataText="No se encontraron detalles para esta venta.">
                <HeaderStyle CssClass="bg-slate-50 text-slate-500 text-xs uppercase font-semibold border-b border-slate-200 px-6 py-4 text-center" />
                <RowStyle CssClass="border-b border-slate-100 hover:bg-slate-50 transition-colors" />
                <EmptyDataRowStyle CssClass="p-6 text-center text-slate-500" />
                
                <Columns>
                    <asp:BoundField DataField="NombreProducto" HeaderText="Producto">
                        <ItemStyle CssClass="px-6 py-4 font-semibold text-slate-900 text-center" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                        <ItemStyle CssClass="px-6 py-4 text-slate-600 text-center" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" DataFormatString="{0:C}">
                        <ItemStyle CssClass="px-6 py-4 text-slate-600 text-center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}">
                        <ItemStyle CssClass="px-6 py-4 font-bold text-green-600 text-center" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
