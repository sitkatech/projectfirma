/*-----------------------------------------------------------------------
<copyright file="UnsupportedHttpMethodHandler.cs" company="Sitka Technology Group">
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
using System.Collections.ObjectModel;
using System.Net;
using System.Web;

namespace LtInfo.Common.LoggingFilters
{
    /// <summary>
    ///     This class is in charge of handling the HTTP response to HTTP methods that aren't allowed, such as WebDav extensions "PROPFIND" and the like.
    ///     IIS can give a problematic response to the method if the following conditions are true:
    ///     * User is trying to download a Microsoft Office document
    ///     ** such as http://www.cbfish.org/Content/tutorials/Sponsor_Reporting_Procedural_Guidance_Final%202-14.docx
    ///     * User is on the BPA network
    ///     ** Or via MyPC
    ///     * Microsoft Office is configured to check for WebDAV support
    ///     Can get a prompt for Username and Password from Microsoft Office based on a "401 Unauthorized" default IIS response.
    ///     This code forces a 405 response so that user won't get confusing prompt to login and filters it out from the log so we don't get spurious messages.
    ///     See Taurus Story #3733 and FogBugz Case #15114 for more details.
    /// </summary>
    public class UnsupportedHttpMethodHandler : ISitkaLoggingFilter
    {
        /// <summary>
        /// Http Status Code to return and check for in log suppression if there is unsupported http method
        /// </summary>
        private const HttpStatusCode HttpStatusCodeForUnsupportedMethods = HttpStatusCode.MethodNotAllowed;

        /// <summary>
        ///     Only allow HTTP methods: GET, HEAD, POST, OPTIONS
        ///     Don't allow HTTP methods such as: PUT, DELETE, TRACE, CONNECT, PATCH
        ///     Don't allow HTTP methods for WebDAV extensions: PROPFIND, PROPPATCH, MKCOL, COPY, MOVE, LOCK, UNLOCK
        ///     Note: HTTP Methods are case-sensitive
        /// </summary>
        private static readonly ReadOnlyCollection<string> AllowedHttpMethods = new ReadOnlyCollection<string>(new[] { "HEAD", "GET", "POST", HttpOptionsMethod });

        private const string HttpOptionsMethod = "OPTIONS";

        /// <summary>
        ///     If we get an HTTP method request for a method we don't support we need to respond with "405 Method Not Allowed" otherwise IIS default is "401 Unauthorized" which may prompt the user for login credentials.
        ///     Call this function at the beginning of <see cref="HttpApplication.BeginRequest" />
        /// </summary>
        public static void BeginRequestRespondToUnsupportedHttpMethodsWith405MethodNotAllowed(HttpRequest httpRequest, HttpResponse httpResponse)
        {
            if (!IsHttpRequestMethodAllowed(httpRequest.HttpMethod))
            {
                httpResponse.StatusCode = (int) HttpStatusCodeForUnsupportedMethods;
                httpResponse.End();
            }
            if (httpRequest.HttpMethod == HttpOptionsMethod)
            {
                httpResponse.StatusCode = (int) HttpStatusCode.OK;
                httpResponse.Headers.Add("Allow", string.Join(",", AllowedHttpMethods));
                httpResponse.End();
            }
        }

        /// <summary>
        ///     Don't log an error if request is unsupported HTTP method and code has responded deliberately to with a "405 Method Not Allowed"
        /// </summary>
        public bool ShouldRequestBeFiltered(SitkaRequestInfo requestInfo)
        {
            // If this request was for an HTTP method that isn't allowed...
            if (!IsHttpRequestMethodAllowed(requestInfo.Method))
            {
                // And the code is returning HTTP STATUS CODE "405 Method Not Allowed" - Then don't log it
                return (requestInfo.StatusCode == (int) HttpStatusCodeForUnsupportedMethods);
            }
            // Otherwise log the message - something else weird happened
            return false;
        }

        /// <summary>
        ///     Check if the HTTP method is allowed
        /// </summary>
        private static bool IsHttpRequestMethodAllowed(string methodString)
        {
            // The Method token indicates the method to be performed on the resource identified by the Request-URI. The method is case-sensitive.
            return AllowedHttpMethods.Contains(methodString);
        }
    }
}
