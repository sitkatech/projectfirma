// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
	<xsd:complexType name="UpdateAssetCA">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest" >
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
    public class msgUpdateAssetCA : clsOperationRequest
    {
        // Members
        public clsAssetCA AssetCA { get; set; }

        // Constructors
        public msgUpdateAssetCA()
        {
        }
    }
}
