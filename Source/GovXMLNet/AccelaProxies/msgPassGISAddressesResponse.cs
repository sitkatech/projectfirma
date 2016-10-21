// Defined in AccelaOperationRepository_GIS

/* Version Last Modified: 6.7
	<xsd:complexType name="PassGISAddressesResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence>
					<xsd:element ref="ElectronicFile" minOccurs="0"/>
					<xsd:element ref="UniversalResourceLocator" minOccurs="0"/>
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
    public class msgPassGISAddressesResponse : clsOperationResponse
    {
        // Members
        public clsElectronicFile ElectronicFile { get; set; }

        public clsUniversalResourceLocator UniversalResourceLocator { get; set; }

        // Constructors
        public msgPassGISAddressesResponse()
        {
        }
    }
}
