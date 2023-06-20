using Application.DTOs.ExpenceCategoryDTO;
using Application.DTOs.ExpenceDTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IExpenceCategoryService
    {
        Task<ExpenceCategoryGetDTO> CreateAsync(ExpenceCategoryCreateDTO expenceCategory);
        Task<ExpenceCategoryGetDTO> GetByIdAsync(Guid id);
        Task<List<ExpenceCategoryGetDTO>> GetWithDetailsAsync(Expression<Func<ExpenceCategory, bool>> filter);
        Task<bool> SoftDeleteAsync(Guid id);
        Task<ExpenceCategoryGetDTO> UpdateAsync(Guid id, ExpenceCategoryUpdateDTO expenceCategory);
    }
}
