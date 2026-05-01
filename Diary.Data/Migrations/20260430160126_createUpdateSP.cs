using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diary.Migrations
{
    /// <inheritdoc />
    public partial class createUpdateSP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" USE [DiaryDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateDiaryEntry]    Script Date: 30/04/2026 16:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/***********************************************************************************************
	Object        :  User Defined Stored Procedure [dbo].[sp_UpdateDiaryEntry]
	Script Date		:  30/04/2026
	Description		:  Update diary entry
	Test Script		:
						DECLARE	@return_value int,
								@Status char(1),
								@Message varchar(max)

						EXEC	@return_value = [dbo].[sp_UpdateDiaryEntry]
								@Title='Sample Title',
								@Content='Sample Content',
								@UpdatedOn='2026-04-30'	,
								@Status = @Status OUTPUT,
								@Message = @Message OUTPUT

						SELECT	@Status as N'@Status',
								@Message as N'@Message'

						SELECT	'Return Value' = @return_value
*************************************************************************************************/
CREATE PROCEDURE [dbo].[sp_UpdateDiaryEntry]
    @Id INT,
    @Title NVARCHAR(100),
    @Content NVARCHAR(MAX),
    @Status CHAR(1) OUTPUT,
    @Message VARCHAR(MAX) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM DiaryEntries WHERE Id = @Id)
        BEGIN
            UPDATE DiaryEntries 
            SET Title = @Title, 
                Content = @Content,
                UpdatedByID = 1,
                UpdatedOn = GETDATE() -- Optional: update timestamp
            WHERE Id = @Id
            AND [Enabled] =1;

            SET @Status = 'S';
            SET @Message = 'Diary entry updated successfully.';
        END
        ELSE
        BEGIN
            SET @Status = 'F';
            SET @Message = 'Record not found.';
        END
    END TRY
    BEGIN CATCH
        SET @Status = 'E';
        SET @Message = ERROR_MESSAGE();
    END CATCH
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
