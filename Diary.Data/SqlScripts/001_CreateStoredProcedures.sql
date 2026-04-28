-- CREATE PROCEDURE
CREATE PROCEDURE sp_CreateDiaryEntry 
    @Title NVARCHAR(100), @Content NVARCHAR(MAX), @Created DATETIME
AS
BEGIN
    INSERT INTO DiaryEntries (Title, Content, Createdon) 
    VALUES (@Title, @Content, @Created);
END
GO

