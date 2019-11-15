using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SourcesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SourcesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Sources.ToList());
        }

        //Get Create Method
        public IActionResult Create()
        {
            return View();
        }

        //Post Create action method

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Sources sources)
        {
            if (ModelState.IsValid)
            {
                _db.Add(sources);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sources);
        }

        //Get Edit Method
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var sources = await _db.Sources.FindAsync(id);
            if (sources == null)
            {
                return NotFound();
            }
            return View(sources);
        }

        //Post Edit action method

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, Sources sources)
        {
            if (id != sources.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Update(sources);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sources);
        }
        //Get Details Method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var sources = await _db.Sources.FindAsync(id);
            if (sources == null)
            {
                return NotFound();
            }
            return View(sources);
        }

        //Get Delete Method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var sources = await _db.Sources.FindAsync(id);
            if (sources == null)
            {
                return NotFound();
            }
            return View(sources);
        }

        //Post Delete action method

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sources = await _db.Sources.FindAsync(id);
            _db.Sources.Remove(sources);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}