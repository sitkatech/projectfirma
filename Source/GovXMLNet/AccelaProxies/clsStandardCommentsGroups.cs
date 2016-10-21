using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="StandardCommentsGroups">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="StandardCommentsGroup"/>
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
    public class clsStandardCommentsGroups : clsElementList
    {
        // Members
        [XmlElement(ElementName = "StandardCommentsGroup")]
        public List<clsStandardCommentsGroup> StandardCommentsGroup { get; set; }

        // Constructors
        public clsStandardCommentsGroups()
        {
        }
    }
}
