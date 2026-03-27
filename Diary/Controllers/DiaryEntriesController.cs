using Microsoft.AspNetCore.Mvc;

namespace Diary.Controllers
{
    public class DiaryEntriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
