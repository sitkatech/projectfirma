using System;
using System.Xml.Serialization;

// Defined in AccelaOpenSystemInterfaceXML

/* START HERE if trying to look through classes
 * This is the class that gets serialized/deserialized when communicating with Accela
 * All calls are defined here.  Each has a request to GovXML and a corresponding response 
*/

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 2/14/2012
 * Modifications:
 * 04/06/2012 Bob Thiele - Updated for version 7.1
*/
namespace GovXMLNet
{
    [Serializable]
    [XmlRootAttribute("GovXML")]
    public class GovXML
    {
        // Members (really all of the calls/responses possible
        
        public undFSystemOut FSystemOut = null;      // (Error returned will be here otherwise should be null)
               
        public msgAddNewDocument AddNewDocument = null;
        public msgAddNewDocumentResponse AddNewDocumentResponse = null;        

        public msgAuthenticateUser AuthenticateUser = null;
        public msgAuthenticateUserResponse AuthenticateUserResponse = null;        
        
        public msgBatchOperation BatchOperation = null;
        public msgBatchOperationResponse BatchOperationResponse = null;

        public msgCalculateInvoices CalculateInvoices = null;
        public msgCalculateInvoicesResponse CalculateInvoicesResponse = null;

        public msgCalculateRoute CalculateRoute = null;
        public msgCalculateRouteResponse CalculateRouteResponse = null;

        public msgCancelInspection CancelInspection = null;
        public msgCancelInspectionResponse CancelInspectionResponse = null;

        public msgCreateDocument CreateDocument = null;
        public msgCreateDocumentResponse CreateDocumentResponse = null;

        public msgCreateAsset CreateAsset = null;
        public msgCreateAssetResponse CreateAssetResponse = null;

        public msgDeleteDocument DeleteDocument = null;
        public msgDeleteDocumentResponse DeleteDocumentResponse = null;
        
        public msgFinalizeCAP FinalizeCAP = null;
        public msgFinalizeCAPResponse FinalizeCAPResponse = null;

        public msgGetAdditionalInformationGroups GetAdditionalInformationGroups = null;
        public msgGetAdditionalInformationGroupsResponse GetAdditionalInformationGroupsResponse = null;

        public msgGetAddresses GetAddresses = null;
        public msgGetAddressesResponse GetAddressesResponse = null;

        public msgGetAssetCAStatus GetAssetCAStatus = null;
        public msgGetAssetCAStatusResponse GetAssetCAStatusResponse = null;

        public msgGetAssetCATypes GetAssetCATypes = null;
        public msgGetAssetCATypesResponse GetAssetCATypesResponse = null;

        public msgGetAssetCAs GetAssetCAs = null;
        public msgGetAssetCAsResponse GetAssetCAsResponse = null;

        public msgGetAssets GetAssets = null;
        public msgGetAssetsResponse GetAssetsResponse = null;

        public msgGetAssetTypes GetAssetTypes = null;
        public msgGetAssetTypesResponse GetAssetTypesResponse = null;

        public msgGetAssetUsages GetAssetUsages = null;
        public msgGetAssetUsagesResponse GetAssetUsagesResponse = null;

        public msgGetAuditLogs GetAuditLogs = null;
        public msgGetAuditLogsResponse GetAuditLogsResponse = null;

        public msgGetAvailableInspectionDates GetAvailableInspectionDates = null;
        public msgGetAvailableInspectionDatesResponse GetAvailableInspectionDatesResponse = null;
        
        public msgGetCAP GetCAP = null;
        public msgGetCAPResponse GetCAPResponse = null;

        public msgGetCAPs GetCAPs = null;
        public msgGetCAPsResponse GetCAPsResponse = null;

        public msgGetCAPTypes GetCAPTypes = null;
        public msgGetCAPTypesResponse GetCAPTypesResponse = null;

        public msgGetCities GetCities = null;
        public msgGetCitiesResponse GetCitiesResponse = null;

        public msgGetConditionTypes GetConditionTypes = null;
        public msgGetConditionTypesResponse GetConditionTypesResponse = null;

        public msgGetContacts GetContacts = null;
        public msgGetContactsResponse GetContactsResponse = null;

        public msgGetCostTypes GetCostTypes = null;
        public msgGetCostTypesResponse GetCostTypesResponse = null;

        public msgGetCriterions GetCriterions = null;
        public msgGetCriterionsResponse GetCriterionsResponse = null;

        public msgGetDepartments GetDepartments = null;
        public msgGetDepartmentsResponse GetDepartmentsResponse = null;

        public msgGetDispositions GetDispositions = null;
        public msgGetDispositionsResponse GetDispositionsResponse = null;

        public msgGetDocument GetDocument = null;
        public msgGetDocumentResponse GetDocumentResponse = null;

        public msgGetDocumentGroups GetDocumentGroups = null;
        public msgGetDocumentGroupsResponse GetDocumentGroupsResponse = null;

        public msgGetDocumentList GetDocumentList = null;
        public msgGetDocumentListResponse GetDocumentListResponse = null;

