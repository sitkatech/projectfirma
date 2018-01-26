/*-----------------------------------------------------------------------
<copyright file="ProjectOrganizationSimple.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
namespace ProjectFirma.Web.Models
{
    public class ProjectOrganizationSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectOrganizationSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        //public ProjectOrganizationSimple()
        //    : this()
        //{
        //}

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public ProjectOrganizationSimple(ProjectOrganization projectOrganization)
            : this()
        {
            OrganizationID = projectOrganization.OrganizationID;
            RelationshipTypeID = projectOrganization.RelationshipTypeID;
        }

        public ProjectOrganizationSimple(ProjectOrganizationUpdate projectOrganization)
        {
            OrganizationID = projectOrganization.OrganizationID;
            RelationshipTypeID = projectOrganization.RelationshipTypeID;
        }

        public int OrganizationID { get; set; }
        public int RelationshipTypeID { get; set; }
    }
}