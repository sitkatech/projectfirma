// Defined in AccelaOperationRepository_System

/* Version Last Modified: 6.7
  <xsd:complexType name="SystemExecuteOperation">
    <xsd:complexContent>
      <xsd:extension base="OperationRequest">
        <xsd:sequence>
          <xsd:element name="operationName" type="xsd:string" form="qualified"/>
          <xsd:element ref="Options" minOccurs="0" maxOccurs="1"/>
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
    public class msgSystemExecuteOperation : clsOperationRequest
    {
        // Members
        private string _operationName = null;
        public string operationName
        {
            get { return _operationName; }
            set { _operationName = value; }
        }

        // public clsOptions Options { get; set; } Should be included in clsOperationRequest

        // Constructors
        public msgSystemExecuteOperation()
        {
        }

    }
}
