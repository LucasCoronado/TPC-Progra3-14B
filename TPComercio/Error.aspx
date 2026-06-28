<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPComercio.Error" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error en el Sistema</title>
    <script src="https://cdn.tailwindcss.com"></script>
</head>
<body class="bg-slate-900 min-h-screen flex items-center justify-center">
    <form id="form1" runat="server" class="w-full max-w-lg px-4">
        
       
        <div class="bg-white p-8 rounded-2xl shadow-2xl space-y-6 border-t-8 border-red-500 text-center">
            
           
            <div class="flex justify-center">
                <div class="bg-red-50 p-4 rounded-full">
                    <svg class="w-16 h-16 text-red-500" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-3L13.732 4c-.77-1.333-2.694-1.333-3.464 0L3.34 16c-.77 1.333.192 3 1.732 3z"></path>
                    </svg>
                </div>
            </div>

            <div>
                <h1 class="text-3xl font-bold text-slate-800">¡Ups! Algo salió mal</h1>
                <p class="text-slate-500 mt-2">Hemos detectado un error en el sistema.</p>
            </div>

            
            <div class="bg-slate-50 p-4 rounded-xl border border-slate-200 text-left overflow-auto max-h-48 shadow-inner">
                <p class="text-sm font-semibold text-slate-700 mb-1">Detalle técnico:</p>
                <asp:Label ID="lblMensajeError" runat="server" CssClass="text-xs text-red-600 font-mono break-words"></asp:Label>
            </div>

            <a href="Login.aspx" class="inline-block w-full bg-slate-800 hover:bg-slate-900 text-white font-bold py-3 rounded-xl transition-colors shadow-lg">
                Volver al Inicio de Sesión
            </a>
            
        </div>

    </form>
</body>
</html>