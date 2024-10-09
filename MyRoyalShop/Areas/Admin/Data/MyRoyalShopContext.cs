using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyRoyalShop.DataLayer.Domain;

namespace MyRoyalShop.Data
{
    public class MyRoyalShopContext : DbContext
    {
        public MyRoyalShopContext (DbContextOptions<MyRoyalShopContext> options)
            : base(options)
        {
        }

        public DbSet<MyRoyalShop.DataLayer.Domain.Product> Product { get; set; } = default!;
    }
}
