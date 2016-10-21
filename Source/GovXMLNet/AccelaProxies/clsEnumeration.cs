// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="Enumeration">
    <xsd:complexContent>
      <xsd:extension base="Attachment">
        <xsd:sequence>
          <xsd:element name="String" type="xsd:string" minOccurs="0"/>
          <xsd:element ref="Keys" minOccurs="0"/>
          <xsd:element name="EnumerationType" type="xsd:string" minOccurs="0"/>
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
    public class clsEnumeration : clsAttachment
    {
        // Members
        private string _String = null;
        public string String
        {
            get { return _String; }
            set { _String = value; }
        }

        // public clsKeys Keys { get; set; } should be inherited from clsAttachment which inherits from clsEntity

        private string _EnumerationType = null;
        public string EnumerationType
        {
            get { return _EnumerationType; }
            set { _EnumerationType = value; }
        }


        // Constructors
        public clsEnumeration()
        {
        }
    }
}
