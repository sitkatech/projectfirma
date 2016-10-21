// Based on usage in ifc2x_final_stage2_03

/* 
<xsd:complexType name="RepresentationContext">
	<xsd:complexContent>
		<xsd:extension base="elementID">
			<xsd:sequence>
				<xsd:element type="Label" minOccurs="0" name="contextIdentifier"/>
				<xsd:element type="Label" minOccurs="0" name="contextType"/>
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
    public class clsIFCRepresentationContext : clsIFCelementID
    {
        // Members
        private string _contextIdentifier = null;
        public string contextIdentifier
        {
            get { return _contextIdentifier; }
            set { _contextIdentifier = value; }
        }

        private string _contextType = null;
        public string contextType
        {
            get { return _contextType; }
            set { _contextType = value; }
        }

        // Constructors
        public clsIFCRepresentationContext()
        {
        }
    }
}
