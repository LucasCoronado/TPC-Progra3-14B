<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NuevaVenta.aspx.cs" Inherits="TPComercio.NuevaVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2"
ContentPlaceHolderID="MainContent"
runat="server">

<div class="bg-white p-6 rounded-xl shadow">

<h2 class="text-2xl font-bold mb-5">
Nueva Venta
</h2>

<div class="grid grid-cols-2 gap-4 mb-4">

<select class="border p-2 rounded">
<option>Seleccionar Cliente</option>
</select>

<input type="text"
placeholder="Fecha"
class="border p-2 rounded">

</div>

<div class="grid grid-cols-4 gap-4 mb-4">

 <input type="text"
        placeholder="Buscar producto..."
        class="border p-2 rounded col-span-3">

    <button class="bg-blue-600 text-white rounded">
        Buscar
    </button>
    </div>
    <table class="table-auto w-full border">
    <thead>
        <tr>
            <th>Código</th>
            <th>Producto</th>
            <th>Precio</th>
            <th>Stock</th>
            <th>Cantidad</th>
            <th></th>
        </tr>
    </thead>

    <tbody>
        <tr>
            <td>P001</td>
            <td>Yerba Mate</td>
            <td>$2500</td>
            <td>50</td>
            <td>
                <input type="number" class="border rounded p-1 w-20" />
            </td>
            <td>
                <button class="bg-green-600 text-white px-3 py-1 rounded">
                    Agregar
                </button>
            </td>
        </tr>
    </tbody>
</table>


<div class="border rounded p-5 mb-5">
Detalle de productos vendidos
</div>

<div class="text-right">

<h3 class="text-xl font-bold mb-3">
Total: $0
</h3>

<button class="bg-blue-600 text-white px-5 py-2 rounded">
Confirmar Venta
</button>

</div>

</div>

</asp:Content>