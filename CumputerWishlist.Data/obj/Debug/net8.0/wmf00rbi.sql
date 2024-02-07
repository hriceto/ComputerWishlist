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
    [ComponentId] int NOT NULL,
    [Count] int NOT NULL,
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

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ComponentTypeId', N'Name') AND [object_id] = OBJECT_ID(N'[Component]'))
    SET IDENTITY_INSERT [Component] ON;
INSERT INTO [Component] ([Id], [ComponentTypeId], [Name])
VALUES (1, 1, N'8 GB'),
(2, 1, N'16 GB'),
(3, 1, N'32 GB'),
(4, 1, N'2 GB'),
(5, 1, N'512 MB'),
(6, 2, N'1 TB SSD'),
(7, 2, N'2 TB HDD'),
(8, 2, N'3 TB HDD'),
(9, 2, N'4 TB HDD'),
(10, 2, N'750 GB SDD'),
(11, 2, N'2 TB SDD'),
(12, 2, N'500 GB SDD'),
(13, 2, N'80 GB SSD'),
(14, 3, N'USB 3.0'),
(15, 3, N'USB 2.0'),
(16, 3, N'USB C'),
(17, 4, N'NVIDIA GeForce GTX 770'),
(18, 4, N'NVIDIA GeForce GTX 960'),
(19, 4, N'Radeon R7360'),
(20, 4, N'NVIDIA GeForce GTX 1080'),
(21, 4, N'Radeon RX 480'),
(22, 4, N'Radeon R9 380'),
(23, 4, N'AMD FirePro W4100'),
(24, 5, N'500 W PSU'),
(25, 5, N'450 W PSU'),
(26, 5, N'1000 W PSU'),
(27, 5, N'750 W PSU'),
(28, 5, N'508 W PSU'),
(29, 5, N'700 W PSU'),
(30, 6, N'Intel® Celeron™ N3050 Processor'),
(31, 6, N'AMD FX 4300 Processor'),
(32, 6, N'AMD Athlon Quad-Core APU Athlon 5150'),
(33, 6, N'AMD FX 8-Core Black Edition FX-8350'),
(34, 6, N'AMD FX 8-Core Black Edition FX-8370'),
(35, 6, N'Intel Core i7-6700K 4GHz Processor'),
(36, 6, N'Intel® Core™ i5-6400 Processor'),
(37, 6, N'Intel Core i7 Extreme Edition 3 GHz Processor');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ComponentTypeId', N'Name') AND [object_id] = OBJECT_ID(N'[Component]'))
    SET IDENTITY_INSERT [Component] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[User]'))
    SET IDENTITY_INSERT [User] ON;
INSERT INTO [User] ([Id], [Name])
VALUES (1, N'Admin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[User]'))
    SET IDENTITY_INSERT [User] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'UserId', N'IsSystem', N'Weight') AND [object_id] = OBJECT_ID(N'[ComputerSpec]'))
    SET IDENTITY_INSERT [ComputerSpec] ON;
INSERT INTO [ComputerSpec] ([Id], [Name], [UserId], [IsSystem], [Weight])
VALUES (1, N'Machine 1', 1, CAST(1 AS bit), N'8.1 kg'),
(2, N'Machine 2', 1, CAST(1 AS bit), N'12 kg'),
(3, N'Machine 3', 1, CAST(1 AS bit), N'16 lb'),
(4, N'Machine 4', 1, CAST(1 AS bit), N'13.8 lb'),
(5, N'Machine 5', 1, CAST(1 AS bit), N'7 kg'),
(6, N'Machine 6', 1, CAST(1 AS bit), N'6 kg'),
(7, N'Machine 7', 1, CAST(1 AS bit), N'15 lb'),
(8, N'Machine 8', 1, CAST(1 AS bit), N'8 lb'),
(9, N'Machine 9', 1, CAST(1 AS bit), N'9 kg'),
(10, N'Machine 10', 1, CAST(1 AS bit), N'22 lb');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'UserId', N'IsSystem', N'Weight') AND [object_id] = OBJECT_ID(N'[ComputerSpec]'))
    SET IDENTITY_INSERT [ComputerSpec] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ComputerSpecId', N'ComponentId', N'Count') AND [object_id] = OBJECT_ID(N'[ComputerSpecComponent]'))
    SET IDENTITY_INSERT [ComputerSpecComponent] ON;
INSERT INTO [ComputerSpecComponent] ([ComputerSpecId], [ComponentId], [Count])
VALUES (1, 1, 1),
(1, 6, 1),
(1, 14, 2),
(1, 15, 4),
(1, 17, 1),
(1, 24, 1),
(1, 30, 1),
(2, 2, 1),
(2, 7, 1),
(2, 14, 3),
(2, 15, 4),
(2, 18, 1),
(2, 24, 1),
(2, 31, 1),
(3, 1, 1),
(3, 8, 1),
(3, 14, 4),
(3, 15, 4),
(3, 19, 1),
(3, 25, 1),
(3, 32, 1),
(4, 2, 1),
(4, 9, 1),
(4, 14, 4),
(4, 15, 5),
(4, 20, 1),
(4, 24, 1),
(4, 33, 1),
(5, 3, 1),
(5, 10, 1),
(5, 14, 2),
(5, 15, 2),
(5, 16, 1),
(5, 21, 1),
(5, 26, 1),
(5, 34, 1),
(6, 2, 1),
(6, 11, 1),
(6, 14, 4),
(6, 16, 2),
(6, 22, 1),
(6, 25, 1);
INSERT INTO [ComputerSpecComponent] ([ComputerSpecId], [ComponentId], [Count])
VALUES (6, 35, 1),
(7, 1, 1),
(7, 7, 1),
(7, 14, 8),
(7, 20, 1),
(7, 26, 1),
(7, 35, 1),
(8, 2, 1),
(8, 12, 1),
(8, 15, 4),
(8, 17, 1),
(8, 27, 1),
(8, 36, 1),
(9, 4, 1),
(9, 7, 1),
(9, 14, 10),
(9, 15, 10),
(9, 16, 10),
(9, 23, 1),
(9, 28, 1),
(9, 37, 1),
(10, 5, 1),
(10, 13, 1),
(10, 14, 19),
(10, 15, 10),
(10, 21, 1),
(10, 29, 1),
(10, 36, 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ComputerSpecId', N'ComponentId', N'Count') AND [object_id] = OBJECT_ID(N'[ComputerSpecComponent]'))
    SET IDENTITY_INSERT [ComputerSpecComponent] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240204011802_InitialCreate', N'8.0.1');
GO

COMMIT;
GO

