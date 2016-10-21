//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[IndicatorRelationship]
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
        public static IndicatorRelationship GetIndicatorRelationship(this IQueryable<IndicatorRelationship> indicatorRelationships, int indicatorRelationshipID)
        {
            var indicatorRelationship = indicatorRelationships.SingleOrDefault(x => x.IndicatorRelationshipID == indicatorRelationshipID);
            Check.RequireNotNullThrowNotFound(indicatorRelationship, "IndicatorRelationship", indicatorRelationshipID);
            return indicatorRelationship;
        }

        public static void DeleteIndicatorRelationship(this IQueryable<IndicatorRelationship> indicatorRelationships, List<int> indicatorRelationshipIDList)
        {
            if(indicatorRelationshipIDList.Any())
            {
                indicatorRelationships.Where(x => indicatorRelationshipIDList.Contains(x.IndicatorRelationshipID)).Delete();
            }
        }

        public static void DeleteIndicatorRelationship(this IQueryable<IndicatorRelationship> indicatorRelationships, ICollection<IndicatorRelationship> indicatorRelationshipsToDelete)
        {
            if(indicatorRelationshipsToDelete.Any())
            {
                var indicatorRelationshipIDList = indicatorRelationshipsToDelete.Select(x => x.IndicatorRelationshipID).ToList();
                indicatorRelationships.Where(x => indicatorRelationshipIDList.Contains(x.IndicatorRelationshipID)).Delete();
            }
        }

        public static void DeleteIndicatorRelationship(this IQueryable<IndicatorRelationship> indicatorRelationships, int indicatorRelationshipID)
        {
            DeleteIndicatorRelationship(indicatorRelationships, new List<int> { indicatorRelationshipID });
        }

        public static void DeleteIndicatorRelationship(this IQueryable<IndicatorRelationship> indicatorRelationships, IndicatorRelationship indicatorRelationshipToDelete)
        {
            DeleteIndicatorRelationship(indicatorRelationships, new List<IndicatorRelationship> { indicatorRelationshipToDelete });
        }
    }
}