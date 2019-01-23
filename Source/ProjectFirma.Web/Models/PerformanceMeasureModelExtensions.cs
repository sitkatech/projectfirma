/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureModelExtensions.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Models
{
    public static class PerformanceMeasureModelExtensions
    {
        public static HtmlString GetDisplayNameAsUrl(this PerformanceMeasure performanceMeasure)
        {
            return UrlTemplate.MakeHrefString(performanceMeasure.GetSummaryUrl(), performanceMeasure.PerformanceMeasureDisplayName);
        }

        public static readonly UrlTemplate<int> SummaryUrlTemplate = new UrlTemplate<int>(SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));
        public static string GetSummaryUrl(this PerformanceMeasure performanceMeasure)
        {
            return SummaryUrlTemplate.ParameterReplace(performanceMeasure.PerformanceMeasureID);
        }

        private static readonly UrlTemplate<int> DefinitionAndGuidanceUrlTemplate = new UrlTemplate<int>(SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(t => t.DefinitionAndGuidance(UrlTemplate.Parameter1Int)));
        public static string GetDefinitionAndGuidanceUrl(this PerformanceMeasure performanceMeasure)
        {
            return DefinitionAndGuidanceUrlTemplate.ParameterReplace(performanceMeasure.PerformanceMeasureID);
        }

        public static string GetEditReportedValuesUrl(this PerformanceMeasure performanceMeasure)
        {
            if (performanceMeasure != null)
            {
                return null;
            }
            throw new NotImplementedException($"PerformanceMeasure {0} is not reported in the {FieldDefinition.Project.GetFieldDefinitionLabel()} Tracker!  No way to edit {FieldDefinition.ReportedValue.GetFieldDefinitionLabel()}!");
        }

        public static bool IsPerformanceMeasureDisplayNameUnique(IEnumerable<PerformanceMeasure> performanceMeasures, string performanceMeasureDisplayName, int currentPerformanceMeasureID)
        {
            var performanceMeasure =
                performanceMeasures.SingleOrDefault(
                    x => x.PerformanceMeasureID != currentPerformanceMeasureID && String.Equals(x.PerformanceMeasureDisplayName, performanceMeasureDisplayName, StringComparison.InvariantCultureIgnoreCase));
            return performanceMeasure == null;
        }

        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(t => t.DeletePerformanceMeasure(UrlTemplate.Parameter1Int)));
        public static string GetDeleteUrl(this PerformanceMeasure performanceMeasure)
        {
            return DeleteUrlTemplate.ParameterReplace(performanceMeasure.PerformanceMeasureID);
        }

        public static string GetJavascriptSafeChartUniqueName(this PerformanceMeasure performanceMeasure)
        {
            return $"PerformanceMeasure{performanceMeasure.PerformanceMeasureID}";
        }

        public static GoogleChartConfiguration GetDefaultPerformanceMeasureChartConfigurationJson(
            PerformanceMeasure performanceMeasure)
        {
            var googleChartType = GoogleChartType.ColumnChart;
            var googleChartAxisHorizontal =
                new GoogleChartAxis("Reporting Year", null, null) {Gridlines = new GoogleChartGridlinesOptions(-1, "transparent")};
            var googleChartAxisVerticals = new List<GoogleChartAxis>();
            var defaultSubcategoryChartConfigurationJson = new GoogleChartConfiguration(
                performanceMeasure.PerformanceMeasureDisplayName, true, googleChartType, googleChartAxisHorizontal,
                googleChartAxisVerticals);
            return defaultSubcategoryChartConfigurationJson;
        }

        public static IEnumerable<PerformanceMeasure> GetReportablePerformanceMeasures()
        {
            return HttpRequestStorage.DatabaseEntities.PerformanceMeasures.ToList().Where(x => !x.PerformanceMeasureDataSourceType.IsCustomCalculation);
        }

        public static IEnumerable<IGrouping<ITaxonomyTier, TaxonomyLeafPerformanceMeasure>> GetTaxonomyTiers(this PerformanceMeasure performanceMeasure)
        {
            Func<TaxonomyLeafPerformanceMeasure, ITaxonomyTier> groupingFunc;
            switch (MultiTenantHelpers.GetAssociatePerformanceMeasureTaxonomyLevel().ToEnum)
            {
                case TaxonomyLevelEnum.Trunk:
                    groupingFunc = x => x.TaxonomyLeaf.TaxonomyBranch.TaxonomyTrunk;
                    break;
                case TaxonomyLevelEnum.Branch:
                    groupingFunc = x => x.TaxonomyLeaf.TaxonomyBranch;
                    break;
                case TaxonomyLevelEnum.Leaf:
                    groupingFunc = x => x.TaxonomyLeaf;
                    break;
                default:
                    throw new ArgumentException();
            }

            var taxonomyBranchPerformanceMeasureGroupedByLevel = performanceMeasure.TaxonomyLeafPerformanceMeasures.GroupBy(groupingFunc);
            return taxonomyBranchPerformanceMeasureGroupedByLevel;
        }

        public static List<PerformanceMeasureSubcategoriesTotalReportedValue> SubcategoriesTotalReportedValues(Person currentPerson, PerformanceMeasure performanceMeasure)
        {
            var groupByProjectAndSubcategory =
                performanceMeasure.GetReportedPerformanceMeasureValues(currentPerson)
                    .Where(x => FirmaDateUtilities.DateIsInReportingRange(x.CalendarYear))
                    .GroupBy(x => new {x.Project, PerformanceMeasureSubcategoriesAsString = x.GetPerformanceMeasureSubcategoriesAsString()})
                    .ToList();

            return
                groupByProjectAndSubcategory.Select(
                    reportedValuesGroup =>
                        new PerformanceMeasureSubcategoriesTotalReportedValue(reportedValuesGroup.Key.Project,
                            reportedValuesGroup.First().GetPerformanceMeasureSubcategoryOptions(),
                            performanceMeasure,
                            reportedValuesGroup.Sum(x => x.GetReportedValue()))).ToList();
        }

        public static List<GoogleChartJson> GetGoogleChartJsonDictionary(this List<Project> projects, PerformanceMeasure performanceMeasure)
        {
            var reportedValues = performanceMeasure.GetProjectPerformanceMeasureSubcategoryOptionReportedValues(performanceMeasure, projects);
            return PerformanceMeasureSubcategory.MakeGoogleChartJsons(performanceMeasure, reportedValues);
        }
    }
}
