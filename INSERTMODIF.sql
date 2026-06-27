USE [BDDComercio]
GO

-- Configuración para evitar errores de compatibilidad regional con las fechas
SET DATEFORMAT ymd;
GO

-- ==========================================
-- 1. TABLAS MAESTRAS (Sin llaves foráneas)
-- ==========================================

-- TABLA: Categorias
INSERT INTO Categorias (Descripcion, Activo) VALUES
('Electrónica', 1),
('Indumentaria', 1),
('Almacén', 1),
('Bebidas', 1),
('Limpieza', 1),
('Bazar', 1),
('Librería', 1),
('Herramientas', 1),
('Calzado', 1),
('Perfumería', 1);

-- TABLA: Marcas
INSERT INTO Marcas (Descripcion, Activo) VALUES
('Samsung', 1),
('Nike', 1),
('Coca-Cola', 1),
('Arcor', 1),
('Bic', 1),
('Tramontina', 1),
('Philips', 1),
('Adidas', 1),
('Unilever', 1),
('Logitech', 1);

-- TABLA: Clientes
INSERT INTO Clientes (Nombre, Apellido, Dni, Telefono, Email, Activo) VALUES
('Juan', 'Pérez', '35123456', '1144445555', 'juan.perez@email.com', 1),
('María', 'Gómez', '38765432', '1155556666', 'maria.gomez@email.com', 1),
('Carlos', 'Rodríguez', '32456789', '1166667777', 'carlos.rod@email.com', 1),
('Ana', 'Fernández', '40123789', '1122223333', 'ana.f@email.com', 1),
('Luis', 'López', '29456123', '1133334444', 'luis.lopez@email.com', 1),
('Laura', 'Martínez', '36789456', '1177778888', 'laura.m@email.com', 1),
('Diego', 'Sánchez', '33123987', '1188889999', 'diego.s@email.com', 1),
('Sofía', 'Díaz', '42159753', '1199990000', 'sofia.diaz@email.com', 1),
('Andrés', 'Silva', '31456852', '1123456789', 'andres.silva@email.com', 1),
('Lucía', 'Romero', '39753159', '1198765432', 'lucia.r@email.com', 1);

-- TABLA: Proveedores
INSERT INTO Proveedores (RazonSocial, Cuit, Telefono, Email, Activo) VALUES
('Distribuidora Norte S.A.', '30-12345678-9', '011-4545-0001', 'ventas@distrinorte.com', 1),
('Nike Argentina SRL', '30-87654321-9', '011-4848-0002', 'contacto@nikearg.com', 1),
('Coca-Cola Femsa S.A.', '30-45678912-9', '011-4141-0003', 'clientes@cocacola.com', 1),
('Arcor S.A.I.C.', '30-98765432-1', '011-4242-0004', 'comercial@arcor.com.ar', 1),
('Bic Argentina S.A.', '30-36925814-7', '011-4343-0005', 'libreria@bic.com', 1),
('Tramontina Arg S.A.', '30-25814736-9', '011-4646-0006', 'bazar@tramontina.com.ar', 1),
('Philips Iluminación', '30-14725836-5', '011-4747-0007', 'soporte@philips.com', 1),
('Adidas Arg SA', '30-95175346-8', '011-4949-0008', 'ventas@adidas.com.ar', 1),
('Unilever de Arg SA', '30-35715948-2', '011-5050-0009', 'atencion@unilever.com', 1),
('Logitech Cono Sur', '30-65498732-1', '011-5151-0010', 'canales@logitech.com', 1);

-- TABLA: Usuarios
INSERT INTO Usuarios (NombreUsuario, Password, Rol, Activo) VALUES
('admin', 'admin123', 'Administrador', 1),
('cajero1', 'clave123', 'Cajero', 1),
('cajero2', 'clave456', 'Cajero', 1),
('supervisor', 'super789', 'Supervisor', 1),
('deposito1', 'depo123', 'Pañolero', 1),
('vendedor1', 'vend123', 'Vendedor', 1),
('vendedor2', 'vend456', 'Vendedor', 1),
('gerente', 'gerente2026', 'Gerente', 1),
('auditor', 'audit987', 'Auditor', 1),
('soporte', 'soporte321', 'Soporte', 1);

-- ==========================================
-- 2. TABLAS CON LLAVES FORÁNEAS (Dependencias)
-- ==========================================

