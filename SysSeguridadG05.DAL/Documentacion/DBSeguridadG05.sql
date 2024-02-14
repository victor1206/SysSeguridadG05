Create database DBSeguridadG05
go
Use DBSeguridadG05
go

Create Table Rol
(
 Id int not null primary key identity(1,1),
 Nombre varchar(20) not null
)

Create Table Usuario
(
 [Id] int not null primary key identity(1,1),
 [IdRol] int not null,
 [Nombre] varchar(100) not null,
 [Apellido] varchar(100) not null,
 [Login] varchar(100) not null,
 [Password] varchar(37) not null,
 [Estatus] tinyint not null,
 [FechaRegistro] datetime not null,
 foreign key (IdRol) references Rol(Id)
)