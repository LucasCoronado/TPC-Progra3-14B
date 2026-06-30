<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HistorialCompras.aspx.cs" Inherits="TPComercio.HistorialCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="max-w-7xl mx-auto py-8">
        
        <div class="mb-8">
            <h1 class="text-3xl font-bold text-slate-800">Historial de Compras</h1>
            <p class="text-slate-500 mt-2">Auditoría y registro de todas las operaciones realizadas.</p>
        </div>

        
        <div class="bg-white p-6 rounded-2xl shadow-sm border border-slate-200 mb-8 flex gap-4 items-end flex-wrap">
            <div class="flex-1 min-w-[200px]">
                <label class="block text-sm font-semibold text-slate-700 mb-1">Buscar por Proveedor</label>
                <asp:TextBox ID="txtFiltroProveedor" runat="server" CssClass="w-full px-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-blue-500 outline-none" placeholder="Ej: Juan Perez"></asp:TextBox>
            </div>
            <div class="w-40">
                <label class="block text-sm font-semibold text-slate-700 mb-1">Desde</label>
                <asp:TextBox ID="txtFechaDesde" runat="server" TextMode="Date" CssClass="w-full px-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-blue-500 outline-none"></asp:TextBox>
            </div>
            <div class="w-40">
                <label class="block text-sm font-semibold text-slate-700 mb-1">Hasta</label>
                <asp:TextBox ID="txtFechaHasta" runat="server" TextMode="Date" CssClass="w-full px-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-blue-500 outline-none"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="bg-slate-800 hover:bg-slate-900 text-white font-bold py-2 px-6 rounded-lg transition-colors cursor-pointer" OnClick="btnFiltrar_Click" />
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="bg-slate-200 hover:bg-slate-300 text-slate-700 font-bold py-2 px-6 rounded-lg transition-colors cursor-pointer ml-2" OnClick="btnLimpiar_Click" />
            </div>
        </div>

        
        <div class="bg-white rounded-2xl shadow-sm border border-slate-200 overflow-hidden">
            <asp:GridView ID="dgvCompras" runat="server" CssClass="w-full text-left border-collapse" AutoGenerateColumns="false" GridLines="None" EmptyDataText="No hay Compras registradas.">
                <HeaderStyle CssClass="bg-slate-50 text-slate-500 text-xs uppercase font-semibold border-b border-slate-200 px-6 py-4 text-center" />
                <RowStyle CssClass="border-b border-slate-100 hover:bg-slate-50 transition-colors" />
                <EmptyDataRowStyle CssClass="p-6 text-center text-slate-500" />
                
                <Columns>
                    
                    <asp:BoundField DataField="Id" HeaderText="Nro">
                        <ItemStyle CssClass="px-6 py-4 font-medium text-slate-900 text-center" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}">
                        <ItemStyle CssClass="px-6 py-4 text-slate-600 text-center" />
                    </asp:BoundField>
                    
                    <asp:TemplateField HeaderText="Factura">
                        <ItemStyle CssClass="px-6 py-4 text-slate-600 text-center" />
                        <ItemTemplate>
                            <%# Eval("FacturaAsociada") != null ? Eval("FacturaAsociada.NumeroFactura") : "Sin factura" %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Proveedor">
                        <ItemStyle CssClass="px-6 py-4 font-semibold text-blue-600 text-center" />
                        <ItemTemplate>
                            <%# Eval("ProveedorAsociado.RazonSocial") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:C}">
                        <ItemStyle CssClass="px-6 py-4 font-bold text-green-600 text-center" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Acciones">
                        <ItemStyle CssClass="px-6 py-4 text-right text-center" />
                        <ItemTemplate>
                            
                            <a href='CompraDetalle.aspx?id=<%# Eval("Id") %>' class="bg-blue-50 text-blue-600 hover:bg-blue-100 font-semibold py-2 px-4 rounded-lg transition-colors text-sm">
                                Ver Detalles
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
