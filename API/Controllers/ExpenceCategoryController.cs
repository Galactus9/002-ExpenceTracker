using Application.DTOs.ExpenceCategoryDTO;
using Application.DTOs.ExpenceDTO;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenceCategoryController : ControllerBase
    {
        private IServicesUnitOfWork _unitOfWorkServices;

        public ExpenceCategoryController(IServicesUnitOfWork unitOfWorkServices)
        {
            _unitOfWorkServices = unitOfWorkServices;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<ExpenceCategoryGetDTO>>> GetAll()
        {
            List<ExpenceCategoryGetDTO> result = await _unitOfWorkServices.ExpenceCategory
                .GetAsync(x => x.IsActive == true & x.IsDeleted == false);
            if (result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ExpenceCategoryGetDTO>> GetById(Guid id) // Integration Test ok!
        {
            var result = await _unitOfWorkServices.ExpenceCategory.GetByIdAsync(id);
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<ExpenceCategoryGetDTO>> Create([FromBody] ExpenceCategoryCreateDTO expenceCategory) // Integration Test ok!
        {
            var addedExpenceCategory = await _unitOfWorkServices.ExpenceCategory.CreateAsync(expenceCategory);
            return Ok(addedExpenceCategory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ExpenceCategoryGetDTO>> Delete(Guid id) // Integration Test ok!
        {

            return Ok(await _unitOfWorkServices.ExpenceCategory.SoftDeleteAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ExpenceCategoryUpdateDTO>> Update(Guid id, [FromBody] ExpenceCategoryUpdateDTO expenceCategory)
        {
            if (ModelState.IsValid)
            {
                ExpenceCategoryGetDTO updatedExpenceCategory = await _unitOfWorkServices.ExpenceCategory.UpdateAsync(id, expenceCategory);
                return Ok(updatedExpenceCategory);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
