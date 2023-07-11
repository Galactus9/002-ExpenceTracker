using Application.DTOs.ChartModels;
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
            List<ChartModel> result = await _unitOfWorkServices.Chart.GetChartData();
            return Ok(result);
        }
    }
}
