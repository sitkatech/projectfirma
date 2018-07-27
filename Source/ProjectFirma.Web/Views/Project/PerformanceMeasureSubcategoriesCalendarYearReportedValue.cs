/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureSubcategoriesCalendarYearReportedValue.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Project
{
    public class PerformanceMeasureSubcategoriesCalendarYearReportedValue
    {
        private readonly Models.PerformanceMeasure _performanceMeasure;
        public int PerformanceMeasureID
        {
            get { return _performanceMeasure.PerformanceMeasureID; }
        }
        public bool HasRealSubcategories
        {
            get { return PerformanceMeasureSubcategories.Any(x => x.PerformanceMeasureSubcategoryOptions.Count > 1); }
        }
        public HtmlString PerformanceMeasureDisplayNameAsUrl
        {
            get { return _performanceMeasure.GetDisplayNameAsUrl(); }
        }
        public string PerformanceMeasureDisplayName
        {
            get { return _performanceMeasure.PerformanceMeasureDisplayName; }
        }
        public MeasurementUnitType MeasurementUnitType
        {
            get { return _performanceMeasure.MeasurementUnitType; }
        }
        public List<PerformanceMeasureSubcategory> PerformanceMeasureSubcategories
        {
            get { return _performanceMeasure.GetPerformanceMeasureSubcategories(); }
        }
        public bool IsAggregatable
        {
            get { return _performanceMeasure.IsAggregatable; }
        }

        public readonly List<SubcategoriesReportedValue> SubcategoriesReportedValues;
        public string DisplayCssClass;

        public PerformanceMeasureSubcategoriesCalendarYearReportedValue(Models.PerformanceMeasure performanceMeasure, List<SubcategoriesReportedValue> subcategoriesReportedValues, string displayCssClass)            
        {
            _performanceMeasure = performanceMeasure;
            SubcategoriesReportedValues = subcategoriesReportedValues;
            DisplayCssClass = displayCssClass;
        }

        public static List<PerformanceMeasureSubcategoriesCalendarYearReportedValue> CreateFromPerformanceMeasuresAndCalendarYears(List<IPerformanceMeasureReportedValue> performanceMeasureReportedValues)
        {
            var groupedByPerformanceMeasure = performanceMeasureReportedValues.GroupBy(x => x.PerformanceMeasure);
            var performanceMeasureCalendarYearReportedValues = new List<PerformanceMeasureSubcategoriesCalendarYearReportedValue>();
            foreach (var reportedValues in groupedByPerformanceMeasure)
            {
                var performanceMeasure = reportedValues.Key;
                var groupBy = reportedValues.GroupBy(x => x.PerformanceMeasureSubcategoriesAsString).ToList();
                var subcategoriesReportedValues =
                    groupBy
                        .Select(
                            subcategoriesReportedValue =>
                            {
                                return new SubcategoriesReportedValue(subcategoriesReportedValue.Key, subcategoriesReportedValue.First().PerformanceMeasureSubcategoryOptions,
                                    subcategoriesReportedValue.GroupBy(scrv => scrv.CalendarYear).ToDictionary(scrv => scrv.Key, scrv => scrv.Sum(rv => rv.ReportedValue)));
                            })                                
                        .ToList();
                var orderedSubcategoryReportedValues = subcategoriesReportedValues.OrderBy(srv =>
                    srv.PerformanceMeasureValueSubcategoryOptions
                        .OrderBy(x => x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName).FirstOrDefault()?
                        .PerformanceMeasureSubcategoryOption.SortOrder).ToList();
                performanceMeasureCalendarYearReportedValues.Add(new PerformanceMeasureSubcategoriesCalendarYearReportedValue(performanceMeasure, orderedSubcategoryReportedValues, null));
            }
            return performanceMeasureCalendarYearReportedValues;
        }

        public static PerformanceMeasureSubcategoriesCalendarYearReportedValue Clone(PerformanceMeasureSubcategoriesCalendarYearReportedValue performanceMeasureSubcategoriesCalendarYearReportedValue, string displayCssClass)
        {
            return new PerformanceMeasureSubcategoriesCalendarYearReportedValue(performanceMeasureSubcategoriesCalendarYearReportedValue._performanceMeasure, performanceMeasureSubcategoriesCalendarYearReportedValue.SubcategoriesReportedValues.Select(SubcategoriesReportedValue.Clone).ToList(), displayCssClass);
        }
    }

    public class SubcategoriesReportedValue
    {
        public readonly List<IPerformanceMeasureValueSubcategoryOption> PerformanceMeasureValueSubcategoryOptions;
        public readonly Dictionary<int, double?> CalendarYearReportedValue;
        public readonly string PerformanceMeasureSubcategories;         
        public readonly List<string> SubcategoryNames;
        
        public SubcategoriesReportedValue(string subcategories, List<IPerformanceMeasureValueSubcategoryOption> performanceMeasureValueSubcategoryOptions, Dictionary<int, double?> calendarYearReportedValue)
        {
            PerformanceMeasureValueSubcategoryOptions = performanceMeasureValueSubcategoryOptions;
            PerformanceMeasureSubcategories = subcategories;
            CalendarYearReportedValue = calendarYearReportedValue;            
            SubcategoryNames = new List<string>(performanceMeasureValueSubcategoryOptions.Select(p => p.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName).OrderBy(p => p));
        }

        public static SubcategoriesReportedValue Clone(SubcategoriesReportedValue subcategoriesReportedValue)
        {
            return new SubcategoriesReportedValue(subcategoriesReportedValue.PerformanceMeasureSubcategories,
                subcategoriesReportedValue.PerformanceMeasureValueSubcategoryOptions,
                subcategoriesReportedValue.CalendarYearReportedValue.ToDictionary(x => x.Key, x => x.Value));
        }
    }
}
