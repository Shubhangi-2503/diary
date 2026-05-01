using Diary.Data;
using Diary.Data.Repositories;
using Diary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var entries = await _repo.GetEntriesAsync();

            // 4. Pass the list of entries to the View
            return View(entries);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DiaryEntry entry)
        {
            if (ModelState.IsValid)
            {
                var result = await _repo.AddEntryAsync(entry);

                if (result.Status == "S") // Assuming 'S' means Success
                {
                    TempData["SuccessMessage"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Show the error message from the SP on the form
                    ModelState.AddModelError("", result.Message);
                }
            }
            return View(entry);
        }

        public async Task<IActionResult> Edit(int id)
        {
            // You might need a GetById method in your repo for this
            var entry = (await _repo.GetEntriesAsync(id)).FirstOrDefault();
            if (entry == null) return NotFound();

            return View(entry);
        }

        // POST: Handle the Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DiaryEntry entry)
        {
            if (ModelState.IsValid)
            {
                var result = await _repo.UpdateEntryAsync(entry);

                if (result.Status == "S")
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", result.Message);
            }
            return View(entry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repo.DeleteEntryAsync(id);

            if (result.Status == "S")
                TempData["Success"] = result.Message;
            else
                TempData["Error"] = result.Message;

            return RedirectToAction(nameof(Index));
        }
    }
}
