USE [master]
GO
/****** Object:  Database [SICOVE1]    Script Date: 23/6/2020 00:59:54 ******/
CREATE DATABASE [SICOVE1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SICOVE1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SICOVE1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SICOVE1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SICOVE1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SICOVE1] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SICOVE1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SICOVE1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SICOVE1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SICOVE1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SICOVE1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SICOVE1] SET ARITHABORT OFF 
GO
ALTER DATABASE [SICOVE1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SICOVE1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SICOVE1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SICOVE1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SICOVE1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SICOVE1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SICOVE1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SICOVE1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SICOVE1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SICOVE1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SICOVE1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SICOVE1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SICOVE1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SICOVE1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SICOVE1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SICOVE1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SICOVE1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SICOVE1] SET RECOVERY FULL 
GO
ALTER DATABASE [SICOVE1] SET  MULTI_USER 
GO
ALTER DATABASE [SICOVE1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SICOVE1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SICOVE1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SICOVE1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SICOVE1] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SICOVE1', N'ON'
GO
ALTER DATABASE [SICOVE1] SET QUERY_STORE = OFF
GO
USE [SICOVE1]
GO
/****** Object:  Table [dbo].[tb_Categorias]    Script Date: 23/6/2020 00:59:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Categorias](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[FechaRegistro] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Clientes]    Script Date: 23/6/2020 00:59:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Direccion] [varchar](50) NOT NULL,
	[Celular] [varchar](20) NOT NULL,
	[DUI] [varchar](20) NOT NULL,
	[FechaRegistro] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Compras]    Script Date: 23/6/2020 00:59:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Compras](
	[IdCompra] [int] IDENTITY(1,1) NOT NULL,
	[IdProveedor] [int] NULL,
	[IdFormaPago] [int] NULL,
	[IdEmpleado] [int] NULL,
	[NumFac] [int] NOT NULL,
	[DetalleCompra] [varchar](100) NULL,
	[TotalCompra] [decimal](18, 5) NOT NULL,
	[FechaRegistro] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_DetalleCompras]    Script Date: 23/6/2020 00:59:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_DetalleCompras](
	[IdDetalleCompra] [int] IDENTITY(1,1) NOT NULL,
	[IdCompra] [int] NULL,
	[IdProducto] [int] NULL,
	[IdCategoria] [int] NULL,
	[PrecioCompra] [decimal](18, 5) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[SubTotal] [decimal](18, 5) NULL,
	[IVA] [decimal](18, 5) NULL,
	[Total] [decimal](18, 5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_DetalleVentas]    Script Date: 23/6/2020 00:59:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_DetalleVentas](
	[IdDetalleVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NULL,
	[IdProducto] [int] NULL,
	[IdCategoria] [int] NULL,
	[PrecioVenta] [decimal](18, 5) NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [decimal](18, 5) NOT NULL,
	[SubTotal] [decimal](18, 5) NOT NULL,
	[Descuento] [decimal](18, 5) NULL,
	[IVA] [decimal](18, 5) NULL,
	[Total] [decimal](18, 5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Empleados]    Script Date: 23/6/2020 00:59:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Empleados](
	[IdEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Direccion] [varchar](50) NOT NULL,
	[Celular] [varchar](20) NOT NULL,
	[DUI] [varchar](20) NOT NULL,
	[FechaRegistro] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_FormaPago]    Script Date: 23/6/2020 00:59:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_FormaPago](
	[IdFormaPago] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[FechaRegistro] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFormaPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Inventarios]    Script Date: 23/6/2020 00:59:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Inventarios](
	[IdInventario] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NULL,
	[Existencia] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdInventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Productos]    Script Date: 23/6/2020 00:59:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Productos](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Detalle] [varchar](50) NULL,
	[FechaRegistro] [date] NOT NULL,
	[IdCategoria] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Proveedores]    Script Date: 23/6/2020 00:59:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Proveedores](
	[IdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Direccion] [varchar](50) NOT NULL,
	[Celular] [varchar](20) NOT NULL,
	[DUI] [varchar](20) NOT NULL,
	[FechaRegistro] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Roles]    Script Date: 23/6/2020 00:59:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Roles](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[FechaRegistro] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Usuarios]    Script Date: 23/6/2020 00:59:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Clave] [varchar](50) NOT NULL,
	[FechaRegistro] [date] NOT NULL,
	[IdRol] [int] NULL,
	[IdEmpleado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Ventas]    Script Date: 23/6/2020 00:59:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Ventas](
	[IdVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdFormaPago] [int] NULL,
	[IdCliente] [int] NULL,
	[IdEmpleado] [int] NULL,
	[NumFac] [int] NOT NULL,
	[Detalle] [varchar](100) NULL,
	[TotalVenta] [decimal](18, 5) NOT NULL,
	[FechaRegistro] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tb_Compras]  WITH CHECK ADD FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[tb_Empleados] ([IdEmpleado])
GO
ALTER TABLE [dbo].[tb_Compras]  WITH CHECK ADD FOREIGN KEY([IdFormaPago])
REFERENCES [dbo].[tb_FormaPago] ([IdFormaPago])
GO
ALTER TABLE [dbo].[tb_Compras]  WITH CHECK ADD FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[tb_Proveedores] ([IdProveedor])
GO
ALTER TABLE [dbo].[tb_DetalleCompras]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[tb_Categorias] ([IdCategoria])
GO
ALTER TABLE [dbo].[tb_DetalleCompras]  WITH CHECK ADD FOREIGN KEY([IdCompra])
REFERENCES [dbo].[tb_Compras] ([IdCompra])
GO
ALTER TABLE [dbo].[tb_DetalleCompras]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[tb_Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[tb_DetalleVentas]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[tb_Categorias] ([IdCategoria])
GO
ALTER TABLE [dbo].[tb_DetalleVentas]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[tb_Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[tb_DetalleVentas]  WITH CHECK ADD FOREIGN KEY([IdVenta])
REFERENCES [dbo].[tb_Ventas] ([IdVenta])
GO
ALTER TABLE [dbo].[tb_Inventarios]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[tb_Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[tb_Productos]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[tb_Categorias] ([IdCategoria])
GO
ALTER TABLE [dbo].[tb_Usuarios]  WITH CHECK ADD FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[tb_Empleados] ([IdEmpleado])
GO
ALTER TABLE [dbo].[tb_Usuarios]  WITH CHECK ADD FOREIGN KEY([IdRol])
REFERENCES [dbo].[tb_Roles] ([IdRol])
GO
ALTER TABLE [dbo].[tb_Ventas]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[tb_Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[tb_Ventas]  WITH CHECK ADD FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[tb_Empleados] ([IdEmpleado])
GO
ALTER TABLE [dbo].[tb_Ventas]  WITH CHECK ADD FOREIGN KEY([IdFormaPago])
REFERENCES [dbo].[tb_FormaPago] ([IdFormaPago])
GO
USE [master]
GO
ALTER DATABASE [SICOVE1] SET  READ_WRITE 
GO
