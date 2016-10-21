using System.Xml.Serialization;

// Defined in ifc2x_final_stage2_03

/* Version Last Modified: 7.1
<xsd:complexType name="elementID">
	<xsd:attribute use="optional" type="xsd:ID" name="id"/>
	<xsd:attribute use="optional" type="xsd:IDREF" name="href"/>
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
    public class clsIFCelementID
    {
        // Members
        private string _ID = null;
        [XmlAttribute("ID")]
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public bool IDSpecified
        {
            get { return _ID != null; }
        }

        private string _IDREF = null;
        [XmlAttribute("IDREF")]
        public string IDREF
        {
            get { return _IDREF; }
            set { _IDREF = value; }
        }
        public bool IDREFSpecified
        {
            get { return _IDREF != null; }
        }

        // Constructors
        public clsIFCelementID()
        {
        }
    }
}
