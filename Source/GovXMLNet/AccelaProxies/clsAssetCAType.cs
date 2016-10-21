// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="AssetCAType">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence>
          <xsd:element ref="Keys"/>
          <xsd:element ref="IdentifierDisplay"/>
          <xsd:element name="Description" type="xsd:string" minOccurs="0"/>
          <xsd:element ref="AdditionalInformationGroupIds" minOccurs="0"/>
          <xsd:element name="Observation" type="AdditionalInformation" minOccurs="0"/>
        </xsd:sequence>
      </xsd:extension>
    </xsd:complexContent>
  </xsd:complexType>
*/

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 4/11/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class clsAssetCAType : clsElement
    {
        // Members
        public clsKeys Keys { get; set; }

        private string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        private string _Description = null;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public clsAdditionalInformationGroupIds AdditionalInformationGroupIds { get; set; }
        public clsAdditionalInformation Observation { get; set; }

        // Constructors
        public clsAssetCAType()
        {
        }
    }
}
