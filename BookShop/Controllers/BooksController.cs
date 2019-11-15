using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Models.ViewModel;
using BookShop.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Controllers
{
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

        //Get : Products Create
        public IActionResult Create()
        {
            return View(BooksVM);
        }

        //Post : Products Create
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



       
    }
}