// Defined in AccelaSharedDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="Option">
    <xsd:sequence>
      <xsd:sequence minOccurs="0" maxOccurs="1">
        <xsd:element name="source" type="xsd:string" form="qualified"/>
        <xsd:element name="context" type="xsd:string" form="qualified"/>
        <xsd:element name="type" form="qualified">
          <xsd:simpleType>
            <xsd:restriction base="xsd:string">
              <xsd:enumeration value="Configuration"/>
              <xsd:enumeration value="Display"/>
              <xsd:enumeration value="Processing"/>
            </xsd:restriction>
          </xsd:simpleType>
        </xsd:element>
      </xsd:sequence>
      <xsd:element name="Name" type="xsd:string" form="qualified"/>
      <xsd:element name="Value" type="xsd:string" form="qualified"/>
    </xsd:sequence>
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
    public class clsOption
    {
        // Members
        private string _source = null;
        public string source
        {
            get { return _source; }
            set { _source = value; }
        }

        private string _context = null;
        public string context
        {
            get { return _context; }
            set { _context = value; }
        }

        private enumOptionType _type;
        public enumOptionType type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _Name = null;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Value = null;
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        // Constructors
        public clsOption()
        {
        }
    }
}
