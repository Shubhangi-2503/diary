using Diary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public async Task<List<DiaryEntry>> GetAllEntriesAsync()
        {
            // Use FromSqlInterpolated with the $ sign
            return await _context.DiaryEntries
                .FromSqlInterpolated($"EXEC sp_GetAllDiaryEntries")
                .ToListAsync();
        }
    }
}
