// Defined in AccelaOperationRepository_System

/* Version Last Modified: 6.7
  <xsd:complexType name="SystemChangeConfiguration">
    <xsd:complexContent>
      <xsd:extension base="OperationRequest">
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
    public class msgSystemChangeConfiguration : clsOperationRequest
    {
        // Members
        public clsOptionSets OptionSets { get; set; }

        // Constructors
        public msgSystemChangeConfiguration()
        {
        }
    }
}

