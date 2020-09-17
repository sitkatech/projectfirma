using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirmaModels.Models
{
    public static class OrganizationTypeModelExtensions
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

        public static string GetDeleteUrl(OrganizationType organizationType)
        {
            return SitkaRoute<OrganizationTypeAndOrganizationRelationshipTypeController>.BuildUrlFromExpression(c =>
                c.DeleteOrganizationType(organizationType.OrganizationTypeID));
        }

        public static HtmlString GetOrganizationTypeHtmlStringWithColor(this OrganizationType organizationType)
        {
            var organizationTypeColor = organizationType.LegendColor;
            return new HtmlString($"<span style=\"vertical-align:middle; width:10px; height:10px; margin-right:5px; display:inline-block; background:{organizationTypeColor};\"></span>{organizationType.OrganizationTypeName}");
        }
    }
}