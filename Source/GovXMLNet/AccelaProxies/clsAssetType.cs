// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="AssetType">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence>
          <xsd:element ref="Keys"/>
          <xsd:element ref="IdentifierDisplay"/>
          <xsd:element ref="Description" minOccurs="0"/>
          <xsd:element ref="AdditionalInformationGroupIds" minOccurs="0"/>
          <xsd:element ref="CAPTypeIds" minOccurs="0" maxOccurs="0"/>
          <xsd:element name="Group" type="xsd:string" minOccurs="0"/>
          <xsd:element name="Type" type="xsd:string" minOccurs="0"/>
          <xsd:element name="GISService" type="xsd:string" minOccurs="0" maxOccurs="0"/>
          <xsd:element ref="GISLayerId" minOccurs="0" maxOccurs="0"/>
          <xsd:element name="GISIDForAssetID" type="xsd:string" minOccurs="0" maxOccurs="0"/>
          <xsd:element ref="GISAttributeMappings" minOccurs="0" maxOccurs="0"/>
          <xsd:element name="classType" type="xsd:string" minOccurs="0"/>
          <xsd:element name="sizeRequired" type="xsd:string" minOccurs="0"/>
          <xsd:element ref="Entities" name="Securities"/>
          <xsd:element name="usageTypes" ref="Types" minOccurs="0"/>
          <xsd:element name="assetSecurity" type="xsd:string" minOccurs="0"/>
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
    public class clsAssetType : clsElement
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
        public clsCAPTypeIds CAPTypeIds { get; set; }

        private string _Group = null;
        public string Group
        {
            get { return _Group; }
            set { _Group = value; }
        }

        private string _Type = null;
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        private string _GISService = null;
        public string GISService
        {
            get { return _GISService; }
            set { _GISService = value; }
        }

        public clsGISLayerId GISLayerId { get; set; }

        private string _GISIDForAssetID = null;
        public string GISIDForAssetID
        {
            get { return _GISIDForAssetID; }
            set { _GISIDForAssetID = value; }
        }

        public clsGISAttributeMappings GISAttributeMappings { get; set; }

        private string _classType = null;
        public string classType
        {
            get { return _classType; }
            set { _classType = value; }
        }

        private string _sizeRequired = null;
        public string sizeRequired
        {
            get { return _sizeRequired; }
            set { _sizeRequired = value; }
        }

        public clsEntities Securities { get; set; }

        public undTypes usageTypes { get; set; }

        private string _assetSecurity = null;
        public string assetSecurity
        {
            get { return _assetSecurity; }
            set { _assetSecurity = value; }
        }

        // Constructors
        public clsAssetType()
        {
        }
    }
}
