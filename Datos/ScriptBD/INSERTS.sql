USE [BDDComercio]
GO

-- ============================================================================
-- 1. TABLA: Categorias (10 Registros)
-- ============================================================================
INSERT INTO Categorias (Descripcion, Activo) VALUES
('Componentes de PC', 1),
('Monitores y Pantallas', 1),
('Periféricos y Accesorios', 1),
('Almacenamiento', 1),
('Notebooks y Equipos', 1),
('Conectividad y Redes', 1),
('Audio y Sonido', 1),
('Cables y Adaptadores', 1),
('Consolas y Gaming', 1),
('Celulares y Tablets', 1);

-- ============================================================================
-- 2. TABLA: Marcas (10 Registros requeridos)
-- ============================================================================
INSERT INTO Marcas (Descripcion, Activo) VALUES
('ASUS', 1),
('Logitech', 1),
('Kingston', 1),
('Corsair', 1),
('Intel', 1),
('AMD', 1),
('Samsung', 1),
('Western Digital', 1),
('Razer', 1),
('Sony', 1);

-- ============================================================================
-- 3. TABLA: Productos (35 Registros - Mínimo 30 solicitados)
-- ============================================================================
INSERT INTO Productos (Codigo, Nombre, StockActual, StockMinimo, PrecioCompraActual, PorcentajeGanancia, IdMarca, IdCategoria, Activo) VALUES
-- Componentes de PC (IdCategoria: 1)
('TEC-001', 'Procesador Core i7 14700K', 12, 3, 420000.00, 25.00, 5, 1, 1),
('TEC-002', 'Procesador Ryzen 7 7800X3D', 8, 2, 445000.00, 22.00, 6, 1, 1),
('TEC-003', 'Placa de Video RTX 4070 ASUS TUF', 5, 2, 780000.00, 18.00, 1, 1, 1),
('TEC-004', 'Motherboard B650-PLUS WIFI', 15, 4, 210000.00, 30.00, 1, 1, 1),
-- Monitores y Pantallas (IdCategoria: 2)
('TEC-005', 'Monitor G5 27" QHD 165Hz', 7, 2, 320000.00, 35.00, 7, 2, 1),
('TEC-006', 'Monitor Gamer 24" IPS 75Hz', 14, 3, 165000.00, 40.00, 7, 2, 1),
-- Periféricos y Accesorios (IdCategoria: 3)
('TEC-007', 'Mouse Inalámbrico G305 Lightspeed', 40, 10, 38000.00, 45.00, 2, 3, 1),
('TEC-008', 'Teclado Mecánico G Pro X', 22, 5, 115000.00, 38.00, 2, 3, 1),
('TEC-009', 'Auriculares BlackShark V2 Pro', 18, 5, 140000.00, 35.00, 9, 3, 1),
('TEC-010', 'Mouse Pad Gigante Goliathus', 50, 15, 22000.00, 50.00, 9, 3, 1),
-- Almacenamiento (IdCategoria: 4)
('TEC-011', 'SSD NVMe M.2 1TB KC3000', 60, 10, 92000.00, 30.00, 3, 4, 1),
('TEC-012', 'SSD Externo 1TB E30', 25, 5, 110000.00, 28.00, 8, 4, 1),
('TEC-013', 'Disco Rígido Blue 2TB SATA3', 30, 8, 75000.00, 32.00, 8, 4, 1),
('TEC-014', 'Memoria RAM DDR5 32GB (2x16) Fury', 35, 8, 135000.00, 25.00, 3, 4, 1),
-- Notebooks y Equipos (IdCategoria: 5)
('TEC-015', 'Notebook ROG Strix i9 16GB RTX 4060', 4, 1, 1850000.00, 15.00, 1, 5, 1),
('TEC-016', 'Notebook Vivobook Ryzen 5 8GB', 10, 2, 680000.00, 20.00, 1, 5, 1),
-- Conectividad y Redes (IdCategoria: 6)
('TEC-017', 'Placa de Red Wi-Fi USB AC600', 45, 10, 15000.00, 50.00, 1, 6, 1),
-- Audio y Sonido (IdCategoria: 7)
('TEC-018', 'Barra de Sonido HW-C400', 12, 3, 195000.00, 30.00, 7, 7, 1),
('TEC-019', 'Parlante Bluetooth SRS-XB100', 25, 6, 59000.00, 42.00, 10, 7, 1),
('TEC-020', 'Auriculares In-Ear WF-C500', 30, 5, 68000.00, 38.00, 10, 7, 1),
-- Cables y Adaptadores (IdCategoria: 8)
('TEC-021', 'Cable HDMI 2.1 2 Metros', 100, 20, 8500.00, 60.00, 7, 8, 1),
-- Consolas y Gaming (IdCategoria: 9)
('TEC-022', 'Consola PlayStation 5 Slim 1TB', 6, 2, 980000.00, 15.00, 10, 9, 1),
('TEC-023', 'Joystick DualSense PS5 Blanco', 24, 5, 89000.00, 35.00, 10, 9, 1),
-- Celulares y Tablets (IdCategoria: 10)
('TEC-024', 'Celular Galaxy S24 Ultra 512GB', 8, 2, 1650000.00, 18.00, 7, 10, 1),
('TEC-025', 'Tablet Galaxy Tab A9+ 64GB', 15, 3, 290000.00, 25.00, 7, 10, 1),
-- Más Hardware variado para llegar a los 35 productos
('TEC-026', 'Fuente Certificada 750W Gold', 20, 5, 125000.00, 30.00, 4, 1, 1),
('TEC-027', 'Gabinete Gamer 4000D Airflow', 12, 3, 110000.00, 35.00, 4, 1, 1),
('TEC-028', 'Water Cooling H100x RGB Elite', 10, 3, 145000.00, 28.00, 4, 1, 1),
('TEC-029', 'Memoria RAM DDR4 8GB Fury', 80, 15, 28000.00, 40.00, 3, 4, 1),
('TEC-030', 'Pendrive 64GB DataTraveler', 150, 30, 6200.00, 55.00, 3, 4, 1),
('TEC-031', 'Teclado Mecánico Huntsman V3', 10, 2, 230000.00, 30.00, 9, 3, 1),
('TEC-032', 'Mouse Gamer DeathAdder Essential', 55, 12, 31000.00, 48.00, 9, 3, 1),
('TEC-033', 'Cargador Rápido 25W Tipo C', 90, 15, 19500.00, 50.00, 7, 8, 1),
('TEC-034', 'Disco Rígido Externo 2TB Pasport', 18, 4, 120000.00, 30.00, 8, 4, 1),
('TEC-035', 'Webcam C920 Pro HD 1080p', 15, 4, 85000.00, 35.00, 2, 3, 1);

