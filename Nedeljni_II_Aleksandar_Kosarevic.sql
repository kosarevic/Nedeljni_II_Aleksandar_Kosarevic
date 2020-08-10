--If database doesnt exist it is automatically created.
IF DB_ID('Zadatak_1') IS NULL
CREATE DATABASE Zadatak_1
GO
--Newly created database is set to be in use.
USE Zadatak_1
--All tables are reseted clean.
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblMedicalInstitute')
drop table tblMedicalInstitute

create table tblMedicalInstitute
(
InstituteID int primary key IDENTITY(1,1),
Title varchar(50),
ConstructionDate Date,
Owner varchar(50),
Adress varchar(50),
Floors int,
Rooms int,
Balcony bit,
BackYard bit,
AmbulanceAccess int,
DisabledAccess int
)