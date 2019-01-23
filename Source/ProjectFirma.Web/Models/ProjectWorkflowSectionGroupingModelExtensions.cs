using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public static class ProjectWorkflowSectionGroupingModelExtensions
    {
        private static List<ProjectSectionSimple> GetProjectCreateSectionsImpl(Project project, List<ProjectCreateSection> projectCreateSections, bool ignoreStatus)
        {
            return projectCreateSections.Select(x => new ProjectSectionSimple(x, x.GetSectionUrl(project), !ignoreStatus && x.IsComplete(project), false, project != null && x.HasCompletionStatus)).OrderBy(x => x.SortOrder).ToList();
        }

        private static List<ProjectSectionSimple> GetProjectUpdateSectionsImpl(ProjectUpdateBatch projectUpdateBatch, List<ProjectUpdateSection> projectUpdateSections, ProjectUpdateStatus projectUpdateStatus, bool ignoreStatus)
        {
            return projectUpdateSections.Select(x => new ProjectSectionSimple(x, x.GetSectionUrl(projectUpdateBatch.Project), !ignoreStatus && x.IsComplete(projectUpdateBatch), projectUpdateStatus != null && x.SectionIsUpdated(projectUpdateStatus))).OrderBy(x => x.SortOrder).ToList();
        }

        public static List<ProjectSectionSimple> GetProjectCreateSections(this ProjectWorkflowSectionGrouping projectWorkflowSectionGrouping, Project project, bool ignoreStatus)
        {
            switch (projectWorkflowSectionGrouping.ToEnum)
            {
                case ProjectWorkflowSectionGroupingEnum.Overview:
                    return GetProjectCreateSectionsImpl(project, projectWorkflowSectionGrouping.ProjectCreateSections, ignoreStatus);
                case ProjectWorkflowSectionGroupingEnum.AdditionalData:
                    var projectCreateSectionsForAdditionalData = projectWorkflowSectionGrouping.ProjectCreateSections.Except(new List<ProjectCreateSection> { ProjectCreateSection.Assessment }).ToList();
                    if (HttpRequestStorage.DatabaseEntities.AssessmentQuestions.Any())
                    {
                        projectCreateSectionsForAdditionalData.Add(ProjectCreateSection.Assessment);
                    }
                    return GetProjectCreateSectionsImpl(project, projectCreateSectionsForAdditionalData, ignoreStatus);
                case ProjectWorkflowSectionGroupingEnum.Expenditures:
                    var projectCreateSectionsForExpenditures = projectWorkflowSectionGrouping.ProjectCreateSections.Except(new List<ProjectCreateSection> { ProjectCreateSection.ExpectedFunding, ProjectCreateSection.ReportedExpenditures }).ToList();
                    if (project != null && project.IsExpectedFundingRelevant())
                    {
                        projectCreateSectionsForExpenditures.Add(ProjectCreateSection.ExpectedFunding);
                    }

                    if (project != null && project.AreReportedExpendituresRelevant())
                    {
                        projectCreateSectionsForExpenditures.Add(ProjectCreateSection.ReportedExpenditures);
                    }
                    return GetProjectCreateSectionsImpl(project, projectCreateSectionsForExpenditures, ignoreStatus);

                case ProjectWorkflowSectionGroupingEnum.PerformanceMeasures:
                    if (project != null && project.AreReportedPerformanceMeasuresRelevant())    
                    {
                        return GetProjectCreateSectionsImpl(project, projectWorkflowSectionGrouping.ProjectCreateSections, ignoreStatus);
                    }

                    return new List<ProjectSectionSimple>();
                case ProjectWorkflowSectionGroupingEnum.SpatialInformation:
                    var projectCreateSections = GetProjectCreateSectionsImpl(project, projectWorkflowSectionGrouping.ProjectCreateSections, ignoreStatus);
                    var maxSortOrder = projectCreateSections.Max(x => x.SortOrder);
                    IEnumerable<ProjectSectionSimple> projectSectionSimples;
                    var geospatialAreaTypes = HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes;
                    if (project == null)
                    {
                        projectSectionSimples = geospatialAreaTypes
                            .OrderBy(x => x.GeospatialAreaTypeName).ToList().Select((geospatialAreaType, index) =>
                                new ProjectSectionSimple(geospatialAreaType.GeospatialAreaTypeNamePluralized,
                                    maxSortOrder + index + 1,
                                    false, projectWorkflowSectionGrouping,
                                    string.Empty,
                                    false, false));
                    }
                    else
                    {
                        projectSectionSimples = geospatialAreaTypes
                            .OrderBy(x => x.GeospatialAreaTypeName).ToList().Select((geospatialAreaType, index) =>
                                new ProjectSectionSimple(geospatialAreaType.GeospatialAreaTypeNamePluralized,
                                    maxSortOrder + index + 1,
                                    true, projectWorkflowSectionGrouping,
                                    SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(y =>
                                        y.EditGeospatialArea(project, geospatialAreaType)),
                                    !ignoreStatus && geospatialAreaType.IsProjectGeospatialAreaValid(project), false));

                    }

                    projectCreateSections.AddRange(projectSectionSimples);
                    return projectCreateSections;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static List<ProjectSectionSimple> GetProjectUpdateSections(this ProjectWorkflowSectionGrouping projectWorkflowSectionGrouping, ProjectUpdateBatch projectUpdateBatch, ProjectUpdateStatus projectUpdateStatus, bool ignoreStatus)
        {
            switch (projectWorkflowSectionGrouping.ToEnum)
            {
                case ProjectWorkflowSectionGroupingEnum.Overview:
                    return GetProjectUpdateSectionsImpl(projectUpdateBatch, projectWorkflowSectionGrouping.ProjectUpdateSections, projectUpdateStatus, ignoreStatus);
                case ProjectWorkflowSectionGroupingEnum.SpatialInformation:
                    var projectUpdateSections = GetProjectUpdateSectionsImpl(projectUpdateBatch, projectWorkflowSectionGrouping.ProjectUpdateSections, projectUpdateStatus, ignoreStatus);
                    var maxSortOrder = projectUpdateSections.Max(x => x.SortOrder);
                    var geospatialAreaTypes = HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes;
                    projectUpdateSections.AddRange(geospatialAreaTypes
                        .OrderBy(x => x.GeospatialAreaTypeName).ToList().Select((geospatialAreaType, index) =>
                            new ProjectSectionSimple(geospatialAreaType.GeospatialAreaTypeNamePluralized, maxSortOrder + index + 1,
                                !projectUpdateBatch.IsNew, projectWorkflowSectionGrouping,
                                projectUpdateBatch.IsNew ? null :
                                    SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(y =>
                                        y.GeospatialArea(projectUpdateBatch.Project, geospatialAreaType)),
                                projectUpdateStatus != null && projectUpdateBatch.IsProjectGeospatialAreaValid(geospatialAreaType),
                                projectUpdateStatus != null && IsGeospatialAreaUpdated(projectUpdateBatch, geospatialAreaType)
                            )));
                    return projectUpdateSections;
                case ProjectWorkflowSectionGroupingEnum.PerformanceMeasures:
                    if (projectUpdateBatch.AreAccomplishmentsRelevant())
                    {
                        return GetProjectUpdateSectionsImpl(projectUpdateBatch, projectWorkflowSectionGrouping.ProjectUpdateSections, projectUpdateStatus, ignoreStatus);
                    }
                    return new List<ProjectSectionSimple>();
                case ProjectWorkflowSectionGroupingEnum.Expenditures:
                    var projectUpdateSectionsForExpenditures = projectWorkflowSectionGrouping.ProjectUpdateSections.Except(new List<ProjectUpdateSection> { ProjectUpdateSection.ExpectedFunding }).ToList();
                    if (projectUpdateBatch.Project.IsExpectedFundingRelevant())
                    {
                        projectUpdateSectionsForExpenditures.Add(ProjectUpdateSection.ExpectedFunding);
                    }

                    return GetProjectUpdateSectionsImpl(projectUpdateBatch, projectUpdateSectionsForExpenditures, projectUpdateStatus, ignoreStatus);
                case ProjectWorkflowSectionGroupingEnum.AdditionalData:
                    return GetProjectUpdateSectionsImpl(projectUpdateBatch, projectWorkflowSectionGrouping.ProjectUpdateSections, projectUpdateStatus, ignoreStatus);
                default:
                    throw new ArgumentOutOfRangeException();
            }

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
}