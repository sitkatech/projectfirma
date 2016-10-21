// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="Structure">
		<xsd:complexContent>
			<xsd:extension base="SpatialObject">
				<xsd:sequence>
					<xsd:element name="relatingStructure" form="qualified" minOccurs="0">
						<xsd:complexType>
							<xsd:choice>
								<xsd:element ref="ifc:SpatialStructureElement"/>
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
    public class clsStructure : clsSpatialObject
    {
        // Members
        // TODO need example to check this
        public clsIFCSpatialStructureElement relatingStructure { get; set; }

        // Constructors
        public clsStructure()
        {
        }
    }
}
