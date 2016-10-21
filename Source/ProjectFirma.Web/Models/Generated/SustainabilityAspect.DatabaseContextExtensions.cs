//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SustainabilityAspect]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static SustainabilityAspect GetSustainabilityAspect(this IQueryable<SustainabilityAspect> sustainabilityAspects, int sustainabilityAspectID)
        {
            var sustainabilityAspect = sustainabilityAspects.SingleOrDefault(x => x.SustainabilityAspectID == sustainabilityAspectID);
            Check.RequireNotNullThrowNotFound(sustainabilityAspect, "SustainabilityAspect", sustainabilityAspectID);
            return sustainabilityAspect;
        }

        public static void DeleteSustainabilityAspect(this IQueryable<SustainabilityAspect> sustainabilityAspects, List<int> sustainabilityAspectIDList)
        {
            if(sustainabilityAspectIDList.Any())
            {
                sustainabilityAspects.Where(x => sustainabilityAspectIDList.Contains(x.SustainabilityAspectID)).Delete();
            }
        }

        public static void DeleteSustainabilityAspect(this IQueryable<SustainabilityAspect> sustainabilityAspects, ICollection<SustainabilityAspect> sustainabilityAspectsToDelete)
        {
            if(sustainabilityAspectsToDelete.Any())
            {
                var sustainabilityAspectIDList = sustainabilityAspectsToDelete.Select(x => x.SustainabilityAspectID).ToList();
                sustainabilityAspects.Where(x => sustainabilityAspectIDList.Contains(x.SustainabilityAspectID)).Delete();
            }
        }

        public static void DeleteSustainabilityAspect(this IQueryable<SustainabilityAspect> sustainabilityAspects, int sustainabilityAspectID)
        {
            DeleteSustainabilityAspect(sustainabilityAspects, new List<int> { sustainabilityAspectID });
        }

        public static void DeleteSustainabilityAspect(this IQueryable<SustainabilityAspect> sustainabilityAspects, SustainabilityAspect sustainabilityAspectToDelete)
        {
            DeleteSustainabilityAspect(sustainabilityAspects, new List<SustainabilityAspect> { sustainabilityAspectToDelete });
        }
    }
}