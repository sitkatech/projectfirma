// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="BufferLayer">
		<xsd:complexContent>
			<xsd:extension base="element">
				<xsd:sequence>
					<xsd:element ref="GISObjectType" maxOccurs="unbounded"/>
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
    public class clsBufferLayer : clsElement
    {
        // Members
        public clsGISObjectType GISObjectType { get; set; }

        // Constructors
        public clsBufferLayer()
        {
        }
    }
}
