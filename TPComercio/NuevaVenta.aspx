<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master"
AutoEventWireup="true"
CodeBehind="NuevaVenta.aspx.cs"
Inherits="TPComercio.NuevaVenta" %>

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

        <asp:DropDownList
            ID="ddlClientes"
            runat="server"
            CssClass="border p-2 rounded w-full">
        </asp:DropDownList>

        <asp:TextBox
            ID="txtFecha"
            runat="server"
            CssClass="border p-2 rounded"
            ReadOnly="true">
        </asp:TextBox>

    </div>

    <div class="grid grid-cols-4 gap-4 mb-4">

        <asp:TextBox
            ID="txtBusqueda"
            runat="server"
            CssClass="border p-2 rounded col-span-3"
            placeholder="Buscar producto...">
        </asp:TextBox>

        <asp:Button
            ID="btnBuscar"
            runat="server"
            Text="Buscar"
            OnClick="btnBuscar_Click"
            CssClass="bg-blue-600 text-white rounded px-4 py-2" />

    </div>

   <asp:GridView ID="dgvProductos"
    runat="server"
    AutoGenerateColumns="false"
    CssClass="table-auto w-full border"
    OnRowCommand="dgvProductos_RowCommand">

    <Columns>

        <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"/>

        <asp:BoundField
            DataField="Codigo"
            HeaderText="Código" />

        <asp:BoundField
            DataField="Nombre"
            HeaderText="Producto" />

        <asp:BoundField
            DataField="StockActual"
            HeaderText="Stock" />

        <asp:BoundField
            DataField="PrecioVenta"
            HeaderText="Precio" />

        <asp:TemplateField HeaderText="Cantidad">
            <ItemTemplate>
                <asp:TextBox
                    ID="txtCantidad"
                    runat="server"
                    Text="1"
                    CssClass="border p-1 rounded w-20">
                </asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Acción">
            <ItemTemplate>
                <asp:Button
                    ID="btnAgregar"
                    runat="server"
                    Text="Agregar"
                    CommandName="Agregar"
                    CommandArgument='<%# Eval("Id") %>'
                    CssClass="bg-green-600 text-white px-3 py-1 rounded" />
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>

</asp:GridView>


    <div class="border rounded p-5 mb-5">
        <h3 class="font-bold mb-2">
            Detalle de productos vendidos
        </h3>

        <asp:GridView
    ID="dgvDetalle"
    runat="server"
    AutoGenerateColumns="false"
    CssClass="table-auto w-full text-left"
    OnRowCommand="dgvDetalle_RowCommand">
    <Columns>
        <asp:BoundField DataField="NombreProducto" HeaderText="Producto" />
        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
        <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio U." DataFormatString="{0:C}" />
        <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
        
        <asp:TemplateField HeaderText="Acción">
            <ItemTemplate>
                <asp:Button
                    ID="btnQuitar"
                    runat="server"
                    Text="Quitar"
                    CommandName="Quitar"
                    CommandArgument='<%# Eval("Id") %>'
                    CssClass="bg-red-600 text-white px-3 py-1 rounded" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

    <div class="text-right">

        <asp:Label
            ID="lblTotal"
            runat="server"
            Text="Total: $0"
            CssClass="text-xl font-bold block mb-3">
        </asp:Label>

        <asp:Button
            ID="btnConfirmarVenta"
            runat="server"
            Text="Confirmar Venta"
            OnClick="btnConfirmarVenta_Click"
            CssClass="bg-blue-600 text-white px-5 py-2 rounded" />

    </div>

</div>

</asp:Content>