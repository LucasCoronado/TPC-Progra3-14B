<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NuevaVenta.aspx.cs" Inherits="TPComercio.NuevaVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">

    <h2>Nueva Venta</h2>

    <div class="card mb-4">

        <div class="card-header">
            Datos del Cliente
        </div>

        <div class="card-body">

            <div class="row">

                <div class="col-md-6">
                    <label>Cliente</label>
                    <asp:DropDownList ID="ddlCliente"
                        runat="server"
                        CssClass="form-select">
                    </asp:DropDownList>
                </div>

            </div>

        </div>

    </div>

    <div class="card mb-4">

        <div class="card-header">
            Agregar Productos
        </div>

        <div class="card-body">

            <div class="row">

                <div class="col-md-5">
                    <label>Producto</label>
                    <asp:DropDownList ID="ddlProducto"
                        runat="server"
                        CssClass="form-select">
                    </asp:DropDownList>
                </div>

                <div class="col-md-3">
                    <label>Cantidad</label>
                    <asp:TextBox ID="txtCantidad"
                        runat="server"
                        CssClass="form-control">
                    </asp:TextBox>
                </div>

                <div class="col-md-2 d-flex align-items-end">
                    <asp:Button ID="btnAgregar"
                        runat="server"
                        Text="Agregar"
                        CssClass="btn btn-primary w-100" />
                </div>

            </div>

        </div>

    </div>

    <asp:GridView ID="dgvDetalleVenta"
        runat="server"
        CssClass="table table-striped table-hover">
    </asp:GridView>

    <div class="text-end mt-3">

        <h4>Total: $0</h4>

        <asp:Button ID="btnConfirmarVenta"
            runat="server"
            Text="Confirmar Venta"
            CssClass="btn btn-success btn-lg" />

    </div>

</div>
</asp:Content>
