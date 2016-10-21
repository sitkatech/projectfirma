// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="GetSeverityLevels">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element name="contextType" type="getSeverityLevelsContextTypeEnum" form="qualified" minOccurs="0"/>
					<xsd:element name="collectionsLevelQueryLogic" type="queryLogicEnum" default="OR" form="qualified" minOccurs="0"/>
					<xsd:element name="collectionLevelQueryLogic" type="queryLogicEnum" default="OR" form="qualified" minOccurs="0"/>
					<xsd:choice minOccurs="0">
						<xsd:group ref="SeverityLevelsSearchCollectionSelect"/>
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
    public class msgGetSeverityLevels : clsOperationRequest
    {
        // Members
        private getSeverityLevelsContextTypeEnum? _contextType = null;
        public getSeverityLevelsContextTypeEnum? contextType
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

        // Begin group SeverityLevelsSearchCollectionSelect
        // Begin choice
        private clsConditionTypeIds _ConditionTypeIds = null;
        public clsConditionTypeIds ConditionTypeIds
        {
            get { return _ConditionTypeIds; }
            set
            {
                _ConditionTypeIds = value;
                ChoiceClearAllBut(eChoiceSeverityLevelsSearchCollectionSelect.scConditionTypeIds);
            }
        }

        private clsHoldTypeIds _HoldTypeIds = null;
        public clsHoldTypeIds HoldTypeIds
        {
            get { return _HoldTypeIds; }
            set
            {
                _HoldTypeIds = value;
                ChoiceClearAllBut(eChoiceSeverityLevelsSearchCollectionSelect.scHoldTypeIds);
            }
        }
        // End choice
        // End group SeverityLevelsSearchCollectionSelect

        // Constructors
        public msgGetSeverityLevels()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceSeverityLevelsSearchCollectionSelect pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceSeverityLevelsSearchCollectionSelect.scConditionTypeIds)
            {
                _ConditionTypeIds = null;
            }
            if (pSelectedChoice != eChoiceSeverityLevelsSearchCollectionSelect.scHoldTypeIds)
            {
                _HoldTypeIds = null;
            }
        }
    }
}
