using System.Xml.Serialization;

// Defined in AccelaSystemDataObjects

/* Version Last Modified: 6.7
  <xsd:complexType name="TransactionResult">
    <xsd:sequence minOccurs="0" maxOccurs="1">
      <xsd:element ref="Fault"/>
    </xsd:sequence>
    <xsd:attribute name="element" type="xsd:positiveInteger" use="optional"/>
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
    public class clsTransactionResult
    {
        // Members
        public clsFault Fault;

        private uint _element = 0;  // Can't use nullable type because it is an attribute
        [XmlAttribute("element")]
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
        public clsTransactionResult()
        {
        }
    }
}
