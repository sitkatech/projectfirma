// Defined in AccelaOperationRepository_GIS

/* Version Last Modified: 6.7
	<xsd:complexType name="PassGISObjects">
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
					<xsd:element ref="MapServiceId" minOccurs="0"/>
					<xsd:element ref="SystemId" minOccurs="0"/>
					<xsd:element name="command" type="xsd:string" form="qualified" minOccurs="0"/>
					<xsd:element ref="GISObjects" minOccurs="0"/>
					<xsd:element ref="Extent" minOccurs="0"/>
					<xsd:element ref="GISLayerGroupIds" minOccurs="0"/>
					<xsd:element name="showRoute" type="xsd:boolean" default="false" form="qualified" minOccurs="0"/>
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
    public class msgPassGISObjects : clsOperationRequest
    {
        // Members
        public lctPassGISObjectsReturnElements returnElements { get; set; }

        public clsMapServiceId MapServiceId { get; set; }

        private string _SystemId = null;
        public string SystemId
        {
            get { return _SystemId; }
            set { _SystemId = value; }
        }

        private string _command = null;
        public string command
        {
            get { return _command; }
            set { _command = value; }
        }

        public clsGISObjects GISObjects { get; set; }

        public clsExtent Extent { get; set; }

        public clsGISLayerGroupIds GISLayerGroupIds { get; set; }

        private bool? _showRoute = null;
        public bool? showRoute
        {
            get
            {
                if (_showRoute.HasValue)
                {
                    return _showRoute.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _showRoute = value; }
        }
        public bool currentValueSpecified
        {
            get { return _showRoute != null; }
        }

        // Constructors
        public msgPassGISObjects()
        {
        }
    }
}
