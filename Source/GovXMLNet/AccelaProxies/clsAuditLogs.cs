using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
    <xsd:complexType name="AuditLogs">
      <xsd:complexContent>
        <xsd:extension base="elementList">
          <xsd:sequence>
            <xsd:element ref="AuditLog"/>
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
    public class clsAuditLogs : clsElementList
    {
        // Members
        [XmlElement(ElementName = "AuditLog")]
        public List<clsAuditLog> AuditLog { get; set; }

        // Constructors
        public clsAuditLogs()
        {
        }
    }
}
