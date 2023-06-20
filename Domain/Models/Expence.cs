using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.AbstractClasses;

namespace Domain.Models
{
    public class Expence : AbstractModel
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public double? Amount { get; set; }
        public DateOnly? PurchaseDate { get; set; }
        public Guid? ExpenceCategoryId { get; set; }
        public ExpenceCategory? ExpenceCategory { get; set; }
    }
}
