using System;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectNote : IAuditableEntity, IEntityNote
    {
        public DateTime LastUpdated
        {
            get { return UpdateDate ?? CreateDate; }
        }

        public string LastUpdatedBy
        {
            get
            {
                if (UpdatePersonID.HasValue)
                {
                    return UpdatePerson.FullNameFirstLast;
                }
                if (CreatePersonID.HasValue)
                {
                    return CreatePerson.FullNameFirstLast;
                }
                return "System";
            }
        }

        public string DeleteUrl
        {
            get { return SitkaRoute<ProjectNoteController>.BuildUrlFromExpression(c => c.DeleteProjectNote(ProjectNoteID)); }
        }

        public string EditUrl
        {
            get { return SitkaRoute<ProjectNoteController>.BuildUrlFromExpression(c => c.Edit(ProjectNoteID)); }
        }

        public string CreatePersonName
        {
            get { return CreatePersonID.HasValue ? CreatePerson.FullNameFirstLast : string.Empty; }
        }

        public string AuditDescriptionString
        {
            get
            {
                var project = HttpRequestStorage.DatabaseEntities.Projects.Find(ProjectID);
                var projectName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                return string.Format("Project: {0}", projectName);
            }
        }
    }
}