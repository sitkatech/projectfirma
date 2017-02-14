//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MonitoringProgramPartner]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static MonitoringProgramPartner GetMonitoringProgramPartner(this IQueryable<MonitoringProgramPartner> monitoringProgramPartners, int monitoringProgramPartnerID)
        {
            var monitoringProgramPartner = monitoringProgramPartners.SingleOrDefault(x => x.MonitoringProgramPartnerID == monitoringProgramPartnerID);
            Check.RequireNotNullThrowNotFound(monitoringProgramPartner, "MonitoringProgramPartner", monitoringProgramPartnerID);
            return monitoringProgramPartner;
        }

        public static void DeleteMonitoringProgramPartner(this List<int> monitoringProgramPartnerIDList)
        {
            if(monitoringProgramPartnerIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllMonitoringProgramPartners.RemoveRange(HttpRequestStorage.DatabaseEntities.MonitoringProgramPartners.Where(x => monitoringProgramPartnerIDList.Contains(x.MonitoringProgramPartnerID)));
            }
        }

        public static void DeleteMonitoringProgramPartner(this ICollection<MonitoringProgramPartner> monitoringProgramPartnersToDelete)
        {
            if(monitoringProgramPartnersToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllMonitoringProgramPartners.RemoveRange(monitoringProgramPartnersToDelete);
            }
        }

        public static void DeleteMonitoringProgramPartner(this int monitoringProgramPartnerID)
        {
            DeleteMonitoringProgramPartner(new List<int> { monitoringProgramPartnerID });
        }

        public static void DeleteMonitoringProgramPartner(this MonitoringProgramPartner monitoringProgramPartnerToDelete)
        {
            DeleteMonitoringProgramPartner(new List<MonitoringProgramPartner> { monitoringProgramPartnerToDelete });
        }
    }
}