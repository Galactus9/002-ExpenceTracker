using Application.DTOs.ChartModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IChartService
    {
        Task<List<ChartModel>> GetChartData();
    }
}
