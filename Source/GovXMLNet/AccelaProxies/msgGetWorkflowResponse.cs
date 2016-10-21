// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
    <xsd:complexType name="GetWorkflowResponse">
        <xsd:complexContent>
            <xsd:extension base="OperationResponse">
                <xsd:sequence>
                    <xsd:element ref="CAPId"/>
                    <xsd:element ref="Process"/>
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
    public class msgGetWorkflowResponse : clsOperationResponse
    {
        // Members
        public clsCAPId CAPId { get; set; }
        public clsProcess Process { get; set; }

        // Constructors
        public msgGetWorkflowResponse()
        {
        }
    }
}
