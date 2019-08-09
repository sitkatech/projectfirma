using System.Collections.Generic;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Shared.ProjectAttachment
{
    public class ProjectAttachmentsDetailViewData
    {

        public bool ShowDownload { get; }

        public ProjectFirmaModels.Models.Project Project { get; set; }
        //public string NewProjectAttachmentUrl { get; set; }
        //public UrlTemplate<int> EditProjectAttachmentUrlTemplate { get; set; }
        //public UrlTemplate<int> DeleteProjectAttachmentUrlTemplate { get; set; }
        public Person CurrentPerson { get; set; }
        //public bool UserHasProjectManagePermissions { get; set; }
        //public ProjectAttachmentEditAsAdminFeature ProjectAttachmentEditAsAdminFeature { get; set; }


        public List<EntityDocument> Attachments { get; }
        public string AddAttachmentUrl { get; }
        public string ProjectName { get; }
        public bool CanEditAttachments { get; }

        public string AttachmentRelationshipTypesIndexUrl { get; }

        public ProjectAttachmentsDetailViewData(List<EntityDocument> documents, string addAttachmentUrl, string projectName, bool canEditAttachments, Person currentPerson)
        {
            CurrentPerson = currentPerson;
            Attachments = documents;
            AddAttachmentUrl = addAttachmentUrl;
            ProjectName = projectName;
            CanEditAttachments = canEditAttachments;
            ShowDownload = true;
            AttachmentRelationshipTypesIndexUrl = new AttachmentRelationshipTypeManageFeature().HasPermissionByPerson(CurrentPerson) ? SitkaRoute<AttachmentRelationshipTypeController>.BuildUrlFromExpression(x => x.Index()) : string.Empty;
        }


        //public ProjectAttachmentsDetailViewData(ProjectFirmaModels.Models.Project project, Person currentPerson)
        //{
        //    Project = project;
        //    CurrentPerson = currentPerson;

        //    NewProjectAttachmentUrl = SitkaRoute<ProjectAttachmentController>.BuildUrlFromExpression(c => c.New(project));
        //    EditProjectAttachmentUrlTemplate = new UrlTemplate<int>(
        //        SitkaRoute<ProjectAttachmentController>.BuildUrlFromExpression(c => c.Edit(UrlTemplate.Parameter1Int)));
        //    DeleteProjectAttachmentUrlTemplate = new UrlTemplate<int>(
        //        SitkaRoute<ProjectAttachmentController>.BuildUrlFromExpression(c => c.Delete(UrlTemplate.Parameter1Int)));

        //    UserHasProjectManagePermissions =
        //        Project.IsProposal() ?
        //        new ProjectCreateFeature().HasPermission(currentPerson, project).HasPermission
        //         : new ProjectEditAsAdminFeature().HasPermission(currentPerson, project).HasPermission;
        //    ProjectAttachmentEditAsAdminFeature = new ProjectAttachmentEditAsAdminFeature();
        //}

        //public ProjectAttachmentsDetailViewData(ProjectFirmaModels.Models.Project project, Person currentPerson, bool showNewButton) : this(project, currentPerson)
        //{
        //    UserHasProjectManagePermissions = UserHasProjectManagePermissions && showNewButton;
        //}





        //public ProjectAttachmentsDetailViewData(List<EntityDocument> documents, string addAttachmentUrl, string projectName,
        //    bool canEditAttachments, bool showDownload) : this(documents,addAttachmentUrl,projectName,canEditAttachments)
        //{
        //    ShowDownload = showDownload;
        //}


    }
}
