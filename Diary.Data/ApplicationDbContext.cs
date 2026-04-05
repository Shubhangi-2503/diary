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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DiaryEntry>().HasData(
             new DiaryEntry
             {
                 Id = 1,
                 Title = "First Entry",
                 Content = "This is the content of the first diary entry.",
                 CreatedOn = new DateTime(2026, 05, 20, 10, 30, 00),
                 Enabled = true,
                 Disabled = false
             },
             new DiaryEntry
             {
                Id = 2,
                 Title = "Second Entry",
                 Content = "This is the content of the second diary entry",
                 CreatedOn = DateTime.Parse("2025-12-25"),
                 Enabled = true,
                 Disabled = false},
             new DiaryEntry
             {
                 Id = 3,
                 Title = "Third Entry",
                 Content = "This is the content of the Third diary entry.",
                 CreatedOn = new DateTime(2026, 05, 20, 10, 30, 00),
                 Enabled = true,
                 Disabled = false
             }
             );
        }
    }
}
