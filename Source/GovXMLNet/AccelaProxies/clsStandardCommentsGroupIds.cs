using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="StandardCommentsGroupIds">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="StandardCommentsGroupId"/>
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
    public class clsStandardCommentsGroupIds : clsElementList
    {
        // Members
        [XmlElement(ElementName = "StandardCommentsGroupId")]
        public List<clsStandardCommentsGroupId> StandardCommentsGroupId { get; set; }

        // Constructors
        public clsStandardCommentsGroupIds()
        {
        }
    }
}
