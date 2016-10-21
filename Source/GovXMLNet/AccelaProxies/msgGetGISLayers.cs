// Defined in AccelaOperationRepository_GIS

/* Version Last Modified: 6.7
	<xsd:complexType name="GetGISLayers">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element ref="MapServiceId"/>
					<xsd:element name="returnElements" form="qualified" minOccurs="0">
						<xsd:complexType>
							<xsd:sequence maxOccurs="unbounded">
								<xsd:element name="returnElement" form="qualified">
									<xsd:complexType>
										<xsd:simpleContent>
											<xsd:extension base="gisLayersEnum"/>
										</xsd:simpleContent>
									</xsd:complexType>
								</xsd:element>
							</xsd:sequence>
						</xsd:complexType>
					</xsd:element>
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
    public class msgGetGISLayers : clsOperationRequest
    {
        // Members
        public clsMapServiceId MapServiceId { get; set; }
        public lctGetGisLayersReturnElements returnElements { get; set; }

        // Constructors
        public msgGetGISLayers()
        {
        }
    }
}
