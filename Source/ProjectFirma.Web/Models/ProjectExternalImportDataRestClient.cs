using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using LtInfo.Common.DesignByContract;
using Newtonsoft.Json;

namespace ProjectFirma.Web.Models
{
    public class ProjectExternalImportDataRestClient
    {
        public string ProjectExternalImportDataUri { get; }

        public ProjectExternalImportDataRestClient(string projectExternalImportDataUri)
        {
            ProjectExternalImportDataUri = projectExternalImportDataUri;
        }

        public ProjectExternalImportDataSimple FetchData()
        {
            string data;
            try
            {
                var webRequest = (HttpWebRequest) WebRequest.Create(ProjectExternalImportDataUri);
                webRequest.Method = "GET";

                var webResponse = (HttpWebResponse) webRequest.GetResponse();
                Check.Assert(webResponse.StatusCode == HttpStatusCode.OK,
                    $"Request to Project External Import Data Uri {ProjectExternalImportDataUri} should resolve 200.");

                var responseStream = webResponse.GetResponseStream();

                Check.RequireNotNull(responseStream, "Some exception");
                // ReSharper disable once AssignNullToNotNullAttribute
                var responseReader = new StreamReader(responseStream);
                data = responseReader.ReadToEnd();
            }
            catch (Exception)
            {
                return null;
            }

            ProjectExternalImportDataSimple projectExternalImportDataSimple;
            try
            {
                data = Regex.Unescape(data);                // TODO remove: This should probably be resolved upstream so it's not stupid to decode this
                data = data.Trim();                         // TODO remove:
                data = data.Substring(1, data.Length - 2);  // TODO remove: Also need to strip off leading and trailing quotes
                projectExternalImportDataSimple = JsonConvert.DeserializeObject<ProjectExternalImportDataSimple>(data);
            }
            catch (Exception)
            {
                return null;
            }

            return projectExternalImportDataSimple;
        }
    }
}
