--USE [implementacao];

CREATE OR ALTER VIEW vwListCourses AS
    SELECT TOP 100
        [Course].[Id],
        [Course].[Tag],
        [Course].[Title],
        [Course].[Url],
        [Course].[Summary],
        [Course].[Active],
        [Course].[CreateDate],
        [Category].[Title] AS [Category],
        [Author].[Name] AS [Tesher]
    FROM
        [Course]
    INNER JOIN [Category] ON [Course].[CategoryId] = [Category].[Id]
    INNER JOIN [Author] ON [Course].[AuthorId] = [Author].[Id]
    WHERE
        [Active] = 1
    ORDER BY [Createdate] DESC
GO

CREATE OR ALTER VIEW vwCareers AS
    SELECT 
        [Career].[Id],
        [Career].[Title] AS [Career],
        [Career].[Url],
        [Career].[Summary],
        COUNT([Id]) AS [Total Courses]
    FROM 
        [Career]
        INNER JOIN [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
    GROUP BY
        [Career].[Id],
        [Career].[Title],
        [Career].[Url],
        [Career].[Summary]
GO

-- SELECT TOP 100 * FROM [Course]
-- SELECT * FROM [Student]
-- SELECT * FROM [StudentCourse]

CREATE OR ALTER VIEW vwListStudentsCourses AS
    SELECT TOP 100
        [Course].[Title] AS [Course],
        [Student].[Name] AS [Student],
        [StudentCourse].[Progress],
        [StudentCourse].[Favorite],
        [StudentCourse].[StartDate],
        [StudentCourse].[LastUpdateDate]
    FROM
        [StudentCourse]
        INNER JOIN [Student] ON [StudentCourse].[StudentId] = [Student].[Id]
        INNER JOIN [Course] ON [StudentCourse].[CourseId] = [Course].[Id]
GO


-- INSERT INTO
--     [Student]
-- VALUES
--     ('3f4d3fd6-1ff3-4e2d-a667-93744acdc313', 'Fulano da Silva', 'email@fulano.com', '10101010', '41000000', '1991-11-17', GETDATE()),
--     ('3f4d3fd6-1ff3-4e2d-a667-93744acdc312', 'Siclano de Oliveira', 'email@siclano.com', '20202020', '41222222', '1987-11-17', GETDATE())

-- INSERT INTO
--     [StudentCourse]
-- VALUES
--     -- ('5d8cf396-e717-9a02-2443-021b00000000', '3f4d3fd6-1ff3-4e2d-a667-93744acdc313', 10, 0, '2022-06-14', GETDATE()),
--     -- ('5c34a0a9-e717-9a7d-1241-14ac00000000', '3f4d3fd6-1ff3-4e2d-a667-93744acdc312', 10, 0, '2022-06-14', GETDATE()),
--     ('5c34ef9e-e717-9a7d-1241-536c00000000', '3f4d3fd6-1ff3-4e2d-a667-93744acdc313', 10, 0, '2022-06-14', GETDATE()),
--     ('5c34ef9e-e717-9a7d-1241-536c00000000', '3f4d3fd6-1ff3-4e2d-a667-93744acdc312', 10, 0, '2022-06-14', GETDATE()),
--     ('5d548b32-e717-9a08-4eee-c57d00000000', '3f4d3fd6-1ff3-4e2d-a667-93744acdc313', 10, 0, '2022-06-14', GETDATE()),
--     ('5bed7e7a-fb6f-c056-1ff8-f8ef00000000', '3f4d3fd6-1ff3-4e2d-a667-93744acdc312', 10, 0, '2022-06-14', GETDATE())


-- SELECT * FROM [vwCareers]

CREATE OR ALTER PROCEDURE spListStudentCourses (
    @StudentId UNIQUEIDENTIFIER
) AS
    SELECT TOP 100
        [Course].[Title] AS [Course],
        [Student].[Name] AS [Student],
        [StudentCourse].[Progress],
        [StudentCourse].[Favorite],
        [StudentCourse].[StartDate],
        [StudentCourse].[LastUpdateDate]
    FROM
        [StudentCourse]
        INNER JOIN [Student] ON [StudentCourse].[StudentId] = [Student].[Id]
        INNER JOIN [Course] ON [StudentCourse].[CourseId] = [Course].[Id]
    WHERE 
        [StudentCourse].[StudentId] = @StudentId
        AND [StudentCourse].[Progress] <= 95
    ORDER BY [StudentCourse].[LastUpdateDate] DESC
GO

--EXEC spListStudentCourses '3f4d3fd6-1ff3-4e2d-a667-93744acdc313'

CREATE OR ALTER PROCEDURE spDeleteStudent (
    @StudentId UNIQUEIDENTIFIER
) 
AS
    BEGIN TRANSACTION
        DELETE FROM
            [StudentCourse]
        WHERE
            [StudentCourse].[StudentId] = @StudentId
            
        DELETE FROM 
            [Student]
        WHERE
            [Id] = @StudentId
    COMMIT
GO
--EXEC spDeleteStudent '3f4d3fd6-1ff3-4e2d-a667-93744acdc313'
SELECT * FROM [vwListStudentsCourses]
SELECT * FROM [Student]




