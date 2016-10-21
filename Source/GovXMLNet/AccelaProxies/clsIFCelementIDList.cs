using System.Xml.Serialization;

// Defined in ifc2x_final_stage2_03

/* Version Last Modified: 7.1
<xsd:complexType name="elementIDList" abstract="true">
	<xsd:complexContent>
		<xsd:extension base="elementID">
			<xsd:attribute name="elementCount" type="xsd:nonNegativeInteger" use="optional"/>
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
    public class clsIFCelementIDList : clsIFCelementID
    {
        // Members
        private uint _elementCount = 0;
        [XmlAttribute("elementCount")]
        public uint elementCount
        {
            get { return _elementCount; }
            set { _elementCount = value; }
        }
        // Here we turn serialization of the elementCount on/off per the value 
        public bool elementCountSpecified
        {
            get { return _elementCount != 0; }
        }
        

    }
}
