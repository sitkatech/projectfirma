// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="HoldType">
		<xsd:complexContent>
			<xsd:extension base="ConditionType">
				<xsd:sequence>
					<xsd:element ref="HoldLevels" minOccurs="0"/>
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
    public class clsHoldType : clsConditionType
    {
        // Members
        public clsHoldLevels HoldLevels { get; set; }

        // Constructors
        public clsHoldType()
        {
        }
    }
}
