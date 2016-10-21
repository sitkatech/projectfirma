// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
    <xsd:complexType name="GetWorkflowTaskStatusValues">
	    <xsd:complexContent>
		    <xsd:extension base="OperationRequest">
			    <xsd:sequence>
				    <xsd:element ref="CAPId"/>
                    <xsd:element name="processCode" type="xsd:string"  minOccurs="0"/>
                    <xsd:element name="taskDescription" type="xsd:string"  minOccurs="0"/>
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
    public class msgGetWorkflowTaskStatusValues : clsOperationRequest
    {
        // Members
        public clsCAPId CAPId { get; set; }

        private string mProcessCode = null;
        public string processCode
        {
            get { return mProcessCode; }
            set { mProcessCode = value; }
        }

        private string mTaskDescription = null;
        public string taskDescription
        {
            get { return mTaskDescription; }
            set { mTaskDescription = value; }
        }

        // Constructors
        public msgGetWorkflowTaskStatusValues()
        {
        }
    }
}
