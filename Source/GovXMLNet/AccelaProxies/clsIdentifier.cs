// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="Identifier" abstract="true">
		<xsd:complexContent>
			<xsd:extension base="element">
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
 * Date: 2/14/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class clsIdentifier //: clsElement
    {
        // Members
        public clsKeys Keys { get; set; }
        
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
        public clsIdentifier()
        {
        }

        public clsIdentifier(string[] pKeys)
        {
            if (Keys == null)
            {
                Keys = new clsKeys(pKeys);
            }
        }

    }
}
