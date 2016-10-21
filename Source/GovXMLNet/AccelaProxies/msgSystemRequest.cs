// Defined in AccelaOperationRepository_Authentication

/* Version Last Modified: 6.7
  <xsd:complexType name="SystemRequest">
    <xsd:complexContent>
      <xsd:extension base="OperationRequest">
        <xsd:sequence minOccurs="0" maxOccurs="1">
          <xsd:element ref="Username"/>
          <xsd:element ref="Password"/>
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
    public class msgSystemRequest : clsOperationRequest
    {
        // Members
        private string _Username = null;
        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        private string _Password = null;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        // Constructors
        public msgSystemRequest()
        {
        }
    }
}
