// Defined in AccelaOperationRepository_System

/* Version Last Modified: 6.7
  <xsd:complexType name="SystemGetConfigurationResponse">
    <xsd:complexContent>
      <xsd:extension base="OperationResponse">
        <xsd:sequence>
          <xsd:element ref="OptionSets" minOccurs="0" maxOccurs="1"/>
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
    public class msgSystemGetConfigurationResponse : clsOperationResponse
    {
        // Members
        public clsOptionSets OptionSets { get; set; }

        // Constructors
        public msgSystemGetConfigurationResponse()
        {
        }
    }
}
