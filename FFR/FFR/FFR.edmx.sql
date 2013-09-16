
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 09/15/2013 22:16:42
-- Generated from EDMX file: C:\Users\NOLSEN\Source\Repos\MSSE680_Week3\FFR\FFR\FFR.edmx
-- --------------------------------------------------

IF OBJECT_ID(N'FFR', N'U') IS NULL CREATE DATABASE FFR;

SET QUOTED_IDENTIFIER OFF;
GO
USE [FFR];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SalesHeader_Customer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesHeaders] DROP CONSTRAINT [FK_SalesHeader_Customer];
GO
IF OBJECT_ID(N'[dbo].[FK_SalesItems_Items]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesItems] DROP CONSTRAINT [FK_SalesItems_Items];
GO
IF OBJECT_ID(N'[dbo].[FK_SalesItems_SalesHeaders]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesItems] DROP CONSTRAINT [FK_SalesItems_SalesHeaders];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[Items]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Items];
GO
IF OBJECT_ID(N'[dbo].[SalesHeaders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SalesHeaders];
GO
IF OBJECT_ID(N'[dbo].[SalesItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SalesItems];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [CustomerId] int  NOT NULL,
    [FirstName] varchar(50)  NULL,
    [LastName] varchar(50)  NULL,
    [Address] varchar(200)  NULL,
    [City] varchar(50)  NULL,
    [State] varchar(2)  NULL,
    [Zip] varchar(10)  NULL,
    [Suite] varchar(20)  NULL,
    [Phone] varchar(20)  NULL,
    [Email] varchar(100)  NULL
);
GO

-- Creating table 'SalesHeaders'
CREATE TABLE [dbo].[SalesHeaders] (
    [SalesId] int  NOT NULL,
    [CustomerId] int  NULL,
    [OrderSalesBalance] decimal(10,0)  NULL,
    [OrderTaxAmount] decimal(10,0)  NULL,
    [OrderTotal] decimal(10,0)  NULL,
    [SalesStatus] varchar(30)  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [EmployeeId] int  NOT NULL,
    [EmployeeFirstName] varchar(50)  NULL,
    [EmployeeLastName] varchar(50)  NULL,
    [EmployeePhone] varchar(20)  NULL,
    [Employeetype] varchar(10)  NULL
);
GO

-- Creating table 'Items'
CREATE TABLE [dbo].[Items] (
    [ItemId] int  NOT NULL,
    [ItemName] varchar(50)  NULL,
    [QuantityAvailable] int  NULL,
    [ItemCost] decimal(18,0)  NULL,
    [Price] decimal(18,0)  NULL
);
GO

-- Creating table 'SalesItems'
CREATE TABLE [dbo].[SalesItems] (
    [SalesId] int  NOT NULL,
    [ItemId] int  NOT NULL,
    [Qty] int  NULL,
    [Price] decimal(19,4)  NULL,
    [LineAmount] decimal(19,4)  NULL,
    [ItemName] varchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CustomerId] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([CustomerId] ASC);
GO

-- Creating primary key on [SalesId] in table 'SalesHeaders'
ALTER TABLE [dbo].[SalesHeaders]
ADD CONSTRAINT [PK_SalesHeaders]
    PRIMARY KEY CLUSTERED ([SalesId] ASC);
GO

-- Creating primary key on [EmployeeId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([EmployeeId] ASC);
GO

-- Creating primary key on [ItemId] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [PK_Items]
    PRIMARY KEY CLUSTERED ([ItemId] ASC);
GO

-- Creating primary key on [SalesId] in table 'SalesItems'
ALTER TABLE [dbo].[SalesItems]
ADD CONSTRAINT [PK_SalesItems]
    PRIMARY KEY CLUSTERED ([SalesId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerId] in table 'SalesHeaders'
ALTER TABLE [dbo].[SalesHeaders]
ADD CONSTRAINT [FK_SalesHeader_Customer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([CustomerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SalesHeader_Customer'
CREATE INDEX [IX_FK_SalesHeader_Customer]
ON [dbo].[SalesHeaders]
    ([CustomerId]);
GO

-- Creating foreign key on [ItemId] in table 'SalesItems'
ALTER TABLE [dbo].[SalesItems]
ADD CONSTRAINT [FK_SalesItems_Items]
    FOREIGN KEY ([ItemId])
    REFERENCES [dbo].[Items]
        ([ItemId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SalesItems_Items'
CREATE INDEX [IX_FK_SalesItems_Items]
ON [dbo].[SalesItems]
    ([ItemId]);
GO

-- Creating foreign key on [SalesId] in table 'SalesItems'
ALTER TABLE [dbo].[SalesItems]
ADD CONSTRAINT [FK_SalesItems_SalesHeaders]
    FOREIGN KEY ([SalesId])
    REFERENCES [dbo].[SalesHeaders]
        ([SalesId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------