using System.Xml.Serialization;

// Defined in AccelaSystemDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="TransactionResults">
    <xsd:sequence minOccurs="1" maxOccurs="unbounded">
      <xsd:element ref="TransactionResult"/>
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
    public class clsTransactionResults
    {
        // Members      
        public clsTransactionResult TransactionResult { get; set; }

        // Note can't get nullable uint to serialize as an attribute so just checking to see if it is zero
        private uint _elementCount = 0;
        [XmlAttribute()]
        public uint elementCount
        {
            get { return _elementCount; }
            set { _elementCount = value; }
        }
        public bool elementCountSpecified
        {
            get { return _elementCount != 0; }
        }
        

        private string _elementList = null;
        [XmlAttribute()]
        public string elementList
        {
            get { return _elementList; }
            set { _elementList = value; }
        }        
        public bool elementListSpecified
        {
            get { return _elementList != null; }
        }
        
        // Constructors
        public clsTransactionResults()
        {
        }
    }
}
