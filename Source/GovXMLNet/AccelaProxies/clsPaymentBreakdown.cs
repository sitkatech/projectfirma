// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="PaymentBreakdown">
		<xsd:complexContent>
			<xsd:extension base="element">
				<xsd:sequence>
					<xsd:element ref="PaymentId"/>
					<xsd:element name="amount" type="monetaryMeasure" form="qualified"/>
					<xsd:element name="currency" type="ifc:CurrencyEnum" form="qualified" minOccurs="0"/>
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
    public class clsPaymentBreakdown : clsElement
    {
        // Members
        public clsPaymentId PaymentId = new clsPaymentId();

        private decimal _amount = 0;
        public decimal amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private CurrencyEnum? _currency = null;
        public CurrencyEnum? currency
        {
            get
            {
                if (_currency.HasValue)
                {
                    return _currency.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _currency = value; }
        }
        public bool currencySpecified
        {
            get { return _currency != null; }
        }


        // Constructors
        public clsPaymentBreakdown()
        {
        }
    }
}
