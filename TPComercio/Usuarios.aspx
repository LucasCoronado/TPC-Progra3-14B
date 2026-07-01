<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="TPComercio.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="bg-white p-6 rounded-xl shadow">
        <h2 class="text-2xl font-bold mb-5">Gestión de Usuarios</h2>
        <div class="grid grid-cols-3 gap-4 mb-1">

            <asp:TextBox runat="server" ID="txtNombreUsuario" CssClass="border p-2 rounded w-full mb-4" placeholder="Nombre de Usuario" />
            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="border p-2 rounded w-full mb-4" placeholder="Contraseña" />

            <asp:DropDownList ID="ddlRol" runat="server" CssClass="border p-2 rounded w-full mb-4">
                <asp:ListItem Text="Seleccionar Rol..." Value=""></asp:ListItem>
                <asp:ListItem Text="Administrador" Value="Administrador"></asp:ListItem>
                <asp:ListItem Text="Vendedor" Value="Vendedor"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="mb-4">
            <asp:Label ID="lblError" runat="server" Text="" CssClass="text-red-600 font-bold"></asp:Label>
        </div>
        <asp:Button Text="Agregar Usuario" ID="btnAgregarUsuario" OnClick="btnAgregarUsuario_Click" runat="server" CssClass="bg-blue-600 text-white px-4 py-2 rounded mb-1" />

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="dgvUsuarios" runat="server" CssClass="table table-auto w-full border"
                    AutoGenerateColumns="false" DataKeyNames="Id"
                    OnRowEditing="dgvUsuarios_RowEditing"
                    OnRowCancelingEdit="dgvUsuarios_RowCancelingEdit"
                    OnRowUpdating="dgvUsuarios_RowUpdating"
                    OnRowDeleting="dgvUsuarios_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="true" />

                        <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" ControlStyle-CssClass="borde-edicion" />
                        <asp:BoundField DataField="Password" HeaderText="Contraseña" ControlStyle-CssClass="borde-edicion" />
                        <asp:BoundField DataField="Rol" HeaderText="Rol" ControlStyle-CssClass="borde-edicion" />

                        <asp:TemplateField HeaderText="Acciones" ItemStyle-Width="20%">

                            <ItemTemplate>
                                <asp:Button ID="btnEditar" runat="server" Text="✏️ Editar" CssClass="btn btn-sm btn-outline-secondary me-2" CommandName="Edit" />

                                <asp:Button ID="btnEliminar" runat="server" Text="🗑️ Eliminar" CssClass="btn btn-sm btn-outline-danger" CommandName="Delete" OnClientClick="return confirm('¿Seguro que deseas eliminar este usuario?');" />
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
