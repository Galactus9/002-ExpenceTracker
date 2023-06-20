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
    public class ExpenceRepository : GenericRepository<Expence>, IExpenceRepository
    {
        private readonly MyDbContext _dbContext;
        public ExpenceRepository(MyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
