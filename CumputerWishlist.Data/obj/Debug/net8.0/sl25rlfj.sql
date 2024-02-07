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

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Name', N'MaxLimit') AND [object_id] = OBJECT_ID(N'[ComponentType]'))
    SET IDENTITY_INSERT [ComponentType] ON;
INSERT INTO [ComponentType] ([Name], [MaxLimit])
VALUES (N'Ram', 1),
(N'Hard Drive', 1),
(N'Ports', 30),
(N'Graphics Card', 2),
(N'Power Supply', 1),
(N'Processor', 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Name', N'MaxLimit') AND [object_id] = OBJECT_ID(N'[ComponentType]'))
    SET IDENTITY_INSERT [ComponentType] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240204003801_InitialCreate', N'8.0.1');
GO

COMMIT;
GO

