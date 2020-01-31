/*-----------------------------------------------------------------------
<copyright file="DatabaseEntities.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Transactions;
using LtInfo.Common.Mvc;

namespace ProjectFirmaModels.Models
{
    public partial class DatabaseEntities : ISitkaDbContext
    {
        public Person Person { get; set; }

        public int SaveChanges(FirmaSession currentFirmaSession)
        {
            return SaveChanges(currentFirmaSession.Person);
        }

        public int SaveChanges(Person userPerson)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.Snapshot }))
            {
                return SaveChangesImpl(userPerson, userPerson.Tenant, scope);
            }
        }

        public override int SaveChanges()
        {
            return SaveChanges(Person);
        }

        public int SaveChangesWithNoAuditing(int tenantId)
        {
            ChangeTracker.DetectChanges();
            var dbEntityEntries = ChangeTracker.Entries().ToList();
            SetTenantIDForAllModifiedEntries(dbEntityEntries, tenantId);
            return base.SaveChanges();
        }

        private int SaveChangesImpl(Person person, Tenant tenant, TransactionScope scope)
        {
            ChangeTracker.DetectChanges();

            var dbEntityEntries = ChangeTracker.Entries().ToList();
            var addedEntries = dbEntityEntries.Where(e => e.State == EntityState.Added).ToList();
            var modifiedEntries = dbEntityEntries
                .Where(e => e.State == EntityState.Deleted || e.State == EntityState.Modified).ToList();
            
            var tenantID = tenant.TenantID;

            SetTenantIDForAllModifiedEntries(dbEntityEntries, tenantID);

            // Project is such an important piece to PF; if we generate an audit log record that has a ProjectID, we need to update the last update date on the Project
            var projectIDsModified = new List<int>();

            foreach (var entry in modifiedEntries)
            {
                // For each changed record, get the audit record entries and add them
                var auditRecordsForChange =
                    AuditLog.GetAuditLogRecordsForModifiedOrDeleted(entry, person, this, tenantID);
                AllAuditLogs.AddRange(auditRecordsForChange);
                projectIDsModified.AddRange(ExtractProjectIDsFromAuditLogs(auditRecordsForChange));
            }

            int changes;
            try
            {
                changes = base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }

            foreach (var entry in addedEntries)
            {
                // For each added record, get the audit record entries and add them
                var auditRecordsForChange = AuditLog.GetAuditLogRecordsForAdded(entry, person, this, tenantID);
                AllAuditLogs.AddRange(auditRecordsForChange);
                projectIDsModified.AddRange(ExtractProjectIDsFromAuditLogs(auditRecordsForChange));
            }

            // now update LastUpdatedDate of any Projects that were touched
            if (projectIDsModified.Any())
            {
                var projects = Projects.Where(x => projectIDsModified.Distinct().Contains(x.ProjectID));
                foreach (var project in projects)
                {
                    project.LastUpdatedDate = DateTime.Now;
                }
                ChangeTracker.DetectChanges();
            }
            // we need to save the audit log entries now
            base.SaveChanges();

            scope.Complete();
            return changes;
        }

        private static IEnumerable<int> ExtractProjectIDsFromAuditLogs(IEnumerable<AuditLog> auditRecordsForChange)
        {
            var auditLogsWithProjectID = auditRecordsForChange.Where(x => x.ProjectID.HasValue).ToList();
            return auditLogsWithProjectID.Any() ? auditLogsWithProjectID.Select(x => x.ProjectID.Value) : new List<int>();
        }

        private static void SetTenantIDForAllModifiedEntries(List<DbEntityEntry> dbEntityEntries, int tenantID)
        {
            /*
             * This is where we are setting it to the TenantID of the current thread or HttpRequestStorage.Tenant;
             */
            foreach (var entry in dbEntityEntries.Where(entry =>
                (entry.State == EntityState.Added || entry.State == EntityState.Deleted ||
                 entry.State == EntityState.Modified) && entry.Entity is IHaveATenantID))
            {
                if (entry.Entity is IHaveATenantID haveATenantID && haveATenantID.TenantID <= 0)
                {
                    haveATenantID.TenantID = tenantID;
                }
            }
        }

        public DbContext GetDbContext()
        {
            return this;
        }

        public ObjectContext GetObjectContext()
        {
            return ((IObjectContextAdapter) this).ObjectContext;
        }
    }
}
