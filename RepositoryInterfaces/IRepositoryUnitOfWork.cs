using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces
{
    public interface IRepositoryUnitOfWork
    {
        public IExpenceRepository Expence { get; }
        public IExpenceCategoryRepository ExpenceCategory { get; }
        public Task<bool> Save();
    }
}
