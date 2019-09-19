using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectCustomAttributeGroup
{
    public class EditViewData : FirmaViewData
    {
        public string ProjectCustomAttributeGroupIndexUrl { get; }
        public string SubmitUrl { get; }
        public ViewPageContentViewData ViewInstructionsFirmaPage { get; }


        public EditViewData(Person currentPerson,
            string submitUrl,
            ProjectFirmaModels.Models.FirmaPage instructionsFirmaPage,
            ProjectFirmaModels.Models.ProjectCustomAttributeGroup projectCustomAttributeGroup)
            : base(currentPerson)
        {
            EntityName = "Attribute Group";
            PageTitle =
                $"{(projectCustomAttributeGroup != null ? "Edit" : "New")} Attribute Group";
            ProjectCustomAttributeGroupIndexUrl =
                SitkaRoute<ProjectCustomAttributeGroupController>.BuildUrlFromExpression(x => x.Manage());
            SubmitUrl = submitUrl;

            ViewInstructionsFirmaPage = new ViewPageContentViewData(instructionsFirmaPage, currentPerson);

        }

    }
}
