using System.Web;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class EditProjectUpdateConfigurationViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForProject { get; }
        public EditProjectUpdateConfigurationViewData(FirmaSession currentFirmaSession) : base(currentFirmaSession)
        {
            FieldDefinitionForProject = FieldDefinitionEnum.Project.ToType();
        }
    }
}
