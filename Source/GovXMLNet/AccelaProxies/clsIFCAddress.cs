// Defined in ifc2x_final_stage2_03

/* Version Last Modified: 7.1
<xsd:complexType abstract="true" name="Address">
	<xsd:complexContent>
		<xsd:extension base="elementID">
			<xsd:sequence>
				<xsd:element type="AddressTypeEnum" minOccurs="0" name="purpose"/>
				<xsd:element type="Text" minOccurs="0" name="description"/>
				<xsd:element type="Label" minOccurs="0" name="userDefinedPurpose"/>
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
    public class clsIFCAddress : clsIFCelementID
    {
        // Members
        private AddressTypeEnum? _purpose = null;
        public AddressTypeEnum? purpose
        {
            get
            {
                if (_purpose.HasValue)
                {
                    return _purpose.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _purpose = value; }
        }
        public bool purposeSpecified
        {
            get { return _purpose != null; }
        }


        private string _description = null;
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _userDefinedPurpose = null;
        public string userDefinedPurpose
        {
            get { return _userDefinedPurpose; }
            set { _userDefinedPurpose = value; }
        }

        public clsIFCPostalAddress PostalAddress { get; set; }
        public clsIFCTelecomAddress TelecomAddress { get; set; }

        // Constructors
        public clsIFCAddress()
        {
        }
    }
}
