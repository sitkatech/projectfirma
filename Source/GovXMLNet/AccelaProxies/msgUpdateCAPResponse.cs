// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="UpdateCAPResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence minOccurs="0">
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
    public class msgUpdateCAPResponse : clsOperationResponse
    {
        // Members
        // Begin choice
        private clsCAP _CAP = null;
        public clsCAP CAP
        {
            get { return _CAP; }
            set
            {
                _CAP = value;
                ChoiceClearAllBut(eChoiceUpdateCAPResponse.scCAP);
            }
        }

        private clsCAPId _CAPId = null;
        public clsCAPId CAPId
        {
            get { return _CAPId; }
            set
            {
                _CAPId = value;
                ChoiceClearAllBut(eChoiceUpdateCAPResponse.scCAPId);
            }
        }
        // End choice

        // Constructors
        public msgUpdateCAPResponse()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceUpdateCAPResponse pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceUpdateCAPResponse.scCAP)
            {
                _CAP = null;
            }
            if (pSelectedChoice != eChoiceUpdateCAPResponse.scCAPId)
            {
                _CAPId = null;
            }
        }
    }
}
