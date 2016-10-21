using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="AdditionalInformationSubGroup">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence>
          <xsd:element ref="Keys" minOccurs="0"/>
          <xsd:element ref="IdentifierDisplay" minOccurs="0"/>
          <xsd:element ref="AdditionalItems" minOccurs="0"/>
          <xsd:element name="security" type="xsd:string" form="qualified" minOccurs="0"/>
          <xsd:element name="type" type="structuralTypeEnum" />
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

    public class clsAdditionalInformationSubGroup : clsElement
    {
        // Members
        public clsKeys Keys { get; set; }

        private string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        public clsAdditionalItems AdditionalItems { get; set; }

        private string _security = null;
        public string security
        {
            get { return _security; }
            set { _security = value; }
        }

        private structuralTypeEnum _type = structuralTypeEnum.ForceExclusion;
        [XmlAttribute("type")]
        public structuralTypeEnum type
        {
            get { return _type; }
            set { _type = value; }
        }
        public bool typeSpecified
        {
            get { return _type != structuralTypeEnum.ForceExclusion; }
        }


        // Constructors
        public clsAdditionalInformationSubGroup()
        {
        }
    }
}
