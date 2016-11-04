using System;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common
{
    public enum HttpSchemeType
    {
        Http = 0,
        Https = 1
    }

    public static class HttpSchemeTypeHelper
    {
        public static string ToProtocol(HttpSchemeType httpSchemeType)
        {
            switch (httpSchemeType)
            {
                case HttpSchemeType.Http:
                    return "http";
                case HttpSchemeType.Https:
                    return "https";
                default:
                    throw new ArgumentOutOfRangeException("httpSchemeType");
            }
        }

        public static Uri ChangeUriToScheme(string uriToChange, HttpSchemeType httpSchemeType)
        {
            Check.RequireNotNullNotEmptyNotWhitespace(uriToChange, "Should specify a URI but got nothing worthwhile.");
            return ChangeUriToScheme(new Uri(uriToChange), httpSchemeType);
        }
        public static Uri ChangeUriToScheme(Uri uriToChange, HttpSchemeType httpSchemeType)
        {
            Check.RequireNotNull(uriToChange);
            var uriBuilder = new UriBuilder(uriToChange) {Scheme = ToProtocol(httpSchemeType), Port = DefaultPortForScheme(httpSchemeType)};
            return uriBuilder.Uri;
        }

        public static int DefaultPortForScheme(HttpSchemeType httpSchemeType)
        {
            switch (httpSchemeType)
            {
                case HttpSchemeType.Http:
                    return 80;
                case HttpSchemeType.Https:
                    return 443;
                default:
                    throw new ArgumentOutOfRangeException("httpSchemeType");
            }
        }
    }
}
