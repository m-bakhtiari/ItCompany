using ItCompany.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ItCompany.Context
{
    public class ItCompanyContext : DbContext
    {

        public ItCompanyContext(DbContextOptions<ItCompanyContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Slide> Slides { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new List<User>()
            {
                new User()
                {
                    Username = "Admin",
                    Password = "1234",
                    Phone = "123456789",
                    RecordDate = new DateTime(2020,09,10),
                    Id =new Guid("f56cdae7-6658-407e-b7ed-2534c18778f8"),
                    Email = "info@admin.com",
                    Name = "ادمین"
                },
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
