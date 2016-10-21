// Defined in AccelaOperationRepository_Base

/* Version Last Modified: 6.7
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
    public class msgBatchOperation : clsOperationRequest
    {
        // Members
        private string _batchOperationId = null;
        public string batchOperationId
        {
            get { return _batchOperationId; }
            set { _batchOperationId = value; }
        }

        private bool? _asynchronousMode;
        public bool? asynchronousMode
        {
            get
            {
                if (_asynchronousMode.HasValue)
                {
                    return _asynchronousMode.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _asynchronousMode = value; }
        }
        public bool asynchronousModeSpecified
        {
            get { return _asynchronousMode != null; }
        }

        private bool? _continueOnError;
        public bool? continueOnError
        {
            get
            {
                if (_continueOnError.HasValue)
                {
                    return _continueOnError.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _continueOnError = value; }
        }
        public bool continueOnErrorSpecified
        {
            get { return _continueOnError != null; }
        }

        public lctOperationsRequest Operations { get; set; }

        // Constructors
        public msgBatchOperation()
        {
        }
    }
}
