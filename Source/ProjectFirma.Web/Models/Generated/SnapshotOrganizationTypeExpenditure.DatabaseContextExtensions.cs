//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SnapshotOrganizationTypeExpenditure]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static SnapshotOrganizationTypeExpenditure GetSnapshotOrganizationTypeExpenditure(this IQueryable<SnapshotOrganizationTypeExpenditure> snapshotOrganizationTypeExpenditures, int snapshotOrganizationTypeExpenditureID)
        {
            var snapshotOrganizationTypeExpenditure = snapshotOrganizationTypeExpenditures.SingleOrDefault(x => x.SnapshotOrganizationTypeExpenditureID == snapshotOrganizationTypeExpenditureID);
            Check.RequireNotNullThrowNotFound(snapshotOrganizationTypeExpenditure, "SnapshotOrganizationTypeExpenditure", snapshotOrganizationTypeExpenditureID);
            return snapshotOrganizationTypeExpenditure;
        }

        public static void DeleteSnapshotOrganizationTypeExpenditure(this List<int> snapshotOrganizationTypeExpenditureIDList)
        {
            if(snapshotOrganizationTypeExpenditureIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllSnapshotOrganizationTypeExpenditures.RemoveRange(HttpRequestStorage.DatabaseEntities.SnapshotOrganizationTypeExpenditures.Where(x => snapshotOrganizationTypeExpenditureIDList.Contains(x.SnapshotOrganizationTypeExpenditureID)));
            }
        }

        public static void DeleteSnapshotOrganizationTypeExpenditure(this ICollection<SnapshotOrganizationTypeExpenditure> snapshotOrganizationTypeExpendituresToDelete)
        {
            if(snapshotOrganizationTypeExpendituresToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllSnapshotOrganizationTypeExpenditures.RemoveRange(snapshotOrganizationTypeExpendituresToDelete);
            }
        }

        public static void DeleteSnapshotOrganizationTypeExpenditure(this int snapshotOrganizationTypeExpenditureID)
        {
            DeleteSnapshotOrganizationTypeExpenditure(new List<int> { snapshotOrganizationTypeExpenditureID });
        }

        public static void DeleteSnapshotOrganizationTypeExpenditure(this SnapshotOrganizationTypeExpenditure snapshotOrganizationTypeExpenditureToDelete)
        {
            DeleteSnapshotOrganizationTypeExpenditure(new List<SnapshotOrganizationTypeExpenditure> { snapshotOrganizationTypeExpenditureToDelete });
        }
    }
}