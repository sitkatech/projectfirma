// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="UpdateInspectionResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence>
					<xsd:choice minOccurs="0">
						<xsd:element ref="Inspection" minOccurs="0"/>
						<xsd:element ref="InspectionId" minOccurs="0"/>
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
    public class msgUpdateInspectionResponse : clsOperationResponse
    {
       // Begin Choice
        public clsInspection _Inspection = null;
        public clsInspection Inspection
        {
            get { return _Inspection; }
            set
            {
                _Inspection = value;
                ChoiceClearAllBut(eChoiceUpdateInspectionResponse.scInspection);
            }
        }

        public clsInspectionId _InspectionId = null;
        public clsInspectionId InspectionId
        {
            get { return _InspectionId; }
            set
            {
                _InspectionId = value;
                ChoiceClearAllBut(eChoiceUpdateInspectionResponse.scInspectionId);
            }
        }

        // End choice

        // Constructors
        public msgUpdateInspectionResponse()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceUpdateInspectionResponse pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceUpdateInspectionResponse.scInspection)
            {
                _Inspection = null;
            }
            if (pSelectedChoice != eChoiceUpdateInspectionResponse.scInspectionId)
            {
                _InspectionId = null;
            }
        }
    }
}
