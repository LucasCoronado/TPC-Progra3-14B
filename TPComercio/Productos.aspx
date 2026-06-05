<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TPComercio.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="container mt-4">

    <div class="d-flex justify-content-between align-items-center mb-3">
        <h2>Productos</h2>
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Producto"
            CssClass="btn btn-primary" />
    </div>

    <div class="card mb-4">
        <div class="card-header">
            Filtros
        </div>

        <div class="card-body">

            <div class="row">

                <div class="col-md-3">
                    <label>Código</label>
                    <asp:TextBox ID="txtCodigo" runat="server"
                        CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-md-3">
                    <label>Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server"
                        CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-md-3">
                    <label>Marca</label>
                    <asp:DropDownList ID="ddlMarca" runat="server"
                        CssClass="form-select"></asp:DropDownList>
                </div>

                <div class="col-md-3">
                    <label>Categoría</label>
                    <asp:DropDownList ID="ddlCategoria" runat="server"
                        CssClass="form-select"></asp:DropDownList>
                </div>

            </div>

        </div>
    </div>

    <asp:GridView ID="dgvProductos"
        runat="server"
        CssClass="table table-striped table-hover">
    </asp:GridView>

</div>

</asp:Content>