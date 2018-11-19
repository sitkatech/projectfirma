//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[StaffTimeActivity]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static StaffTimeActivity GetStaffTimeActivity(this IQueryable<StaffTimeActivity> staffTimeActivities, int staffTimeActivityID)
        {
            var staffTimeActivity = staffTimeActivities.SingleOrDefault(x => x.StaffTimeActivityID == staffTimeActivityID);
            Check.RequireNotNullThrowNotFound(staffTimeActivity, "StaffTimeActivity", staffTimeActivityID);
            return staffTimeActivity;
        }

        public static void DeleteStaffTimeActivity(this List<int> staffTimeActivityIDList)
        {
            if(staffTimeActivityIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllStaffTimeActivities.RemoveRange(HttpRequestStorage.DatabaseEntities.StaffTimeActivities.Where(x => staffTimeActivityIDList.Contains(x.StaffTimeActivityID)));
            }
        }

        public static void DeleteStaffTimeActivity(this ICollection<StaffTimeActivity> staffTimeActivitiesToDelete)
        {
            if(staffTimeActivitiesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllStaffTimeActivities.RemoveRange(staffTimeActivitiesToDelete);
            }
        }

        public static void DeleteStaffTimeActivity(this int staffTimeActivityID)
        {
            DeleteStaffTimeActivity(new List<int> { staffTimeActivityID });
        }

        public static void DeleteStaffTimeActivity(this StaffTimeActivity staffTimeActivityToDelete)
        {
            DeleteStaffTimeActivity(new List<StaffTimeActivity> { staffTimeActivityToDelete });
        }
    }
}