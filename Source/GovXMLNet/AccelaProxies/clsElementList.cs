using System.Xml.Serialization;

// Defined in ifc2x_final_stage2_03

/*
 * Note:  For some reason XmlAttribute does not work with nullable objects so setting as regular and suppressing on 0
*/
/* Version Last Modified: 6.7
	<xsd:complexType name="elementList" abstract="true">
		<xsd:complexContent>
			<xsd:extension base="element">
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
    public class clsElementList : clsElement
    {
        // Members
        private uint _elementCount;
        [XmlAttribute("elementCount")]
        public uint elementCount
        {
            get { return _elementCount; }
            set { _elementCount = value; }
        }
        public bool elementCountSpecified
        {
            get { return _elementCount != 0; }
        }

        // Constructors
        public clsElementList()
        {
        }
    }
}
