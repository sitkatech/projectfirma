using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaSharedDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="OptionSets">
    <xsd:sequence>
      <xsd:element ref="OptionSet" minOccurs="1" maxOccurs="unbounded"/>
    </xsd:sequence>
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
    public class clsOptionSets
    {
        // Members
        [XmlElement(ElementName = "OptionSet")]
        public List<clsOptionSet> OptionSet { get; set; }

        // Constructors
        public clsOptionSets()
        {
        }
    }
}
