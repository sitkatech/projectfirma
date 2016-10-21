using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="Cities">
    <xsd:complexContent>
      <xsd:extension base="elementList">
        <xsd:sequence maxOccurs="unbounded">
          <xsd:element ref="City"/>
          <xsd:element ref="CityEnumerations" minOccurs="0" maxOccurs="1"/>
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
    public class clsCities : clsElementList
    {
        // Members
        // TODO need example, these may need to be combined into a struct
        [XmlElement(ElementName = "City")]
        public List<string> City { get; set; }

        public clsCityEnumerations CityEnumerations { get; set; }

        // Constructors
        public clsCities()
        {
        }
    }
}
