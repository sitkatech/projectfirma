/*-----------------------------------------------------------------------
<copyright file="WhoisUtilityTest.cs" company="Sitka Technology Group">
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
using System.Diagnostics;
using System.Net;
using NUnit.Framework;

namespace LtInfo.Common
{
    [TestFixture]
    public class WhoisUtilityTest
    {
        private const string SampleOutputTemplate = @"
#
# Query terms are ambiguous.  The query is assumed to be:
#     ""n 123.0.0.1""
#
# Use ""?"" to get help.
#

#
# The following results may also be obtained via:
# http://whois.arin.net/rest/nets;q=123.0.0.1?showDetails=true&showARIN=true
#

NetRange:       123.0.0.0 - 123.255.255.255
CIDR:           123.0.0.0/8
OriginAS:       
NetName:        APNIC-123
NetHandle:      NET-123-0-0-0-1
Parent:         
NetType:        Allocated to APNIC
Comment:        This IP address range is not registered in the ARIN database.
Comment:        For details, refer to the APNIC Whois Database via
Comment:        WHOIS.APNIC.NET or http://wq.apnic.net/apnic-bin/whois.pl
Comment:        ** IMPORTANT NOTE: APNIC is the Regional Internet Registry
Comment:        for the Asia Pacific region. APNIC does not operate networks
Comment:        using this IP address range and is not able to investigate
Comment:        spam or abuse reports relating to these addresses. For more
Comment:        help, refer to http://www.apnic.net/apnic-info/whois_search2/abuse-and-spamming
RegDate:        2006-01-06
Updated:        2010-07-30
Ref:            http://whois.arin.net/rest/net/NET-123-0-0-0-1

OrgName:        Asia Pacific Network Information Centre
OrgId:          APNIC
Address:        PO Box 2131
City:           Milton
StateProv:      QLD
PostalCode:     4064
Country:        AU
RegDate:        
Updated:        2004-03-01
Ref:            http://whois.arin.net/rest/org/APNIC

{0}

OrgTechHandle: AWC12-ARIN
OrgTechName:   APNIC Whois Contact
OrgTechPhone:  +61 7 3858 3188 
OrgTechEmail:  search-apnic-not-arin@apnic.net
OrgTechRef:    http://whois.arin.net/rest/poc/AWC12-ARIN

#
# ARIN WHOIS data and services are subject to the Terms of Use
# available at: https://www.arin.net/whois_tou.html
#
";

        [Test]
        public void CanLookupAnIp4Address()
        {
            var ip = IPAddress.Parse("23.0.0.1");
            var answer = WhoisUtility.Lookup(ip);
            //Assert.That(answer, Is.StringContaining("American Registry for Internet Numbers NET23"), "Should have been able to look up something simple through ARIN");
            AssertResponseIsTrimmedOfCommentsAndWhitespace(answer);
        }

        [Test]
        public void CanLookupIp4AddressThatRequiresRecursion()
        {
            // Arrange
            // -------
            // 156.8.0.1 works in Africa whois.afrinic.net
            // 123.0.0.1 is good for whois.apnic.net but it is down on 09/18/2015 -MF
            var ipAddressThatRequiresRecursion = IPAddress.Parse("156.8.0.1");

            var resultOfIpAddressWithRecursion = WhoisUtility.Lookup(ipAddressThatRequiresRecursion, WhoisUtility.StartingWhoisServer, false);
            var recursiveWhoisServer = WhoisUtility.CalculateNextServerLookupIfAny(resultOfIpAddressWithRecursion);
            Assert.That(recursiveWhoisServer, Is.Not.Null, string.Format("Test precondition: the ip address {0} is supposed to be one that requires recursion but it doesn't seem to.", ipAddressThatRequiresRecursion.ToString()));
            Assert.That(resultOfIpAddressWithRecursion, Is.Not.StringContaining("inetnum:"), "Test precondition: Should not yet have completed the lookup");
            Assert.That(resultOfIpAddressWithRecursion, Is.Not.StringContaining("netname:"), "Test precondition: Should not yet have completed the lookup");

            // Act
            // ---
            var answer = WhoisUtility.Lookup(ipAddressThatRequiresRecursion);
            Assert.That(WhoisUtility.CalculateNextServerLookupIfAny(answer), Is.Null, "Should not be a reponse that requires further recursion");
            Assert.That(answer, Is.StringContaining("inetnum:"), "Should have completed the lookup");
            Assert.That(answer, Is.StringContaining("netname:"), "Should have completed the lookup");
        }

        [Test]
        public void RecursiveCanDetectNoRecursion()
        {
            // Arrange
            // ------
            var outputWithReferralServer = String.Format(SampleOutputTemplate, String.Empty);

            // Act
            // ------
            var nextHost = WhoisUtility.CalculateNextServerLookupIfAny(outputWithReferralServer);

            // Assert
            // ------
            Assert.That(nextHost, Is.Null, "Should have found no recursion");
        }
        
        [Test]
        public void RecursiveCanParseSimple()
        {
            // Arrange
            // ------
            const string host = "whois.apnic.net";
            var outputWithReferralServer = String.Format(SampleOutputTemplate, string.Format("ReferralServer: whois://{0}", host));

            // Act
            // ------
            var nextHost = WhoisUtility.CalculateNextServerLookupIfAny(outputWithReferralServer);

            // Assert
            // ------
            Assert.That(nextHost, Is.Not.Null, "Should have found another host");
            Assert.That(nextHost.Hostname, Is.EqualTo(host), "Should have identified hostname");
            Assert.That(nextHost.Port, Is.EqualTo(WhoisUtility.DefaultWhoisPort), "Without port should be using the default Whois Port");
        }

        [Test]
        public void RecursiveCanParseWithPort()
        {
            // Arrange
            // ------
            const string host = "example.com";
            const int port = 1234;
            var outputWithReferralServer = String.Format(SampleOutputTemplate, string.Format("ReferralServer: whois://{0}:{1}", host, port));

            // Act
            // ------
            var nextHost = WhoisUtility.CalculateNextServerLookupIfAny(outputWithReferralServer);

            // Assert
            // ------
            Assert.That(nextHost, Is.Not.Null, "Should have found another host");
            Assert.That(nextHost.Hostname, Is.EqualTo(host), "Should have identified hostname");
            Assert.That(nextHost.Port, Is.EqualTo(port), "Without port should be using the default Whois Port");
        }

        [Test]
        public void RecursiveCanParseWithPortAndRWhois()
        {
            // Arrange
            // ------
            const string host = "example.com";
            const int port = 1234;
            var outputWithReferralServer = String.Format(SampleOutputTemplate, string.Format("ReferralServer: rwhois://{0}:{1}", host, port));

            // Act
            // ------
            var nextHost = WhoisUtility.CalculateNextServerLookupIfAny(outputWithReferralServer);

            // Assert
            // ------
            Assert.That(nextHost, Is.Not.Null, "Should have found another host");
            Assert.That(nextHost.Hostname, Is.EqualTo(host), "Should have identified hostname");
            Assert.That(nextHost.Port, Is.EqualTo(port), "Without port should be using the default Whois Port");
        }

        [Test]
        public void CanFilterOutBlankLinesAndCommentLines()
        {
            const string sampleOutput = @"
# ARIN comments start with a pound sign
# Next line is blank

# Next lines are real data
Real Output 1 NET170 (NET-170-0-0-0-0) 170.0.0.0 - 170.255.255.255
  Real Output 2 Spaces before this line should be ok (NET-170-160-0-0-1) 170.160.0.0 - 170.160.255.255

# Next line has spaces and tab but is still considered blank
    " + "\t" + @"
% Other servers have percent comments
" + "# Comment with CR end of line\r# Comment with CR LF end of line\r\n# Comment with LF end of line\n" + "    \r  \r\n \n";
            var filteredOutput = WhoisUtility.FilterOutBlankLinesAndComment(sampleOutput);

            Assert.That(filteredOutput, Is.StringMatching("Real Output 1"), "Real output should be preserved");
            Assert.That(filteredOutput, Is.StringMatching("Real Output 2"), "Real output should be preserved");
            AssertResponseIsTrimmedOfCommentsAndWhitespace(filteredOutput);

            Trace.WriteLine(">>" + filteredOutput + "<<");
        }

        private static void AssertResponseIsTrimmedOfCommentsAndWhitespace(string filteredOutput)
        {
            Assert.That(filteredOutput, Is.Not.StringMatching("(?m)^#"), "Minimal output - should not have any comment lines starting with #");
            Assert.That(filteredOutput, Is.Not.StringMatching("(?m)^%"), "Minimal output - should not have any comment lines starting with %");
            Assert.That(filteredOutput, Is.Not.StringMatching(@"(?m)^\s+$"), "Minimal output - should not have any blank lines");
        }
    }
}
