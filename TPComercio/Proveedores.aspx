<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="TPComercio.Proveedores" %>

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

        <h2 class="text-2xl font-bold mb-5">
            Proveedores
        </h2>

        <div class="grid grid-cols-4 gap-4 mb-5">
            <asp:TextBox runat="server" ID="txtRazonSocial" CssClass="border p-2 rounded w-full mb-4" placeholder="Razón Social"/>
            <asp:TextBox runat="server" ID="txtCuit" CssClass="border p-2 rounded w-full mb-4" placeholder="CUIT"/>
            <asp:TextBox runat="server" ID="txtTelefonoProveedor" CssClass="border p-2 rounded w-full mb-4" placeholder="Teléfono"/>
            <asp:TextBox runat="server" ID="txtEmailProveedor" CssClass="border p-2 rounded w-full mb-4" placeholder="Email"/>
        </div>

        <div class="mb-6">
            <asp:Label ID="lblError" runat="server" Text="" CssClass="text-red-600 font-bold"></asp:Label>
        </div>

        <asp:Button Text="Nuevo Proveedor" ID="btnAgregarProveedor" OnClick="btnAgregarProveedor_Click" runat="server" CssClass="bg-green-600 text-white px-4 py-2 rounded mb-5"/>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="dgvProveedores" runat="server" CssClass="table table-auto w-full border" 
                    AutoGenerateColumns="false" DataKeyNames="Id"
                    OnRowEditing="dgvProveedores_RowEditing"
                    OnRowCancelingEdit="dgvProveedores_RowCancelingEdit"
                    OnRowUpdating="dgvProveedores_RowUpdating"
                    OnRowDeleting="dgvProveedores_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" Visible="false" ReadOnly="true" />
                        
                        <asp:BoundField DataField="RazonSocial" HeaderText="Razón Social" ControlStyle-CssClass="borde-edicion" />
                        <asp:BoundField DataField="Cuit" HeaderText="CUIT" ControlStyle-CssClass="borde-edicion" />
                        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" ControlStyle-CssClass="borde-edicion" />
                        <asp:BoundField DataField="Email" HeaderText="Email" ControlStyle-CssClass="borde-edicion" />
                        
                        <asp:TemplateField HeaderText="Acciones" ItemStyle-Width="20%">
                            <ItemTemplate>
                                
                                <asp:Button ID="btnEditar" runat="server" Text="✏️ Editar" CssClass="btn btn-sm btn-outline-secondary me-2" CommandName="Edit" />
                                <asp:Button ID="btnEliminar" runat="server" Text="🗑️ Eliminar" CssClass="btn btn-sm btn-outline-danger" CommandName="Delete" OnClientClick="return confirm('¿Seguro que deseas eliminar este proveedor?');" />

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