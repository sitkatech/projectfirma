// Defined in AccelaOperationRepository_Authentication

/* Version Last Modified: 6.7
	<xsd:complexType name="CancelInspectionResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence minOccurs="0">
					<xsd:choice minOccurs="0">
						<xsd:element ref="Inspection"/>
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
    public class msgCancelInspectionResponse : clsOperationResponse
    {
        // Members

        // Begin Choice
        private clsInspection _Inspection = null;
        public clsInspection Inspection
        {
            get { return _Inspection; }
            set
            {
                _Inspection = value;
                ChoiceClearAllBut(eChoiceCancelInspectionResponse.scInspection);
            }
        }

        private clsInspectionId _InspectionId = null;
        public clsInspectionId InspectionId
        {
            get { return _InspectionId; }
            set
            {
                _InspectionId = value;
                ChoiceClearAllBut(eChoiceCancelInspectionResponse.scInspectionId);
            }
        }
        // End Choice
        private string _ConfirmationNumber = null;
        public string ConfirmationNumber
        {
            get { return _ConfirmationNumber; }
            set { _ConfirmationNumber = value; }
        }


        // Constructors
        public msgCancelInspectionResponse()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceCancelInspectionResponse pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceCancelInspectionResponse.scInspection)
            {
                _Inspection = null;
            }
            if (pSelectedChoice != eChoiceCancelInspectionResponse.scInspectionId)
            {
                _InspectionId = null;
            }
        }
    }
}
