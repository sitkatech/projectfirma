using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLSystemDataObjects

/* Version Last Modified: 6.7
   <xsd:complexType name="Messages">
	<xsd:sequence minOccurs="0" maxOccurs="unbounded">
		<xsd:element ref="Message" />
    </xsd:sequence>
  </xsd:complexType>
*/
// Note this should maybe be defined as an XML array depending on how it indents

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 2/14/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class clsMessages
    {
        // Members
        [XmlElement(ElementName = "Message")]
        public List<clsMessage> Message { get; set; }

        // Constructors
        public clsMessages()
        {
        }

    }
}
