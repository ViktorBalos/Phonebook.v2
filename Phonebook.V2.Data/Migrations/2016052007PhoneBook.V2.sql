IF  NOT EXISTS (SELECT name FROM sys.databases WHERE name ='PhoneBook.V2')
CREATE DATABASE [PhoneBook.V2]

USE [PhoneBook.V2]


IF NOT EXISTS (SELECT name FROM sys.tables WHERE name = 'Country')
CREATE TABLE[dbo].[Country](
[ID] int NOT NULL IDENTITY (1000,1),
[CountryName] nvarchar (50) NOT NULL,
CONSTRAINT [Country_pk] PRIMARY KEY ([ID])
)

IF NOT EXISTS (SELECT name FROM sys.tables WHERE name = 'City')
CREATE TABLE [dbo].[City](
[ID] int NOT NULL IDENTITY (1000,1),
[CityName] nvarchar (50) NOT NULL,
[CountryID] int NOT NULL,
CONSTRAINT [City_pk] PRIMARY KEY ([ID]),
CONSTRAINT [City_fk] FOREIGN KEY ([CountryID]) REFERENCES Country (ID)
)

IF NOT EXISTS (SELECT name FROM sys.tables WHERE name = 'Street')
CREATE TABLE [dbo].[Street](
[ID] int NOT NULL IDENTITY (1000,1),
[StreetName] nvarchar (50) NOT NULL,
[CityID] int NOT NULL,
CONSTRAINT [Street_pk] PRIMARY KEY ([ID]),
CONSTRAINT [Street_fk] FOREIGN KEY ([CityID]) REFERENCES City (ID)
)

IF NOT EXISTS (SELECT name FROM sys.tables WHERE name = 'Contact')
CREATE TABLE[dbo].[Contact](
[ID] int NOT NULL IDENTITY (1000,1),
[FirstName] nvarchar (20) NOT NULL,
[LastName] nvarchar (20) NOT NULL,
[StreetID] int  NOT NULL,
[HouseNumber] nvarchar (20) NOT NULL,
[PhoneNumber] nvarchar (20) NOT NULL,
[Email] nvarchar (50),
[CreatedOn] datetime,
[CreatedBy] nvarchar(25),
[UpdatedOn] datetime,
[UpdateBy] nvarchar(25),
CONSTRAINT [Contact_pk] PRIMARY KEY ([ID]),
CONSTRAINT [Contact_fk] FOREIGN KEY ([StreetID]) REFERENCES Street(ID)
)
