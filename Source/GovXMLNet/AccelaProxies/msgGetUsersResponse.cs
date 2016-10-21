// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
	<xsd:complexType name="GetUsersResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence>
                    <xsd:element ref="Contacts"/>
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
    public class msgGetUsersResponse : clsOperationResponse
    {
        // Members
        public clsContacts Contacts { get; set; }

        // Constructors
        public msgGetUsersResponse()
        {
        }
    }
}
