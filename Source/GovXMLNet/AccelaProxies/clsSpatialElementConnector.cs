// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="SpatialElementConnector">
		<xsd:complexContent>
			<xsd:extension base="SpatialEntity">
				<xsd:sequence>
					<xsd:element name="relatingElementConnector" form="qualified">
						<xsd:complexType>
							<xsd:choice>
								<xsd:element ref="ifc:RelConnectsElements"/>
							</xsd:choice>
						</xsd:complexType>
					</xsd:element>
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
    public class clsSpatialElementConnector : clsSpatialEntity
    {
        // Members
        // TODO not sure if this needs to be calling another class or not, need example
        public clsIFCRelConnectsElements relatingElementConnector { get; set; }

        // Constructors
        public clsSpatialElementConnector()
        {
        }
    }
}
