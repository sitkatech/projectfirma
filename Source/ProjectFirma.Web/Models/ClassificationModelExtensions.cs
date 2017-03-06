/*-----------------------------------------------------------------------
<copyright file="ClassificationModelExtensions.cs" company="Tahoe Regional Planning Agency">
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
using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public static class ClassificationModelExtensions
    {
        public static string GetEditUrl(this Classification classification)
        {
            return SitkaRoute<ClassificationController>.BuildUrlFromExpression(t => t.Edit(classification));
        }

        public static string GetDetailUrl(this Classification classification)
        {
            return SitkaRoute<ClassificationController>.BuildUrlFromExpression(t => t.Detail(classification));
        }

        public static HtmlString GetDisplayNameAsUrl(this Classification classification)
        {
            return UrlTemplate.MakeHrefString(GetDetailUrl(classification), classification.DisplayName);
        }
    }
}
