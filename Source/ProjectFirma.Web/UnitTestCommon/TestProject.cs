using System;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProject
        {
            public static Project Create()
            {
                var taxonomyTierOne = TestTaxonomyTierOne.Create();
                var projectStage = ProjectStage.PlanningDesign;
                var project = Project.CreateNewBlank(taxonomyTierOne, projectStage, ProjectLocationSimpleType.None, FundingType.Capital);
                return project;
            }

            public static Project Create(DatabaseEntities dbContext)
            {
                var taxonomyTierOne = TestTaxonomyTierOne.Create(dbContext);

                var projectStage = ProjectStage.PlanningDesign;
                var project = new Project(taxonomyTierOne,
                    projectStage,
                    string.Format("Test Project Name {0}", Guid.NewGuid()),
                    MakeTestName("Test Project Description"),
                    false,
                    ProjectLocationSimpleType.None,
                    FundingType.Capital);

                dbContext.AllProjects.Add(project);
                return project;
            }

            public static Project Create(short projectID, string projectName)
            {
                var taxonomyTierOne = TestTaxonomyTierOne.Create();
                var projectStage = ProjectStage.Implementation;
                var project = new Project(taxonomyTierOne, projectStage, projectName, "Some description",  false, ProjectLocationSimpleType.None, FundingType.Capital)
                {
                    ProjectID = projectID
                };
                return project;
            }

            public static Project Insert(DatabaseEntities dbContext)
            {
                var project = Create(dbContext);
                HttpRequestStorage.DatabaseEntities.SaveChanges();
                return project;
            }
        }
    }
}