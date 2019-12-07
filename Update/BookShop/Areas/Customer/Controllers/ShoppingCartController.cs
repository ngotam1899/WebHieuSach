using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Extensions;
using BookShop.Models;
using BookShop.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public ShoppingCartViewModel ShoppingCartVM { get; set; }
        public ShoppingCartController(ApplicationDbContext db)
        {
            _db = db;
            ShoppingCartVM = new ShoppingCartViewModel()
            {
                Books = new List<Models.Books>()
            };
        }
        //Get Index Shopping Cart
        public async Task<IActionResult> Index()
        {
            List<int> lstCartItems = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if (lstCartItems.Count > 0)
            {
                foreach (int cartItem in lstCartItems)
                {
                    Books book = _db.Books.Include(b => b.BookTypes).Include(b => b.Publishers).Include(b => b.Authors).Where(b => b.ID == cartItem).FirstOrDefault();
                    ShoppingCartVM.Books.Add(book);
                }
            }
            return View(ShoppingCartVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public IActionResult IndexPost()
        {
            List<int> lstCartItems = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            ShoppingCartVM.Shipments.ShipmentDate = ShoppingCartVM.Shipments.ShipmentDate.AddHours(ShoppingCartVM.Shipments.ShipmentTime.Hour).AddMinutes(ShoppingCartVM.Shipments.ShipmentTime.Minute);
            Shipments shipments = ShoppingCartVM.Shipments;
            _db.Shipments.Add(shipments);
            _db.SaveChanges();

            int shipmentID = shipments.ID;
            foreach(int bookID in lstCartItems)
            {
                BooksSelectedForShipment booksSelectedForShipment = new BooksSelectedForShipment()
                {
                    ShipmentID = shipmentID,
                    BookID = bookID
                };
                _db.BooksSelectedForShipment.Add(booksSelectedForShipment);

            }
            _db.SaveChanges();
            lstCartItems = new List<int>();
            HttpContext.Session.Set("ssShoppingCart", lstCartItems);
            return RedirectToAction("ShipmentConfirmation", "ShoppingCart", new { ID = shipmentID });
        }
        //Xóa Cart
        public IActionResult Remove(int id)
        {
            List<int> lstCartItems = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if(lstCartItems.Count > 0)
            {
                if(lstCartItems.Contains(id))
                {
                    lstCartItems.Remove(id);
                }
            }

            HttpContext.Session.Set("ssShoppingCart", lstCartItems);
            return RedirectToAction(nameof(Index));
        }


        //Get
        public IActionResult ShipmentConfirmation(int id)
        {
            ShoppingCartVM.Shipments = _db.Shipments.Where(s => s.ID == id).FirstOrDefault();
            List<BooksSelectedForShipment> objBookList = _db.BooksSelectedForShipment.Where(b => b.ShipmentID == id).ToList();
            foreach(BooksSelectedForShipment bookShipObj in objBookList)
            {
                ShoppingCartVM.Books.Add(_db.Books.Include(b => b.BookTypes).Include(b => b.Publishers).Include(b => b.Authors).Where(b => b.ID == bookShipObj.BookID).FirstOrDefault());

            }
            return View(ShoppingCartVM);
        }



    }
}