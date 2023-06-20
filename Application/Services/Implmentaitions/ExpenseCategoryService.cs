using Application.DTOs.ExpenseCategoryDTO;
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

namespace Application.Services.Implmentaitions
{
    public class ExpenseCategoryService : IExpenseCategoryService
    {
        private IMapper _mapper;
        private IRepositoryUnitOfWork _repoUOW;
        public async Task<ExpenseCategoryGetDTO> CreateAsync(ExpenseCategoryCreateDTO ExpenseCategory)
        {
            try
            {
                ExpenseCategory mappedExpenseCategory = _mapper.Map<ExpenseCategory>(ExpenseCategory);
                mappedExpenseCategory.CreatedOn = DateTime.Now;
                mappedExpenseCategory.IsActive = true;
                mappedExpenseCategory.IsDeleted = false;
                ExpenseCategory result = await _repoUOW.ExpenseCategory.InsertAsync(mappedExpenseCategory);
                await _repoUOW.Save();
                return _mapper.Map<ExpenseCategoryGetDTO>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(message: $"An error occurred while creating the ExpenseCategory: {ex.Message}");
            }
        }

        public async Task<ExpenseCategoryGetDTO> GetByIdAsync(Guid id)
        {
            try
            {
                ExpenseCategory result = await _repoUOW.ExpenseCategory.GetByIdAsync(id);
                // Here we have to add || IsApproved == false when we add roles
                if (result is null)
                {
                    throw new Exception("No active application found!");
                }
                return _mapper.Map<ExpenseCategoryGetDTO>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(message: $"An error occurred while retrieving the Expense: {ex.Message}");
            }
        }

        public async Task<List<ExpenseCategoryGetDTO>> GetAsync(Expression<Func<ExpenseCategory, bool>> filter)
        {
            try
            {
                List<ExpenseCategory> result = await _repoUOW.ExpenseCategory.GetAllAsync(filter);

                if (result is null || result.Count is 0)
                {
                    throw new Exception(message: "No active application found!");
                }

                return _mapper.Map<List<ExpenseCategoryGetDTO>>(result);
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
                ExpenseCategory result = await _repoUOW.ExpenseCategory.GetByIdAsync(id);
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

        public async Task<ExpenseCategoryGetDTO> UpdateAsync(Guid id, ExpenseCategoryUpdateDTO ExpenseCategory)
        {
            try
            {
                ExpenseCategory ExpenseCategoryToBeUpdated = await _repoUOW.ExpenseCategory.GetByIdAsync(id);

                if (ExpenseCategoryToBeUpdated == null)
                {
                    // Application with the specified ID was not found
                    throw new Exception($"Application with ID '{id}' not found.");
                }

                _mapper.Map(ExpenseCategory, ExpenseCategoryToBeUpdated);
                ExpenseCategoryToBeUpdated.UpdatedOn = DateTime.UtcNow;
                //ExpenseToBeUpdated.UpdatedBy = 

                ExpenseCategory updatedExpenseCategory = _repoUOW.ExpenseCategory.Update(ExpenseCategoryToBeUpdated);
                await _repoUOW.Save();

                return _mapper.Map<ExpenseCategoryGetDTO>(updatedExpenseCategory);
            }

            catch (Exception ex)
            {
                // Handle the exception here
                throw new Exception($"An error occurred while updating the application: {ex.Message}");
            }
        }
    }
}
