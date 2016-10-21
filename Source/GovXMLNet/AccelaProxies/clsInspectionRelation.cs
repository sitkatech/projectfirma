using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="InspectionRelation">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence>
          <xsd:element ref="Keys" minOccurs="0" />
          <xsd:element name="identifierDisplay" type="xsd:string" minOccurs="0" maxOccurs="0"
          <xsd:element name="value" type="xsd:string" minOccurs="0" maxOccurs="0"
          <xsd:element name="contextType" type="capRelationContextTypeEnum" form="qualified" minOccurs="0"/>
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
    public class clsInspectionRelation : clsElement
    {
        // Members
        public clsKeys Keys { get; set; }

        private string _identifierDisplay = null;
        public string identifierDisplay
        {
            get { return _identifierDisplay; }
            set { _identifierDisplay = value; }
        }

        private string _Value = null;
        [XmlElement("value")]
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        private capRelationContextTypeEnum? _contextType = null;
        public capRelationContextTypeEnum? contextType
        {
            get
            {
                if (_contextType.HasValue)
                {
                    return _contextType.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _contextType = value; }
        }
        public bool contextTypeSpecified
        {
            get { return _contextType != null; }
        }

        // Constructors
        public clsInspectionRelation()
        {
        }

    }
}
