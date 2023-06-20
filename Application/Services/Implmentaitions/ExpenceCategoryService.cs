using Application.DTOs.ExpenceCategoryDTO;
using Application.Services.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implmentaitions
{
    internal class ExpenceCategoryService : IExpenceCategoryService
    {
        public Task<ExpenceCategoryGetDTO> CreateAsync(ExpenceCategoryCreateDTO expenceCategory)
        {
            throw new NotImplementedException();
        }

        public Task<ExpenceCategoryGetDTO> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ExpenceCategoryGetDTO>> GetWithDetailsAsync(Expression<Func<ExpenceCategory, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<ExpenceCategoryGetDTO> SoftDeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ExpenceCategoryGetDTO> UpdateAsync(Guid id, ExpenceCategoryUpdateDTO expenceCategory)
        {
            throw new NotImplementedException();
        }
    }
}
