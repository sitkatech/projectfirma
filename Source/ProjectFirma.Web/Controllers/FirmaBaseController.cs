/*-----------------------------------------------------------------------
<copyright file="FirmaBaseController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.ObjectModel;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using log4net;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Controllers
{
    [ValidateInput(false)]
    public abstract class FirmaBaseController : Common.SitkaController
    {
        public static ControllerContext ControllerContextStatic = null;

        protected ILog Logger = LogManager.GetLogger(typeof(FirmaBaseController));

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!IsCurrentUserAnonymous())
            {
                var currentDateTime = DateTime.Now;

                // Log Last Activity times to both FirmaSession and Person if enough time has passed since last activity
                // (RL tells me this is truly needed, and that performance will suffer without it. --SLG)
                var minimumTimeSpanForActivityLogging = new TimeSpan(0, 3, 0);
                if (currentDateTime - (CurrentFirmaSession.LastActivityDate ?? new DateTime()) > minimumTimeSpanForActivityLogging)
                {
                    // It's arguably better to have activity logged only on the FirmaSession, but we'll keep it in 
                    // both places for the moment. -- SLG
                    CurrentFirmaSession.LastActivityDate = currentDateTime;
                    CurrentFirmaSession.Person.LastActivityDate = currentDateTime;
                    HttpRequestStorage.DatabaseEntities.ChangeTracker.DetectChanges();
                    HttpRequestStorage.DatabaseEntities.SaveChangesWithNoAuditing(CurrentFirmaSession.TenantID);
                }
            }
            base.OnActionExecuting(filterContext);
        }

        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            var firmaSessionFromClaimsIdentity = ClaimsIdentityHelper.FirmaSessionFromClaimsIdentity(HttpContext.GetOwinContext().Authentication, CurrentTenant);

            HttpRequestStorage.FirmaSession = firmaSessionFromClaimsIdentity;
            // we need to set this so that the save will know who the Person is
            HttpRequestStorage.DatabaseEntities.Person = firmaSessionFromClaimsIdentity.Person;

            base.OnAuthentication(filterContext);
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!IsCurrentUserAnonymous())
            {
                HttpRequestStorage.DatabaseEntities.Person = CurrentFirmaSession.Person;
            }
            base.OnAuthorization(filterContext);
        }

        protected FirmaBaseController()
        {
            if (ControllerContextStatic == null)
            {
                ControllerContextStatic = ControllerContext;
            }
        }

        public static ReadOnlyCollection<MethodInfo> AllControllerActionMethods => AllControllerActionMethodsProtected;

        static FirmaBaseController()
        {
            AllControllerActionMethodsProtected = new ReadOnlyCollection<MethodInfo>(GetAllControllerActionMethods(typeof(FirmaBaseController)));
        }

        protected override bool IsCurrentUserAnonymous()
        {
            return CurrentFirmaSession == null || CurrentFirmaSession.IsAnonymousUser();
        }

        protected override string LoginUrl => FirmaHelpers.GenerateLogInUrl();

        protected override ISitkaDbContext SitkaDbContext => HttpRequestStorage.DatabaseEntities;

        public FirmaSession CurrentFirmaSession => HttpRequestStorage.FirmaSession;

        public Person CurrentPerson => CurrentFirmaSession.Person;

        public Tenant CurrentTenant => HttpRequestStorage.Tenant;
    }
}
