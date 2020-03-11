/*-----------------------------------------------------------------------
<copyright file="ProjectFactSheetController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectFactSheet;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;
using System.Web.Mvc;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectFactSheetController : FirmaBaseController
    {
        [ProjectFactSheetAdminFeature]
        public ViewResult Manage()
        {
            var firmaPage = FirmaPageTypeEnum.ManageProjectFactSheet.GetFirmaPage();
            var factSheetCustomTextFirmaPage = FirmaPageTypeEnum.FactSheetCustomText.GetFirmaPage();
            var factSheetCustomTextViewData = new ViewPageContentViewData(factSheetCustomTextFirmaPage, false);
            var editCustomFactSheetTextUrl =  SitkaRoute<FirmaPageController>.BuildUrlFromExpression(t => t.EditInDialog(factSheetCustomTextFirmaPage));
            var viewData = new ManageViewData(CurrentFirmaSession, firmaPage, factSheetCustomTextViewData, editCustomFactSheetTextUrl);
            return RazorView<Manage, ManageViewData>(viewData);
        }


    }
}