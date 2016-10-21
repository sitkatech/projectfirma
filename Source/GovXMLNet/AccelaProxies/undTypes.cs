using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="AssetType">

   -------   <xsd:element name="usageTypes" ref="Types" minOccurs="0"/> Refers to nonexistant "Types"
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
    public class undTypes : clsElementList
    {
        // Members
        [XmlElement(ElementName = "Type")]
        public List<clsType> Type { get; set; }

        // Constructors
        public undTypes()
        {
        }
    }
}
