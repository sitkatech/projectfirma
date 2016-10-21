// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
    <xsd:complexType name="UpdateWorkflowTaskResponse">
        <xsd:complexContent>
            <xsd:extension base="OperationResponse">
                <xsd:sequence minOccurs="0">
                    <xsd:element ref="CAPId"/>
                    <xsd:element name="result" type="xsd:string"  minOccurs="0"/>
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
    public class msgUpdateWorkflowTaskResponse : clsOperationResponse
    {
        // Members
        public clsCAPId CAPId { get; set; }

        private string _result = null;
        public string result
        {
            get { return _result; }
            set { _result = value; }
        }

        // Constructors
        public msgUpdateWorkflowTaskResponse()
        {
        }
    }
}
