using Application.DTOs.ExpenseCategoryDTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ExpenseDTO
{
    public class ExpenseGetDTO
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public double Amount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public ExpenseCategoryGetDTO ExpenseCategory { get; set; }
    }
}
