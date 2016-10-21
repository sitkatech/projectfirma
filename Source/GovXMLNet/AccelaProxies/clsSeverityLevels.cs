using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="SeverityLevels">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="SeverityLevel"/>
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
    public class clsSeverityLevels : clsElementList
    {
        // Members
        [XmlElement(ElementName = "SeverityLevel")]
        public List<clsSeverityLevel> SeverityLevel { get; set; }

        // Constructors
        public clsSeverityLevels()
        {
        }
    }
}
