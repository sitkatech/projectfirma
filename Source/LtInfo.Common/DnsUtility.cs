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