// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
  <xsd:complexType name="GetInspections">
    <xsd:complexContent>
      <xsd:extension base="OperationRequest">
        <xsd:sequence>
          <xsd:element name="returnElements" form="qualified" minOccurs="0">
            <xsd:complexType>
              <xsd:sequence maxOccurs="unbounded">
                <xsd:element name="returnElement" form="qualified">
                  <xsd:complexType>
                    <xsd:simpleContent>
                      <xsd:extension base="inspectionDetailReturnEnum">
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
            <xsd:group ref="InspectionSearchCollectionSelect"/>
          </xsd:choice>
          <xsd:element name="openInspectionsOnly" type="xsd:boolean" default="false" form="qualified" minOccurs="0"/>
          <xsd:element name="useCachedCAPs" type="xsd:boolean" default="false" form="qualified" minOccurs="0"/>
          <xsd:element name="downloadRouteSheetOnly" type="xsd:boolean" default="false" form="qualified" minOccurs="0"/>
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
    public class msgGetInspections : clsOperationRequest
    {
        // Members
        public lctGetInspectionsReturnElements returnElements { get; set; }

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


        // Begin group InspectionSearchCollectionSelect
        // Begin choice
        private clsCAPIds _CAPIds = null;
        public clsCAPIds CAPIds
        {
            get { return _CAPIds; }
            set
            {
                _CAPIds = value;
                ChoiceClearAllBut(eChoiceInspectionSearchCollectionSelect.scCAPIds);
            }
        }

        private clsCAPTypeIds _CAPTypeIds = null;
        public clsCAPTypeIds CAPTypeIds
        {
            get { return _CAPTypeIds; }
            set
            {
                _CAPTypeIds = value;
                ChoiceClearAllBut(eChoiceInspectionSearchCollectionSelect.scCAPTypeIds);
            }
        }

        private clsConfirmationNumbers _ConfirmationNumbers = null;
        public clsConfirmationNumbers ConfirmationNumbers
        {
            get { return _ConfirmationNumbers; }
            set
            {
                _ConfirmationNumbers = value;
                ChoiceClearAllBut(eChoiceInspectionSearchCollectionSelect.scConfirmationNumbers);
            }
        }

        private clsContact _Contact = null;
        public clsContact Contact
        {
            get { return _Contact; }
            set
            {
                _Contact = value;
                ChoiceClearAllBut(eChoiceInspectionSearchCollectionSelect.scContact);
            }
        }

        private clsDateRanges _DateRanges = null;  // Note this is supposed to reference rec_date
        public clsDateRanges DateRanges
        {
            get { return _DateRanges; }
            set
            {
                _DateRanges = value;
                ChoiceClearAllBut(eChoiceInspectionSearchCollectionSelect.scDateRanges);
            }
        }

        private clsType _Type = null;
        public clsType Type
        {
            get { return _Type; }
            set
            {
                _Type = value;
                ChoiceClearAllBut(eChoiceInspectionSearchCollectionSelect.scType);
            }
        }

        private clsDepartment _Department = null;
        public clsDepartment Deaprtment
        {
            get { return _Department; }
            set
            {
                _Department = value;
                ChoiceClearAllBut(eChoiceInspectionSearchCollectionSelect.scDepartment);
            }
        }

        private clsDetailAddresses _DetailAddresses = null;
        public clsDetailAddresses DetailAddresses
        {
            get { return _DetailAddresses; }
            set
            {
                _DetailAddresses = value;
                ChoiceClearAllBut(eChoiceInspectionSearchCollectionSelect.scDetailAddresses);
            }
        }

        private clsInspectionDistrictIds _InspectionDistrictIds = null;
        public clsInspectionDistrictIds InspectionDistrictIds
        {
            get { return _InspectionDistrictIds; }
            set
            {
                _InspectionDistrictIds = value;
                ChoiceClearAllBut(eChoiceInspectionSearchCollectionSelect.scInspectionDistrictIds);
            }
        }

        private clsInspectionStatuses _InspectionStatuses = null;
        public clsInspectionStatuses InspectionStatuses
        {
            get { return _InspectionStatuses; }
            set
            {
                _InspectionStatuses = value;
                ChoiceClearAllBut(eChoiceInspectionSearchCollectionSelect.scInspectionStatuses);
            }
        }

        private clsInspectionTypeIds _InspectionTypeIds = null;
        public clsInspectionTypeIds InspectionTypeIds
        {
            get { return _InspectionTypeIds; }
            set
            {
                _InspectionTypeIds = value;
                ChoiceClearAllBut(eChoiceInspectionSearchCollectionSelect.scInspectionTypeIds);
            }
        }

        private clsInspectionTypes _InspectionTypes = null;
        public clsInspectionTypes InspectionTypes
        {
            get { return _InspectionTypes; }
            set
            {
                _InspectionTypes = value;
                ChoiceClearAllBut(eChoiceInspectionSearchCollectionSelect.scInspectionTypes);
            }
        }

        private clsInspectorIds _InspectorIds = null;
        public clsInspectorIds InspectorIds
        {
            get { return _InspectorIds; }
            set
            {
                _InspectorIds = value;
                ChoiceClearAllBut(eChoiceInspectionSearchCollectionSelect.scInspectorIds);
            }
        }

        private clsMapReference _MapReference = null;
        public clsMapReference MapReference
        {
            get { return _MapReference; }
            set
            {
                _MapReference = value;
                ChoiceClearAllBut(eChoiceInspectionSearchCollectionSelect.scMapReference);
            }
        }

        private clsParcelId _ParcelId = null;
        public clsParcelId ParcelId
        {
            get { return _ParcelId; }
            set
            {
                _ParcelId = value;
                ChoiceClearAllBut(eChoiceInspectionSearchCollectionSelect.scParcelId);
            }
        }

        private clsDateRanges _completionDateRanges = null;
        public clsDateRanges completionDateRanges
        {
            get { return _completionDateRanges; }
            set
            {
                _completionDateRanges = value;
                ChoiceClearAllBut(eChoiceInspectionSearchCollectionSelect.scCompletionDateRanges);
            }
        }

        private clsDateRanges _scheduledDateRanges = null;
        public clsDateRanges scheduledDateRanges
        {
            get { return _scheduledDateRanges; }
            set
            {
                _scheduledDateRanges = value;
                ChoiceClearAllBut(eChoiceInspectionSearchCollectionSelect.scScheduledDateRanges);
            }
        }
        // End choice
        // End group InspectionSearchCollectionSelect

        private bool? _openInspectionsOnly = null;
        public bool? openInspectionsOnly
        {
            get
            {
                if (_openInspectionsOnly.HasValue)
                {
                    return _openInspectionsOnly.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _openInspectionsOnly = value; }
        }
        public bool openInspectionsOnlySpecified
        {
            get { return _openInspectionsOnly != null; }
        }

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

        private bool? _downloadRouteSheetOnly = null;
        public bool? downloadRouteSheetOnly
        {
            get
            {
                if (_downloadRouteSheetOnly.HasValue)
                {
                    return _downloadRouteSheetOnly.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _downloadRouteSheetOnly = value; }
        }
        public bool downloadRouteSheetOnlySpecified
        {
            get { return _downloadRouteSheetOnly != null; }
        }

        // Constructors
        public msgGetInspections()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceInspectionSearchCollectionSelect pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceInspectionSearchCollectionSelect.scCAPIds)
            {
                _CAPIds = null;
            }
            if (pSelectedChoice != eChoiceInspectionSearchCollectionSelect.scCAPTypeIds)
            {
                _CAPTypeIds = null;
            }
            if (pSelectedChoice != eChoiceInspectionSearchCollectionSelect.scConfirmationNumbers)
            {
                _ConfirmationNumbers = null;
            }
            if (pSelectedChoice != eChoiceInspectionSearchCollectionSelect.scContact)
            {
                _Contact = null;
            }
            if (pSelectedChoice != eChoiceInspectionSearchCollectionSelect.scDateRanges) 
            {
                _DateRanges = null;
            }
            if (pSelectedChoice != eChoiceInspectionSearchCollectionSelect.scType)
            {
                _Type = null;
            }
            if (pSelectedChoice != eChoiceInspectionSearchCollectionSelect.scDepartment)
            {
                _Department = null;
            }
            if (pSelectedChoice != eChoiceInspectionSearchCollectionSelect.scDetailAddresses)
            {
                _DetailAddresses = null;
            }
            if (pSelectedChoice != eChoiceInspectionSearchCollectionSelect.scInspectionDistrictIds)
            {
                _InspectionDistrictIds = null;
            }
            if (pSelectedChoice != eChoiceInspectionSearchCollectionSelect.scInspectionStatuses)
            {
                _InspectionStatuses = null;
            }
            if (pSelectedChoice != eChoiceInspectionSearchCollectionSelect.scInspectionTypeIds)
            {
                _InspectionTypeIds = null;
            }
            if (pSelectedChoice != eChoiceInspectionSearchCollectionSelect.scInspectionTypes)
            {
                _InspectionTypes = null;
            }
            if (pSelectedChoice != eChoiceInspectionSearchCollectionSelect.scInspectorIds)
            {
                _InspectorIds = null;
            }
            if (pSelectedChoice != eChoiceInspectionSearchCollectionSelect.scMapReference)
            {
                _MapReference = null;
            }
            if (pSelectedChoice != eChoiceInspectionSearchCollectionSelect.scParcelId)
            {
                _ParcelId = null;
            }
            if (pSelectedChoice != eChoiceInspectionSearchCollectionSelect.scCompletionDateRanges)
            {
                _completionDateRanges = null;
            }
            if (pSelectedChoice != eChoiceInspectionSearchCollectionSelect.scScheduledDateRanges)
            {
                _scheduledDateRanges = null;
            }
        }
    }
}
