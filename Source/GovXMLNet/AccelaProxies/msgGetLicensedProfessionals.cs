// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
  <xsd:complexType name="GetLicensedProfessionals">
    <xsd:complexContent>
      <xsd:extension base="OperationRequest">
        <xsd:sequence>
          <xsd:element ref="ifc:Person" minOccurs="0"/>
          <xsd:element ref="ifc:Organization" minOccurs="0"/>
          <xsd:element ref="ifc:PersonAndOrganization" minOccurs="0"/>
          <xsd:element ref="License" minOccurs="0"/>
          <xsd:element ref="ReturnElements" minOccurs="0"/>
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
    public class msgGetLicensedProfessionals : clsOperationRequest
    {
        // Members
        public clsIFCPerson Person { get; set; }
        public clsIFCOrganization Organization { get; set; }
        public clsIFCPersonAndOrganization PersonAndOrganization { get; set; }
        public clsLicense License { get; set; }
        public undReturnElements ReturnElements { get; set; }

        // Constructors
        public msgGetLicensedProfessionals()
        {
        }
    }
}
