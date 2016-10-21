// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="GISAttributeMapping">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence>
          <xsd:element name="GISAttribute" type="xsd:string" minOccurs="0"/>
          <xsd:element name="AAAtribute" type="xsd:string" minOccurs="0"/>
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
    public class clsGISAttributeMapping : clsElement
    {
        // Members
        private string _GISAttribute = null;
        public string GISAttribute
        {
            get { return _GISAttribute; }
            set { _GISAttribute = value; }
        }

        private string _AAAtribute = null;
        public string AAAtribute
        {
            get { return _AAAtribute; }
            set { _AAAtribute = value; }
        }

        // Constructors
        public clsGISAttributeMapping()
        {
        }
    }
}
