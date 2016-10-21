// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="GetAddresses">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element name="returnElements" form="qualified" minOccurs="0">
						<xsd:complexType>
							<xsd:sequence maxOccurs="unbounded">
								<xsd:element name="returnElement" form="qualified">
									<xsd:complexType>
										<xsd:simpleContent>
											<xsd:extension base="addressDetailReturnEnum">
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
						<xsd:group ref="AddressSearchCollectionSelect"/>
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
    public class msgGetAddresses : clsOperationRequest
    {
        public lctGetAddressesReturnElements returnElements { get; set; }

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

        // Start group AddressSearchCollectionSelect
        // Start choice
        private clsCAPId _CAPId = null;
        public clsCAPId CAPId
        {
            get { return _CAPId; }
            set
            {
                _CAPId = value;
                ChoiceClearAllBut(eChoiceAddressSearchCollectionSelect.scCAPId);
            }
        }

        private clsCAPTypeId _CAPTypeId = null;
        public clsCAPTypeId CAPTypeId
        {
            get { return _CAPTypeId; }
            set
            {
                _CAPTypeId = value;
                ChoiceClearAllBut(eChoiceAddressSearchCollectionSelect.scCAPTypeId);
            }
        }

        private clsDateRange _DateRange = null;
        public clsDateRange DateRange
        {
            get { return _DateRange; }
            set
            {
                _DateRange = value;
                ChoiceClearAllBut(eChoiceAddressSearchCollectionSelect.scDateRange);
            }
        }

        private clsDetailAddress _DetailAddress = null;
        public clsDetailAddress DetailAddress
        {
            get { return _DetailAddress; }
            set
            {
                _DetailAddress = value;
                ChoiceClearAllBut(eChoiceAddressSearchCollectionSelect.scDetailAddress);
            }
        }

        private clsParcelId _ParcelId = null;
        public clsParcelId ParcelId
        {
            get { return _ParcelId; }
            set
            {
                _ParcelId = value;
                ChoiceClearAllBut(eChoiceAddressSearchCollectionSelect.scParcelId);
            }
        }

        private clsCAPIds _CAPIds = null;
        public clsCAPIds CAPIds
        {
            get { return _CAPIds; }
            set
            {
                _CAPIds = value;
                ChoiceClearAllBut(eChoiceAddressSearchCollectionSelect.scCAPIds);
            }
        }

        private clsCAPStatuses _CAPStatuses = null;
        public clsCAPStatuses CAPStatuses
        {
            get { return _CAPStatuses; }
            set
            {
                _CAPStatuses = value;
                ChoiceClearAllBut(eChoiceAddressSearchCollectionSelect.scCAPStatuses);
            }
        }

        private clsCAPTypeIds _CAPTypeIds = null;
        public clsCAPTypeIds CAPTypeIds
        {
            get { return _CAPTypeIds; }
            set
            {
                _CAPTypeIds = value;
                ChoiceClearAllBut(eChoiceAddressSearchCollectionSelect.scCAPTypeIds);
            }
        }

        private clsDateRanges _DateRanges = null;
        public clsDateRanges DateRanges
        {
            get { return _DateRanges; }
            set
            {
                _DateRanges = value;
                ChoiceClearAllBut(eChoiceAddressSearchCollectionSelect.scDateRanges);
            }
        }

        private clsParcelIds _ParcelIds = null;
        public clsParcelIds ParcelIds
        {
            get { return _ParcelIds; }
            set
            {
                _ParcelIds = value;
                ChoiceClearAllBut(eChoiceAddressSearchCollectionSelect.scParcelIds);
            }
        }
        // End Choice
        // End group AddressSearchCollectionSelect


        public msgGetAddresses()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceAddressSearchCollectionSelect pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceAddressSearchCollectionSelect.scCAPId)
            {
                _CAPId = null;
            }
            if (pSelectedChoice != eChoiceAddressSearchCollectionSelect.scCAPTypeId)
            {
                _CAPTypeId = null;
            }
            if (pSelectedChoice != eChoiceAddressSearchCollectionSelect.scDateRange)
            {
                _DateRange = null;
            }
            if (pSelectedChoice != eChoiceAddressSearchCollectionSelect.scDetailAddress)
            {
                _DetailAddress = null;
            }
            if (pSelectedChoice != eChoiceAddressSearchCollectionSelect.scParcelId)
            {
                _ParcelId = null;
            }
            if (pSelectedChoice != eChoiceAddressSearchCollectionSelect.scCAPIds)
            {
                _CAPTypeIds = null;
            }
            if (pSelectedChoice != eChoiceAddressSearchCollectionSelect.scCAPStatuses)
            {
                _CAPStatuses = null;
            }
            if (pSelectedChoice != eChoiceAddressSearchCollectionSelect.scCAPTypeIds)
            {
                _CAPTypeIds = null;
            }
            if (pSelectedChoice != eChoiceAddressSearchCollectionSelect.scDateRanges)
            {
                _DateRanges = null;
            }
            if (pSelectedChoice != eChoiceAddressSearchCollectionSelect.scParcelIds)
            {
                _ParcelIds = null;
            }
        }
    }
}
