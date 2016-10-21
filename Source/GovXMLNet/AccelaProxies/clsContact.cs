using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="Contact">
    <xsd:complexContent>
      <xsd:extension base="People">
        <xsd:sequence>
          <xsd:element ref="Conditions" minOccurs="0"/>
          <xsd:element ref="Holds" minOccurs="0"/>
          <xsd:element ref="Licenses" minOccurs="0"/>
          <xsd:element ref="AdditionalInformation" minOccurs="0"/>
          <xsd:element name="isPrimary" type="xsd:boolean"  minOccurs="0"/>
          <xsd:element ref="ParcelIds" minOccurs="0"/>
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
    public class clsContact : clsPeople
    {
        // Members
        public clsConditions Conditions { get; set; }
        public clsHolds Holds { get; set; }
        public clsLicenses Licenses { get; set; }
        public clsAdditionalInformation AdditionalInformation { get; set; }

        private bool _isPrimary = false;
        [XmlAttribute("isPrimary")]
        public bool isPrimary
        {
            get { return _isPrimary; }
            set { _isPrimary = value; }
        }

        public clsParcelIds ParcelIds { get; set; }

        // Constructors
        public clsContact()
        {
        }

        public clsContact(long pG1ContactNbr)
        {
            if (Keys == null)
            {
                Keys = new clsKeys(new string[] { pG1ContactNbr.ToString(), "contact" });
            }
            else
            {
                if (Keys.Key == null)
                {
                    Keys.Key = new List<string>();
                }
                else
                {
                    Keys.Key.Clear();
                }
                Keys.Key.AddRange(new string[] { pG1ContactNbr.ToString(), "contact" });
            }
        }
    }
}