-- ============================================================================
-- 4. TABLA: Clientes (10 Registros requeridos)
-- ============================================================================
INSERT INTO Clientes (Nombre, Apellido, Dni, Telefono, Email, Activo) VALUES
('Esteban', 'Quito', '34221155', '1123456789', 'esteban.quito@techmail.com', 1),
('Alan', 'Brito', '37884411', '1187654321', 'alan.brito@gamers.com', 1),
('Mónica', 'Galindo', '31559988', '1136925814', 'moni.galindo@enterprise.com', 1),
('Lucas', 'Moyano', '41223344', '1125814736', 'lucas.moyano@outlook.com', 1),
('Debora', 'Melo', '39445566', '1114725836', 'debora.melo@gmail.com', 1),
('Guillermo', 'Puertas', '28556677', '1195175346', 'bill.gates@microsoft.com', 1),
('Natalia', 'Natal', '35667788', '1135715948', 'naty.natal@techmail.com', 1),
('Federico', 'Mercurio', '33998877', '1165498732', 'freddie@rocktech.com', 1),
('Roberto', 'Sánchez', '25441122', '1174185296', 'sandro.tech@gmail.com', 1),
('Florencia', 'Flor', '43112233', '1196385274', 'flor.v@outlook.com', 1);

-- ============================================================================
-- 5. TABLA: Proveedores (10 Registros requeridos)
-- ============================================================================
INSERT INTO Proveedores (RazonSocial, Cuit, Telefono, Email, Activo) VALUES
('Mayorista Informática S.A.', '30-44112233-9', '011-4000-1111', 'ventas@mayonista-info.com.ar', 1),
('Tech Distribution SRL', '30-55223344-9', '011-4111-2222', 'compras@techdist.com', 1),
('ASUS Argentina S.A.', '30-66334455-9', '011-4222-3333', 'wholesales@asus.com.ar', 1),
('Logitech Cono Sur SRL', '30-77445566-9', '011-4333-4444', 'pedidos@logitech-latam.com', 1),
('Gamer Components S.A.', '30-88556677-9', '011-4444-5555', 'comercial@gamercomp.com', 1),
('Componentes del Plata', '30-99667788-9', '011-4555-6666', 'ventas@comdelplata.com.ar', 1),
('Samsung Electronics Arg', '30-11778899-9', '011-4666-7777', 'distribuidores@samsung.com', 1),
('Storage Latam SRL', '30-22889900-9', '011-4777-8888', 'sales@storagelatam.com', 1),
('Razer Southern Cone', '30-33990011-9', '011-4888-9999', 'elite@razer.com', 1),
('Sony Entertainment Arg', '30-44001122-9', '011-4999-0000', 'b2b@sony.com.ar', 1);

