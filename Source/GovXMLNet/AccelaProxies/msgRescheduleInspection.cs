// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
  <xsd:complexType name="RescheduleInspection">
    <xsd:complexContent>
      <xsd:extension base="OperationRequest">
        <xsd:sequence>
          <xsd:element name="validatingLicenses" type="Licenses" form="qualified" minOccurs="0"/>
          <xsd:element ref="Inspection"/>
          <xsd:element name="reassign" type="xsd:boolean" minOccurs="0"/>
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
    public class msgRescheduleInspection : clsOperationRequest
    {
        // Members
        public clsLicenses validatingLicenses { get; set; }

        public clsInspection Inspection { get; set; }

        private bool? _reassign = false;
        public bool? reassign
        {
            get
            {
                if (_reassign.HasValue)
                {
                    return _reassign.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _reassign = value; }
        }
        public bool reassignSpecified
        {
            get { return _reassign != null; }
        }

        public undReturnElements ReturnElements { get; set; }

        // Constructors
        public msgRescheduleInspection()
        {
        }
    }
}
