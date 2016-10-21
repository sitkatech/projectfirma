// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
    <xsd:complexType name="GetWorkflowHistoryResponse">
        <xsd:complexContent>
            <xsd:extension base="OperationResponse">
                <xsd:sequence>
                    <xsd:element ref="TaskItems"/>
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
    public class msgGetWorkflowHistoryResponse : clsOperationResponse
    {
        // Members
        public clsTaskItems TaskItems { get; set; }

        // Constructors
        public msgGetWorkflowHistoryResponse()
        {
        }
    }
}
