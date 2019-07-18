/*-----------------------------------------------------------------------
<copyright file="OrganizationSimple.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class OrganizationSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public OrganizationSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public OrganizationSimple(int organizationID, Guid? organizationGuid, string organizationName,
            string organizationShortName, int organizationTypeId, int? primaryContactPersonID, bool isActive,
            string url, int? logoFileResourceID, string detailUrl)
            : this()
        {
            OrganizationID = organizationID;
            OrganizationGuid = organizationGuid;
            OrganizationName = organizationName;
            OrganizationShortName = organizationShortName;
            OrganizationTypeID = organizationTypeId;
            PrimaryContactPersonID = primaryContactPersonID;
            PrimaryContactPersonDisplayName = primaryContactPersonID != null ? HttpRequestStorage.DatabaseEntities.People.GetPerson(primaryContactPersonID.Value).GetFullNameFirstLastAndOrgShortName() : "nobody";
            IsActive = isActive;
            URL = url;
            DetailUrl = detailUrl;
            LogoFileResourceID = logoFileResourceID;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public OrganizationSimple(Organization organization)
            : this()
        {
            OrganizationID = organization.OrganizationID;
            OrganizationGuid = organization.OrganizationGuid;
            OrganizationName = organization.OrganizationName;
            OrganizationShortName = organization.OrganizationShortName;
            OrganizationTypeID = organization.OrganizationTypeID;
            PrimaryContactPersonID = organization.PrimaryContactPersonID;
            PrimaryContactPersonDisplayName = organization.PrimaryContactPerson != null ? organization.PrimaryContactPerson.GetFullNameFirstLastAndOrgShortName() : "nobody";
            IsActive = organization.IsActive;
            URL = organization.OrganizationUrl;
            DetailUrl = organization.GetDetailUrl();
            LogoFileResourceID = organization.LogoFileResourceID;
            ValidOrganizationRelationshipTypeSimples = organization.OrganizationType?.OrganizationTypeOrganizationRelationshipTypes.Select(x => x.OrganizationRelationshipType).ToList()
                                               .Select(x => new OrganizationRelationshipTypeSimple(x))
                                               .ToList() ?? new List<OrganizationRelationshipTypeSimple>();
        }

        public int OrganizationID { get; set; }
        public Guid? OrganizationGuid { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationShortName { get; set; }
        public int OrganizationTypeID { get; set; }
        public int? PrimaryContactPersonID { get; set; }
        public string PrimaryContactPersonDisplayName { get; set; }
        public bool IsActive { get; set; }
        public string URL { get; set; }
        public string DetailUrl { get; set; }
        public int? LogoFileResourceID { get; set; }
        public List<OrganizationRelationshipTypeSimple> ValidOrganizationRelationshipTypeSimples;

        public string DisplayName
        {
            get { return string.Format("{0}{1}", OrganizationName, !string.IsNullOrWhiteSpace(OrganizationShortName) ? string.Format(" ({0})", OrganizationShortName) : string.Empty); }
        }
    }
}
