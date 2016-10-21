//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TdrTransactionAllocationAssignment]
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
        public static TdrTransactionAllocationAssignment GetTdrTransactionAllocationAssignment(this IQueryable<TdrTransactionAllocationAssignment> tdrTransactionAllocationAssignments, int tdrTransactionAllocationAssignmentID)
        {
            var tdrTransactionAllocationAssignment = tdrTransactionAllocationAssignments.SingleOrDefault(x => x.TdrTransactionAllocationAssignmentID == tdrTransactionAllocationAssignmentID);
            Check.RequireNotNullThrowNotFound(tdrTransactionAllocationAssignment, "TdrTransactionAllocationAssignment", tdrTransactionAllocationAssignmentID);
            return tdrTransactionAllocationAssignment;
        }

        public static void DeleteTdrTransactionAllocationAssignment(this IQueryable<TdrTransactionAllocationAssignment> tdrTransactionAllocationAssignments, List<int> tdrTransactionAllocationAssignmentIDList)
        {
            if(tdrTransactionAllocationAssignmentIDList.Any())
            {
                tdrTransactionAllocationAssignments.Where(x => tdrTransactionAllocationAssignmentIDList.Contains(x.TdrTransactionAllocationAssignmentID)).Delete();
            }
        }

        public static void DeleteTdrTransactionAllocationAssignment(this IQueryable<TdrTransactionAllocationAssignment> tdrTransactionAllocationAssignments, ICollection<TdrTransactionAllocationAssignment> tdrTransactionAllocationAssignmentsToDelete)
        {
            if(tdrTransactionAllocationAssignmentsToDelete.Any())
            {
                var tdrTransactionAllocationAssignmentIDList = tdrTransactionAllocationAssignmentsToDelete.Select(x => x.TdrTransactionAllocationAssignmentID).ToList();
                tdrTransactionAllocationAssignments.Where(x => tdrTransactionAllocationAssignmentIDList.Contains(x.TdrTransactionAllocationAssignmentID)).Delete();
            }
        }

        public static void DeleteTdrTransactionAllocationAssignment(this IQueryable<TdrTransactionAllocationAssignment> tdrTransactionAllocationAssignments, int tdrTransactionAllocationAssignmentID)
        {
            DeleteTdrTransactionAllocationAssignment(tdrTransactionAllocationAssignments, new List<int> { tdrTransactionAllocationAssignmentID });
        }

        public static void DeleteTdrTransactionAllocationAssignment(this IQueryable<TdrTransactionAllocationAssignment> tdrTransactionAllocationAssignments, TdrTransactionAllocationAssignment tdrTransactionAllocationAssignmentToDelete)
        {
            DeleteTdrTransactionAllocationAssignment(tdrTransactionAllocationAssignments, new List<TdrTransactionAllocationAssignment> { tdrTransactionAllocationAssignmentToDelete });
        }
    }
}