
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/14/2015 17:41:33
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

IF OBJECT_ID(N'[dbo].[FK_RiskAssessmentAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Addresses] DROP CONSTRAINT [FK_RiskAssessmentAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskAssessmentRiskAssessmentQuestion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Risks] DROP CONSTRAINT [FK_RiskAssessmentRiskAssessmentQuestion];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionRiskAssessmentQuestion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Risks] DROP CONSTRAINT [FK_QuestionRiskAssessmentQuestion];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Addresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Addresses];
GO
IF OBJECT_ID(N'[dbo].[RiskAssessments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RiskAssessments];
GO
IF OBJECT_ID(N'[dbo].[Risks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Risks];
GO
IF OBJECT_ID(N'[dbo].[Questions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Questions];
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
    [SupplyName] nvarchar(max)  NULL,
    [DateCreated] datetime  NOT NULL
);
GO

-- Creating table 'Risks'
CREATE TABLE [dbo].[Risks] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RiskAssessmentID] int  NOT NULL,
    [QuestionID] int  NOT NULL,
    [Likelihood] nvarchar(max)  NOT NULL,
    [Response] int  NOT NULL
);
GO

-- Creating table 'Questions'
CREATE TABLE [dbo].[Questions] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [IsHazard] bit  NOT NULL,
    [Severity] int  NOT NULL,
    [RiskNumber] nvarchar(max)  NOT NULL
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

-- Creating primary key on [ID] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [PK_Risks]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [PK_Questions]
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

-- Creating foreign key on [RiskAssessmentID] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [FK_RiskAssessmentRiskAssessmentQuestion]
    FOREIGN KEY ([RiskAssessmentID])
    REFERENCES [dbo].[RiskAssessments]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskAssessmentRiskAssessmentQuestion'
CREATE INDEX [IX_FK_RiskAssessmentRiskAssessmentQuestion]
ON [dbo].[Risks]
    ([RiskAssessmentID]);
GO

-- Creating foreign key on [QuestionID] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [FK_QuestionRiskAssessmentQuestion]
    FOREIGN KEY ([QuestionID])
    REFERENCES [dbo].[Questions]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QuestionRiskAssessmentQuestion'
CREATE INDEX [IX_FK_QuestionRiskAssessmentQuestion]
ON [dbo].[Risks]
    ([QuestionID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------