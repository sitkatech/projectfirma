using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Transactions;
using ProjectFirma.Web.Common;
using LtInfo.Common;
using LtInfo.Common.Models;

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
                return SaveChangesImpl(userPerson, HttpRequestStorage.Tenant, scope);
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

        private int SaveChangesImpl(Person person, Tenant tenant, TransactionScope scope)
        {
            ChangeTracker.DetectChanges();

            var addedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList();
            var modifiedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted || e.State == EntityState.Modified).ToList();
            var objectContext = GetObjectContext();

            var tenantID = tenant.TenantID;
            addedEntries.ForEach(entry =>
            {
                var haveATenantID = entry.Entity as IHaveATenantID;
                if (haveATenantID != null)
                {
                    haveATenantID.TenantID = tenantID;
                }
            });

            foreach (var entry in modifiedEntries)
            {
                // For each changed record, get the audit record entries and add them
                var auditRecordsForChange = AuditLog.GetAuditLogRecordsForModifiedOrDeleted(entry, person, objectContext);
                auditRecordsForChange.ForEach(x => x.TenantID = tenantID);
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
                auditRecordsForChange.ForEach(x => x.TenantID = tenantID);
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