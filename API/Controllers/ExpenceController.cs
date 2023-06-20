using Application.DTOs.ExpenceDTO;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenceController : ControllerBase
    {
        private IServicesUnitOfWork _unitOfWorkServices;

        public ExpenceController(IServicesUnitOfWork unitOfWorkServices)
        {
            _unitOfWorkServices = unitOfWorkServices;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<ExpenceGetDTO>>> GetAll() 
        {
            List<ExpenceGetDTO> result = await _unitOfWorkServices.Expence
                .GetAsync(x => x.IsActive == true & x.IsDeleted == false);
            if (result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<ExpenceGetDTO>>> GetAllWithDetails() // Integration Test ok!
        {
            var result = await _unitOfWorkServices.Expence.GetWithDetailsAsync(x => x.IsActive == true);
            if (result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ExpenceGetDTO>> GetById(Guid id) // Integration Test ok!
        {
            var result = await _unitOfWorkServices.Expence.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ExpenceGetDTO>> GetByIdWithDetails(Guid id) // Integration Test ok!
        {
            var result = await _unitOfWorkServices.Expence.GetWithDetailsAsync(
                x => x.Id == id && x.IsActive == true
                );
            return Ok(result.FirstOrDefault());
        }

        [HttpPost]
        public async Task<ActionResult<ExpenceGetDTO>> Create([FromBody] ExpenceCreateDTO employee) // Integration Test ok!
        {
            var addedEmployee = await _unitOfWorkServices.Expence.CreateAsync(employee);
            return Ok(addedEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ExpenceGetDTO>> Delete(Guid id) // Integration Test ok!
        {

            return Ok(await _unitOfWorkServices.Expence.SoftDeleteAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ExpenceUpdateDTO>> Update(Guid id, [FromBody] ExpenceUpdateDTO employee)
        {
            if (ModelState.IsValid)
            {
                ExpenceGetDTO updatedEmployee = await _unitOfWorkServices.Expence.UpdateAsync(id, employee);
                return Ok(updatedEmployee);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
