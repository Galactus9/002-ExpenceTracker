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
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<ExpenseCategory> ExpenseCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>()
                 .Property(Expense => Expense.Id)
                 .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<ExpenseCategory>()
                 .Property(Expense => Expense.Id)
                 .HasDefaultValueSql("NEWID()");
        }
    }
}
