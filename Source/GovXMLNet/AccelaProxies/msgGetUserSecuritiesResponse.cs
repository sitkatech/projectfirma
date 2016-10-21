// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
  <xsd:complexType name=" GetUserSecuritiesResponse">
    <xsd:complexContent>
      <xsd:extension base="OperationResponse">
        <xsd:sequence minOccurs="0">
          <xsd:element name =" Securities" ref=" Entities" minOccurs="0"/>
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
    public class msgGetUserSecuritiesResponse : clsOperationResponse
    {
        // Members
        public clsEntities Securities { get; set; }

        // Constructors
        public msgGetUserSecuritiesResponse()
        {
        }
    }
}
