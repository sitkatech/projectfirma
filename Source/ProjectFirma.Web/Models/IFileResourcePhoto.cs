/*-----------------------------------------------------------------------
<copyright file="IFileResourcePhoto.cs" company="Tahoe Regional Planning Agency">
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
using System.Collections.Generic;

namespace ProjectFirma.Web.Models
{
    public interface IFileResourcePhoto
    {
        int? EntityImageIDAsNullable { get; }
        DateTime CreateDate { get; }
        int PrimaryKey { get; }
        FileResource FileResource { get; set; }
        string DeleteUrl { get; }
        bool IsKeyPhoto { get; }
        string CaptionOnFullView { get; }
        string CaptionOnGallery { get; }
        string Caption { get; set; }
        string PhotoUrl { get; }
        string PhotoUrlScaledThumbnail { get; }
        string EditUrl { get; }
        List<string> AdditionalCssClasses { get; }
        object OrderBy { get; set; }
    }
}
