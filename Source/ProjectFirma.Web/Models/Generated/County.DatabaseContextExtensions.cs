//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[County]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static County GetCounty(this IQueryable<County> counties, int countyID)
        {
            var county = counties.SingleOrDefault(x => x.CountyID == countyID);
            Check.RequireNotNullThrowNotFound(county, "County", countyID);
            return county;
        }

        public static void DeleteCounty(this List<int> countyIDList)
        {
            if(countyIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllCounties.RemoveRange(HttpRequestStorage.DatabaseEntities.Counties.Where(x => countyIDList.Contains(x.CountyID)));
            }
        }

        public static void DeleteCounty(this ICollection<County> countiesToDelete)
        {
            if(countiesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllCounties.RemoveRange(countiesToDelete);
            }
        }

        public static void DeleteCounty(this int countyID)
        {
            DeleteCounty(new List<int> { countyID });
        }

        public static void DeleteCounty(this County countyToDelete)
        {
            DeleteCounty(new List<County> { countyToDelete });
        }
    }
}