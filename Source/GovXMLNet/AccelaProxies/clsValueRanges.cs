using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="ValueRanges">
    <xsd:complexContent>
      <xsd:extension base="elementList">
        <xsd:sequence maxOccurs="unbounded">
          <xsd:element ref="ValueRange"/>
        </xsd:sequence>
      </xsd:extension>
    </xsd:complexContent>
  </xsd:complexType>
*/

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 4/11/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class clsValueRanges : clsElementList
    {
        // Members
        [XmlElement(ElementName = "ValueRange")]
        public List<string> ValueRange { get; set; }

        // Constructors
        public clsValueRanges()
        {
        }
    }
}
