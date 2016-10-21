// Defined in AccelaOperationRepository_GIS

/* Version Last Modified: 6.7
	<xsd:complexType name="GetGISObjectsResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence>
					<xsd:element ref="GISObjects" minOccurs="0"/>
					<xsd:element ref="GISObjectTypes" minOccurs="0"/>
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
    public class msgGetGISObjectsResponse : clsOperationResponse
    {
        // Members
        public clsGISObjects GISObjects { get; set; }
        public clsGISObjectTypes GISObjectTypes { get; set; }

        // Constructors
        public msgGetGISObjectsResponse()
        {
        }
    }
}
