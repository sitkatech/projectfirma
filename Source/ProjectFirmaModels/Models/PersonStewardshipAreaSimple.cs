/*-----------------------------------------------------------------------
<copyright file="PersonStewardshipAreaSimple.cs" company="Tahoe Regional Planning Agency">
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

using System.ComponentModel.DataAnnotations;

namespace ProjectFirmaModels.Models
{
    public class PersonStewardshipAreaSimple
    {
        public int? PersonStewardshipAreaID { get; set; }
        
        [Required]
        public int? StewardshipAreaID { get; set; }

        /// <summary>
        /// Nedded by ModelBinder
        /// </summary>
        public PersonStewardshipAreaSimple()
        {

        }

        public PersonStewardshipAreaSimple(PersonStewardTaxonomyBranch personStewardTaxonomyBranch)
        {
            PersonStewardshipAreaID = personStewardTaxonomyBranch.PersonStewardTaxonomyBranchID;
            StewardshipAreaID = personStewardTaxonomyBranch.TaxonomyBranchID;
        }

        public PersonStewardshipAreaSimple(PersonStewardOrganization personStewardOrganization)
        {
            PersonStewardshipAreaID = personStewardOrganization.PersonStewardOrganizationID;
            StewardshipAreaID = personStewardOrganization.OrganizationID;
        }
        public PersonStewardshipAreaSimple(PersonStewardGeospatialArea personStewardGeospatialArea)
        {
            PersonStewardshipAreaID = personStewardGeospatialArea.PersonStewardGeospatialAreaID;
            StewardshipAreaID = personStewardGeospatialArea.GeospatialAreaID;
        }
    }
}
