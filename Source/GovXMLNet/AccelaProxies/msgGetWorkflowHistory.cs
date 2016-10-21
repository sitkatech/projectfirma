// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
    <xsd:complexType name="GetWorkflowHistory">
        <xsd:complexContent>
            <xsd:extension base="OperationRequest">
                <xsd:sequence>
                    <xsd:element ref="CAPIds"/>
                    <xsd:element name="maxRecord" type="xsd:string" minOccurs="0"/>
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
    public class msgGetWorkflowHistory : clsOperationRequest
    {
        // Members
        public clsCAPIds CAPIds { get; set; }

        private string mMaxRecord = null;
        public string maxRecord
        {
            get { return mMaxRecord; }
            set { mMaxRecord = value; }
        }

        // Constructors
        public msgGetWorkflowHistory()
        {
        }
    }
}
