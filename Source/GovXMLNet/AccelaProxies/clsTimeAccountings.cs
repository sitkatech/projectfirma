using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
    <xsd:complexType name="TimeAccountings">
      <xsd:complexContent>
        <xsd:extension base="elementList">
          <xsd:sequence>
            <xsd:element ref="TimeAccounting" minOccurs="0"/>
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
    public class clsTimeAccountings : clsElementList
    {
        // Members
        [XmlElement(ElementName = "TimeAccounting")]
        public List<clsTimeAccounting> TimeAccounting { get; set; }

        // Constructors
        public clsTimeAccountings()
        {
        }
    }
}
