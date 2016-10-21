using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="ConfirmationNumbers">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="ConfirmationNumber"/>
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
    public class clsConfirmationNumbers : clsElementList
    {
        // Members
        [XmlElement(ElementName = "ConfirmationNumber")]
        public List<string> ConfirmationNumber { get; set; }

        // Constructors
        public clsConfirmationNumbers()
        {
        }
    }
}
