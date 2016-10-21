// Defined in ifc2x_final_stage2_03

/* Version Last Modified: 7.1
<xsd:complexType name="PersonAndOrganization">
	<xsd:complexContent>
		<xsd:extension base="elementID">
			<xsd:sequence>
				<xsd:element name="thePerson">
					<xsd:complexType>
						<xsd:choice>
							<xsd:element ref="Person"/>
						</xsd:choice>
					</xsd:complexType>
				</xsd:element>
				<xsd:element name="theOrganization">
					<xsd:complexType>
						<xsd:choice>
							<xsd:element ref="Organization"/>
						</xsd:choice>
					</xsd:complexType>
				</xsd:element>
				<xsd:element minOccurs="0" name="roles">
					<xsd:complexType>
						<xsd:choice maxOccurs="unbounded" minOccurs="1">
							<xsd:element ref="ActorRole"/>
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
    public class clsIFCPersonAndOrganization : clsIFCelementID
    {
        // Members
        public lctIFCthePerson thePerson { get; set; }
        public lctIFCtheOrganization theOrganization { get; set; }
        public clsIFCActorRole roles { get; set; }

        // Constructors
    }
}
