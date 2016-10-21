// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
	<xsd:complexType name="GetAssetCAsResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse" >
				<xsd:sequence>
					<xsd:element ref="AssetCAs"/>
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
    public class msgGetAssetCAsResponse : clsOperationResponse
    {
        // Members
        public clsAssetCAs AssetCAs { get; set; }

        // Constructors
        public msgGetAssetCAsResponse()
        {
        }
    }
}
