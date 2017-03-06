/*-----------------------------------------------------------------------
<copyright file="TagHelper.cs" company="Tahoe Regional Planning Agency">
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
using System.Collections.Generic;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Tag
{
    public class TagHelper
    {
        public readonly List<BootstrapTag> Tags;
        public readonly string AddTagsUrl;
        public readonly string RemoveTagsUrl;
        public readonly string FindTagsUrl;

        public TagHelper(List<BootstrapTag> tags)
        {
            Tags = tags;
            AddTagsUrl = SitkaRoute<TagController>.BuildUrlFromExpression(c => c.AddTagsToProject());
            RemoveTagsUrl = SitkaRoute<TagController>.BuildUrlFromExpression(c => c.RemoveTagsFromProject());
            FindTagsUrl = SitkaRoute<TagController>.BuildUrlFromExpression(c => c.Find(null));
        }
    }
}
