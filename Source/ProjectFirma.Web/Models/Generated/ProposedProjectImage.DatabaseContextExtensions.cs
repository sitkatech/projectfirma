//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectImage]
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
        public static ProposedProjectImage GetProposedProjectImage(this IQueryable<ProposedProjectImage> proposedProjectImages, int proposedProjectImageID)
        {
            var proposedProjectImage = proposedProjectImages.SingleOrDefault(x => x.ProposedProjectImageID == proposedProjectImageID);
            Check.RequireNotNullThrowNotFound(proposedProjectImage, "ProposedProjectImage", proposedProjectImageID);
            return proposedProjectImage;
        }

        public static void DeleteProposedProjectImage(this IQueryable<ProposedProjectImage> proposedProjectImages, List<int> proposedProjectImageIDList)
        {
            if(proposedProjectImageIDList.Any())
            {
                proposedProjectImages.Where(x => proposedProjectImageIDList.Contains(x.ProposedProjectImageID)).Delete();
            }
        }

        public static void DeleteProposedProjectImage(this IQueryable<ProposedProjectImage> proposedProjectImages, ICollection<ProposedProjectImage> proposedProjectImagesToDelete)
        {
            if(proposedProjectImagesToDelete.Any())
            {
                var proposedProjectImageIDList = proposedProjectImagesToDelete.Select(x => x.ProposedProjectImageID).ToList();
                proposedProjectImages.Where(x => proposedProjectImageIDList.Contains(x.ProposedProjectImageID)).Delete();
            }
        }

        public static void DeleteProposedProjectImage(this IQueryable<ProposedProjectImage> proposedProjectImages, int proposedProjectImageID)
        {
            DeleteProposedProjectImage(proposedProjectImages, new List<int> { proposedProjectImageID });
        }

        public static void DeleteProposedProjectImage(this IQueryable<ProposedProjectImage> proposedProjectImages, ProposedProjectImage proposedProjectImageToDelete)
        {
            DeleteProposedProjectImage(proposedProjectImages, new List<ProposedProjectImage> { proposedProjectImageToDelete });
        }
    }
}