using System.Xml.Serialization;

// Defined in AccelaSystemDataObjects

/* Version Last Modified: 6.7
  <xsd:complexType name="TransactionResponses">
    <xsd:sequence minOccurs="1" maxOccurs="unbounded">
      <xsd:element ref="TransactionResults"/>
    </xsd:sequence>
    <xsd:attribute name="elementCount" type="xsd:positiveInteger" use="optional"/>
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
    public class clsTransactionResponses 
    {
        // Members
        public clsTransactionResults TransactionResults = new clsTransactionResults();

        private uint _elementCount = 0;  // Can't use nullable type because attribute
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

        // Constructors
        public clsTransactionResponses()
        {
        }
    }
}
