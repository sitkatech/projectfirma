using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="element" abstract="true">
    <xsd:complexContent>
      <xsd:extension base="ifc:elementID">
        <xsd:attribute name="action" type="dataitemChangeEnum" use="optional"/>
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
    public class clsElement : clsIFCelementID
    {
        // Members
        // Don't set this to be a nullable enumeration as it will not serialize correctly
        private dataitemChangeEnum _action = dataitemChangeEnum.ForceExclusion;
        [XmlAttribute("action")]
        public dataitemChangeEnum action
        {
            get { return _action; }
            set { _action = value; }
        }
        public bool actionSpecified
        {
            get { return _action != dataitemChangeEnum.ForceExclusion; }
        }

        // Constructors
        public clsElement()
        {
        }
    }
}
