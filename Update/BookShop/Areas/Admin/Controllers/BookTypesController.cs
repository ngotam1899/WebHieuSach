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
    public class BookTypesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookTypesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(string search)
        {
            var bts = from m in _db.BookTypes
                          select m;
            if (!string.IsNullOrEmpty(search))
            {
                bts = _db.BookTypes.Where(s => s.Name.Contains(search));
            }
            //books = _db.Books.Include(m => m.BookTypes).Include(m => m.Authors).Include(m => m.Publishers);
            return View(await bts.ToListAsync());
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

        public async Task<IActionResult> Create(BookTypes bookTypes)
        {
            if (ModelState.IsValid)
            {
                _db.Add(bookTypes);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookTypes);
        }

        //Get Edit Method
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var bookTypes = await _db.BookTypes.FindAsync(id);
            if (bookTypes == null)
            {
                return NotFound();
            }
            return View(bookTypes);
        }

        //Post Edit action method

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, BookTypes bookTypes)
        {
            if (id != bookTypes.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Update(bookTypes);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookTypes);
        }
        //Get Details Method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var bookTypes = await _db.BookTypes.FindAsync(id);
            if (bookTypes == null)
            {
                return NotFound();
            }
            return View(bookTypes);
        }

        //Get Delete Method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var bookTypes = await _db.BookTypes.FindAsync(id);
            if (bookTypes == null)
            {
                return NotFound();
            }
            return View(bookTypes);
        }

        //Post Delete action method

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookTypes = await _db.BookTypes.FindAsync(id);
            _db.BookTypes.Remove(bookTypes);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}