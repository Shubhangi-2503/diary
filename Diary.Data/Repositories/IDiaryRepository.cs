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
        Task<List<DiaryEntry>> GetAllEntriesAsync();

    }
}
