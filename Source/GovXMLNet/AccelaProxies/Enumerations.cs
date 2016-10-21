using System.Xml.Serialization;

/*
 * Note: XMLSerializer can't serialize a nullable attribute. I've added "ForceExclusion" as the first 
 *       item in enumerations that can be suppressed that are used as an attribute.
 *       Thereby it can be excluded from the XML that is generated if it should not be displayed
 *       by using the [name]Specified property for example
 
        private spatialReferenceTypeEnum _contextType = spatialReferenceTypeEnum.ForceExclusion;
        public spatialReferenceTypeEnum contextType
        {
            get { return _contextType; }
            set { _contextType = value; }
        }
        public bool contextTypeSpecified
        {
            get
            {
                return _contextType != spatialReferenceTypeEnum.ForceExclusion;
            }
        }
 *
 */

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 2/14/2012
 * Modifications:
*/

namespace GovXMLNet
{
    // Defined in AccelaSystemDataObject
    //----------------------------------------------------------------------------------------------------------------------
    public enum contextEnumType { AccelaDocumentService, AccelaGis, AccelaIvr, AccelaRfs, AccelaWireless, AccelaWirelessInspection, VelocityHall, AccelaMobileOffice }
    public enum errorClassEnumType { Business, Database, Logical, Network, Remote, Runtime, Schema, System, Undefined }
    //public enum ItemChoiceType { None, connectionString, dataSourceName, url }



    // Defined in AccelaSharedDataObjects
    //----------------------------------------------------------------------------------------------------------------------    
    public enum dataitemChangeEnum { ForceExclusion, Add, Append, Delete, Existing, New, Replace, Readonly, Update }
    public enum datasetChangeEnum { Add, Append, Delete, DeleteAll, Existing, New, Replace, Readonly, Update }
    // InLine definition from ComplexType Option
    public enum enumOptionType { Configuration, Display, Processing }



    // Defined in AccelaOperationRepository_Base
    //----------------------------------------------------------------------------------------------------------------------
    public enum queryLogicEnum { AND, OR }



    // Defined in AccelaOperationRepository_GIS
    //----------------------------------------------------------------------------------------------------------------------
    public enum gisObjectDetailReturnEnum { All, Basic, Attributes, CompactAddresses, DetailAddresses, Extent, GISLayerId, MapServiceId, SpatialDescriptors, Contacts }
    public enum gisPassViewReturnEnum { All, Basic, ElectronicFile, UniversalResourceLocator }
    public enum gisLayersEnum { All, [XmlEnum(Name = "Edit Layers")] EditLayers, [XmlEnum(Name = "Production Layers")] ProductionLayers }



    // defined in accelaGovXMLDataObjects
    //----------------------------------------------------------------------------------------------------------------------
    public enum addressFormatEnum { UnitedStates, PuertoRico, Others }
    public enum attributeTypeEnum { Char, Date, Double, Float, Integer, LongInteger, RowId, Shape, SmallInteger, String }
    public enum capIssuanceEnum { Issued, Submitted }
    public enum capRelationContextTypeEnum { Child, Parent, Sibling }
    public enum parcelsGenealogyTypeEnum { Split, Merge }
    //public enum capRelationTypeEnum { Account, Accounts, Amendment, Amendments, "Business License", 
    public enum capTypeEnum { Readonly, Restricted }
    public enum comparisonOperatorEnum { EQ, NE, GE, GT, LE, LT }
    public enum directionEnum { E, ENE, ESE, N, NE, NNE, NNW, NW, S, SE, SSE, SSW, SW, W, WNW, WSW }
    public enum documentLocatorContextTypeEnum { Copy, Missing, MovedFrom, MovedTo, NoStatus, ReceivedAt, SentTo }
    public enum electronicFileServerPlatformEnum { DB2, MacintoshOS, MSSQL, MSSQL2000, MSSQL65, MSSQL7, WindowsOS, LinuxOS, NetwareOS, Oracle, Oracle7, Oracle8, Oracle9, Sybase, UnixOS, Others }
    public enum electronicFileServerTypeEnum { Database, DocumentService, FileSystem, Others }
    public enum electronicFileServerVendorEnum { Accela, Apple, IBM, Microsoft, Novell, Oracle, Sybase, Others }
    //public enum guideitemSpecialTypeEnum { Yes, No, 'N/A' }
    public enum holdLevelEnum { Lock, Hold, Notice, Comment, None }
    public enum gisGeometryTypeEnum { Line, Point, Polygon, MultipleLines, MultiplePoints, MultiplePolygons }
    public enum gisLayerTypeEnum { Acetate, FeatureLayer, Image }
    public enum gisMapServiceTypeEnum { ImageServer, FeatureServer, ArcMapServer, MetaDataServer }
    public enum gisRouteNodeRequestedOrderingPositionEnum { Any, First, Last }
    public enum inspectionTypeEnum { Available, Completed, Failed, New, Pending, Readonly, Requried, Scheduled, [XmlEnum("")] Unknown }
    public enum inspectionTimeSpecialType { AM, PM }
    public enum objectContextTypeEnum { CAP, Inspection, Parcel }
    public enum paymentMethodEnum { ACH, Account, Cash, Check, CreditCard, Others }
    public enum rangeConstraintEnum { Inclusive, Exclusive }
    public enum rangeProcessValueEnum { Lax, Skip, Strict }
    public enum severityLevelEnum
    {
        High, 
        Medium, 
        Low, 
        Lowest, 
        None,
        Notice // Not present in XSD but TRPA data had a value of Notice
    }
    public enum spatialReferenceTypeEnum { AllowedMaximum, AllowedMinimum, AllowedAddition, AllowedSubtraction, AllowedFinal, Existing, ProposedAddition, ProposedSubtraction, ProposedFinal, Recorded, Reference /* found in response */, Daily /* found in response */ }
    public enum entityTypeEnum { CAP_DETAIL, ASI, ASIT, GUIDESHEET, CAP_CONDITION, STD_CONDITION, REF_ADDRESS_CONDITION, REF_PARCEL_CONDITION, LP_CONDITION, REF_OWNER_CONDITION, STRUC_EST_CONDITION, ASSET_CONDITION, CONTACT_CONDITION, STRUCTURE_CONDITION }
    public enum structuralTypeEnum { ForceExclusion, Structural, DataAndStructural, Data }
    public enum resolutionTypeEnum { Pass, Fail }
    public enum paymentTransactionVendorEnum { AMX, Verisign, Others, None }
    public enum enumDataType { Checkbox, Date, Enumeration, Float, Integer, ReadOnlyText, String, YesNo, Currency, Time /* returned value */ } // Internal to DataType definition



