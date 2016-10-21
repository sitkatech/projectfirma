using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="Districts">
    <xsd:complexContent>
      <xsd:extension base="elements">
        <xsd:sequence maxOccurs="unbounded">
          <xsd:element ref="District"/>
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
    public class clsDistricts : clsElementList  // Guessing here since elements is not defined
    {
        // Members
        [XmlElement(ElementName = "District")]
        public List<clsDistrict> District { get; set; }

        // Constructors
        public clsDistricts()
        {
        }
    }
}
