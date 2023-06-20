using Application.Services.Implmentaitions;
using Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServicesUnitOfWork : IServicesUnitOfWork
    {
        public ServicesUnitOfWork()
        {
            Expence = new ExpenceService();
            ExpenceCategory = new ExpenceCategoryService();
        }
        public IExpenceService Expence { get; private set; }
        public IExpenceCategoryService ExpenceCategory { get; private set; }
    }
}
