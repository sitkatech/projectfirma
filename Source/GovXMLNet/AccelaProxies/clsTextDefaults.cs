using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="TextDefaults">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence minOccurs="0" maxOccurs="unbounded">
					<xsd:element ref="TextDefault"/>
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
    public class clsTextDefaults : clsElementList
    {
        // Members
        [XmlElement(ElementName = "TextDefault")]
        public List<clsTextDefault> TextDefault { get; set; }

        // Constructors
        public clsTextDefaults()
        {
        }
    }
}
