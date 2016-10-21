// Defined in ifc2x_final_stage2_03

/* Version Last Modified: 7.1
<xsd:complexType name="RelConnectsElements">
	<xsd:complexContent>
		<xsd:extension base="RelConnects">
			<xsd:sequence>
				<xsd:element minOccurs="0" name="connectionGeometry">
					<xsd:complexType>
						<xsd:choice>
							<xsd:element ref="ConnectionGeometry"/>
						</xsd:choice>
					</xsd:complexType>
				</xsd:element>
				<xsd:element name="relatingElement">
					<xsd:complexType>
						<xsd:choice>
							<xsd:element ref="Element"/>
						</xsd:choice>
					</xsd:complexType>
				</xsd:element>
				<xsd:element name="relatedElement">
					<xsd:complexType>
						<xsd:choice>
							<xsd:element ref="Element"/>
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
    public class clsIFCRelConnectsElements : clsIFCRelConnects
    {
        // Members
        public clsIFCConnectionGeometry connectionGeometry { get; set; }
        public clsIFCElement relatingElement { get; set; }
        public clsIFCElement relatedElement { get; set; }

        // Constructors 
        public clsIFCRelConnectsElements()
        {
        }
    }
}
