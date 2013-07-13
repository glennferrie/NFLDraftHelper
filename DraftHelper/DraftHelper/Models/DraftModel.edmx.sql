
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/13/2013 10:04:11
-- Generated from EDMX file: C:\git\NFLDraftHelper\DraftHelper\DraftHelper\Models\DraftModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DraftHelper];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_NFLTeamNFLPlayer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NFLPlayers] DROP CONSTRAINT [FK_NFLTeamNFLPlayer];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[NFLPlayers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NFLPlayers];
GO
IF OBJECT_ID(N'[dbo].[NFLTeams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NFLTeams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'NFLPlayers'
CREATE TABLE [dbo].[NFLPlayers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Position] nvarchar(max)  NOT NULL,
    [ESPNRank] int  NOT NULL,
    [MyRank] int  NOT NULL,
    [DepthChart] int  NOT NULL,
    [NFLTeam_Id] int  NOT NULL,
    [DraftPick_Id] int  NULL
);
GO

-- Creating table 'NFLTeams'
CREATE TABLE [dbo].[NFLTeams] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Locale] nvarchar(max)  NOT NULL,
    [Abbrev] nvarchar(max)  NOT NULL,
    [Conference] nvarchar(max)  NOT NULL,
    [Division] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TeamOwners'
CREATE TABLE [dbo].[TeamOwners] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TeamName] nvarchar(max)  NOT NULL,
    [DraftOrder] int  NULL
);
GO

-- Creating table 'DraftPicks'
CREATE TABLE [dbo].[DraftPicks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PickNumber] int  NOT NULL,
    [TeamOwner_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'NFLPlayers'
ALTER TABLE [dbo].[NFLPlayers]
ADD CONSTRAINT [PK_NFLPlayers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NFLTeams'
ALTER TABLE [dbo].[NFLTeams]
ADD CONSTRAINT [PK_NFLTeams]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TeamOwners'
ALTER TABLE [dbo].[TeamOwners]
ADD CONSTRAINT [PK_TeamOwners]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DraftPicks'
ALTER TABLE [dbo].[DraftPicks]
ADD CONSTRAINT [PK_DraftPicks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [NFLTeam_Id] in table 'NFLPlayers'
ALTER TABLE [dbo].[NFLPlayers]
ADD CONSTRAINT [FK_NFLTeamNFLPlayer]
    FOREIGN KEY ([NFLTeam_Id])
    REFERENCES [dbo].[NFLTeams]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_NFLTeamNFLPlayer'
CREATE INDEX [IX_FK_NFLTeamNFLPlayer]
ON [dbo].[NFLPlayers]
    ([NFLTeam_Id]);
GO

-- Creating foreign key on [TeamOwner_Id] in table 'DraftPicks'
ALTER TABLE [dbo].[DraftPicks]
ADD CONSTRAINT [FK_TeamOwnerDraftPick]
    FOREIGN KEY ([TeamOwner_Id])
    REFERENCES [dbo].[TeamOwners]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamOwnerDraftPick'
CREATE INDEX [IX_FK_TeamOwnerDraftPick]
ON [dbo].[DraftPicks]
    ([TeamOwner_Id]);
GO

-- Creating foreign key on [DraftPick_Id] in table 'NFLPlayers'
ALTER TABLE [dbo].[NFLPlayers]
ADD CONSTRAINT [FK_DraftPickNFLPlayer]
    FOREIGN KEY ([DraftPick_Id])
    REFERENCES [dbo].[DraftPicks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DraftPickNFLPlayer'
CREATE INDEX [IX_FK_DraftPickNFLPlayer]
ON [dbo].[NFLPlayers]
    ([DraftPick_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------