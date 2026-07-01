<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPComercio.Clientes" %>

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

        <h2 class="text-2xl font-bold mb-5">Clientes</h2>

        <div class="grid grid-cols-5 gap-4 mb-5">
            <asp:TextBox runat="server" ID="txtNombreCliente" CssClass="border p-2 rounded w-full mb-4" placeholder="Nombre" />
            <asp:TextBox runat="server" ID="txtApellidoCliente" CssClass="border p-2 rounded w-full mb-4" placeholder="Apellido" />
            <asp:TextBox runat="server" ID="txtDniCliente" CssClass="border p-2 rounded w-full mb-4" placeholder="Dni" />
            <asp:TextBox runat="server" ID="txtTelefonoCliente" CssClass="border p-2 rounded w-full mb-4" placeholder="Telefono" />
            <asp:TextBox runat="server" ID="txtEmailCliente" CssClass="border p-2 rounded w-full mb-4" placeholder="Email" />
        </div>

        <div class="mb-4">
            <asp:Label ID="lblError" runat="server" Text="" CssClass="text-red-600 font-bold"></asp:Label>
        </div>

        <asp:Button Text="Nuevo Cliente" ID="btnAgregarCliente" OnClick="btnAgregarCliente_Click" runat="server" CssClass="bg-green-600 text-white px-4 py-2 rounded mb-5" />

        <hr class="mb-5" />

        <asp:Panel runat="server" DefaultButton="btnBuscar" CssClass="flex gap-4 mb-5 bg-gray-50 p-4 rounded border">
            <asp:TextBox runat="server" ID="txtFiltro" CssClass="border p-2 rounded w-full" placeholder="Buscar por Apellido o DNI..." />
            <asp:Button Text="Buscar" ID="btnBuscar" OnClick="btnBuscar_Click" runat="server" CssClass="bg-slate-800 text-white px-4 py-2 rounded" />
            <asp:Button Text="Limpiar" ID="btnLimpiar" OnClick="btnLimpiar_Click" runat="server" CssClass="bg-gray-500 text-white px-4 py-2 rounded" />
        </asp:Panel>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="dgvClientes" runat="server" CssClass="table table-auto w-full border"
                    AutoGenerateColumns="false" DataKeyNames="Id"
                    OnRowEditing="dgvClientes_RowEditing"
                    OnRowCancelingEdit="dgvClientes_RowCancelingEdit"
                    OnRowUpdating="dgvClientes_RowUpdating"
                    OnRowDeleting="dgvClientes_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" Visible="false" ReadOnly="true" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" ControlStyle-CssClass="borde-edicion" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" ControlStyle-CssClass="borde-edicion" />
                        <asp:BoundField DataField="Dni" HeaderText="Dni" ControlStyle-CssClass="borde-edicion" />
                        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" ControlStyle-CssClass="borde-edicion" />
                        <asp:BoundField DataField="Email" HeaderText="Email" ControlStyle-CssClass="borde-edicion" />

                        <asp:TemplateField HeaderText="Acciones" ItemStyle-Width="20%">
                            <ItemTemplate>

                                <asp:Button ID="btnEditar" runat="server" Text="✏️ Editar" CssClass="btn btn-sm btn-outline-secondary me-2" CommandName="Edit" />
                                <asp:Button ID="btnEliminar" runat="server" Text="🗑️ Eliminar" CssClass="btn btn-sm btn-outline-danger" CommandName="Delete" OnClientClick="return confirm('¿Seguro que deseas eliminar este cliente?');" />

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
