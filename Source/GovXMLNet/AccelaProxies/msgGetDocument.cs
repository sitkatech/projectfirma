// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="GetDocument">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element ref="DocumentId"/>
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
    public class msgGetDocument : clsOperationRequest
    {
        // Members
        public clsDocumentId DocumentId { get; set; }
        public clsEDMSAdapter EDMSAdapter { get; set; }

        // Constructors
        public msgGetDocument()
        {
        }
    }
}
