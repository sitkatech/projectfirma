// Defined in AccelaOperationRepository_Base

/* Version Last Modified: 7.1
  <xsd:complexType name="BatchOperation">
    <xsd:complexContent>
      <xsd:extension base="OperationRequest">
        <xsd:sequence>
          <xsd:element name="batchOperationId" type="xsd:string" minOccurs="0" maxOccurs="1" form="qualified"/>
          <xsd:element name="asynchronousMode" type="xsd:boolean" default="false" minOccurs="0" maxOccurs="1" form="qualified"/>
          <xsd:element name="continueOnError" type="xsd:boolean" default="true" minOccurs="0" maxOccurs="1" form="qualified"/>
          <xsd:element name="operations" form="qualified">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="operation" minOccurs="1" maxOccurs="unbounded" form="qualified">
                  <xsd:complexType>
                    <xsd:sequence>
                      <xsd:element ref="OperationRequest"/>
                    </xsd:sequence>
                  </xsd:complexType>
                </xsd:element>
              </xsd:sequence>
            </xsd:complexType>
          </xsd:element>
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
    public class clsBatchOperation : clsOperationRequest
    {
        // Members
        private string _batchOperationId = null;
        public string batchOperationId
        {
            get { return _batchOperationId; }
            set { _batchOperationId = value; }
        }

        private bool? _asynchronousMode = false;
        public bool? asynchronousMode
        {
            get { return _asynchronousMode; }
            set { _asynchronousMode = value; }
        }
        public bool asynchronousModeSpecified
        {
            get { return _asynchronousMode != null; }
        }

        private bool? _continueOnError = true;
        public bool? continueOnError
        {
            get { return _continueOnError; }
            set { _continueOnError = value; }
        }
        public bool continueOnErrorSpecified
        {
            get { return _continueOnError != null; }
        }

        public lctBatchOperationOperations operations { get; set; }

        // Constructors
        public clsBatchOperation()
        {
        }
    }
}
