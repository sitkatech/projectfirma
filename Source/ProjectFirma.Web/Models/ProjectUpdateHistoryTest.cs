using ProjectFirma.Web.UnitTestCommon;
using NUnit.Framework;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class ProjectUpdateHistoryTest
    {
        [Test]
        public void GetLatestProjectUpdateHistoryTest()
        {
            var person = TestFramework.TestPerson.Create();
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create();
            Assert.That(projectUpdateBatch.ProjectUpdateHistories.GetLatestProjectUpdateHistory(), Is.Null, "Should be null");

            var projectUpdateHistory1 = TestFramework.TestProjectUpdateHistory.Create(projectUpdateBatch, ProjectUpdateState.Created, person);
            AssertGetLatestReturnsCorrectly(projectUpdateBatch, projectUpdateHistory1, ProjectUpdateState.Created);

            // create one in the past
            var projectUpdateHistory2 = TestFramework.TestProjectUpdateHistory.Create(projectUpdateBatch, ProjectUpdateState.Created, person);
            projectUpdateHistory2.TransitionDate = projectUpdateHistory1.TransitionDate.AddDays(-2);
            AssertGetLatestReturnsCorrectly(projectUpdateBatch, projectUpdateHistory1, ProjectUpdateState.Created);

            // create one in the future and in a different transition
            var projectUpdateHistory3 = TestFramework.TestProjectUpdateHistory.Create(projectUpdateBatch, ProjectUpdateState.Submitted, person);
            projectUpdateHistory3.TransitionDate = projectUpdateHistory1.TransitionDate.AddDays(1);
            AssertGetLatestReturnsCorrectly(projectUpdateBatch, projectUpdateHistory3, ProjectUpdateState.Submitted);

            // create one in the future and in a different transition
            var projectUpdateHistory4 = TestFramework.TestProjectUpdateHistory.Create(projectUpdateBatch, ProjectUpdateState.Approved, person);
            projectUpdateHistory4.TransitionDate = projectUpdateHistory3.TransitionDate.AddDays(2);
            AssertGetLatestReturnsCorrectly(projectUpdateBatch, projectUpdateHistory4, ProjectUpdateState.Approved);

            // create one that is in between projectUpdateHistory3 and projectUpdateHistory4
            var projectUpdateHistory5 = TestFramework.TestProjectUpdateHistory.Create(projectUpdateBatch, ProjectUpdateState.Returned, person);
            projectUpdateHistory5.TransitionDate = projectUpdateHistory3.TransitionDate.AddDays(1);
            AssertGetLatestReturnsCorrectly(projectUpdateBatch, projectUpdateHistory4, ProjectUpdateState.Approved);
        }

        private static void AssertGetLatestReturnsCorrectly(ProjectUpdateBatch projectUpdateBatch,
            ProjectUpdateHistory expectedProjectUpdateHistory,
            ProjectUpdateState projectUpdateStateExpected)
        {
            Assert.That(projectUpdateBatch.ProjectUpdateHistories.GetLatestProjectUpdateHistory(), Is.EqualTo(expectedProjectUpdateHistory), "Should have gotten the correct latest one");
            AssertGetLatestForTransitionReturnsCorrectly(projectUpdateBatch, expectedProjectUpdateHistory, projectUpdateStateExpected, ProjectUpdateState.Created);
            AssertGetLatestForTransitionReturnsCorrectly(projectUpdateBatch, expectedProjectUpdateHistory, projectUpdateStateExpected, ProjectUpdateState.Submitted);
            AssertGetLatestForTransitionReturnsCorrectly(projectUpdateBatch, expectedProjectUpdateHistory, projectUpdateStateExpected, ProjectUpdateState.Approved);
            AssertGetLatestForTransitionReturnsCorrectly(projectUpdateBatch, expectedProjectUpdateHistory, projectUpdateStateExpected, ProjectUpdateState.Returned);
        }

        private static void AssertGetLatestForTransitionReturnsCorrectly(ProjectUpdateBatch projectUpdateBatch,
            ProjectUpdateHistory expectedProjectUpdateHistory,
            ProjectUpdateState projectUpdateStateExpected,
            ProjectUpdateState projectUpdateStateToCheck)
        {
            if (projectUpdateStateExpected == projectUpdateStateToCheck)
            {
                Assert.That(projectUpdateBatch.ProjectUpdateHistories.GetLatestProjectUpdateHistory(projectUpdateStateToCheck),
                    Is.EqualTo(expectedProjectUpdateHistory),
                    "Should have gotten the latest one in this transition");
            }
            else
            {
                var latestProjectUpdateHistory = projectUpdateBatch.ProjectUpdateHistories.GetLatestProjectUpdateHistory();
                Assert.That(latestProjectUpdateHistory.ProjectUpdateState, Is.Not.EqualTo(projectUpdateStateToCheck), "Should not return a ProjectUpdateHistory in this transition");
            }
        }
    }
}