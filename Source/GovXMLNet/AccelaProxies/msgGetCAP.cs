// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="GetCAP">
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
					<xsd:element ref="CAPId"/>
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
    public class msgGetCAP : clsOperationRequest
    {
        // Members
        public lctGetCAPReturnElements returnElements { get; set; }
        public clsLicenses validatingLicenses { get; set; }
        public clsCAPId CAPId { get; set; }

        // Constructors
        public msgGetCAP()
        {
        }

        public msgGetCAP(clsCAPId capID)
        {
            CAPId = capID;
        }

        public msgGetCAP(string pB1PerId1, string pB1PerId2, string pB1PerId3)
        {
            CAPId = new clsCAPId(pB1PerId1, pB1PerId2, pB1PerId3);
        }
    }
}
