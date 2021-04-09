using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class RestApiClient
    {
        public static string SyncGeospatialAreaTypeFromService(GeospatialAreaType geospatialAreaType)
        {
            SitkaHttpApplication.Logger.Info($"Syncing data for Geospatial Area Type {geospatialAreaType.GeospatialAreaTypeName} from {geospatialAreaType.ServiceUrl}");
            string statusMessage;
            try
            {
                var responseData = MakeApiRequest("Geospatial Area Type", geospatialAreaType.ServiceUrl);
                var lastSucessfulResponse = HttpRequestStorage.DatabaseEntities.GeospatialAreaRawDatas.SingleOrDefault(x => x.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID);
                var noChange = lastSucessfulResponse != null && new JTokenEqualityComparer().Equals(JToken.Parse(lastSucessfulResponse.ResultJson), JToken.Parse(responseData));
                if (noChange)
                {
                    statusMessage = $"The data in the service has not changed since the data in Geospatial Area Type {geospatialAreaType.GeospatialAreaTypeName} was last synced.";
                    SitkaHttpApplication.Logger.Info(statusMessage);
                    return statusMessage;
                }

                GeospatialAreaTypeModelExtensions.ProcessApiResponse(geospatialAreaType, responseData, HttpRequestStorage.DatabaseEntities, SitkaWebConfiguration.DatabaseConnectionString);
                // Record this response as the latest response for next time
                if (lastSucessfulResponse == null)
                {
                    lastSucessfulResponse = new GeospatialAreaRawData(geospatialAreaType.GeospatialAreaTypeID);
                    HttpRequestStorage.DatabaseEntities.AllGeospatialAreaRawDatas.Add(lastSucessfulResponse);
                }
                lastSucessfulResponse.ResultJson = responseData;
                statusMessage = $"Geospatial area sync for {geospatialAreaType.GeospatialAreaTypeName} successful";
                return statusMessage;

            }
            catch (Exception e)
            {
                statusMessage = $"Geospatial area sync for {geospatialAreaType.GeospatialAreaTypeName} failed";
                SitkaLogger.Instance.LogDetailedErrorMessage(statusMessage + " with an exception", e);
                return statusMessage;
            }
        }

        public static string MakeApiRequest(string serviceName, string serviceUrl)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
            webRequest.Method = "GET";
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            Check.Assert(webResponse.StatusCode == HttpStatusCode.OK,
                $"Request to {serviceName} Data Source {serviceUrl} should resolve 200.");
            var responseStream = webResponse.GetResponseStream();
            Check.RequireNotNull(responseStream, $"{serviceName} - Response stream cannot be null");
            // ReSharper disable once AssignNullToNotNullAttribute
            var responseReader = new StreamReader(responseStream);
            return responseReader.ReadToEnd();
        }
    }
}
