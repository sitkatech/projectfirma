// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="GetStandardCommentsResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence>
					<xsd:choice minOccurs="0">
						<xsd:element ref="StandardComments" minOccurs="0"/>
						<xsd:element ref="StandardCommentsGroups" minOccurs="0"/>
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
    public class msgGetStandardCommentsResponse : clsOperationResponse
    {
        // Members
        // Begin choice
        private clsStandardComments _StandardComments = null;
        public clsStandardComments StandardComments
        {
            get { return _StandardComments; }
            set
            {
                _StandardComments = value;
                ChoiceClearAllBut(eChoiceGetStandardCommentsResponse.scStandardComments);
            }
        }
        private clsStandardCommentsGroups _StandardCommentsGroups = null;
        public clsStandardCommentsGroups StandardCommentsGroups
        {
            get { return _StandardCommentsGroups; }
            set
            {
                _StandardCommentsGroups = value;
                ChoiceClearAllBut(eChoiceGetStandardCommentsResponse.scStandardCommentsGroups);
            }
        }
        // End choice

        // Constructors
        public msgGetStandardCommentsResponse()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceGetStandardCommentsResponse pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceGetStandardCommentsResponse.scStandardComments)
            {
                _StandardComments = null;
            }
            if (pSelectedChoice != eChoiceGetStandardCommentsResponse.scStandardCommentsGroups)
            {
                _StandardCommentsGroups = null;
            }
        }
    }
}
