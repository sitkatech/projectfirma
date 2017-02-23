/*-----------------------------------------------------------------------
<copyright file="HttpSchemeType.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
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
using System;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common
{
    public enum HttpSchemeType
    {
        Http = 0,
        Https = 1
    }

    public static class HttpSchemeTypeHelper
    {
        public static string ToProtocol(HttpSchemeType httpSchemeType)
        {
            switch (httpSchemeType)
            {
                case HttpSchemeType.Http:
                    return "http";
                case HttpSchemeType.Https:
                    return "https";
                default:
                    throw new ArgumentOutOfRangeException("httpSchemeType");
            }
        }

        public static Uri ChangeUriToScheme(string uriToChange, HttpSchemeType httpSchemeType)
        {
            Check.RequireNotNullNotEmptyNotWhitespace(uriToChange, "Should specify a URI but got nothing worthwhile.");
            return ChangeUriToScheme(new Uri(uriToChange), httpSchemeType);
        }
        public static Uri ChangeUriToScheme(Uri uriToChange, HttpSchemeType httpSchemeType)
        {
            Check.RequireNotNull(uriToChange);
            var uriBuilder = new UriBuilder(uriToChange) {Scheme = ToProtocol(httpSchemeType), Port = DefaultPortForScheme(httpSchemeType)};
            return uriBuilder.Uri;
        }

        public static int DefaultPortForScheme(HttpSchemeType httpSchemeType)
        {
            switch (httpSchemeType)
            {
                case HttpSchemeType.Http:
                    return 80;
                case HttpSchemeType.Https:
                    return 443;
                default:
                    throw new ArgumentOutOfRangeException("httpSchemeType");
            }
        }
    }
}
