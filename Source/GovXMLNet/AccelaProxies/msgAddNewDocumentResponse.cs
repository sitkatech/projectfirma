// Defined in AccelaOperationRepository_Authentication

/* Version Last Modified: 6.7
	<xsd:complexType name="AddNewDocumentResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence>
					<xsd:element ref="TransactionResults" minOccurs="0"/>
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
    public class msgAddNewDocumentResponse : clsOperationResponse
    {
        // Members
        public clsTransactionResults TransactionResults { get; set; }

        // Constructors
        public msgAddNewDocumentResponse()
        {
        }
    }
}
