/*-----------------------------------------------------------------------
<copyright file="HttpDebugInfo.cs" company="Sitka Technology Group">
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
using System.IO;
using System.Web;

namespace LtInfo.Common
{
    public static class HttpDebugInfo
    {
        public static string DebugInfoFromHttpRequestIfAny()
        {
            string debugInfo = String.Empty;
            if (HttpContext.Current != null)
                debugInfo = DebugInfo(HttpContext.Current.Request);
            return debugInfo;
        }

        public static string DebugInfo(HttpRequest request)
        {
            var requestContent = GetRequestContent(request);
            return String.Format("IP Address: {1}{0}URL: {2}{0}{0}Http Request:{0}{3}", Environment.NewLine, request.UserHostAddress, request.Url.AbsoluteUri, requestContent);
        }

        public static string GetRequestContent(HttpRequest request)
        {
            var tempFile = new FileInfo(Path.GetTempFileName());
            request.SaveAs(tempFile.FullName, true);
            var requestContent = FileUtility.FileToString(tempFile);
            tempFile.Delete();

            return requestContent;
        }
    }

    /// <summary>
    /// Workaround till Microsoft fixes this:
    /// http://blogs.msdn.com/b/praburaj/archive/2012/09/13/accessing-httpcontext-current-request-inputstream-property-in-aspnetcompatibility-mode-throws-exception-this-method-or-property-is-not-supported-after-httprequest-getbufferlessinputstream-has-been-invoked.aspx
    /// </summary>
    public class WcfReadEntityBodyModeWorkaroundModule : IHttpModule
    {
        public void Dispose() { }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            //This will force the HttpContext.Request.ReadEntityBody to be "Classic" and will ensure compatibility..    
            var stream = ((HttpApplication) sender).Request.InputStream;
        }
    } 
}
