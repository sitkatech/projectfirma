using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public partial class OrganizationType : IAuditableEntity
    {
        public static bool IsOrganizationTypeNameUnique(IEnumerable<OrganizationType> organizationTypes, string organizationTypeName, int currentOrganizationTypeID)
        {
            var organizationType = organizationTypes.SingleOrDefault(x => x.OrganizationTypeID != currentOrganizationTypeID && String.Equals(x.OrganizationTypeName, organizationTypeName, StringComparison.InvariantCultureIgnoreCase));
            return organizationType == null;
        }

        public static bool IsOrganizationTypeAbbreviationUnique(IEnumerable<OrganizationType> organizationTypes, string organizationAbbreviation, int currentOrganizationTypeID)
        {
            var organizationType = organizationTypes.SingleOrDefault(x => x.OrganizationTypeID != currentOrganizationTypeID && String.Equals(x.OrganizationTypeAbbreviation, organizationAbbreviation, StringComparison.InvariantCultureIgnoreCase));
            return organizationType == null;
        }
        public string DeleteUrl
        {
            get { return SitkaRoute<OrganizationAndRelationshipTypeController>.BuildUrlFromExpression(c => c.DeleteOrganizationType(OrganizationTypeID)); }
        }

        public string AuditDescriptionString => OrganizationTypeName;
    }
}