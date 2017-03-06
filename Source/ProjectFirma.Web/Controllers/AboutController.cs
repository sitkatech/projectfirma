/*-----------------------------------------------------------------------
<copyright file="AboutController.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
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
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security.Shared;

namespace ProjectFirma.Web.Controllers
{
    public class AboutController : FirmaBaseController
    {
        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ActionResult AboutClackamasPartnership()
        {
            var con = new HomeController { ControllerContext = ControllerContext };
            return con.ViewPageContent(FirmaPageTypeEnum.About);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ActionResult Meetings()
        {
            var con = new HomeController { ControllerContext = ControllerContext };
            return con.ViewPageContent(FirmaPageTypeEnum.FirmaCustomPage1);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ActionResult FirmaCustomPage2()
        {
            var con = new HomeController { ControllerContext = ControllerContext };
            return con.ViewPageContent(FirmaPageTypeEnum.FirmaCustomPage2);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ActionResult FirmaCustomPage3()
        {
            var con = new HomeController { ControllerContext = ControllerContext };
            return con.ViewPageContent(FirmaPageTypeEnum.FirmaCustomPage3);
        }
    }
}
