using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="EDMSAdapters">
    <xsd:complexContent>
      <xsd:extension base="elementList">
        <xsd:sequence maxOccurs="unbounded">
          <xsd:element ref="EDMSAdapter"/>
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
    public class clsEDMSAdapters : clsElementList
    {
        // Methods
        [XmlElement(ElementName = "EDMSAdapter")]
        public List<clsEDMSAdapter> EDMSAdapter { get; set; }

        // Constructors
        public clsEDMSAdapters()
        {
        }
    }
}
