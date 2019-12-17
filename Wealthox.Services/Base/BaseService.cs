using System;
using System.Collections.Generic;
using System.Text;
using Wealthox.DataAccess.UnitOfWork;

namespace Wealthox.Services.Base
{
    public class BaseService : IDisposable
    {
        protected readonly WealthoxUnitOfWork UnitOfWork;

        public BaseService(WealthoxUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
