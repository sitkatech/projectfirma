/*-----------------------------------------------------------------------
<copyright file="ProgramInfoController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.ProgramInfo;

namespace ProjectFirma.Web.Controllers
{
    public class ProgramInfoController : FirmaBaseController
    {
        [AnonymousUnclassifiedFeature]
        public ViewResult Taxonomy()
        {
            var firmaPage = FirmaPageTypeEnum.Taxonomy.GetFirmaPage();
            var topLevelTaxonomyTierAsFancyTreeNodes = MultiTenantHelpers.GetTaxonomyLevel()
                .GetTaxonomyTiers(HttpRequestStorage.DatabaseEntities).OrderBy(x => x.SortOrder)
                .ThenBy(x => x.DisplayName, StringComparer.InvariantCultureIgnoreCase)
                .Select(x => x.ToFancyTreeNode(CurrentFirmaSession))
                .ToList();
            var viewData = new TaxonomyViewData(CurrentFirmaSession, firmaPage, topLevelTaxonomyTierAsFancyTreeNodes);
            return RazorView<Taxonomy, TaxonomyViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public ViewResult ClassificationSystem(ClassificationSystemPrimaryKey classificationSystemPrimaryKey)
        {
            var classificationSystem = classificationSystemPrimaryKey.EntityObject;
            var viewData = new ClassificationSystemViewData(CurrentFirmaSession, classificationSystem);
            return RazorView<Views.ProgramInfo.ClassificationSystem, ClassificationSystemViewData>(viewData);
        }
    }
}
