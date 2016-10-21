// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="Fee">
		<xsd:complexContent>
			<xsd:extension base="element">
				<xsd:sequence>
					<xsd:choice>
						<xsd:sequence>
							<xsd:element name="totalAssessedAmount" type="monetaryMeasure" form="qualified"/>
							<xsd:element name="totalPaidAmount" type="monetaryMeasure" form="qualified" minOccurs="0"/>
							<xsd:element name="transactionDueAmount" type="monetaryMeasure" form="qualified"/>
							<xsd:element name="transactionPaymentRange" type="Range" form="qualified" minOccurs="0"/>
						</xsd:sequence>
						<xsd:sequence>
							<xsd:element name="transactionPaymentAmount" type="monetaryMeasure" form="qualified"/>
							<xsd:element ref="PaymentBreakdowns" minOccurs="0"/>
						</xsd:sequence>
					</xsd:choice>
					<xsd:element name="currency" type="ifc:CurrencyEnum" form="qualified" minOccurs="0"/>
					<xsd:element ref="Comments" minOccurs="0"/>
					<xsd:element name="quantity" type="xsd:double" minOccurs="0"/>
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
    public class clsFee : clsElement
    {
        private decimal _totalAssessedAmount = 0;
        public decimal totalAssessedAmount
        {
            get { return _totalAssessedAmount; }
            set { _totalAssessedAmount = value; }
        }

        private decimal? _totalPaidAmount = null;
        public decimal? totalPaidAmount
        {
            get
            {
                if (_totalPaidAmount.HasValue)
                {
                    return _totalPaidAmount.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _totalPaidAmount = value; }
        }
        public bool totalPaidAmountSpecified
        {
            get { return _totalPaidAmount != null; }
        }

        private decimal _transactionDueAmount = 0;
        public decimal transactionDueAmount
        {
            get { return _transactionDueAmount; }
            set { _transactionDueAmount = value; }
        }

        public clsRange transactionPaymentRange { get; set; }

        private decimal _transactionPaymentAmount = 0;
        public decimal transactionPaymentAmount
        {
            get { return _transactionPaymentAmount; }
            set { _transactionPaymentAmount = value; }
        }
        public bool transactionPaymentAmountSpecified
        {
            get { return _transactionPaymentAmount != 0; }
        }


        public clsPaymentBreakdowns PaymentBreakdowns { get; set; }

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

        private string _Comments = null;
        public string Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }

        private double? _quantity = null;
        public double? quantity
        {
            get
            {
                if (_quantity.HasValue)
                {
                    return _quantity.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _quantity = value; }
        }
        public bool quantitySpecified
        {
            get { return _quantity != null; }
        }


        // Constructors
        public clsFee()
        {
        }
    }
}
