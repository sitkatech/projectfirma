/*-----------------------------------------------------------------------
<copyright file="NotReferred404LoggingFilter.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
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
using System.Net;
using System.Web;

namespace LtInfo.Common.LoggingFilters
{
    public class NotReferred404LoggingFilter : ISitkaLoggingFilter
    {
        public bool ShouldRequestBeFiltered(SitkaRequestInfo requestInfo)
        {
            //should be filtered if status code is 404 and there is no referrer
            if (requestInfo.OriginalException is HttpException)
            {
                var http = (HttpException) requestInfo.OriginalException;
                return (http.GetHttpCode() == (int)HttpStatusCode.NotFound &&
                        (requestInfo.UrlReferrer == null ||
                         String.IsNullOrWhiteSpace(requestInfo.UrlReferrer.ToString())));
            }

            //should also be filtered out if exception is SitkaRecordNotFoundException and there is no referrer
            if (requestInfo.OriginalException is SitkaRecordNotFoundException)
            {
                return (requestInfo.UrlReferrer == null || String.IsNullOrWhiteSpace(requestInfo.UrlReferrer.ToString()));
            }

            return false;
        }
    }
}
