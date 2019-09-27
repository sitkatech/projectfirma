/*-----------------------------------------------------------------------
<copyright file="HomeController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Web.Mvc;
using ProjectFirma.Web.HealthMonitor;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.SiteMonitor;

namespace ProjectFirma.Web.Controllers
{
    public class SiteMonitorController : FirmaBaseController
    {
        [HttpGet]
        // This needs to be an anonymous feature so Nagios can call it without having to log in.
        // Please take pains not to advertise this to non-Admins, but if this ever does become public / called by bots, we
        // can likely fix Nagios so it can log in.
        [AnonymousUnclassifiedFeature]
        public ViewResult SiteMonitor()
        {
            var siteMonitorCheckResults = SiteMonitorChecks.Run();
            var viewData = new SiteMonitorNagiosViewData(CurrentPerson, siteMonitorCheckResults);
            return RazorView<SiteMonitorNagios, SiteMonitorNagiosViewData>(viewData);
        }
    }
}