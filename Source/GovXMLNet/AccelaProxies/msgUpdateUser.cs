// Defined in AccelaOperationRepository_Authentication

/* Version Last Modified: 6.7
  <xsd:complexType name="UpdateUser">
    <xsd:complexContent>
      <xsd:extension base="OperationRequest">
        <xsd:sequence>
          <xsd:element name="contextType" type="datasetChangeEnum" form="qualified"/>
          <xsd:element ref="User"/>
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
    public class msgUpdateUser : clsOperationRequest
    {
        // Members
        private datasetChangeEnum _contextType;
        public datasetChangeEnum contextType
        {
            get { return _contextType; }
            set { _contextType = value; }
        }

        public clsUser User { get; set; }

        // Constructors
        public msgUpdateUser()
        {
        }
    }
}
