//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SustainabilityPillar]
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
        public static SustainabilityPillar GetSustainabilityPillar(this IQueryable<SustainabilityPillar> sustainabilityPillars, int sustainabilityPillarID)
        {
            var sustainabilityPillar = sustainabilityPillars.SingleOrDefault(x => x.SustainabilityPillarID == sustainabilityPillarID);
            Check.RequireNotNullThrowNotFound(sustainabilityPillar, "SustainabilityPillar", sustainabilityPillarID);
            return sustainabilityPillar;
        }

        public static void DeleteSustainabilityPillar(this IQueryable<SustainabilityPillar> sustainabilityPillars, List<int> sustainabilityPillarIDList)
        {
            if(sustainabilityPillarIDList.Any())
            {
                sustainabilityPillars.Where(x => sustainabilityPillarIDList.Contains(x.SustainabilityPillarID)).Delete();
            }
        }

        public static void DeleteSustainabilityPillar(this IQueryable<SustainabilityPillar> sustainabilityPillars, ICollection<SustainabilityPillar> sustainabilityPillarsToDelete)
        {
            if(sustainabilityPillarsToDelete.Any())
            {
                var sustainabilityPillarIDList = sustainabilityPillarsToDelete.Select(x => x.SustainabilityPillarID).ToList();
                sustainabilityPillars.Where(x => sustainabilityPillarIDList.Contains(x.SustainabilityPillarID)).Delete();
            }
        }

        public static void DeleteSustainabilityPillar(this IQueryable<SustainabilityPillar> sustainabilityPillars, int sustainabilityPillarID)
        {
            DeleteSustainabilityPillar(sustainabilityPillars, new List<int> { sustainabilityPillarID });
        }

        public static void DeleteSustainabilityPillar(this IQueryable<SustainabilityPillar> sustainabilityPillars, SustainabilityPillar sustainabilityPillarToDelete)
        {
            DeleteSustainabilityPillar(sustainabilityPillars, new List<SustainabilityPillar> { sustainabilityPillarToDelete });
        }
    }
}