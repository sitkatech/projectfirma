using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="PartInventoryIds">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="PartInventoryId"/>
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
    public class clsPartInventoryIds : clsElementList
    {
        // Members
        [XmlElement(ElementName = "PartInventoryId")]
        public List<clsPartInventoryId> PartInventoryId { get; set; }

        // Constructors
        public clsPartInventoryIds()
        {
        }
    }
}
