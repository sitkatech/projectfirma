// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="GetInspectionTypes">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element name="returnElements" form="qualified" minOccurs="0">
						<xsd:complexType>
							<xsd:sequence maxOccurs="unbounded">
								<xsd:element name="returnElement" form="qualified">
									<xsd:complexType>
										<xsd:simpleContent>
											<xsd:extension base="inspectionTypeDetailReturnEnum">
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
					<xsd:choice minOccurs="0" maxOccurs="unbounded">
						<xsd:group ref="InspectionTypeSearchCollectionSelect"/>
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
    public class msgGetInspectionTypes : clsOperationRequest
    {
        // Members
        public lctGetInspectionTypesReturnElements returnElements { get; set; }

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

        // Begin group InspectionTypeSearchCollectionSelect
        // Begin choice
        private clsCAPId _CAPId = null;
        public clsCAPId CAPId
        {
            get { return _CAPId; }
            set
            {
                _CAPId = value;
                ChoiceClearAllBut(eChoiceInspectionTypeSearchCollectionSelect.scCAPId);
            }
        }

        private clsCAPTypeId _CAPTypeId = null;
        public clsCAPTypeId CAPTypeId
        {
            get { return _CAPTypeId; }
            set
            {
                _CAPTypeId = value;
                ChoiceClearAllBut(eChoiceInspectionTypeSearchCollectionSelect.scCAPTypeId);
            }
        }

        private clsInspectorId _InspectorId = null;
        public clsInspectorId InspectorId
        {
            get { return _InspectorId; }
            set
            {
                _InspectorId = value;
                ChoiceClearAllBut(eChoiceInspectionTypeSearchCollectionSelect.scInspectorId);
            }
        }

        private lctGetInspectionTypesGetByCode _GetByCode = null;
        public lctGetInspectionTypesGetByCode GetByCode
        {
            get { return _GetByCode; }
            set
            {
                _GetByCode = value;
                ChoiceClearAllBut(eChoiceInspectionTypeSearchCollectionSelect.scGetByCode);
            }
        }
        // End choice
        // End group InspectionTypeSearchCollectionSelect

        // Constructors
        public msgGetInspectionTypes()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceInspectionTypeSearchCollectionSelect pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceInspectionTypeSearchCollectionSelect.scCAPId)
            {
                _CAPId = null;
            }
            if (pSelectedChoice != eChoiceInspectionTypeSearchCollectionSelect.scCAPTypeId)
            {
                _CAPTypeId = null;
            }
            if (pSelectedChoice != eChoiceInspectionTypeSearchCollectionSelect.scInspectorId)
            {
                _InspectorId = null;
            }
            if (pSelectedChoice != eChoiceInspectionTypeSearchCollectionSelect.scGetByCode)
            {
                _GetByCode = null;
            }
        }
    }
}
