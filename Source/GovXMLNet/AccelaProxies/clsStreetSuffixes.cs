using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="StreetSuffixes">
    <xsd:complexContent>
      <xsd:extension base="elementList">
        <xsd:sequence>
          <xsd:element ref="StreetSuffixesEnumerations"/>
        </xsd:sequence>
      </xsd:extension>
    </xsd:complexContent>
  </xsd:complexType>
*/

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 4/17/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class clsStreetSuffixes : clsElementList
    {
        // Members
        [XmlElement(ElementName = "StreetSuffixesEnumerations")]
        public List<clsStreetSuffixesEnumerations> StreetSuffixesEnumerations { get; set; }

        // Constructors
        public clsStreetSuffixes()
        {
        }
    }
}
