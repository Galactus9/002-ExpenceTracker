using Application.Services.Interfaces;
using RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IServicesUnitOfWork
    {
        public IExpenseService Expense { get;}
        public IExpenseCategoryService ExpenseCategory { get;}
        public IChartService Chart { get;}

    }
}
