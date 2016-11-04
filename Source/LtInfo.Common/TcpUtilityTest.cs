using NUnit.Framework;

namespace LtInfo.Common
{
    [TestFixture]
    public class TcpUtilityTest
    {
        [Test, Description("An example that it can make a TCP socket connection successfully and do a simple send - receive data exchange")]
        public void CanConnectAndExchangeData()
        {
            const string hostThatSupportsHttp = "www.example.com";
            var result = TcpUtility.SendThenReceiveDataThroughTcp(hostThatSupportsHttp, 80, string.Format(@"GET / HTTP/1.0
Host: {0}

", hostThatSupportsHttp));
            Assert.That(result, Is.StringMatching("HTTP/1.0 [23][0-9][0-9] [A-z0-9 ]+"), "If the TCP socket thingy is working it should be able to make a sample connection such as for an HTTP GET request and get back a 200 or 300 level response");
        }
    }
}