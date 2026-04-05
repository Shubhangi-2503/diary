using Diary.Data;
using Microsoft.AspNetCore.Mvc;

namespace Diary.Controllers
{
    public class DiaryEntriesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DiaryEntriesController(ApplicationDbContext db)
        {
            _db= db;
        }
        public IActionResult Index()
        {
            List<Models.DiaryEntry> diaryEntries = _db.DiaryEntries.ToList();
            return View(diaryEntries);
        }

        public IActionResult Create()
        {
            List<Models.DiaryEntry> diaryEntries = _db.DiaryEntries.ToList();
            return View();
        }
    }
}
