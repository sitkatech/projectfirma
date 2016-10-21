// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
  <xsd:complexType name="GetOwners">
    <xsd:complexContent>
      <xsd:extension base="OperationRequest">
        <xsd:sequence minOccurs="0">
          <xsd:element ref="Contacts" minOccurs="0"/>
          <xsd:element ref="GISObjects" minOccurs="0"/>
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
    public class msgGetOwners : clsOperationRequest
    {
        // Members
        public clsContacts Contacts { get; set; }
        public clsGISObjects GISObjects { get; set; }

        // Constructors
        public msgGetOwners()
        {
        }
    }
}
