// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
	<xsd:complexType name="GetAssetCAStatusResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence>
					<xsd:element ref="Dispositions"/>
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
    public class msgGetAssetCAStatusResponse : clsOperationResponse
    {
        // Members
        public clsDispositions Dispositions { get; set; }

        // Constructors
        public msgGetAssetCAStatusResponse()
        {
        }
    }
}
