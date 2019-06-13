USE master
IF EXISTS(select * from sys.databases where name='Sommerland')
DROP DATABASE Sommerland
CREATE DATABASE Sommerland
GO

USE Sommerland

GO
CREATE TABLE RideCategories (
	RideCategoryId INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	Description NVARCHAR(MAX) NOT NULL
	);
GO
CREATE TABLE Rides (
	RideId INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	Description NVARCHAR(MAX) NOT NULL,
	CategoryId INT NOT NULL FOREIGN KEY REFERENCES RideCategories(RideCategoryId)
	);
GO
CREATE TABLE Reports (
	ReportId INT NOT NULL PRIMARY KEY,
	Status INT NOT NULL,
	ReportTime DATE NOT NULL,
	Notes NVARCHAR(MAX) NOT NULL,
	RideId INT NOT NULL FOREIGN KEY REFERENCES Rides(RideId)
	);
GO
