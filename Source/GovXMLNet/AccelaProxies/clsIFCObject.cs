// Defined in ifc2x_final_stage2_03

/* Version Last Modified: 6.7
<xsd:complexType abstract="true" name="Object">
	<xsd:complexContent>
		<xsd:extension base="Root">
			<xsd:sequence>
				<xsd:element type="Label" minOccurs="0" name="objectType"/>
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
    public class clsIFCObject : clsIFCRoot
    {
        private string _objectType = null;
        public string objectType
        {
            get { return _objectType; }
            set { _objectType = value; }
        }

        // Initializations
        public clsIFCObject()
        {
        }
    }
}
