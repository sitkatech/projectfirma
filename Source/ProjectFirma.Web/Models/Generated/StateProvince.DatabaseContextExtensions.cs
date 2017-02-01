//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[StateProvince]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
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

        public static void DeleteStateProvince(this IQueryable<StateProvince> stateProvinces, List<int> stateProvinceIDList)
        {
            if(stateProvinceIDList.Any())
            {
                stateProvinces.Where(x => stateProvinceIDList.Contains(x.StateProvinceID)).Delete();
            }
        }

        public static void DeleteStateProvince(this IQueryable<StateProvince> stateProvinces, ICollection<StateProvince> stateProvincesToDelete)
        {
            if(stateProvincesToDelete.Any())
            {
                var stateProvinceIDList = stateProvincesToDelete.Select(x => x.StateProvinceID).ToList();
                stateProvinces.Where(x => stateProvinceIDList.Contains(x.StateProvinceID)).Delete();
            }
        }

        public static void DeleteStateProvince(this IQueryable<StateProvince> stateProvinces, int stateProvinceID)
        {
            DeleteStateProvince(stateProvinces, new List<int> { stateProvinceID });
        }

        public static void DeleteStateProvince(this IQueryable<StateProvince> stateProvinces, StateProvince stateProvinceToDelete)
        {
            DeleteStateProvince(stateProvinces, new List<StateProvince> { stateProvinceToDelete });
        }
    }
}