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
    public class AuthorsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AuthorsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(string search)
        {
            var authors = from m in _db.Authors
                        select m;
            if (!string.IsNullOrEmpty(search))
            {
                authors = _db.Authors.Where(s => s.Name.Contains(search));
            }
            //books = _db.Books.Include(m => m.BookTypes).Include(m => m.Authors).Include(m => m.Publishers);
            return View(await authors.ToListAsync());
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

        public async Task<IActionResult> Create(Authors authors)
        {
            if (ModelState.IsValid)
            {
                _db.Add(authors);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(authors);
        }

        //Get Edit Method
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var authors  = await _db.Authors.FindAsync(id);
            if (authors == null)
            {
                return NotFound();
            }
            return View(authors);
        }

        //Post Edit action method

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, Authors authors)
        {
            if (id != authors.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Update(authors);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(authors);
        }
        //Get Details Method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var author = await _db.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        //Get Delete Method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var author = await _db.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        //Post Delete action method

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var author = await _db.Authors.FindAsync(id);
            _db.Authors.Remove(author);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }

}