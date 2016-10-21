using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="CAPType">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence>
          <xsd:element ref="Keys"/>
          <xsd:element ref="IdentifierDisplay"/>
          <xsd:element name="module" type="xsd:string" minOccurs="0"/>
          <xsd:element ref="AdditionalInformationGroupIds" minOccurs="0"/>
          <xsd:element ref="ConditionTypeIds" minOccurs="0"/>
          <xsd:element ref="Dispositions" minOccurs="0"/>
          <xsd:element ref="HoldTypeIds" minOccurs="0"/>
          <xsd:element ref="InspectionTypeSetIds" minOccurs="0"/>
          <xsd:element ref="Roles" minOccurs="0"/>
          <xsd:element ref="StandardCommentsGroupIds" minOccurs="0"/>
          <xsd:element ref="IVRCode" minOccurs="0" maxOccurs="0"/>
          <xsd:element ref="CapStatusGroupId" minOccurs="0" maxOccurs="0"/>
          <xsd:element ref="GISLayerId" minOccurs="0" maxOccurs="0"/>
          <xsd:element name="GISService" type="xsd:string" minOccurs="0" maxOccurs="0"/>
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
    public class clsCAPType : clsElement
    {
        // Members
        public clsKeys Keys { get; set; }

        private string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        private string _module = null;
        public string module
        {
            get { return _module; }
            set { _module = value; }
        }

        public clsAdditionalInformationGroupIds AdditionalInformationGroupIds { get; set; }
        public clsConditionTypeIds ConditionTypeIds { get; set; }
        public clsDispositions Dispositions { get; set; }
        public clsHoldTypeIds HoldTypeIds { get; set; }
        public clsInspectionTypeSetIds InspectionTypeSetIds { get; set; }
        public clsRoles Roles { get; set; }
        public clsStandardCommentsGroupIds StandardCommentsGroupIds { get; set; }

        private int? _IVRCode = null;
        public int? IVRCode
        {
            get
            {
                if (_IVRCode.HasValue)
                {
                    return _IVRCode.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _IVRCode = value; }
        }
        public bool IVRCodeSpecified
        {
            get { return _IVRCode != null; }
        }

        public clsCapStatusGroupId CapStatusGroupId { get; set; }

        public clsGISLayerId GISLayerId { get; set; }

        private string _GISService = null;
        public string GISService
        {
            get { return _GISService; }
            set { _GISService = value; }
        }

        public undDocumentGroupIds DocumentGroupIds { get; set; }      // Not in definition, but found in response for getCapTypes

        private string _Group = null;   // Not in definition, but found in response for getCapTypes
        public string Group
        {
            get { return _Group; }
            set { _Group = value; }
        }

        private string _Type = null;   // Not in definition, but found in response for getCapTypes
        [XmlElement("SubGroup")]
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        private string _SubType = null;   // Not in definition, but found in response for getCapTypes
        [XmlElement("Category")]
        public string SubType
        {
            get { return _SubType; }
            set { _SubType = value; }
        }

        private string _Category = null;   // Not in definition, but found in response for getCapTypes
        [XmlElement("type")]
        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }


        // Constructors
        public clsCAPType()
        {
        }
    }
}
