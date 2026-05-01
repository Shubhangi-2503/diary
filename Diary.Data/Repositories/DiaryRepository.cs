using Diary.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Data.Repositories
{
    public class DiaryRepository : IDiaryRepository
    {
        private readonly ApplicationDbContext _context;

        // Make sure the constructor is also 'public'
        public DiaryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Your methods must also be 'public'
        public async Task<List<DiaryEntry>> GetEntriesAsync(int? id = null)
        {
            // Use FromSqlInterpolated with the $ sign
            return await _context.DiaryEntries
                .FromSqlInterpolated($"EXEC sp_GetDiaryEntries @Id={id}")
                .ToListAsync();
        }

        public async Task<(string Status, string Message)> AddEntryAsync(DiaryEntry entry)
        {
            // 1. Define Input Parameters
            var titleParam = new SqlParameter("@Title", entry.Title ?? (object)DBNull.Value);
            var contentParam = new SqlParameter("@Content", entry.Content ?? (object)DBNull.Value);
            var dateParam = new SqlParameter("@Createdon", entry.CreatedOn);

            // 2. Define OUTPUT Parameters
            var statusParam = new SqlParameter
            {
                ParameterName = "@Status",
                SqlDbType = SqlDbType.Char,
                Size = 1,
                Direction = ParameterDirection.Output
            };

            var messageParam = new SqlParameter
            {
                ParameterName = "@Message",
                SqlDbType = SqlDbType.VarChar,
                Size = -1, // Use -1 for VARCHAR(MAX)
                Direction = ParameterDirection.Output
            };

            // 3. Execute the SP
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC [dbo].[sp_CreateDiaryEntry] @Title, @Content, @Createdon, @Status OUTPUT, @Message OUTPUT",
                titleParam, contentParam, dateParam, statusParam, messageParam
            );

            // 4. Return the output values
            return (
                statusParam.Value.ToString(),
                messageParam.Value.ToString()
            );
        }

        public async Task<(string Status, string Message)> UpdateEntryAsync(DiaryEntry entry)
        {
            var statusParam = new SqlParameter("@Status", SqlDbType.Char, 1) { Direction = ParameterDirection.Output };
            var messageParam = new SqlParameter("@Message", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC [dbo].[sp_UpdateDiaryEntry] @Id, @Title, @Content, @Status OUTPUT, @Message OUTPUT",
                new SqlParameter("@Id", entry.Id),
                new SqlParameter("@Title", entry.Title ?? (object)DBNull.Value),
                new SqlParameter("@Content", entry.Content ?? (object)DBNull.Value),
                statusParam,
                messageParam
            );

            return (statusParam.Value?.ToString() ?? "E", messageParam.Value?.ToString() ?? "Unknown Error");
        }

        public async Task<(string Status, string Message)> DeleteEntryAsync(int id)
        {
            var statusParam = new SqlParameter("@Status", SqlDbType.Char, 1) { Direction = ParameterDirection.Output };
            var messageParam = new SqlParameter("@Message", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC [dbo].[sp_DeleteDiaryEntry] @Id, @Status OUTPUT, @Message OUTPUT",
                new SqlParameter("@Id", id),
                statusParam,
                messageParam
            );

            return (statusParam.Value?.ToString() ?? "E", messageParam.Value?.ToString() ?? "Error");
        }

    }
}
