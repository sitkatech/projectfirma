using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="GISLayerGroups">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="GISLayerGroup"/>
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
    public class clsGISLayerGroups : clsElementList
    {
        // Members
        [XmlElement(ElementName = "GISLayerGroup")]
        public List<clsGISLayerGroup> GISLayerGroup { get; set; }

        // Constructors
        public clsGISLayerGroups()
        {
        }
    }
}
