<%@ Page Title="Historial de Operaciones" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Historial.aspx.cs" Inherits="TPComercio.Historial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="max-w-5xl mx-auto py-12 px-6">
        <div class="mb-10 text-center">
            <h1 class="text-4xl font-extrabold text-slate-800">Historial de Operaciones</h1>
            <p class="text-slate-500 mt-3 text-lg">Seleccione el módulo que desea auditar</p>
        </div>

        <div class="grid grid-cols-1 md:grid-cols-2 gap-8">
            <a href="HistorialVentas.aspx" class="group relative bg-white rounded-2xl shadow-sm border border-slate-200 p-8 hover:shadow-md hover:border-blue-400 transition-all cursor-pointer block text-center">
                <div class="bg-blue-50 w-20 h-20 mx-auto rounded-full flex items-center justify-center mb-6 group-hover:scale-110 transition-transform">
                    <svg class="w-10 h-10 text-blue-600" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 8c-1.657 0-3 .895-3 2s1.343 2 3 2 3 .895 3 2-1.343 2-3 2m0-8c1.11 0 2.08.402 2.599 1M12 8V7m0 1v8m0 0v1m0-1c-1.11 0-2.08-.402-2.599-1M21 12a9 9 0 11-18 0 9 9 0 0118 0z"></path>
                    </svg>
                </div>
                <h3 class="text-2xl font-bold text-slate-800 mb-2">Ventas</h3>
                <p class="text-slate-500">Consultar y filtrar el registro histórico de ventas realizadas a clientes.</p>
            </a>

            <a href="HistorialCompras.aspx" class="group relative bg-white rounded-2xl shadow-sm border border-slate-200 p-8 hover:shadow-md hover:border-emerald-400 transition-all cursor-pointer block text-center">
                <div class="bg-emerald-50 w-20 h-20 mx-auto rounded-full flex items-center justify-center mb-6 group-hover:scale-110 transition-transform">
                    <svg class="w-10 h-10 text-emerald-600" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 11H5m14 0a2 2 0 012 2v6a2 2 0 01-2 2H5a2 2 0 01-2-2v-6a2 2 0 012-2m14 0V9a2 2 0 00-2-2M5 11V9a2 2 0 012-2m0 0V5a2 2 0 012-2h6a2 2 0 012 2v2M7 7h10"></path>
                    </svg>
                </div>
                <h3 class="text-2xl font-bold text-slate-800 mb-2">Compras</h3>
                <p class="text-slate-500">Auditar el ingreso de stock histórico mediante compras a proveedores.</p>
            </a>

        </div>
    </div>
</asp:Content>
