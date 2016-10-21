// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="BufferObjects">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence>
					<xsd:element ref="GISObjectTypes"/>
					<xsd:element ref="GISObjects"/>
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
    public class clsBufferObjects : clsElementList
    {
        // Members
        // TODO need example, these may need to be put into a struct
        public clsGISObjectTypes GISObjectTypes { get; set; }
        public clsGISObjects GISObjects { get; set; }

        // Constructors
        public clsBufferObjects()
        {
        }
    }
}
