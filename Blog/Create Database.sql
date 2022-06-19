-- CREATE DATABASE [Blog]
-- GO

-- USE [Blog]
-- GO

CREATE TABLE [User] (
    [Id] INT NOT NULL IDENTITY,
    [Name] NVARCHAR(100) NOT NULL,
    [Email] VARCHAR(200) NOT NULL,
    [PasswordHash] VARCHAR(255) NOT NULL,
    [Bio] TEXT NOT NULL,
    [Image] VARCHAR(2000) NOT NULL,
    [Slug] VARCHAR (100) NOT NULL,

    CONSTRAINT [PK_UserId] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_User_Email] UNIQUE([Email]),
    CONSTRAINT [UQ_User_Slug] UNIQUE([Slug])
);
CREATE NONCLUSTERED INDEX [IX_User_Email] ON [User]([Email])
CREATE NONCLUSTERED INDEX [IX_User_Slug] ON [User]([Slug])
GO

INSERT INTO
    [User]
VALUES
    -- ('Erick Rick', 'erickcred@email.com', 'Password', 'Dessenvolvedor (JavaScript, NodeJs, .NET)', 'https://caminho_da_imagem', 'erickcred');
    ('Jessica', 'hessicad@email.com', 'Password', 'Cordenadora de Desenvolvimento', 'https://caminho_da_imagem', 'jessica'),
    ('Marta Rocha', 'marta@email.com', 'Password', 'Cordenadora de Vendas', 'https://caminho_da_imagem', 'marta');
GO

CREATE TABLE [Role] (
    [Id] INT NOT NULL IDENTITY,
    [Name] VARCHAR(100) NOT NULL,
    [Slug] VARCHAR(100) NOT NULL,

    CONSTRAINT [PK_RoleId] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_Role_Slug] UNIQUE([Slug])
);
CREATE NONCLUSTERED INDEX [IX_Role_Slug] ON [Role]([Slug])
GO

CREATE TABLE [UserRole] (
    [UserId] INT NOT NULL,
    [RoleId] INT NOT NULL,

    CONSTRAINT [PK_UserRole] PRIMARY KEY([UserId], [RoleId])
);
GO

CREATE TABLE [Category] (
    [Id] INT NOT NULL IDENTITY,
    [Name] VARCHAR(100) NOT NULL,
    [Slug] VARCHAR(100) NOT NULL,

    CONSTRAINT [PK_CategoryId] PRIMARY KEY([Id]),
    CONSTRAINT [UK_Category_Slug] UNIQUE([Slug])
);
CREATE NONCLUSTERED INDEX [IX_Category_Slug] ON [Category]([Slug])
GO


CREATE TABLE [Post] (
    [Id] INT NOT NULL IDENTITY,
    [CategoryId] INT NOT NULL,
    [AuthorId] INT NOT NULL,
    [Title] VARCHAR(200) NOT NULL,
    [Summary] VARCHAR(255) NOT NULL,
    [Body] TEXT NOT NULL,
    [Slug] VARCHAR(100) NOT NULL,
    [CreateDate] DATETIME NOT NULL DEFAULT(GETDATE()),
    [LastUpdateDate] DATETIME NOT NULL DEFAULT(GETDATE())

    CONSTRAINT [PK_PostId] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Post_CategoryId] FOREIGN KEY([CategoryId]) REFERENCES [Category]([Id]),
    CONSTRAINT [FK_Post_AuthorId] FOREIGN KEY([AuthorId]) REFERENCES [User]([Id]),
    CONSTRAINT [UQ_Post_Slug] UNIQUE([Slug])
);
CREATE NONCLUSTERED INDEX [IX_PostSlug] ON [Post]([Slug])
GO

CREATE TABLE [Tag] (
    [Id] INT NOT NULL IDENTITY,
    [Name] VARCHAR(100) NOT NULL,
    [Slug] VARCHAR(100) NOT NULL,

    CONSTRAINT [PK_TagId] PRIMARY KEY([Id]),
    CONSTRAINT [UK_Tag_Slug] UNIQUE([Slug])
);
CREATE NONCLUSTERED INDEX [IX_Tag_Slug] ON [Tag]([Slug])
GO

CREATE TABLE [PostTag] (
    [PostId] INT NOT NULL,
    [TagId] INT NOT NULL,

    CONSTRAINT [PK_PostTag] PRIMARY KEY([PostId], [TagId])
);
GO

-- USE [master]
-- DECLARE @kill varchar(8000) = '';
-- SELECT @kill = @kill + 'kill' + CONVERT(varchar(5), session_id) + ';'
-- FROM sys.dm_exec_sessions
-- WHERE database_id = db_id('Blog')
-- EXEC(@kill)
-- DROP DATABASE [Blog]