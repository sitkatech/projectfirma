using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security.Shared;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View {0} and Relationship Types", FieldDefinitionEnum.Organization)]
    public class OrganizationAndRelationshipTypeViewFeature : SitkaAdminFeature
    {
    }
}