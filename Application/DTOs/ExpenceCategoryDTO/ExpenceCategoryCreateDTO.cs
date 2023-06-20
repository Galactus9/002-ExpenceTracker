using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ExpenceCategoryDTO
{
    public class ExpenceCategoryCreateDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
