using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="RouteNodeIds">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="RouteNodeId"/>
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
    public class clsRouteNodeIds : clsElementList
    {
        // Members
        [XmlElement(ElementName = "RouteNodeId")]
        public List<clsRouteNodeId> RouteNodeId { get; set; }

        // Constructors
        public clsRouteNodeIds()
        {
        }
    }
}
