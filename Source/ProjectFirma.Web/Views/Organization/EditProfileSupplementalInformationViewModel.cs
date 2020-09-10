/*-----------------------------------------------------------------------
<copyright file="EditProfileSupplementalInformationViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Organization
{
    public class EditProfileSupplementalInformationViewModel : FormViewModel
    {
        public int OrganizationID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.OrganizationCash)]
        public bool MatchmakerCash { get; set; }

        [StringLength(ProjectFirmaModels.Models.Organization.FieldLengths.MatchmakerCashDescription)]
        [DisplayName("Cash Description")]
        public string MatchmakerCashDescription { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.OrganizationInKindServices)]
        public bool MatchmakerInKindServices { get; set; }

        [StringLength(ProjectFirmaModels.Models.Organization.FieldLengths.MatchmakerInKindServicesDescription)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.OrganizationInKindServices)]
        public string MatchmakerInKindServicesDescription { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.OrganizationCommercialServices)]
        public bool MatchmakerCommercialServices { get; set; }

        [StringLength(ProjectFirmaModels.Models.Organization.FieldLengths.MatchmakerCommercialServicesDescription)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.OrganizationCommercialServices)]
        public string MatchmakerCommercialServicesDescription { get; set; }

        [StringLength(ProjectFirmaModels.Models.Organization.FieldLengths.MatchmakerConstraints)]
        [DisplayName("Partner Constraints")]
        public string MatchmakerConstraints { get; set; }

        [StringLength(ProjectFirmaModels.Models.Organization.FieldLengths.MatchmakerAdditionalInformation)]
        [DisplayName("Additional Information")]
        public string MatchmakerAdditionalInformation { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProfileSupplementalInformationViewModel()
        {
        }

        public EditProfileSupplementalInformationViewModel(ProjectFirmaModels.Models.Organization organization)
        {
            OrganizationID = organization.OrganizationID;
            MatchmakerCashDescription = organization.MatchmakerCashDescription;
            MatchmakerCash = organization.MatchmakerCash ?? false;
            MatchmakerInKindServicesDescription = organization.MatchmakerInKindServicesDescription;
            MatchmakerInKindServices = organization.MatchmakerInKindServices ?? false;
            MatchmakerCommercialServicesDescription = organization.MatchmakerCommercialServicesDescription;
            MatchmakerCommercialServices = organization.MatchmakerCommercialServices ?? false;
            MatchmakerConstraints = organization.MatchmakerConstraints;
            MatchmakerAdditionalInformation = organization.MatchmakerAdditionalInformation;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Organization organization)
        {
            organization.MatchmakerCash = MatchmakerCash;
            organization.MatchmakerCashDescription = MatchmakerCashDescription;
            organization.MatchmakerInKindServices = MatchmakerInKindServices;
            organization.MatchmakerInKindServicesDescription = MatchmakerInKindServicesDescription;
            organization.MatchmakerCommercialServices = MatchmakerCommercialServices;
            organization.MatchmakerCommercialServicesDescription = MatchmakerCommercialServicesDescription;
            organization.MatchmakerConstraints = MatchmakerConstraints;
            organization.MatchmakerAdditionalInformation = MatchmakerAdditionalInformation;
        }
    }
}
