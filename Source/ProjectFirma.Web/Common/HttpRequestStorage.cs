/*-----------------------------------------------------------------------
<copyright file="HttpRequestStorage.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using System.Security.Principal;
using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Models;
using Keystone.Common.OpenID;
using log4net;
using LtInfo.Common.DesignByContract;
using Person = ProjectFirma.Web.Models.Person;

namespace ProjectFirma.Web.Common
{
    public class HttpRequestStorage : SitkaHttpRequestStorage
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(HttpRequestStorage));

        static HttpRequestStorage()
        {
            LtInfoEntityTypeLoaderFactoryFunction = () => MakeNewContext(false);
        }

        protected override List<string> BackingStoreKeys => new List<string>();

        public static IPrincipal GetHttpContextUserThroughOwin()
        {
            return HttpContext.Current.GetOwinContext().Authentication.User;
        }

        public static Person Person
        {
            get => GetValueOrDefault(PersonKey, () => KeystoneClaimsHelpers.GetOpenIDUserFromPrincipal(GetHttpContextUserThroughOwin(), Person.GetAnonymousSitkaUser(), DatabaseEntities.People.GetPersonByPersonGuid));
            set => SetValue(PersonKey, value);
        }

        public static Tenant Tenant
        {
            get
            {
                return GetValueOrDefault(TenantKey,
                    () =>
                    {
                        var httpContext = HttpContext.Current;
                        if (httpContext == null)
                        {
                            Logger.Warn($"HttpContext.Current is null, can't determine tenant from HttpContext.Current.Request.Url. Using default tenant {nameof(Tenant.SitkaTechnologyGroup.TenantID)}: {Tenant.SitkaTechnologyGroup.TenantID}");
                            return Tenant.SitkaTechnologyGroup;
                        }
                        var urlHost = httpContext.Request.Url.Host;
                        var tenant = Tenant.All.SingleOrDefault(x => urlHost.Equals(FirmaWebConfiguration.FirmaEnvironment.GetCanonicalHostNameForEnvironment(x), StringComparison.InvariantCultureIgnoreCase));
                        Check.RequireNotNull(tenant, $"Could not determine tenant from host {urlHost}");
                        return tenant;
                    });
            }
            set => SetValue(TenantKey, value);
        }

        public static DatabaseEntities DatabaseEntities => (DatabaseEntities) LtInfoEntityTypeLoader;

        private static DatabaseEntities MakeNewContext(bool autoDetectChangesEnabled)
        {
            var databaseEntities = new DatabaseEntities();
            databaseEntities.Configuration.AutoDetectChangesEnabled = autoDetectChangesEnabled;
            return databaseEntities;
        }

        public static void StartContextForTest()
        {
            var context = MakeNewContext(true);
            SetValue(TenantKey, Tenant.SitkaTechnologyGroup);
            SetValue(DatabaseContextKey, context);
        }

        public static void EndContextForTest()
        {
            if (!BackingStore.Contains(DatabaseContextKey))
            {
                return;
            }

            if (BackingStore[DatabaseContextKey] is DatabaseEntities databaseEntities)
            {
                databaseEntities.Dispose();
                BackingStore[DatabaseContextKey] = null;
            }
            BackingStore.Remove(DatabaseContextKey);

            if (!BackingStore.Contains(TenantKey))
            {
                return;
            }
            var tenant = BackingStore[TenantKey] as Tenant;
            if (tenant != null)
            {
                BackingStore[TenantKey] = null;
            }
            BackingStore.Remove(TenantKey);

            if (!BackingStore.Contains(PersonKey))
            {
                return;
            }

            if (BackingStore[PersonKey] is Person)
            {
                BackingStore[PersonKey] = null;
            }
            BackingStore.Remove(PersonKey);
        }
    }
}
