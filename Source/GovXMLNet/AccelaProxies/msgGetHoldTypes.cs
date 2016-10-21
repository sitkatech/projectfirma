// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="GetHoldTypes">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element name="contextType" type="getHoldTypesContextTypeEnum" form="qualified" minOccurs="0"/>
					<xsd:element name="collectionsLevelQueryLogic" type="queryLogicEnum" default="OR" form="qualified" minOccurs="0"/>
					<xsd:element name="collectionLevelQueryLogic" type="queryLogicEnum" default="OR" form="qualified" minOccurs="0"/>
					<xsd:choice minOccurs="0" maxOccurs="unbounded">
						<xsd:group ref="HoldsSearchCollectionSelect"/>
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
    public class msgGetHoldTypes : clsOperationRequest
    {
        private getHoldTypesContextTypeEnum? _contextType = null;
        public getHoldTypesContextTypeEnum? contextType
        {
            get
            {
                if (_contextType.HasValue)
                {
                    return _contextType.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _contextType = value; }
        }
        public bool contextTypeSpecified
        {
            get { return _contextType != null; }
        }

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

        // Begin group HoldsSearchCollectionSelect
        // Begin choice
        private clsCAPIds _CAPIds = null;
        public clsCAPIds CAPIds
        {
            get { return _CAPIds; }
            set
            {
                _CAPIds = value;
                ChoiceClearAllBut(eChoiceHoldsSearchCollectionSelect.scCAPIds);
            }
        }

        private clsCAPTypeIds _CAPTypeIds = null;
        public clsCAPTypeIds CAPTypeIds
        {
            get { return _CAPTypeIds; }
            set
            {
                _CAPTypeIds = value;
                ChoiceClearAllBut(eChoiceHoldsSearchCollectionSelect.scCAPTypeIds);
            }
        }

        private clsCompactAddressIds _CompactAddressIds = null;
        public clsCompactAddressIds CompactAddressIds
        {
            get { return _CompactAddressIds; }
            set
            {
                _CompactAddressIds = value;
                ChoiceClearAllBut(eChoiceHoldsSearchCollectionSelect.scCompactAddressIds);
            }
        }

        private clsContacts _Contacts = null;
        public clsContacts Contacts
        {
            get { return _Contacts; }
            set
            {
                _Contacts = value;
                ChoiceClearAllBut(eChoiceHoldsSearchCollectionSelect.scContacts);
            }
        }

        private clsContactIds _ContactIds = null;
        public clsContactIds ContactIds
        {
            get { return _ContactIds; }
            set
            {
                _ContactIds = value;
                ChoiceClearAllBut(eChoiceHoldsSearchCollectionSelect.scContactIds);
            }
        }

        private clsDateRanges _DateRanges = null;
        public clsDateRanges DateRanges
        {
            get { return _DateRanges; }
            set
            {
                _DateRanges = value;
                ChoiceClearAllBut(eChoiceHoldsSearchCollectionSelect.scDateRanges);
            }
        }

        private clsDetailAddresses _DetailAddresses = null;
        public clsDetailAddresses DetailAddresses
        {
            get { return _DetailAddresses; }
            set
            {
                _DetailAddresses = value;
                ChoiceClearAllBut(eChoiceHoldsSearchCollectionSelect.scDetailAddresses);
            }
        }

        private clsLicenses _Licenses = null;
        public clsLicenses Licenses
        {
            get { return _Licenses; }
            set
            {
                _Licenses = value;
                ChoiceClearAllBut(eChoiceHoldsSearchCollectionSelect.scLicenses);
            }
        }

        private clsParcelIds _ParcelIds = null;
        public clsParcelIds ParcelIds
        {
            get { return _ParcelIds; }
            set
            {
                _ParcelIds = value;
                ChoiceClearAllBut(eChoiceHoldsSearchCollectionSelect.scParcelIds);
            }
        }
        // End Choice
        // End group HoldsSearchCollectionSelect

        // Constructors
        public msgGetHoldTypes()
        {
        }

        
        // Methods
        private void ChoiceClearAllBut(eChoiceHoldsSearchCollectionSelect pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceHoldsSearchCollectionSelect.scCAPIds)
            {
                _CAPIds = null;
            }
            if (pSelectedChoice != eChoiceHoldsSearchCollectionSelect.scCAPTypeIds)
            {
                _CAPTypeIds = null;
            }
            if (pSelectedChoice != eChoiceHoldsSearchCollectionSelect.scCompactAddressIds)
            {
                _CompactAddressIds = null;
            }
            if (pSelectedChoice != eChoiceHoldsSearchCollectionSelect.scContacts)
            {
                _Contacts = null;
            }
            if (pSelectedChoice != eChoiceHoldsSearchCollectionSelect.scContactIds)
            {
                _ContactIds = null;
            }
            if (pSelectedChoice != eChoiceHoldsSearchCollectionSelect.scDateRanges)
            {
                _DateRanges = null;
            }
            if (pSelectedChoice != eChoiceHoldsSearchCollectionSelect.scDetailAddresses)
            {
                _DetailAddresses = null;
            }
            if (pSelectedChoice != eChoiceHoldsSearchCollectionSelect.scLicenses)
            {
                _Licenses = null;
            }
            if (pSelectedChoice != eChoiceHoldsSearchCollectionSelect.scParcelIds)
            {
                _ParcelIds = null;
            }
        }

    }
}
