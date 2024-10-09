using Microsoft.EntityFrameworkCore;
using MyRoyalShop.DataLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRoyalShop.DataLayer.Context
{
    public class MyRoyalShopDbContext : DbContext
    {
        public MyRoyalShopDbContext(DbContextOptions<MyRoyalShopDbContext>
            options):
            base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
