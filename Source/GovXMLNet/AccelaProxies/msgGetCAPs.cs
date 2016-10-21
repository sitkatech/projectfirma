// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
  <xsd:complexType name="GetCAPs">
    <xsd:complexContent>
      <xsd:extension base="OperationRequest">
        <xsd:sequence>
          <xsd:element name="returnElements" form="qualified" minOccurs="0">
            <xsd:complexType>
              <xsd:sequence maxOccurs="unbounded">
                <xsd:element name="returnElement" form="qualified">
                  <xsd:complexType>
                    <xsd:simpleContent>
                      <xsd:extension base="capDetailReturnEnum">
                        <xsd:attribute name="detailLevels" type="xsd:nonNegativeInteger" use="optional"/>
                      </xsd:extension>
                    </xsd:simpleContent>
                  </xsd:complexType>
                </xsd:element>
              </xsd:sequence>
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="validatingLicenses" type="Licenses" form="qualified" minOccurs="0"/>
          <xsd:element name="collectionsLevelQueryLogic" type="queryLogicEnum" default="OR" form="qualified" minOccurs="0"/>
          <xsd:element name="collectionLevelQueryLogic" type="queryLogicEnum" default="OR" form="qualified" minOccurs="0"/>
          <xsd:choice maxOccurs="unbounded">
            <xsd:group ref="CAPsSearchCollectionSelect"/>
          </xsd:choice>
          <xsd:element name="useCachedCAPs" type="xsd:boolean" default="false" form="qualified" minOccurs="0"/>
          <xsd:element name="withOpenInspectionsOnly" type="xsd:boolean" default="false" form="qualified" minOccurs="0"/>
          <xsd:element name="withUnassignedInspectionsOnly" type="xsd:boolean" default="false" form="qualified" minOccurs="0"/>
          <xsd:element name="withOutstandingFeeDueOnly" type="xsd:boolean" default="false" form="qualified" minOccurs="0"/>
          <xsd:element name="ScheduleDate" type="DateRanges"/>
          <xsd:element ref="ParcelIds"/>
        </xsd:sequence>
      </xsd:extension>
    </xsd:complexContent>
  </xsd:complexType>
