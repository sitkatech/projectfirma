// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
  <xsd:complexType name="GetAssetUsagesResponse">
    <xsd:complexContent>
      <xsd:extension base="OperationResponse">
        <xsd:sequence minOccurs="0">
          <xsd:element ref="Usages" minOccurs="0"/>
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
    public class msgGetAssetUsagesResponse : clsOperationResponse
    {
        // Members
        public clsUsages Usages { get; set; }

        // Constuctors
        public msgGetAssetUsagesResponse()
        {
        }
    }
}
