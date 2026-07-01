using System;
using System.IO;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using Dominio;

namespace TPComercio
{
    public static class TicketHelper
    {
        public static void GenerarTicketPDF(string numeroVenta, string nombreCliente, decimal totalVenta, List<DetalleVenta> detalle, DateTime fechaVenta)
        {
            // Tamaño y margenes de doc
            Document doc = new Document(PageSize.A4, 30, 30, 30, 30);
            
            MemoryStream ms = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, ms);
            
            doc.Open();

            doc.Add(new Paragraph($"TICKET DE VENTA: {numeroVenta}"));
            doc.Add(new Paragraph($"Fecha: {fechaVenta:dd/MM/yyyy HH:mm}"));
            doc.Add(new Paragraph($"Cliente: {nombreCliente}\n\n"));
            
            PdfPTable tabla = new PdfPTable(4);
           
            tabla.AddCell("Producto");
            tabla.AddCell("Cant.");
            tabla.AddCell("Precio U.");
            tabla.AddCell("Subtotal");

            foreach (var item in detalle)
            {
                tabla.AddCell(item.NombreProducto);
                tabla.AddCell(item.Cantidad.ToString());
                tabla.AddCell(item.PrecioUnitario.ToString("C"));
                tabla.AddCell((item.Cantidad * item.PrecioUnitario).ToString("C"));
            }

            doc.Add(tabla);

            doc.Add(new Paragraph($"\nTOTAL A PAGAR: {totalVenta:C}"));

            doc.Close();

            // Descarga en navegador usando HttpContext.Current.Response
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("content-disposition", $"attachment;filename=Ticket_{numeroVenta}.pdf");
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.BinaryWrite(ms.ToArray());
            HttpContext.Current.Response.End();
        }
    }
}
