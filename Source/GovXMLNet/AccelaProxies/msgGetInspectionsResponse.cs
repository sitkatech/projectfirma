// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="GetInspectionsResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence minOccurs="0">
					<xsd:element ref="InspectionSheets"/>
					<xsd:element ref="CAPs" minOccurs="0"/>
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
    public class msgGetInspectionsResponse : clsOperationResponse
    {
        // Members
        public clsInspectionSheets InspectionSheets { get; set; }
        public clsCAPs CAPs { get; set; }

        // Constructors
        public msgGetInspectionsResponse()
        {
        }
    }
}
