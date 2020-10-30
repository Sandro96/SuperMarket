--create database ScriptFacturacion

use ScriptFacturacion

create table Cliente(
Ci int primary key not null,
Nombre varchar (50) not null,
Domicilio varchar (50) not null,
[Fecha Nacimiento] datetime not null,
Habilitado bit not null,
)

create table Producto(
Nombre varchar (50) not null,
Marca varchar (50) not null,
Identificador int primary key not null,
Precio decimal not null,
Habilitado bit not null,
)

create table Usuario(
Usuario varchar (50) primary key not null,
Contrasena varchar (50) not null,
Administrador bit not null,
)

create table Factura(
Fecha datetime not null,
Numero int primary key identity (1,1) not null,
[Numero Cliente] int not null,
foreign key([Numero Cliente]) references Cliente(Ci),
Usuario varchar(50) not null,
foreign key(Usuario) references Usuario(Usuario),
Total decimal not null,
)

create table DetallesFactura(
Id int primary key identity (1,1) not null,

Cantidad int not null,

Identificador int not null,

foreign key(Identificador) references Producto(Identificador),

Factura int not null,
foreign key(Factura) references Factura(Numero),
)

insert into Cliente values(12345672,'Osvaldo Oborno','Calle Sabatica 666',1978/12/3,1)
insert into Cliente values(11111111,'Leonor Mataseñor','Camino Motorizado 4000',1975/12/24,1)
insert into Cliente values(22222222,'Roberto Medioford ','Callejuda 1515',1981/08/25,1)
insert into Cliente values(23333335,'David Muchone','Camino Paz 4545',1991/09/13,1) 
insert into Cliente values(22333334,'Javier Campo','Camino Metal 8484',1993/08/03,1)
insert into Cliente values(22233332,'Esteban Maravilla','Bella Vista 1416',1980/05/13,1)
insert into Cliente values(22223339,'Curtis Corbena','Calle Sonrisas 3213',1997/02/20,0)
insert into Cliente values(22222335,'Bili Puerta','Calle Micro 2313',1985/10/28,1)
insert into Cliente values(22222238,'Esteban Trabajos','Calle manzana 4213',1985/02/24,0)

insert into Usuario values('SuperAdmin','contraseña',1)
insert into Usuario values('Empleado','1234',0)

insert into Producto values('Cuchillo','Tramontino',67890,150.00,1)
insert into Producto values('Termo','Smanley',44321,400,1)
insert into Producto values('Desodorante','Roxana',94123,50,1)
insert into Producto values('Cafe','Maradona',49287,29.00,1)
insert into Producto values('Cigarros','Manzana roja',99999,125.00,0)

insert into Factura values(2017/10/20,11111111,'SuperAdmin',150.00)
insert into Factura values(2017/10/22,22223339,'SuperAdmin',100.00)
insert into Factura values(2017/09/15,22222222,'Empleado',58.00)
insert into Factura values(2017/09/01,12345672,'Empleado',250.00)

insert into DetallesFactura values(1,67890,1)
insert into DetallesFactura values(2,94123,2)
insert into DetallesFactura values(2,49287,3)
insert into DetallesFactura values(2,99999,4)
