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
using static System.Net.Mime.MediaTypeNames;

namespace Application.Services.Implmentaitions
{
    internal class ExpenceService : IExpenceService
    {
        private IMapper _mapper;
        private IRepositoryUnitOfWork _repoUOW;
        public async Task<ExpenceGetDTO> CreateAsync(ExpenceCreateDTO expence)
        {
            try
            {
                Expence mappedExpence = _mapper.Map<Expence>(expence);
                mappedExpence.CreatedOn = DateTime.Now;
                mappedExpence.IsActive = true;
                mappedExpence.IsDeleted = false;
                Expence result = await _repoUOW.Expence.InsertAsync(mappedExpence);
                await _repoUOW.Save();
                return _mapper.Map<ExpenceGetDTO>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(message: $"An error occurred while creating the Expence: {ex.Message}");
            }
        }

        public async Task<ExpenceGetDTO> GetByIdAsync(Guid id)
        {
            try
            {
                Expence result = await _repoUOW.Expence.GetByIdAsync(id);
                // Here we have to add || IsApproved == false when we add roles
                if (result is null)
                {
                    throw new Exception("No active application found!");
                }
                return _mapper.Map<ExpenceGetDTO>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(message: $"An error occurred while retrieving the Expence: {ex.Message}");
            }
        }

        public async Task<List<ExpenceGetDTO>> GetWithDetailsAsync(Expression<Func<Expence, bool>> filter)
        {
            try
            {
                List<Expence> result = await _repoUOW.Expence.GetAllAsync(filter);

                if (result is null || result.Count is 0)
                {
                    throw new Exception(message: "No active application found!");
                }

                return _mapper.Map<List<ExpenceGetDTO>>(result);
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
                Expence result = await _repoUOW.Expence.GetByIdAsync(id);
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

        public async Task<ExpenceGetDTO> UpdateAsync(Guid id, ExpenceUpdateDTO expence)
        {
            try
            {
                var expenceToBeUpdated = await _repoUOW.Expence.GetByIdAsync(id);

                if (expenceToBeUpdated == null)
                {
                    // Application with the specified ID was not found
                    throw new Exception($"Application with ID '{id}' not found.");
                }

                _mapper.Map(expence, expenceToBeUpdated);
                expenceToBeUpdated.UpdatedOn = DateTime.UtcNow;
                //expenceToBeUpdated.UpdatedBy = 

                Expence updatedExpence = _repoUOW.Expence.Update(expenceToBeUpdated);
                await _repoUOW.Save();

                return _mapper.Map<ExpenceGetDTO>(updatedExpence);  
            }

            catch (Exception ex)
            {
                // Handle the exception here
                throw new Exception($"An error occurred while updating the application: {ex.Message}");
            }
        }

    }
}
