using Application.DTOs.ChartModels;
using Application.Services.Interfaces;
using Domain.Models;
using RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implmentaitions
{
    public class ChartService : IChartService
    {
        private IRepositoryUnitOfWork _repoUOW;

        public ChartService(IRepositoryUnitOfWork repoUOW)
        {
            _repoUOW = repoUOW;
        }
        public async Task<List<ChartModel>> GetChartData()
        {
            List<Expense>? expenses = await _repoUOW.Expense.GetWithDetailsAsync();
            List<ChartModel> chartData = expenses
                .GroupBy(e => e.ExpenseCategory)
                .Select(g => new ChartModel
                {
                    Category = g.Key?.Title ?? "Uncategorized",
                    AmountSpend = g.Sum(e => e.Amount ?? 0)
                })
                .ToList();

            return chartData;
        }
    }
}
