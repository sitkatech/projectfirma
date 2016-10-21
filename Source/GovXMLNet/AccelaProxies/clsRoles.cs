using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="Roles">
    <xsd:complexContent>
      <xsd:extension base="elementList">
        <xsd:sequence maxOccurs="unbounded">
          <xsd:element ref="Role"/>
          <xsd:element ref="RoleEnumerations" minOccurs="0" maxOccurs="1"/>
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
    public class clsRoles : clsElementList
    {
        // Members
        [XmlElement(ElementName = "Role")]
        public List<string> Role { get; set; }
        // TODO this is probably wrong and will need to be combined into a struct
        public clsRoleEnumerations RoleEnumerations { get; set; }

        // Constructors
        public clsRoles()
        {
        }
    }
}
