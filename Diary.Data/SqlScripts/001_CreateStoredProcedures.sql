-- CREATE PROCEDURE
CREATE PROCEDURE sp_CreateDiaryEntry 
    @Title NVARCHAR(100), @Content NVARCHAR(MAX), @Created DATETIME
AS
BEGIN
    INSERT INTO DiaryEntries (Enabled, Createdon, Title, Content, ) 
    VALUES (1,GETDATE(), @Title, @Content);
END
GO

