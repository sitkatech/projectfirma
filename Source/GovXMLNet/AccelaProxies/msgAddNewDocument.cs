// Defined in AccelaOperationRepository_Authentication

/* Version Last Modified: 6.7
	<xsd:complexType name="AddNewDocument">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element ref="Documents"/>
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
    public class msgAddNewDocument : clsOperationRequest
    {
        // Members
        public clsDocuments Documents { get; set; }

        // Constructors
        public msgAddNewDocument()
        {
        }
    }
}
