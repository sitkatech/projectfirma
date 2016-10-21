using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="District">
    <xsd:complexContent>
      <xsd:extension base="String">
        <xsd:sequence maxOccurs="unbounded">
          <xsd:element name="district" type="xsd:string" minOccurs="0" />
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
    public class clsDistrict
    {
        // Members
        [XmlArray("District")]
        [XmlArrayItem("district")]
        public List<string> District { get; set; }
        
        // Constructors
        public clsDistrict()
        {
        }
    }
}