-- TABLA: Productos
INSERT INTO Productos (Codigo, Nombre, StockActual, StockMinimo, PrecioCompraActual, PorcentajeGanancia, IdMarca, IdCategoria, Activo) VALUES
('PROD001', 'Smart TV 50" 4K', 15, 3, 450000.00, 35.00, 1, 1, 1),
('PROD002', 'Zapatillas Running', 25, 5, 60000.00, 40.00, 2, 2, 1),
('PROD003', 'Gaseosa Cola 2.25L', 120, 20, 1500.00, 30.00, 3, 4, 1),
('PROD004', 'Chocolatada 1L', 60, 10, 1200.00, 25.00, 4, 3, 1),
('PROD005', 'Pack Bolígrafos Azul x4', 200, 15, 800.00, 50.00, 5, 7, 1),
('PROD006', 'Cuchillo de Asado', 45, 8, 2500.00, 45.00, 6, 6, 1),
('PROD007', 'Bombita LED 9W', 80, 15, 950.00, 40.00, 7, 1, 1),
('PROD008', 'Remera Deportiva', 35, 5, 15000.00, 42.00, 8, 2, 1),
('PROD009', 'Jabón Líquido para Ropa', 40, 8, 4500.00, 35.00, 9, 5, 1),
('PROD010', 'Mouse Inalámbrico', 30, 5, 12000.00, 38.00, 10, 1, 1);

-- TABLA: Compras
INSERT INTO Compras (Fecha, IdProveedor, Total) VALUES
('2026-06-10 09:00:00', 1, 4500000.00),
('2026-06-11 10:30:00', 2, 600000.00),
('2026-06-12 11:15:00', 3, 150000.00),
('2026-06-12 14:00:00', 4, 72000.00),
('2026-06-13 08:45:00', 5, 80000.00),
('2026-06-13 16:20:00', 6, 112500.00),
('2026-06-14 09:10:00', 7, 76000.00),
('2026-06-14 13:00:00', 8, 525000.00),
('2026-06-15 10:00:00', 9, 180000.00),
('2026-06-15 15:30:00', 10, 360000.00);

-- TABLA: Ventas
INSERT INTO Ventas (Fecha, IdCliente, IdUsuario, NumeroFactura, Total) VALUES
('2026-06-16 09:15:00', 1, 2, '0001-00000001', 607500.00),
('2026-06-16 10:22:00', 2, 2, '0001-00000002', 84000.00),
('2026-06-16 11:05:00', 3, 3, '0001-00000003', 3900.00),
('2026-06-16 14:40:00', 4, 3, '0001-00000004', 3000.00),
('2026-06-16 16:12:00', 5, 2, '0001-00000005', 2400.00),
('2026-06-17 09:30:00', 6, 2, '0001-00000006', 7250.00),
('2026-06-17 10:45:00', 7, 3, '0001-00000007', 26600.00),
('2026-06-17 11:15:00', 8, 3, '0001-00000008', 42600.00),
('2026-06-17 13:02:00', 9, 2, '0001-00000009', 12150.00),
('2026-06-17 15:20:00', 10, 3, '0001-00000010', 33120.00);

-- ==========================================
-- 3. TABLAS DE DETALLES (Dependen de las transacciones y productos)
-- ==========================================

-- TABLA: DetalleCompras
INSERT INTO DetalleCompras (IdCompra, IdProducto, Cantidad, PrecioUnitario) VALUES
(1, 1, 10, 450000.00),
(2, 2, 10, 60000.00),
(3, 3, 100, 1500.00),
(4, 4, 60, 1200.00),
(5, 5, 100, 800.00),
(6, 6, 45, 2500.00),
(7, 7, 80, 950.00),
(8, 8, 35, 15000.00),
(9, 9, 40, 4500.00),
(10, 10, 30, 12000.00);

-- TABLA: DetalleVentas
INSERT INTO DetalleVentas (IdVenta, IdProducto, Cantidad, PrecioUnitario) VALUES
(1, 1, 1, 607500.00),
(2, 2, 1, 84000.00),
(3, 3, 2, 1950.00),
(4, 4, 2, 1500.00),
(5, 5, 2, 1200.00),
(6, 6, 2, 3625.00),
(7, 7, 10, 1330.00),
(8, 8, 2, 21300.00),
(9, 9, 2, 6075.00),
(10, 10, 2, 16560.00);
GO