use master;
go
--Elimina siempre la Base de Datos y la vuelve a crear
drop  database SICOVE1; 
Set nocount on
--creando base de datos
create database SICOVE1;
go
use SICOVE1;
go
--creando las tablas 
go
create table tb_Clientes(
	IdCliente int identity(1,1) primary key not null,
	Nombre varchar(50) not null,
	Direccion varchar(50) not null,
	Celular varchar(20) not null,
	DUI varchar(20) not null,
	FechaRegistro date not null
);
go
create table tb_Roles(
	IdRol int identity(1,1) primary key not null,
	Nombre varchar(50) not null,
	FechaRegistro date not null
);
go
create table tb_FormaPago(
	IdFormaPago int identity(1,1) primary key not null,
	Nombre varchar(30) not null,
	FechaRegistro date not null
);
go
create table tb_Empleados(
	IdEmpleado int identity(1,1) primary key not null,
	Nombre varchar(50) not null,
	Direccion varchar(50) not null,
	Celular varchar(20) not null,
	DUI varchar(20) not null,
	FechaRegistro date not null
);
go
create table tb_Usuarios
(
	IdUsuario int identity(1,1) primary key not null,
	Usuario varchar(50) not null,
	Clave varchar(50) not null,
	FechaRegistro date not null,
	IdRol int references tb_Roles,
	IdEmpleado int references tb_Empleados
);

go
create table tb_Proveedores(
	IdProveedor int identity(1,1) primary key not null,
	Nombre varchar(50) not null,
	Direccion varchar(50) not null,
	Celular varchar(20) not null,
	DUI varchar(20) not null,
	FechaRegistro date not null
);
go
create table tb_Categorias(
	IdCategoria int identity(1,1) primary key not null,
	Nombre varchar(50) not null,
	FechaRegistro date not null
);
go
create table tb_Productos(
	IdProducto int identity(1,1) primary key not null,
	Nombre varchar(50) not null,
	Detalle varchar(100),
	FechaRegistro date not null,
	IdCategoria int references tb_Categorias
);
go
create table tb_Compras(
	IdCompra int  primary key identity(1,1) not null,
	IdProveedor int references tb_Proveedores,
	IdFormaPago int references tb_FormaPago,
	IdEmpleado int references tb_Empleados,
	NumFac int not null,	
	DetalleCompra varchar(100),
	TotalCompra decimal(18,5) not null,
	FechaRegistro date not null
);
go
create table tb_DetalleCompras(
	IdDetalleCompra int identity(1,1) primary key not null,
	IdCompra int references tb_Compras,
	IdProducto int references tb_Productos,
	IdCategoria int references tb_Categorias,
	PrecioCompra decimal(18,5) not null,
	Cantidad int not null,
	SubTotal decimal(18,5),
	IVA decimal(18,5),
	Total decimal(18,5) not null
);
go
create table tb_Ventas
(
	IdVenta int identity(1,1) primary key not null,
	IdFormaPago int references tb_FormaPago,
	IdCliente int references tb_Clientes,
	IdEmpleado int references tb_Empleados,
	NumFac int not null,	
	Detalle varchar(100),
	TotalVenta decimal(18,5) not null,
	FechaRegistro date not null,
);
go
create table tb_DetalleVentas(
	IdDetalleVenta int identity(1,1) primary key not null,
	IdVenta int references tb_Ventas,
	IdProducto int references tb_Productos,
	IdCategoria int references tb_Categorias,
	PrecioVenta decimal(18,5),
	Cantidad int not null,
	Precio decimal(18,5) not null,
	SubTotal decimal(18,5) not null,
	Descuento decimal(18,5),
	IVA decimal(18,5),
	Total decimal(18,5) not null
);
go
create table tb_Inventarios
(
	IdInventario int identity(1,1) primary key not null,
	IdProducto int references tb_Productos,
	Existencia int not null
);

go

--Insertando Clientes 
insert into tb_Clientes(Nombre, Direccion, Celular, DUI, FechaRegistro) 
	values ('Beto Calderon', 'Agua Caliente', '7363623653', '323232432', getdate());
	select * from tb_Clientes
go

--Insertando Proveedores 
insert into tb_Proveedores(Nombre, Direccion, Celular, DUI, FechaRegistro) 
	values ('Beto Calderon', 'Agua Caliente', '7363623653', '323232432', getdate());

go

--Insertando Empleados 
insert into tb_Empleados(Nombre, Direccion, Celular, DUI, FechaRegistro) 
	values ('Beto Calderon', 'Agua Caliente', '7363623653', '323232432', getdate());

go

--Insertando Roles 
insert into tb_Roles(Nombre, FechaRegistro) 
	values ('Admin', getdate());

go

--Insertando Formas de pagos  
insert into tb_FormaPago(Nombre, FechaRegistro) 
	values ('Contado', getdate());

go
--Insertando Usuarios 
insert into tb_Usuarios(Usuario, Clave, FechaRegistro, IdRol, IdEmpleado) 
	values ('Beto', '123', getdate(), '1', '1' );

go

--Insertando categorias   
insert into tb_Categorias(Nombre, FechaRegistro) 
	values ('Poliester', getdate());

go

--Insertando productos  
insert into tb_Productos(Nombre, Detalle, FechaRegistro, IdCategoria) 
	values ('Camisas', 'cual quier cosa', getdate(), 1);

--Notas----------------------
-- tener un frm para el reg de c/u de las cat por separado y asi controlar mejor el registro de c/u  de los prod