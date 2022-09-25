//using Microsoft.EntityFrameworkCore;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ElectronicShopContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=FAYIK; DataBase=ElectronicStores;Trusted_Connection =true");
        }
        public DbSet<Product> Products { get; set; }

    }
}
