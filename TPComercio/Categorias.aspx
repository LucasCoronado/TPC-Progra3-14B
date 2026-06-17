<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="TPComercio.Categorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <div class="bg-white p-6 rounded-xl shadow">

        <h2 class="text-2xl font-bold mb-5">Categorías
        </h2>

        <asp:TextBox runat="server" ID="txtNuevaCategoria" CssClass="border p-2 rounded w-full mb-3" placeholder="Nombre de Categoria" />

        <asp:Button Text="Agregar" ID="btnAgregarCategoria" OnClick="btnAgregarCategoria_Click" runat="server" CssClass="bg-blue-600 text-white px-4 py-2 rounded mb-3" />


        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="mb-4">
                    <asp:Label ID="lblError" runat="server" Text="" CssClass="text-red-600 font-bold"></asp:Label>
                </div>

                <asp:GridView ID="dgvCategorias" runat="server" CssClass="table table-auto w-full border"
                    AutoGenerateColumns="false" DataKeyNames="Id"
                    OnRowEditing="dgvCategorias_RowEditing"
                    OnRowCancelingEdit="dgvCategorias_RowCancelingEdit"
                    OnRowUpdating="dgvCategorias_RowUpdating"
                    OnRowDeleting="dgvCategorias_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="true" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" ControlStyle-CssClass="borde-edicion" />

                        <asp:TemplateField HeaderText="Acciones" ItemStyle-Width="20%">

                            <ItemTemplate>
                                <asp:Button ID="btnEditar" runat="server" Text="✏️ Editar" CssClass="btn btn-sm btn-outline-secondary me-2" CommandName="Edit" />

                                <asp:Button ID="btnEliminar" runat="server" Text="🗑️ Eliminar" CssClass="btn btn-sm btn-outline-danger" CommandName="Delete" OnClientClick="return confirm('¿Seguro que deseas eliminar esta categoría?');" />

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
