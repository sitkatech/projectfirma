/*-----------------------------------------------------------------------
<copyright file="EditAttachmentRelationshipTypeViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web.Mvc;
using LtInfo.Common.Mvc;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.AttachmentRelationshipType
{
    public class EditAttachmentRelationshipTypeViewData : FirmaUserControlViewData
    {
        public List<FileResourceMimeType> AllFileResourceMimeTypes { get; }
        public List<ProjectFirmaModels.Models.TaxonomyTrunk> AllTaxonomyTrunks { get; }


        public List<SelectListItem> MaxFileSizes { get; }

        public EditAttachmentRelationshipTypeViewData(List<FileResourceMimeType> fileResourceMimeTypes, List<ProjectFirmaModels.Models.TaxonomyTrunk> allTaxonomyTrunks)
        {
            AllFileResourceMimeTypes = fileResourceMimeTypes;
            AllTaxonomyTrunks = allTaxonomyTrunks;
            MaxFileSizes = new List<SelectListItem>();
            for (var i = 10; i <= 50; i += 10)
            {
                SelectListItem thisSelectListItem = new SelectListItem()
                {
                    Text = $"≤ {i}MB",
                    Value = (i * 1024 * 1000).ToString() // calculate byte value based on displayed MB
                };
                MaxFileSizes.Add(thisSelectListItem);
            }
        }
    }
}