    //defined in ifc2x_final_stage2_03
    //----------------------------------------------------------------------------------------------------------------------
    public enum CurrencyEnum { aed, aes, ats, aud, bbd, beg, bgl, bhd, bmd, bnd, brl, bsd, bwp, bzd, cad, cbd, chf, clp, cny, cys, czk, ddp, dem, dkk, egl, est, eur, fak, fim, fjd, fkp, frf, gbp, gip, gmd, grx, hkd, huf, ick, idr, ils, inr, irp, itl, jmd, jod, jpy, kes, krw, kwd, kyd, lkr, luf, mtl, mur, mxn, myr, nlg, nzd, omr, pgk, php, pkr, pln, ptn, qar, rur, sar, scr, sek, sgd, skp, thb, trl, ttd, twd, usd, veb, vnd, xeu, zar, zwd, nok }
    public enum RoleEnum { supplier, manufacturer, contractor, subcontractor, architect, structuralengineer, costengineer, client, buildingowner, buildingoperator, mechanicalengineer, electricalengineer, projectmanager, facilitiesmanager, civilengineer, comissioningengineer, engineer, owner, consultant, constructionmanager, fieldconstructionmanager, reseller, userdefined }
    public enum AddressTypeEnum { office, site, home, distributionpoint, userdefined }
    public enum ElementCompositionEnum { complex, element, partial }
    public enum StateEnum { readwrite, [XmlEnum(Name = "readonly")] read_only, locked, readwritelocked, readonlylocked }
    public enum ChangeActionEnum { nochange, modified, added, deleted, modifiedadded, modifieddeleted }




