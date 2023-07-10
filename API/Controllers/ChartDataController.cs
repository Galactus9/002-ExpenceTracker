using Application.DTOs.ExpenseCategoryDTO;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartDataController : ControllerBase
    {
        private IServicesUnitOfWork _unitOfWorkServices;

        public ChartDataController(IServicesUnitOfWork unitOfWorkServices)
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
    }
}
