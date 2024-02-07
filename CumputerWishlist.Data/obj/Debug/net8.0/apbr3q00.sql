IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Component] (
    [Id] int NOT NULL IDENTITY,
    [ComponentTypeId] int NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Component] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ComponentType] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [MaxLimit] int NOT NULL,
    CONSTRAINT [PK_ComponentType] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ComputerSpec] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [UserId] int NOT NULL,
    [IsSystem] bit NOT NULL,
    [Weight] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_ComputerSpec] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ComputerSpecComponent] (
    [Id] int NOT NULL IDENTITY,
    [ComputerSpecId] int NOT NULL,
    [ComputerSpecComponentId] int NOT NULL,
    CONSTRAINT [PK_ComputerSpecComponent] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [User] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'MaxLimit') AND [object_id] = OBJECT_ID(N'[ComponentType]'))
    SET IDENTITY_INSERT [ComponentType] ON;
INSERT INTO [ComponentType] ([Id], [Name], [MaxLimit])
VALUES (1, N'Ram', 1),
(2, N'Hard Drive', 1),
(3, N'Ports', 30),
(4, N'Graphics Card', 2),
(5, N'Power Supply', 1),
(6, N'Processor', 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'MaxLimit') AND [object_id] = OBJECT_ID(N'[ComponentType]'))
    SET IDENTITY_INSERT [ComponentType] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ComponentTypeId', N'Name') AND [object_id] = OBJECT_ID(N'[Component]'))
    SET IDENTITY_INSERT [Component] ON;
INSERT INTO [Component] ([ComponentTypeId], [Name])
VALUES (1, N'8 GB'),
(1, N'16 GB'),
(1, N'32 GB'),
(1, N'2 GB'),
(1, N'512 MB'),
(2, N'1 TB SSD'),
(2, N'2 TB HDD'),
(2, N'3 TB HDD'),
(2, N'4 TB HDD'),
(2, N'750 GB SDD'),
(2, N'2 TB SDD'),
(2, N'500 GB SDD'),
(2, N'80 GB SSD');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ComponentTypeId', N'Name') AND [object_id] = OBJECT_ID(N'[Component]'))
    SET IDENTITY_INSERT [Component] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240204003801_InitialCreate', N'8.0.1');
GO

COMMIT;
GO

