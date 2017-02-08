//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[County]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
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

        public static void DeleteCounty(this IQueryable<County> counties, List<int> countyIDList)
        {
            if(countyIDList.Any())
            {
                counties.Where(x => countyIDList.Contains(x.CountyID)).Delete();
            }
        }

        public static void DeleteCounty(this IQueryable<County> counties, ICollection<County> countiesToDelete)
        {
            if(countiesToDelete.Any())
            {
                var countyIDList = countiesToDelete.Select(x => x.CountyID).ToList();
                counties.Where(x => countyIDList.Contains(x.CountyID)).Delete();
            }
        }

        public static void DeleteCounty(this IQueryable<County> counties, int countyID)
        {
            DeleteCounty(counties, new List<int> { countyID });
        }

        public static void DeleteCounty(this IQueryable<County> counties, County countyToDelete)
        {
            DeleteCounty(counties, new List<County> { countyToDelete });
        }
    }
}