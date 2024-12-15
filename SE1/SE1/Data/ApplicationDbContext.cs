using Microsoft.EntityFrameworkCore;
using SE1.Models;
using System;

namespace SE1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Request> Requests { get; set; }
        
        public DbSet<Printer> Printers { get; set; }

        public DbSet<Printer2> Printer2s { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Dat Nguyen", Email = "dat.nguyentrinh1801@hcmut.edu.vn", Password = "123456", Phone = 0347909369 },
                new User { Id = 2, Name = "Khanh Phan", Email = "khanh.phannguyen@hcmut.edu.vn", Password = "123456", Phone = 0965221701 }
                );
            modelBuilder.Entity<Request>().HasData(
                new Request { RId = 1, Date = new DateTime(2024, 10, 12), Paper = 20, Document_name = "Doc1", Deliver_date = new DateTime(2024, 10, 13) },
                new Request { RId = 2, Date = new DateTime(2024, 11, 13), Paper = 18, Document_name = "Doc2", Deliver_date = new DateTime(2024, 11, 14) },
                new Request { RId = 3, Date = new DateTime(2024, 11, 18), Paper = 13, Document_name = "Doc3", Deliver_date = new DateTime(2024, 11, 19) },
                new Request { RId = 4, Date = new DateTime(2024, 11, 27), Paper = 25, Document_name = "Doc4", Deliver_date = new DateTime(2024, 11, 28) }
                );
            modelBuilder.Entity<Printer>().HasData(
                new Printer { Id = 1, Name = "HP Color LaserJet Pro", Location = "A4-502", Active = true },
                new Printer { Id = 2, Name = "Brother MFC-J23188WC", Location = "C6-102", Active = true },
                new Printer { Id = 3, Name = "HP DeskJet 2440", Location = "B1-212", Active = true }
                );
            modelBuilder.Entity<Printer2>().HasData(
                new Printer2 { Id = 1, Name = "HP Color LaserJet Pro", Location = "A4-502", Active = "active" },
                new Printer2 { Id = 2, Name = "Brother MFC-J23188WC", Location = "C6-102", Active = "active" },
                new Printer2 { Id = 3, Name = "HP DeskJet 2440", Location = "B1-212", Active = "active" }
                );
        }
    }
}
