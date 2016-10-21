// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="EnumerationList">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence>
          <xsd:element name="id" type="enumerationListIdentifier" form="qualified"/>
          <xsd:element name="enumeration" type="StringList" form="qualified"/>
          <xsd:element ref="Enumerations" minOccurs="0" maxOccurs="1"/>
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
    public class clsEnumerationList : clsElement
    {
        // Members
        private string _id = null;
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }

        public clsStringList enumeration { get; set; }

        public clsEnumerations Enumerations { get; set; }

        // Constructors
        public clsEnumerationList()
        {
        }
    }
}
