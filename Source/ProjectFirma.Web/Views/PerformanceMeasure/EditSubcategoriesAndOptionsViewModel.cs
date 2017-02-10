using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class EditSubcategoriesAndOptionsViewModel
    {
        public List<PerformanceMeasureSubcategorySimple> PerformanceMeasureSubcategorySimples { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EditSubcategoriesAndOptionsViewModel()
        {
        }

        public EditSubcategoriesAndOptionsViewModel(Models.PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureSubcategorySimples = performanceMeasure.PerformanceMeasureSubcategories.ToList().Select(x => new PerformanceMeasureSubcategorySimple(x)).ToList();
        }

        public void UpdateModel(Models.PerformanceMeasure performanceMeasure)
        {
            var performanceMeasureSubcategoriesFromDatabase = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureSubcategories.Local;
            var performanceMeasureSubcategoryOptionsFromDatabase = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureSubcategoryOptions.Local;

            var performanceMeasureSubcategoriesToUpdate = PerformanceMeasureSubcategorySimples.Select(x =>
            {
                var performanceMeasureSubcategory = new PerformanceMeasureSubcategory(new Models.PerformanceMeasure(String.Empty, default(int), default(int), String.Empty),
                    x.PerformanceMeasureSubcategoryDisplayName);
                performanceMeasureSubcategory.PerformanceMeasure = performanceMeasure;
                performanceMeasureSubcategory.PerformanceMeasureSubcategoryID = x.PerformanceMeasureSubcategoryID;
                performanceMeasureSubcategory.PerformanceMeasureSubcategoryOptions =
                    x.PerformanceMeasureSubcategoryOptions.Select(
                        y =>
                            new PerformanceMeasureSubcategoryOption(
                                new PerformanceMeasureSubcategory(new Models.PerformanceMeasure(String.Empty, default(int), default(int), String.Empty), String.Empty),
                                y.PerformanceMeasureSubcategoryOptionName)
                            {
                                PerformanceMeasureSubcategory =
                                    performanceMeasure.PerformanceMeasureSubcategories.SingleOrDefault(z => z.PerformanceMeasureSubcategoryID == x.PerformanceMeasureSubcategoryID),
                                PerformanceMeasureSubcategoryOptionID = y.PerformanceMeasureSubcategoryOptionID,
                                ShortName = y.ShortName,
                                SortOrder = y.SortOrder
                            }).ToList();
                return performanceMeasureSubcategory;
            }).ToList();

            var performanceMeasureSubcategoryOptionsToUpdate = performanceMeasureSubcategoriesToUpdate.SelectMany(x => x.PerformanceMeasureSubcategoryOptions).ToList();
            performanceMeasure.PerformanceMeasureSubcategories.SelectMany(x => x.PerformanceMeasureSubcategoryOptions).ToList().Merge(
                performanceMeasureSubcategoryOptionsToUpdate,
                performanceMeasureSubcategoryOptionsFromDatabase,
                (x, y) => x.PerformanceMeasureSubcategoryOptionID == y.PerformanceMeasureSubcategoryOptionID,
                (x, y) =>
                {
                    x.PerformanceMeasureSubcategoryOptionName = y.PerformanceMeasureSubcategoryOptionName;
                    x.ShortName = y.ShortName;
                    x.SortOrder = y.SortOrder;
                });

            performanceMeasure.PerformanceMeasureSubcategories.Merge(performanceMeasureSubcategoriesToUpdate,
                performanceMeasureSubcategoriesFromDatabase,
                (x, y) => x.PerformanceMeasureSubcategoryID == y.PerformanceMeasureSubcategoryID,
                (x, y) =>
                {
                    x.PerformanceMeasureSubcategoryDisplayName = y.PerformanceMeasureSubcategoryDisplayName;
                });
        }
    }
}