/*-----------------------------------------------------------------------
<copyright file="EditPrimaryContactViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Organization
{
    public class EditPrimaryContactViewModel : FormViewModel
    {
        public int OrganizationID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.OrganizationPrimaryContact)]
        public int? PrimaryContactPersonID { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditPrimaryContactViewModel()
        {
        }

        public EditPrimaryContactViewModel(ProjectFirmaModels.Models.Organization organization)
        {
            OrganizationID = organization.OrganizationID;
            PrimaryContactPersonID = organization.PrimaryContactPerson?.PersonID;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Organization organization, FirmaSession currentFirmaSession)
        {
            organization.PrimaryContactPersonID = PrimaryContactPersonID;
        }
    }
}
