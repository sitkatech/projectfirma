// Defined in AccelaOperationRepository_Authentication

/* Version Last Modified: 7.1
  <xsd:complexType name="CancelInspection">
    <xsd:complexContent>
      <xsd:extension base="OperationRequest">
        <xsd:sequence>
          <xsd:element name="validatingLicenses" type="Licenses" form="qualified" minOccurs="0"/>
          <xsd:element ref="InspectionId"/>
          <xsd:element name="ResultComment" type="xsd:string"/>
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
    public class msgCancelInspection : clsOperationRequest
    {
        // Members
        public clsLicenses validatingLicenses { get; set; }
        public clsInspectionId InspectionId { get; set; }

        private string _ResultComment = null;
        public string ResultComment
        {
            get { return _ResultComment; }
            set { _ResultComment = value; }
        }


        // Constructors
        public msgCancelInspection()
        {
        }
    }
}
