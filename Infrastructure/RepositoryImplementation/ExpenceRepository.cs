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
    public class ExpenceRepository : GenericRepository<Expence>, IExpenceRepository
    {
        private readonly MyDbContext _dbContext;
        public ExpenceRepository(MyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Expence>> GetWithDetailsAsync() 
        {
            try
            {
                return  await _dbContext.Set<Expence>().Include(x => x.ExpenceCategory).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<Expence>> GetWithDetailsAsync(Expression<Func<Expence, bool>> filter) 
        {
            try
            {
                return  await _dbContext.Set<Expence>().Where(filter).Include(x => x.ExpenceCategory).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
