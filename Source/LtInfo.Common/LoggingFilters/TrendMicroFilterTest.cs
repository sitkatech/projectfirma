/*-----------------------------------------------------------------------
<copyright file="TrendMicroFilterTest.cs" company="Sitka Technology Group">
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
using NUnit.Framework;

namespace LtInfo.Common.LoggingFilters
{
    [TestFixture]
    public class TrendMicroFilterTest
    {
        [Test]
        public void ShouldAllowTheseHostnames()
        {
            foreach (var hostname in new[] {"example.com", "example.org"})
            {
                Assert.That(_filter.ShouldRequestBeFiltered(MakeRequestInfoWithParticularHostname(hostname)), Is.False,
                            string.Format("Requests with hostnames that are not Trend Micro should pass through. Hostname: {0}", hostname));
            }
        }

        [Test]
        public void ShouldFilterByTheseHostnames()
        {
            foreach (var hostname in new[] {"test.trendnet.org", "test.sjdc", "iad1-wtp-gd-maya7.sdi.trendnet.org", "blahblah.trendmicro.com"})
            {
                Assert.That(_filter.ShouldRequestBeFiltered(MakeRequestInfoWithParticularHostname(hostname)), Is.True,
                            string.Format("Hostnames that are Trend Micro should be filtered. Hostname: {0}", hostname));
            }
        }

        [Test]
        public void ShouldFilterByTheseWhoisInformationStrings()
        {
            foreach (var whoisInformation in new[] {"TREND MICRO INCORPORATED NET-TRENDMICRO-COM", "TrendMicro"})
            {
                Assert.That(_filter.ShouldRequestBeFiltered(MakeRequestInfoWithParticularWhoisInformation(whoisInformation)), Is.True,
                            string.Format("Whois Information that looks like Trend Micro should be filtered. Whois Information:\r\n{0}", whoisInformation));
            }
        }

        [Test]
        public void ShouldFilterByTheseRequestHeadersViaStrings()
        {
            const string requestInfoTemplate = @"GET /Map.mvc/GetFilterResultsJsonForMapLayerVariantGroup HTTP/1.0
Cache-Control: max-age=3600
Connection: keep-alive
{0}
Accept: */*
Accept-Language: en-us
Host: www.cbfish.org
User-Agent: Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)
X-Forwarded-For: 127.0.0.1
";
            foreach (
                var httpRequestViaHeaders in
                    new[]
                    {
                        "Via: 1.0 wtp-g3-maya1.sjdc:3128 (squid/2.6.STABLE21)",
                        "Via: 1.0 wtp-gd-maya7.iad1:3128 (squid/2.6.STABLE21)",
                        "Via: 1.0 wtp-go-maya1.sjdc.dcsecct.trendmicro.com:3128 (squid/2.6.STABLE21)"
                    })
            {
                var requestInfo = String.Format(requestInfoTemplate, httpRequestViaHeaders);
                Assert.That(_filter.ShouldRequestBeFiltered(MakeRequestInfoWithParticularRequestInfo(requestInfo)), Is.True,
                            string.Format("Request information with a header that looks like Trend Micro should be filtered. RequestInfo:\r\n{0}", requestInfo));
            }
        }

        private TrendMicroFilter _filter;

        public SitkaRequestInfo MakeRequestInfoWithParticularHostname(string hostname)
        {
            return new SitkaRequestInfo(new ApplicationException(), "Session Info String",
                                        new SitkaDebugInfo(IPAddress.Parse("127.0.0.1"), hostname,
                                                           "Blah Blah Whois Information",
                                                           new Uri("http://localhost.cbfish.org"), "Blah Blah Request Info"),
                                        new Uri("http://localhost.cbfish.org"), "UserAgent");
        }

        public SitkaRequestInfo MakeRequestInfoWithParticularRequestInfo(string requestInfo)
        {
            return new SitkaRequestInfo(new ApplicationException(), "Session Info String",
                                        new SitkaDebugInfo(IPAddress.Parse("127.0.0.1"), "blahblah.example.org",
                                                           "Blah Blah Whois Information",
                                                           new Uri("http://localhost.cbfish.org"), requestInfo),
                                        new Uri("http://localhost.cbfish.org"), "UserAgent");
        }

        public SitkaRequestInfo MakeRequestInfoWithParticularWhoisInformation(string whoisInformation)
        {
            return new SitkaRequestInfo(new ApplicationException(), "Session Info String",
                                        new SitkaDebugInfo(IPAddress.Parse("127.0.0.1"), "blahblah.example.org",
                                                           whoisInformation,
                                                           new Uri("http://localhost.cbfish.org"), "Blah Blah Request Info"),
                                        new Uri("http://localhost.cbfish.org"), "UserAgent");
        }

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            _filter = new TrendMicroFilter();
        }
    }
}
