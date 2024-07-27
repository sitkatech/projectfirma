/*-----------------------------------------------------------------------
<copyright file="HtmlLinkObject.cs" company="Environmental Science Associates">
Copyright (c) Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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

using DocumentFormat.OpenXml.Drawing;
using LtInfo.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace LtInfo.Common.AgGridWrappers
{
    public class HtmlLinkObject
    {
        public string DisplayText { get; set; }

        public string Url { get; set; }

        public HtmlLinkObject(string displayText, string url)
        {
            DisplayText = displayText;
            Url = url;
        }
    }

    public static class HtmlLinkObjectModelExtensions
    {
        public static string ToJsonObjectForAgGrid(this HtmlLinkObject htmlLinkObject)
        {
            return $"{{ \"link\":\"{htmlLinkObject.Url}\",\"displayText\":\"{htmlLinkObject.DisplayText}\" }}";
        }

        public static string ToJsonArrayForAgGrid(this IEnumerable<HtmlLinkObject> htmlLinkObjects)
        {
            return $"{{ \"links\": [{string.Join(",", htmlLinkObjects.Select(x => x.ToJsonObjectForAgGrid()))}] }}";
        }

    }
}
