using Application.DTOs.ExpenseCategoryDTO;
using Application.DTOs.ExpenseDTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IExpenseCategoryService
    {
        Task<ExpenseCategoryGetDTO> CreateAsync(ExpenseCategoryCreateDTO ExpenseCategory);
        Task<ExpenseCategoryGetDTO> GetByIdAsync(Guid id);
        Task<List<ExpenseCategoryGetDTO>> GetAsync(Expression<Func<ExpenseCategory, bool>> filter);
        Task<bool> SoftDeleteAsync(Guid id);
        Task<ExpenseCategoryGetDTO> UpdateAsync(Guid id, ExpenseCategoryUpdateDTO ExpenseCategory);
    }
}
