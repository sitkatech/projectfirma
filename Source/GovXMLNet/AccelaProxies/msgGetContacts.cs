// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
	<xsd:complexType name="GetContacts">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element ref="CAPId"/>
					<xsd:element ref="Contact"/>
					<xsd:element ref="Elements"/>
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
    public class msgGetContacts : clsOperationRequest
    {
        // Members
        public clsCAPId CAPId { get; set; }
        public clsContact Contact { get; set; }
        public undElements Elements { get; set; }

        // Constructors
        public msgGetContacts()
        {
        }
    }
}
