// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="GetInspectionDistricts">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element name="collectionsLevelQueryLogic" type="queryLogicEnum" default="OR" form="qualified" minOccurs="0"/>
					<xsd:element name="collectionLevelQueryLogic" type="queryLogicEnum" default="OR" form="qualified" minOccurs="0"/>
					<xsd:choice minOccurs="0" maxOccurs="unbounded">
						<xsd:group ref="InspectionDistrictsSearchCollectionSelect"/>
					</xsd:choice>
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
    public class msgGetInspectionDistricts : clsOperationRequest
    {
        // Members
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

        // Begin group InspectionDistrictsSearchCollectionSelect
        // Begin choice
        private clsCAPIds _CAPIds = null;
        public clsCAPIds CAPIds
                    {
                        get { return _CAPIds; }
            set
            {
                _CAPIds = value;
                ChoiceClearAllBut(eChoiceInspectionDistrictsSearchCollectionSelect.scCAPIds);
            }
        }

        private clsCAPTypeIds _CAPTypeIds = null;
        public clsCAPTypeIds CAPTypeIds
        {
            get { return _CAPTypeIds; }
            set
            {
                _CAPTypeIds = value;
                ChoiceClearAllBut(eChoiceInspectionDistrictsSearchCollectionSelect.scCAPTypeIds);
            }
        }

        private clsCompactAddressIds _CompactAddressIds = null;
        public clsCompactAddressIds CompactAddressIds
        {
            get { return _CompactAddressIds; }
            set
            {
                _CompactAddressIds = value;
                ChoiceClearAllBut(eChoiceInspectionDistrictsSearchCollectionSelect.scCompactAddressIds);
            }
        }

        private clsDetailAddresses _DetailAddresses = null;
        public clsDetailAddresses DetailAddresses
        {
            get { return _DetailAddresses; }
            set
            {
                _DetailAddresses = value;
                ChoiceClearAllBut(eChoiceInspectionDistrictsSearchCollectionSelect.scDetailAddresses);
            }
        }

        private clsInspectionIds _InspectionIds = null;
        public clsInspectionIds InspectionIds
        {
            get { return _InspectionIds; }
            set
            {
                _InspectionIds = value;
                ChoiceClearAllBut(eChoiceInspectionDistrictsSearchCollectionSelect.scInspectionIds);
            }
        }

        private clsInspectionTypes _InspectionTypes = null;
        public clsInspectionTypes InspectionTypes
        {
            get { return _InspectionTypes; }
            set
            {
                _InspectionTypes = value;
                ChoiceClearAllBut(eChoiceInspectionDistrictsSearchCollectionSelect.scInspectionTypes);
            }
        }

        private clsParcelIds _ParcelIds = null;
        public clsParcelIds ParcelIds
        {
            get { return _ParcelIds; }
            set
            {
                _ParcelIds = value;
                ChoiceClearAllBut(eChoiceInspectionDistrictsSearchCollectionSelect.scParcelIds);
            }
        }
        // End choice
        // End group InspectionDistrictsSearchCollectionSelect

        // Constructors
        public msgGetInspectionDistricts()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceInspectionDistrictsSearchCollectionSelect pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceInspectionDistrictsSearchCollectionSelect.scCAPIds)
            {
                _CAPIds = null;
            }
            if (pSelectedChoice != eChoiceInspectionDistrictsSearchCollectionSelect.scCAPTypeIds)
            {
                _CAPTypeIds = null;
            }
            if (pSelectedChoice != eChoiceInspectionDistrictsSearchCollectionSelect.scCompactAddressIds)
            {
                _CompactAddressIds = null;
            }
            if (pSelectedChoice != eChoiceInspectionDistrictsSearchCollectionSelect.scDetailAddresses)
            {
                _DetailAddresses = null;
            }
            if (pSelectedChoice != eChoiceInspectionDistrictsSearchCollectionSelect.scInspectionIds)
            {
                _InspectionIds = null;
            }
            if (pSelectedChoice != eChoiceInspectionDistrictsSearchCollectionSelect.scInspectionTypes)
            {
                _InspectionTypes = null;
            }
            if (pSelectedChoice != eChoiceInspectionDistrictsSearchCollectionSelect.scParcelIds)
            {
                _ParcelIds = null;
            }
        }
    }
}
