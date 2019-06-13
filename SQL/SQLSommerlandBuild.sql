USE master
IF EXISTS(select * from sys.databases where name='Sommerland')
DROP DATABASE Sommerland
CREATE DATABASE Sommerland
GO

USE Sommerland

GO
CREATE TABLE Reports (
	ReportId INT NOT NULL PRIMARY KEY,
	Status INT NOT NULL,
	ReportTime DATE NOT NULL,
	Notes NVARCHAR(MAX) NOT NULL,
	RideId INT NOT NULL
	);
GO
CREATE TABLE Rides (
	RideId INT NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES Reports(RideId),
	Name NVARCHAR(50) NOT NULL,
	Description NVARCHAR(MAX) NOT NULL,
	CategoryId INT NOT NULL,
	);
GO
CREATE TABLE RideCategories (
	RideCategoryId INT NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES Rides(CategoryId),
	Name NVARCHAR(50) NOT NULL,
	Description NVARCHAR(MAX) NOT NULL
	);
GO