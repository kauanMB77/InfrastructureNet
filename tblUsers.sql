CREATE DATABASE InfraStags;

use InfraStags

Go
create table Users(
id int NOT NULL PRIMARY KEY,
usuario varchar(30) NOT NULL,
senha varchar(30) NOT NULL,
isAdm bit,
isMaster bit)

Go
create procedure spConsultaLogin
(
@usuario varchar(max)
)
as
begin
	select * from Users
	where usuario = @usuario
end

Go
create procedure spInsert_Users
(
@id int,
@usuario varchar(max),
@senha varchar(max)
)
as
begin
	insert into Users
	(id, usuario, senha, isAdm, isMaster)
	values
	(@id, @usuario, @senha, 0, 0)
end

Go
create procedure spConcedeAdm
(
@usuario varchar(max)
)
as
begin
update Users
set isAdm = 1
where usuario = @usuario;
end

Go
create procedure spRetiraAdm
(
@usuario varchar(max)
)
as
begin
update Users
set isAdm = 0
where usuario = @usuario;
end