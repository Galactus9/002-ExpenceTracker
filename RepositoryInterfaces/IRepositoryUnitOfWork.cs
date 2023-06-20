using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces
{
    public interface IRepositoryUnitOfWork
    {
        public IExpenseRepository Expense { get; }
        public IExpenseCategoryRepository ExpenseCategory { get; }
        public Task<bool> Save();
    }
}
