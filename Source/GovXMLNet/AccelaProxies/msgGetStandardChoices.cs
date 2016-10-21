// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
	<xsd:complexType name="GetStandardChoices">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest"/>
			<xsd:element name="StandardChoiceType" type="StandardChoiceTypeEnum" default="OR" form="qualified" minOccurs="0"/>
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
    public class msgGetStandardChoices : clsOperationRequest
    {
        // Members
        /* StandardChoiceTypeEnum is not defined
        private StandardChoiceTypeEnum _StandardChoiceType;
        public StandardChoiceTypeEnum StandardChoiceType
        {
            get { return _StandardChoiceType; }
            set { _StandardChoiceType = value; }
        }
        */

        // Constructors
        public msgGetStandardChoices()
        {
        }
    }
}
