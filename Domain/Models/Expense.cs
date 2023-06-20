using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.AbstractClasses;

namespace Domain.Models
{
    public class Expense : AbstractModel
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public double? Amount { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public Guid? ExpenseCategoryId { get; set; }
        public ExpenseCategory? ExpenseCategory { get; set; }
    }
}
