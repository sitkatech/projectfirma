// Defined in AccelaOperationRepository_GIS

/* Version Last Modified: 6.7
	<xsd:complexType name="GetGISObjectsByBufferRadiusResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence>
					<xsd:element ref="BufferObjects" minOccurs="0"/>
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
    public class msgGetGISObjectsByBufferRadiusResponse : clsOperationResponse
    {
        // Members
        public clsBufferObjects BufferObjects { get; set; }

        // Constructors
        public msgGetGISObjectsByBufferRadiusResponse()
        {
        }
    }
}
