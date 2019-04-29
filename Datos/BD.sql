/*
drop table VentaDetalle
drop table Venta
drop table IngresoDetalle
drop table Ingreso
drop table Usuario
drop table Persona
drop table Articulo
drop table Marca
drop table Categoria
*/
create table Categoria(
	Id INT Primary key identity(1,1),
	Nombre varchar(200) not null
)
create table Marca(
	Id INT Primary key identity(1,1),
	Nombre varchar(200) not null
)
create table Articulo(
	Id INT Primary key identity(1,1),
	CategoriaId INT references Categoria(Id) not null,
	MarcaId INT references Marca(Id) not null,
	Codigo varchar(50),
	Nombre varchar(256) not null,
	Costo decimal(10,2) default(0) not null,
	Venta decimal(10,2) default(0) not null,
	Stock int default(0) not null,
	StockMin int default(0) not null,
	Activo Bit default(1) not null,
)
create table Persona(
	Id INT Primary key identity(1,1),
	Apellidos VARCHAR(100),
	Nombres VARCHAR(100),
	NombreCompleto varchar(200) not null,
	TipoDocumento CHAR(3) not null,
	NumDocumento VARCHAR(11) not null,
	Celular VARCHAR(20),
	Correo VARCHAR(50),
	Direccion VARCHAR(256),
	IndCliente BIT default(0) not null,
	IndProveedor BIT default(0) not null
)
create table Usuario(
	Id INT Primary key identity(1,1),
	Nombre VARCHAR(50),
	Clave VARCHAR(50),
	Activo BIT default(1) not null
)
create table Venta(
	Id INT Primary key identity(1,1),
	ClienteId INT references Persona(Id),
	UsuarioId INT references Usuario(Id),
	Tipo CHAR(1), 
	Serie VARCHAR(7),
	Numero VARCHAR(10),
	Fecha DateTime NOT NULL,
	Total Decimal(10,2) default(0) not null,
	Estado CHAR(1) not null
)
create table VentaDetalle(
	Id INT Primary key identity(1,1),
	VentaId INT references Venta(Id) not null,
	ArticuloId INT references Articulo(Id) not null,	
	Cantidad INT default(0) not null,
	Precio decimal(10,2) default(0) not null,
	Descuento decimal(10,2) default(0) not null,
	Importe decimal(10,2) default(0) not null
)
create table Ingreso(
	Id INT Primary key identity(1,1),
	ProveedorId INT references Persona(Id),
	UsuarioId INT references Usuario(Id),
	Tipo CHAR(1), 
	Serie VARCHAR(7),
	Numero VARCHAR(10),
	Fecha DateTime NOT NULL,
	Total Decimal(10,2) default(0) not null,
	Estado CHAR(1) not null
)
create table IngresoDetalle(
	Id INT Primary key identity(1,1),
	IngresoId INT references Ingreso(Id) not null,
	ArticuloId INT references Articulo(Id) not null,	
	Cantidad INT default(0) not null,
	Precio decimal(10,2) default(0) not null,
	Descuento decimal(10,2) default(0) not null,
	Importe decimal(10,2) default(0) not null
)