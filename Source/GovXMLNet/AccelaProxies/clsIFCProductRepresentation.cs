using System.Collections.Generic;
using System.Xml.Serialization;
// Defined in ifc2x_final_stage2_03

/* Version Last Modified: 7.1
<xsd:complexType name="ProductRepresentation">
	<xsd:complexContent>
		<xsd:extension base="elementID">
			<xsd:sequence>
				<xsd:element type="Label" minOccurs="0" name="name"/>
				<xsd:element type="Text" minOccurs="0" name="description"/>
				<xsd:element name="representations">
					<xsd:complexType>
						<xsd:choice maxOccurs="unbounded" minOccurs="1">
							<xsd:element ref="Representation"/>
						</xsd:choice>
					</xsd:complexType>
				</xsd:element>
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
    public class clsIFCProductRepresentation : clsIFCelementID
    {
        // Members
        private string _name = null;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _description = null;
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        [XmlElement(ElementName = "Representation")]
        public List<clsIFCRepresentation> representations { get; set; }

        // Initializations
        public clsIFCProductRepresentation()
        {
        }
    }
}
