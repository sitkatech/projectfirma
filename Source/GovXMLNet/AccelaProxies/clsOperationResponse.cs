using System.Xml.Serialization;

// Defined in AccelaOperationRepository_Base

/* Version Last Modified: 7.1
  <xsd:complexType name="OperationResponse">
    <xsd:sequence>
      <xsd:element ref="System"/>
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
    public class clsOperationResponse
    {
        // Members
        [XmlElement(ElementName = "System")]
        public clsSystem system { get; set; }

        // Constructors
        public clsOperationResponse()
        {
        }

    }
}
