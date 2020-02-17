using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class PerformanceMeasureExpectedUpdateModelExtensions
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            var performanceMeasureExpectedUpdates = new List<PerformanceMeasureExpectedUpdate>();
            var currentPerformanceMeasureExpecteds = project.PerformanceMeasureExpecteds.ToList();
            // if we have a project completion year, we only fill up to that unless current year is earlier; no completion year set we use current year
            if (currentPerformanceMeasureExpecteds.Any())
            {
                performanceMeasureExpectedUpdates.AddRange(
                    currentPerformanceMeasureExpecteds.Select(
                        performanceMeasureExpected => ClonePerformanceMeasureValue(projectUpdateBatch,
                            performanceMeasureExpected, performanceMeasureExpected.ExpectedValue)));
            }

            projectUpdateBatch.PerformanceMeasureExpectedUpdates = performanceMeasureExpectedUpdates;
        }

        /// <summary>
        /// Only public for unit testing
        /// </summary>
        public static PerformanceMeasureExpectedUpdate ClonePerformanceMeasureValue(ProjectUpdateBatch projectUpdateBatch,
            IPerformanceMeasureValue performanceMeasureValueToClone,
            double? expectedValue)
        {
            var performanceMeasureExpectedUpdate = new PerformanceMeasureExpectedUpdate(projectUpdateBatch, performanceMeasureValueToClone.PerformanceMeasure)
            {
                ExpectedValue = expectedValue
            };
            performanceMeasureExpectedUpdate.PerformanceMeasureExpectedSubcategoryOptionUpdates =
                performanceMeasureValueToClone.GetPerformanceMeasureSubcategoryOptions().Select(
                    performanceMeasureExpectedSubcategoryOption =>
                        new PerformanceMeasureExpectedSubcategoryOptionUpdate(performanceMeasureExpectedUpdate,
                            performanceMeasureExpectedSubcategoryOption.PerformanceMeasureSubcategoryOption,
                            performanceMeasureExpectedSubcategoryOption.PerformanceMeasure,
                            performanceMeasureExpectedSubcategoryOption.PerformanceMeasureSubcategory)).ToList();
            return performanceMeasureExpectedUpdate;
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, DatabaseEntities databaseEntities)
        {
            var project = projectUpdateBatch.Project;
            var currentPerformanceMeasureExpecteds = project.PerformanceMeasureExpecteds.ToList();
            currentPerformanceMeasureExpecteds.ForEach(pmav => pmav.DeleteFull(databaseEntities));
            currentPerformanceMeasureExpecteds.Clear();

            if (projectUpdateBatch.AreAccomplishmentsRelevant() && projectUpdateBatch.PerformanceMeasureExpectedUpdates.Any())
            {
                // Completely rebuild the list
                projectUpdateBatch.PerformanceMeasureExpectedUpdates.ToList().ForEach(x =>
                {
                    var performanceMeasureExpected = new PerformanceMeasureExpected(project, x.PerformanceMeasure)
                    {
                        ExpectedValue = x.ExpectedValue
                    };
                    databaseEntities.AllPerformanceMeasureExpecteds.Add(performanceMeasureExpected);
                    var performanceMeasureExpectedSubcategoryOptionUpdates = x.PerformanceMeasureExpectedSubcategoryOptionUpdates.ToList();
                    if (performanceMeasureExpectedSubcategoryOptionUpdates.Any())
                    {
                        performanceMeasureExpectedSubcategoryOptionUpdates.ForEach(
                            y =>
                                databaseEntities.AllPerformanceMeasureExpectedSubcategoryOptions.Add(new PerformanceMeasureExpectedSubcategoryOption(performanceMeasureExpected,
                                    y.PerformanceMeasureSubcategoryOption,
                                    y.PerformanceMeasure,
                                    y.PerformanceMeasureSubcategory)));
                    }
                });
            }
        }
    }
}