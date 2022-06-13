CREATE DATABASE [Curso]
USE [Curso]

DROP TABLE [Aluno]
CREATE TABLE [Aluno] (
    [Id] INT NOT NULL IDENTITY,
    [Nome] NVARCHAR(100) NOT NULL,
    [Email] NVARCHAR(180) NOT NULL,
    [Nascimento] DATEtIME NULL,
    [Active] BIT DEFAULT(0),

    CONSTRAINT [Pk_Aluno] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_Email] UNIQUE([Email])
)
GO
INSERT INTO [Aluno] ([Nome], [Email]) VALUES
('Fulano da Silva', 'email@fulano.com.br'), ('Siclano', 'email@siclano.com.br')
SELECT * FROM [Aluno]

CREATE INDEX [IX_Aluno_Nome] ON [Aluno]([Nome])
CREATE INDEX [IX_Aluno_Email] ON [Aluno]([Email])
DROP INDEX [IX_Aluno_Email] ON [Aluno]

DROP TABLE [Curso]
CREATE TABLE [Curso] (
    [Id] INT NOT NULL IDENTITY,
    [Nome] NVARCHAR(100) NOT NULL,
    [CategoriaId] INT NOT NULL,

    CONSTRAINT [PK_Curso] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Curso_Categoria] FOREIGN KEY([CategoriaId]) REFERENCES [Categoria]([Id])
)
GO


DROP TABLE [Categoria]
CREATE TABLE [Categoria] (
    [Id] INT NOT NULL IDENTITY,
    [Nome] NVARCHAR(100)

    CONSTRAINT [PK_Categoria] PRIMARY KEY([Id])
)
GO

DROP TABLE [ProgressoCurso]
CREATE TABLE [ProgressoCurso] (
    [AlunoId] INT NOT NULL IDENTITY,
    [CursoId] INT NOT NULL,
    [Progresso] INT NOT NULL,
    [UltimaAtualizacao] DATETIME NOT NULL DEFAULT(GETDATE())
    
    CONSTRAINT [PK_ProgressoCurso] PRIMARY KEY([AlunoId], [CursoId])
)
GO

-- ALTER TABLE [Aluno]
--     ALTER COLUMN [Active] BIT NOT NULL 

-- ALTER TABLE [Aluno]
--     ADD [Document] NVARCHAR(11)

-- ALTER TABLE [Aluno]
--     DROP COLUMN [Document]

-- ALTER TABLE [Aluno]
--     ALTER COLUMN [Document] CHAR(11)

-- Matar processos abertos
USE [master]
DECLARE @kill varchar(8000) = '';
SELECT @kill = @kill + 'kill' + CONVERT(varchar(5), session_id)
FROM sys.dm_exec_sessions
WHERE database_id = db_id('Curso')

EXEC(@kill);

DROP DATABASE [Curso]