//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[County]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static County GetCounty(this IQueryable<County> counties, int countyID)
        {
            var county = counties.SingleOrDefault(x => x.CountyID == countyID);
            Check.RequireNotNullThrowNotFound(county, "County", countyID);
            return county;
        }

    }
}