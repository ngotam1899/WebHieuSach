using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Models;
using BookShop.Models.ViewModel;
using BookShop.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _db;
        
        private readonly IHostingEnvironment _hostingEnvironment;

        [BindProperty]
        public BooksViewModel BooksVM { get; set; }


        public BooksController(ApplicationDbContext db, IHostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
            BooksVM = new BooksViewModel()
            {
                BookTypes = _db.BookTypes.ToList(),
                Authors = _db.Authors.ToList(),
                Publishers = _db.Publishers.ToList(),
                Books= new Models.Books()
            };

        }


        public async Task<IActionResult> Index()
        {
            var books = _db.Books.Include(m => m.BookTypes).Include(m => m.Authors).Include(m => m.Publishers);
            return View(await books.ToListAsync());
        }

        //Get : Books Create
        public IActionResult Create()
        {
            return View(BooksVM);
        }

        //Post : Books Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            if (!ModelState.IsValid)
            {
                return View(BooksVM);
            }

            _db.Books.Add(BooksVM.Books);
            await _db.SaveChangesAsync();

            //Image being saved

            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var booksFromDb = _db.Books.Find(BooksVM.Books.ID);

            if (files.Count != 0)
            {
                //Image has been uploaded
                var uploads = Path.Combine(webRootPath, SD.ImageFolder);
                var extension = Path.GetExtension(files[0].FileName);

                using (var filestream = new FileStream(Path.Combine(uploads, BooksVM.Books.ID + extension), FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                }
                booksFromDb.Image = @"\" + SD.ImageFolder + @"\" + BooksVM.Books.ID + extension;
            }
            else
            {
                //when user does not upload image
                var uploads = Path.Combine(webRootPath, SD.ImageFolder + @"\" + SD.DefaultBookImage);
                System.IO.File.Copy(uploads, webRootPath + @"\" + SD.ImageFolder + @"\" + BooksVM.Books.ID + ".png");
                booksFromDb.Image = @"\" + SD.ImageFolder + @"\" + BooksVM.Books.ID + ".png";
            }
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        //GET : Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BooksVM.Books = await _db.Books.Include(m => m.Publishers).Include(m => m.Authors).Include(m => m.BookTypes).SingleOrDefaultAsync(m => m.ID == id);

            if (BooksVM.Books == null)
            {
                return NotFound();
            }

            return View(BooksVM);
        }


        //Post : Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var booksFromDb = _db.Books.Where(m => m.ID == BooksVM.Books.ID).FirstOrDefault();

                if (files.Count > 0 && files[0] != null)
                {
                    //if user uploads a new image
                    var uploads = Path.Combine(webRootPath, SD.ImageFolder);
                    var extension_new = Path.GetExtension(files[0].FileName);
                    var extension_old = Path.GetExtension(booksFromDb.Image);

                    if (System.IO.File.Exists(Path.Combine(uploads, BooksVM.Books.ID + extension_old)))
                    {
                        System.IO.File.Delete(Path.Combine(uploads, BooksVM.Books.ID + extension_old));
                    }
                    using (var filestream = new FileStream(Path.Combine(uploads, BooksVM.Books.ID + extension_new), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    BooksVM.Books.Image = @"\" + SD.ImageFolder + @"\" + BooksVM.Books.ID + extension_new;
                }

                if (BooksVM.Books.Image != null)
                {
                    booksFromDb.Image = BooksVM.Books.Image;
                }

                booksFromDb.Name = BooksVM.Books.Name;
                booksFromDb.Price = BooksVM.Books.Price;
                booksFromDb.Available = BooksVM.Books.Available;
                booksFromDb.AuthorID = BooksVM.Books.AuthorID;
                booksFromDb.PublisherID = BooksVM.Books.PublisherID;
                booksFromDb.BookTypeID = BooksVM.Books.BookTypeID;
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(BooksVM);
        }


        //GET : Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BooksVM.Books = await _db.Books.Include(m => m.Publishers).Include(m => m.Authors).Include(m => m.BookTypes).SingleOrDefaultAsync(m => m.ID == id);

            if (BooksVM.Books == null)
            {
                return NotFound();
            }

            return View(BooksVM);
        }

        //GET : Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BooksVM.Books = await _db.Books.Include(m => m.Publishers).Include(m => m.Authors).Include(m => m.BookTypes).SingleOrDefaultAsync(m => m.ID == id);

            if (BooksVM.Books == null)
            {
                return NotFound();
            }

            return View(BooksVM);
        }

        //POST : Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            Books books = await _db.Books.FindAsync(id);

            if (books == null)
            {
                return NotFound();
            }
            else
            {
                var uploads = Path.Combine(webRootPath, SD.ImageFolder);
                var extension = Path.GetExtension(books.Image);

                if (System.IO.File.Exists(Path.Combine(uploads, books.ID + extension)))
                {
                    System.IO.File.Delete(Path.Combine(uploads, books.ID + extension));
                }
                _db.Books.Remove(books);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
        }




    }
}