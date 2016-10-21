using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="Addresses">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:group ref="AddressSelect"/>
				</xsd:sequence>
			</xsd:extension>
		</xsd:complexContent>
	</xsd:complexType>
*/

/*
	<xsd:group name="AddressSelect">
		<xsd:choice>
			<xsd:element ref="CompactAddress"/>
			<xsd:element ref="DetailAddress"/>
		</xsd:choice>
	</xsd:group>
 */

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 2/14/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class clsAddresses : clsElementList
    {
        enum eChoiceAddressSelect
        {
            scCompactAddress,
            scDetailAddress
        }

        // TODO need example
        // Members
        // Start Group AddressSelect
        // Start Choice
        private List<clsCompactAddress> _CompactAddress = null;
        [XmlElement(ElementName = "CompactAddress")]
        public List<clsCompactAddress> CompactAddress
        {
            get { return _CompactAddress; }
            set
            {
                _CompactAddress = value;
                //ChoiceClearAllBut(eChoiceAddressSelect.scCompactAddress);  Disabled choice because both are found in response
            }
        }


        private List<clsDetailAddress> _DetailAddress = null;
        [XmlElement(ElementName = "DetailAddress")]
        public List<clsDetailAddress> DetailAddress
        {
            get { return _DetailAddress; }
            set
            {
                _DetailAddress = value;
                //ChoiceClearAllBut(eChoiceAddressSelect.scCompactAddress);  Disabled choice because both are found in response
            }
        }
        // End Choice
        // End Group AddressSelect

        // Constructors
        public clsAddresses()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceAddressSelect pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceAddressSelect.scCompactAddress)
            {
                _CompactAddress = null;
            }
            if (pSelectedChoice != eChoiceAddressSelect.scDetailAddress)
            {
                _DetailAddress = null;
            }
        }
    }
}
