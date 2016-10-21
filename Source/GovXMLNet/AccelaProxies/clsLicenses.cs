using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="Licenses">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="License"/>
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
    public class clsLicenses : clsElementList
    {
        // Members
        [XmlElement(ElementName = "License")]
        public List<clsLicense> License { get; set; }

        // Constructors
        public clsLicenses()
        {
        }

        // Methods
        public void Add(string pLicenseType, string pLicenseNumber)
        {
            if (License == null)
            {
                License = new List<clsLicense>();
            }
            License.Add(new clsLicense(pLicenseType, pLicenseNumber));
        }
    }
}
