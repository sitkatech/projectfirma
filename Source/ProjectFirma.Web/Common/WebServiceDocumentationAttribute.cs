using System;

namespace ProjectFirma.Web.Common
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class WebServiceDocumentationAttribute : Attribute
    {
        public string Documentation;

        public WebServiceDocumentationAttribute(string s)
        {
            Documentation = s;
        }
    }
}