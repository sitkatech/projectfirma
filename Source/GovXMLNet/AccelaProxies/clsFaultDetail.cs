using System.Xml.Serialization;


// Defined in AccelaGovXMLSystemDataObjects

/* Version Last Modified: 6.7
   <xsd:complexType name="FaultDetail">
    <xsd:sequence>
      <xsd:any namespace="##any" minOccurs="0" maxOccurs="unbounded" processContents="lax" />
    </xsd:sequence>
    <xsd:anyAttribute namespace="##any" processContents="lax" />
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
    class clsFaultDetail
    {
        // TODO I hope this will work, definitely need a couple of examples of different faults
        public System.Xml.XmlElement Any { get; set; }
        [XmlAttribute]
        public System.Xml.XmlAttribute AnyAttr { get; set; }

        // Constructors
        public clsFaultDetail()
        {
        }
    }
}