        public msgGetDocuments GetDocuments = null;
        public msgGetDocumentsResponse GetDocumentsResponse = null;

        public msgGetEDMSAdapters GetEDMSAdapters = null;
        public msgGetEDMSAdaptersResponse GetEDMSAdaptersResponse = null;

        public msgGetGISDynamicThemes GetGISDynamicThemes = null;
        public msgGetGISDynamicThemesResponse GetGISDynamicThemesResponse = null;

        public msgGetGISLayerGroups GetGISLayerGroups = null;
        public msgGetGISLayerGroupsResponse GetGISLayerGroupsResponse = null;

        public msgGetGISLayers GetGISLayers = null;
        public msgGetGISLayersResponse GetGISLayersResponse = null;

        public msgGetGISMapServices GetGISMapServices = null;
        public msgGetGISMapServicesResponse GetGISMapServicesResponse = null;

        public msgGetGISObjects GetGISObjects = null;
        public msgGetGISObjectsResponse GetGISObjectsResponse = null;

        public msgGetGISObjectsByBufferRadius GetGISObjectsByBufferRadius = null;
        public msgGetGISObjectsByBufferRadiusResponse GetGISObjectsByBufferRadiusResponse = null;

        public msgGetGISObjectsGenealogy GetGISObjectsGenealogy = null;
        public msgGetGISObjectsGenealogyResponse GetGISObjectsGenealogyResponse = null;

        public msgGetGuidesheets GetGuidesheets = null;
        public msgGetGuidesheetsResponse GetGuidesheetsResponse = null;
        
        public msgGetHoldTypes GetHoldTypes = null;
        public msgGetHoldTypesResponse GetHoldTypesResponse = null;
        
        public msgGetInspection GetInspection = null;
        public msgGetInspectionResponse GetInspectionResponse = null;
        
        public msgGetInspectionDistricts GetInspectionDistricts = null;
        public msgGetInspectionDistrictsResponse GetInspectionDistrictsResponse = null;
        
        public msgGetInspections GetInspections = null;
        public msgGetInspectionsResponse GetInspectionsResponse = null;
        
        public msgGetInspectionTypes GetInspectionTypes = null;
        public msgGetInspectionTypesResponse GetInspectionTypesResponse = null;
        
        public msgGetInspectionUnitNumbers GetInspectionUnitNumbers = null;
        public msgGetInspectionUnitNumbersResponse GetInspectionUnitNumbersResponse = null;
        
        public msgGetInspectors GetInspectors = null;
        public msgGetInspectorsResponse GetInspectorsResponse = null;
                
        public msgGetInvoices GetInvoices = null;
        public msgGetInvoicesResponse GetInvoicesResponse = null;
        
        public msgGetJurisdictions GetJurisdictions = null;
        public msgGetJurisdictionsResponse GetJurisdictionsResponse = null;
        
        public msgGetLicensedProfessionals GetLicensedProfessionals = null;
        public msgGetLicensedProfessionalsResponse GetLicensedProfessionalsResponse = null;
        
        public msgGetLicenseTypes GetLicenseTypes = null;
        public msgGetLicenseTypesResponse GetLicenseTypesResponse = null;

        public msgGetOwners GetOwners = null;
        public msgGetOwnersResponse GetOwnersResponse = null;

        // From CRC Accela 7.2 Not implemented in AA so far use GetParcels instead
        // Since they said so far instead of not supported, I am not deleting the classes
        //public msgGetParcel GetParcel = null;
        //public msgGetParcelResponse GetParcelResponse = null;
        
        public msgGetParcels GetParcels = null;
        public msgGetParcelsResponse GetParcelsResponse = null;
        
        public msgGetPartTypes GetPartTypes = null;
        public msgGetPartTypesResponse GetPartTypesResponse = null;
        
        public msgGetPartInventory GetPartInventory = null;
        public msgGetPartInventoryResponse GetPartInventoryResponse = null;
        
        public msgGetRoles GetRoles = null;
        public msgGetRolesResponse GetRolesResponse = null;
        
        public msgGetSeverityLevels GetSeverityLevels = null;
        public msgGetSeverityLevelsResponse GetSeverityLevelsResponse = null;

        public msgGetStandardChoices GetStandardChoices = null;
        public msgGetStandardChoicesResponse GetStandardChoicesResponse = null;

        public msgGetStandardComments GetStandardComments = null;
        public msgGetStandardCommentsResponse GetStandardCommentsResponse = null;

        public msgGetStreetSuffixes GetStreetSuffixes = null;
        public msgGetStreetSuffixesResponse GetStreetSuffixesResponse = null;

        public msgGetStreetDirections GetStreetDirections = null;
        public msgGetStreetDirectionsResponse GetStreetDirectionsResponse = null;

        public msgGetTimeAccountingGroups GetTimeAccountingGroups = null;
        public msgGetTimeAccountingGroupsResponse GetTimeAccountingGroupsResponse = null;

