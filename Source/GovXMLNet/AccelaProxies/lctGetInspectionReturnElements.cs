using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="GetInspection">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element name="returnElements" form="qualified" minOccurs="0">
						<xsd:complexType>
							<xsd:sequence maxOccurs="unbounded">
								<xsd:element name="returnElement" form="qualified">
									<xsd:complexType>
										<xsd:simpleContent>
											<xsd:extension base="inspectionDetailReturnEnum">
												<xsd:attribute name="detailLevels" type="xsd:nonNegativeInteger" use="optional"/>
											</xsd:extension>
										</xsd:simpleContent>
									</xsd:complexType>
								</xsd:element>
							</xsd:sequence>
						</xsd:complexType>
					</xsd:element>
					<xsd:element name="validatingLicenses" type="Licenses" form="qualified" minOccurs="0"/>
					<xsd:choice>
						<xsd:element ref="ConfirmationNumber"/>
						<xsd:element ref="InspectionId"/>
					</xsd:choice>
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
    public class lctGetInspectionReturnElements
    {
        // Members
        // TODO need example
        [XmlElement(ElementName = "returnElement")]
        public List<lctGetInspectionReturnElement> returnElements { get; set; }

        // Constructors
        public lctGetInspectionReturnElements()
        {
        }
    }
}
