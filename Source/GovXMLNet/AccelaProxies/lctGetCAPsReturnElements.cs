using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaOperationRepository_GovXML as local complexType

/* Version Last Modified: 6.7
	<xsd:complexType name="GetCAPs">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element name="returnElements" form="qualified" minOccurs="0">
						<xsd:complexType>
							<xsd:sequence maxOccurs="unbounded">
								<xsd:element name="returnElement" form="qualified">
									<xsd:complexType>
										<xsd:simpleContent>
											<xsd:extension base="capDetailReturnEnum">
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
						<xsd:group ref="CAPsSearchCollectionSelect"/>
					</xsd:choice>
					<xsd:element name="useCachedCAPs" type="xsd:boolean" default="false" form="qualified" minOccurs="0"/>
					<xsd:element name="withOpenInspectionsOnly" type="xsd:boolean" default="false" form="qualified" minOccurs="0"/>
					<xsd:element name="withUnassignedInspectionsOnly" type="xsd:boolean" default="false" form="qualified" minOccurs="0"/>
					<xsd:element name="withOutstandingFeeDueOnly" type="xsd:boolean" default="false" form="qualified" minOccurs="0"/>
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
    public class lctGetCAPsReturnElements
    {
        // Members
        // TODO need example
        [XmlElement(ElementName = "returnElement")]
        public List<lctGetCAPsReturnElement> returnElements { get; set; }

        // Constructors
        public lctGetCAPsReturnElements()
        {
        }
    }
}
