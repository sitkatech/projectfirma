using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common.Models;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.ProjectLocalAndRegionalPlan
{
    [TestFixture]
    public class EditProjectLocalAndRegionalPlansViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var localAndRegionalPlan1 = TestFramework.TestLocalAndRegionalPlan.Create();
            var localAndRegionalPlan2 = TestFramework.TestLocalAndRegionalPlan.Create();
            var localAndRegionalPlan3 = TestFramework.TestLocalAndRegionalPlan.Create();
            var localAndRegionalPlan4 = TestFramework.TestLocalAndRegionalPlan.Create();

            var project = TestFramework.TestProject.Create();
            TestFramework.TestProjectLocalAndRegionalPlan.Create(project, localAndRegionalPlan1);
            TestFramework.TestProjectLocalAndRegionalPlan.Create(project, localAndRegionalPlan2);
            TestFramework.TestProjectLocalAndRegionalPlan.Create(project, localAndRegionalPlan3);
            TestFramework.TestProjectLocalAndRegionalPlan.Create(project, localAndRegionalPlan4);

            var allLocalAndRegionalPlans = new List<Models.LocalAndRegionalPlan> {localAndRegionalPlan1, localAndRegionalPlan2, localAndRegionalPlan3, localAndRegionalPlan4};

            // Act
            var viewModel = new EditProjectLocalAndRegionalPlansViewModel(project.ProjectLocalAndRegionalPlans.Select(x => new ProjectLocalAndRegionalPlanSimple(x)).ToList());

            // Assert
            Assert.That(viewModel.ProjectLocalAndRegionalPlans.Select(x => x.LocalAndRegionalPlanID), Is.EquivalentTo(allLocalAndRegionalPlans.Select(x => x.LocalAndRegionalPlanID)));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var localAndRegionalPlan1 = TestFramework.TestLocalAndRegionalPlan.Create();
            var localAndRegionalPlan2 = TestFramework.TestLocalAndRegionalPlan.Create();
            var localAndRegionalPlan3 = TestFramework.TestLocalAndRegionalPlan.Create();
            var localAndRegionalPlan4 = TestFramework.TestLocalAndRegionalPlan.Create();

            var project = TestFramework.TestProject.Create();
            var projectLocalAndRegionalPlan1 = TestFramework.TestProjectLocalAndRegionalPlan.Create(project, localAndRegionalPlan1);
            var projectLocalAndRegionalPlan2 = TestFramework.TestProjectLocalAndRegionalPlan.Create(project, localAndRegionalPlan2);

            Assert.That(project.ProjectLocalAndRegionalPlans.Select(x => x.LocalAndRegionalPlanID),
                Is.EquivalentTo(new List<int> {projectLocalAndRegionalPlan1.LocalAndRegionalPlanID, projectLocalAndRegionalPlan2.LocalAndRegionalPlanID}));

            var localAndRegionalPlansSelected = new List<Models.LocalAndRegionalPlan> {localAndRegionalPlan1, localAndRegionalPlan3, localAndRegionalPlan4};
            var allProjectLocalAndRegionalPlans = new List<Models.ProjectLocalAndRegionalPlan> {projectLocalAndRegionalPlan1, projectLocalAndRegionalPlan2};

            var viewModel = new EditProjectLocalAndRegionalPlansViewModel();
            viewModel.ProjectLocalAndRegionalPlans =
                localAndRegionalPlansSelected.Select(x => new ProjectLocalAndRegionalPlanSimple(ModelObjectHelpers.NotYetAssignedID, project.ProjectID, x.LocalAndRegionalPlanID)).ToList();

            // Act
            viewModel.UpdateModel(project.ProjectLocalAndRegionalPlans.ToList(), allProjectLocalAndRegionalPlans);

            // Assert
            Assert.That(allProjectLocalAndRegionalPlans.Select(x => x.LocalAndRegionalPlanID), Is.EquivalentTo(localAndRegionalPlansSelected.Select(x => x.LocalAndRegionalPlanID)));
        }

        [Test]
        public void CanValidateModelTest()
        {
            // Arrange
            var localAndRegionalPlan = TestFramework.TestLocalAndRegionalPlan.Create();
            var project = TestFramework.TestProject.Create();

            localAndRegionalPlan.IsTransportationPlan = true;

            var error = EditProjectLocalAndRegionalPlansViewModel.ValidateImpl(project, localAndRegionalPlan);
            // Act
            // Assert - Associating non-Transpo project with Transpo plan is error
            Assert.That(error, Is.Not.Null, "Expecting error associating non-Transportation project with Transportation plan");

            localAndRegionalPlan.IsTransportationPlan = false;

            // Act
            error = EditProjectLocalAndRegionalPlansViewModel.ValidateImpl(project, localAndRegionalPlan);
            // Assert - Associating non-Transpo project with non-Transpo plan is valid
            Assert.That(error, Is.Null, "Associating non-Transportation project to non-Transportation plan should be valid");

            localAndRegionalPlan.IsTransportationPlan = true;
            project.TransportationObjective = TestFramework.TestTransportationObjective.Create();

            // Act
            error = EditProjectLocalAndRegionalPlansViewModel.ValidateImpl(project, localAndRegionalPlan);
            // Assert - Associating non-Transpo project with non-Transpo plan is valid
            Assert.That(error, Is.Null, "Associating Transportation project to Transportation plan should be valid");

            localAndRegionalPlan.IsTransportationPlan = false;
            project.TransportationObjective = TestFramework.TestTransportationObjective.Create();

            // Act
            error = EditProjectLocalAndRegionalPlansViewModel.ValidateImpl(project, localAndRegionalPlan);
            // Assert - Associating non-Transpo project with non-Transpo plan is valid
            Assert.That(error, Is.Null, "Associating Transportation project to non-Transportation plan should be valid");
        }
    }
}