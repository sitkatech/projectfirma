// Defined in ifc2x_final_stage2_03

/* Version Last Modified: 6.7
<xsd:complexType name="Application">
	<xsd:complexContent>
		<xsd:extension base="elementID">
			<xsd:sequence>
				<xsd:element name="applicationDeveloper">
					<xsd:complexType>
						<xsd:choice>
							<xsd:element ref="Organization"/>
						</xsd:choice>
					</xsd:complexType>
				</xsd:element>
				<xsd:element type="Label" name="version"/>
				<xsd:element type="Label" name="applicationFullName"/>
				<xsd:element type="Identifier" name="applicationIdentifier"/>
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
    public class clsIFCApplication : clsIFCelementID
    {
        // Members
        public clsIFCOrganization applicationDeveloper { get; set; }

        private string _version = null;
        public string version
        {
            get { return _version; }
            set { _version = value; }
        }

        private string _applicationFullName = null;
        public string applicationFullName
        {
            get { return _applicationFullName; }
            set { _applicationFullName = value; }
        }

        private string _applicationIdentifier = null;
        public string applicationIdentifier
        {
            get { return _applicationIdentifier; }
            set { _applicationIdentifier = value; }
        }

        // Constructors
        public clsIFCApplication()
        {
        }
    }
}
