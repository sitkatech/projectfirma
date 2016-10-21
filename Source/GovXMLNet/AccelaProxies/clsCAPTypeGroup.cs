// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="CAPTypeGroup">
		<xsd:complexContent>
			<xsd:extension base="Identifier">
				<xsd:sequence>
					<xsd:element ref="CAPTypeSubGroups"/>
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
    public class clsCAPTypeGroup : clsIdentifier
    {
        // Members
        public clsCAPTypeSubGroups CAPTypeSubGroups { get; set; }

        // Constructors
        public clsCAPTypeGroup()
        {
        }
    }
}
