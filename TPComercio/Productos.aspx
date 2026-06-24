<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TPComercio.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .borde-edicion {
            border: 1px solid #0d6efd !important;
            background-color: #f8f9fa !important;
            box-sizing: border-box;
            width: 100%;
            padding: 2px;
            outline: none;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="bg-white p-6 rounded-xl shadow">
        <h2 class="text-2xl font-bold mb-5">Gestión de Productos</h2>

        <a href="NuevoProducto.aspx" class="btn btn-primary px-4 py-2 mb-5">Agregar</a>

        <asp:Panel runat="server" DefaultButton="btnBuscar" CssClass="flex gap-4 mb-5 bg-gray-50 p-4 rounded border">
            <asp:TextBox runat="server" ID="txtFiltro" CssClass="border p-2 rounded w-full" placeholder="Buscar por Nombre o Código..." />
            <asp:Button Text="Buscar" ID="btnBuscar" OnClick="btnBuscar_Click" runat="server" CssClass="bg-slate-800 text-white px-4 py-2 rounded" />
            <asp:Button Text="Limpiar" ID="btnLimpiar" OnClick="btnLimpiar_Click" runat="server" CssClass="bg-gray-500 text-white px-4 py-2 rounded" />
        </asp:Panel>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="mb-4">
                    <asp:Label ID="lblError" runat="server" Text="" CssClass="text-red-600 font-bold"></asp:Label>
                </div>

                <asp:GridView ID="dgvProductos" runat="server" CssClass="table table-auto w-full border"
                    AutoGenerateColumns="false" DataKeyNames="Id"
                    OnRowEditing="dgvProductos_RowEditing"
                    OnRowCancelingEdit="dgvProductos_RowCancelingEdit"
                    OnRowUpdating="dgvProductos_RowUpdating"
                    OnRowDeleting="dgvProductos_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" Visible="false" ReadOnly="true" />
                        <asp:BoundField DataField="Codigo" HeaderText="Código" ControlStyle-CssClass="borde-edicion" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" ControlStyle-CssClass="borde-edicion" />
                        <asp:BoundField DataField="StockActual" HeaderText="Stock Actual" ControlStyle-CssClass="borde-edicion" ReadOnly="true" />

                        <asp:TemplateField HeaderText="Acciones" ItemStyle-Width="25%">
                            <ItemTemplate>

                                <asp:Button ID="btnEditar" runat="server" Text="✏️ Editar" CssClass="btn btn-sm btn-outline-secondary me-2" CommandName="Edit" />

                                <a href='NuevoProducto.aspx?id=<%# Eval("Id") %>' class="btn btn-sm btn-outline-info me-2">⚙️ Edición Avanzada</a>

                                <asp:Button ID="btnEliminar" runat="server" Text="🗑️ Eliminar" CssClass="btn btn-sm btn-outline-danger" CommandName="Delete" OnClientClick="return confirm('¿Seguro que deseas eliminar este producto?');" />


                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Button ID="btnGuardar" runat="server" Text="💾 Guardar" CssClass="btn btn-sm btn-success me-2" CommandName="Update" />
                                <asp:Button ID="btnCancelar" runat="server" Text="❌ Cancelar" CssClass="btn btn-sm btn-danger" CommandName="Cancel" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>

</asp:Content>
