CREATE DATABASE [plataformaead]
USE [plataformaead]

CREATE TABLE [Aluno] 
(
    [Id] INT NOT NULL,
    [Nome] NVARCHAR(200) NOT NULL,
    [Email] NVARCHAR(180) NOT NULL,
    [CPF] NVARCHAR(12) NOT NULL,
    [Rg] NVARCHAR(8) NULL,
    [Telefone] NVARCHAR(20) NULL,
    [DataNascimento] DATETIME NULL,
    [Cadastro] DATETIME NOT NULL,

    CONSTRAINT [PK_Student] PRIMARY KEY([Id])
);
GO

CREATE TABLE [Autor]
(
    [Id] INT IDENTITY NOT NULL,
    [Nome] NVARCHAR(200) NOT NULL,
    [Titulo] NVARCHAR(100) NOT NULL,
    [Imagem] NVARCHAR(1024) NULL,
    [Bio] NVARCHAR(2000) NULL,
    [Url] NVARCHAR(450) NULL,
    [Email] NVARCHAR(180) NOT NULL,
    [Tipo] TINYINT NOT NULL,

    CONSTRAINT [PK_Autor] PRIMARY KEY([Id])
);
GO

CREATE TABLE [Carreira]
(
    [Id] INT IDENTITY NOT NULL,
    [Title] NVARCHAR(180) NOT NULL,
    [Sumario] NVARCHAR(2000) NOT NULL,
    [Url] NVARCHAR(1024) NOT NULL,
    [DuracaoMinutos] INT NOT NULL,
    [Ativo] BIT NOT NULL,
    [Destaque] BIT NOT NULL,
    [Tags] NVARCHAR(180) NOT NULL,

    CONSTRAINT [PK_Carreira] PRIMARY KEY([Id])
);
GO

CREATE TABLE [Categoria]
(
    [Id] INT IDENTITY NOT NULL,
    [Titulo] NVARCHAR(180) NOT NULL,
    [Url] NVARCHAR(1024) NOT NULL,
    [Sumario] NVARCHAR(2000) NOT NULL,
    [Ordem] INT NOT NULL,
    [Descricao] TEXT NOT NULL,
    [Destauqe] BIT NOT NULL,

    CONSTRAINT [PK_Categoria] PRIMARY KEY([Id])
);
GO

CREATE TABLE [Curso]
(
    [Id] INT IDENTITY NOT NULL,
    [Tag] NVARCHAR(20) NOT NULL,
    [Title] NVARCHAR(180) NOT NULL,
    [Sumario] NVARCHAR(2000) NOT NULL,
    [Url] NVARCHAR(1024) NOT NULL,
    [Nivel] TINYINT NOT NULL,
    [DuracaoMinutos] INT NOT NULL,
    [Cadastro] DATETIME NOT NULL,
    [Atualizacao] DATETIME NOT NULL,
    [Ativo] BIT NOT NULL,
    [Gratis] BIT NOT NULL,
    [Destaque] BIT NOT NULL,
    [AutorId] INT NOT NULL,
    [CategoriaId] INT NOT NULL,
    [Tags] NVARCHAR(180) NOT NULL,

    CONSTRAINT [PK_Curso] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Curso_Autor_AutorId] FOREIGN KEY([AutorId]) REFERENCES [Autor]([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Curso_Ctegoria_CategoriaId] FOREIGN KEY([CategoriaId]) REFERENCES [Autor]([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [CarreiraItem]
(
    [Id] INT IDENTITY NOT NULL,
    [CursoId] INT NOT NULL,
    [Titulo] NVARCHAR(180),
    [Descricao] TEXT NOT NULL,
    [Ordem] TINYINT NOT NULL,
    [CarreiraId] INT NOT NULL,

    CONSTRAINT [PK_CarreiraItem] PRIMARY KEY([Id]),
    CONSTRAINT [FK_CarreiraItem_Carreira_CarreiraId] FOREIGN KEY([CarreiraId]) REFERENCES[Carreira]([Id]),
    CONSTRAINT [FK_CarreiraItem_Curso_CursoId] FOREIGN KEY([CursoId]) REFERENCES[Curso]([Id])

)

CREATE TABLE [AlunoCurso]
(
    [CursoId] INT NOT NULL,
    [AlunoId] INT NOT NULL,
    [Progresso] TINYINT NOT NULL,
    [Favorito] BIT NULL,
    [DataInicio] DATETIME NOT NULL,
    [UltimoAcesso] DATETIME NOT NULL,

    CONSTRAINT [PK_AlunoCurso] PRIMARY KEY([CursoId], [AlunoId]),
    CONSTRAINT [FK_AlunoCurso_Curso_CursoId] FOREIGN KEY([CursoId]) REFERENCES [Curso]([Id]),
    CONSTRAINT [FK_AlunoCurso_Aluno_AlunoId] FOREIGN KEY([CursoId]) REFERENCES [Aluno]([Id])
);
GO

-- Drop Database 
USE [master]
DECLARE @kill VARCHAR(8000) = '';
SELECT @kill = @kill + 'kill' + CONVERT(VARCHAR(5), session_id) + ';'
FROM sys.dm_exec_sessions
WHERE database_id = db_id('plataformaead')
EXEC(@kill);
DROP DATABASE [plataformaead]