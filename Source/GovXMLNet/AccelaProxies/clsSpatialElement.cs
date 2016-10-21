// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="SpatialElement">
		<xsd:complexContent>
			<xsd:extension base="SpatialEntity">
				<xsd:sequence>
					<xsd:element name="relatingElement" form="qualified" minOccurs="0">
						<xsd:complexType>
							<xsd:choice>
								<xsd:element ref="ifc:Element"/>
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
    public class clsSpatialElement : clsSpatialEntity
    {
        // Members
        // TODO need example to see if this is right
        public clsIFCElement relatingElement { get; set; }

        // Constructors
        public clsSpatialElement()
        {
        }
    }
}
