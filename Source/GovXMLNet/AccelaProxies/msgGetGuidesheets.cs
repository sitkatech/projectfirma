// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="GetGuidesheets">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element name="collectionsLevelQueryLogic" type="queryLogicEnum" default="OR" form="qualified" minOccurs="0"/>
					<xsd:element name="collectionLevelQueryLogic" type="queryLogicEnum" default="OR" form="qualified" minOccurs="0"/>
					<xsd:choice minOccurs="0">
						<xsd:group ref="GuidesheetSearchCollectionSelect"/>
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
    public class msgGetGuidesheets : clsOperationRequest
    {
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

        // Begin group GuidesheetSearchCollectionSelect
        // Begin choice

        private clsCAPId _CAPId = null;
        public clsCAPId CAPId
        {
            get { return _CAPId; }
            set
            {
                _CAPId = value;
                ChoiceClearAllBut(eChoiceGuidesheetSearchCollectionSelect.scCAPId);
            }
        }

        private clsCAPTypeId _CAPTypeId = null;
        public clsCAPTypeId CAPTypeId
        {
            get { return _CAPTypeId; }
            set
            {
                _CAPTypeId = value;
                ChoiceClearAllBut(eChoiceGuidesheetSearchCollectionSelect.scCAPTypeId);
            }
        }

        private clsInspectionId _InspectionId = null;
        public clsInspectionId InspectionId
        {
            get { return _InspectionId; }
            set
            {
                _InspectionId = value;
                ChoiceClearAllBut(eChoiceGuidesheetSearchCollectionSelect.scInspectionId);
            }
        }

        private clsInspectionType _InspectionType = null;
        public clsInspectionType InspectionType
        {
            get { return _InspectionType; }
            set
            {
                _InspectionType = value;
                ChoiceClearAllBut(eChoiceGuidesheetSearchCollectionSelect.scInspectionType);
            }
        }
        // End choice
        // End Group GuidesheetSearchCollectionSelect

        public msgGetGuidesheets()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceGuidesheetSearchCollectionSelect pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceGuidesheetSearchCollectionSelect.scCAPId)
            {
                _CAPId = null;
            }
            if (pSelectedChoice != eChoiceGuidesheetSearchCollectionSelect.scCAPTypeId)
            {
                _CAPTypeId = null;
            }
            if (pSelectedChoice != eChoiceGuidesheetSearchCollectionSelect.scInspectionId)
            {
                _InspectionId = null;
            }
            if (pSelectedChoice != eChoiceGuidesheetSearchCollectionSelect.scInspectionType)
            {
                _InspectionType = null;
            }
        }
    }
}
