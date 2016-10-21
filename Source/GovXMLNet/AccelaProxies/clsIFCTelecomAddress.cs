using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in ifc2x_final_stage2_03

/* Version Last Modified: 6.7
<xsd:complexType name="TelecomAddress">
	<xsd:complexContent>
		<xsd:extension base="Address">
			<xsd:sequence>
				<xsd:element minOccurs="0" name="telephoneNumbers">
					<xsd:complexType>
						<xsd:choice maxOccurs="unbounded" minOccurs="1">
							<xsd:element type="Label" name="String"/>
						</xsd:choice>
					</xsd:complexType>
				</xsd:element>
				<xsd:element minOccurs="0" name="facsimileNumbers">
					<xsd:complexType>
						<xsd:choice maxOccurs="unbounded" minOccurs="1">
							<xsd:element type="Label" name="String"/>
						</xsd:choice>
					</xsd:complexType>
				</xsd:element>
				<xsd:element type="Label" minOccurs="0" name="pagerNumber"/>
				<xsd:element minOccurs="0" name="electronicMailAddresses">
					<xsd:complexType>
						<xsd:choice maxOccurs="unbounded" minOccurs="1">
							<xsd:element type="Label" name="String"/>
						</xsd:choice>
					</xsd:complexType>
				</xsd:element>
				<xsd:element type="Label" minOccurs="0" name="wWWHomePageURL"/>
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
    public class clsIFCTelecomAddress : clsIFCAddress
    {
        // Members
        private List<string> _telephoneNumbers = null;
        [XmlArray("telephoneNumbers")]
        [XmlArrayItem("String")]
        public List<string> telephoneNumbers
        {
            get { return _telephoneNumbers; }
            set { _telephoneNumbers = value; }
        }
        public bool telephoneNumbersSpecified
        {
            get { return _telephoneNumbers != null && _telephoneNumbers.Count > 0; }
        }

        private List<string> _facsimileNumbers = null;
        [XmlArray("facsimileNumbers")]
        [XmlArrayItem("String")]
        public List<string> facsimileNumbers
        {
            get { return _facsimileNumbers; }
            set { _facsimileNumbers = value; }
        }
        public bool facsimileNumbersSpecified
        {
            get { return _facsimileNumbers != null && _facsimileNumbers.Count > 0; }
        }

        private string _pagerNumber = null;
        public string pagerNumber
        {
            get { return _pagerNumber; }
            set { _pagerNumber = value; }
        }

        private List<string> _electronicMailAddresses = null;
        [XmlArray("electronicMailAddresses")]
        [XmlArrayItem("String")]
        public List<string> electronicMailAddresses 
        {
            get { return _electronicMailAddresses; }
            set { _electronicMailAddresses = value; }
        }
        public bool electronicMailAddressesSpecified
        {
            get { return _electronicMailAddresses != null && _electronicMailAddresses.Count > 0; }
        }

        private string _wWWHomePageURL = null;
        public string wWWHomePageURL
        {
            get { return _wWWHomePageURL; }
            set { _wWWHomePageURL = value; }
        }

        // Constructors
        public clsIFCTelecomAddress()
        {
        }
    }
}
