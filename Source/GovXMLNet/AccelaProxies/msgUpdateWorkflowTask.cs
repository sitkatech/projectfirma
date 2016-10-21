// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
	</xsd:complexType>
    <xsd:complexType name="UpdateWorkflowTask">
        <xsd:complexContent>
            <xsd:extension base="OperationRequest">
                <xsd:sequence>
                    <xsd:element ref="CAPId"/>
                    <xsd:element ref="TaskItem"/>
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
    public class msgUpdateWorkflowTask : clsOperationRequest
    {
        // Members
        public clsCAPId CAPId { get; set; }
        public clsTaskItem TaskItem { get; set; }

        // Constructors
        public msgUpdateWorkflowTask()
        {
        }
    }
}
