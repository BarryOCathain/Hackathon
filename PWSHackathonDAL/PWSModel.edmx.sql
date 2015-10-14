
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/14/2015 14:17:51
-- Generated from EDMX file: C:\TortoiseGit\Hackathon\PWSHackathonDAL\PWSModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PWS_Database];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Addresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Addresses];
GO
IF OBJECT_ID(N'[dbo].[RiskAssessments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RiskAssessments];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [ID] int  NOT NULL,
    [Name] nvarchar(max)  NULL,
    [AddressLine1] nvarchar(max)  NULL,
    [AddressLine2] nvarchar(max)  NULL,
    [AddressLine3] nvarchar(max)  NULL,
    [AddressLine4] nvarchar(max)  NULL,
    [Postcode] nvarchar(max)  NULL,
    [Telephone] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL,
    [RiskAssessmentID] int  NOT NULL
);
GO

-- Creating table 'RiskAssessments'
CREATE TABLE [dbo].[RiskAssessments] (
    [ID] int  NOT NULL,
    [LocalAuthority] nvarchar(max)  NULL,
    [SupplyReference] nvarchar(max)  NULL,
    [SupplyName] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'RiskAssessments'
ALTER TABLE [dbo].[RiskAssessments]
ADD CONSTRAINT [PK_RiskAssessments]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RiskAssessmentID] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [FK_RiskAssessmentAddress]
    FOREIGN KEY ([RiskAssessmentID])
    REFERENCES [dbo].[RiskAssessments]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskAssessmentAddress'
CREATE INDEX [IX_FK_RiskAssessmentAddress]
ON [dbo].[Addresses]
    ([RiskAssessmentID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------