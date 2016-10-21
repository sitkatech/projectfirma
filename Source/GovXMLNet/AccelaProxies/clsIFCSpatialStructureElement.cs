// Defined in ifc2x_final_stage2_03

/* Version Last Modified: 6.7
<xsd:complexType abstract="true" name="SpatialStructureElement">
	<xsd:complexContent>
		<xsd:extension base="Product">
			<xsd:sequence>
				<xsd:element type="Identifier" minOccurs="0" name="longName"/>
				<xsd:element type="ElementCompositionEnum" name="compositionType"/>
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
    public class clsIFCSpatialStructureElement : clsIFCProduct
    {
        // Members
        private string _longName = null;
        public string longName
        {
            get { return _longName; }
            set { _longName = value; }
        }

        private ElementCompositionEnum _compositionType;
        public ElementCompositionEnum compositionType
        {
            get { return _compositionType; }
            set { _compositionType = value; }
        }

        // Constructors
        public clsIFCSpatialStructureElement()
        {
        }

    }
}
