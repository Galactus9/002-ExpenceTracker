using Application.DTOs.ExpenseDTO;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private IServicesUnitOfWork _unitOfWorkServices;

        public ExpenseController(IServicesUnitOfWork unitOfWorkServices)
        {
            _unitOfWorkServices = unitOfWorkServices;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<ExpenseGetDTO>>> GetAll() 
        {
            List<ExpenseGetDTO> result = await _unitOfWorkServices.Expense
                .GetAsync(x => x.IsActive == true & x.IsDeleted == false);
            if (result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<ExpenseGetDTO>>> GetAllWithDetails() // Integration Test ok!
        {
            var result = await _unitOfWorkServices.Expense.GetWithDetailsAsync(x => x.IsActive == true);
            if (result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ExpenseGetDTO>> GetById(Guid id) // Integration Test ok!
        {
            var result = await _unitOfWorkServices.Expense.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ExpenseGetDTO>> GetByIdWithDetails(Guid id) // Integration Test ok!
        {
            var result = await _unitOfWorkServices.Expense.GetWithDetailsAsync(
                x => x.Id == id && x.IsActive == true
                );
            return Ok(result.FirstOrDefault());
        }

        [HttpPost]
        public async Task<ActionResult<ExpenseGetDTO>> Create([FromBody] ExpenseCreateDTO employee) // Integration Test ok!
        {
            var addedEmployee = await _unitOfWorkServices.Expense.CreateAsync(employee);
            return Ok(addedEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ExpenseGetDTO>> Delete(Guid id) // Integration Test ok!
        {

            return Ok(await _unitOfWorkServices.Expense.SoftDeleteAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ExpenseUpdateDTO>> Update(Guid id, [FromBody] ExpenseUpdateDTO employee)
        {
            if (ModelState.IsValid)
            {
                ExpenseGetDTO updatedEmployee = await _unitOfWorkServices.Expense.UpdateAsync(id, employee);
                return Ok(updatedEmployee);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
