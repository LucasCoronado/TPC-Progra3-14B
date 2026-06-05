<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="TPComercio.Proveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">

        <div class="d-flex justify-content-between mb-3">
            <h2>Proveedores</h2>

            <asp:Button ID="btnNuevoProveedor"
                runat="server"
                Text="Nuevo Proveedor"
                CssClass="btn btn-success" />
        </div>

        <div class="card">
            <div class="card-body">

                <div class="row">

                    <div class="col-md-6">
                        <label>Razón Social</label>
                        <asp:TextBox ID="txtRazonSocial"
                            runat="server"
                            CssClass="form-control">
                        </asp:TextBox>
                    </div>

                    <div class="col-md-6">
                        <label>CUIT</label>
                        <asp:TextBox ID="txtCuit"
                            runat="server"
                            CssClass="form-control">
                        </asp:TextBox>
                    </div>

                </div>

            </div>
        </div>

        <br />

        <asp:GridView ID="dgvProveedores"
            runat="server"
            CssClass="table table-striped">
        </asp:GridView>

    </div>
</asp:Content>