    //defined in AccelaOperationRepository_GovXML
    //----------------------------------------------------------------------------------------------------------------------
    public enum addressDetailReturnEnum { All, Basic, AdditionalInformation, Alias, Contacts, Country, County, Parcels, PostalCode, SpatialDescriptors, SpatialObjects, State }
    public enum capDetailReturnEnum { All, Basic, AdditionalInformation, Addresses, ApprovalDate, CAPRelations, Checklist, CompactAddresses, Conditions, Contacts, Description, Dispositions, EffectiveDate, ElectronicSignatures, ExpirationDate, FileDate, GISObjects, Holds, Inspections, Parcels, SpatialDescriptors, SpatialObjects, Type }
    public enum capTypeDetailReturnEnum { All, Basic, AdditionalInformationGroupIds, ConditionTypeIds, Dispositions, HoldTypeIds, InspectionTypeSetIds }
    public enum capsSearchTypeEnum { All, Account, Complaint, Development, License, Permit, Project, ServiceRequest, Set }
    public enum capTypesSearchTypeEnum { All, Account, Complaint, Development, License, Permit, Project, Public, ServiceRequest }
    public enum conditionTypeReturnEnum { All, Basic, Dispositions, SeverityLevels }
    public enum finalizeCAPResponseContextTypeEnum { Issued, Submitted }
    public enum getAdditionalInformationGroupsContextTypeEnum { Asset, CAP, People}
    public enum getDispositionsContextTypeEnum { All, AssetStatus, CAP, Checkitem, Condition, Hold, Inspection }
    public enum getHoldTypesContextTypeEnum { CAP, Inspection, Parcel }
    public enum getInvoicesContextTypeEnum { All, Closed, Outstanding, PastDue }
    public enum getSeverityLevelsContextTypeEnum { Checkitem, Condition, Hold }
    public enum holdTypeReturnEnum { All, Basic, Dispositions, HoldLevels, SeverityLevels }
    public enum inspectionDetailReturnEnum { All, Basic, Checklist, CompactAddress, Conditions, Contacts, DetailAddress, Dispositions, ElectronicSignatures, Guidesheets, Holds, InspectionDate, InspectionTime, Inspector, RequestComment, ResultComment, SpatialDescriptors, Type, TimeAccountings }
    public enum inspectionTypeDetailReturnEnum { All, Basic, Dispositions, GuidesheetIds, InspectionStatus }
    public enum parcelDetailReturnEnum { All, Basic, AdditionalInformation, Addresses, CAPIds, CAPs, CompactAddresses, Contacts, SpatialDescriptors, SpatialElements, SpatialObjects }
    public enum routeCalculationMethodEnum { Direct, Route }
    public enum routeCalculationPriorityEnum { Distance, Time }

    /*
     * Enumerations based on message request
     * These are NOT defined by Accela, rather for the purpose of guaranteeing the choice condition in XML
     * They are also declared here in the public namespace instead of privately in the class so they can be used
     * by the test program.  That way a method won't get overlooked without throwing an error while testing.
     * 
     * The naming convention is eChoice[name of request], unless it is a group choice, then it is eChoice[GroupName]
     */
    public enum eChoiceCalculateInvoices
    {
        scContactID,
        scCAPId,
        scDateRange,
        scInvoiceId
    }
    public enum eChoiceCancelInspectionResponse
    {
        scInspection,
        scInspectionId
    }
    public enum eChoiceCalculateRouteResponse
    {
        scRouteNodeIds,
        scRouteNodes
    }
    public enum eChoicePeopleIdSelect  // Used in AuthenticateUserResponse
    {
        scInspectorId,
        scPeopleId,
        scUserId
    }
    public enum eChoiceAuthenticateUser
    {
        scUserNamePassword,
        scSSOSessionId
    }
    public enum eChoiceFinalizeCAPResponse
    {
        scCAP,
        scCAPId
    }
    public enum eChoiceAssetsSearchCollectionSelect
    {
        scAssetIds,
        scStatus,
        scAssetTypes,
        scDescription,
        scDateOfService,
        scStatusDates,
        scCurrentValue,
        scComments
    }
    public enum eChoiceAddressSearchCollectionSelect
    {
        scCAPId,
        scCAPTypeId,
        scDateRange,
        scDetailAddress,
        scParcelId,
        scCAPIds,
        scCAPStatuses,
        scCAPTypeIds,
        scDateRanges,
        scParcelIds
    }
    public enum eChoiceConditionsSearchCollectionSelect
    {
        scCAPIds,
        scCAPTypeIds,
        scDateRanges,
        scInspectionIds,
        scInspectionTypes
    }
    public enum eChoiceCAPTypesSearchCollectionSelect
    {
        scInspectionType,
        scType,
        scIVRCode
    }
    public enum eChoiceCAPsSearchCollectionSelect
    {
        scCAPId,
        scCAPIds,
        scCAPStatuses,
        scCAPTypeIds,
        //scCompactAddressIds,
        scContactIds,
        scContacts,
        scDateRanges,
        scDetailAddresses,
        scGISObjectIds,
        scGISObjects,
        scInspectionDistricts,
        scInspectionIds,
        scInspectionStatuses,
        scInspectionTypeIds,
        scInspectionTypes,
        scInspectorIds,
        scLicenses,
        scParcelId,
        scParcelIds,
        scSpatialDescriptors,
        scStatuses,
        scApprovalDateRanges,
        scCompletionDateRanges,
        scCreationDateRanges,
        scDisapprovalDateRanges,
        scExpirationDateRanges,
        scInspectorRoles,
        scKeyword,
        scParentCAPId,
        scParentCAPIds,
        //scPartialCAPId,
        //scPartialCAPIds,
        scSubsidiaryCAPId,
        scSubsidiaryCAPIds,
        scType,
        scDepartments,
        scAssetIds,
        scMaxRecordsPerAssetId,
        scActivePermitsFlag
    }
    public enum eChoiceHoldsSearchCollectionSelect
    {
        scEmpty, 
        scCAPIds,
        scCAPTypeIds,
        scCompactAddressIds,
        scContacts,
        scContactIds,
        scDateRanges,
        scDetailAddresses,
        scLicenses,
        scParcelIds
    }
    public enum eChoiceGuidesheetSearchCollectionSelect
    {
        scEmpty,
        scCAPId,
        scCAPTypeId,
        scInspectionId,
        scInspectionType
    }

