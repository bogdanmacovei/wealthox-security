using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Wealthox.DataAccess.Data;

namespace Wealthox.DataAccess.Base
{
    public class BaseUnitOfWork : IUnitOfWork, IDisposable
    {
        protected readonly WealthoxContext DbContext;

        public BaseUnitOfWork(WealthoxContext context)
        {
            this.DbContext = context;
        }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
