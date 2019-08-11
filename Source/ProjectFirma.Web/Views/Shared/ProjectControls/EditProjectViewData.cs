/*-----------------------------------------------------------------------
<copyright file="EditProjectViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class EditProjectViewData : FirmaUserControlViewData
    {
        public IEnumerable<SelectListItem> TaxonomyLeafs { get; }
        public IEnumerable<SelectListItem> StartYearRange { get; }
        public IEnumerable<SelectListItem> CompletionYearRange { get; }
        public IEnumerable<SelectListItem> ProjectStages { get; }
        public IEnumerable<SelectListItem> Organizations { get; }
        public IEnumerable<SelectListItem> PrimaryContactPeople { get; }
        public Person DefaultPrimaryContactPerson { get; }
        public EditProjectType EditProjectType { get; }
        public string TaxonomyLeafDisplayName { get; }
        public decimal? TotalExpenditures { get; }
        public string DefaultPrimaryContactPersonName { get; }
        public bool HasThreeTierTaxonomy { get; }
        public IEnumerable<ProjectFirmaModels.Models.ProjectCustomAttributeType> ProjectCustomAttributeTypes { get; }
        public TenantAttribute TenantAttribute { get; set; }

        public EditProjectViewData(EditProjectType editProjectType,
            string taxonomyLeafDisplayName,
            IEnumerable<ProjectStage> projectStages,
            IEnumerable<ProjectFirmaModels.Models.Organization> organizations,
            IEnumerable<Person> primaryContactPeople,
            Person defaultPrimaryContactPerson,
            decimal? totalExpenditures,
            List<ProjectFirmaModels.Models.TaxonomyLeaf> taxonomyLeafs,
            IEnumerable<ProjectFirmaModels.Models.ProjectCustomAttributeType> projectCustomAttributeTypes,
            TenantAttribute tenantAttribute)
        {
            EditProjectType = editProjectType;
            TaxonomyLeafDisplayName = taxonomyLeafDisplayName;
            TotalExpenditures = totalExpenditures;
            ProjectStages = projectStages.OrderBy(x => x.SortOrder).ToSelectListWithEmptyFirstRow(x => x.ProjectStageID.ToString(CultureInfo.InvariantCulture), y => y.ProjectStageDisplayName);
            Organizations = organizations.ToSelectListWithEmptyFirstRow(x => x.OrganizationID.ToString(CultureInfo.InvariantCulture), y => y.GetDisplayName());
            PrimaryContactPeople = primaryContactPeople.ToSelectListWithEmptyFirstRow(
                    x => x.PersonID.ToString(CultureInfo.InvariantCulture), y => y.GetFullNameFirstLastAndOrgShortName(),
                    $"<Set Based on {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}'s Associated {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabelPluralized()}>");
            DefaultPrimaryContactPerson = defaultPrimaryContactPerson;
            TaxonomyLeafs = taxonomyLeafs.ToGroupedSelectList();
            StartYearRange = FirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.CalendarYear.ToString(CultureInfo.InvariantCulture), x => x.CalendarYearDisplay);
            CompletionYearRange = FirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.CalendarYear.ToString(CultureInfo.InvariantCulture), x => x.CalendarYearDisplay);
            HasThreeTierTaxonomy = MultiTenantHelpers.IsTaxonomyLevelTrunk();
            DefaultPrimaryContactPersonName = DefaultPrimaryContactPerson != null ? DefaultPrimaryContactPerson.GetFullNameFirstLastAndOrgShortName() : "nobody";
            ProjectCustomAttributeTypes = projectCustomAttributeTypes;
            TenantAttribute = tenantAttribute;
        }
    }
}