-- ============================================================================
-- 6. TABLA: Usuarios (10 Registros - Solo Roles: Administrador / Vendedor)
-- ============================================================================
INSERT INTO Usuarios (NombreUsuario, Password, Rol, Activo) VALUES
('admin_central', 'HashSecureAdmin1', 'Administrador', 1),
('sistemas_facu', 'PassDev2026!', 'Administrador', 1),
('vendedor_tomas', 'VentaTech01', 'Vendedor', 1),
('vendedora_sol', 'VentaTech02', 'Vendedor', 1),
('vendedor_lucas', 'VentaTech03', 'Vendedor', 1),
('vendedora_mora', 'VentaTech04', 'Vendedor', 1),
('vendedor_enzo', 'VentaTech05', 'Vendedor', 1),
('admin_sucursal', 'HashSecureAdmin2', 'Administrador', 1),
('vendedora_ana', 'VentaTech06', 'Vendedor', 1),
('vendedor_ian', 'VentaTech07', 'Vendedor', 1);

-- ============================================================================
-- 7. TABLA: Compras (10 Transacciones estructurales)
-- ============================================================================
INSERT INTO Compras (Fecha, IdProveedor, Total, NumeroFactura, FechaFactura) VALUES
('2026-06-20 09:30:00', 1, 1260000.00, 'A-0001-00001234', '2026-06-19'), -- Compra de Procesadores
('2026-06-20 11:00:00', 3, 2340000.00, 'A-0002-00004567', '2026-06-18'), -- Compra de Placas ASUS
('2026-06-21 14:15:00', 4, 382000.00,  'B-0001-00000089', '2026-06-20'), -- Compra de Periféricos Logitech
('2026-06-21 16:00:00', 8, 920000.00,  'A-0003-00007890', '2026-06-21'), -- Compra de SSDs
('2026-06-22 10:00:00', 7, 2240000.00, 'A-0005-00001111', '2026-06-20'), -- Compra de Monitores/Celulares
('2026-06-22 12:30:00', 9, 740000.00,  'C-0001-00002222', '2026-06-21'), -- Compra de Accesorios Razer
('2026-06-23 09:00:00', 10, 2405000.00,'A-0008-00003333', '2026-06-22'), -- Compra de PS5 y Mandos
('2026-06-23 15:45:00', 2, 680000.00,  'A-0004-00004444', '2026-06-23'), -- Compra de Notebooks Base
('2026-06-24 11:20:00', 5, 595000.00,  'A-0002-00005555', '2026-06-23'), -- Compra de Memorias/Fuentes
('2026-06-25 10:30:00', 6, 425000.00,  'B-0001-00006666', '2026-06-24'); -- Compra de Webcams

