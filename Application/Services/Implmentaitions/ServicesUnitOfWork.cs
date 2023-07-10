using Application.Services.Implmentaitions;
using Application.Services.Interfaces;
using AutoMapper;
using RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServicesUnitOfWork : IServicesUnitOfWork
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryUnitOfWork _unitOfWork;
        public ServicesUnitOfWork(IMapper mapper, IRepositoryUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            Expense = new ExpenseService(_mapper, _unitOfWork);
            ExpenseCategory = new ExpenseCategoryService(_mapper, _unitOfWork);
            Chart = new ChartService(_unitOfWork);
        }
        public IExpenseService Expense { get; private set; }
        public IExpenseCategoryService ExpenseCategory { get; private set; }

        public IChartService Chart { get; private set; }
    }
}
