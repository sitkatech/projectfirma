using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaOperationRepository_GovXML as local complex type

/* Version Last Modified: 6.7
	<xsd:complexType name="GetInspections">
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
					<xsd:element name="collectionsLevelQueryLogic" type="queryLogicEnum" default="OR" form="qualified" minOccurs="0"/>
					<xsd:element name="collectionLevelQueryLogic" type="queryLogicEnum" default="OR" form="qualified" minOccurs="0"/>
					<xsd:choice maxOccurs="unbounded">
						<xsd:group ref="InspectionSearchCollectionSelect"/>
					</xsd:choice>
					<xsd:element name="openInspectionsOnly" type="xsd:boolean" default="false" form="qualified" minOccurs="0"/>
					<xsd:element name="useCachedCAPs" type="xsd:boolean" default="false" form="qualified" minOccurs="0"/>
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
    public class lctGetInspectionsReturnElements
    {
        // Members
        // TODO need example
        [XmlElement(ElementName = "returnElement")]
        public List<lctGetInspectionsReturnElement> returnElements { get; set; }

        // Constructors
        public lctGetInspectionsReturnElements()
        {
        }
    }
}
