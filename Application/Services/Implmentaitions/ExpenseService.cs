using Application.DTOs.ExpenseDTO;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Models;
using RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Application.Services.Implmentaitions
{
    public class ExpenseService : IExpenseService
    {
        private IMapper _mapper;
        private IRepositoryUnitOfWork _repoUOW;

        public ExpenseService(IMapper mapper, IRepositoryUnitOfWork repoUOW)
        {
            _mapper = mapper;
            _repoUOW = repoUOW;
        }

        public async Task<ExpenseGetDTO> CreateAsync(ExpenseCreateDTO Expense)
        {
            try
            {
                Expense mappedExpense = _mapper.Map<Expense>(Expense);
                mappedExpense.CreatedOn = DateTime.Now;
                mappedExpense.IsActive = true;
                mappedExpense.IsDeleted = false;
                await _repoUOW.Expense.InsertAsync(mappedExpense);
                await _repoUOW.Save();
                return _mapper.Map<ExpenseGetDTO>(mappedExpense);
            }
            catch (Exception ex)
            {
                throw new Exception(message: $"An error occurred while creating the Expense: {ex.Message}");
            }
        }
        public async Task<ExpenseGetDTO> GetByIdAsync(Guid id)
        {
            try
            {
                Expense result = await _repoUOW.Expense.GetByIdAsync(id);
                // Here we have to add || IsApproved == false when we add roles
                if (result is null)
                {
                    throw new Exception("No active application found!");
                }
                return _mapper.Map<ExpenseGetDTO>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(message: $"An error occurred while retrieving the Expense: {ex.Message}");
            }
        }
        public async Task<List<ExpenseGetDTO>> GetAsync(Expression<Func<Expense, bool>> filter)
        {
            try
            {
                List<Expense> result = await _repoUOW.Expense.GetAllAsync(filter);

                if (result is null || result.Count is 0)
                {
                    throw new Exception(message: "No active application found!");
                }

                return _mapper.Map<List<ExpenseGetDTO>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(message: $"No active application found: {ex.Message}");
            }
        }
        public async Task<List<ExpenseGetDTO>> GetWithDetailsAsync(Expression<Func<Expense, bool>> filter)
        {
            try
            {
                List<Expense> result = await _repoUOW.Expense.GetWithDetailsAsync(filter);

                if (result is null || result.Count is 0)
                {
                    throw new Exception(message: "No active application found!");
                }

                return _mapper.Map<List<ExpenseGetDTO>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(message: $"No active application found: {ex.Message}");
            }
        }
        public async Task<bool> SoftDeleteAsync(Guid id)
        {
            try
            {
                Expense result = await _repoUOW.Expense.GetByIdAsync(id);
                // Here we have to add || IsApproved == false when we add roles
                if (result is null)
                {
                    throw new Exception("No active application found!");
                }
                result.IsActive = false;
                result.IsDeleted = true;
                result.DeletedOn = DateTime.Now;
                //result.DeletedBy =

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(message: $"An error occurred while retrieving the Expense: {ex.Message}");
            }
        }
        public async Task<ExpenseGetDTO> UpdateAsync(Guid id, ExpenseUpdateDTO Expense)
        {
            try
            {
                var ExpenseToBeUpdated = await _repoUOW.Expense.GetByIdAsync(id);

                if (ExpenseToBeUpdated == null)
                {
                    // Application with the specified ID was not found
                    throw new Exception($"Application with ID '{id}' not found.");
                }

                _mapper.Map(Expense, ExpenseToBeUpdated);
                ExpenseToBeUpdated.UpdatedOn = DateTime.UtcNow;
                //ExpenseToBeUpdated.UpdatedBy = 

                Expense updatedExpense = _repoUOW.Expense.Update(ExpenseToBeUpdated);
                await _repoUOW.Save();

                return _mapper.Map<ExpenseGetDTO>(updatedExpense);  
            }

            catch (Exception ex)
            {
                // Handle the exception here
                throw new Exception($"An error occurred while updating the application: {ex.Message}");
            }
        }

    }
}
