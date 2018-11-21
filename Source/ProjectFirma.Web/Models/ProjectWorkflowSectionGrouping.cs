using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.ProjectUpdate;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectWorkflowSectionGrouping
    {
        public abstract List<ProjectSectionSimple> GetProjectCreateSections(Project project);

        protected List<ProjectSectionSimple> GetProjectCreateSectionsImpl(Project project,
            List<ProjectCreateSection> projectCreateSections)
        {
            return projectCreateSections.Select(x => new ProjectSectionSimple(x, x.GetSectionUrl(project), x.IsComplete(project), false, project != null && x.HasCompletionStatus)).OrderBy(x => x.SortOrder).ToList();
        }

        public abstract List<ProjectSectionSimple> GetProjectUpdateSections(ProjectUpdateBatch projectUpdateBatch,
            UpdateStatus updateStatus);

        protected List<ProjectSectionSimple> GetProjectUpdateSectionsImpl(ProjectUpdateBatch projectUpdateBatch,
            List<ProjectUpdateSection> projectUpdateSections, UpdateStatus updateStatus)
        {
            return projectUpdateSections.Select(x => new ProjectSectionSimple(x, x.GetSectionUrl(projectUpdateBatch.Project), x.IsComplete(projectUpdateBatch), updateStatus != null && x.SectionIsUpdated(updateStatus))).OrderBy(x => x.SortOrder).ToList();
        }
    }

    public partial class ProjectWorkflowSectionGroupingOverview
    {
        public override List<ProjectSectionSimple> GetProjectCreateSections(Project project)
        {
            return GetProjectCreateSectionsImpl(project, ProjectCreateSections);
        }

        public override List<ProjectSectionSimple> GetProjectUpdateSections(ProjectUpdateBatch projectUpdateBatch,
            UpdateStatus updateStatus)
        {
            return GetProjectUpdateSectionsImpl(projectUpdateBatch, ProjectUpdateSections, updateStatus);
        }
    }

    public partial class ProjectWorkflowSectionGroupingLocation
    {
        public override List<ProjectSectionSimple> GetProjectCreateSections(Project project)
        {
            var projectCreateSections = GetProjectCreateSectionsImpl(project, ProjectCreateSections);
            var maxSortOrder = projectCreateSections.Max(x => x.SortOrder);
            IEnumerable<ProjectSectionSimple> projectSectionSimples;
            if (project == null)
            {
                projectSectionSimples = HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes
                    .OrderBy(x => x.GeospatialAreaTypeName).ToList().Select((geospatialAreaType, index) =>
                        new ProjectSectionSimple(geospatialAreaType.GeospatialAreaTypeNamePluralized,
                            maxSortOrder + index + 1,
                            false, this,
                            string.Empty,
                            false, false));
            }
            else
            {
                projectSectionSimples = HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes
                    .OrderBy(x => x.GeospatialAreaTypeName).ToList().Select((geospatialAreaType, index) =>
                        new ProjectSectionSimple(geospatialAreaType.GeospatialAreaTypeNamePluralized,
                            maxSortOrder + index + 1,
                            true, this,
                            SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(y =>
                                y.EditGeospatialArea(project, geospatialAreaType)),
                            project.IsProjectGeospatialAreaValid(geospatialAreaType), false));

            }

            projectCreateSections.AddRange(projectSectionSimples);
            return projectCreateSections;
        }

        public override List<ProjectSectionSimple> GetProjectUpdateSections(ProjectUpdateBatch projectUpdateBatch,
            UpdateStatus updateStatus)
        {
            var projectUpdateSections = GetProjectUpdateSectionsImpl(projectUpdateBatch, ProjectUpdateSections, updateStatus);
            var maxSortOrder = projectUpdateSections.Max(x => x.SortOrder);
            projectUpdateSections.AddRange(HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes
                .OrderBy(x => x.GeospatialAreaTypeName).ToList().Select((geospatialAreaType, index) =>
                    new ProjectSectionSimple(geospatialAreaType.GeospatialAreaTypeNamePluralized, maxSortOrder + index + 1,
                        !projectUpdateBatch.IsNew, this,
                        projectUpdateBatch.IsNew ? null :
                        SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(y =>
                            y.GeospatialArea(projectUpdateBatch.Project, geospatialAreaType)),
                        updateStatus != null && projectUpdateBatch.IsProjectGeospatialAreaValid(geospatialAreaType),
                        updateStatus != null && IsGeospatialAreaUpdated(projectUpdateBatch, geospatialAreaType)
                    )));
            return projectUpdateSections;
        }

        private static bool IsGeospatialAreaUpdated(ProjectUpdateBatch projectUpdateBatch, GeospatialAreaType geospatialAreaType)
        {
            var project = projectUpdateBatch.Project;            
            var originalGeospatialAreaIDs = project.ProjectGeospatialAreas.Where(x => x.GeospatialArea.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID).Select(x => x.GeospatialAreaID).ToList();
            var updatedGeospatialAreaIDs = projectUpdateBatch.ProjectGeospatialAreaUpdates.Where(x => x.GeospatialArea.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID).Select(x => x.GeospatialAreaID).ToList();

            if (!originalGeospatialAreaIDs.Any() && !updatedGeospatialAreaIDs.Any())
                return false;

            if (originalGeospatialAreaIDs.Count != updatedGeospatialAreaIDs.Count)
                return true;

            var enumerable = originalGeospatialAreaIDs.Except(updatedGeospatialAreaIDs);
            return enumerable.Any();
        }

    }

    public partial class ProjectWorkflowSectionGroupingPerformanceMeasures
    {

        public override List<ProjectSectionSimple> GetProjectCreateSections(Project project)
        {
            if (project != null && project.AreReportedPerformanceMeasuresRelevant())
            {
                return GetProjectCreateSectionsImpl(project, ProjectCreateSections);
            }

            return new List<ProjectSectionSimple>();
        }

        public override List<ProjectSectionSimple> GetProjectUpdateSections(ProjectUpdateBatch projectUpdateBatch,
            UpdateStatus updateStatus)
        {
            if (projectUpdateBatch.AreAccomplishmentsRelevant())
            {
                return GetProjectUpdateSectionsImpl(projectUpdateBatch, ProjectUpdateSections, updateStatus);
            }

            return  new List<ProjectSectionSimple>();
        }
    }

    public partial class ProjectWorkflowSectionGroupingExpenditures
    {
        public override List<ProjectSectionSimple> GetProjectCreateSections(Project project)
        {
            var projectCreateSections = ProjectCreateSections.Except(new List<ProjectCreateSection> { ProjectCreateSection.ExpectedFunding, ProjectCreateSection.ReportedExpenditures }).ToList();
            if (project != null && project.IsExpectedFundingRelevant())
            {
                projectCreateSections.Add(ProjectCreateSection.ExpectedFunding);
            }

            if (project != null && project.AreReportedExpendituresRelevant())
            {
                projectCreateSections.Add(ProjectCreateSection.ReportedExpenditures);
            }
            return GetProjectCreateSectionsImpl(project, projectCreateSections);
        }

        public override List<ProjectSectionSimple> GetProjectUpdateSections(ProjectUpdateBatch projectUpdateBatch,
            UpdateStatus updateStatus)
        {
            var projectUpdateSections = ProjectUpdateSections.Except(new List<ProjectUpdateSection> { ProjectUpdateSection.ExpectedFunding }).ToList();
            if (projectUpdateBatch.Project.IsExpectedFundingRelevant())
            {
                projectUpdateSections.Add(ProjectUpdateSection.ExpectedFunding);
            }

            return GetProjectUpdateSectionsImpl(projectUpdateBatch, projectUpdateSections, updateStatus);
        }
    }

    public partial class ProjectWorkflowSectionGroupingAdditionalData
    {
        public override List<ProjectSectionSimple> GetProjectCreateSections(Project project)
        {
            return GetProjectCreateSectionsImpl(project, ProjectCreateSections);
        }

        public override List<ProjectSectionSimple> GetProjectUpdateSections(ProjectUpdateBatch projectUpdateBatch,
            UpdateStatus updateStatus)
        {
            return GetProjectUpdateSectionsImpl(projectUpdateBatch, ProjectUpdateSections, updateStatus);
        }
    }
}