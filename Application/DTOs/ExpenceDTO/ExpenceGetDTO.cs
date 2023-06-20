using Application.DTOs.ExpenceCategoryDTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ExpenceDTO
{
    public class ExpenceGetDTO
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public double Amount { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public ExpenceCategoryGetDTO ExpenceCategory { get; set; }
    }
}
