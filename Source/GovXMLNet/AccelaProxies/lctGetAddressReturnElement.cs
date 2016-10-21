using System.Xml.Serialization;

// Defined in AccelaOperationRepository_GovXML defined as local complex type

/* Version Last Modified: 6.7
	<xsd:complexType name="GetAddress">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element name="returnElements" form="qualified" minOccurs="0">
						<xsd:complexType>
							<xsd:sequence maxOccurs="unbounded">
								<xsd:element name="returnElement" form="qualified">
									<xsd:complexType>
										<xsd:simpleContent>
											<xsd:extension base="addressDetailReturnEnum">
												<xsd:attribute name="detailLevels" type="xsd:nonNegativeInteger" use="optional"/>
											</xsd:extension>
										</xsd:simpleContent>
									</xsd:complexType>
								</xsd:element>
							</xsd:sequence>
						</xsd:complexType>
					</xsd:element>
					<xsd:element ref="CompactAddressId"/>
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
    public class lctGetAddressReturnElement 
    {
        // Members
        // TODO need example
        private addressDetailReturnEnum _AddressDetailReturnEnum;
        public addressDetailReturnEnum AddressDetailReturnEnum
        {
            get { return _AddressDetailReturnEnum; }
            set { _AddressDetailReturnEnum = value; }
        }

        private uint _detailLevels = 0;
        [XmlAttribute("elementCount")]
        public uint detailLevels
        {
            get { return _detailLevels; }
            set { _detailLevels = value; }
        }

        // Constructors
        public lctGetAddressReturnElement()
        {
        }
    }
}
