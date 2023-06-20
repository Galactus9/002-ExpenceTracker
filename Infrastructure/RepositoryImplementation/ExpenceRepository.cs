using dbConnection;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryImplementation
{
    public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
    {
        private readonly MyDbContext _dbContext;
        public ExpenseRepository(MyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Expense>> GetWithDetailsAsync() 
        {
            try
            {
                return  await _dbContext.Set<Expense>().Include(x => x.ExpenseCategory).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<Expense>> GetWithDetailsAsync(Expression<Func<Expense, bool>> filter) 
        {
            try
            {
                return  await _dbContext.Set<Expense>().Where(filter).Include(x => x.ExpenseCategory).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
