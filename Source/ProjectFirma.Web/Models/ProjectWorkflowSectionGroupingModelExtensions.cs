using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

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
            var sections = projectUpdateSections.Select(x => new ProjectSectionSimple(x, x.GetSectionUrl(projectUpdateBatch.Project), !ignoreStatus && x.IsComplete(projectUpdateBatch), projectUpdateStatus != null && x.SectionIsUpdated(projectUpdateStatus))).OrderBy(x => x.SortOrder).ToList();
            return sections;
        }

        public static List<ProjectSectionSimple> GetProjectCreateSections(this ProjectWorkflowSectionGrouping projectWorkflowSectionGrouping, Project project, bool ignoreStatus)
        {
            switch (projectWorkflowSectionGrouping.ToEnum)
            {
                case ProjectWorkflowSectionGroupingEnum.Overview:
                    // remove the custom attributes section from the overview section to begin with
                    var projectCreateSectionForOverview = projectWorkflowSectionGrouping.ProjectCreateSections.Except(new List<ProjectCreateSection> {ProjectCreateSection.CustomAttributes}).ToList();
                    // If there are custom attribute types for this tenant, we can add the section back
                    if (HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.Any())
                    {
                        projectCreateSectionForOverview.Add(ProjectCreateSection.CustomAttributes);
                    }
                    return GetProjectCreateSectionsImpl(project, projectCreateSectionForOverview, ignoreStatus);
                case ProjectWorkflowSectionGroupingEnum.AdditionalData:
                    var projectCreateSectionsForAdditionalData = projectWorkflowSectionGrouping.ProjectCreateSections.Except(new List<ProjectCreateSection> { ProjectCreateSection.Assessment }).ToList();

                    if (HttpRequestStorage.DatabaseEntities.AssessmentQuestions.Any())
                    {
                        projectCreateSectionsForAdditionalData.Add(ProjectCreateSection.Assessment);
                    }
                    return GetProjectCreateSectionsImpl(project, projectCreateSectionsForAdditionalData, ignoreStatus);
                case ProjectWorkflowSectionGroupingEnum.Financials:
                    var projectCreateSectionsForExpenditures = projectWorkflowSectionGrouping.ProjectCreateSections.Except(new List<ProjectCreateSection> { ProjectCreateSection.Budget, ProjectCreateSection.ReportedExpenditures }).ToList();
                    if (project != null && project.IsExpectedFundingRelevant())
                    {
                        projectCreateSectionsForExpenditures.Add(ProjectCreateSection.Budget);
                    }

                    if (project != null && project.AreReportedExpendituresRelevant())
                    {
                        projectCreateSectionsForExpenditures.Add(ProjectCreateSection.ReportedExpenditures);
                    }
                    return GetProjectCreateSectionsImpl(project, projectCreateSectionsForExpenditures, ignoreStatus);

                case ProjectWorkflowSectionGroupingEnum.Accomplishments:
                    if (project == null)
                    {
                        return new List<ProjectSectionSimple>();
                    }

                    if (project.AreReportedPerformanceMeasuresRelevant())
                    {
                        return GetProjectCreateSectionsImpl(project, new List<ProjectCreateSection> { ProjectCreateSection.ExpectedAccomplishments, ProjectCreateSection.ReportedAccomplishments }, ignoreStatus);
                    }

                    return GetProjectCreateSectionsImpl(project, new List<ProjectCreateSection> { ProjectCreateSection.ExpectedAccomplishments }, ignoreStatus);
                case ProjectWorkflowSectionGroupingEnum.SpatialInformation:
                    var geospatialAreaTypes = HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes;
                    var createSections = projectWorkflowSectionGrouping.ProjectCreateSections.Except(new List<ProjectCreateSection> { ProjectCreateSection.BulkSetSpatialInformation }).ToList();
                    if (geospatialAreaTypes.Count() > 1)
                    {
                        createSections.Add(ProjectCreateSection.BulkSetSpatialInformation);
                    }
                    var projectCreateSections = GetProjectCreateSectionsImpl(project, createSections, ignoreStatus);
                    int maxSortOrder = 0;
                    if (projectCreateSections.Any())
                    {
                        maxSortOrder = projectCreateSections.Max(x => x.SortOrder);
                    }                    
                    IEnumerable<ProjectSectionSimple> projectSectionSimples;
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
                    // remove the custom attributes section from the overview section to begin with
                    var projectUpdateSectionForCustomAttributes = projectWorkflowSectionGrouping.ProjectUpdateSections.Except(new List<ProjectUpdateSection> { ProjectUpdateSection.CustomAttributes }).ToList();
                    // If there are custom attribute types for this tenant, we can add the section back
                    if (HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.Any())
                    {
                        projectUpdateSectionForCustomAttributes.Add(ProjectUpdateSection.CustomAttributes);
                    }
                    return GetProjectUpdateSectionsImpl(projectUpdateBatch, projectUpdateSectionForCustomAttributes, projectUpdateStatus, ignoreStatus);
                case ProjectWorkflowSectionGroupingEnum.SpatialInformation:
                    var geospatialAreaTypes = HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes;
                    var updateSections = projectWorkflowSectionGrouping.ProjectUpdateSections.Except(new List<ProjectUpdateSection> { ProjectUpdateSection.BulkSetSpatialInformation }).ToList();
                    if (geospatialAreaTypes.Count() > 1)
                    {
                        updateSections.Add(ProjectUpdateSection.BulkSetSpatialInformation);
                    }
                    var projectUpdateSections = GetProjectUpdateSectionsImpl(projectUpdateBatch, updateSections, projectUpdateStatus, ignoreStatus);
                    int maxSortOrder = 0;
                    if (projectUpdateSections.Any())
                    {
                        maxSortOrder = projectUpdateSections.Max(x => x.SortOrder);
                    }
                    projectUpdateSections.AddRange(geospatialAreaTypes
                        .OrderBy(x => x.GeospatialAreaTypeName).ToList().Select((geospatialAreaType, index) =>
                            new ProjectSectionSimple(geospatialAreaType.GeospatialAreaTypeNamePluralized, maxSortOrder + index + 1,
                                !projectUpdateBatch.IsNew(), projectWorkflowSectionGrouping,
                                projectUpdateBatch.IsNew() ? null :
                                    SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(y =>
                                        y.GeospatialArea(projectUpdateBatch.Project, geospatialAreaType)),
                                projectUpdateStatus != null && projectUpdateBatch.IsProjectGeospatialAreaValid(geospatialAreaType),
                                projectUpdateStatus != null && IsGeospatialAreaUpdated(projectUpdateBatch, geospatialAreaType)
                            )));
                    return projectUpdateSections;
                case ProjectWorkflowSectionGroupingEnum.Accomplishments:
                    var projectUpdateSectionsForPerformanceMeasures = projectWorkflowSectionGrouping.ProjectUpdateSections.Except(new List<ProjectUpdateSection> { ProjectUpdateSection.ReportedAccomplishments}).ToList();
                    if (projectUpdateBatch.AreAccomplishmentsRelevant())
                    {
                        projectUpdateSectionsForPerformanceMeasures.Add(ProjectUpdateSection.ReportedAccomplishments);
                    }
                    return GetProjectUpdateSectionsImpl(projectUpdateBatch, projectUpdateSectionsForPerformanceMeasures, projectUpdateStatus, ignoreStatus);
                case ProjectWorkflowSectionGroupingEnum.Financials:
                    var projectUpdateSectionsForExpenditures = projectWorkflowSectionGrouping.ProjectUpdateSections.Except(new List<ProjectUpdateSection> { ProjectUpdateSection.Budget }).ToList();
                    if (projectUpdateBatch.Project.IsExpectedFundingRelevant())
                    {
                        projectUpdateSectionsForExpenditures.Add(ProjectUpdateSection.Budget);
                    }
                    return GetProjectUpdateSectionsImpl(projectUpdateBatch, projectUpdateSectionsForExpenditures, projectUpdateStatus, ignoreStatus);
                case ProjectWorkflowSectionGroupingEnum.AdditionalData:
                    var additionalDataProjectUpdateSections = projectWorkflowSectionGrouping.ProjectUpdateSections.ToList();

                    var sections = GetProjectUpdateSectionsImpl(projectUpdateBatch, additionalDataProjectUpdateSections, projectUpdateStatus, ignoreStatus);
                    // Remove Technical Assistance Requests for all tenants except Idaho
                    if (!MultiTenantHelpers.UsesTechnicalAssistanceParameters())
                    {
                        sections = sections.Where(x => x.SectionDisplayName != ProjectUpdateSection.TechnicalAssistanceRequests.ProjectUpdateSectionDisplayName).ToList();
                    }
                    return sections;
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