// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="GetCitiesResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence minOccurs="0">
					<xsd:element ref="Cities" minOccurs="0"/>
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
    public class msgGetCitiesResponse : clsOperationResponse
    {
        // Members
        public clsCities Cities { get; set; }

        // Constructors
        public msgGetCitiesResponse()
        {
        }
    }
}
