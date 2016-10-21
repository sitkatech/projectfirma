// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
    <xsd:complexType name="TimeAccountingGroup">
      <xsd:complexContent>
        <xsd:extension base="Identifier">
          <xsd:sequence>
            <xsd:element ref=" TimeAccountingTypes " minOccurs="0" maxOccurs="1" />
            <xsd:element name="security" type="xsd:string" minOccurs="0" maxOccurs="1" />
          </xsd:sequence>
        </xsd:extension>
      </xsd:complexContent>
    </xsd:complexType>
*/

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 4/11/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class clsTimeAccountingGroup : clsIdentifier
    {
        // Members
        public clsTimeAccountingTypes TimeAccountingTypes { get; set; }

        private string _security = null;
        public string security
        {
            get { return _security; }
            set { _security = value; }
        }

        // Constructors
        public clsTimeAccountingGroup()
        {
        }
    }
}
