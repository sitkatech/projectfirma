// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
  <xsd:complexType name="CreateDocumentResponse">
    <xsd:complexContent>
      <xsd:extension base="OperationResponse">
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
    public class msgCreateDocumentResponse : clsOperationResponse
    {
        // Members
        public clsDocumentId DocumentId { get; set; }
        public clsEDMSAdapter EDMSAdapater { get; set; }

        // Constructors
        public msgCreateDocumentResponse()
        {
        }
    }
}
