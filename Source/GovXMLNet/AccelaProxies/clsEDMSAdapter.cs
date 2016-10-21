using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="EDMSAdapter">
    <xsd:complexContent>
      <xsd:extension base="Identifier">
        <xsd:sequence>
          <xsd:element name="Username" type="xsd:string"/>
          <xsd:element name="Password" type="xsd:string"/>
          <xsd:element name="default" type="xsd:string" form="qualified" minOccurs="0"/>
          <xsd:element name="requiresPassword" type="xsd:string" form="qualified" minOccurs="0"/>
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
    public class clsEDMSAdapter : clsIdentifier
    {
        // Members
        private string _Username = null;
        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        private string _Password = null;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private string _Default = null;
        [XmlElement("default")]
        public string Default
        {
            get { return _Default; }
            set { _Default = value; }
        }

        private string _requiresPassword = null;
        public string requiresPassword
        {
            get { return _requiresPassword; }
            set { _requiresPassword = value; }
        }

        // Constructors
        public clsEDMSAdapter()
        {
        }
    }
}
