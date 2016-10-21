// Defined in AccelaOperationRepository_GIS

/* Version Last Modified: 6.7
	<xsd:complexType name="UpdateGISObjects">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element name="before" form="qualified">
						<xsd:complexType>
							<xsd:sequence>
								<xsd:element ref="GISObjectIds"/>
							</xsd:sequence>
						</xsd:complexType>
					</xsd:element>
					<xsd:element name="after" form="qualified">
						<xsd:complexType>
							<xsd:sequence>
								<xsd:element ref="GISObjects"/>
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
    public class msgUpdateGISObjects : clsOperationRequest
    {
        // Members
        // TODO need example on how this really lays out
        public clsGISObjectIds before { get; set; }
        public clsGISObjectIds after { get; set; }

        // Constructors
        public msgUpdateGISObjects()
        {
        }
    }
}
