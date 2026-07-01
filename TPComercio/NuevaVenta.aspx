<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NuevaVenta.aspx.cs" Inherits="TPComercio.NuevaVenta"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="bg-white p-6 rounded-xl shadow max-w-7xl mx-auto">

        <h2 class="text-2xl font-bold mb-5 text-gray-800">Nueva Venta
        </h2>

        <div class="grid grid-cols-1 lg:grid-cols-12 gap-6 items-start">
            <%//Panel izquierdo %>
            <div class="lg:col-span-7 flex flex-col gap-6">

                <div class="grid grid-cols-2 gap-4">
                    <div>
                        <label class="block text-sm font-bold mb-1 text-gray-700">Cliente</label>
                        <asp:DropDownList
                            ID="ddlClientes"
                            runat="server"
                            CssClass="border p-2 rounded w-full bg-gray-50 focus:outline-none focus:ring-2 focus:ring-blue-500">
                        </asp:DropDownList>
                    </div>
                    <div>
                        <label class="block text-sm font-bold mb-1 text-gray-700">Fecha</label>
                        <asp:TextBox
                            ID="txtFecha"
                            runat="server"
                            CssClass="border p-2 rounded w-full bg-gray-100 text-gray-600"
                            ReadOnly="true">
                        </asp:TextBox>
                    </div>
                </div>

                <div class="bg-blue-50 p-4 rounded-lg border border-blue-100 flex flex-col h-[500px]">
                    <div class="flex gap-4 mb-4">
                        <asp:TextBox
                            ID="txtBusqueda"
                            runat="server"
                            CssClass="border p-2 rounded flex-grow focus:outline-none focus:ring-2 focus:ring-blue-500"
                            placeholder="Escriba el código o nombre del producto para buscar...">
                        </asp:TextBox>

                        <asp:Button
                            ID="btnBuscar"
                            runat="server"
                            Text="Buscar"
                            OnClick="btnBuscar_Click"
                            CssClass="bg-blue-600 hover:bg-blue-700 text-white font-bold rounded px-6 py-2 transition duration-200" />
                    </div>

                    <div id="divProductos" class="overflow-y-auto flex-grow border bg-white rounded">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgvProductos"
                                    runat="server"
                                    AutoGenerateColumns="false"
                                    CssClass="table-auto w-full text-left"
                                    OnRowCommand="dgvProductos_RowCommand">
                                    <HeaderStyle CssClass="bg-gray-100 border-b sticky top-0 text-center" />
                                    <RowStyle CssClass="border-b hover:bg-gray-50" />
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                                        <asp:BoundField DataField="Codigo" HeaderText="Código" ItemStyle-CssClass="p-2 whitespace-nowrap" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Producto" ItemStyle-CssClass="p-2 " />
                                        <asp:BoundField DataField="StockActual" HeaderText="Stock" ItemStyle-CssClass="p-2" />
                                        <asp:BoundField DataField="PrecioVenta" HeaderText="Precio" DataFormatString="{0:C}" ItemStyle-CssClass="p-2 whitespace-nowrap" />

                                        <asp:TemplateField HeaderText="Cantidad" ItemStyle-CssClass="p-2">
                                            <ItemTemplate>
                                                <asp:TextBox
                                                    ID="txtCantidad"
                                                    runat="server"
                                                    Text="1"
                                                    TextMode="Number"
                                                    min="1"
                                                    CssClass="border p-1 rounded w-20 text-center">
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Acción" ItemStyle-CssClass="p-2 text-center">
                                            <ItemTemplate>
                                                <asp:Button
                                                    ID="btnAgregar"
                                                    runat="server"
                                                    Text="+ Agregar"
                                                    CommandName="Agregar"
                                                    CommandArgument='<%# Eval("Id") %>'
                                                    CssClass="bg-green-600 hover:bg-green-700 text-white font-bold px-3 py-1 rounded text-sm transition duration-200" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            
            <%//Panel derecho %>
            <div class="lg:col-span-5 sticky top-6">
                <asp:UpdatePanel ID="upDetalle" runat="server">
                    <ContentTemplate>
                        <div class="border rounded-lg shadow-sm flex flex-col h-[600px] overflow-hidden bg-white">
                            <div class="bg-gray-800 text-white p-3 font-bold flex justify-between items-center">
                                <h3>🛒 Detalle de productos en el carrito</h3>
                            </div>

                            <div class="overflow-y-auto flex-grow">
                                <asp:GridView
                                    ID="dgvDetalle"
                                    runat="server"
                                    AutoGenerateColumns="false"
                                    CssClass="table-auto w-full text-left"
                                    OnRowCommand="dgvDetalle_RowCommand">
                                    <HeaderStyle CssClass="bg-gray-100 border-b sticky top-0 shadow-sm" />
                                    <RowStyle CssClass="border-b hover:bg-gray-50" />
                                    <Columns>
                                        <asp:BoundField DataField="NombreProducto" HeaderText="Producto" ItemStyle-CssClass="p-3" />
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cant." ItemStyle-CssClass="p-3 text-center" />
                                        <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio U." DataFormatString="{0:C}" ItemStyle-CssClass="p-3" />
                                        <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" ItemStyle-CssClass="p-3 font-bold" />

                                        <asp:TemplateField HeaderText="Quitar" ItemStyle-CssClass="p-3 text-center">
                                            <ItemTemplate>
                                                <asp:Button
                                                    ID="btnQuitar"
                                                    runat="server"
                                                    Text="✕"
                                                    CommandName="Quitar"
                                                    CommandArgument='<%# Eval("Id") %>'
                                                    CssClass="bg-red-100 hover:bg-red-200 text-red-700 font-bold px-2 py-1 rounded" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>

                            <div class="p-4 bg-gray-50 border-t mt-auto">
                                <div class="flex justify-between items-center">
                                    <span class="text-gray-500 italic">Revise los productos antes de confirmar.</span>
                                    <asp:Label
                                        ID="lblTotal"
                                        runat="server"
                                        Text="Total: $0.00"
                                        CssClass="text-2xl font-bold text-gray-800">
                                    </asp:Label>
                                </div>

                                <div class="flex justify-end gap-3 mt-4">
                                    <asp:Button
                                        ID="btnCancelarVenta"
                                        runat="server"
                                        Text="Cancelar Venta"
                                        OnClick="btnCancelarVenta_Click"
                                        CssClass="bg-red-500 hover:bg-red-600 text-white px-5 py-2 rounded font-bold transition duration-200" />
                                    
                                    <asp:Button
                                        ID="btnConfirmarVenta"
                                        runat="server"
                                        Text="Confirmar Venta"
                                        OnClick="btnConfirmarVenta_Click"
                                        CssClass="bg-green-600 hover:bg-green-700 text-white px-8 py-2 rounded font-bold text-lg shadow-md transition duration-200" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            

        </div> 
    </div>

</asp:Content>
