using dbConnection;
using Domain.AbstractClasses;
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
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : AbstractModel
    {


        private readonly MyDbContext _dbContext;

        public GenericRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TEntity> GetByIdAsync(Guid Id)
        {
            try
            {
                var result = await _dbContext.Set<TEntity>().FindAsync(Id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                List<TEntity> entities = new();

                if (filter != null)
                {
                    return entities = await _dbContext.Set<TEntity>().Where(filter).ToListAsync();
                }
                else
                {
                    entities = await _dbContext.Set<TEntity>().ToListAsync();
                }

                return await _dbContext.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            try
            {
                var result = await _dbContext.Set<TEntity>().AddAsync(entity);
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TEntity Update(TEntity entity)
        {
            try
            {

                var result = _dbContext.Set<TEntity>().Update(entity);
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> HardDeleteAsync(Guid Id)
        {
            try
            {
                var entityToDelete = await GetByIdAsync(Id);
                _dbContext.Set<TEntity>().Remove(entityToDelete);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

