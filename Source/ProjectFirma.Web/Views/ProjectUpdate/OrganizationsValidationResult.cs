/*-----------------------------------------------------------------------
<copyright file="OrganizationsValidationResult.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class OrganizationsValidationResult
    {
        private readonly List<string> _warningMessages;

        public OrganizationsValidationResult()
        {
            _warningMessages = new List<string>();
        }


        public OrganizationsValidationResult(List<ProjectOrganizationSimple> projectOrganizationSimples)
        {
            _warningMessages = new List<string>();

            // todo: is this the right linq? 90% sure it is.
            if (projectOrganizationSimples.GroupBy(x => new { RelationshipTypeID = x.OrganizationRelationshipTypeID, x.OrganizationID }).Any(x => x.Count() > 1))
            {
                _warningMessages.Add($"Cannot have the same organization relationship type listed for the same {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} multiple times.");
            }

            var relationshipTypeThatMustBeRelatedOnceToAProject = HttpRequestStorage.DatabaseEntities.OrganizationRelationshipTypes.Where(x => x.CanOnlyBeRelatedOnceToAProject).ToList();

            // no more than one todo right linq?
            var projectOrganizationsGroupedByOrganizationRelationshipTypeID =
                projectOrganizationSimples.GroupBy(x => x.OrganizationRelationshipTypeID).ToList();

            _warningMessages.AddRange(relationshipTypeThatMustBeRelatedOnceToAProject
                .Where(rt => projectOrganizationsGroupedByOrganizationRelationshipTypeID.Count(po => po.Key == rt.OrganizationRelationshipTypeID) > 1)
                .Select(relationshipType => 
                    $"Cannot have more than one {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} with a {FieldDefinitionEnum.ProjectOrganizationRelationshipType.ToType().GetFieldDefinitionLabel()} set to \"{relationshipType.OrganizationRelationshipTypeName}\"."));

            // not zero todo right linq?
            _warningMessages.AddRange(relationshipTypeThatMustBeRelatedOnceToAProject
                .Where(rt => projectOrganizationsGroupedByOrganizationRelationshipTypeID.Count(po => po.Key == rt.OrganizationRelationshipTypeID) == 0)
                .Select(relationshipType => 
                    $"Must have one {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} with a {FieldDefinitionEnum.ProjectOrganizationRelationshipType.ToType().GetFieldDefinitionLabel()} set to \"{relationshipType.OrganizationRelationshipTypeName}\"."));

            // todo right linq?
            var allValidRelationshipTypes = projectOrganizationSimples.All(x =>
            {
                var organization = HttpRequestStorage.DatabaseEntities.Organizations.GetOrganization(x.OrganizationID);
                var organizationType = organization.OrganizationType;

                if (organizationType != null)
                {
                    var organizationTypeOrganizationRelationshipTypeIDs =
                        organizationType.OrganizationTypeOrganizationRelationshipTypes.Select(y => y.OrganizationRelationshipTypeID);

                    return organizationTypeOrganizationRelationshipTypeIDs.Contains(x.OrganizationRelationshipTypeID);
                }
                return false;
            });

            if (!allValidRelationshipTypes)
            {
                _warningMessages.Add("One or more organization relationship types are invalid.");
            }
            
        }

        public List<string> GetWarningMessages()
        {
            return _warningMessages;
        }

        public bool IsValid => !_warningMessages.Any();
    }
}
