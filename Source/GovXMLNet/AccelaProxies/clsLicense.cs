using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
  <xsd:complexType name="License">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence>
          <xsd:element name="licenseType" type="text" form="qualified" id="gov_license_licensetype"/>
          <xsd:element ref="LicenseTypeId" minOccurs="0" maxOccurs="1"/>
          <xsd:element name="licenseNumber" type="text" form="qualified" id="gov_license_licensenumber"/>
          <xsd:element name="issuedBy" form="qualified" id="gov_license_issuedby" minOccurs="0">
            <xsd:element ref="AdditionalInformation" minOccurs="0" maxOccurs="0"/>
            <xsd:complexType>
              <xsd:choice>
                <xsd:element ref="ifc:Organization"/>
              </xsd:choice>
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="issuedDate" type="calendarDate" form="qualified" id="gov_license_issueddate" minOccurs="0"/>
          <xsd:element name="expirationDate" type="calendarDate" form="qualified" id="gov_license_expirationdate" minOccurs="0"/>
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
    public class clsLicense : clsElement
    {
        // Members
        private string _licenseType = null;
        public string licenseType
        {
            get { return _licenseType; }
            set 
            { 
                _licenseType = value;
                LicenseTypeId = new clsLicenseTypeId(_licenseType);
            }
        }

        public clsLicenseTypeId LicenseTypeId { get; set; }

        private string _licenseNumber = null;
        public string licenseNumber
        {
            get { return _licenseNumber; }
            set { _licenseNumber = value; }
        }

        private string _issuedBy = null;
        public string issuedBy
        {
            get { return _issuedBy; }
            set { _issuedBy = value; }
        }

        public clsAdditionalInformation AdditionalInformation { get; set; }
        public clsIFCOrganization Organization { get; set; }

        [XmlIgnore]
        public DateTime? issuedDate { get; set; }
        [XmlElement("issuedDate")]
        public string issuedDatetring
        {
            get
            {
                if (issuedDate.HasValue)
                {
                    return issuedDate.Value.ToString(Constants.cDateFormat); ;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                DateTime td;
                if (DateTime.TryParse(value, out td))
                {
                    issuedDate = td;
                }
                else
                {
                    issuedDate = null;
                }
            }
        }
        public bool issuedDateStringSpecified
        {
            get { return issuedDate != null; }
        }

        [XmlIgnore]
        public DateTime? expirationDate { get; set; }
        [XmlElement("expirationDate")]
        public string expirationDateString
        {
            get
            {
                if (expirationDate.HasValue)
                {
                    return expirationDate.Value.ToString(Constants.cDateFormat); ;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                DateTime td;
                if (DateTime.TryParse(value, out td))
                {
                    expirationDate = td;
                }
                else
                {
                    expirationDate = null;
                }
            }
        }
        public bool expirationDateStringSpecified
        {
            get { return expirationDate != null; }
        }

        // Constructors
        public clsLicense()
        {
        }

        public clsLicense(string pLicenseType, string pLicenseNumber)
        {
            licenseType = pLicenseType;
            licenseNumber = pLicenseNumber;
        }

    }
}
