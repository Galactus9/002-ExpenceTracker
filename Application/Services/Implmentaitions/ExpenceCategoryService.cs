using Application.DTOs.ExpenceCategoryDTO;
using Application.DTOs.ExpenceDTO;
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
    public class ExpenceCategoryService : IExpenceCategoryService
    {
        private IMapper _mapper;
        private IRepositoryUnitOfWork _repoUOW;
        public async Task<ExpenceCategoryGetDTO> CreateAsync(ExpenceCategoryCreateDTO expenceCategory)
        {
            try
            {
                ExpenceCategory mappedExpenceCategory = _mapper.Map<ExpenceCategory>(expenceCategory);
                mappedExpenceCategory.CreatedOn = DateTime.Now;
                mappedExpenceCategory.IsActive = true;
                mappedExpenceCategory.IsDeleted = false;
                ExpenceCategory result = await _repoUOW.ExpenceCategory.InsertAsync(mappedExpenceCategory);
                await _repoUOW.Save();
                return _mapper.Map<ExpenceCategoryGetDTO>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(message: $"An error occurred while creating the ExpenceCategory: {ex.Message}");
            }
        }

        public async Task<ExpenceCategoryGetDTO> GetByIdAsync(Guid id)
        {
            try
            {
                ExpenceCategory result = await _repoUOW.ExpenceCategory.GetByIdAsync(id);
                // Here we have to add || IsApproved == false when we add roles
                if (result is null)
                {
                    throw new Exception("No active application found!");
                }
                return _mapper.Map<ExpenceCategoryGetDTO>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(message: $"An error occurred while retrieving the Expence: {ex.Message}");
            }
        }

        public async Task<List<ExpenceCategoryGetDTO>> GetWithDetailsAsync(Expression<Func<ExpenceCategory, bool>> filter)
        {
            try
            {
                List<ExpenceCategory> result = await _repoUOW.ExpenceCategory.GetAllAsync(filter);

                if (result is null || result.Count is 0)
                {
                    throw new Exception(message: "No active application found!");
                }

                return _mapper.Map<List<ExpenceCategoryGetDTO>>(result);
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
                ExpenceCategory result = await _repoUOW.ExpenceCategory.GetByIdAsync(id);
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
                throw new Exception(message: $"An error occurred while retrieving the Expence: {ex.Message}");
            }
        }

        public async Task<ExpenceCategoryGetDTO> UpdateAsync(Guid id, ExpenceCategoryUpdateDTO expenceCategory)
        {
            try
            {
                ExpenceCategory expenceCategoryToBeUpdated = await _repoUOW.ExpenceCategory.GetByIdAsync(id);

                if (expenceCategoryToBeUpdated == null)
                {
                    // Application with the specified ID was not found
                    throw new Exception($"Application with ID '{id}' not found.");
                }

                _mapper.Map(expenceCategory, expenceCategoryToBeUpdated);
                expenceCategoryToBeUpdated.UpdatedOn = DateTime.UtcNow;
                //expenceToBeUpdated.UpdatedBy = 

                ExpenceCategory updatedExpenceCategory = _repoUOW.ExpenceCategory.Update(expenceCategoryToBeUpdated);
                await _repoUOW.Save();

                return _mapper.Map<ExpenceCategoryGetDTO>(updatedExpenceCategory);
            }

            catch (Exception ex)
            {
                // Handle the exception here
                throw new Exception($"An error occurred while updating the application: {ex.Message}");
            }
        }
    }
}
