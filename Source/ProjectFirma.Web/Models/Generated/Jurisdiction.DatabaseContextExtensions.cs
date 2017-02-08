//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Jurisdiction]
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
        public static Jurisdiction GetJurisdiction(this IQueryable<Jurisdiction> jurisdictions, int jurisdictionID)
        {
            var jurisdiction = jurisdictions.SingleOrDefault(x => x.JurisdictionID == jurisdictionID);
            Check.RequireNotNullThrowNotFound(jurisdiction, "Jurisdiction", jurisdictionID);
            return jurisdiction;
        }

        public static void DeleteJurisdiction(this IQueryable<Jurisdiction> jurisdictions, List<int> jurisdictionIDList)
        {
            if(jurisdictionIDList.Any())
            {
                jurisdictions.Where(x => jurisdictionIDList.Contains(x.JurisdictionID)).Delete();
            }
        }

        public static void DeleteJurisdiction(this IQueryable<Jurisdiction> jurisdictions, ICollection<Jurisdiction> jurisdictionsToDelete)
        {
            if(jurisdictionsToDelete.Any())
            {
                var jurisdictionIDList = jurisdictionsToDelete.Select(x => x.JurisdictionID).ToList();
                jurisdictions.Where(x => jurisdictionIDList.Contains(x.JurisdictionID)).Delete();
            }
        }

        public static void DeleteJurisdiction(this IQueryable<Jurisdiction> jurisdictions, int jurisdictionID)
        {
            DeleteJurisdiction(jurisdictions, new List<int> { jurisdictionID });
        }

        public static void DeleteJurisdiction(this IQueryable<Jurisdiction> jurisdictions, Jurisdiction jurisdictionToDelete)
        {
            DeleteJurisdiction(jurisdictions, new List<Jurisdiction> { jurisdictionToDelete });
        }
    }
}