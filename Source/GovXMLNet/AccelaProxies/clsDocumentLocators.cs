// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="DocumentLocators">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="DocumentLocator"/>
				</xsd:sequence>
			</xsd:extension>
		</xsd:complexContent>
	</xsd:complexType>
*/

/*
 * The reference to DocumentLocator is an abstract complex type.  Which results in the classes based
 * on DocumentLocator to be included instead of DocumentLocator.
*/ 

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 2/14/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class clsDocumentLocators : clsElementList
    {
        // Members
        // TODO need example, this was based on an abstract
        public clsElectronicFileLocator ElectronicFileLocator { get; set; }
        public clsPhysicalDocumentLocator PhysicalDocumentLocator { get; set; }

        // Constructors
        public clsDocumentLocators()
        {
        }
    }
}
