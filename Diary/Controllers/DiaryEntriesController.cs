using Diary.Data;
using Diary.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Diary.Controllers
{
    public class DiaryEntriesController : Controller
    {
        private readonly IDiaryRepository _repo;

        // 1. Dependency Injection: We ask for the Interface, not the Class
        public DiaryEntriesController(IDiaryRepository repo)
        {
            _repo = repo;
        }

        // 2. The Action must be 'async Task' to match the Repository
        public async Task<IActionResult> Index()
        {
            // 3. Call the Repository method
            var entries = await _repo.GetAllEntriesAsync();

            // 4. Pass the list of entries to the View
            return View(entries);
        }

        public IActionResult Create()
        {
            //List<Models.DiaryEntry> diaryEntries = _db.DiaryEntries.ToList();
            return View();
        }
    }
}
