// Defined in AccelaOperationRepository_GIS

/* Version Last Modified: 6.7
	<xsd:complexType name="ViewGISMap">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element name="returnElements" form="qualified" minOccurs="0">
						<xsd:complexType>
							<xsd:sequence maxOccurs="unbounded">
								<xsd:element name="returnElement" form="qualified">
									<xsd:complexType>
										<xsd:simpleContent>
											<xsd:extension base="gisPassViewReturnEnum">
												<xsd:attribute name="detailLevels" type="xsd:nonNegativeInteger" use="optional"/>
											</xsd:extension>
										</xsd:simpleContent>
									</xsd:complexType>
								</xsd:element>
							</xsd:sequence>
						</xsd:complexType>
					</xsd:element>
					<xsd:element ref="MapServiceId"/>
					<xsd:element ref="SystemId" minOccurs="0"/>
					<xsd:element ref="GISLayerGroupIds" minOccurs="0"/>
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
    public class msgViewGISMap : clsOperationRequest
    {
        // Members
        public lctViewGISMapReturnElements returnElements { get; set; }

        public clsMapServiceId MapServiceId { get; set; }

        private string _SystemId = null;
        public string SystemId
        {
            get { return _SystemId; }
            set { _SystemId = value; }
        }

        public clsGISLayerGroupIds GISLayerGroupIds { get; set; }

        // Constructors
        public msgViewGISMap()
        {
        }
    }
}
