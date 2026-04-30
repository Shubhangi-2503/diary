using Diary.Models;
using Microsoft.EntityFrameworkCore;

namespace Diary.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<DiaryEntry> DiaryEntries { get; set; }

 
    }
}
