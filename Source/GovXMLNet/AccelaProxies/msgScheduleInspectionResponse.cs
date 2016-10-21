// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="ScheduleInspectionResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence minOccurs="0">
					<xsd:choice minOccurs="0">
						<xsd:element ref="Inspection"/>
						<xsd:element ref="InspectionId"/>
					</xsd:choice>
					<xsd:element ref="ConfirmationNumber" minOccurs="0"/>
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
    public class msgScheduleInspectionResponse : clsOperationResponse
    {
        // Begin Choice
        private clsInspection _Inspection = null;
        public clsInspection Inspection
        {
            get { return _Inspection; }
            set
            {
                _Inspection = value;
                ChoiceClearAllBut(eChocieScheduleInspectionResponse.scInspection);
            }
        }

        private clsInspectionId _InspectionId = null;
        public clsInspectionId InspectionId
        {
            get { return _InspectionId; }
            set
            {
                _InspectionId = value;
                ChoiceClearAllBut(eChocieScheduleInspectionResponse.scInspectionId);
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
        public msgScheduleInspectionResponse()
        {
        }

        
        // Methods
        private void ChoiceClearAllBut(eChocieScheduleInspectionResponse pSelectedChoice)
        {
            if (pSelectedChoice != eChocieScheduleInspectionResponse.scInspection)
            {
                _Inspection = null;
            }
            if (pSelectedChoice != eChocieScheduleInspectionResponse.scInspectionId)
            {
                _InspectionId = null;
            }
        }

    }
}
