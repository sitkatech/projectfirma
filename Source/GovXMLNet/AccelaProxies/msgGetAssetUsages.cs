// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
  <xsd:complexType name="GetAssetUsages">
    <xsd:complexcontent>
      <xsd:extension base="OperationRequest">
        <xsd:element ref="AssetIds"/>
        <xsd:element name ="previousUsageNumber" type="xsd:string" minOccurs="0"/>
      </xsd:extension>
    </xsd:complexcontent>
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
    public class msgGetAssetUsages : clsOperationRequest
    {
        // Members
        public clsAssetIds AssetIds { get; set; }

        private string _previousUsageNumber = null;
        public string previousUsageNumber
        {
            get { return _previousUsageNumber; }
            set { _previousUsageNumber = value; }
        }

        // Constructors
        public msgGetAssetUsages()
        {
        }
    }
}
