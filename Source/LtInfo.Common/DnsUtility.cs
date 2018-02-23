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
using System.Net.Sockets;

namespace LtInfo.Common
{
    /// <summary>
    /// Performs reverse DNS lookup for getting diagnostic information
    /// </summary>
    public static class DnsUtility
    {
        public static string GetReverseDns(IPAddress ipAddress)
        {
            return GetReverseDns(ipAddress, TimeSpan.FromSeconds(5));
        }

        internal static string GetReverseDns(IPAddress ipAddress, TimeSpan timeout)
        {
            var ipAddressAsString = ipAddress.ToString().Trim();
            var fnDnsGetHostEntry = new Func<string, string>(DnsGetHostEntry);
            var result = fnDnsGetHostEntry.BeginInvoke(ipAddressAsString, null, null);
            if (result.AsyncWaitHandle.WaitOne(timeout, false))
            {
                return fnDnsGetHostEntry.EndInvoke(result);
            }
            return ipAddressAsString;
        }

        private static string DnsGetHostEntry(string ipAddress)
        {
            string returnString;
            try
            {
                var ipHostEntry = Dns.GetHostEntry(ipAddress);
                returnString = ipHostEntry.HostName;
            }
            catch (SocketException)
            {
                // *ANY* socket exception problem means we drop back to just the IP address. (We started out originally with trying to trap a particular error message by string,
                // but others errors started to trouble us so we've given up that for now.) -- SLG 2/15/2018

                // By the way, if you DON'T trap an error here, the end user will see a yellow-screen-of-death, like this:
                // https://support.sitkatech.com/fogbugz/default.asp?50012#234241

                // So if you find yourself wondering about this code, you may need to widen the catch above to more (all?) exceptions.
                returnString = ipAddress;
            }
            return returnString;
        }
    }
}
