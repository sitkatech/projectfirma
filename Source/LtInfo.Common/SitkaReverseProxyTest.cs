/*-----------------------------------------------------------------------
<copyright file="SitkaReverseProxyTest.cs" company="Sitka Technology Group">
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
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Hosting;
using NUnit.Framework;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common
{
    [TestFixture]
    public class SitkaReverseProxyTest
    {
        private SitkaReverseProxy _proxy;

        [SetUp]
        public void Init()
        {
            _proxy = new SitkaReverseProxy();
        }

        [Test]
        [ExpectedException(typeof(WebException), ExpectedMessage = "The remote name could not be resolved: 'iefienfnkdknfkndki.com'")]
        public void TestRunBadHost()
        {
            RunUrl("http://iefienfnkdknfkndki.com");
        }

        [Test]
        [ExpectedException(typeof(UriFormatException), ExpectedMessage = @"Invalid URI: The hostname could not be parsed.")]
        public void TestParseBadHost()
        {
            SitkaReverseProxy.ParseWhitelist("http://x y z");
        }

        [Test]
        public void TestBadParam()
        {
            var list = SitkaReverseProxy.ParseWhitelist("http://example.com");
            var exception = Assert.Throws<PreconditionException>(() => _proxy.CalculateTargetUrlFromCurrentRequestQueryString(GetSampleHttpContext("http://example.com", "BadParamName"), list));
            Assert.That(exception.Message, Is.EqualTo(String.Format("The reverse proxy requires the {0} query parameter.", SitkaReverseProxy.QueryParameter)));
        }

        [Test]
        public void TestGoodHost()
        {
            RunUrl("http://example.com");
        }

        [Test]
        [ExpectedException(typeof(PreconditionException),
            ExpectedMessage = "Url http://localhost.example.com does not match the reverse proxy white list: 'http://localhost.example.org/,http://example.org/'")]
        public void TestHostMismatch()
        {
            var list = SitkaReverseProxy.ParseWhitelist("http://localhost.example.org;http://example.org");
            _proxy.CalculateTargetUrlFromCurrentRequestQueryString(GetSampleHttpContext("http://localhost.example.com"), list);
        }

        [Test]
        public void TestLongerPathIsAllowed()
        {
            var list = SitkaReverseProxy.ParseWhitelist("http://localhost.example.org:8080/geoserver/wms;http://example.org:8080");
            _proxy.CalculateTargetUrlFromCurrentRequestQueryString(GetSampleHttpContext("http://localhost.example.org:8080/geoserver/wms/foo"), list);
        }

        [Test]
        public void TestMultipleEntries()
        {
            var list = SitkaReverseProxy.ParseWhitelist("http://localhost.example.org;http://example.org");
            _proxy.CalculateTargetUrlFromCurrentRequestQueryString(GetSampleHttpContext("http://localhost.example.org"), list);
            _proxy.CalculateTargetUrlFromCurrentRequestQueryString(GetSampleHttpContext("http://example.org"), list);
        }

        [Test]
        [ExpectedException(typeof(PreconditionException),
            ExpectedMessage = "Url http://localhost.example.org does not match the reverse proxy white list: 'http://localhost.example.org:8080/,http://example.org/'")]
        public void TestPortMismatch()
        {
            var list = SitkaReverseProxy.ParseWhitelist("http://localhost.example.org:8080;http://example.org");
            _proxy.CalculateTargetUrlFromCurrentRequestQueryString(GetSampleHttpContext("http://localhost.example.org"), list);
        }

        [Test]
        [ExpectedException(typeof(PreconditionException),
            ExpectedMessage = "Url https://example.org does not match the reverse proxy white list: 'http://example.org/,http://localhost.example.org:8080/geoserver/wms,http://slashdot.org:8080/'")]
        public void TestSchemaMismatch()
        {
            var list = SitkaReverseProxy.ParseWhitelist("http://example.org;http://localhost.example.org:8080/geoserver/wms;http://slashdot.org:8080");
            _proxy.CalculateTargetUrlFromCurrentRequestQueryString(GetSampleHttpContext("https://example.org"), list);
        }

        [Test]
        [ExpectedException(typeof(PreconditionException),
            ExpectedMessage =
                "Url http://localhost.example.org:8080/geoserver does not match the reverse proxy white list: 'http://example.org/,http://localhost.example.org:8080/geoserver/wms,http://slashdot.org:8080/'"
            )]
        public void TestShorterPathIsDisallowed()
        {
            var list = SitkaReverseProxy.ParseWhitelist("http://example.org;http://localhost.example.org:8080/geoserver/wms;http://slashdot.org:8080");
            _proxy.CalculateTargetUrlFromCurrentRequestQueryString(GetSampleHttpContext("http://localhost.example.org:8080/geoserver"), list);
        }

        [Test]
        public void TestWhitelistParser()
        {
            const string url1 = "http://google.com";
            const string url2 = "http://slashdot.com:8000";
            
            var list1 = SitkaReverseProxy.ParseWhitelist(string.Format("{0};{1}",url1,url2));
            var list2 = SitkaReverseProxy.ParseWhitelist(string.Format(";{0};;{1};", url1, url2));
            var list3 = SitkaReverseProxy.ParseWhitelist(string.Format("; {0};   ;  ; {1} ;;", url1, url2));
            var expList = new List<Uri> { new Uri(url1), new Uri(url2) };
            Assert.That(list1, Is.EqualTo(expList));
            Assert.That(list2, Is.EqualTo(expList));
            Assert.That(list3, Is.EqualTo(expList));
        }

        private void RunUrl(string url)
        {
            var ctx = GetSampleHttpContext(url);
            _proxy.CopyUrlContentsToResponse(url, ctx);
        }

        private HttpContext GetSampleHttpContext(string url, string param = SitkaReverseProxy.QueryParameter)
        {
            var stringWriter = new StringWriter();
            var request = new SimpleWorkerRequest("", "", "", string.Format("{0}={1}", param, url), stringWriter);
            return new HttpContext(request);
        }
    }
}
