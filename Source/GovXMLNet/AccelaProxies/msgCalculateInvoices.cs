// Defined in AccelaOperationRepository_Authentication

/* Version Last Modified: 6.7
	<xsd:complexType name="CalculateInvoices">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
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
    public class msgCalculateInvoices : clsOperationRequest
    {
        // Members
        // Begin group InvoiceSearchCollectionSelect
        // Begin choice
        private clsContactId _ContactId = null;
        public clsContactId ContactId
        {
            get { return _ContactId; }
            set
            {
                _ContactId = value;
                ChoiceClearAllBut(eChoiceCalculateInvoices.scContactID);
            }
        }

        private clsCAPId _CAPId = null;
        public clsCAPId CAPId
        {
            get { return _CAPId; }
            set
            {
                _CAPId = value;
                ChoiceClearAllBut(eChoiceCalculateInvoices.scCAPId);
            }
        }

        private clsDateRange _DateRange = null;
        public clsDateRange DateRange
        {
            get { return _DateRange; }
            set
            {
                _DateRange = value;
                ChoiceClearAllBut(eChoiceCalculateInvoices.scDateRange);
            }
        }

        private clsInvoiceId _InvoiceId = null;
        public clsInvoiceId InvoiceId
        {
            get { return _InvoiceId; }
            set
            {
                _InvoiceId = value;
                ChoiceClearAllBut(eChoiceCalculateInvoices.scInvoiceId);
            }
        }
        // End choice
        // End group InvoiceSearchCollectionSelect

        // Constructors
        public msgCalculateInvoices()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceCalculateInvoices pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceCalculateInvoices.scContactID)
            {
                _ContactId = null;
            }
            if (pSelectedChoice != eChoiceCalculateInvoices.scCAPId)
            {
                _CAPId = null;
            }
            if (pSelectedChoice != eChoiceCalculateInvoices.scDateRange)
            {
                _DateRange = null;
            }
            if (pSelectedChoice != eChoiceCalculateInvoices.scInvoiceId)
            {
                _InvoiceId = null;
            }
        }
    }
}
