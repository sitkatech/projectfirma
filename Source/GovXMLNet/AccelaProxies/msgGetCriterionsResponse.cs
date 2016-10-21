// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="GetCriterionsResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence>
					<xsd:element ref="CriterionGroups" minOccurs="0"/>
					<xsd:element ref="EnumerationLists" minOccurs="0"/>
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
    public class msgGetCriterionsResponse : clsOperationResponse
    {
        // Members
        public clsCriterionGroups CriterionGroups { get; set; }
        public clsEnumerationLists EnumerationLists { get; set; }

        // Constructors
        public msgGetCriterionsResponse()
        {
        }
    }
}
