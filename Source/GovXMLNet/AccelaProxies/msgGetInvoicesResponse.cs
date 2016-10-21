// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="GetInvoicesResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence>
					<xsd:element ref="Invoices"/>
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
    public class msgGetInvoicesResponse : clsOperationResponse
    {
        // Members
        public clsInvoices Invoices { get; set; }

        // Constructors
        public msgGetInvoicesResponse()
        {
        }
    }
}
