// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="GetConditionTypes">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element name="returnElements" form="qualified" minOccurs="0">
						<xsd:complexType>
							<xsd:sequence maxOccurs="unbounded">
								<xsd:element name="returnElement" form="qualified">
									<xsd:complexType>
										<xsd:simpleContent>
											<xsd:extension base="conditionTypeReturnEnum">
												<xsd:attribute name="detailLevels" type="xsd:nonNegativeInteger" use="optional"/>
											</xsd:extension>
										</xsd:simpleContent>
									</xsd:complexType>
								</xsd:element>
							</xsd:sequence>
						</xsd:complexType>
					</xsd:element>
					<xsd:element name="contextType" type="getHoldTypesContextTypeEnum" form="qualified" minOccurs="0"/>
					<xsd:element name="collectionsLevelQueryLogic" type="queryLogicEnum" default="OR" form="qualified" minOccurs="0"/>
					<xsd:element name="collectionLevelQueryLogic" type="queryLogicEnum" default="OR" form="qualified" minOccurs="0"/>
					<xsd:choice minOccurs="0" maxOccurs="unbounded">
						<xsd:group ref="ConditionsSearchCollectionSelect"/>
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
    public class msgGetConditionTypes : clsOperationRequest
    {
        // Members
        public lctGetCAPTypesReturnElements returnElements { get; set; }

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

        // Begin group ConditionsSearchCollectionSelect
        // Begin choice
        
        private clsCAPIds _CAPIds = null;
        public clsCAPIds CAPIds
        {
            get { return _CAPIds; }
            set
            {
                _CAPIds = value;
                ChoiceClearAllBut(eChoiceConditionsSearchCollectionSelect.scCAPIds);
            }
        }
        
        private clsCAPTypeIds _CAPTypeIds = null;
        public clsCAPTypeIds CAPTypeIds
        {
            get { return _CAPTypeIds; }
            set
            {
                _CAPTypeIds = value;
                ChoiceClearAllBut(eChoiceConditionsSearchCollectionSelect.scCAPTypeIds);
            }
        }
        
        private clsDateRanges _DateRanges = null;
        public clsDateRanges DateRanges
        {
            get { return _DateRanges; }
            set
            {
                _DateRanges = value;
                ChoiceClearAllBut(eChoiceConditionsSearchCollectionSelect.scDateRanges);
            }
        }
        
        private clsInspectionIds _InspectionIds = null;
        public clsInspectionIds InspectionIds
        {
            get { return _InspectionIds; }
            set
            {
                _InspectionIds = value;
                ChoiceClearAllBut(eChoiceConditionsSearchCollectionSelect.scInspectionIds);
            }
        }

        private clsInspectionTypes _InspectionTypes = null;
        public clsInspectionTypes InspectionTypes
        {
            get { return _InspectionTypes; }
            set
            {
                _InspectionTypes = value;
                ChoiceClearAllBut(eChoiceConditionsSearchCollectionSelect.scInspectionTypes);
            }
        }
        // End choice
        // End group ConditionsSearchCollectionSelect
        
        // Constructors
        public msgGetConditionTypes()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceConditionsSearchCollectionSelect pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceConditionsSearchCollectionSelect.scCAPIds)
            {
                _CAPIds = null;
            }
            if (pSelectedChoice != eChoiceConditionsSearchCollectionSelect.scCAPTypeIds)
            {
                _CAPTypeIds = null;
            }
            if (pSelectedChoice != eChoiceConditionsSearchCollectionSelect.scDateRanges)
            {
                _DateRanges = null;
            }
            if (pSelectedChoice != eChoiceConditionsSearchCollectionSelect.scInspectionIds)
            {
                _InspectionIds = null;
            }
            if (pSelectedChoice != eChoiceConditionsSearchCollectionSelect.scInspectionTypes)
            {
                _InspectionTypes = null;
            }
        }
    }
}
