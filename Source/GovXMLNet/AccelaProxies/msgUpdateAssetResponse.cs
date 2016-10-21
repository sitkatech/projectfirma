// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="UpdateAssetResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence>
					<xsd:choice>
						<xsd:element ref="Asset" minOccurs="0"/>
						<xsd:element ref="AssetId" minOccurs="0"/>
					</xsd:choice>
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
    public class msgUpdateAssetResponse : clsOperationResponse
    {
        // Begin choice
        private clsAsset _Asset = null;
        public clsAsset Asset
        {
            get { return _Asset; }
            set
            {
                _Asset = value;
                ChoiceClearAllBut(eChoiceUpdateAssetResponse.scAsset);
            }
        }

        private clsAssetId _AssetId = null;
        public clsAssetId AssetId
        {
            get { return _AssetId; }
            set
            {
                _AssetId = value;
                ChoiceClearAllBut(eChoiceUpdateAssetResponse.scAssetId);
            }
        }
        // End choice

        // Constructors
        public msgUpdateAssetResponse()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceUpdateAssetResponse pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceUpdateAssetResponse.scAsset)
            {
                _Asset = null;
            }
            if (pSelectedChoice != eChoiceUpdateAssetResponse.scAssetId)
            {
                _AssetId = null;
            }
        }
    }
}
