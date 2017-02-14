//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectImage]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProposedProjectImage GetProposedProjectImage(this IQueryable<ProposedProjectImage> proposedProjectImages, int proposedProjectImageID)
        {
            var proposedProjectImage = proposedProjectImages.SingleOrDefault(x => x.ProposedProjectImageID == proposedProjectImageID);
            Check.RequireNotNullThrowNotFound(proposedProjectImage, "ProposedProjectImage", proposedProjectImageID);
            return proposedProjectImage;
        }

        public static void DeleteProposedProjectImage(this List<int> proposedProjectImageIDList)
        {
            if(proposedProjectImageIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProposedProjectImages.RemoveRange(HttpRequestStorage.DatabaseEntities.ProposedProjectImages.Where(x => proposedProjectImageIDList.Contains(x.ProposedProjectImageID)));
            }
        }

        public static void DeleteProposedProjectImage(this ICollection<ProposedProjectImage> proposedProjectImagesToDelete)
        {
            if(proposedProjectImagesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProposedProjectImages.RemoveRange(proposedProjectImagesToDelete);
            }
        }

        public static void DeleteProposedProjectImage(this int proposedProjectImageID)
        {
            DeleteProposedProjectImage(new List<int> { proposedProjectImageID });
        }

        public static void DeleteProposedProjectImage(this ProposedProjectImage proposedProjectImageToDelete)
        {
            DeleteProposedProjectImage(new List<ProposedProjectImage> { proposedProjectImageToDelete });
        }
    }
}