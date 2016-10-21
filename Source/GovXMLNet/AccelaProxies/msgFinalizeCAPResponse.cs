// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="FinalizeCAPResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence minOccurs="0">
					<xsd:choice>
						<xsd:element ref="CAP"/>
						<xsd:element ref="CAPId"/>
					</xsd:choice>
					<xsd:element name="contextType" type="finalizeCAPResponseContextTypeEnum" form="qualified" minOccurs="0"/>
					<xsd:element ref="Status" minOccurs="0"/>
					<xsd:element ref="Text" minOccurs="0"/>
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
    public class msgFinalizeCAPResponse : clsOperationResponse
    {
        // Members
        // Begin Choice
        private clsCAP _CAP = null;
        public clsCAP CAP
        {
            get { return _CAP; }
            set
            {
                _CAP = value;
                ChoiceClearAllBut(eChoiceFinalizeCAPResponse.scCAP);
            }
        }

        private clsCAPId _CAPId = null;
        public clsCAPId CAPId
        {
            get { return _CAPId; }
            set
            {
                _CAPId = value;
                ChoiceClearAllBut(eChoiceFinalizeCAPResponse.scCAPId);
            }
        }
        // End Choice        

        private finalizeCAPResponseContextTypeEnum? _contextType = null;
        public finalizeCAPResponseContextTypeEnum? contextType
        {
            get
            {
                if (_contextType.HasValue)
                {
                    return _contextType.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _contextType = value; }
        }
        public bool contextTypeSpecified
        {
            get { return _contextType != null; }
        }

        public clsStatus Status { get; set; }

        private string _Text = null;
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }

        // Constructors
        public msgFinalizeCAPResponse()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceFinalizeCAPResponse pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceFinalizeCAPResponse.scCAP)
            {
                _CAP = null;
            }
            if (pSelectedChoice != eChoiceFinalizeCAPResponse.scCAPId)
            {
                _CAPId = null;
            }
        }
    }
}
