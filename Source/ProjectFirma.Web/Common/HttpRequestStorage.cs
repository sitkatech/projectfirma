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

        protected override List<string> BackingStoreKeys => new List<string>();

        public static IPrincipal GetHttpContextUserThroughOwin()
        {
            return HttpContext.Current.GetOwinContext().Authentication.User;
        }

        public static Person Person
        {
            get => GetValueOrDefault(PersonKey, () =>
            {
                var principal = GetHttpContextUserThroughOwin();
                var anonymousSitkaUser = Person.GetAnonymousSitkaUser();
                if (!principal.Identity.IsAuthenticated)
                {
                    return anonymousSitkaUser;
                }

                // calls to the account provisioning service from keystone are authenticated calls, but not by forms auth tickets.  they come in with the user identity of the
                // application pool that keystone runs under and have an authentication type of "Kerberos". these particular invokations need to be treated the same way as the
                // unauthenticated calls over basic bindings - that is they do not map to a MM user and should be considered "anonymous".

                //These are OpenID AuthenticationTypes, WIF ones include "Keberos" and "Federation"
                if (principal.Identity.AuthenticationType == "JWT" || principal.Identity.AuthenticationType == "Cookies")
                {
                    // otherwise remap claims from principal
                    var keystoneUserClaims = KeystoneClaimsHelpers.ParseOpenIDClaims(principal.Identity);
                    var user = DatabaseEntities.People.GetPersonByPersonGuid(keystoneUserClaims.UserGuid);
                    user.SetKeystoneUserClaims(keystoneUserClaims);

                    return user;
                }
                return anonymousSitkaUser;


                //return KeystoneClaimsHelpers.GetOpenIDUserFromPrincipal(GetHttpContextUserThroughOwin(),
                //        Person.GetAnonymousSitkaUser(), DatabaseEntities.People.GetPersonByPersonGuid);
            });
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
                        if (httpContext != null)
                        {
                            var urlHost = httpContext.Request.Url.Host;
                            var tenant = Tenant.All.SingleOrDefault(x => urlHost.Equals(FirmaWebConfiguration.FirmaEnvironment.GetCanonicalHostNameForEnvironment(x), StringComparison.InvariantCultureIgnoreCase));
                            Check.RequireNotNull(tenant, $"Could not determine tenant from host {urlHost}");
                            return tenant;
                        }
                        else
                        {
                            return Tenant.SitkaTechnologyGroup;
                        }
                    });
            }
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
