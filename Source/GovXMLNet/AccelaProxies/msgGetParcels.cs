// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
  <xsd:complexType name="GetParcels">
    <xsd:complexContent>
      <xsd:extension base="OperationRequest">
        <xsd:sequence>
          <xsd:element name="returnElements" form="qualified" minOccurs="0">
            <xsd:complexType>
              <xsd:sequence maxOccurs="unbounded">
                <xsd:element name="returnElement" form="qualified">
                  <xsd:complexType>
                    <xsd:simpleContent>
                      <xsd:extension base="parcelDetailReturnEnum">
                        <xsd:attribute name="detailLevels" type="xsd:nonNegativeInteger" use="optional"/>
                      </xsd:extension>
                    </xsd:simpleContent>
                  </xsd:complexType>
                </xsd:element>
              </xsd:sequence>
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="collectionsLevelQueryLogic" type="queryLogicEnum" default="OR" form="qualified" minOccurs="0"/>
          <xsd:element name="collectionLevelQueryLogic" type="queryLogicEnum" default="OR" form="qualified" minOccurs="0"/>
          <xsd:choice maxOccurs="unbounded">
            <xsd:group ref="ParcelSearchCollectionSelect"/>
          </xsd:choice>
          <xsd:element name="withOpenInspectionsOnly" type="xsd:boolean" default="false" form="qualified" minOccurs="0"/>
          <xsd:element name="withUnassignedInspectionsOnly" type="xsd:boolean" default="false" form="qualified" minOccurs="0"/>
          <xsd:element name="returnDisabledParcels" type="xsd:boolean" default="false" form="qualified" minOccurs="0"/>
          <xsd:element name="returnRefParcels" type="xsd:boolean" default="false" form="qualified" minOccurs="0"/>
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
    public class msgGetParcels : clsOperationRequest
    {
        // Members
        public lctGetParcelsReturnElements returnElements { get; set; }

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

        // Begin Group ParcelSearchCollectionSelect
        // Begin choice
        private clsCAPIds _CAPIds = null;
        public clsCAPIds CAPIds
        {
            get { return _CAPIds; }
            set
            {
                _CAPIds = value;
                ChoiceClearAllBut(eChoiceParcelSearchCollectionSelect.scCAPIds);
            }
        }

        private clsCAPStatuses _CAPStatuses = null;
        public clsCAPStatuses CAPStatuses
        {
            get { return _CAPStatuses; }
            set
            {
                _CAPStatuses = value;
                ChoiceClearAllBut(eChoiceParcelSearchCollectionSelect.scCAPStatuses);
            }
        }

        private clsContact _Contact = null;
        public clsContact Contact
        {
            get { return _Contact; }
            set
            {
                _Contact = value;
                ChoiceClearAllBut(eChoiceParcelSearchCollectionSelect.scContact);
            }
        }

        private clsDateRanges _DateRanges = null;
        public clsDateRanges DateRanges
        {
            get { return _DateRanges; }
            set
            {
                _DateRanges = value;
                ChoiceClearAllBut(eChoiceParcelSearchCollectionSelect.scDateRanges);
            }
        }

        private clsDetailAddresses _DetailAddresses = null;
        public clsDetailAddresses DetailAddresses
        {
            get { return _DetailAddresses; }
            set
            {
                _DetailAddresses = value;
                ChoiceClearAllBut(eChoiceParcelSearchCollectionSelect.scDetailAddresses);
            }
        }

        private clsGISObjects _GISObjects = null;
        public clsGISObjects GISObjects
        {
            get { return _GISObjects; }
            set
            {
                _GISObjects = value;
                ChoiceClearAllBut(eChoiceParcelSearchCollectionSelect.scGISObjects);
            }
        }

        private clsParcelIds _ParcelIds = null;
        public clsParcelIds ParcelIds
        {
            get { return _ParcelIds; }
            set
            {
                _ParcelIds = value;
                ChoiceClearAllBut(eChoiceParcelSearchCollectionSelect.scParcelIds);
            }
        }

        private clsSpatialDescriptors _SpatialDescriptors = null;
        public clsSpatialDescriptors SpatialDescriptors
        {
            get { return _SpatialDescriptors; }
            set
            {
                _SpatialDescriptors = value;
                ChoiceClearAllBut(eChoiceParcelSearchCollectionSelect.scSpatialDescriptors);
            }
        }

        // End choice
        // End Group ParcelSearchCollectionSelect
        private bool? _withOpenInspectionsOnly = false;
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

        private bool? _withUnassignedInspectionsOnly = false;
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

        private bool? _returnDisabledParcels = false;
        public bool? returnDisabledParcels
        {
            get
            {
                if (_returnDisabledParcels.HasValue)
                {
                    return _returnDisabledParcels.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _returnDisabledParcels = value; }
        }
        public bool returnDisabledParcelsSpecified
        {
            get { return _returnDisabledParcels != null; }
        }

        private bool? _returnRefParcels = false;
        public bool? returnRefParcels
        {
            get
            {
                if (_returnRefParcels.HasValue)
                {
                    return _returnRefParcels.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _returnRefParcels = value; }
        }
        public bool returnRefParcelsSpecified
        {
            get { return _returnRefParcels != null; }
        }

        // Constructors
        public msgGetParcels()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceParcelSearchCollectionSelect pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceParcelSearchCollectionSelect.scCAPIds)
            {
                _CAPIds = null;
            }
            if (pSelectedChoice != eChoiceParcelSearchCollectionSelect.scCAPStatuses)
            {
                _CAPStatuses = null;
            }
            if (pSelectedChoice != eChoiceParcelSearchCollectionSelect.scContact)
            {
                _Contact = null;
            }
            if (pSelectedChoice != eChoiceParcelSearchCollectionSelect.scDateRanges)
            {
                _DateRanges = null;
            }
            if (pSelectedChoice != eChoiceParcelSearchCollectionSelect.scDetailAddresses)
            {
                _DetailAddresses = null;
            }
            if (pSelectedChoice != eChoiceParcelSearchCollectionSelect.scGISObjects)
            {
                _GISObjects = null;
            }
            if (pSelectedChoice != eChoiceParcelSearchCollectionSelect.scParcelIds)
            {
                _ParcelIds = null;
            }
            if (pSelectedChoice != eChoiceParcelSearchCollectionSelect.scSpatialDescriptors)
            {
                _SpatialDescriptors = null;
            }
        }
    }
}
