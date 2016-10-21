using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="InspectionRelations">
    <xsd:complexContent>
      <xsd:extension base="elementList">
        <xsd:sequence maxOccurs="unbounded">
          <xsd:element ref="InspectionRelation"/>
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
    public class clsInspectionRelations : clsElementList
    {
        // Members
        [XmlElement(ElementName = "InspectionRelation")]
        public List<clsInspectionRelation> InspectionRelation { get; set; }

        // Constructors
        public clsInspectionRelations()
        {
        }
    }
}
