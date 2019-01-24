/*-----------------------------------------------------------------------
<copyright file="BootstrapTag.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
namespace ProjectFirmaModels.Models
{
    public class BootstrapTag
    {
        public string id;
        public string text;
        public string url;
        public int num;

        public BootstrapTag(string id, string text, string url, int num)
        {
            this.id = id;
            this.text = text;
            this.url = url;
            this.num = num;
        }

        public BootstrapTag(Tag tag) : this(tag.TagName, tag.TagName, TagModelExtensions.GetDetailUrl(tag), tag.ProjectTags.Count)
        {
        }
    }
}
