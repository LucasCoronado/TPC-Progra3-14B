<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPComercio.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Iniciar Sesión - Gestión Comercial</title>
    <script src="https://cdn.tailwindcss.com"></script>
</head>
<body class="bg-slate-900 min-h-screen flex items-center justify-center">
    <form id="form1" runat="server" class="w-full max-w-md px-4">

        <div class="bg-white p-8 rounded-2xl shadow-2xl space-y-6">

            <div class="text-center">
                <h1 class="text-3xl font-bold text-slate-800">Bienvenido</h1>
                <p class="text-slate-500 mt-2">Ingresá tus credenciales para acceder</p>
            </div>

            <div class="space-y-5">
                <div>
                    <label class="block text-sm font-semibold text-slate-700 mb-1">Usuario</label>
                    <asp:TextBox ID="txtUsuario" runat="server"
                        CssClass="w-full px-4 py-3 border border-slate-300 rounded-xl focus:ring-4 focus:ring-blue-500/20 focus:border-blue-500 outline-none transition-all"
                        placeholder="Ej: admin"></asp:TextBox>
                </div>

                <div>
                    <label class="block text-sm font-semibold text-slate-700 mb-1">Contraseña</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"
                        CssClass="w-full px-4 py-3 border border-slate-300 rounded-xl focus:ring-4 focus:ring-blue-500/20 focus:border-blue-500 outline-none transition-all"
                        placeholder="••••••••"></asp:TextBox>
                </div>


                <asp:Label ID="lblError" runat="server" CssClass="text-red-500 text-sm font-semibold block text-center bg-red-50 p-2 rounded-lg"></asp:Label>
            </div>

            <asp:Button ID="btnIngresar" runat="server" Text="Iniciar Sesión" OnClick="btnIngresar_Click"
                CssClass="w-full bg-blue-600 hover:bg-blue-700 text-white font-bold py-3 rounded-xl transition-colors cursor-pointer shadow-lg shadow-blue-500/30" />

        </div>

    </form>
</body>
</html>
