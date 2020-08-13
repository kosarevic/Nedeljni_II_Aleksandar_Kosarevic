--If database doesnt exist it is automatically created.
IF DB_ID('Zadatak_1') IS NULL
CREATE DATABASE Zadatak_1
GO
--Newly created database is set to be in use.
USE Zadatak_1
--All tables are reseted clean.
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblClinic')
drop table tblClinic
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblClinicAdministrator')
drop table tblClinicAdministrator
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblClinicMaintance')
drop table tblClinicMaintance

create table tblClinic
(
ClinicID int primary key IDENTITY(1,1),
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

create table tblClinicAdministrator
(
AdministratorID int primary key IDENTITY(1,1),
FirstName varchar(50),
LastName varchar(50),
RegistrationNumber varchar(50),
Gender char,
DateOfBirth date,
Citazenship varchar(50),
Username varchar(50),
Password varchar(200),
FirstLogin bit
)

create table tblClinicMaintance
(
MaintanceID int primary key IDENTITY(1,1),
FirstName varchar(50),
LastName varchar(50),
RegistrationNumber varchar(50),
Gender char,
DateOfBirth date,
Citazenship varchar(50),
Username varchar(50),
Password varchar(200),
ClinicExpansion bit,
DisabledAccess bit
)

select * from tblClinicMaintance