    // Defined in AccelaOperationRepository_GIS
    public enum eChoiceGetGISObjectsGenealogy
    {
        scActionId,
        scActionDateTime,
        scGISObjectIds
    }

    public enum eChoiceGISObjectsSearchCollectionSelect
    {
        scAttributes,
        scCriterions,
        scGISDynamicTheme,
        scGISLayerId,
        scGISObjectIds,
        scGISObjectTypes
    }
    public enum eChoiceGetInspection
    {
        scConfirmationNumber,
        scInspectionId
    }
    public enum eChoiceInspectionTypeSearchCollectionSelect
    {
        scCAPId,
        scCAPTypeId,
        scInspectorId,
        scGetByCode
    }
    public enum eChoiceInspectionDistrictsSearchCollectionSelect
    {
        scCAPIds,
        scCAPTypeIds,
        scCompactAddressIds,
        scDetailAddresses,
        scInspectionIds,
        scInspectionTypes,
        scParcelIds
    }
    public enum eChoiceInvoiceSearchCollectionSelect
    {
        scCAPId,
        scDateRange,
        scInvoiceId
    }
    public enum eChoiceInspectionSearchCollectionSelect
    {
        scCAPIds,
        scCAPTypeIds,
        scConfirmationNumbers,
        scContact,
        scDateRanges,
        scType,
        scDepartment,
        scDetailAddresses,
        scInspectionDistrictIds,
        scInspectionStatuses,
        scInspectionTypeIds,
        scInspectionTypes,
        scInspectorIds,
        scMapReference,
        scParcelId,
        scCompletionDateRanges,
        scScheduledDateRanges
    }
    public enum eChoiceParcelSearchCollectionSelect
    {
        scCAPIds,
        scCAPStatuses,
        scContact,
        scDateRanges,
        scDetailAddresses,
        scGISObjects,
        scParcelIds,
        scSpatialDescriptors
    }
    public enum eChoiceSeverityLevelsSearchCollectionSelect
    {
        scConditionTypeIds,
        scHoldTypeIds
    }
    public enum eChoiceGetStandardCommentsResponse
    {
        scStandardComments,
        scStandardCommentsGroups
    }
    public enum eChoiceUpdateInspectionResponse
    {
        scInspection,
        scInspectionId
    }
    public enum eChoiceUpdateGISObject
    {
        scAttributes,
        scExtent,
        scGISLayerId,
        scMapServiceId
    }
    public enum eChocieRescheduleInspectionResponse
    {
        scInspection,
        scInspectionId
    }
    public enum eChocieScheduleInspectionResponse
    {
        scInspection,
        scInspectionId
    }
    public enum eChoiceUpdateAssetResponse
    {
        scAsset,
        scAssetId
    }
    public enum eChoiceUpdateCAPResponse
    {
        scCAP,
        scCAPId
    }
    public enum eChoiceInitiateCAPResponse
    {
        scCAP,
        scCAPId
    }
    public enum eChoiceInitiateCAPAddress
    {
        scDetailAddress
    }
    public enum eChoiceInitiateCAPGIS
    {
        scGISObjectIds,
        scGISObjects
    }
    public enum eChoiceInitiateCAPParcel
    {
        scParcelIds,
        scParcels
    }
    public enum eChoiceCAPUpdateCollectionSelect
    {
        scAdditionalInformation,
        scAddresses,
        scApprovalDate,
        scCAPRelations,
        scChecklist,
        scCompactAddresses,
        scConditions,
        scContacts,
        scDescription,
        scEffectiveDate,
        scExpirationDate,
        scElectronicSignatures,
        scFileDate,
        scGISObjects,
        scGISObjectIds,
        scHolds,
        scParcelIds,
        scParcels,
        scSpatialDescriptors,
        scSpatialObjects,
        scStatus,
        scType,
        scWorksheets,
        scAssets,
        scParts,
        scCostItems,
        scParentCAPIds,
        scDepartment,
        scStaffPerson,
        scAssignedDate,
        scScheduleDate,
        scScheduleTime
    }

}
