// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="UniversalResourceLocator">
		<xsd:complexContent>
			<xsd:extension base="DocumentLocator">
				<xsd:sequence>
					<xsd:element name="location" type="xsd:string" form="qualified"/>
					<xsd:element ref="ElectronicSignature" minOccurs="0"/>
					<xsd:element ref="ElectronicFileUploaded" minOccurs="0"/>
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
    public class clsUniversalResourceLocator : clsDocumentLocator
    {
        // Members
        private string _location = null;
        public string location
        {
            get { return _location; }
            set { _location = value; }
        }

        public clsElectronicSignature ElectronicSignature { get; set; }
        public clsElectronicFileUploaded ElectronicFileUploaded { get; set; }

        // Constructors
        public clsUniversalResourceLocator()
        {
        }
    }
}
