// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="Hold">
		<xsd:complexContent>
			<xsd:extension base="Condition">
				<xsd:sequence>
					<xsd:element ref="HoldLevel" minOccurs="0"/>
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
    public class clsHold : clsCondition
    {
        // Members
        public clsHoldLevel HoldLevel { get; set; }

        // Constructors
        public clsHold()
        {
        }
    }
}
