using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="StreetDirections">
    <xsd:complexContent>
      <xsd:extension base="elementList">
        <xsd:sequence>
          <xsd:element ref="StreetDirectionsEnumerations"/>
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
    public class clsStreetDirections : clsElementList
    {
        // Members
        [XmlElement(ElementName = "StreetDirectionsEnumerations")]
        public List<clsStreetDirectionsEnumerations> StreetDirectionsEnumerations { get; set; }

        // Constructors
        public clsStreetDirections()
        {
        }
    }
}
