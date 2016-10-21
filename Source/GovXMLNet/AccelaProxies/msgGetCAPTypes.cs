// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="GetCAPTypes">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element name="returnElements" form="qualified" minOccurs="0">
						<xsd:complexType>
							<xsd:sequence maxOccurs="unbounded">
								<xsd:element name="returnElement" form="qualified">
									<xsd:complexType>
										<xsd:simpleContent>
											<xsd:extension base="capTypeDetailReturnEnum">
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
					<xsd:choice minOccurs="0" maxOccurs="unbounded">
						<xsd:group ref="CAPTypesSearchCollectionSelect"/>
					</xsd:choice>
					<xsd:element name="returnGroup" type="xsd:boolean" default="false" form="qualified" minOccurs="0"/>
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
    public class msgGetCAPTypes : clsOperationRequest
    {
        // Members
        public lctGetCAPTypesReturnElements returnElements { get; set; }

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

        // Begin group CAPTypesSearchCollectionSelect
        // Begin choice
        private clsInspectionType _InspectionType = null;
        public clsInspectionType InspectionType
        {
            get { return _InspectionType; }
            set
            {
                _InspectionType = value;
                ChoiceClearAllBut(eChoiceCAPTypesSearchCollectionSelect.scInspectionType);
            }
        }

        private capTypesSearchTypeEnum? _type = null;
        public capTypesSearchTypeEnum? type
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
            set 
            { 
                _type = value;
                ChoiceClearAllBut(eChoiceCAPTypesSearchCollectionSelect.scType);
            }
        }
        public bool typeSpecified
        {
            get { return _type != null; }
        }

        private int? _IVRCode = null;
        public int? IVRCode
        {
            get
            {
                if (_IVRCode.HasValue)
                {
                    return _IVRCode.Value;
                }
                else
                {
                    return null;
                }
            }
            set 
            { 
                _IVRCode = value;
                ChoiceClearAllBut(eChoiceCAPTypesSearchCollectionSelect.scIVRCode);
            }
        }
        public bool IVRCodeSpecified
        {
            get { return _IVRCode != null; }
        }
        // End choice
        // End group CAPTypesSearchCollectionSelect
        
        // Constructors
        public msgGetCAPTypes()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceCAPTypesSearchCollectionSelect pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceCAPTypesSearchCollectionSelect.scInspectionType)
            {
                _InspectionType = null;
            }
            if (pSelectedChoice != eChoiceCAPTypesSearchCollectionSelect.scType)
            {
                _type = null;
            }
            if (pSelectedChoice != eChoiceCAPTypesSearchCollectionSelect.scIVRCode)
            {
                _IVRCode = null;
            }
        }
    }
}
