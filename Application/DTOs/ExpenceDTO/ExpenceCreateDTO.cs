using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ExpenseDTO
{
    public class ExpenseCreateDTO
    {
        public string? Description { get; set; }
        public double? Amount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Guid? ExpenseCategoryId { get; set; }
    }
}
