using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Models;
using Keystone.Common;
using LtInfo.Common.DesignByContract;
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
            set { SetValue(PersonKey, value); }
        }

        public static Tenant Tenant
        {
            get
            {
                return GetValueOrDefault(TenantKey,
                    () =>
                    {
                        var urlHost = HttpContext.Current.Request.Url.Host;
                        var tenant = DatabaseEntities.Tenants.SingleOrDefault(x => urlHost.Contains(x.TenantDomain));
                        Check.RequireNotNull(tenant, string.Format("Could not determine tenant from host {0}", urlHost));
                        return tenant;
                    });
            }
            set { SetValue(TenantKey, value); }
        }


        public static DatabaseEntities DatabaseEntities
        {
            get { return (DatabaseEntities) LtInfoEntityTypeLoader; }
        }

        private static DatabaseEntities MakeNewContext(bool autoDetectChangesEnabled)
        {
            var databaseEntities = new DatabaseEntities();
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
    }
}