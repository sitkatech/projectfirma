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
            var invalidProjectLocationGeometryStringsList = new List<string>();

            var projectLocations = HttpRequestStorageForTest.DatabaseEntities.AllProjectLocations.ToList();
            foreach (var projectLocation in projectLocations)
            {
                if (!projectLocation.ProjectLocationGeometry.IsValid)
                {
                    var invalidProjectLocationGeometryString = $"(ProjectLocationID: [{projectLocation.ProjectLocationID}] TenantID: [{projectLocation.Tenant.TenantID}] TenantName: [{projectLocation.Tenant.TenantName}] ProjectID: [{projectLocation.ProjectID}] ProjectName: [{projectLocation.Project.ProjectName}])";
                    invalidProjectLocationGeometryStringsList.Add(invalidProjectLocationGeometryString);
                }
            }

            Check.Ensure(!invalidProjectLocationGeometryStringsList.Any(), $"Found {invalidProjectLocationGeometryStringsList.Count} invalid geometries for ProjectLocations: {String.Join(", ", invalidProjectLocationGeometryStringsList)}");
        }
    }
}