using Application.DTOs.ExpenseCategoryDTO;
using Application.DTOs.ExpenseDTO;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseCategoryController : ControllerBase
    {
        private IServicesUnitOfWork _unitOfWorkServices;

        public ExpenseCategoryController(IServicesUnitOfWork unitOfWorkServices)
        {
            _unitOfWorkServices = unitOfWorkServices;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<ExpenseCategoryGetDTO>>> GetAll()
        {
            List<ExpenseCategoryGetDTO> result = await _unitOfWorkServices.ExpenseCategory
                .GetAsync(x => x.IsActive == true & x.IsDeleted == false);
            if (result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ExpenseCategoryGetDTO>> GetById(Guid id) // Integration Test ok!
        {
            var result = await _unitOfWorkServices.ExpenseCategory.GetByIdAsync(id);
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<ExpenseCategoryGetDTO>> Create([FromBody] ExpenseCategoryCreateDTO ExpenseCategory) // Integration Test ok!
        {
            var addedExpenseCategory = await _unitOfWorkServices.ExpenseCategory.CreateAsync(ExpenseCategory);
            return Ok(addedExpenseCategory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ExpenseCategoryGetDTO>> Delete(Guid id) // Integration Test ok!
        {

            return Ok(await _unitOfWorkServices.ExpenseCategory.SoftDeleteAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ExpenseCategoryUpdateDTO>> Update(Guid id, [FromBody] ExpenseCategoryUpdateDTO ExpenseCategory)
        {
            if (ModelState.IsValid)
            {
                ExpenseCategoryGetDTO updatedExpenseCategory = await _unitOfWorkServices.ExpenseCategory.UpdateAsync(id, ExpenseCategory);
                return Ok(updatedExpenseCategory);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
