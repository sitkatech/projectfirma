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
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.ProgramInfo;
using ProjectFirma.Web.Views.Shared.SortOrder;

namespace ProjectFirma.Web.Controllers
{
    public class ProgramInfoController : FirmaBaseController
    {
        [AnonymousUnclassifiedFeature]
        public ViewResult Taxonomy()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.Taxonomy);
            
            
            List<FancyTreeNode> topLevelTaxonomyTierAsFancyTreeNodes;
            switch (MultiTenantHelpers.GetTaxonomyLevel().ToEnum)
            {
                case TaxonomyLevelEnum.Trunk:
                    var taxonomyTrunks = HttpRequestStorage.DatabaseEntities.TaxonomyTrunks.ToList().SortByOrderThenName().ToList();
                    topLevelTaxonomyTierAsFancyTreeNodes = taxonomyTrunks.Select(x => x.ToFancyTreeNode()).ToList();
                    break;
                case TaxonomyLevelEnum.Branch:
                    var taxonomyBranches = HttpRequestStorage.DatabaseEntities.TaxonomyBranches.ToList().SortByOrderThenName().ToList();
                    topLevelTaxonomyTierAsFancyTreeNodes = taxonomyBranches.Select(x => x.ToFancyTreeNode()).ToList();
                    break;
                case TaxonomyLevelEnum.Leaf:
                    var taxonomyLeafs = HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.ToList().SortByOrderThenName().ToList();
                    topLevelTaxonomyTierAsFancyTreeNodes = taxonomyLeafs.Select(x => x.ToFancyTreeNode()).ToList();
                    break;
                default:
                    throw new NotImplementedException("Only one, two, or three taxonomy tiers are supported.");
            }
            var viewData = new TaxonomyViewData(CurrentPerson, firmaPage, topLevelTaxonomyTierAsFancyTreeNodes);
            return RazorView<Taxonomy, TaxonomyViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public ViewResult ClassificationSystem(ClassificationSystemPrimaryKey classificationSystemPrimaryKey)
        {
            var classificationSystem = classificationSystemPrimaryKey.EntityObject;

            var viewData = new ClassificationSystemViewData(CurrentPerson, classificationSystem);
            return RazorView<Views.ProgramInfo.ClassificationSystem, ClassificationSystemViewData>(viewData);
        }
    }
}
