using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Models;
using BookShop.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class PublishersController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PublishersController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(string search)
        {
            var publishers = from m in _db.Publishers
                          select m;
            if (!string.IsNullOrEmpty(search))
            {
                publishers = _db.Publishers.Where(s => s.Name.Contains(search));
            }
            //books = _db.Books.Include(m => m.BookTypes).Include(m => m.Authors).Include(m => m.Publishers);
            return View(await publishers.ToListAsync());
            //return View(_db.Authors.ToList());
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