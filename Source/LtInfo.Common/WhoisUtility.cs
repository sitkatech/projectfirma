/*-----------------------------------------------------------------------
<copyright file="WhoisUtility.cs" company="Sitka Technology Group">
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
using System.Net;
using System.Text.RegularExpressions;

namespace LtInfo.Common
{
    /// <summary>
    /// Class that can gather "Whois" information for doing a reverse whois lookup on IP Address for use in diagnostic error information gathering
    /// </summary>
    public class WhoisUtility
    {
        internal const int DefaultWhoisPort = 43;

        internal static readonly Regex RegexToGetReferralServer = new Regex(@"^ReferralServer:\s+(whois|rwhois)://(?<WhoisServerName>[^:\s]+)(:(?<WhoisPort>[0-9]+))?", RegexOptions.Multiline);
        internal static readonly HostAndPort StartingWhoisServer = new HostAndPort("whois.arin.net", DefaultWhoisPort);
        private static readonly Regex ReplaceComments = new Regex("(?m)^[%#].*$");
        private static readonly Regex ReplaceWhitespaceOnly = new Regex(@"(?m)^\s+(\r|\r\n|\n)");

        public static string Lookup(IPAddress ipAddressToLookup)
        {
            return Lookup(ipAddressToLookup, StartingWhoisServer, true);
        }

        internal static string Lookup(IPAddress ipAddressToLookup, HostAndPort whoisServer, bool shouldRecurse)
        {
            var whoisQuery = String.Format("{0}{1}", ipAddressToLookup.ToString(), Environment.NewLine);
            var whoisResponse = TcpUtility.SendThenReceiveDataThroughTcp(whoisServer, whoisQuery);
            var filteredWhoisResponse = FilterOutBlankLinesAndComment(whoisResponse);

            if (shouldRecurse)
            {
                var nextHostIfAny = CalculateNextServerLookupIfAny(filteredWhoisResponse);
                if (nextHostIfAny != null)
                {
                    return Lookup(ipAddressToLookup, nextHostIfAny, true);
                }
            }
            return filteredWhoisResponse;
        }

        internal static string FilterOutBlankLinesAndComment(string whoisResponse)
        {
            var commentFiltered = ReplaceComments.Replace(whoisResponse, String.Empty);
            var commentAndWhitespaceFiltered = ReplaceWhitespaceOnly.Replace(commentFiltered, String.Empty);
            return commentAndWhitespaceFiltered;
        }

        internal static HostAndPort CalculateNextServerLookupIfAny(string serverResponse)
        {
            // Parse out referral server if any for a potential second call to whois
            // Examples:
            // ReferralServer: whois://whois.apnic.net
            // ReferralServer: whois://whois.ripe.net:43
            // ReferralServer: rwhois://rwhois.cogentco.com:4321
            var match = RegexToGetReferralServer.Match(serverResponse);
            if (match.Success)
            {
                var whoisServerName = match.Groups["WhoisServerName"].Value;
                var whoisPortString = match.Groups["WhoisPort"].Value;
                var whoisPort = DefaultWhoisPort;
                if (!String.IsNullOrWhiteSpace(whoisPortString))
                {
                    whoisPort = Int32.Parse(whoisPortString);
                }
                return new HostAndPort(whoisServerName, whoisPort);
            }

            return null;
        }
    }
}
