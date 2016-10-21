using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="Types">
    <xsd:complexContent>
      <xsd:extension base="elementList">
        <xsd:sequence maxOccurs="unbounded">
          <xsd:element ref="Type">
	    </xsd:sequence>
      </xsd:extension>
    </xsd:compleContent>
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
    public class clsTypes : clsElementList
    {
        // Members
        [XmlElement(ElementName = "Type")]
        public List<clsType> Type { get; set; }

        // Constructors
        public clsTypes()
        {
        }
    }
}
