-- USE [master]
-- DECLARE @kill varchar(8000) = '';
-- SELECT @kill = @kill + 'kill' + CONVERT(varchar(5), session_id) + ';'
-- FROM sys.dm_exec_sessions
-- WHERE database_id = db_id('Cursos')
-- EXEC(@kill)
-- DROP DATABASE [Cursos]

CREATE DATABASE [Cursos]
GO
USE [Cursos]

CREATE TABLE [Categoria] (
    Id INT NOT NULL IDENTITY,
    [Nome] NVARCHAR(100) NOT NULL,

    CONSTRAINT [PK_Categoria] PRIMARY KEY(Id)
)
GO  

CREATE TABLE [Curso] (
    [Id] INT NOT NULL IDENTITY,
    [Nome] NVARCHAR(100) NOT NULL,
    [CategoriaId] INT NOT NULL,

    CONSTRAINT [PK_Curso] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Curso_Categoria] FOREIGN KEY([CategoriaId]) REFERENCES[Categoria]([Id])
)
GO

-- Inserindo Dados na Tabela de Categoria
INSERT INTO [Categoria] ([Nome]) VALUES
('LGPD'),
('Contábil/Fical'),
('Trabalhista/Previdenciária'),
('Tributável')
GO
SELECT * FROM [Categoria]

INSERT INTO [Curso] ([Nome], [CategoriaId]) VALUES
('LGPD - Lei Geral de Proteção de Dados Pessoais e as Relações Trabalhistas', 1),
('Jornada LGPD para Contadores', 1),
('ECD 2022 - Passo a passo para implementação', 2),
('Industrialização por Encomenda', 4)
SELECT DISTINCT TOP 100 -- DISTINCT -> Para poder remover duplicidades
    [Id], [Nome], [CategoriaId]
FROM 
    [Curso]
WHERE 
    [CategoriaId] = 1
ORDER BY [Nome]

BEGIN TRANSACTION
    UPDATE 
        [Categoria] 
    SET 
        [Nome] = 'Trabalhista' 
    WHERE 
        [Id] = 3
COMMIT

SELECT TOP 100
    [Id], [Nome]
FROM 
    [Categoria]



SELECT 
    c.[Id], c.[Nome], c.[CategoriaId], ct.[Nome] 
FROM 
    [Curso] c 
INNER JOIN 
    [Categoria] ct ON c.[CategoriaId] = ct.[Id]
WHERE c.[Id] = 1

-- Deletando dados
DELETE FROM 
    [Curso]
WHERE
    [Id] = 4

SELECT TOP 100
    COUNT(Id)
FROM
    [Curso]

SELECT TOP 100
    [Nome]
FROM
    [Curso]
WHERE 
    [Nome] LIKE '%lgp%'


SELECT TOP 100
    [Id], [Nome]
FROM 
    [Curso]
WHERE [Id] BETWEEN 1 AND 3


SELECT TOP 100
    [Curso].[Id], [Curso].[Nome] AS [Curso],
    [Categoria].[Nome] AS [Categoria]
FROM 
    [Curso]
    INNER JOIN -- LEFT JOIN / RIGHT JOIN / FULL JOIN / FULL OUTER JOIN
        [Categoria] ON [Curso].[CategoriaId] = [Categoria].[Id]
WHERE [Curso].[Id] = 1


-- Utilizando o GROUP BY
-- Processo para poder contar item por quantidade
SELECT TOP 100
    [Categoria].[Nome],
    COUNT([Curso].[CategoriaId]) AS [TotalCursos]
FROM 
    [Categoria]
INNER JOIN [Curso] ON [Curso].[CategoriaId] = [Categoria].[Id]
GROUP BY
    [Curso].[CategoriaId], [Categoria].[Nome]
HAVING
    COUNT([Curso].[CategoriaId]) > 1
GO

-- Crinado Views
CREATE OR ALTER VIEW VWCursosPorCategoria AS 
    SELECT TOP 100
        [Categoria].[Nome],
        COUNT([Curso].[CategoriaId]) AS [TotalCursos]
    FROM 
        [Categoria]
    INNER JOIN [Curso] ON [Curso].[CategoriaId] = [Categoria].[Id]
    GROUP BY
        [Curso].[CategoriaId], [Categoria].[Nome]
    HAVING
        COUNT([Curso].[CategoriaId]) > 1
GO
SELECT * FROM VWCursosPorCategoria


-- Stored Procedures
CREATE OR ALTER PROCEDURE [spListCursos] AS
    SELECT 
        [Curso].[Nome] AS [Curso],
        [Categoria].[Nome] AS [Categoria]
    FROM [Curso]
    INNER JOIN [Categoria] ON [Categoria].[Id] = [CategoriaId]
GO
EXEC [spListCursos]

-- Variaveis