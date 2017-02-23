/*-----------------------------------------------------------------------
<copyright file="BulkTagProjectsViewModel.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Tag
{
    public class BulkTagProjectsViewModel : FormViewModel
    {
        [Required]
        public List<int> ProjectIDList { get; set; }

        [Required]
        [StringLength(Models.Tag.FieldLengths.TagName)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.TagName)]
        [RegularExpression(@"^[a-zA-Z0-9-_\s]{1,}$", ErrorMessage = FirmaValidationMessages.LettersNumbersSpacesDashesAndUnderscoresOnly)]
        public string TagName { get; set; }
    }
}
