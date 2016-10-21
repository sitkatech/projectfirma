//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TdrTransactionECMRetirement]
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
        public static TdrTransactionECMRetirement GetTdrTransactionECMRetirement(this IQueryable<TdrTransactionECMRetirement> tdrTransactionECMRetirements, int tdrTransactionECMRetirementID)
        {
            var tdrTransactionECMRetirement = tdrTransactionECMRetirements.SingleOrDefault(x => x.TdrTransactionECMRetirementID == tdrTransactionECMRetirementID);
            Check.RequireNotNullThrowNotFound(tdrTransactionECMRetirement, "TdrTransactionECMRetirement", tdrTransactionECMRetirementID);
            return tdrTransactionECMRetirement;
        }

        public static void DeleteTdrTransactionECMRetirement(this IQueryable<TdrTransactionECMRetirement> tdrTransactionECMRetirements, List<int> tdrTransactionECMRetirementIDList)
        {
            if(tdrTransactionECMRetirementIDList.Any())
            {
                tdrTransactionECMRetirements.Where(x => tdrTransactionECMRetirementIDList.Contains(x.TdrTransactionECMRetirementID)).Delete();
            }
        }

        public static void DeleteTdrTransactionECMRetirement(this IQueryable<TdrTransactionECMRetirement> tdrTransactionECMRetirements, ICollection<TdrTransactionECMRetirement> tdrTransactionECMRetirementsToDelete)
        {
            if(tdrTransactionECMRetirementsToDelete.Any())
            {
                var tdrTransactionECMRetirementIDList = tdrTransactionECMRetirementsToDelete.Select(x => x.TdrTransactionECMRetirementID).ToList();
                tdrTransactionECMRetirements.Where(x => tdrTransactionECMRetirementIDList.Contains(x.TdrTransactionECMRetirementID)).Delete();
            }
        }

        public static void DeleteTdrTransactionECMRetirement(this IQueryable<TdrTransactionECMRetirement> tdrTransactionECMRetirements, int tdrTransactionECMRetirementID)
        {
            DeleteTdrTransactionECMRetirement(tdrTransactionECMRetirements, new List<int> { tdrTransactionECMRetirementID });
        }

        public static void DeleteTdrTransactionECMRetirement(this IQueryable<TdrTransactionECMRetirement> tdrTransactionECMRetirements, TdrTransactionECMRetirement tdrTransactionECMRetirementToDelete)
        {
            DeleteTdrTransactionECMRetirement(tdrTransactionECMRetirements, new List<TdrTransactionECMRetirement> { tdrTransactionECMRetirementToDelete });
        }
    }
}