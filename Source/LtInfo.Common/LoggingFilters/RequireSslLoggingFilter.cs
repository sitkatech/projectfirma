/*-----------------------------------------------------------------------
<copyright file="RequireSslLoggingFilter.cs" company="Sitka Technology Group">
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
namespace LtInfo.Common.LoggingFilters
{
    public class RequireSslLoggingFilter : ISitkaLoggingFilter
    {
        public bool ShouldRequestBeFiltered(SitkaRequestInfo requestInfo)
        {
            // we were checking for the error message, but then it would give an error like: Http Server is returning response status code "500 Internal Server Error" and error was not logged via the Application_Error method
            // so we filter all Head request errors.
            return requestInfo.DebugInfo.RequestInfo.StartsWith("HEAD") || requestInfo.DebugInfo.RequestInfo.StartsWith("PROPFIND") || requestInfo.DebugInfo.RequestInfo.StartsWith("OPENVAS");// && requestInfo.OriginalException != null && requestInfo.OriginalException.Message == "The requested resource can only be accessed via SSL.";
        }
    }
}
