// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
	<xsd:complexType name="GetDocumentResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence>
					<xsd:element ref="Document"/>
                    <xsd:element ref="EDMSAdapter" minOccurs="0" maxOccurs="1"/>
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
    public class msgGetDocumentResponse : clsOperationResponse
    {
        // Members
        public clsDocument Document { get; set; }
        public clsEDMSAdapter EDMSAdapter { get; set; }

        // Constructors
        public msgGetDocumentResponse()
        {
        }
    }
}
