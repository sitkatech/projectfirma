// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="InitiateCAPResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence>
					<xsd:choice>
						<xsd:element ref="CAP"/>
						<xsd:element ref="CAPId"/>
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
    public class msgInitiateCAPResponse : clsOperationResponse
    {
        // Members
        private clsCAP _CAP = null;
        public clsCAP CAP
        {
            get { return _CAP; }
            set
            {
                _CAP = value;
                ChoiceClearAllBut(eChoiceInitiateCAPResponse.scCAP);
            }
        }

        private clsCAPId _CAPId = null;
        public clsCAPId CAPId
        {
            get { return _CAPId; }
            set
            {
                _CAPId = value;
                ChoiceClearAllBut(eChoiceInitiateCAPResponse.scCAPId);
            }
        }

        // Constructors
        public msgInitiateCAPResponse()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceInitiateCAPResponse pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceInitiateCAPResponse.scCAP)
            {
                _CAP = null;
            }
            if (pSelectedChoice != eChoiceInitiateCAPResponse.scCAPId)
            {
                _CAPId = null;
            }
        }
    }
}
