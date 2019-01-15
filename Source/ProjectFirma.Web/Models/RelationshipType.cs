using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public partial class RelationshipType : IAuditableEntity
    {
        public const string RelationshipTypeNameFunder = "Funder";

        public bool CanDelete()
        {
            return !ProjectOrganizations.Any();
        }
        public string AuditDescriptionString => RelationshipTypeName;

        public static bool IsRelationshipTypeNameUnique(List<RelationshipType> existingRelationshipTypes, string relationshipTypeName, int currentRelationshipTypeID)
        {
            var relationshipType = existingRelationshipTypes.SingleOrDefault(x => x.RelationshipTypeID != currentRelationshipTypeID && String.Equals(x.RelationshipTypeName, relationshipTypeName, StringComparison.InvariantCultureIgnoreCase));
            return relationshipType == null;
        }

        public bool HasOrganizationsWithSpatialBoundary()
        {
            return OrganizationTypeRelationshipTypes.Any(x =>
                x.OrganizationType.Organizations.Any(y => y.OrganizationBoundary != null));            
        }

        public Organization GetOrganizationContainingProjectSimpleLocation(IProject project)
        {
            if (!(HasOrganizationsWithSpatialBoundary() && CanOnlyBeRelatedOnceToAProject))
            {
                return null;
            }

            if (project.ProjectLocationPoint == null)
            {
                return null;
            }

            var organizationsInThisRelatonshipTypeWithBoundary = OrganizationTypeRelationshipTypes.SelectMany(x =>
                x.OrganizationType.Organizations.Where(y => y.OrganizationBoundary != null));

            return organizationsInThisRelatonshipTypeWithBoundary.FirstOrDefault(x =>
            {
                try
                {
                    var projectLocationPoint = project.ProjectLocationPoint;
                    var contains = x.OrganizationBoundary.Contains(projectLocationPoint);
                    return contains;
                }
                catch (Exception e)
                {
                    SitkaLogger.Instance.LogDetailedErrorMessage(e); //This typically trips if there are geometries with no SRID
                    return false;
                }
                
            });
            
        }

        public string DeleteUrl
        {
            get { return SitkaRoute<OrganizationAndRelationshipTypeController>.BuildUrlFromExpression(c => c.DeleteRelationshipType(RelationshipTypeID)); }
        }

        public bool IsAssociatedWithOrganiztionType(OrganizationType organizationType)
        {
            return OrganizationTypeRelationshipTypes.Select(x => x.OrganizationType).Contains(organizationType);
        }
    }
}