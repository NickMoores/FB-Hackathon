using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITN.Felicity.EntityFramework
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly FelicityContext dbContext;

        public UnitOfWork(FelicityContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            this.dbContext = dbContext;
        }

        public Task SaveChangesAsync() => this.dbContext.SaveChangesAsync();
    }
}
