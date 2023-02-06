CREATE DATABASE InfraStags;

use InfraStags

Go
create table Users(
id int NOT NULL PRIMARY KEY,
usuario varchar(30) NOT NULL,
senha varchar(30) NOT NULL,
isAdm bit,
isMaster bit)
