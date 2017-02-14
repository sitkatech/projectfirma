//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[StateProvince]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static StateProvince GetStateProvince(this IQueryable<StateProvince> stateProvinces, int stateProvinceID)
        {
            var stateProvince = stateProvinces.SingleOrDefault(x => x.StateProvinceID == stateProvinceID);
            Check.RequireNotNullThrowNotFound(stateProvince, "StateProvince", stateProvinceID);
            return stateProvince;
        }

        public static void DeleteStateProvince(this List<int> stateProvinceIDList)
        {
            if(stateProvinceIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllStateProvinces.RemoveRange(HttpRequestStorage.DatabaseEntities.StateProvinces.Where(x => stateProvinceIDList.Contains(x.StateProvinceID)));
            }
        }

        public static void DeleteStateProvince(this ICollection<StateProvince> stateProvincesToDelete)
        {
            if(stateProvincesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllStateProvinces.RemoveRange(stateProvincesToDelete);
            }
        }

        public static void DeleteStateProvince(this int stateProvinceID)
        {
            DeleteStateProvince(new List<int> { stateProvinceID });
        }

        public static void DeleteStateProvince(this StateProvince stateProvinceToDelete)
        {
            DeleteStateProvince(new List<StateProvince> { stateProvinceToDelete });
        }
    }
}