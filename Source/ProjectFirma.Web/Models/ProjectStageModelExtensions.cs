using System;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectStageModelExtensions
    {
        public static readonly UrlTemplate<int> EditUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProjectStageCustomLabelController>.BuildUrlFromExpression(t => t.Edit(UrlTemplate.Parameter1Int)));
        public static string GetEditUrl(this ProjectStage projectStage)
        {
            return EditUrlTemplate.ParameterReplace(projectStage.ProjectStageID);
        }

        public static ProjectStage ToType(this ProjectStageEnum projectStageEnum)
        {
            return ToType(projectStageEnum);
        }

        public static string GetProjectStageDisplayName(this ProjectStage projectStage)
        {
            var projectStageCustomLabel = projectStage.GetProjectStageCustomLabel();
            return projectStage.GetProjectStageLabelImpl(projectStageCustomLabel);
        }
        
        private static string GetProjectStageLabelImpl(this ProjectStage projectStage, ProjectStageCustomLabel projectStageCustomLabel)
        {
            if (projectStageCustomLabel != null && !string.IsNullOrWhiteSpace(projectStageCustomLabel.ProjectStageLabel))
            {
                return projectStageCustomLabel.ProjectStageLabel;
            }
            return projectStage.ProjectStageDisplayName;
        }
        
        public static bool HasCustomLabel(this ProjectStage projectStage)
        {
            var projectStageCustomLabel = projectStage.GetProjectStageCustomLabel();
            return projectStageCustomLabel != null && !string.IsNullOrWhiteSpace(projectStageCustomLabel.ProjectStageLabel);
        }
        
        public static ProjectStageCustomLabel GetProjectStageCustomLabel(this ProjectStage projectStage)
        {
            return HttpRequestStorage.DatabaseEntities.ProjectStageCustomLabels.SingleOrDefault(x => x.ProjectStageID == projectStage.ProjectStageID);
        }
        
        public static ProjectStageCustomLabel GetProjectStageCustomLabelForBackgroundJob(this ProjectStage projectStage, int tenantID)
        {
            return HttpRequestStorage.DatabaseEntities.ProjectStageCustomLabels.SingleOrDefault(x => x.TenantID == tenantID && x.ProjectStageID == projectStage.ProjectStageID);
        }
        
        public static string GetProjectStageLabelForBackgroundJob(this ProjectStage projectStage, int tenantID)
        {
            var projectStageCustomLabel = projectStage.GetProjectStageCustomLabelForBackgroundJob(tenantID);
            return projectStage.GetProjectStageLabelImpl(projectStageCustomLabel);
        }
    }
}