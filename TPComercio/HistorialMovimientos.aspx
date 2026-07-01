<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HistorialMovimientos.aspx.cs" Inherits="TPComercio.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="max-w-6xl mx-auto mt-10 p-6 bg-white rounded-lg shadow-md border border-gray-200">
        <h2 class="text-2xl font-bold text-gray-800 mb-6">Historial Completo de Movimientos</h2>
        <div class="overflow-hidden shadow ring-1 ring-black ring-opacity-5 rounded-lg">
            <asp:GridView ID="dgvHistorial" runat="server"
                AutoGenerateColumns="false"
                CssClass="min-w-full divide-y divide-gray-300"
                HeaderStyle-CssClass="bg-gray-50"
                RowStyle-CssClass="hover:bg-gray-50">
                <Columns>
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy HH:mm}" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm text-gray-500" HeaderStyle-CssClass="px-6 py-3 text-left text-xs font-semibold text-gray-900 uppercase" />
                    <asp:BoundField DataField="Producto" HeaderText="Producto" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900" HeaderStyle-CssClass="px-6 py-3 text-left text-xs font-semibold text-gray-900 uppercase" />
                    <asp:BoundField DataField="CantidadCambio" HeaderText="Ajuste" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm text-gray-500" HeaderStyle-CssClass="px-6 py-3 text-left text-xs font-semibold text-gray-900 uppercase" />
                    <asp:BoundField DataField="Motivo" HeaderText="Motivo" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm text-gray-500" HeaderStyle-CssClass="px-6 py-3 text-left text-xs font-semibold text-gray-900 uppercase" />
                    <asp:BoundField DataField="Usuario" HeaderText="Realizado por" ItemStyle-CssClass="px-6 py-4 whitespace-nowrap text-sm text-gray-500" HeaderStyle-CssClass="px-6 py-3 text-left text-xs font-semibold text-gray-900 uppercase" />
                </Columns>
            </asp:GridView>
        </div>

        <div class="mt-6">
            <a href="AjusteStock.aspx" class="text-blue-600 hover:underline">← Volver a Ajuste de Stock</a>
        </div>
    </div>
</asp:Content>
