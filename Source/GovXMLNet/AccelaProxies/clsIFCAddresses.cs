// Based on usage in ifc2x_final_stage2_03 defined in "Person" type as array of abstract type "Address"

/* Version Last Modified: 7.1 
				<xsd:element minOccurs="0" name="addresses">
					<xsd:complexType>
						<xsd:choice maxOccurs="unbounded" minOccurs="1">
							<xsd:element ref="Address"/>
						</xsd:choice>
					</xsd:complexType>
				</xsd:element>
*/


/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 2/14/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class clsIFCAddresses
    {
        //[XmlElement(ElementName = "Address")]
        //public List<clsIFCAddress> Address { get; set; }
        public clsIFCPostalAddress PostalAddress { get; set; }
        public clsIFCTelecomAddress TelecomAddress { get; set; }
        public clsIFCAddresses()
        {
        }
    }
}
