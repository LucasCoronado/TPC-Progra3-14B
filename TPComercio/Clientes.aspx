<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPComercio.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">

    <div class="d-flex justify-content-between mb-3">
        <h2>Clientes</h2>
        <asp:Button ID="btnNuevoCliente" runat="server"
            Text="Nuevo Cliente"
            CssClass="btn btn-success" />
    </div>

    <div class="card">
        <div class="card-body">

            <div class="row">

                <div class="col-md-4">
                    <label>Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server"
                        CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <label>Apellido</label>
                    <asp:TextBox ID="txtApellido" runat="server"
                        CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <label>DNI</label>
                    <asp:TextBox ID="txtDni" runat="server"
                        CssClass="form-control"></asp:TextBox>
                </div>

            </div>

        </div>
    </div>

    <br />

    <asp:GridView ID="dgvClientes"
        runat="server"
        CssClass="table table-bordered table-hover">
    </asp:GridView>

</div>
</asp:Content>
