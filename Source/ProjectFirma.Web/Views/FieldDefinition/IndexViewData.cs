using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.FieldDefinition
{
    public class IndexViewData : SiteLayoutViewData
    {
        public readonly FieldDefinitionGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;
        public readonly string FieldDefinitionDataUrl;

        public IndexViewData(Person currentPerson) : base(currentPerson)
        {
            PageTitle = "Manage Field Definitions";

            GridSpec = new FieldDefinitionGridSpec(new FieldDefinitionViewListFeature().HasPermissionByPerson(currentPerson))
            {
                ObjectNameSingular = "Field Definition",
                ObjectNamePlural = "Field Definitions",
                SaveFiltersInCookie = true
            };
            GridName = "fieldDefinitionsGrid";
            GridDataUrl = SitkaRoute<FieldDefinitionController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());

            FieldDefinitionDataUrl = SitkaRoute<FieldDefinitionController>.BuildUrlFromExpression(x => x.FieldDefinitionDetails(UrlTemplate.Parameter1Int));
        }
    }
}