using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="InspectionUnitNumbers">
    <xsd:complexContent>
      <xsd:extension base="elementList">
        <xsd:sequence maxOccurs="unbounded">
          <xsd:element ref="InspectionUnitNumber"/>
          <xsd:element ref="InspectionUnitNumberEnumerations" minOccurs="0" maxOccurs="1"/>
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
    public class clsInspectionUnitNumbers : clsElementList
    {
        // Members
        [XmlElement(ElementName = "InspectionUnitNumber")]
        public List<string> InspectionUnitNumber { get; set; }

        // TODO I'm pretty sure this is wrong.  These probably need to be combined into a struct, but want example
        [XmlElement(ElementName = "InspectionUnitNumberEnumerations")]
        public List<clsInspectionUnitNumberEnumerations> InspectionUnitNumberEnumerations { get; set; }

        // Constructors
        public clsInspectionUnitNumbers()
        {
        }
    }
}
