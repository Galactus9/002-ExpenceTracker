using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbConnection
{
    public static class SeedDB
    {
        private static List<string> ExpenseTitle = new List<string> { "Housing", "Transportation", "Utilities", "Insurance", "Medical & Healthcare", "Personal Spending",  };
        public static async Task Seed(MyDbContext db)
        {
            try
            {
                bool migrated = await Migrate(db);

                SeedStandaloneTables(db);
                SeedRelatedTables(db);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }
        public static void SeedStandaloneTables(MyDbContext db)
        {
            if (!db.Set<ExpenseCategory>().Any())
            {
                foreach (string title in ExpenseTitle)
                {
                    ExpenseCategory expenseCategory = new ExpenseCategory
                    {
                        Title = title,
                        IsActive = true,
                        IsApproved = true,
                        IsDeleted = false,
                        CreatedOn = DateTime.Now,
                    };
                    db.Set<ExpenseCategory>().Add(expenseCategory);
                    db.SaveChanges();
                } 
            }
        }
        private static void SeedRelatedTables(MyDbContext db)
        {
            if (!db.Set<Expense>().Any())
            {
                Random rnd = new Random();
                List<ExpenseCategory> cat = db.ExpenseCategories.ToList();
                for (int i = 0; i < cat.Count; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Expense exspense = new Expense
                        {
                            Amount = rnd.Next(minValue: 5, maxValue: 200),
                            ExpenseCategory = cat[i],
                            IsActive = true,
                            IsApproved = true,
                            IsDeleted = false,
                            CreatedOn = DateTime.Now,
                            PurchaseDate = DateTime.Now,
                        };
                        db.Set<Expense>().Add(exspense);
                        db.SaveChanges();
                    }
                } 
            }
        }
        public static async Task<bool> Migrate(MyDbContext db)
        {
            try
            {
                Console.WriteLine("Attempting to apply migration...");

                //if(!db.Database.IsInMemory())
                if (!db.Database.GetConnectionString().Equals("Server=.;Database=IntegrationTestDB;Integrated Security=true;TrustServerCertificate=True;")) //The test database doesn't need migrations
                {
                    await db.Database.MigrateAsync();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR: Tried to apply migration but failed.");
                Console.WriteLine("Do you want to continue to drop db and update? (y/n)");

                string input = Console.ReadLine();
                if (input.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Dropping the database and migrating...");
                    await db.Database.EnsureDeletedAsync();
                    await db.Database.MigrateAsync();
                }
                else if (input.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Exiting program...");
                    Environment.Exit(0);
                }
            }
            return true;
        }
    }
}
