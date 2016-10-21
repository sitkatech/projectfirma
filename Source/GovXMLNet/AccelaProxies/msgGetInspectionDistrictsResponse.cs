// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="GetInspectionDistrictsResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence>
					<xsd:element ref="InspectionDistricts" minOccurs="0"/>
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
    public class msgGetInspectionDistrictsResponse : clsOperationResponse
    {
        // Members
        public clsInspectionDistricts InspectionDistricts { get; set; }

        // Constructors
        public msgGetInspectionDistrictsResponse()
        {
        }
    }
}
