// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
  <xsd:complexType name="ScheduleInspection">
    <xsd:complexContent>
      <xsd:extension base="OperationRequest">
        <xsd:sequence>
          <xsd:element name="validatingLicenses" type="Licenses" form="qualified" minOccurs="0"/>
          <xsd:element ref="Inspection"/>
          <xsd:element ref="ReturnElements"/>
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
    public class msgScheduleInspection : clsOperationRequest
    {
        // Members
        public clsLicenses validatingLicenses { get; set; }

        public clsInspection Inspection { get; set; }

        public undReturnElements ReturnElements { get; set; }

        // Constructors
        public msgScheduleInspection()
        {
        }
    }
}
