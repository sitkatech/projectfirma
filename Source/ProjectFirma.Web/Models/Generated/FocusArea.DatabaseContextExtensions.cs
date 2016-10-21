//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FocusArea]
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
        public static FocusArea GetFocusArea(this IQueryable<FocusArea> focusAreas, int focusAreaID)
        {
            var focusArea = focusAreas.SingleOrDefault(x => x.FocusAreaID == focusAreaID);
            Check.RequireNotNullThrowNotFound(focusArea, "FocusArea", focusAreaID);
            return focusArea;
        }

        public static void DeleteFocusArea(this IQueryable<FocusArea> focusAreas, List<int> focusAreaIDList)
        {
            if(focusAreaIDList.Any())
            {
                focusAreas.Where(x => focusAreaIDList.Contains(x.FocusAreaID)).Delete();
            }
        }

        public static void DeleteFocusArea(this IQueryable<FocusArea> focusAreas, ICollection<FocusArea> focusAreasToDelete)
        {
            if(focusAreasToDelete.Any())
            {
                var focusAreaIDList = focusAreasToDelete.Select(x => x.FocusAreaID).ToList();
                focusAreas.Where(x => focusAreaIDList.Contains(x.FocusAreaID)).Delete();
            }
        }

        public static void DeleteFocusArea(this IQueryable<FocusArea> focusAreas, int focusAreaID)
        {
            DeleteFocusArea(focusAreas, new List<int> { focusAreaID });
        }

        public static void DeleteFocusArea(this IQueryable<FocusArea> focusAreas, FocusArea focusAreaToDelete)
        {
            DeleteFocusArea(focusAreas, new List<FocusArea> { focusAreaToDelete });
        }
    }
}