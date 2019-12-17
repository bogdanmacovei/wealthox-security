using System;
using System.Collections.Generic;
using System.Linq;
using Wealthox.DataAccess.Data;
using Wealthox.DataAccess.UnitOfWork;
using Wealthox.Entities;
using Wealthox.Services.Base;

namespace Wealthox.Services
{
    public class ConstructionMaterialService : BaseService
    {
        public ConstructionMaterialService(WealthoxUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public List<ConstructionMaterial> GetConstructionMaterials()
        {
            return UnitOfWork.ConstructionMaterials.Query.ToList();
        }
    }
}
