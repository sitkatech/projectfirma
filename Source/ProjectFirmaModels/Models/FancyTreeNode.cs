/*-----------------------------------------------------------------------
<copyright file="FancyTreeNode.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ProjectFirmaModels.Models
{
    public class FancyTreeNode
    {
        [JsonProperty(PropertyName = "title", Order = 1)]
        public string Title;
        [JsonProperty(PropertyName = "key", Order = 1)]
        public string Key;
        [JsonProperty(PropertyName = "expanded", Order = 1)]
        public bool Expanded;
        [JsonProperty(PropertyName = "children", Order = 1)]
        public List<FancyTreeNode> Children;

        // custom attributes
        public int? NumberOfProjects { get { return GetProjectCount(); } }

        // custom attributes
        public string Answer;

        private int? GetProjectCount()
        {
            return Children == null ? 1 : Children.Sum(x => x.GetProjectCount());
        }

        public string ThemeColor;
        public string MapUrl;
        public Dictionary<int, string> StatusTrendConfidenceIcons;

        public FancyTreeNode(string title, string key, bool expanded)
        {
            Title = title;
            Key = key;
            Expanded = expanded;
        }

        public FancyTreeNode(HtmlString title, string key, bool expanded)
        {
            Title = title.ToString();
            Key = key;
            Expanded = expanded;
        }
    }   
}
