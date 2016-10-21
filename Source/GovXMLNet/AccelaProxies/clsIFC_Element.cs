// Defined in ifc2x_final_stage2_03

/*
 * Do not confuse this with Element defined in this file with element defined in ifc2x_final_stage2_03.
 * The XSD files are case sensitive.  This mixed case element definition is used as fields in other 
 * classes
*/

/* Version Last Modified: 7.1
<xsd:complexType abstract="true" name="Element">
	<xsd:complexContent>
		<xsd:extension base="Product">
			<xsd:sequence>
				<xsd:element type="Identifier" minOccurs="0" name="tag"/>
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
    public class clsIFCElement : clsIFCProduct
    {
        // Members
        private string _tag = null;
        public string tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        // Constructors
        public clsIFCElement()
        {
        }

    }
}
