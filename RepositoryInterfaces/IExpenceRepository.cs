using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces
{
    public interface IExpenceRepository : IGenericRepository<Expence>
    {
        public Task<List<Expence>> GetWithDetailsAsync();
        public Task<List<Expence>> GetWithDetailsAsync(Expression<Func<Expence, bool>> filter);

    }
}
