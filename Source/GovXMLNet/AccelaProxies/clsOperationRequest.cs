using System.Xml.Serialization;

// Defined in AccelaOperationRepository_Base

/* Version Last Modified: 7.1
  <xsd:complexType name="OperationRequest">
    <xsd:sequence>
      <xsd:element ref="System"/>
      <xsd:element ref="Options" minOccurs="0" maxOccurs="1"/>
    </xsd:sequence>
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
    public class clsOperationRequest
    {
        // Members
        [XmlElement(ElementName = "System")]
        public clsSystem system { get; set; }

        public clsOptions Options { get; set; }

        // Constructors
        public clsOperationRequest()
        {
        }
    }
}
