// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
    <xsd:complexType name="GetWorkflowTaskStatusValuesResponse">
	    <xsd:complexContent>
		    <xsd:extension base="OperationResponse">
			    <xsd:sequence>
                    <xsd:element ref="CAPId"/>
				    <xsd:element ref="Statuses"/>
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
    public class msgGetWorkflowTaskStatusValuesResponse : clsOperationResponse
    {
        // Members
        public clsCAPId CAPId { get; set; }
        public clsStatuses Statuses { get; set; }

            // Constructors
        public msgGetWorkflowTaskStatusValuesResponse()
        {
        }
    }
}
