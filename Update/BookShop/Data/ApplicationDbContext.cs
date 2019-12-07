using System;
using System.Collections.Generic;
using System.Text;
using BookShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Publishers> Publishers { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<BookTypes> BookTypes { get; set; }

        public DbSet<Shipments> Shipments { get; set; }
        public DbSet<BooksSelectedForShipment> BooksSelectedForShipment { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
