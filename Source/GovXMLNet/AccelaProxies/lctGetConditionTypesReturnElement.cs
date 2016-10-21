using System.Xml.Serialization;

// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="GetConditionTypes">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element name="returnElements" form="qualified" minOccurs="0">
						<xsd:complexType>
							<xsd:sequence maxOccurs="unbounded">
								<xsd:element name="returnElement" form="qualified">
									<xsd:complexType>
										<xsd:simpleContent>
											<xsd:extension base="conditionTypeReturnEnum">
												<xsd:attribute name="detailLevels" type="xsd:nonNegativeInteger" use="optional"/>
											</xsd:extension>
										</xsd:simpleContent>
									</xsd:complexType>
								</xsd:element>
							</xsd:sequence>
						</xsd:complexType>
					</xsd:element>
					<xsd:element name="contextType" type="getHoldTypesContextTypeEnum" form="qualified" minOccurs="0"/>
					<xsd:element name="collectionsLevelQueryLogic" type="queryLogicEnum" default="OR" form="qualified" minOccurs="0"/>
					<xsd:element name="collectionLevelQueryLogic" type="queryLogicEnum" default="OR" form="qualified" minOccurs="0"/>
					<xsd:choice minOccurs="0" maxOccurs="unbounded">
						<xsd:group ref="ConditionsSearchCollectionSelect"/>
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
    class lctGetConditionTypesReturnElement
    {
        // Members
        // TODO need example
        private conditionTypeReturnEnum _returnElement;
        public conditionTypeReturnEnum returnElement
        {
            get { return _returnElement; }
            set { _returnElement = value; }
        }

        private uint _detailLevels;
        [XmlElementAttribute("detailLevels")]
        public uint detailLevels
        {
            get { return _detailLevels; }
            set { _detailLevels = value; }
        }

        // Constructors
        public lctGetConditionTypesReturnElement()
        {
        }
    }
}
