using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;

namespace ProjectFirma.Web.ScheduledJobs
{
    public class CleanUpStaleFirmaSessionsJob : ScheduledBackgroundJobBase
    {
        public new const string JobName = "Clean Stale Firma Sessions";

        public override List<FirmaEnvironmentType> RunEnvironments => new List<FirmaEnvironmentType>
        {
            FirmaEnvironmentType.Local,
            FirmaEnvironmentType.Prod,
            FirmaEnvironmentType.Qa
        };

        protected override void RunJobImplementation()
        {
            CleanStaleSessionsImpl();
        }

        protected bool FirmaSessionIsStale(FirmaSession firmaSession)
        {
            if (firmaSession.LastActivityDate == null)
            {
                // If just created, we assume Session isn't stale
                return false;
            }

            var currentDateTime = DateTime.Now;

            var maximumTimeToKeepFirmaSessionWithoutActivity = new TimeSpan(24, 0, 0);
            TimeSpan sessionAge = currentDateTime - firmaSession.LastActivityDate.Value;

            bool isStale = sessionAge > maximumTimeToKeepFirmaSessionWithoutActivity;
            return isStale;
        }

        protected virtual void CleanStaleSessionsImpl()
        {
            Logger.Info($"Cleaning stale FirmaSessions ('{JobName}').");

            // This is "tenant-agnostic" because we are deleting ALL stale FirmaSessions across all Tenants.
            var allFirmaSessions = DbContext.AllFirmaSessions.ToList();
            var staleFirmaSessions = allFirmaSessions.Where(FirmaSessionIsStale).ToList();

            foreach (var staleFirmaSession in staleFirmaSessions)
            {
                SitkaHttpApplication.Logger.Info($"Cleaning up stale FirmaSession {staleFirmaSession.FirmaSessionGuid}: Tenant: {staleFirmaSession.Tenant.TenantName} (TenantID {staleFirmaSession.Tenant.TenantID}) Person: {staleFirmaSession.Person.GetFullNameFirstLast()} Organization: {staleFirmaSession.Person.Organization.OrganizationName}  LastActivityDate: {staleFirmaSession.LastActivityDate} ");
                int tenantID = staleFirmaSession.TenantID;
                staleFirmaSession.Delete(DbContext);
                DbContext.SaveChangesWithNoAuditing(tenantID);
            }

        }
    }
}

