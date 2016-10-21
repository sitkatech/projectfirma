// Defined in AccelaOperationRepository_GIS

/* Version Last Modified: 7.1
	<xsd:complexType name="GetStreetDirectionsResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence minOccurs="0">
					<xsd:element ref="StreetDirections" minOccurs="0"/>
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
    public class msgGetStreetDirectionsResponse : clsOperationResponse
    {
        // Members
        public clsStreetDirections StreetDirections { get; set; }

        // Constructors
        public msgGetStreetDirectionsResponse()
        {
        }
    }
}
