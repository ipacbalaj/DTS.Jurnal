
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 07/29/2016 00:22:42
-- Generated from EDMX file: E:\DTS\DTS.Jurnal.V5\Projects\DTS.Jurnal.Database.SQLServer.Module\JurnalModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DTS.Jurnal];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AreaIntervention]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Interventions] DROP CONSTRAINT [FK_AreaIntervention];
GO
IF OBJECT_ID(N'[dbo].[FK_FilterFilterItem_Filter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FilterFilterItem] DROP CONSTRAINT [FK_FilterFilterItem_Filter];
GO
IF OBJECT_ID(N'[dbo].[FK_FilterFilterItem_FilterItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FilterFilterItem] DROP CONSTRAINT [FK_FilterFilterItem_FilterItem];
GO
IF OBJECT_ID(N'[dbo].[FK_FilterFilterType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Filters] DROP CONSTRAINT [FK_FilterFilterType];
GO
IF OBJECT_ID(N'[dbo].[FK_FilterGroupFilter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Filters] DROP CONSTRAINT [FK_FilterGroupFilter];
GO
IF OBJECT_ID(N'[dbo].[FK_InterventionDateHourDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Interventions] DROP CONSTRAINT [FK_InterventionDateHourDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_InterventionLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Interventions] DROP CONSTRAINT [FK_InterventionLocation];
GO
IF OBJECT_ID(N'[dbo].[FK_InterventionWork]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Interventions] DROP CONSTRAINT [FK_InterventionWork];
GO
IF OBJECT_ID(N'[dbo].[FK_MaterialIntervention]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Interventions] DROP CONSTRAINT [FK_MaterialIntervention];
GO
IF OBJECT_ID(N'[dbo].[FK_MaterialType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Types] DROP CONSTRAINT [FK_MaterialType];
GO
IF OBJECT_ID(N'[dbo].[FK_MonthIntervention]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Interventions] DROP CONSTRAINT [FK_MonthIntervention];
GO
IF OBJECT_ID(N'[dbo].[FK_PatientIntervention]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Interventions] DROP CONSTRAINT [FK_PatientIntervention];
GO
IF OBJECT_ID(N'[dbo].[FK_TechnicianIntervention]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Interventions] DROP CONSTRAINT [FK_TechnicianIntervention];
GO
IF OBJECT_ID(N'[dbo].[FK_UserPatient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Patients] DROP CONSTRAINT [FK_UserPatient];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkWorkType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkTypes] DROP CONSTRAINT [FK_WorkWorkType];
GO
IF OBJECT_ID(N'[dbo].[FK_YearIntervention]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Interventions] DROP CONSTRAINT [FK_YearIntervention];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Areas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Areas];
GO
IF OBJECT_ID(N'[dbo].[DateHourDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DateHourDetails];
GO
IF OBJECT_ID(N'[dbo].[DentalPaymentInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DentalPaymentInfoes];
GO
IF OBJECT_ID(N'[dbo].[FilterFilterItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FilterFilterItem];
GO
IF OBJECT_ID(N'[dbo].[FilterGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FilterGroups];
GO
IF OBJECT_ID(N'[dbo].[FilterItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FilterItems];
GO
IF OBJECT_ID(N'[dbo].[Filters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Filters];
GO
IF OBJECT_ID(N'[dbo].[FilterTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FilterTypes];
GO
IF OBJECT_ID(N'[dbo].[IntervalInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IntervalInfoes];
GO
IF OBJECT_ID(N'[dbo].[Interventions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Interventions];
GO
IF OBJECT_ID(N'[dbo].[Locations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Locations];
GO
IF OBJECT_ID(N'[dbo].[Materials]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Materials];
GO
IF OBJECT_ID(N'[dbo].[Months]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Months];
GO
IF OBJECT_ID(N'[dbo].[Patients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Patients];
GO
IF OBJECT_ID(N'[dbo].[ProgramInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProgramInfoes];
GO
IF OBJECT_ID(N'[dbo].[Technicians]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Technicians];
GO
IF OBJECT_ID(N'[dbo].[Types]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Types];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Works]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Works];
GO
IF OBJECT_ID(N'[dbo].[WorkTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkTypes];
GO
IF OBJECT_ID(N'[dbo].[Years]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Years];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Areas'
CREATE TABLE [dbo].[Areas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(4000)  NOT NULL,
    [WasDeleted] bit  NULL
);
GO

-- Creating table 'DateHourDetails'
CREATE TABLE [dbo].[DateHourDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StartHour] datetime  NOT NULL,
    [EndingHour] datetime  NOT NULL,
    [Date] datetime  NOT NULL,
    [Duration] bigint  NULL,
    [MiliTime] bigint  NOT NULL
);
GO

-- Creating table 'DentalPaymentInfoes'
CREATE TABLE [dbo].[DentalPaymentInfoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [TotalRevenue] float  NOT NULL,
    [TotalPercent] float  NOT NULL
);
GO

-- Creating table 'FilterGroups'
CREATE TABLE [dbo].[FilterGroups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(4000)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [IsActive] bit  NOT NULL,
    [IsIntervalActive] bit  NOT NULL
);
GO

-- Creating table 'FilterItems'
CREATE TABLE [dbo].[FilterItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(4000)  NOT NULL
);
GO

-- Creating table 'Filters'
CREATE TABLE [dbo].[Filters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IsActive] bit  NOT NULL,
    [FilterGroup_Id] int  NOT NULL,
    [FilterType_Id] int  NOT NULL
);
GO

-- Creating table 'FilterTypes'
CREATE TABLE [dbo].[FilterTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(4000)  NOT NULL
);
GO

-- Creating table 'IntervalInfoes'
CREATE TABLE [dbo].[IntervalInfoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TotalRevenue] float  NOT NULL,
    [TotalPercent] float  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Interventions'
CREATE TABLE [dbo].[Interventions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Observation] nvarchar(4000)  NULL,
    [Number] int  NOT NULL,
    [Revenue] float  NOT NULL,
    [Percent] float  NOT NULL,
    [Patient_id] int  NOT NULL,
    [Location_Id] int  NULL,
    [Material_Id] int  NULL,
    [DateHourDetail_Id] int  NOT NULL,
    [Area_Id] int  NULL,
    [Work_Id] int  NULL,
    [Year_Id] int  NOT NULL,
    [Month_Id] int  NOT NULL,
    [WasPayedByDental] bit  NULL,
    [TechnicianId] int  NULL,
    [MaterialCost] float  NULL,
    [IsSelected] bit  NOT NULL,
    [Remainder] float  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'Locations'
CREATE TABLE [dbo].[Locations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(4000)  NOT NULL,
    [WasDeleted] bit  NULL
);
GO

-- Creating table 'Materials'
CREATE TABLE [dbo].[Materials] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(4000)  NOT NULL,
    [Cost] float  NOT NULL,
    [WasDeleted] bit  NULL
);
GO

-- Creating table 'Months'
CREATE TABLE [dbo].[Months] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MOnthNumber] int  NOT NULL
);
GO

-- Creating table 'Patients'
CREATE TABLE [dbo].[Patients] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(100)  NULL,
    [surname] nvarchar(100)  NULL,
    [Address] nvarchar(100)  NULL,
    [City] nvarchar(50)  NULL,
    [Phone] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [BirthDate] datetime  NULL,
    [Street] nvarchar(4000)  NULL,
    [Block] nvarchar(4000)  NULL,
    [Job] nvarchar(4000)  NULL,
    [StreetNumber] nvarchar(4000)  NULL,
    [Ocupation] nvarchar(4000)  NULL,
    [Country] nvarchar(4000)  NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'ProgramInfoes'
CREATE TABLE [dbo].[ProgramInfoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ExportFileName] nvarchar(max)  NOT NULL,
    [LastFileDateImport] datetime  NOT NULL,
    [LastAddedInterventionDate] datetime  NOT NULL
);
GO

-- Creating table 'Technicians'
CREATE TABLE [dbo].[Technicians] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [WasDeleted] bit  NULL
);
GO

-- Creating table 'Types'
CREATE TABLE [dbo].[Types] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cost] float  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Material_Id] int  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [username] nvarchar(max)  NULL,
    [password] nvarchar(max)  NULL,
    [appInfo] nvarchar(max)  NULL
);
GO

-- Creating table 'Works'
CREATE TABLE [dbo].[Works] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(4000)  NOT NULL,
    [Cost] float  NOT NULL,
    [Percent] float  NULL,
    [IncludedINFinancial] bit  NULL,
    [WasDeleted] bit  NULL
);
GO

-- Creating table 'WorkTypes'
CREATE TABLE [dbo].[WorkTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Cost] float  NOT NULL,
    [Percent] float  NOT NULL,
    [Work_Id] int  NOT NULL
);
GO

-- Creating table 'Years'
CREATE TABLE [dbo].[Years] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [YearNb] int  NOT NULL
);
GO

-- Creating table 'FilterFilterItem'
CREATE TABLE [dbo].[FilterFilterItem] (
    [Filters_Id] int  NOT NULL,
    [FilterItems_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Areas'
ALTER TABLE [dbo].[Areas]
ADD CONSTRAINT [PK_Areas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DateHourDetails'
ALTER TABLE [dbo].[DateHourDetails]
ADD CONSTRAINT [PK_DateHourDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DentalPaymentInfoes'
ALTER TABLE [dbo].[DentalPaymentInfoes]
ADD CONSTRAINT [PK_DentalPaymentInfoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FilterGroups'
ALTER TABLE [dbo].[FilterGroups]
ADD CONSTRAINT [PK_FilterGroups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FilterItems'
ALTER TABLE [dbo].[FilterItems]
ADD CONSTRAINT [PK_FilterItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Filters'
ALTER TABLE [dbo].[Filters]
ADD CONSTRAINT [PK_Filters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FilterTypes'
ALTER TABLE [dbo].[FilterTypes]
ADD CONSTRAINT [PK_FilterTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IntervalInfoes'
ALTER TABLE [dbo].[IntervalInfoes]
ADD CONSTRAINT [PK_IntervalInfoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Interventions'
ALTER TABLE [dbo].[Interventions]
ADD CONSTRAINT [PK_Interventions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Locations'
ALTER TABLE [dbo].[Locations]
ADD CONSTRAINT [PK_Locations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Materials'
ALTER TABLE [dbo].[Materials]
ADD CONSTRAINT [PK_Materials]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Months'
ALTER TABLE [dbo].[Months]
ADD CONSTRAINT [PK_Months]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'Patients'
ALTER TABLE [dbo].[Patients]
ADD CONSTRAINT [PK_Patients]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'ProgramInfoes'
ALTER TABLE [dbo].[ProgramInfoes]
ADD CONSTRAINT [PK_ProgramInfoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Technicians'
ALTER TABLE [dbo].[Technicians]
ADD CONSTRAINT [PK_Technicians]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Types'
ALTER TABLE [dbo].[Types]
ADD CONSTRAINT [PK_Types]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Works'
ALTER TABLE [dbo].[Works]
ADD CONSTRAINT [PK_Works]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WorkTypes'
ALTER TABLE [dbo].[WorkTypes]
ADD CONSTRAINT [PK_WorkTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Years'
ALTER TABLE [dbo].[Years]
ADD CONSTRAINT [PK_Years]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Filters_Id], [FilterItems_Id] in table 'FilterFilterItem'
ALTER TABLE [dbo].[FilterFilterItem]
ADD CONSTRAINT [PK_FilterFilterItem]
    PRIMARY KEY NONCLUSTERED ([Filters_Id], [FilterItems_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Area_Id] in table 'Interventions'
ALTER TABLE [dbo].[Interventions]
ADD CONSTRAINT [FK_AreaIntervention]
    FOREIGN KEY ([Area_Id])
    REFERENCES [dbo].[Areas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AreaIntervention'
CREATE INDEX [IX_FK_AreaIntervention]
ON [dbo].[Interventions]
    ([Area_Id]);
GO

-- Creating foreign key on [DateHourDetail_Id] in table 'Interventions'
ALTER TABLE [dbo].[Interventions]
ADD CONSTRAINT [FK_InterventionDateHourDetails]
    FOREIGN KEY ([DateHourDetail_Id])
    REFERENCES [dbo].[DateHourDetails]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InterventionDateHourDetails'
CREATE INDEX [IX_FK_InterventionDateHourDetails]
ON [dbo].[Interventions]
    ([DateHourDetail_Id]);
GO

-- Creating foreign key on [FilterGroup_Id] in table 'Filters'
ALTER TABLE [dbo].[Filters]
ADD CONSTRAINT [FK_FilterGroupFilter]
    FOREIGN KEY ([FilterGroup_Id])
    REFERENCES [dbo].[FilterGroups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FilterGroupFilter'
CREATE INDEX [IX_FK_FilterGroupFilter]
ON [dbo].[Filters]
    ([FilterGroup_Id]);
GO

-- Creating foreign key on [FilterType_Id] in table 'Filters'
ALTER TABLE [dbo].[Filters]
ADD CONSTRAINT [FK_FilterFilterType]
    FOREIGN KEY ([FilterType_Id])
    REFERENCES [dbo].[FilterTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FilterFilterType'
CREATE INDEX [IX_FK_FilterFilterType]
ON [dbo].[Filters]
    ([FilterType_Id]);
GO

-- Creating foreign key on [Location_Id] in table 'Interventions'
ALTER TABLE [dbo].[Interventions]
ADD CONSTRAINT [FK_InterventionLocation]
    FOREIGN KEY ([Location_Id])
    REFERENCES [dbo].[Locations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InterventionLocation'
CREATE INDEX [IX_FK_InterventionLocation]
ON [dbo].[Interventions]
    ([Location_Id]);
GO

-- Creating foreign key on [Work_Id] in table 'Interventions'
ALTER TABLE [dbo].[Interventions]
ADD CONSTRAINT [FK_InterventionWork]
    FOREIGN KEY ([Work_Id])
    REFERENCES [dbo].[Works]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InterventionWork'
CREATE INDEX [IX_FK_InterventionWork]
ON [dbo].[Interventions]
    ([Work_Id]);
GO

-- Creating foreign key on [Material_Id] in table 'Interventions'
ALTER TABLE [dbo].[Interventions]
ADD CONSTRAINT [FK_MaterialIntervention]
    FOREIGN KEY ([Material_Id])
    REFERENCES [dbo].[Materials]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MaterialIntervention'
CREATE INDEX [IX_FK_MaterialIntervention]
ON [dbo].[Interventions]
    ([Material_Id]);
GO

-- Creating foreign key on [Month_Id] in table 'Interventions'
ALTER TABLE [dbo].[Interventions]
ADD CONSTRAINT [FK_MonthIntervention]
    FOREIGN KEY ([Month_Id])
    REFERENCES [dbo].[Months]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MonthIntervention'
CREATE INDEX [IX_FK_MonthIntervention]
ON [dbo].[Interventions]
    ([Month_Id]);
GO

-- Creating foreign key on [Patient_id] in table 'Interventions'
ALTER TABLE [dbo].[Interventions]
ADD CONSTRAINT [FK_PatientIntervention]
    FOREIGN KEY ([Patient_id])
    REFERENCES [dbo].[Patients]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PatientIntervention'
CREATE INDEX [IX_FK_PatientIntervention]
ON [dbo].[Interventions]
    ([Patient_id]);
GO

-- Creating foreign key on [TechnicianId] in table 'Interventions'
ALTER TABLE [dbo].[Interventions]
ADD CONSTRAINT [FK_TechnicianIntervention]
    FOREIGN KEY ([TechnicianId])
    REFERENCES [dbo].[Technicians]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TechnicianIntervention'
CREATE INDEX [IX_FK_TechnicianIntervention]
ON [dbo].[Interventions]
    ([TechnicianId]);
GO

-- Creating foreign key on [Year_Id] in table 'Interventions'
ALTER TABLE [dbo].[Interventions]
ADD CONSTRAINT [FK_YearIntervention]
    FOREIGN KEY ([Year_Id])
    REFERENCES [dbo].[Years]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_YearIntervention'
CREATE INDEX [IX_FK_YearIntervention]
ON [dbo].[Interventions]
    ([Year_Id]);
GO

-- Creating foreign key on [Material_Id] in table 'Types'
ALTER TABLE [dbo].[Types]
ADD CONSTRAINT [FK_MaterialType]
    FOREIGN KEY ([Material_Id])
    REFERENCES [dbo].[Materials]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MaterialType'
CREATE INDEX [IX_FK_MaterialType]
ON [dbo].[Types]
    ([Material_Id]);
GO

-- Creating foreign key on [UserId] in table 'Patients'
ALTER TABLE [dbo].[Patients]
ADD CONSTRAINT [FK_UserPatient]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPatient'
CREATE INDEX [IX_FK_UserPatient]
ON [dbo].[Patients]
    ([UserId]);
GO

-- Creating foreign key on [Work_Id] in table 'WorkTypes'
ALTER TABLE [dbo].[WorkTypes]
ADD CONSTRAINT [FK_WorkWorkType]
    FOREIGN KEY ([Work_Id])
    REFERENCES [dbo].[Works]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkWorkType'
CREATE INDEX [IX_FK_WorkWorkType]
ON [dbo].[WorkTypes]
    ([Work_Id]);
GO

-- Creating foreign key on [Filters_Id] in table 'FilterFilterItem'
ALTER TABLE [dbo].[FilterFilterItem]
ADD CONSTRAINT [FK_FilterFilterItem_Filters]
    FOREIGN KEY ([Filters_Id])
    REFERENCES [dbo].[Filters]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [FilterItems_Id] in table 'FilterFilterItem'
ALTER TABLE [dbo].[FilterFilterItem]
ADD CONSTRAINT [FK_FilterFilterItem_FilterItems]
    FOREIGN KEY ([FilterItems_Id])
    REFERENCES [dbo].[FilterItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FilterFilterItem_FilterItems'
CREATE INDEX [IX_FK_FilterFilterItem_FilterItems]
ON [dbo].[FilterFilterItem]
    ([FilterItems_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------