using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.Mvc;
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
        public TenantAttribute TenantAttribute { get; }
        public bool HasExistingData { get; }

        public IEnumerable<SelectListItem> ProjectTypeSelectListItems { get; }

        public EditViewData(FirmaSession currentFirmaSession,
            string submitUrl,
            ProjectFirmaModels.Models.FirmaPage instructionsFirmaPage,
            ProjectFirmaModels.Models.ProjectCustomAttributeGroup projectCustomAttributeGroup)
            : base(currentFirmaSession)
        {
            EntityName = "Attribute Group";
            PageTitle =
                $"{(projectCustomAttributeGroup != null ? "Edit" : "New")} Attribute Group";
            ProjectCustomAttributeGroupIndexUrl =
                SitkaRoute<ProjectCustomAttributeGroupController>.BuildUrlFromExpression(x => x.Manage());
            SubmitUrl = submitUrl;

            ViewInstructionsFirmaPage = new ViewPageContentViewData(instructionsFirmaPage, currentFirmaSession);
            TenantAttribute = MultiTenantHelpers.GetTenantAttribute();
            ProjectTypeSelectListItems = ProjectType.All.ToSelectList(x => x.ProjectTypeID.ToString(), x => x.ProjectTypeDisplayName );

            if (projectCustomAttributeGroup != null && projectCustomAttributeGroup.ProjectCustomAttributeTypes.Any(x => x.ProjectCustomAttributes.Any(y => y.ProjectCustomAttributeValues.Any())))
            {
                HasExistingData = true;
            }
            else
            {
                HasExistingData = false;
            }
        }

    }
}
