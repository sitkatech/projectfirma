using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;   //xmlserialer

/* 
 * This class is the connection to Accela
 * It will serialize/deserialize and send/receive the requests
 */

namespace GovXMLNet
{
    public class Transport
    {
        // Define connection variable
        readonly AccelaGovXMLWebService.GovXMLClient Connection;

        public Transport(string URL = null, string UserID = null, string Password = null)
        {

            if (URL != null)
            {
                Connection = new AccelaGovXMLWebService.GovXMLClient("GovXMLService", URL);
            }
            else
            {
                Connection = new AccelaGovXMLWebService.GovXMLClient();
            }

            // string turl;
            if (UserID != null)
            {
                Connection.ClientCredentials.UserName.UserName = UserID;
            }

            if (Password != null)
            {
                Connection.ClientCredentials.UserName.Password = Password;
            }
            ServicePointManager.ServerCertificateValidationCallback = (obj, certificate, chain, errors) => true;
            //vConnection.ClientCredentials.
        }
        
        public Transport(Uri url) : this(url.ToString())
        {}

        // Exposed variables and settings
        public string UserName
        {
            get { return Connection.ClientCredentials.UserName.UserName; }
            set { Connection.ClientCredentials.UserName.UserName = value; }
        }

        public string Password
        {
            get { return Connection.ClientCredentials.UserName.Password; }
            set { Connection.ClientCredentials.UserName.Password = value; }
        }

        public string URL
        {
            get { return Connection.Endpoint.Address.ToString(); }
            //set { AccelaGovXMLWebService.GovXMLChannel. = value; }
        }

        public string SendRequest(string tstring, DirectoryInfo logFileDirectory, string filebase)
        {
            var retvalue = "";
            var dateTimeString = DateTime.Now.ToString("yyyyMMdd_HHmmss_ff");
            if (filebase != null)
            {
                File.WriteAllText(Path.Combine(logFileDirectory.FullName, string.Format("{0}_{1}_Request_GovXml.xml", dateTimeString, filebase)), tstring);
            }
            retvalue = Connection.passGovXML(tstring);
            if (filebase != null)
            {
                File.WriteAllText(Path.Combine(logFileDirectory.FullName, string.Format("{0}_{1}_Response_GovXml.xml", dateTimeString, filebase)), retvalue);
            }
            return retvalue;
        }

        public string serialize(GovXML request)
        {
            var serializedXml = ToXmlSerialized(request, Formatting.None);
            
            // This namespace is very important in order to get the correct results back from Accela
            const string accelaRequiredNamespace = "http://www.accela.com/schema/AccelaOpenSystemInterfaceXML";

            // Hack to get the output from the data serializer to come out right.  I can't seem to get rid of the www.w3.org reference
            if (serializedXml.Contains(accelaRequiredNamespace))
            {
                throw new ApplicationException("Should not already contain the required namespace otherwise there is a problem!");
            }

            var namespaceAlteredXml = serializedXml.Replace("<GovXML xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", string.Format("<GovXML xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"{0}\"", accelaRequiredNamespace));

            //retval = retval.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");
            //retval = retval.Replace(" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\"", " xmlns=\"http://www.accela.com/schema/AccelaOpenSystemInterfaceXML\"");
            //retval = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r" + retval;
            //retval = "<?xml version=\"1.0\" encoding=\"us-ascii\"?>" + retval;

            if (!namespaceAlteredXml.Contains(accelaRequiredNamespace))
            {
                throw new ApplicationException(string.Format("Failed to add required namespace {0} to xml to serialize.\r\nRaw Xml:\r\n{1}\r\nReplaced xml:\r\n{2}", accelaRequiredNamespace, serializedXml, namespaceAlteredXml));
            }
            // return xml text
            return namespaceAlteredXml;
        }

        private static string ToXmlSerialized<T>(T request, Formatting formatting)
        {
            string retval;
            using (var strwriter = new StringWriterWithEncoding(Encoding.ASCII))
            {
                using (var xmlwriter = new XmlTextWriter(strwriter))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    xmlwriter.Formatting = formatting;

                    // Generate xml
                    serializer.Serialize(xmlwriter, request);
                }
                retval = strwriter.ToString();
            }
            return retval;
        }

        /// <summary>
        /// XML Serialize object with <see cref="Formatting.Indented"/> so it is human readable
        /// </summary>
        public static string ToXmlSerializedHumanReadable<T>(T request)
        {
            return ToXmlSerialized(request, Formatting.Indented);
        }

