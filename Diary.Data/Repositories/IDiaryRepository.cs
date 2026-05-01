using Diary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Data.Repositories
{
    public interface IDiaryRepository
    {
        Task<List<DiaryEntry>> GetEntriesAsync(int? id = null);
        Task<(string Status, string Message)> AddEntryAsync(DiaryEntry entry);
        Task<(string Status, string Message)> UpdateEntryAsync(DiaryEntry entry);
        Task<(string Status, string Message)> DeleteEntryAsync(int id);

    }
}
