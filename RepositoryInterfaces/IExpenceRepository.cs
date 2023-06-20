using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces
{
    public interface IExpenseRepository : IGenericRepository<Expense>
    {
        public Task<List<Expense>> GetWithDetailsAsync();
        public Task<List<Expense>> GetWithDetailsAsync(Expression<Func<Expense, bool>> filter);

    }
}
