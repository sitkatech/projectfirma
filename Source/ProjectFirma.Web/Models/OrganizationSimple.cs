/*-----------------------------------------------------------------------
<copyright file="OrganizationSimple.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
        public OrganizationSimple(int organizationID, Guid? organizationGuid, string organizationName, string organizationAbbreviation, int organizationTypeId, int? primaryContactPersonID, bool isActive, string url, int? logoFileResourceID)
            : this()
        {
            OrganizationID = organizationID;
            OrganizationGuid = organizationGuid;
            OrganizationName = organizationName;
            OrganizationAbbreviation = organizationAbbreviation;
            OrganizationTypeID = organizationTypeId;
            PrimaryContactPersonID = primaryContactPersonID;
            IsActive = isActive;
            URL = url;
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
            OrganizationAbbreviation = organization.OrganizationAbbreviation;
            OrganizationTypeID = organization.OrganizationTypeID.Value;
            PrimaryContactPersonID = organization.PrimaryContactPersonID;
            IsActive = organization.IsActive;
            URL = organization.OrganizationUrl;
            LogoFileResourceID = organization.LogoFileResourceID;
        }

        public int OrganizationID { get; set; }
        public Guid? OrganizationGuid { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationAbbreviation { get; set; }
        public int OrganizationTypeID { get; set; }
        public int? PrimaryContactPersonID { get; set; }
        public bool IsActive { get; set; }
        public string URL { get; set; }
        public int? LogoFileResourceID { get; set; }
        
        public string DisplayName
        {
            get { return string.Format("{0}{1}", OrganizationName, !string.IsNullOrWhiteSpace(OrganizationAbbreviation) ? string.Format(" ({0})", OrganizationAbbreviation) : string.Empty); }
        }
    }
}
