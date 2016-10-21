using System;
using System.Linq;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static SustainabilityAspect GetSustainabilityAspectByName(this IQueryable<SustainabilityAspect> sustainabilityAspects, string sustainabilityAspectName)
        {
            return GetSustainabilityAspectByName(sustainabilityAspects, sustainabilityAspectName, true);
        }

        public static SustainabilityAspect GetSustainabilityAspectByName(this IQueryable<SustainabilityAspect> sustainabilityAspects, string sustainabilityAspectName, bool requireRecordFound)
        {
            var sustainabilityAspect = sustainabilityAspects.SingleOrDefault(x => x.SustainabilityAspectName == sustainabilityAspectName);
            if (requireRecordFound)
            {
                Check.RequireNotNullThrowNotFound(sustainabilityAspect, sustainabilityAspectName);
            }
            return sustainabilityAspect;
        }
    }
}