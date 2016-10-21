using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="LicenseTypes">
    <xsd:complexContent>
      <xsd:extension base="elementList">
        <xsd:sequence maxOccurs="unbounded">
          <xsd:element ref="LicenseType"/>
          <xsd:element ref="LicenseTypeEnumerations" minOccurs="0" maxOccurs="1"/>
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
    public class clsLicenseTypes : clsElementList
    {
        // Members
        [XmlElement(ElementName = "LicenseType")]
        public List<string> LicenseType { get; set; }

        // TODO I'm pretty sure this is wrong.  These probably need to be combined into a struct, but want example
        [XmlElement(ElementName = "LicenseTypeEnumerations")]
        public List<clsLicenseTypeEnumerations> LicenseTypeEnumerations { get; set; }

        // Constructors
        public clsLicenseTypes()
        {
        }
    }
}
