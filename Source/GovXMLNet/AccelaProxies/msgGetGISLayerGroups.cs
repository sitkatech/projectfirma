// Defined in AccelaOperationRepository_GIS

/* Version Last Modified: 6.7
	<xsd:complexType name="GetGISLayerGroups">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element ref="MapServiceId"/>
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
    public class msgGetGISLayerGroups : clsOperationRequest
    {
        // Members
        public clsMapServiceId MapServiceId { get; set; }

        // Constructors
        public msgGetGISLayerGroups()
        {
        }
    }
}
