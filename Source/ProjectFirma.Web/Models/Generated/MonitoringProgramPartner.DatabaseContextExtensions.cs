//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MonitoringProgramPartner]
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
        public static MonitoringProgramPartner GetMonitoringProgramPartner(this IQueryable<MonitoringProgramPartner> monitoringProgramPartners, int monitoringProgramPartnerID)
        {
            var monitoringProgramPartner = monitoringProgramPartners.SingleOrDefault(x => x.MonitoringProgramPartnerID == monitoringProgramPartnerID);
            Check.RequireNotNullThrowNotFound(monitoringProgramPartner, "MonitoringProgramPartner", monitoringProgramPartnerID);
            return monitoringProgramPartner;
        }

        public static void DeleteMonitoringProgramPartner(this IQueryable<MonitoringProgramPartner> monitoringProgramPartners, List<int> monitoringProgramPartnerIDList)
        {
            if(monitoringProgramPartnerIDList.Any())
            {
                monitoringProgramPartners.Where(x => monitoringProgramPartnerIDList.Contains(x.MonitoringProgramPartnerID)).Delete();
            }
        }

        public static void DeleteMonitoringProgramPartner(this IQueryable<MonitoringProgramPartner> monitoringProgramPartners, ICollection<MonitoringProgramPartner> monitoringProgramPartnersToDelete)
        {
            if(monitoringProgramPartnersToDelete.Any())
            {
                var monitoringProgramPartnerIDList = monitoringProgramPartnersToDelete.Select(x => x.MonitoringProgramPartnerID).ToList();
                monitoringProgramPartners.Where(x => monitoringProgramPartnerIDList.Contains(x.MonitoringProgramPartnerID)).Delete();
            }
        }

        public static void DeleteMonitoringProgramPartner(this IQueryable<MonitoringProgramPartner> monitoringProgramPartners, int monitoringProgramPartnerID)
        {
            DeleteMonitoringProgramPartner(monitoringProgramPartners, new List<int> { monitoringProgramPartnerID });
        }

        public static void DeleteMonitoringProgramPartner(this IQueryable<MonitoringProgramPartner> monitoringProgramPartners, MonitoringProgramPartner monitoringProgramPartnerToDelete)
        {
            DeleteMonitoringProgramPartner(monitoringProgramPartners, new List<MonitoringProgramPartner> { monitoringProgramPartnerToDelete });
        }
    }
}