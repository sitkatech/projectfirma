// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="User">
		<xsd:complexContent>
			<xsd:extension base="People">
				<xsd:sequence>
					<xsd:element ref="AdditionalInformation" minOccurs="0"/>
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
    public class clsUser : clsPeople
    {
        // Members
        public clsAdditionalInformation AdditionalInformation { get; set; }

        // Constructors
        public clsUser()
        {
        }
    }
}
