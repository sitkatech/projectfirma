using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="ElectronicSignatures">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="ElectronicSignature"/>
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
    public class clsElectronicSignatures : clsElementList
    {
        // Members
        [XmlElement(ElementName = "ElectronicSignature")]
        public List<clsElectronicSignature> ElectronicSignature { get; set; }

        // Constructors
        public clsElectronicSignatures()
        {
        }
    }
}
