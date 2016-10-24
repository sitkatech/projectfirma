//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ActionPriorityImage]
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
        public static ActionPriorityImage GetActionPriorityImage(this IQueryable<ActionPriorityImage> actionPriorityImages, int actionPriorityImageID)
        {
            var actionPriorityImage = actionPriorityImages.SingleOrDefault(x => x.ActionPriorityImageID == actionPriorityImageID);
            Check.RequireNotNullThrowNotFound(actionPriorityImage, "ActionPriorityImage", actionPriorityImageID);
            return actionPriorityImage;
        }

        public static void DeleteActionPriorityImage(this IQueryable<ActionPriorityImage> actionPriorityImages, List<int> actionPriorityImageIDList)
        {
            if(actionPriorityImageIDList.Any())
            {
                actionPriorityImages.Where(x => actionPriorityImageIDList.Contains(x.ActionPriorityImageID)).Delete();
            }
        }

        public static void DeleteActionPriorityImage(this IQueryable<ActionPriorityImage> actionPriorityImages, ICollection<ActionPriorityImage> actionPriorityImagesToDelete)
        {
            if(actionPriorityImagesToDelete.Any())
            {
                var actionPriorityImageIDList = actionPriorityImagesToDelete.Select(x => x.ActionPriorityImageID).ToList();
                actionPriorityImages.Where(x => actionPriorityImageIDList.Contains(x.ActionPriorityImageID)).Delete();
            }
        }

        public static void DeleteActionPriorityImage(this IQueryable<ActionPriorityImage> actionPriorityImages, int actionPriorityImageID)
        {
            DeleteActionPriorityImage(actionPriorityImages, new List<int> { actionPriorityImageID });
        }

        public static void DeleteActionPriorityImage(this IQueryable<ActionPriorityImage> actionPriorityImages, ActionPriorityImage actionPriorityImageToDelete)
        {
            DeleteActionPriorityImage(actionPriorityImages, new List<ActionPriorityImage> { actionPriorityImageToDelete });
        }
    }
}