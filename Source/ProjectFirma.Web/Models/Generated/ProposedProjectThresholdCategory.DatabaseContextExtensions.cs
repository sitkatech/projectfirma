//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectThresholdCategory]
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
        public static ProposedProjectThresholdCategory GetProposedProjectThresholdCategory(this IQueryable<ProposedProjectThresholdCategory> proposedProjectThresholdCategories, int proposedProjectThresholdCategoryID)
        {
            var proposedProjectThresholdCategory = proposedProjectThresholdCategories.SingleOrDefault(x => x.ProposedProjectThresholdCategoryID == proposedProjectThresholdCategoryID);
            Check.RequireNotNullThrowNotFound(proposedProjectThresholdCategory, "ProposedProjectThresholdCategory", proposedProjectThresholdCategoryID);
            return proposedProjectThresholdCategory;
        }

        public static void DeleteProposedProjectThresholdCategory(this IQueryable<ProposedProjectThresholdCategory> proposedProjectThresholdCategories, List<int> proposedProjectThresholdCategoryIDList)
        {
            if(proposedProjectThresholdCategoryIDList.Any())
            {
                proposedProjectThresholdCategories.Where(x => proposedProjectThresholdCategoryIDList.Contains(x.ProposedProjectThresholdCategoryID)).Delete();
            }
        }

        public static void DeleteProposedProjectThresholdCategory(this IQueryable<ProposedProjectThresholdCategory> proposedProjectThresholdCategories, ICollection<ProposedProjectThresholdCategory> proposedProjectThresholdCategoriesToDelete)
        {
            if(proposedProjectThresholdCategoriesToDelete.Any())
            {
                var proposedProjectThresholdCategoryIDList = proposedProjectThresholdCategoriesToDelete.Select(x => x.ProposedProjectThresholdCategoryID).ToList();
                proposedProjectThresholdCategories.Where(x => proposedProjectThresholdCategoryIDList.Contains(x.ProposedProjectThresholdCategoryID)).Delete();
            }
        }

        public static void DeleteProposedProjectThresholdCategory(this IQueryable<ProposedProjectThresholdCategory> proposedProjectThresholdCategories, int proposedProjectThresholdCategoryID)
        {
            DeleteProposedProjectThresholdCategory(proposedProjectThresholdCategories, new List<int> { proposedProjectThresholdCategoryID });
        }

        public static void DeleteProposedProjectThresholdCategory(this IQueryable<ProposedProjectThresholdCategory> proposedProjectThresholdCategories, ProposedProjectThresholdCategory proposedProjectThresholdCategoryToDelete)
        {
            DeleteProposedProjectThresholdCategory(proposedProjectThresholdCategories, new List<ProposedProjectThresholdCategory> { proposedProjectThresholdCategoryToDelete });
        }
    }
}