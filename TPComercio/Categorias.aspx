<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="TPComercio.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row mt-5 mb-4 align-items-center">
        <div class="col-8">
            <h2>Gestión de Categorias</h2>
            <p class="text-muted">Administrá las categorias de los productos del sistema.</p>
        </div>
        <div class="col-4 text-end">
            <asp:Button ID="btnAgregarCategoria" runat="server" Text="+ Agregar Categoria" CssClass="btn btn-primary"  />
        </div>
    </div>

   <div class="row">
        <div class="col-12">
            <div class="table-responsive shadow-sm rounded">

                <asp:GridView ID="dgvCategorias" runat="server" CssClass="table table-hover table-bordered mb-0"
                    AutoGenerateColumns="false" DataKeyNames="Id">

                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" ItemStyle-Width="10%" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />

                        <asp:TemplateField HeaderText="Acciones" ItemStyle-Width="20%" ItemStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Button ID="btnEditar" runat="server" Text="✏️ Editar" CssClass="btn btn-sm btn-outline-secondary me-2" />
                                <asp:Button ID="btnEliminar" runat="server" Text="🗑️ Eliminar" CssClass="btn btn-sm btn-outline-danger" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
