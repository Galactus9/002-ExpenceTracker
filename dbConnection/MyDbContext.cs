using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbConnection
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Expence> Expences { get; set; }
        public virtual DbSet<ExpenceCategory> ExpenceCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expence>()
                 .Property(expence => expence.Id)
                 .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<ExpenceCategory>()
                 .Property(expence => expence.Id)
                 .HasDefaultValueSql("NEWID()");
        }
    }
}
