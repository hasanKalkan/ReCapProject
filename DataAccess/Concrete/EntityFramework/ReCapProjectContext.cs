using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapProjectContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ReCapProject;Trusted_Connection=true"); // @\\ @ işareti slaş işaretini ters slaş olarak ayarlar.
            //veri tabanı isminde büyük küçük harf farketmez.
            //trusted ile integrated security aynı
        }

        public DbSet<Car> Products { get; set; }
        public DbSet<Color> Categories { get; set; }
        public DbSet<Brand> Customers { get; set; }
    }
}
