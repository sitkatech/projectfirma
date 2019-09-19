using System;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectCustomAttributeGroupModelExtensions
    {
        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<ProjectCustomAttributeGroupController>.BuildUrlFromExpression(c => c.DeleteProjectCustomAttributeGroup(UrlTemplate.Parameter1Int)));

        public static readonly UrlTemplate<int> EditUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<ProjectCustomAttributeGroupController>.BuildUrlFromExpression(c => c.Edit(UrlTemplate.Parameter1Int)));
        
        public static string GetDeleteUrl(this ProjectCustomAttributeGroup projectCustomAttributeGroup) => DeleteUrlTemplate.ParameterReplace(projectCustomAttributeGroup.ProjectCustomAttributeGroupID);
        public static string GetEditUrl(this ProjectCustomAttributeGroup projectCustomAttributeGroup) => EditUrlTemplate.ParameterReplace(projectCustomAttributeGroup.ProjectCustomAttributeGroupID);

    }
}