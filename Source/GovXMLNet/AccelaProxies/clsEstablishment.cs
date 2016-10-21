// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="Establishment">
		<xsd:complexContent>
			<xsd:extension base="SpatialObject">
				<xsd:sequence>
					<xsd:element ref="ifc:Organization" minOccurs="0"/>
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
    public class clsEstablishment : clsSpatialObject
    {
        // Members
        public clsIFCOrganization Organization { get; set; }

        // Constructors
        public clsEstablishment()
        {
        }
    }
}
