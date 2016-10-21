// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
	<xsd:complexType name="UpdateAssetCAResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse" >
				<xsd:sequence>
					<xsd:element ref="AssetCA"/>
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
    public class msgUpdateAssetCAResponse : clsOperationResponse
    {
        // Members
        public clsAssetCA AssetCA { get; set; }

        // Constructors
        public msgUpdateAssetCAResponse()
        {
        }
    }
}
