// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="SpatialDescriptor" abstract="true">
		<xsd:complexContent>
			<xsd:extension base="element">
				<xsd:sequence>
					<xsd:element ref="Keys" minOccurs="0"/>
					<xsd:element name="source" type="text" form="qualified" minOccurs="0"/>
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
    public class clsSpatialDescriptor : clsElement
    {
        // Members
        public clsKeys Keys { get; set; }

        private string _source = null;
        public string source
        {
            get { return _source; }
            set { _source = value; }
        }


        // Constructors
        public clsSpatialDescriptor()
        {
        }
    }
}
