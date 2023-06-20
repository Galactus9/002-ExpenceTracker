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
    public interface IExpenceService
    {
        Task<ExpenceGetDTO> CreateAsync(ExpenceCreateDTO expence);
        Task<ExpenceGetDTO> GetByIdAsync(Guid id);
        Task<List<ExpenceGetDTO>> GetAsync(Expression<Func<Expence, bool>> filter);
        Task<List<ExpenceGetDTO>> GetWithDetailsAsync(Expression<Func<Expence, bool>> filter);
        Task<ExpenceGetDTO> UpdateAsync(Guid id, ExpenceUpdateDTO expence);
        Task<bool> SoftDeleteAsync(Guid id);
    }
}
