// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
	<xsd:complexType name="GetStandardChoicesResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence minOccurs="0">
				  <xsd:element name="standardChoiceType" type="xsd:string" minOccurs="0" maxOccurs="1" />
					<xsd:element name="StandardChoices" ref="Enumerations" minOccurs="0"/>
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
    public class msgGetStandardChoicesResponse : clsOperationResponse
    {
        // Members
        private string mStandardChoiceType;
        public string standardChoiceType
        {
            get { return mStandardChoiceType; }
            set { mStandardChoiceType = value; }
        }

        public clsEnumerations StandardChoices { get; set; }

        // Constructors
        public msgGetStandardChoicesResponse()
        {
        }

    }
}
