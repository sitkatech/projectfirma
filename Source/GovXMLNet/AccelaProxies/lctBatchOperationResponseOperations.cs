using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaOperationRepository_Base as local complex type

/* Version Last Modified: 7.1
  <xsd:complexType name="BatchOperationResponse">
    <xsd:complexContent>
      <xsd:extension base="OperationResponse">
        <xsd:sequence>
          <xsd:element name="batchOperationId" type="xsd:string" minOccurs="0" maxOccurs="1" form="qualified"/>
          <xsd:element name="operations" form="qualified">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="operation" minOccurs="1" maxOccurs="unbounded" form="qualified">
                  <xsd:complexType>
                    <xsd:sequence>
                      <xsd:choice>
                        <xsd:element ref="OperationResponse"/>
                        <xsd:element ref="Fault"/>
                      </xsd:choice>
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
    class lctBatchOperationResponseOperations
    {
        // Members
        // TODO need example
        [XmlElement(ElementName = "operation")]
        public List<lctBatchOperationResponseOperation> operations { get; set; }

        // Constructors
        public lctBatchOperationResponseOperations()
        {
            operations = new List<lctBatchOperationResponseOperation>();
        }
    }
}
