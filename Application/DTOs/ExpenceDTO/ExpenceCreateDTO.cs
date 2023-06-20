using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ExpenceDTO
{
    public class ExpenceCreateDTO
    {
        public string? Description { get; set; }
        public double Amount { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public Guid? ExpenceCategoryId { get; set; }
    }
}
