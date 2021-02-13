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

        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }


        //Custom Mapping
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fluent mapping
            // modelBuilder.HasDefaultSchema("admin"); //Default şema
            //modelBuilder.Entity<Personel>().ToTable("Employees"); //Employees tablosunu Personel tablosu olarak bağla.
            //modelBuilder.Entity<Personel>().Property(p => p.Id).HasColumnName("EmployeeID"); //Sadece bir alanın ismini bağladık.
            //modelBuilder.Entity<Personel>().Property(p => p.Name).HasColumnName("FirstName"); //ilk bizim class taki isim
            //modelBuilder.Entity<Personel>().Property(p => p.SurName).HasColumnName("LasttName"); //ikincisi de veri tabanındaki isim
        }
    }
}
