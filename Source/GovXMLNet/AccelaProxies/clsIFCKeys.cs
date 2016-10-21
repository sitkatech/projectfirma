using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in ifc2x_final_stage2_03

/* Version Last Modified: 7.1
<xsd:complexType name="Keys">
	<xsd:complexContent>
		<xsd:extension base="elementIDList">
			<xsd:sequence minOccurs="0" maxOccurs="unbounded">
				<xsd:element ref="Key"/>
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
    public class clsIFCKeys : clsIFCelementIDList
    {
        // Members
        [XmlElement(ElementName = "Key")]
        public List<string> Key { get; set; }

        // Constructors
        public clsIFCKeys()
        {
        }
    }
}
