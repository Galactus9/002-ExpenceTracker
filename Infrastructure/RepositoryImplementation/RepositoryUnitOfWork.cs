using dbConnection;
using RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryImplementation
{
    public class RepositoryUnitOfWork : IRepositoryUnitOfWork
    {
        private readonly MyDbContext _db;
        //private readonly IEventBus _eventBus;

        public RepositoryUnitOfWork(MyDbContext db /*IEventBus eventBus*/)
        {
            _db = db;
            //_eventBus = eventBus;
            Expense = new ExpenseRepository(db);
            ExpenseCategory = new ExpenseCategoryRepository(db);
        }

        public IExpenseRepository Expense {get; private set;}

        public IExpenseCategoryRepository ExpenseCategory { get; private set;}

    public async Task<bool> Save()
        {
            try
            {
                //var loggCommands = new List<EntityModifiedCommand>();
                //loggCommands = GetEntityModifiedCommands(_db);
                await _db.SaveChangesAsync();
                //loggCommands.ForEach(command => _eventBus.SendCommand(command));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
