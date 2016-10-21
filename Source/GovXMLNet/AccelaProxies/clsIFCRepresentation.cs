using System.Collections.Generic;
using System.Xml.Serialization;
// Based on usage in ifc2x_final_stage2_03

/*  Version 7.1 
<xsd:complexType name="Representation">
	<xsd:complexContent>
		<xsd:extension base="elementID">
			<xsd:sequence>
				<xsd:element name="contextOfItems">
					<xsd:complexType>
						<xsd:choice>
							<xsd:element ref="RepresentationContext"/>
						</xsd:choice>
					</xsd:complexType>
				</xsd:element>
				<xsd:element type="Label" minOccurs="0" name="representationIdentifier"/>
				<xsd:element type="Label" minOccurs="0" name="representationType"/>
				<xsd:element name="items">
					<xsd:complexType>
						<xsd:choice maxOccurs="unbounded" minOccurs="1">
							<xsd:element ref="RepresentationItem"/>
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
    public class clsIFCRepresentation : clsIFCelementID
    {
        // Members
        public clsIFCRepresentationContext contextOfItems { get; set; }

        private string _representationIdentifier = null;
        public string representationIdentifier
        {
            get { return _representationIdentifier; }
            set { _representationIdentifier = value; }
        }


        private string _representationType = null;
        public string representationType
        {
            get { return _representationType; }
            set { _representationType = value; }
        }

        [XmlElement(ElementName = "RepresentationItem")]
        public List<clsIFCRepresentationItem> items { get; set; }


        // Constructors
        public clsIFCRepresentation()
        {
        }
    }
}
