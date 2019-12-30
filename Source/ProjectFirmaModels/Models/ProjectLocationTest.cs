using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using NUnit.Framework;
using ProjectFirmaModels.UnitTestCommon;

namespace ProjectFirmaModels.Models

{
    [TestFixture]
    public class ProjectLocationTest
    {
        [Test]
        public void TestProjectLocationGeometriesAreAllValid()
        {
            var invalidProjectLocationGeometriesList = new List<ProjectLocation>();

            var projectLocations = HttpRequestStorageForTest.DatabaseEntities.AllProjectLocations.ToList();
            foreach (var projectLocation in projectLocations)
            {
                if (!projectLocation.ProjectLocationGeometry.IsValid)
                {
                    invalidProjectLocationGeometriesList.Add(projectLocation);
                }
            }

            Check.Ensure(!invalidProjectLocationGeometriesList.Any(), $"Found invalid geometries for ProjectLocationIDs: {String.Join(",", invalidProjectLocationGeometriesList.Select(x => x.ProjectLocationID).ToList())}");
        }
    }
}