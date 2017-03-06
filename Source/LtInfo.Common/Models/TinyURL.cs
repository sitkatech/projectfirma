/*-----------------------------------------------------------------------
<copyright file="TinyURL.cs" company="Sitka Technology Group">
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
using System.Text;
using log4net;

namespace LtInfo.Common.Models
{
    /// <summary>
    /// Implements the TinyURL API.
    ///
    /// Example:
    ///
    /// We request:  "http://tinyurl.com/api-create.php?url=http://www.example.com"
    /// We get back: "http://tinyurl.com/7567"
    /// </summary>
    public class TinyUrl
    {
        private const string TinyUrlApiStringTemplate = "http://tinyurl.com/api-create.php?url={0}";
        private static readonly ILog _logger = LogManager.GetLogger(typeof(TinyUrl));

        public static string GetTinyUrl(string urlToMakeTiny)
        {
            // Create a new WebClient instance.
            byte[] myDataBuffer;
            using (var myWebClient = new WebClient())
            {
                var tinyUrlApiUrl = string.Format(TinyUrlApiStringTemplate, urlToMakeTiny);
                try
                {
                    myDataBuffer = myWebClient.DownloadData(tinyUrlApiUrl);
                }
                catch (Exception ex)
                {
                    _logger.WarnFormat(string.Format("TinyUrl failed with Exception (did not cause a user visible exception)\r\n{0}\r\nTiny Url Api Url: {1}\r\nUrl To Make Tiny: {2}\r\nRequest:\r\n{3}", ex, tinyUrlApiUrl, urlToMakeTiny, HttpDebugInfo.DebugInfoFromHttpRequestIfAny()));
                    return urlToMakeTiny; // we tried anyway...
                }
            }
            // Convert to string, return
            var tinyURL = Encoding.ASCII.GetString(myDataBuffer);
            return tinyURL;
        }
    }
}
