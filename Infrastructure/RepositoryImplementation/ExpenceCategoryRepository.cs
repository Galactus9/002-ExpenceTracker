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
    internal class ExpenceCategoryRepository : GenericRepository<ExpenceCategory>, IExpenceCategoryRepository
    {
        private readonly MyDbContext _dbContext;
        public ExpenceCategoryRepository(MyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
