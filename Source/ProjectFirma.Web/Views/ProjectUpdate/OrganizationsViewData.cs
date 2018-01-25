using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class OrganizationsViewData : ProjectUpdateViewData {
        public OrganizationsViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, ProjectUpdateSection currentSection, UpdateStatus updateStatus, List<string> validationWarnings) : base(currentPerson, projectUpdateBatch, currentSection, updateStatus, validationWarnings)
        {
        }
    }
}