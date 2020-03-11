/*-----------------------------------------------------------------------
<copyright file="ManageViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectFactSheet
{
    public class ManageViewData : FirmaViewData
    {
        public ViewPageContentViewData FactSheetCustomTextViewData { get; }
        public string EditFactSheetCustomTextUrl { get; }
        public string DeleteFactSheetLogoFileResourceUrl { get; }
        public string EditFactSheetLogoUrl { get; }
        public string EditBasicsUrl { get; }
        public TenantAttribute TenantAttribute { get; }

        public ManageViewData(FirmaSession currentFirmaSession,
            ProjectFirmaModels.Models.FirmaPage firmaPage, ViewPageContentViewData factSheetCustomTextViewData,
            string editFactSheetCustomTextUrl, string deleteFactSheetLogoFileResourceUrl, string editFactSheetLogoUrl, string editBasicsUrl, TenantAttribute tenantAttribute) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = $"Manage {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Fact Sheets";
            FactSheetCustomTextViewData = factSheetCustomTextViewData;
            EditFactSheetCustomTextUrl = editFactSheetCustomTextUrl;
            DeleteFactSheetLogoFileResourceUrl = deleteFactSheetLogoFileResourceUrl;
            TenantAttribute = tenantAttribute;
            EditFactSheetLogoUrl = editFactSheetLogoUrl;
            EditBasicsUrl = editBasicsUrl;
        }
    }
}