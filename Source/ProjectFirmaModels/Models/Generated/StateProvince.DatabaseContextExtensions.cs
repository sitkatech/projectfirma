//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[StateProvince]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static StateProvince GetStateProvince(this IQueryable<StateProvince> stateProvinces, int stateProvinceID)
        {
            var stateProvince = stateProvinces.SingleOrDefault(x => x.StateProvinceID == stateProvinceID);
            Check.RequireNotNullThrowNotFound(stateProvince, "StateProvince", stateProvinceID);
            return stateProvince;
        }

    }
}