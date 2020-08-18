using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=ProjectListDB;Trusted_Connection=True;");
        }


        public DbSet<Project> Projects { get; set; }
        public DbSet<Manager> Managers { get; set; }

    }
}
