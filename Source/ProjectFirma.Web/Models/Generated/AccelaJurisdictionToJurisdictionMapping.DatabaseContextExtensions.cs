//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AccelaJurisdictionToJurisdictionMapping]
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
        public static AccelaJurisdictionToJurisdictionMapping GetAccelaJurisdictionToJurisdictionMapping(this IQueryable<AccelaJurisdictionToJurisdictionMapping> accelaJurisdictionToJurisdictionMappings, int accelaJurisdictionToJurisdictionMappingID)
        {
            var accelaJurisdictionToJurisdictionMapping = accelaJurisdictionToJurisdictionMappings.SingleOrDefault(x => x.AccelaJurisdictionToJurisdictionMappingID == accelaJurisdictionToJurisdictionMappingID);
            Check.RequireNotNullThrowNotFound(accelaJurisdictionToJurisdictionMapping, "AccelaJurisdictionToJurisdictionMapping", accelaJurisdictionToJurisdictionMappingID);
            return accelaJurisdictionToJurisdictionMapping;
        }

        public static void DeleteAccelaJurisdictionToJurisdictionMapping(this IQueryable<AccelaJurisdictionToJurisdictionMapping> accelaJurisdictionToJurisdictionMappings, List<int> accelaJurisdictionToJurisdictionMappingIDList)
        {
            if(accelaJurisdictionToJurisdictionMappingIDList.Any())
            {
                accelaJurisdictionToJurisdictionMappings.Where(x => accelaJurisdictionToJurisdictionMappingIDList.Contains(x.AccelaJurisdictionToJurisdictionMappingID)).Delete();
            }
        }

        public static void DeleteAccelaJurisdictionToJurisdictionMapping(this IQueryable<AccelaJurisdictionToJurisdictionMapping> accelaJurisdictionToJurisdictionMappings, ICollection<AccelaJurisdictionToJurisdictionMapping> accelaJurisdictionToJurisdictionMappingsToDelete)
        {
            if(accelaJurisdictionToJurisdictionMappingsToDelete.Any())
            {
                var accelaJurisdictionToJurisdictionMappingIDList = accelaJurisdictionToJurisdictionMappingsToDelete.Select(x => x.AccelaJurisdictionToJurisdictionMappingID).ToList();
                accelaJurisdictionToJurisdictionMappings.Where(x => accelaJurisdictionToJurisdictionMappingIDList.Contains(x.AccelaJurisdictionToJurisdictionMappingID)).Delete();
            }
        }

        public static void DeleteAccelaJurisdictionToJurisdictionMapping(this IQueryable<AccelaJurisdictionToJurisdictionMapping> accelaJurisdictionToJurisdictionMappings, int accelaJurisdictionToJurisdictionMappingID)
        {
            DeleteAccelaJurisdictionToJurisdictionMapping(accelaJurisdictionToJurisdictionMappings, new List<int> { accelaJurisdictionToJurisdictionMappingID });
        }

        public static void DeleteAccelaJurisdictionToJurisdictionMapping(this IQueryable<AccelaJurisdictionToJurisdictionMapping> accelaJurisdictionToJurisdictionMappings, AccelaJurisdictionToJurisdictionMapping accelaJurisdictionToJurisdictionMappingToDelete)
        {
            DeleteAccelaJurisdictionToJurisdictionMapping(accelaJurisdictionToJurisdictionMappings, new List<AccelaJurisdictionToJurisdictionMapping> { accelaJurisdictionToJurisdictionMappingToDelete });
        }
    }
}