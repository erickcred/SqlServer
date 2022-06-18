USE [erickcred]
GO

CREATE OR ALTER PROCEDURE spDeleteStudent (
    @StudentId UNIQUEIDENTIFIER
)
AS
    BEGIN TRANSACTION
        DELETE FROM
            [StudentCourse]
        WHERE
            [StudentId] = @StudentId
        
        DELETE FROM
            [Student]
        WHERE
            [Id] = @StudentId
    COMMIT
GO

INSERT INTO [Student] VALUES(NEWID(), 'Siclano da Silva', 'email@siclano.com', '1234562340', '41022200000', '1986-07-05', GETDATE())
GO

SELECT TOP 100 * FROM [Student]
GO

CREATE OR ALTER PROCEDURE [spGetCoursesByCategory]
    @CategoryId UNIQUEIDENTIFIER
AS
    SELECT * FROM [Course] WHERE [CategoryId] = @CategoryId
GO

SELECT * FROM [Category]
GO

EXEC [spGetCoursesByCategory] "af3407aa-11ae-4621-a2ef-2028b85507c4"
GO

CREATE OR ALTER VIEW [vwCourse] AS
    SELECT * FROM [Course]
GO

SELECT * FROM [CareerItem] INNER JOIN [Course] ON [CareerItem].[CourseId] = [Course].[Id] 



SELECT TOP 5 
    [Career].[Id],
    [Career].[Title],
    [CareerItem].[CareerId],
    [CareerItem].[Title]
FROM
    [Career]
    INNER JOIN [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
ORDER BY 
    [Career].[Title]


SELECT TOP 100 * FROM [Career] WHERE [Id] IN (
    '01ae8a85-b4e8-4194-a0f1-1c6190af54cb',
    '4327ac7e-963b-4893-9f31-9a3b28a4e72b'
)