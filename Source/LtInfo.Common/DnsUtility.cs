/*-----------------------------------------------------------------------
<copyright file="DnsUtility.cs" company="Sitka Technology Group">
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

namespace LtInfo.Common
{
    /// <summary>
    /// Performs reverse DNS lookup for getting diagnostic information
    /// </summary>
    public static class DnsUtility
    {
        private delegate IPHostEntry GetHostEntryHandler(string ip);
        public static string GetReverseDns(IPAddress ipAddress)
        {
            return GetReverseDns(ipAddress, TimeSpan.FromMilliseconds(250));
        }

        public static string GetReverseDns(IPAddress ipAddress, TimeSpan timeout)
        {
            var callback = new GetHostEntryHandler(Dns.GetHostEntry);
            var result = callback.BeginInvoke(ipAddress.ToString(), null, null);
            if (result.AsyncWaitHandle.WaitOne(timeout, false))
            {
                return callback.EndInvoke(result).HostName;
            }

            return ipAddress.ToString().Trim();
        }
    }
}
