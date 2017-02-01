using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using LtInfo.Common;
using ProjectFirma.Web.Models;
using Keystone.Common;
using Z.EntityFramework.Plus;
using Person = ProjectFirma.Web.Models.Person;

namespace ProjectFirma.Web.Common
{
    public class HttpRequestStorage : SitkaHttpRequestStorage
    {
        static HttpRequestStorage()
        {
            LtInfoEntityTypeLoaderFactoryFunction = () => MakeNewContext(false);
        }

        protected override List<string> BackingStoreKeys
        {
            get { return new List<string>(); }
        }

        public static Person Person
        {
            get { return GetValueOrDefault(PersonKey, () => KeystoneClaimsHelpers.GetUserFromPrincipal(Thread.CurrentPrincipal, Person.GetAnonymousSitkaUser(), DatabaseEntities.People.GetPersonByPersonGuid)); }
            set { BackingStore[PersonKey] = value; }
        }

        public static Tenant Tenant
        {
            get { return GetValueOrDefault(TenantKey, () => DatabaseEntities.Tenants.GetTenant(2)); }
            set { BackingStore[TenantKey] = value; }
        }


        public static DatabaseEntities DatabaseEntities
        {
            get { return (DatabaseEntities) LtInfoEntityTypeLoader; }
        }

        private static DatabaseEntities MakeNewContext(bool autoDetectChangesEnabled)
        {
            var databaseEntities = new DatabaseEntities();
            databaseEntities.Filter<IHaveATenantID>(q => q.Where(x => x.TenantID == Tenant.TenantID));
            databaseEntities.Configuration.AutoDetectChangesEnabled = autoDetectChangesEnabled;
            return databaseEntities;
        }

        public static void StartContextForTest()
        {
            var context = MakeNewContext(true);
            SetValue(DatabaseContextKey, context);
        }

        public static void EndContextForTest()
        {
            if (!BackingStore.Contains(DatabaseContextKey))
            {
                return;
            }
            var databaseEntities = BackingStore[DatabaseContextKey] as DatabaseEntities;
            if (databaseEntities != null)
            {
                databaseEntities.Dispose();
                BackingStore[DatabaseContextKey] = null;
            }
            BackingStore.Remove(DatabaseContextKey);
        }

        public static void DetectChangesAndSave()
        {
            DatabaseEntities.ChangeTracker.DetectChanges();
            try
            {
                DatabaseEntities.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var errors =
                    e.EntityValidationErrors.SelectMany(
                        x => x.ValidationErrors.Select(ve => String.Format("ObjectProperty: {0}.{1}, Error: {2}", x.Entry.Entity.GetType().Name, ve.PropertyName, ve.ErrorMessage)));
                var message = String.Join("\r\n", errors);
                throw new ApplicationException(message, e);
            }
        }
    }
}