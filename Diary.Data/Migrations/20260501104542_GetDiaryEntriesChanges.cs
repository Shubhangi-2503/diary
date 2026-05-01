using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diary.Migrations
{
    /// <inheritdoc />
    public partial class GetDiaryEntriesChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [dbo].[sp_GetDiaryEntries]");
            migrationBuilder.Sql(@"
USE [DiaryDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDiaryEntries]    Script Date: 30/04/2026 18:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/***********************************************************************************************
	Object        :  User Defined Stored Procedure [dbo].[sp_GetDiaryEntries]
	Script Date		:  30/04/2026
	Description		:  Update diary entry
	Test Script		:
					
						EXEC [dbo].[sp_GetDiaryEntries]
								@Id=2
							

						SELECT	'Return Value' = @return_value
*************************************************************************************************/
CREATE PROCEDURE [dbo].[sp_GetDiaryEntries]
    @Id INT = NULL  -- Optional parameter
AS
BEGIN
    SET NOCOUNT ON;
    SELECT *
    FROM DiaryEntries
    WHERE (@Id IS NULL OR Id = @Id)
	AND Enabled = 1
    ORDER BY Createdon DESC;
END 

");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
