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
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Transactions;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using SitkaController = ProjectFirma.Web.Common.SitkaController;

namespace ProjectFirma.Web.Models
{
    public partial class DatabaseEntities : SitkaController.ISitkaDbContext
    {
        public int SaveChanges(IPrincipal userPrincipal)
        {
            var person = HttpRequestStorage.Person;
            return SaveChanges(person);
        }

        public int SaveChanges(Person userPerson)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.Snapshot }))
            {
                return SaveChangesImpl(userPerson, HttpRequestStorage.Tenant, scope, false);
            }
        }

        public override int SaveChanges()
        {
            var person = HttpRequestStorage.Person;
            return SaveChanges(person);
        }

        public int SaveChangesWithNoAuditing()
        {
            return base.SaveChanges();
        }
        
        /// <summary>
        /// This will allow persisting even when multiple tenants have been touched in the same context.
        /// DO NOT USE THIS UNLESS YOU KNOW EXACTLY WHAT YOU'RE DOING AND EXACTLY WHY YOU'RE DOING IT.
        /// The literal only use case for this should be that we're running a scheduled job that has to run for all tenants.
        /// If that's not your use case, you should probably reconsider.
        /// </summary>
        public int SaveChangesOverridingTenantBounds()
        {
            var person = HttpRequestStorage.Person;
            return SaveChangesOverridingTenantBounds(person);
        }

        // private so I didn't have to write the warning above twice.
        private int SaveChangesOverridingTenantBounds(Person userPerson)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.Snapshot }))
            {
                return SaveChangesImpl(userPerson, HttpRequestStorage.Tenant, scope, true);
            }
        }

        private int SaveChangesImpl(Person person, Tenant tenant, TransactionScope scope, bool overrideTenantBounds)
        {
            ChangeTracker.DetectChanges();

            var dbEntityEntries = ChangeTracker.Entries().ToList();
            var addedEntries = dbEntityEntries.Where(e => e.State == EntityState.Added).ToList();
            var modifiedEntries = dbEntityEntries.Where(e => e.State == EntityState.Deleted || e.State == EntityState.Modified).ToList();
            var objectContext = GetObjectContext();

            var tenantID = tenant.TenantID;

            /*
             * This is an aggressive check to make sure we're not accidentally doing something like, e.g.,
             * HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceRequests.Load();
             */
            if (!overrideTenantBounds)
            {
                foreach (var entry in dbEntityEntries.Where(entry => entry.Entity is IHaveATenantID))
                {
                    var haveATenantID = entry.Entity as IHaveATenantID;
                    var editingCurrentTenant = haveATenantID != null && haveATenantID.TenantID == tenantID;
                    Check.Assert(editingCurrentTenant,
                        "Editing or accessing an entity across tenant boundaries: " + entry.Entity);
                }
            }

            foreach (var entry in modifiedEntries)
            {
                // For each changed record, get the audit record entries and add them
                var auditRecordsForChange = AuditLog.GetAuditLogRecordsForModifiedOrDeleted(entry, person, objectContext);
                AllAuditLogs.AddRange(auditRecordsForChange);
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
                var auditRecordsForChange = AuditLog.GetAuditLogRecordsForAdded(entry, person, objectContext);
                AllAuditLogs.AddRange(auditRecordsForChange);
            }
            // we need to save the audit log entries now
            base.SaveChanges();

            scope.Complete();
            return changes;
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
