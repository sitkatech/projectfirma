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

using System.Collections.Generic;
using System.Web;
using LtInfo.Common;
using ProjectFirmaModels.Models;
using Person = ProjectFirmaModels.Models.Person;

namespace ProjectFirmaModels.UnitTestCommon
{
    /// <summary>
    /// This is a hacked-up version of HttpRequestStorage, but put into the UnitTestCommon assembly to make it accessible where it would otherwise not be.
    /// I would appreciate knowing if there's a better way to accomplish this. This is just the first thing I tried that worked, and it seems to have a
    /// small/impact footprint, unlike other things attempted. -- SLG 3/29/2019
    /// </summary>
    public class HttpRequestStorageForTest : SitkaHttpRequestStorage
    {
        static HttpRequestStorageForTest()
        {
            LtInfoEntityTypeLoaderFactoryFunction = () => MakeNewContext(false);
        }
        

        protected override List<string> BackingStoreKeys
        {
            get { return new List<string>(); }
        }
        /*
        public static IPrincipal GetHttpContextUserThroughOwin()
        {
            return HttpContext.Current.GetOwinContext().Authentication.User;
        }
        */

        public static Person Person
        {
            get
            {
                //return GetValueOrDefault(PersonKey, () => KeystoneClaimsHelpers.GetOpenIDUserFromPrincipal(GetHttpContextUserThroughOwin(), PersonModelExtensions.GetAnonymousSitkaUser(), DatabaseEntities.People.GetPersonByPersonGuid));
                return null;
            }
            set { SetValue(PersonKey, value); }
        }


        /*
        public static Tenant Tenant
        {
            get
            {
                return GetValueOrDefault(TenantKey,
                    () =>
                    {
                        var httpContext = HttpContext.Current;
                        if (httpContext != null)
                        {
                            // If you bring this back, use             return MultiTenantHelpers.GetTenantFromHostUrl(urlHost); instead. -- SLG 9/16/2019

                            //var urlHost = httpContext.Request.Url.Host;
                            ////var tenant = Tenant.All.SingleOrDefault(x => urlHost.Equals(FirmaWebConfiguration.FirmaEnvironment.GetCanonicalHostNameForEnvironment(x), StringComparison.InvariantCultureIgnoreCase));
                            ////Check.RequireNotNull(tenant, $"Could not determine tenant from host {urlHost}");
                            ////return tenant;
                            //return null;
                            return DesiredTenant;
                        }
                        else
                        {
                            return Tenant.SitkaTechnologyGroup;
                        }
                    });
            }
            set => SetValue(TenantKey, value);
        }
        */

        public static DatabaseEntities DatabaseEntities
        {
            get { return (DatabaseEntities)LtInfoEntityTypeLoader; }
        }

        private static DatabaseEntities MakeNewContext(bool autoDetectChangesEnabled)
        {
            // Hard coded for now?
            Tenant desiredTenant = Tenant.BureauOfReclamation;

            var databaseEntities = new DatabaseEntities(desiredTenant.TenantID);
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
            var databaseEntities = BackingStore[DatabaseContextKey] as DatabaseEntities;
            if (databaseEntities != null)
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
            var person = BackingStore[PersonKey] as Person;
            if (person != null)
            {
                BackingStore[PersonKey] = null;
            }
            BackingStore.Remove(PersonKey);
        }
    }
}
