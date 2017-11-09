/*-----------------------------------------------------------------------
<copyright file="Tag.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class Tag : IAuditableEntity
    {
        public string EditUrl
        {
            get { return SitkaRoute<TagController>.BuildUrlFromExpression(t => t.Edit(TagID)); }
        }

        public string DeleteUrl
        {
            get { return SitkaRoute<TagController>.BuildUrlFromExpression(c => c.DeleteTag(TagID)); }
        }

        public HtmlString DisplayNameAsUrl
        {
            get { return UrlTemplate.MakeHrefString(SummaryUrl, DisplayName); }
        }

        public string DisplayName
        {
            get { return TagName; }
        }

        public string SummaryUrl
        {
            get { return SitkaRoute<TagController>.BuildUrlFromExpression(x => x.Detail(TagName)); }
        }

        public string AuditDescriptionString
        {
            get { return TagName; }
        }

        public List<Project> AssociatedProjects
        {
            get { return ProjectTags.Select(x => x.Project).ToList(); }
        }

        public static bool IsTagNameUnique(IEnumerable<Tag> tags, string tagName, int currentTagID)
        {
            var tag = tags.SingleOrDefault(x => x.TagID != currentTagID && String.Equals(x.TagName, tagName, StringComparison.InvariantCultureIgnoreCase));
            return tag == null;
        }
    }
}
