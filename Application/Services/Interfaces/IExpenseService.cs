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
    public interface IExpenseService
    {
        Task<ExpenseGetDTO> CreateAsync(ExpenseCreateDTO Expense);
        Task<ExpenseGetDTO> GetByIdAsync(Guid id);
        Task<List<ExpenseGetDTO>> GetAsync(Expression<Func<Expense, bool>> filter);
        Task<List<ExpenseGetDTO>> GetWithDetailsAsync(Expression<Func<Expense, bool>> filter);
        Task<ExpenseGetDTO> UpdateAsync(Guid id, ExpenseUpdateDTO Expense);
        Task<bool> SoftDeleteAsync(Guid id);
    }
}
