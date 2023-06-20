using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces
{
    /// <summary>
    /// Generic Repository meant to cover the basic CRUD operations as well as a GetAll and Save() function
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<TEntity> where TEntity : class
    {

        /// <summary>
        /// Retrieves all entities of type TEntity from the database.
        /// </summary>
        /// <returns>A list of all retrieved entities.</returns>
        Task<List<TEntity>> GetAllAsync();

        /// <summary>
        /// This method retrieves entities from the database, applying an optional filter expression delegate,
        /// and returns a list of entities that following the filter parameters.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns >
        /// A task that represents the asynchronous operation.
        ///     The task result contains a <see cref="List{T}" /> that contains elements from the input sequence.
        /// </returns>
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Retrieves an entity of type TEntity from the database by its unique identifier.
        /// </summary>
        /// <param name="Id">The unique identifier of the entity to retrieve.</param>
        /// <returns>The retrieved entity.</returns>
        Task<TEntity> GetByIdAsync(Guid Id);

        /// <summary>
        /// Inserts a new entity of type TEntity into the database.
        /// </summary>
        /// <param name="entity">The entity to be inserted.</param>
        /// <returns>The inserted entity.</returns>
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>
        /// Updates an existing entity of type TEntity in the database.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        /// <returns>The updated entity.</returns>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Performs a hard delete of an entity of type TEntity from the database based on its unique identifier.
        /// </summary>
        /// <param name="Id">The unique identifier of the entity to be deleted.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        Task<bool> HardDeleteAsync(Guid Id);
    }
}
