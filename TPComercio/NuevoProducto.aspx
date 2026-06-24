<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NuevoProducto.aspx.cs" Inherits="TPComercio.NuevoProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%if (Request.QueryString["id"] != null)
        {%>
    <h2 class="text-2xl font-bold mb-3">Modificar Producto</h2>
    <%}
        else
        { %>
    <h2 class="text-2xl font-bold mb-2">Nuevo Producto</h2>
    <%} %>

    <div class="row">
        <div class="col-6">
            <div class="mb-2">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control w-50" ReadOnly="true" />
            </div>

            <div class="mb-2">
                <label for="txtCodigo" class="form-label">Codigo: </label>
                <div class="d-flex align-items-center">
                    <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control w-50" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCodigo"
                        ErrorMessage="El código es obligatorio" ForeColor="Red" Display="Dynamic" CssClass="ms-2">
                    </asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="mb-2">
                <label for="txtNombre" class="form-label">Nombre: </label>
                <div class="d-flex align-items-center">
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control w-50" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre"
                        ErrorMessage="El nombre es obligatorio" ForeColor="Red" Display="Dynamic" CssClass="ms-2">
                    </asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="mb-2">
                <label for="txtPrecio" class="form-label">Precio: </label>
                <div class="d-flex align-items-center">
                    <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control w-50" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPrecio"
                        ErrorMessage="El Precio es obligatorio" ForeColor="Red" Display="Dynamic" CssClass="ms-2">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtPrecio"
                        ValidationExpression="^[0-9]+([,\.][0-9]+)?$"
                        ErrorMessage="Solo ingrese números" ForeColor="Red" Display="Dynamic" CssClass="ms-2">
                    </asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="mb-2">
                <label for="txtGanancia" class="form-label">Ganancia: </label>
                <div class="d-flex align-items-center">
                    <asp:TextBox runat="server" ID="txtGanancia" CssClass="form-control w-50" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtGanancia"
                        ErrorMessage="El porcentaje de Ganancia es obligatorio" ForeColor="Red" Display="Dynamic" CssClass="ms-2">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtGanancia"
                        ValidationExpression="^[0-9]+([,\.][0-9]+)?$"
                        ErrorMessage="Solo ingrese números" ForeColor="Red" Display="Dynamic" CssClass="ms-2">
                    </asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="mb-2">
                <label for="txtStock" class="form-label">Stock: </label>
                <asp:TextBox runat="server" ID="txtStock" CssClass="form-control w-50" ReadOnly="true" />
            </div>

            <div class="mb-2">
                <label for="txtStockMinimo" class="form-label">Stock minimo: </label>
                <div class="d-flex align-items-center">
                    <asp:TextBox runat="server" ID="txtStockMinimo" CssClass="form-control w-50" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtStockMinimo"
                        ErrorMessage="El valor es obligatorio" ForeColor="Red" Display="Dynamic" CssClass="ms-2">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtStockMinimo"
                        ValidationExpression="^[0-9]+$"
                        ErrorMessage="Solo números enteros" ForeColor="Red" Display="Dynamic" CssClass="ms-2">
                    </asp:RegularExpressionValidator>
                </div>
            </div>


            <div class="mb-2">
                <label for="ddlMarcas" class="form-label">Marca: </label>
                <asp:DropDownList ID="ddlMarcas" CssClass="form-select w-50" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-2">
                <label for="ddlCategorias" class="form-label">Categoria</label>
                <asp:DropDownList ID="ddlCategorias" CssClass="form-select w-50" runat="server"></asp:DropDownList>
            </div>

            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

            <div class="mb-2">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary mr-5" runat="server" OnClick="btnAceptar_Click" />
                <a href="Productos.aspx">Cancelar</a>

                <%if (Request.QueryString["id"] != null)
                    {%>
                <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-warning ml-5" runat="server" OnClick="btnEliminar_Click" />
                <%} %>
            </div>
        </div>
    </div>

</asp:Content>
