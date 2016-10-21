using System.Xml.Serialization;

// Defined in AccelaGovXMLSystemDataObjects

/* Version Last Modified: 6.7
   <xsd:complexType name="RowStatus">
    <xsd:complexContent>
      <xsd:extension base="Error">
        <xsd:attribute name="element" type="xsd:positiveInteger" use="optional"/>
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
    class clsRowStatus : clsError
    {
        // Members
        private uint _element = 0;
        [XmlAttribute(AttributeName="element", DataType = "positiveInteger")]
        public uint element
        {
            get { return _element; }
            set { _element = value; }
        }
        public bool elementSpecified
        {
            get { return _element != 0; }
        }

        // Constructors
        public clsRowStatus()
        {
        }
    }
}
