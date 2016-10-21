// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="GetInvoices">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element name="contextType" type="getInvoicesContextTypeEnum" form="qualified" minOccurs="0"/>
					<xsd:element name="calculateNow" type="xsd:boolean" default="false" form="qualified" minOccurs="0"/>
					<xsd:element name="collectionsLevelQueryLogic" type="queryLogicEnum" default="OR" form="qualified" minOccurs="0"/>
					<xsd:element name="collectionLevelQueryLogic" type="queryLogicEnum" default="OR" form="qualified" minOccurs="0"/>
					<xsd:choice maxOccurs="unbounded">
						<xsd:group ref="InvoiceSearchCollectionSelect"/>
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
    public class msgGetInvoices : clsOperationRequest
    {
        // Members
        private getInvoicesContextTypeEnum? _contextType = null;
        public getInvoicesContextTypeEnum? contextType
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

        private bool? _calculateNow = null;
        public bool? calculateNow
        {
            get
            {
                if (_calculateNow.HasValue)
                {
                    return _calculateNow.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _calculateNow = value; }
        }
        public bool calculateNowSpecified
        {
            get { return _calculateNow != null; }
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

        // Begin group InvoiceSearchCollectionSelect
        // Begin choice 
        private clsCAPId _CAPId = null;
        public clsCAPId CAPId
        {
            get { return _CAPId; }
            set
            {
                _CAPId = value;
                ChoiceClearAllBut(eChoiceInvoiceSearchCollectionSelect.scCAPId);
            }
        }

        private clsDateRange _DateRange = null;
        public clsDateRange DateRange
        {
            get { return _DateRange; }
            set
            {
                _DateRange = value;
                ChoiceClearAllBut(eChoiceInvoiceSearchCollectionSelect.scDateRange);
            }
        }

        private clsInvoiceId _InvoiceId = null;
        public clsInvoiceId InvoiceId
        {
            get { return _InvoiceId; }
            set
            {
                _InvoiceId = value;
                ChoiceClearAllBut(eChoiceInvoiceSearchCollectionSelect.scInvoiceId);
            }
        }
        // End choice
        // End Group InvoiceSearchCollectionSelect

        // Constructors
        public msgGetInvoices()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceInvoiceSearchCollectionSelect pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceInvoiceSearchCollectionSelect.scCAPId)
            {
                _CAPId = null;
            }
            if (pSelectedChoice != eChoiceInvoiceSearchCollectionSelect.scDateRange)
            {
                _DateRange = null;
            }
            if (pSelectedChoice != eChoiceInvoiceSearchCollectionSelect.scInvoiceId)
            {
                _InvoiceId = null;
            }
        }
    }
}