        public msgGetTimeAccountingTypes GetTimeAccountingTypes = null;
        public msgGetTimeAccountingTypesResponse GetTimeAccountingTypesResponse = null;

        public msgGetUser GetUser = null;
        public msgGetUserResponse GetUserResponse = null;

        public msgGetUsers GetUsers = null;
        public msgGetUsersResponse GetUsersResponse = null;

        public msgGetUserSecurities GetUserSecurities = null;
        public msgGetUserSecuritiesResponse GetUserSecuritiesResponse = null;

        public msgGetWorkflow GetWorkflow = null;
        public msgGetWorkflowResponse GetWorkflowResponse = null;

        public msgGetWorkflowHistory GetWorkflowHistory = null;
        public msgGetWorkflowHistoryResponse GetWorkflowHistoryResponse = null;

        public msgGetWorkflowTaskStatusValues GetWorkflowTaskStatusValues = null;
        public msgGetWorkflowTaskStatusValuesResponse GetWorkflowTaskStatusValuesResponse = null;

        public msgGetWorksheets GetWorksheets = null;
        public msgGetWorksheetsResponse GetWorksheetsResponse = null;
        
        public msgInitiateCAP InitiateCAP = null;
        public msgInitiateCAPResponse InitiateCAPResponse = null;
        
        public msgPassGISAddresses PassGISAddresses = null;
        public msgPassGISAddressesResponse PassGISAddressesResponse = null;
        
        public msgPassGISObjects PassGISObjects = null;
        public msgPassGISObjectsResponse PassGISObjectsResponse = null;
        
        public msgPostMileage PostMileage = null;
        public msgPostMileageResponse PostMileageResponse = null;
        
        public msgPostPayment PostPayment = null;
        public msgPostPaymentResponse PostPaymentResponse = null;
        
        public msgPostTransactionLog PostTransactionLog = null;
        public msgPostTransactionLogResponse PostTransactionLogResponse = null;
        
        public msgRescheduleInspection RescheduleInspection = null;
        public msgRescheduleInspectionResponse RescheduleInspectionResponse = null;
        
        public msgScheduleInspection ScheduleInspection = null;
        public msgScheduleInspectionResponse ScheduleInspectionResponse = null;

        public msgSetGISObjectsGenealogy SetGISObjectsGenealogy = null;
        public msgSetGISObjectsGenealogyResponse SetGISObjectsGenealogyResponse = null;

        public msgSetInspectionPriority SetInspectionPriority = null;
        public msgSetInspectionPriorityResponse SetInspectionPriorityResponse = null;
        
        public msgSystemRequest SystemRequest = null;
        public msgSystemResponse SystemResponse = null;
        
        public msgSystemExecuteOperation SystemExecuteOperation = null;
        public msgSystemExecuteOperationResponse SystemExecuteOperationResponse = null;
        
        public msgSystemGetConfiguration SystemGetConfiguration = null;
        public msgSystemGetConfigurationResponse SystemGetConfigurationResponse = null;
        
        public msgSystemChangeConfiguration SystemChangeConfiguration = null;
        public msgSystemChangeConfigurationResponse SystemChangeConfigurationResponse = null;
        
        public msgUpdateAsset UpdateAsset = null;
        public msgUpdateAssetResponse UpdateAssetResponse = null;

        public msgUpdateAssetCA UpdateAssetCA = null;
        public msgUpdateAssetCAResponse UpdateAssetCAResponse = null;

        public msgUpdateCAP UpdateCAP = null;
        public msgUpdateCAPResponse UpdateCAPResponse = null;
        
        public msgUpdateDocument UpdateDocument = null;
        public msgUpdateDocumentResponse UpdateDocumentResponse = null;
        
        public msgUpdateGISObject UpdateGISObject = null;
        public msgUpdateGISObjectResponse UpdateGISObjectResponse = null;
        
        public msgUpdateGISObjects UpdateGISObjects = null;
        public msgUpdateGISObjectsResponse UpdateGISObjectsResponse = null;
        
        public msgUpdateInspection UpdateInspection = null;
        public msgUpdateInspectionResponse UpdateInspectionResponse = null;

        public msgUpdateParcel UpdateParcel = null;
        public msgUpdateParcelResponse UpdateParcelResponse = null;
        
        public msgUpdateUser UpdateUser = null;
        public msgUpdateUserResponse UpdateUserResponse = null;

        public msgUpdateWorkflowTask UpdateWorkflowTask = null;
        public msgUpdateWorkflowTaskResponse UpdateWorkflowTaskResponse = null;

        public msgUpdateWorksheet UpdateWorksheet = null;
        public msgUpdateWorksheetResponse UpdateWorksheetResponse = null;
      

        public msgViewGISDynamicTheme ViewGISDynamicTheme = null;  // Just a call there is no response

        
        public msgViewGISMap ViewGISMap = null;
        public msgViewGISMapResponse ViewGISMapResponse = null;
        
        // Constructors

        public GovXML()
        {
        }

    }
}
