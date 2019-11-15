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
    public class PublishersController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PublishersController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Publishers.ToList());
        }
        //Get Create Method
        public IActionResult Create()
        {
            return View();
        }

        //Post Create action method

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Publishers publishers)
        {
            if (ModelState.IsValid)
            {
                _db.Add(publishers);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(publishers);
        }

        //Get Edit Method
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var publishers = await _db.Publishers.FindAsync(id);
            if (publishers == null)
            {
                return NotFound();
            }
            return View(publishers);
        }

        //Post Edit action method

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, Publishers publishers)
        {
            if (id != publishers.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Update(publishers);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(publishers);
        }
        //Get Details Method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var publishers = await _db.Publishers.FindAsync(id);
            if (publishers == null)
            {
                return NotFound();
            }
            return View(publishers);
        }

        //Get Delete Method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var publishers = await _db.Publishers.FindAsync(id);
            if (publishers == null)
            {
                return NotFound();
            }
            return View(publishers);
        }

        //Post Delete action method

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publishers = await _db.Publishers.FindAsync(id);
            _db.Publishers.Remove(publishers);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}