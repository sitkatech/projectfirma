// Defined in ifc2x_final_stage2_03 as local complex type needed to get thePerson

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
    public class lctIFCthePerson
    {
        // Members
        public clsIFCPerson Person { get; set; }

        // Constructors
        public lctIFCthePerson()
        {
        }
    }
}
