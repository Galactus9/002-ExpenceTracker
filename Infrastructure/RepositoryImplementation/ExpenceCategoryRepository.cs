using dbConnection;
using Domain.Models;
using RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryImplementation
{
    internal class ExpenseCategoryRepository : GenericRepository<ExpenseCategory>, IExpenseCategoryRepository
    {
        private readonly MyDbContext _dbContext;
        public ExpenseCategoryRepository(MyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
