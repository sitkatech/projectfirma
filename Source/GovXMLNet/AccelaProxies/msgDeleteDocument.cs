// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="DeleteDocument">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element ref="DocumentId"/>
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
    public class msgDeleteDocument : clsOperationRequest       
    {
        // Members
        public clsDocumentId DocumentId { get; set; }

        // Constructors
        public msgDeleteDocument()
        {
        }
    }
}
