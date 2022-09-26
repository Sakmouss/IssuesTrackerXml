
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/28/2022 17:46:56
-- Generated from EDMX file: C:\Users\WORD\source\repos\IssuesTracker\IssuesTracker\data\tkrdata.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TrackerDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DBprojectDBissue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DBissues] DROP CONSTRAINT [FK_DBprojectDBissue];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[DBissues]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DBissues];
GO
IF OBJECT_ID(N'[dbo].[DBprojects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DBprojects];
GO
IF OBJECT_ID(N'[dbo].[DBusers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DBusers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DBissues'
CREATE TABLE [dbo].[DBissues] (
    [issueId] int IDENTITY(1,1) NOT NULL,
    [issueSumup] nvarchar(max)  NULL,
    [issueDescription] nvarchar(max)  NULL,
    [identifiedDate] datetime  NULL,
    [relatedProjectId] int  NOT NULL,
    [assignedPerson] nvarchar(max)  NULL,
    [resolutionTargetDate] datetime  NULL,
    [issueProgression] nvarchar(max)  NULL,
    [actualResolutionDate] datetime  NULL,
    [resolutionSumup] nvarchar(max)  NULL
);
GO

-- Creating table 'DBprojects'
CREATE TABLE [dbo].[DBprojects] (
    [IdprojectId] int IDENTITY(1,1) NOT NULL,
    [projectName] nvarchar(255)  NOT NULL,
    [startDate] datetime  NULL,
    [targetEndDate] datetime  NULL,
    [actualEndDate] datetime  NULL,
    [createdDate] datetime  NULL
);
GO

-- Creating table 'DBusers'
CREATE TABLE [dbo].[DBusers] (
    [userId] int IDENTITY(1,1) NOT NULL,
    [personName] nvarchar(255)  NOT NULL,
    [personEmail] nvarchar(255)  NULL,
    [personRole] nvarchar(20)  NULL,
    [userName] nvarchar(30)  NULL,
    [assignedProject] nvarchar(255)  NULL,
    [registeredDate] datetime  NULL,
    [personPhoto] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [issueId] in table 'DBissues'
ALTER TABLE [dbo].[DBissues]
ADD CONSTRAINT [PK_DBissues]
    PRIMARY KEY CLUSTERED ([issueId] ASC);
GO

-- Creating primary key on [IdprojectId] in table 'DBprojects'
ALTER TABLE [dbo].[DBprojects]
ADD CONSTRAINT [PK_DBprojects]
    PRIMARY KEY CLUSTERED ([IdprojectId] ASC);
GO

-- Creating primary key on [userId] in table 'DBusers'
ALTER TABLE [dbo].[DBusers]
ADD CONSTRAINT [PK_DBusers]
    PRIMARY KEY CLUSTERED ([userId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [relatedProjectId] in table 'DBissues'
ALTER TABLE [dbo].[DBissues]
ADD CONSTRAINT [FK_DBprojectDBissue]
    FOREIGN KEY ([relatedProjectId])
    REFERENCES [dbo].[DBprojects]
        ([IdprojectId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DBprojectDBissue'
CREATE INDEX [IX_FK_DBprojectDBissue]
ON [dbo].[DBissues]
    ([relatedProjectId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------