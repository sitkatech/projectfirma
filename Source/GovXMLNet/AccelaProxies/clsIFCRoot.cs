// Defined in ifc2x_final_stage2_03

/* Version Last Modified: 7.1
<xsd:complexType abstract="true" name="Root">
	<xsd:complexContent>
		<xsd:extension base="elementID">
			<xsd:sequence>
				<xsd:element type="GloballyUniqueId" name="globalId" minOccurs="0"/>
				<xsd:element name="ownerHistory" minOccurs="0">
					<xsd:complexType>
						<xsd:choice minOccurs="0">
							<xsd:element ref="OwnerHistory"/>
						</xsd:choice>
					</xsd:complexType>
				</xsd:element>
				<xsd:element type="Label" minOccurs="0" name="name"/>
				<xsd:element type="Text" minOccurs="0" name="description"/>
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
    public class clsIFCRoot : clsIFCelementID
    {
        // Members
        private string _globalId = null;
        public string globalId
        {
            get { return _globalId; }
            set { _globalId = value; }
        }

        public clsIFCOwnerHistory ownerHistory { get; set; }

        private string _name = null;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _description = null;
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        // Constructors
        public clsIFCRoot()
        {
        }
    }
}