-- ============================================================================
-- 8. TABLA: Ventas (10 Facturas emitidas por Vendedores a Clientes)
-- ============================================================================
INSERT INTO Ventas (Fecha, IdCliente, IdUsuario, NumeroFactura, Total) VALUES
('2026-06-25 11:00:00', 1, 3, 'A-0001-00000001', 525000.00),
('2026-06-25 12:45:00', 2, 3, 'A-0001-00000002', 158700.00),
('2026-06-25 15:30:00', 3, 4, 'A-0001-00000003', 920400.00),
('2026-06-25 17:15:00', 4, 4, 'A-0001-00000004', 119600.00),
('2026-06-26 09:45:00', 5, 5, 'A-0001-00000005', 2127500.00),
('2026-06-26 11:15:00', 6, 5, 'A-0001-00000006', 432000.00),
('2026-06-26 13:00:00', 7, 6, 'A-0001-00000007', 120150.00),
('2026-06-26 14:30:00', 8, 6, 'A-0001-00000008', 1947000.00),
('2026-06-26 15:50:00', 9, 7, 'A-0001-00000009', 39200.00),
('2026-06-26 16:45:00', 10, 7, 'A-0001-00000010', 114750.00);

-- ============================================================================
-- 9. TABLA: DetalleCompras (Asociación N:M de Compras con Productos)
-- ============================================================================
INSERT INTO DetalleCompras (IdCompra, IdProducto, Cantidad, PrecioUnitario) VALUES
(1, 1, 3, 420000.00),  -- Compra 1: 3x Core i7
(2, 3, 3, 780000.00),  -- Compra 2: 3x Placas de video
(3, 7, 10, 38000.00),  -- Compra 3: 10x Mouse G305
(4, 11, 10, 92000.00), -- Compra 4: 10x SSD 1TB
(5, 5, 7, 320000.00),  -- Compra 5: 7x Monitores G5
(6, 9, 4, 140000.00),  -- Compra 6: 4x Auriculares BlackShark
(6, 10, 8, 22000.00),  -- Compra 6: 8x Mousepads
(7, 22, 2, 980000.00), -- Compra 7: 2x PS5 Slim
(7, 23, 5, 89000.00),  -- Compra 7: 5x Joysticks
(8, 16, 1, 680000.00), -- Compra 8: 1x Notebook Vivobook
(9, 26, 3, 125000.00), -- Compra 9: 3x Fuentes 750W
(9, 14, 1, 135000.00), -- Compra 9: 1x Ram DDR5 32GB
(10, 35, 5, 85000.00); -- Compra 10: 5x Webcams C920

-- ============================================================================
-- 10. TABLA: DetalleVentas (Asociación N:M de Ventas con Productos)
-- Nota: PrecioUnitario ya incluye la ganancia (Compra * (1 + Porcentaje/100))
-- ============================================================================
INSERT INTO DetalleVentas (IdVenta, IdProducto, Cantidad, PrecioUnitario) VALUES
(1, 1, 1, 525000.00),  -- Venta 1: Core i7 (Costo: 420k + 25% = 525k)
(2, 8, 1, 158700.00),  -- Venta 2: Teclado G Pro X
(3, 3, 1, 920400.00),  -- Venta 3: Placa RTX 4070
(4, 11, 1, 119600.00), -- Venta 4: SSD M.2 1TB
(5, 15, 1, 2127500.00),-- Venta 5: Notebook ROG Strix
(6, 5, 1, 432000.00),  -- Venta 6: Monitor G5 27"
(7, 12, 1, 120150.00), -- Venta 7: SSD Externo 1TB
(8, 24, 1, 1947000.00),-- Venta 8: Galaxy S24 Ultra
(9, 30, 4, 9800.00),   -- Venta 9: 4x Pendrives 64GB
(10, 35, 1, 114750.00);-- Venta 10: Webcam C920
GO