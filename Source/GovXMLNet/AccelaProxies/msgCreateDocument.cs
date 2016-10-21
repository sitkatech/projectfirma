// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
  <xsd:complexType name="CreateDocument">
    <xsd:complexContent>
      <xsd:extension base="OperationRequest">
        <xsd:sequence>
          <xsd:element ref="ObjectId"/>
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
    public class msgCreateDocument : clsOperationRequest
    {
        // Members
        public clsObjectId ObjectId { get; set; }
        public clsDocument Document { get; set; }
        public clsEDMSAdapter EDMSAdapter { get; set; }

        // Constructors
        public msgCreateDocument()
        {
        }
    }
}
