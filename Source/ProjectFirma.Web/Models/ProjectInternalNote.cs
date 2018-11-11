using System;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectInternalNote : IEntityNote
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
            get { return SitkaRoute<ProjectInternalNoteController>.BuildUrlFromExpression(c => c.DeleteProjectInternalNote(this)); }
        }

        public string EditUrl
        {
            get { return SitkaRoute<ProjectInternalNoteController>.BuildUrlFromExpression(c => c.Edit(this)); }
        }
    }
}