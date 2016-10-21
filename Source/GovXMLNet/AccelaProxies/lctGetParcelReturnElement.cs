using System.Xml.Serialization;

// Defined in AccelaOperationRepository_GovXML as local complex type

/* Version Last Modified: 6.7
	<xsd:complexType name="GetParcel">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element name="returnElements" form="qualified" minOccurs="0">
						<xsd:complexType>
							<xsd:sequence maxOccurs="unbounded">
								<xsd:element name="returnElement" form="qualified">
									<xsd:complexType>
										<xsd:simpleContent>
											<xsd:extension base="parcelDetailReturnEnum">
												<xsd:attribute name="detailLevels" type="xsd:nonNegativeInteger" use="optional"/>
											</xsd:extension>
										</xsd:simpleContent>
									</xsd:complexType>
								</xsd:element>
							</xsd:sequence>
						</xsd:complexType>
					</xsd:element>
					<xsd:element ref="ParcelId"/>
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
    public class lctGetParcelReturnElement
    {
        // Members
        // TODO need example
        private parcelDetailReturnEnum _returnElement;
        public parcelDetailReturnEnum returnElement
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
        public lctGetParcelReturnElement()
        {
        }
    }
}
