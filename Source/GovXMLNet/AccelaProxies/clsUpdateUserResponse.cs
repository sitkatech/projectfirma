// Defined in AccelaOperationRepository_Authentication

/* Version Last Modified: 6.7
  <xsd:complexType name="UpdateUserResponse">
    <xsd:complexContent>
      <xsd:extension base="OperationResponse">
        <xsd:sequence minOccurs="0" maxOccurs="1">
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
    public class clsUpdateUserResponse : clsOperationResponse
    {
        // Members
        public clsUser User { get; set; }

        // Constructors
        public clsUpdateUserResponse()
        {
        }
    }
}
