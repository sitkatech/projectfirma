using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in ifc2x_final_stage2_03

/* Version Last Modified: 7.1
<xsd:complexType name="PostalAddress">
	<xsd:complexContent>
		<xsd:extension base="Address">
			<xsd:sequence>
				<xsd:element type="Label" minOccurs="0" name="internalLocation"/>
				<xsd:element minOccurs="0" name="addressLines">
					<xsd:complexType>
						<xsd:choice maxOccurs="unbounded" minOccurs="1">
							<xsd:element type="Label" name="String"/>
						</xsd:choice>
					</xsd:complexType>
				</xsd:element>
				<xsd:element type="Label" minOccurs="0" name="postalBox"/>
				<xsd:element type="Label" minOccurs="0" name="town"/>
				<xsd:element ref="TownId" minOccurs="0" maxOccurs="1"/>
				<xsd:element type="Label" minOccurs="0" name="region"/>
				<xsd:element type="Label" minOccurs="0" name="postalCode"/>
				<xsd:element type="Label" minOccurs="0" name="country"/>
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
    public class clsIFCPostalAddress : clsIFCAddress
    {

        private string _internalLocation = null;
        public string internalLocation
        {
            get { return _internalLocation; }
            set { _internalLocation = value; }
        }

        [XmlArray("addressLines")]
        [XmlArrayItem("String")]
        public List<string> addressLines { get; set; }

        private string _postalBox = null;
        public string postalBox
        {
            get { return _postalBox; }
            set { _postalBox = value; }
        }

        private string _town = null;
        public string town
        {
            get { return _town; }
            set { _town = value; }
        }

        public clsIFCTownId TownId { get; set; }

        private string _region = null;
        public string region
        {
            get { return _region; }
            set { _region = value; }
        }

        private string _postalCode = null;
        public string postalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }

        private string _country = null;
        public string country
        {
            get { return _country; }
            set { _country = value; }
        }

        //Constructors
        public clsIFCPostalAddress()
        {
        }
    }
}