*/

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 2/14/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class msgGetCAPs : clsOperationRequest
    {

        // Members
        public lctGetCAPsReturnElements returnElements { get; set; }
        public clsLicenses validatingLicenses { get; set; }

        private queryLogicEnum? _collectionsLevelQueryLogic = queryLogicEnum.OR;
        public queryLogicEnum? collectionsLevelQueryLogic
        {
            get
            {
                if (_collectionsLevelQueryLogic.HasValue)
                {
                    return _collectionsLevelQueryLogic.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _collectionsLevelQueryLogic = value; }
        }
        public bool collectionsLevelQueryLogicSpecified
        {
            get { return _collectionsLevelQueryLogic != null; }
        }

        private queryLogicEnum? _collectionLevelQueryLogic = queryLogicEnum.OR;
        public queryLogicEnum? collectionLevelQueryLogic
        {
            get
            {
                if (_collectionLevelQueryLogic.HasValue)
                {
                    return _collectionLevelQueryLogic.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _collectionLevelQueryLogic = value; }
        }
        public bool collectionLevelQueryLogicSpecified
        {
            get { return _collectionLevelQueryLogic != null; }
        }


        // Begin group CAPsSearchCollectionSelect
        // Begin choice
        private clsCAPId _CAPId = null;
        public clsCAPId CAPId
        {
            get { return _CAPId; }
            set
            {
                _CAPId = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scCAPId);
            }
        }

        private clsCAPIds _CAPIds = null;
        public clsCAPIds CAPIds
        {
            get { return _CAPIds; }
            set
            {
                _CAPIds = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scCAPIds);
            }
        }

        private clsCAPStatuses _CAPStatuses = null;
        public clsCAPStatuses CAPStatuses
        {
            get { return _CAPStatuses; }
            set
            {
                _CAPStatuses = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scCAPStatuses);
            }
        }

        private clsCAPTypeIds _CAPTypeIds = null;
        public clsCAPTypeIds CAPTypeIds
        {
            get { return _CAPTypeIds; }
            set
            {
                _CAPTypeIds = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scCAPTypeIds);
            }
        }

        private clsContactIds _ContactIds = null;
        public clsContactIds ContactIds
        {
            get { return _ContactIds; }
            set
            {
                _ContactIds = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scContactIds);
            }
        }

        private clsContacts _Contacts = null;
        public clsContacts Contacts
        {
            get { return _Contacts; }
            set
            {
                _Contacts = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scContacts);
            }
        }

        private clsDateRanges _DateRanges = null;
        public clsDateRanges DateRanges
        {
            get { return _DateRanges; }
            set
            {
                _DateRanges = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scDateRanges);
            }
        }

        private clsDetailAddresses _DetailAddresses = null;
        public clsDetailAddresses DetailAddresses
        {
            get { return _DetailAddresses; }
            set
            {
                _DetailAddresses = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scDetailAddresses);
            }
        }

        private clsGISObjectIds _GISObjectIds = null;
        public clsGISObjectIds GISObjectIds
        {
            get { return _GISObjectIds; }
            set
            {
                _GISObjectIds = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scGISObjectIds);
            }
        }

        private clsGISObjects _GISObjects = null;
        public clsGISObjects GISObjects
        {
            get { return _GISObjects; }
            set
            {
                _GISObjects = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scGISObjects);
            }
        }

        private clsInspectionDistricts _InspectionDistricts = null;
        public clsInspectionDistricts InspectionDistricts
        {
            get { return _InspectionDistricts; }
            set
            {
                _InspectionDistricts = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scInspectionDistricts);
            }
        }

        private clsInspectionIds _InspectionIds = null;
        public clsInspectionIds InspectionIds
        {
            get { return _InspectionIds; }
            set
            {
                _InspectionIds = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scInspectionIds);
            }
        }

        private clsInspectionStatuses _InspectionStatuses = null;
        public clsInspectionStatuses InspectionStatuses
        {
            get { return _InspectionStatuses; }
            set
            {
                _InspectionStatuses = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scInspectionStatuses);
            }
        }

        private clsInspectionTypeIds _InspectionTypeIds = null;
        public clsInspectionTypeIds InspectionTypeIds
        {
            get { return _InspectionTypeIds; }
            set
            {
                _InspectionTypeIds = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scInspectionTypeIds);
            }
        }

        private clsInspectionTypes _InspectionTypes = null;
        public clsInspectionTypes InspectionTypes
        {
            get { return _InspectionTypes; }
            set
            {
                _InspectionTypes = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scInspectionTypes);
            }
        }

        private clsInspectorIds _InspectorIds = null;
        public clsInspectorIds InspectorIds
        {
            get { return _InspectorIds; }
            set
            {
                _InspectorIds = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scInspectorIds);
            }
        }

        private clsLicenses _Licenses = null;
        public clsLicenses Licenses
        {
            get { return _Licenses; }
            set
            {
                _Licenses = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scLicenses);
            }
        }

        private clsParcelId _ParcelId = null;
        public clsParcelId ParcelId
        {
            get { return _ParcelId; }
            set
            {
                _ParcelId = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scParcelId);
            }
        }

        private clsParcelIds _ParcelIds = null;
        public clsParcelIds ParcelIds
        {
            get { return _ParcelIds; }
            set
            {
                _ParcelIds = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scParcelIds);
            }
        }

        private clsSpatialDescriptors _SpatialDescriptors = null;
        public clsSpatialDescriptors SpatialDescriptors
        {
            get { return _SpatialDescriptors; }
            set
            {
                _SpatialDescriptors = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scSpatialDescriptors);
            }
        }

        private clsStatuses _Statuses = null;
        public clsStatuses Statuses
        {
            get { return _Statuses; }
            set
            {
                _Statuses = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scStatuses);
            }
        }

        private clsDateRanges _approvalDateRanges = null;
        public clsDateRanges approvalDateRanges
        {
            get { return _approvalDateRanges; }
            set
            {
                _approvalDateRanges = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scApprovalDateRanges);
            }
        }

        private clsDateRanges _completionDateRanges = null;
        public clsDateRanges completionDateRanges
        {
            get { return _completionDateRanges; }
            set
            {
                _completionDateRanges = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scCompletionDateRanges);
            }
        }

        private clsDateRanges _creationDateRanges = null;
        public clsDateRanges creationDateRanges
        {
            get { return _creationDateRanges; }
            set
            {
                _creationDateRanges = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scCreationDateRanges);
            }
        }

        private clsDateRanges _disapprovalDateRanges = null;
        public clsDateRanges disapprovalDateRanges
        {
            get { return _disapprovalDateRanges; }
            set
            {
                _disapprovalDateRanges = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scDisapprovalDateRanges);
            }
        }

        private clsDateRanges _expirationDateRanges = null;
        public clsDateRanges expirationDateRanges
        {
            get { return _expirationDateRanges; }
            set
            {
                _expirationDateRanges = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scExpirationDateRanges);
            }
        }

        private clsRoles _inspectorRoles = null;
        public clsRoles inspectorRoles
        {
            get { return _inspectorRoles; }
            set
            {
                _inspectorRoles = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scInspectorRoles);
            }
        }

        private string _keyword = null;
        public string keyword
        {
            get { return _keyword; }
            set
            {
                _keyword = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scKeyword);
            }
        }

        private clsCAPId _parentCAPId = null;
        public clsCAPId parentCAPId
        {
            get { return _parentCAPId; }
            set
            {
                _parentCAPId = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scParentCAPId);
            }
        }

        private clsCAPIds _parentCAPIds = null;
        public clsCAPIds parentCAPIds
        {
            get { return _parentCAPIds; }
            set
            {
                _parentCAPIds = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scParentCAPIds);
            }
        }

        private clsCAPId _subsidiaryCAPId = null;
        public clsCAPId subsidiaryCAPId
        {
            get { return _subsidiaryCAPId; }
            set
            {
                _subsidiaryCAPId = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scSubsidiaryCAPId);
            }
        }

        private clsCAPIds _subsidiaryCAPIds = null;
        public clsCAPIds susidiaryCAPIds
        {
            get { return _subsidiaryCAPIds; }
            set
            {
                _subsidiaryCAPIds = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scSubsidiaryCAPIds);
            }
        }

        private capsSearchTypeEnum? _type = null;
        public capsSearchTypeEnum? type
        {
            get
            {
                if (_type.HasValue)
                {
                    return _type.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _type = value; }
        }
        public bool typeSpecified
        {
            get { return _type != null; }
        }

        private clsDepartments _Departments = null;
        public clsDepartments Departments
        {
            get { return _Departments; }
            set
            {
                _Departments = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scDepartments);
            }
        }

        private clsAssetIds _AssetIds = null;
        public clsAssetIds AssetIds
        {
            get { return _AssetIds; }
            set
            {
                _AssetIds = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scAssetIds);
            }
        }

        private uint? _MaxRecordsPerAssetId = null;
        public uint? MaxRecordsPerAssetId
        {
            get
            {
                if (_MaxRecordsPerAssetId.HasValue)
                {
                    return _MaxRecordsPerAssetId.Value;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _MaxRecordsPerAssetId = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scMaxRecordsPerAssetId);
            }
        }
        public bool MaxRecordsPerAssetIdSpecified
        {
            get { return _MaxRecordsPerAssetId != null; }
        }


        private bool? _ActivePermitsFlag = null;
        public bool? ActivePermitsFlag
        {
            get
            {
                if (_ActivePermitsFlag.HasValue)
                {
                    return _ActivePermitsFlag.Value;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _ActivePermitsFlag = value;
                ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect.scActivePermitsFlag);
            }
        }
        public bool ActivePermitsFlagSpecified
        {
            get { return _ActivePermitsFlag != null; }
        }
        // End choice
        // End group CAPsSearchCollectionSelect

        private bool? _useCachedCAPs = null;
        public bool? useCachedCAPs
        {
            get
            {
                if (_useCachedCAPs.HasValue)
                {
                    return _useCachedCAPs.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _useCachedCAPs = value; }
        }
        public bool useCachedCAPsSpecified
        {
            get { return _useCachedCAPs != null; }
        }

        private bool? _withOpenInspectionsOnly = null;
        public bool? withOpenInspectionsOnly
        {
            get
            {
                if (_withOpenInspectionsOnly.HasValue)
                {
                    return _withOpenInspectionsOnly.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _withOpenInspectionsOnly = value; }
        }
        public bool withOpenInspectionsOnlySpecified
        {
            get { return _withOpenInspectionsOnly != null; }
        }

        private bool? _withUnassignedInspectionsOnly = null;
        public bool? withUnassignedInspectionsOnly
        {
            get
            {
                if (_withUnassignedInspectionsOnly.HasValue)
                {
                    return _withUnassignedInspectionsOnly.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _withUnassignedInspectionsOnly = value; }
        }
        public bool withUnassignedInspectionsOnlySpecified
        {
            get { return _withUnassignedInspectionsOnly != null; }
        }

        private bool? _withOutstandingFeeDueOnly = null;
        public bool? withOutstandingFeeDueOnly
        {
            get
            {
                if (_withOutstandingFeeDueOnly.HasValue)
                {
                    return _withOutstandingFeeDueOnly.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _withOutstandingFeeDueOnly = value; }
        }
        public bool withOutstandingFeeDueOnlySpecified
        {
            get { return _withOutstandingFeeDueOnly != null; }
        }

        public clsDateRanges ScheduleDate { get; set; }

        // Constructors
        public msgGetCAPs()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceCAPsSearchCollectionSelect pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scCAPId)
            {
                _CAPId = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scCAPIds)
            {
                _CAPIds = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scCAPStatuses)
            {
                _CAPStatuses = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scCAPTypeIds)
            {
                _CAPTypeIds = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scContactIds)
            {
                _ContactIds = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scContacts)
            {
                _Contacts = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scDateRanges)
            {
                _DateRanges = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scDetailAddresses)
            {
                _DetailAddresses = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scGISObjectIds)
            {
                _GISObjectIds = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scGISObjects)
            {
                _GISObjects = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scInspectionDistricts)
            {
                _InspectionDistricts = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scInspectionIds)
            {
                _InspectionIds = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scInspectionStatuses)
            {
                _InspectionStatuses = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scInspectionTypeIds)
            {
                _InspectionTypeIds = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scInspectionTypes)
            {
                _InspectionTypes = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scInspectorIds)
            {
                _InspectorIds = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scLicenses)
            {
                _Licenses = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scParcelId)
            {
                _ParcelId = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scParcelIds)
            {
                _ParcelIds = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scSpatialDescriptors)
            {
                _SpatialDescriptors = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scStatuses)
            {
                _Statuses = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scApprovalDateRanges)
            {
                _approvalDateRanges = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scCompletionDateRanges)
            {
                _completionDateRanges = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scCreationDateRanges)
            {
                _creationDateRanges = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scDisapprovalDateRanges)
            {
                _disapprovalDateRanges = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scExpirationDateRanges)
            {
                _expirationDateRanges = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scInspectorRoles)
            {
                _inspectorRoles = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scKeyword)
            {
                _keyword = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scParentCAPId)
            {
                _parentCAPId = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scParentCAPIds)
            {
                _parentCAPIds = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scSubsidiaryCAPId)
            {
                _subsidiaryCAPId = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scSubsidiaryCAPIds)
            {
                _subsidiaryCAPIds = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scType)
            {
                _type = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scDepartments)
            {
                _Departments = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scAssetIds)
            {
                _AssetIds = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scMaxRecordsPerAssetId)
            {
                _MaxRecordsPerAssetId = null;
            }
            if (pSelectedChoice != eChoiceCAPsSearchCollectionSelect.scActivePermitsFlag)
            {
                _ActivePermitsFlag = null;
            }
        }
    }
}