        public bool deserialize(string xml, ref GovXML response, out GovXMLNet.clsError error)
        {
            bool retval = false;
            var xmlCleanedOfNamespaces = xml;
            error = null;

            // Reverse hack to deserialize correctly.
            xmlCleanedOfNamespaces = xmlCleanedOfNamespaces.Replace(" xmlns=\"http://www.accela.com/schema/AccelaWirelessXML\"", "");
            xmlCleanedOfNamespaces = xmlCleanedOfNamespaces.Replace(" xmlns=\"http://www.accela.com/schema/AccelaOpenSystemInterfaceXML\"", "");
            xmlCleanedOfNamespaces = xmlCleanedOfNamespaces.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
            xmlCleanedOfNamespaces = xmlCleanedOfNamespaces.Replace(" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");
            xmlCleanedOfNamespaces = xmlCleanedOfNamespaces.Replace(" xmlns=\"http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL\"", "");
            xmlCleanedOfNamespaces = xmlCleanedOfNamespaces.Replace(" xsi:type=\"java:java.lang.String\"", "");

            using (var strreader = new StringReader(xmlCleanedOfNamespaces))
            {
                using (var xmlreader = new XmlTextReader(strreader))
                {
                    var deserializer = new XmlSerializer(typeof(GovXML));
                    try
                    {
                        response = (GovXML)deserializer.Deserialize(xmlreader);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("Exception \"{0}\" during GovXml deserialization. Raw Xml:\r\n{1}\r\nNamespace Cleaned Xml:\r\n{2}\r\n", ex.GetAllExceptionMessages(), xml, xmlCleanedOfNamespaces), ex);
                    }
                }
            }

