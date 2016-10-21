using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaSharedDataObjects

/* Version Last Modified: 6.7
  <xsd:complexType name="Options">
    <xsd:sequence>
      <xsd:element ref="Option" minOccurs="1" maxOccurs="unbounded"/>
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
    public class clsOptions
    {
        // Members
        [XmlElement(ElementName = "Option")]
        public List<clsOption> Option { get; set; }

        // Constructors
        public clsOptions()
        {
        }
    }
}
