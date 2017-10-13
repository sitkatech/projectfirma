/*-----------------------------------------------------------------------
<copyright file="FirmaBaseController.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using log4net;
using LtInfo.Common;

namespace ProjectFirma.Web.Controllers
{
    [ValidateInput(false)]
    public abstract class FirmaBaseController : SitkaController
    {
        public static ControllerContext ControllerContextStatic = null;

        protected ILog Logger = LogManager.GetLogger(typeof(FirmaBaseController));

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!IsCurrentUserAnonymous())
            {
                CurrentPerson.LastActivityDate = DateTime.Now;
                HttpRequestStorage.DatabaseEntities.ChangeTracker.DetectChanges();
                HttpRequestStorage.DatabaseEntities.SaveChangesWithNoAuditing();
            }
            base.OnAuthorization(filterContext);
        }

        protected FirmaBaseController()
        {
            if (ControllerContextStatic == null)
                ControllerContextStatic = ControllerContext;
        }

        public static ReadOnlyCollection<MethodInfo> AllControllerActionMethods => AllControllerActionMethodsProtected;

        static FirmaBaseController()
        {
            AllControllerActionMethodsProtected = new ReadOnlyCollection<MethodInfo>(GetAllControllerActionMethods(typeof(FirmaBaseController)));
        }

        protected override bool IsCurrentUserAnonymous()
        {
            return CurrentPerson == null || CurrentPerson.IsAnonymousUser;
        }

        protected override string LoginUrl => FirmaHelpers.GenerateLogInUrlWithReturnUrl();

        protected override ISitkaDbContext SitkaDbContext => HttpRequestStorage.DatabaseEntities;

        protected Person CurrentPerson => HttpRequestStorage.Person;

        protected Tenant CurrentTenant => HttpRequestStorage.Tenant;

        protected List<IProject> ProjectsForMap(Func<IProject, bool> visibleProjectFilter)
        {
            var allProjects = new List<IProject>(HttpRequestStorage.DatabaseEntities.Projects);
            if (MultiTenantHelpers.IncludeProposedProjectsOnMap())
            {
                allProjects.AddRange(new List<IProject>(HttpRequestStorage.DatabaseEntities.ProposedProjects));
            }
            var projectsToShow = allProjects.Where(visibleProjectFilter)
                .OrderBy(x => x.ProjectStage.ProjectStageID).ToList();
            return projectsToShow;
        }
    }
}
