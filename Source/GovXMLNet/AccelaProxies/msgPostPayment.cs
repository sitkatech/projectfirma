// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="PostPayment">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element name="validatingLicenses" type="Licenses" form="qualified" minOccurs="0"/>
					<xsd:element ref="Invoices" minOccurs="0"/>
					<xsd:element ref="Payments"/>
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
    public class msgPostPayment : clsOperationRequest
    {
        // Members
        public clsLicenses validatingLicenses { get; set; }

        public clsInvoices Invoices { get; set; }

        public clsPayments Payments { get; set; }

        // Constructors
        public msgPostPayment()
        {
        }
    }
}
