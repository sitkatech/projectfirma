using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
    <xsd:complexType name="TimeAccountingGroups">
      <xsd:complexContent>
        <xsd:extension base="elementList">
          <xsd:sequence>
            <xsd:element ref="TimeAccountingGroup" minOccurs="0"/>
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
    public class clsTimeAccountingGroups : clsElementList
    {
        // Members
        [XmlElement(ElementName = "TimeAccountingGroup")]
        public List<clsTimeAccountingGroup> TimeAccountingGroup { get; set; }

        // Constructors
        public clsTimeAccountingGroups()
        {
        }
    }
}