            if (response != null)
            {
                retval = true;
                if (response.FSystemOut != null)
                {
                    error = response.FSystemOut.System.Error;
                    retval = false;
                }
                else
                {
                    //------------------------------------------------------
                    if (response.AddNewDocumentResponse != null && response.AddNewDocumentResponse.system.Error != null)
                    {
                        error = response.AddNewDocumentResponse.system.Error;
                    }
                    else if (response.AuthenticateUserResponse != null && response.AuthenticateUserResponse.system.Error != null)
                    {
                        error = response.AuthenticateUserResponse.system.Error;
                    }
                    else if (response.BatchOperationResponse != null && response.BatchOperationResponse.system.Error != null)
                    {
                        error = response.BatchOperationResponse.system.Error;
                    }
                    else if (response.CalculateInvoicesResponse != null && response.CalculateInvoicesResponse.system.Error != null)
                    {
                        error = response.CalculateInvoicesResponse.system.Error;
                    }
                    else if (response.CalculateRouteResponse != null && response.CalculateRouteResponse.system.Error != null)
                    {
                        error = response.CalculateRouteResponse.system.Error;
                    }
                    else if (response.CancelInspectionResponse != null && response.CancelInspectionResponse.system.Error != null)
                    {
                        error = response.CancelInspectionResponse.system.Error;
                    }
                    else if (response.CreateDocumentResponse != null && response.CreateDocumentResponse.system.Error != null)
                    {
                        error = response.CreateDocumentResponse.system.Error;
                    }
                    else if (response.CreateAssetResponse != null && response.CreateAssetResponse.system.Error != null)
                    {
                        error = response.CreateAssetResponse.system.Error;
                    }
                    else if (response.DeleteDocumentResponse != null && response.DeleteDocumentResponse.system.Error != null)
                    {
                        error = response.DeleteDocumentResponse.system.Error;
                    }
                    else if (response.FinalizeCAPResponse != null && response.FinalizeCAPResponse.system.Error != null)
                    {
                        error = response.FinalizeCAPResponse.system.Error;
                    }
                    else if (response.GetAdditionalInformationGroupsResponse != null && response.GetAdditionalInformationGroupsResponse.system.Error != null)
                    {
                        error = response.GetAdditionalInformationGroupsResponse.system.Error;
                    }
                    else if (response.GetAddressesResponse != null && response.GetAddressesResponse.system.Error != null)
                    {
                        error = response.GetAddressesResponse.system.Error;
                    }
                    else if (response.GetAssetCAStatusResponse != null && response.GetAssetCAStatusResponse.system.Error != null)
                    {
                        error = response.GetAssetCAStatusResponse.system.Error;
                    }
                    else if (response.GetAssetCATypesResponse != null && response.GetAssetCATypesResponse.system.Error != null)
                    {
                        error = response.GetAssetCATypesResponse.system.Error;
                    }
                    else if (response.GetAssetCAsResponse != null && response.GetAssetCAsResponse.system.Error != null)
                    {
                        error = response.GetAssetCAsResponse.system.Error;
                    }
                    else if (response.GetAssetsResponse != null && response.GetAssetsResponse.system.Error != null)
                    {
                        error = response.GetAssetsResponse.system.Error;
                    }
                    else if (response.GetAssetTypesResponse != null && response.GetAssetTypesResponse.system.Error != null)
                    {
                        error = response.GetAssetTypesResponse.system.Error;
                    }
                    else if (response.GetAssetUsagesResponse != null && response.GetAssetUsagesResponse.system.Error != null)
                    {
                        error = response.GetAssetUsagesResponse.system.Error;
                    }
                    else if (response.GetAuditLogsResponse != null && response.GetAuditLogsResponse.system.Error != null)
                    {
                        error = response.GetAuditLogsResponse.system.Error;
                    }
                    else if (response.GetAvailableInspectionDatesResponse != null && response.GetAvailableInspectionDatesResponse.system.Error != null)
                    {
                        error = response.GetAvailableInspectionDatesResponse.system.Error;
                    }
                    else if (response.GetCAPResponse != null && response.GetCAPResponse.system.Error != null)
                    {
                        error = response.GetCAPResponse.system.Error;
                    }
                    else if (response.GetCAPsResponse != null && response.GetCAPsResponse.system.Error != null)
                    {
                        error = response.GetCAPsResponse.system.Error;
                    }
                    else if (response.GetCAPTypesResponse != null && response.GetCAPTypesResponse.system.Error != null)
                    {
                        error = response.GetCAPTypesResponse.system.Error;
                    }
                    else if (response.GetCitiesResponse != null && response.GetCitiesResponse.system.Error != null)
                    {
                        error = response.GetCitiesResponse.system.Error;
                    }
                    else if (response.GetConditionTypesResponse != null && response.GetConditionTypesResponse.system.Error != null)
                    {
                        error = response.GetConditionTypesResponse.system.Error;
                    }
                    else if (response.GetContactsResponse != null && response.GetContactsResponse.system.Error != null)
                    {
                        error = response.GetContactsResponse.system.Error;
                    }
                    else if (response.GetCostTypesResponse != null && response.GetCostTypesResponse.system.Error != null)
                    {
                        error = response.GetCostTypesResponse.system.Error;
                    }
                    else if (response.GetCriterionsResponse != null && response.GetCriterionsResponse.system.Error != null)
                    {
                        error = response.GetCriterionsResponse.system.Error;
                    }
                    else if (response.GetDepartmentsResponse != null && response.GetDepartmentsResponse.system.Error != null)
                    {
                        error = response.GetDepartmentsResponse.system.Error;
                    }
                    else if (response.GetDispositionsResponse != null && response.GetDispositionsResponse.system.Error != null)
                    {
                        error = response.GetDispositionsResponse.system.Error;
                    }
                    else if (response.GetDocumentResponse != null && response.GetDocumentResponse.system.Error != null)
                    {
                        error = response.GetDocumentResponse.system.Error;
                    }
                    else if (response.GetDocumentGroupsResponse != null && response.GetDocumentGroupsResponse.system.Error != null)
                    {
                        error = response.GetDocumentGroupsResponse.system.Error;
                    }
                    else if (response.GetDocumentListResponse != null && response.GetDocumentListResponse.system.Error != null)
                    {
                        error = response.GetDocumentListResponse.system.Error;
                    }
                    else if (response.GetDocumentsResponse != null && response.GetDocumentsResponse.system.Error != null)
                    {
                        error = response.GetDocumentsResponse.system.Error;
                    }
                    else if (response.GetEDMSAdaptersResponse != null && response.GetEDMSAdaptersResponse.system.Error != null)
                    {
                        error = response.GetEDMSAdaptersResponse.system.Error;
                    }
                    else if (response.GetGISDynamicThemesResponse != null && response.GetGISDynamicThemesResponse.system.Error != null)
                    {
                        error = response.GetGISDynamicThemesResponse.system.Error;
                    }
                    else if (response.GetGISLayerGroupsResponse != null && response.GetGISLayerGroupsResponse.system.Error != null)
                    {
                        error = response.GetGISLayerGroupsResponse.system.Error;
                    }
                    else if (response.GetGISLayersResponse != null && response.GetGISLayersResponse.system.Error != null)
                    {
                        error = response.GetGISLayersResponse.system.Error;
                    }
                    else if (response.GetGISMapServicesResponse != null && response.GetGISMapServicesResponse.system.Error != null)
                    {
                        error = response.GetGISMapServicesResponse.system.Error;
                    }
                    else if (response.GetGISObjectsResponse != null && response.GetGISObjectsResponse.system.Error != null)
                    {
                        error = response.GetGISObjectsResponse.system.Error;
                    }
                    else if (response.GetGISObjectsByBufferRadiusResponse != null && response.GetGISObjectsByBufferRadiusResponse.system.Error != null)
                    {
                        error = response.GetGISObjectsByBufferRadiusResponse.system.Error;
                    }
                    else if (response.GetGISObjectsGenealogyResponse != null && response.GetGISObjectsGenealogyResponse.system.Error != null)
                    {
                        error = response.GetGISObjectsGenealogyResponse.system.Error;
                    }
                    else if (response.GetGuidesheetsResponse != null && response.GetGuidesheetsResponse.system.Error != null)
                    {
                        error = response.GetGuidesheetsResponse.system.Error;
                    }
                    else if (response.GetHoldTypesResponse != null && response.GetHoldTypesResponse.system.Error != null)
                    {
                        error = response.GetHoldTypesResponse.system.Error;
                    }
                    else if (response.GetInspectionResponse != null && response.GetInspectionResponse.system.Error != null)
                    {
                        error = response.GetInspectionResponse.system.Error;
                    }
                    else if (response.GetInspectionDistrictsResponse != null && response.GetInspectionDistrictsResponse.system.Error != null)
                    {
                        error = response.GetInspectionDistrictsResponse.system.Error;
                    }
                    else if (response.GetInspectionsResponse != null && response.GetInspectionsResponse.system.Error != null)
                    {
                        error = response.GetInspectionsResponse.system.Error;
                    }
                    else if (response.GetInspectionTypesResponse != null && response.GetInspectionTypesResponse.system.Error != null)
                    {
                        error = response.GetInspectionTypesResponse.system.Error;
                    }
                    else if (response.GetInspectionUnitNumbersResponse != null && response.GetInspectionUnitNumbersResponse.system.Error != null)
                    {
                        error = response.GetInspectionUnitNumbersResponse.system.Error;
                    }
                    else if (response.GetInspectorsResponse != null && response.GetInspectorsResponse.system.Error != null)
                    {
                        error = response.GetInspectorsResponse.system.Error;
                    }
                    else if (response.GetInvoicesResponse != null && response.GetInvoicesResponse.system.Error != null)
                    {
                        error = response.GetInvoicesResponse.system.Error;
                    }
                    else if (response.GetJurisdictionsResponse != null && response.GetJurisdictionsResponse.system.Error != null)
                    {
                        error = response.GetJurisdictionsResponse.system.Error;
                    }
                    else if (response.GetLicensedProfessionalsResponse != null && response.GetLicensedProfessionalsResponse.system.Error != null)
                    {
                        error = response.GetLicensedProfessionalsResponse.system.Error;
                    }
                    else if (response.GetLicenseTypesResponse != null && response.GetLicenseTypesResponse.system.Error != null)
                    {
                        error = response.GetLicenseTypesResponse.system.Error;
                    }
                    else if (response.GetOwnersResponse != null && response.GetOwnersResponse.system.Error != null)
                    {
                        error = response.GetOwnersResponse.system.Error;
                    }
                    else if (response.GetParcelsResponse != null && response.GetParcelsResponse.system.Error != null)
                    {
                        error = response.GetParcelsResponse.system.Error;
                    }
                    else if (response.GetPartTypesResponse != null && response.GetPartTypesResponse.system.Error != null)
                    {
                        error = response.GetPartTypesResponse.system.Error;
                    }
                    else if (response.GetPartInventoryResponse != null && response.GetPartInventoryResponse.system.Error != null)
                    {
                        error = response.GetPartInventoryResponse.system.Error;
                    }
                    else if (response.GetRolesResponse != null && response.GetRolesResponse.system.Error != null)
                    {
                        error = response.GetRolesResponse.system.Error;
                    }
                    else if (response.GetSeverityLevelsResponse != null && response.GetSeverityLevelsResponse.system.Error != null)
                    {
                        error = response.GetSeverityLevelsResponse.system.Error;
                    }
                    else if (response.GetStandardChoicesResponse != null && response.GetStandardChoicesResponse.system.Error != null)
                    {
                        error = response.GetStandardChoicesResponse.system.Error;
                    }
                    else if (response.GetStandardCommentsResponse != null && response.GetStandardCommentsResponse.system.Error != null)
                    {
                        error = response.GetStandardCommentsResponse.system.Error;
                    }
                    else if (response.GetStreetSuffixesResponse != null && response.GetStreetSuffixesResponse.system.Error != null)
                    {
                        error = response.GetStreetSuffixesResponse.system.Error;
                    }
                    else if (response.GetStreetDirectionsResponse != null && response.GetStreetDirectionsResponse.system.Error != null)
                    {
                        error = response.GetStreetDirectionsResponse.system.Error;
                    }
                    else if (response.GetTimeAccountingGroupsResponse != null && response.GetTimeAccountingGroupsResponse.system.Error != null)
                    {
                        error = response.GetTimeAccountingGroupsResponse.system.Error;
                    }
                    else if (response.GetTimeAccountingTypesResponse != null && response.GetTimeAccountingTypesResponse.system.Error != null)
                    {
                        error = response.GetTimeAccountingTypesResponse.system.Error;
                    }
                    else if (response.GetUserResponse != null && response.GetUserResponse.system.Error != null)
                    {
                        error = response.GetUserResponse.system.Error;
                    }
                    else if (response.GetUsersResponse != null && response.GetUsersResponse.system.Error != null)
                    {
                        error = response.GetUsersResponse.system.Error;
                    }
                    else if (response.GetUserSecuritiesResponse != null && response.GetUserSecuritiesResponse.system.Error != null)
                    {
                        error = response.GetUserSecuritiesResponse.system.Error;
                    }
                    else if (response.GetWorkflowResponse != null && response.GetWorkflowResponse.system.Error != null)
                    {
                        error = response.GetWorkflowResponse.system.Error;
                    }
                    else if (response.GetWorkflowHistoryResponse != null && response.GetWorkflowHistoryResponse.system.Error != null)
                    {
                        error = response.GetWorkflowHistoryResponse.system.Error;
                    }
                    else if (response.GetWorkflowTaskStatusValuesResponse != null && response.GetWorkflowTaskStatusValuesResponse.system != null && response.GetWorkflowTaskStatusValuesResponse.system.Error != null)
                    {
                        error = response.GetWorkflowTaskStatusValuesResponse.system.Error;
                    }
                    else if (response.GetWorksheetsResponse != null && response.GetWorksheetsResponse.system.Error != null)
                    {
                        error = response.GetWorksheetsResponse.system.Error;
                    }
                    else if (response.InitiateCAPResponse != null && response.InitiateCAPResponse.system.Error != null)
                    {
                        error = response.InitiateCAPResponse.system.Error;
                    }
                    else if (response.PassGISAddressesResponse != null && response.PassGISAddressesResponse.system.Error != null)
                    {
                        error = response.PassGISAddressesResponse.system.Error;
                    }
                    else if (response.PassGISObjectsResponse != null && response.PassGISObjectsResponse.system.Error != null)
                    {
                        error = response.PassGISObjectsResponse.system.Error;
                    }
                    else if (response.PostMileageResponse != null && response.PostMileageResponse.system.Error != null)
                    {
                        error = response.PostMileageResponse.system.Error;
                    }
                    else if (response.PostPaymentResponse != null && response.PostPaymentResponse.system.Error != null)
                    {
                        error = response.PostPaymentResponse.system.Error;
                    }
                    else if (response.PostTransactionLogResponse != null && response.PostTransactionLogResponse.system.Error != null)
                    {
                        error = response.PostTransactionLogResponse.system.Error;
                    }
                    else if (response.RescheduleInspectionResponse != null && response.RescheduleInspectionResponse.system.Error != null)
                    {
                        error = response.RescheduleInspectionResponse.system.Error;
                    }
                    else if (response.ScheduleInspectionResponse != null && response.ScheduleInspectionResponse.system.Error != null)
                    {
                        error = response.ScheduleInspectionResponse.system.Error;
                    }
                    else if (response.SetGISObjectsGenealogyResponse != null && response.SetGISObjectsGenealogyResponse.system.Error != null)
                    {
                        error = response.SetGISObjectsGenealogyResponse.system.Error;
                    }
                    else if (response.SetInspectionPriorityResponse != null && response.SetInspectionPriorityResponse.system.Error != null)
                    {
                        error = response.SetInspectionPriorityResponse.system.Error;
                    }
                    else if (response.SystemResponse != null && response.SystemResponse.system.Error != null)
                    {
                        error = response.SystemResponse.system.Error;
                    }
                    else if (response.SystemExecuteOperationResponse != null && response.SystemExecuteOperationResponse.system.Error != null)
                    {
                        error = response.SystemExecuteOperationResponse.system.Error;
                    }
                    else if (response.SystemGetConfigurationResponse != null && response.SystemGetConfigurationResponse.system.Error != null)
                    {
                        error = response.SystemGetConfigurationResponse.system.Error;
                    }
                    else if (response.SystemChangeConfigurationResponse != null && response.SystemChangeConfigurationResponse.system.Error != null)
                    {
                        error = response.SystemChangeConfigurationResponse.system.Error;
                    }
                    else if (response.UpdateAssetResponse != null && response.UpdateAssetResponse.system.Error != null)
                    {
                        error = response.UpdateAssetResponse.system.Error;
                    }
                    else if (response.UpdateAssetCAResponse != null && response.UpdateAssetCAResponse.system.Error != null)
                    {
                        error = response.UpdateAssetCAResponse.system.Error;
                    }
                    else if (response.UpdateCAPResponse != null && response.UpdateCAPResponse.system.Error != null)
                    {
                        error = response.UpdateCAPResponse.system.Error;
                    }
                    else if (response.UpdateDocumentResponse != null && response.UpdateDocumentResponse.system.Error != null)
                    {
                        error = response.UpdateDocumentResponse.system.Error;
                    }
                    else if (response.UpdateGISObjectResponse != null && response.UpdateGISObjectResponse.system.Error != null)
                    {
                        error = response.UpdateGISObjectResponse.system.Error;
                    }
                    else if (response.UpdateGISObjectsResponse != null && response.UpdateGISObjectsResponse.system.Error != null)
                    {
                        error = response.UpdateGISObjectsResponse.system.Error;
                    }
                    else if (response.UpdateInspectionResponse != null && response.UpdateInspectionResponse.system.Error != null)
                    {
                        error = response.UpdateInspectionResponse.system.Error;
                    }
                    else if (response.UpdateParcelResponse != null && response.UpdateParcelResponse.system.Error != null)
                    {
                        error = response.UpdateParcelResponse.system.Error;
                    }
                    else if (response.UpdateUserResponse != null && response.UpdateUserResponse.system.Error != null)
                    {
                        error = response.UpdateUserResponse.system.Error;
                    }
                    else if (response.UpdateWorkflowTaskResponse != null && response.UpdateWorkflowTaskResponse.system.Error != null)
                    {
                        error = response.UpdateWorkflowTaskResponse.system.Error;
                    }
                    else if (response.UpdateWorksheetResponse != null && response.UpdateWorksheetResponse.system.Error != null)
                    {
                        error = response.UpdateWorksheetResponse.system.Error;
                    }
                    else if (response.ViewGISMapResponse != null && response.ViewGISMapResponse.system.Error != null)
                    {
                        error = response.ViewGISMapResponse.system.Error;
                    }

                    if (error != null)
                    {
                        var falseErrorCodes = new[]{"0", "0000"};
                        if (! falseErrorCodes.Contains( error.ErrorCode ))
                        {
                            retval = false;
                        }
                    }
                    //----------------------------------------------------------------------------------------------------
                }
            }

            return retval;
        }


        public string StripNamespace(string input)
        {
            string retvalue = input;

            retvalue = retvalue.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
            retvalue = retvalue.Replace(" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");
            retvalue = retvalue.Replace(" xmlns=\"http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL\"", "");

            return retvalue;
        }

        public string StripEncoding(string input)
        {
            string retvalue = input;

            if (retvalue.Substring(0, 13) == "<?xml version" && retvalue.IndexOf(">") > 0)
            {
                retvalue = retvalue.Substring(retvalue.IndexOf(">") + 1, retvalue.Length - retvalue.IndexOf(">") - 1);
                if (retvalue.Substring(0, 1) == "\n")
                {
                    retvalue = retvalue.Substring(1, retvalue.Length - 1);
                }
            }

            return retvalue;
        }

    }

    // You can't specify the encoder with the String Writer, so this takes care of that.  
    // The default encoder is UTF-16 which Accela does NOT like
    public sealed class StringWriterWithEncoding : StringWriter
    {
        private readonly Encoding encoding;

        public StringWriterWithEncoding(Encoding encoding)
        {
            this.encoding = encoding;
        }

        public override Encoding Encoding
        {
            get { return encoding; }
        }
    }

}
