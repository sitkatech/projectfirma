// Defined in ifc2x_final_stage2_03

/* Version Last Modified: 6.7
<xsd:complexType abstract="true" name="Product">
	<xsd:complexContent>
		<xsd:extension base="Object">
			<xsd:sequence>
				<xsd:element minOccurs="0" name="objectPlacement">
					<xsd:complexType>
						<xsd:choice>
							<xsd:element ref="ObjectPlacement"/>
						</xsd:choice>
					</xsd:complexType>
				</xsd:element>
				<xsd:element minOccurs="0" name="representation">
					<xsd:complexType>
						<xsd:choice>
							<xsd:element ref="ProductRepresentation"/>
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
    public class clsIFCProduct : clsIFCObject
    {
        public clsIFCObjectPlacement objectPlacement { get; set; }
        public clsIFCProductRepresentation representation { get; set; }
        // Constructors
        public clsIFCProduct()
        {
        }
    }
}
