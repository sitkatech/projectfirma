// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="GetLicenseTypesResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence>
					<xsd:element ref="LicenseTypes" minOccurs="0"/>
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
    public class msgGetLicenseTypesResponse : clsOperationResponse
    {
        // Members
        public clsLicenseTypes LicenseTypes { get; set; }

        // Constructors
        public msgGetLicenseTypesResponse()
        {
        }
    }
}
