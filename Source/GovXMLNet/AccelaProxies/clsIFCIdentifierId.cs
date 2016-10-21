// Defined in ifc2x_final_stage2_03

/* Version Last Modified: 7.1
<xsd:complexType name="IdentifierId">
	<xsd:complexContent>
		<xsd:extension base="elementID">
			<xsd:choice>
				<xsd:sequence>
					<xsd:element ref="Keys"/>
					<xsd:element ref="IdentifierDisplay" minOccurs="0"/>
				</xsd:sequence>
				<xsd:sequence>
					<xsd:element ref="Value"/>
				</xsd:sequence>
			</xsd:choice>
		</xsd:extension>
	</xsd:complexContent>
</xsd:complexType>
*/

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 4/14/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class clsIFCIdentifierId
    {
        // Members
        public clsIFCKeys Keys { get; set; }

        private string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        private string _Value = null;
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        // Constructors
        public clsIFCIdentifierId()
        {
        }
    }
}
