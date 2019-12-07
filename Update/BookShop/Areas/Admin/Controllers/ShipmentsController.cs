using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Models;
using BookShop.Models.ViewModel;
using BookShop.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.AdminEndUser + "," + SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class ShipmentsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ShipmentsController(ApplicationDbContext db)
        {
            _db = db;   
        }
        //Xác nhận id nào đang làm
        public async Task<IActionResult> Index(string searchName = null, string searchEmail = null, string searchPhone = null, string searchDate = null)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            ShipmentViewModel shipmentVM = new ShipmentViewModel()
            {
                Shipments = new List<Models.Shipments>()
            };
          

            shipmentVM.Shipments = _db.Shipments.Include(s => s.SalesPerson).ToList();
            if(User.IsInRole(SD.AdminEndUser))
            {
                shipmentVM.Shipments = shipmentVM.Shipments.Where(s => s.SalesPersonID == claim.Value).ToList();
            }

            //Criteria
            if (searchName != null)
            {
                shipmentVM.Shipments = shipmentVM.Shipments.Where(s => s.CustomerName.ToLower().Contains(searchName.ToLower())).ToList();
            }
            if (searchEmail != null)
            {
                shipmentVM.Shipments = shipmentVM.Shipments.Where(s => s.CustomerEmail.ToLower().Contains(searchEmail.ToLower())).ToList();
            }
            if (searchPhone != null)
            {
                shipmentVM.Shipments = shipmentVM.Shipments.Where(s => s.CustomerPhone.ToLower().Contains(searchPhone.ToLower())).ToList();
            }
            if (searchDate != null)
            {
                try
                {
                    DateTime shipDate = Convert.ToDateTime(searchDate);
                    shipmentVM.Shipments = shipmentVM.Shipments.Where(s => s.ShipmentDate.ToShortDateString().Equals(shipDate.ToShortDateString())).ToList();
                }
                catch(Exception ex)
                {

                }
                
            } 


            return View(shipmentVM);
        }

        //Get Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var booklist = (IEnumerable<Books>)(from b in _db.Books
                                             join s in _db.BooksSelectedForShipment
                                             on b.ID equals s.BookID
                                             where s.ShipmentID == id
                                             select b).Include("BookTypes").Include("Publishers").Include("Authors");

            ShipmentDetailsViewModel objShipmentVM = new ShipmentDetailsViewModel()
            {
                Shipment = _db.Shipments.Include(s => s.SalesPerson).Where(s => s.ID == id).FirstOrDefault(),
                SalesPerson = _db.ApplicationUsers.ToList(),
                Books = booklist.ToList()
            };
            return View(objShipmentVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ShipmentDetailsViewModel objShipmentVM)
        {
            if(ModelState.IsValid)
            {
                objShipmentVM.Shipment.ShipmentDate = objShipmentVM.Shipment.ShipmentDate.AddHours(objShipmentVM.Shipment.ShipmentTime.Hour).AddMinutes(objShipmentVM.Shipment.ShipmentTime.Minute);
                var shipmentFromDb = _db.Shipments.Where(s => s.ID == objShipmentVM.Shipment.ID).FirstOrDefault();

                shipmentFromDb.CustomerName = objShipmentVM.Shipment.CustomerName;
                shipmentFromDb.CustomerEmail = objShipmentVM.Shipment.CustomerEmail;
                shipmentFromDb.CustomerPhone = objShipmentVM.Shipment.CustomerPhone;
                shipmentFromDb.ShipmentDate = objShipmentVM.Shipment.ShipmentDate;
                shipmentFromDb.isConfirmed = objShipmentVM.Shipment.isConfirmed;

                //Cập nhật ID
                if(User.IsInRole(SD.SuperAdminEndUser))
                {
                    shipmentFromDb.SalesPersonID = objShipmentVM.Shipment.SalesPersonID; 
                }
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(objShipmentVM);
        }

        //Get Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booklist = (IEnumerable<Books>)(from b in _db.Books
                                                join s in _db.BooksSelectedForShipment
                                                on b.ID equals s.BookID
                                                where s.ShipmentID == id
                                                select b).Include("BookTypes").Include("Publishers").Include("Authors");

            ShipmentDetailsViewModel objShipmentVM = new ShipmentDetailsViewModel()
            {
                Shipment = _db.Shipments.Include(s => s.SalesPerson).Where(s => s.ID == id).FirstOrDefault(),
                SalesPerson = _db.ApplicationUsers.ToList(),
                Books = booklist.ToList()
            };
            return View(objShipmentVM);
        }

        //Get Delete    
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booklist = (IEnumerable<Books>)(from b in _db.Books
                                                join s in _db.BooksSelectedForShipment
                                                on b.ID equals s.BookID
                                                where s.ShipmentID == id
                                                select b).Include("BookTypes").Include("Publishers").Include("Authors");

            ShipmentDetailsViewModel objShipmentVM = new ShipmentDetailsViewModel()
            {
                Shipment = _db.Shipments.Include(s => s.SalesPerson).Where(s => s.ID == id).FirstOrDefault(),
                SalesPerson = _db.ApplicationUsers.ToList(),
                Books = booklist.ToList()
            };
            return View(objShipmentVM);
        }

        //Post Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id)
        {
            var shipment = await _db.Shipments.FindAsync(id);
            _db.Shipments.Remove(shipment);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}