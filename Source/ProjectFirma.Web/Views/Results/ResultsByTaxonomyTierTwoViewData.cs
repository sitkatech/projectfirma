/*-----------------------------------------------------------------------
<copyright file="ResultsByTaxonomyTierTwoViewData.cs" company="Tahoe Regional Planning Agency">
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
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.PerformanceMeasure;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Results
{
    public class ResultsByTaxonomyTierTwoViewData : FirmaViewData
    {
        public readonly List<Models.TaxonomyTierThree> TaxonomyTierThrees;
        public readonly Models.TaxonomyTierTwo SelectedTaxonomyTierTwo;
        public readonly string ResultsByTaxonomyTierTwoUrl;
        public readonly List<PerformanceMeasureChartViewData> PerformanceMeasureChartViewDatas;

        public ResultsByTaxonomyTierTwoViewData(Person currentPerson,
            Models.FirmaPage firmaPage,
            List<Models.TaxonomyTierThree> taxonomyTierThrees,
            Models.TaxonomyTierTwo selectedTaxonomyTierTwo) : base(currentPerson, firmaPage, false)
        {
            TaxonomyTierThrees = taxonomyTierThrees;
            PageTitle = string.Format("Results by {0}", Models.FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabel());
            SelectedTaxonomyTierTwo = selectedTaxonomyTierTwo;
            ResultsByTaxonomyTierTwoUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.ResultsByTaxonomyTierTwo(UrlTemplate.Parameter1Int));

            var projectIDs = selectedTaxonomyTierTwo.Projects.Select(y => y.ProjectID).ToList();
            PerformanceMeasureChartViewDatas =
                selectedTaxonomyTierTwo.GetPerformanceMeasures()
                    .ToList()
                    .Select(x => new PerformanceMeasureChartViewData(x, true, ChartViewMode.Small, projectIDs))
                    .ToList();
        }
    }
}
