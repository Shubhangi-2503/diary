using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diary.Migrations
{
    /// <inheritdoc />
    public partial class changesininsertSP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
               /***********************************************************************************************
	Object        :  User Defined Stored Procedure [dbo].[sp_CreateDiaryEntry]
	Script Date		:  30/04/2026
	Description		:  Create a new diary entry
	Test Script		:
						DECLARE	@return_value int,
								@Status char(1),
								@Message varchar(max)

						EXEC	@return_value = [dbo].[sp_CreateDiaryEntry]
								@Title='Sample Title',
								@Content='Sample Content'	,
								@Status = @Status OUTPUT,
								@Message = @Message OUTPUT

						SELECT	@Status as N'@Status',
								@Message as N'@Message'

						SELECT	'Return Value' = @return_value
*************************************************************************************************/
CREATE PROCEDURE sp_CreateDiaryEntry 
    @Title NVARCHAR(100), @Content NVARCHAR(MAX), @Createdon DATE ,@Status CHAR(1) OUTPUT, @Message VARCHAR(MAX) OUTPUT
AS
BEGIN

	BEGIN TRY
    INSERT INTO DiaryEntries (Enabled, Createdon, CreatedById, Title, Content) 
    VALUES (1,CASE WHEN @Createdon IS NULL THEN GETDATE() ELSE @Createdon END, 1,@Title, @Content);
	END TRY
	BEGIN CATCH
		SELECT 
			ERROR_NUMBER() AS ErrorNumber,
			ERROR_SEVERITY() AS ErrorSeverity,
			ERROR_STATE() AS ErrorState,
			ERROR_PROCEDURE() AS ErrorProcedure,
			ERROR_LINE() AS ErrorLine,
			ERROR_MESSAGE() AS ErrorMessage;
	END CATCH
END
GO
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
