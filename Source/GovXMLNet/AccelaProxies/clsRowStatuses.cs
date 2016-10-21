using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLSystemDataObjects

/* Version Last Modified: 6.7
   <xsd:complexType name="RowStatuses">
    <xsd:sequence minOccurs="1" maxOccurs="unbounded">
      <xsd:element ref="RowStatus"/>
    </xsd:sequence>
    <xsd:attribute name="elementCount" type="xsd:positiveInteger" use="optional"/>
    <xsd:attribute name="elementList" type="xsd:string" use="optional"/>
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
    class clsRowStatuses
    {
        // Members
        [XmlElement(ElementName = "RowStatus")]
        public List<clsRowStatus> RowStatus { get; set; }

        // Note can't get nullable uint to serialize as an attribute so just checking to see if it is zero
        private uint _elementCount = 0;
        [XmlAttribute("elementCount")]
        public uint elementCount
        {
            get { return _elementCount; }
            set { _elementCount = value; }
        }
        public bool elementCountSpecified
        {
            get { return _elementCount != 0; }
        }

        private string _elementList;
        [XmlAttribute("elementList")]
        public string elementList
        {
            get { return _elementList; }
            set { _elementList = value; }
        }

        // Constructors
        public clsRowStatuses()
        {
        }
    }
}
