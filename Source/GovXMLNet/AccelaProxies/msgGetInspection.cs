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
    public class msgGetInspection : clsOperationRequest
    {
        // Members
        public lctGetInspectionReturnElements returnElements { get; set; }
        public clsLicenses validatingLicenses { get; set; }

        // Start Choice
        private string _ConfirmationNumber = null;
        public string ConfirmationNumber
        {
            get { return _ConfirmationNumber; }
            set
            {
                _ConfirmationNumber = value;
                ChoiceClearAllBut(eChoiceGetInspection.scConfirmationNumber);
            }
        }

        public clsInspectionId _InspectionId = null;
        public clsInspectionId InspectionId
        {
            get { return _InspectionId; }
            set
            {
                _InspectionId = value;
                ChoiceClearAllBut(eChoiceGetInspection.scInspectionId);
            }
        }
        // End Choice

        // Constructors
        public msgGetInspection()
        {
        }


        // Methods
        private void ChoiceClearAllBut(eChoiceGetInspection pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceGetInspection.scConfirmationNumber)
            {
                _ConfirmationNumber = null;
            }
            if (pSelectedChoice != eChoiceGetInspection.scInspectionId)
            {
                _InspectionId = null;
            }
        }
    }
}
