using System;
using System.Linq;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="Parcel">
    <xsd:complexContent>
      <xsd:extension base="SpatialObject">
        <xsd:sequence>
          <xsd:element ref="Status" minOccurs="0"/>
          <xsd:element name="legalDescription" type="xsd:string" minOccurs="0"/>
          <xsd:element name="Parcelgenealogy" fef ="ParcelRelations" minOccurs="0" />
          <xsd:element name="ChildGenealogy" ref = "ParcelRelations"= minOcuurs="0" />
        </xsd:sequence>
        <xsd:attribute name="isPrimary" type="xsd:boolean" />
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
    public class clsParcel : clsSpatialObject
    {
        public clsStatus Status { get; set; }

        public string legalDescription { get; set; }

        public clsParcelRelations Parcelgenealogy { get; set; }

        public clsParcelRelations ChildGenealogy { get; set; }

        private bool? _IsPrimary;
        [XmlIgnore]
        public bool? IsPrimary
        {
            get
            {
                return _IsPrimary;
            }
            set { _IsPrimary = value; }
        }
        [XmlElement("IsPrimary")]
        public string IsPrimaryString
        {
            get
            {
                if (_IsPrimary.HasValue)
                {
                    if (_IsPrimary.Value)
                    {
                        return "Y";
                    }
                    return "N";
                }
                return null;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Substring(0, 1).ToUpper() == "Y")
                {
                    _IsPrimary = true;
                }
                else if (!string.IsNullOrEmpty(value) && value.Substring(0, 1).ToUpper() == "N")
                {
                    _IsPrimary = false;
                }
                else
                {
                    _IsPrimary = null;
                }
            }
        }
        public bool IsPrimaryStringSpecified
        {
            get { return _IsPrimary != null; }
        }


        // Constructors
        public clsParcel()
        {
            legalDescription = null;
        }

        public string FindJurisdictionName()
        {
            return FindAdditionalItem("Jurisdiction");
        }

        public string FindHRA()
        {
            return FindAdditionalItem("HRA");
        }

        public string FindParcelSize()
        {
            return FindAdditionalItem("Parcel Size");
        }

        public string FindAreaPlan()
        {
            return FindAdditionalItem("Area Plan");
        }

        public string FindCommunityPlan()
        {
            return FindAdditionalItem("Community Plan");
        }

        public string FindPlanAreaStatement()
        {
            return FindAdditionalItem("Plan Area Statement");
        }

        public string FindPlanAreaStatementID()
        {
            return FindAdditionalItem("Plan Area Statement ID");
        }

        public string FindBMPStatus()
        {
            return FindAdditionalItem("BMP Status");
        }

        public string FindFireProtectionDistrict()
        {
            return FindAdditionalItem("Fire Protection District");
        }

        public string FindWatershed()
        {
            return FindAdditionalItem("Watershed");
        }

        private string FindAdditionalItem(string value)
        {
            var clsAdditionalItem =
                AdditionalInformation.AdditionalInformationGroup.SelectMany(x => x.AdditionalInformationSubGroup)
                    .SelectMany(x => x.AdditionalItems.AdditionalItem)
                    .FirstOrDefault(x => x.Name.Equals(value, StringComparison.InvariantCultureIgnoreCase));

            return clsAdditionalItem == null ? null : clsAdditionalItem.Value;
        }

        public string FindOwnerName()
        {
            if (Contacts != null)
            {
                var ownerContacts =
                    Contacts.Contact.Where(curContact => curContact.Person != null && curContact.Person.roles != null && curContact.Person.roles.Any(r => r.role == RoleEnum.owner)).ToList();
                if (ownerContacts.Any())
                {
                    return ownerContacts.First().Person.fullName;
                }
            }
            return null;
        }

        private clsCompactAddress FindParcelCompactAddress()
        {
            if (CompactAddresses != null && CompactAddresses.CompactAddress != null)
            {
                return CompactAddresses.CompactAddress.First();
            }
            return null;
        }
        
        public string FindParcelStreetAddress()
        {
            var clsCompactAddress = FindParcelCompactAddress();
            if (clsCompactAddress == null)
            {
                return null;
            }
            string streetAddress = null;
            if (clsCompactAddress.addressLines != null && clsCompactAddress.addressLines.String.Any())
            {
                streetAddress = string.Join(", ", clsCompactAddress.addressLines.String);
            }
            return streetAddress;
        }

        public string FindParcelCity()
        {
            var clsCompactAddress = FindParcelCompactAddress();
            if (clsCompactAddress == null)
            {
                return null;
            }
            return !string.IsNullOrWhiteSpace(clsCompactAddress.City) ? clsCompactAddress.City : null;
        }

        public string FindParcelState()
        {
            var clsCompactAddress = FindParcelCompactAddress();
            if (clsCompactAddress == null)
            {
                return null;
            }
            return !string.IsNullOrWhiteSpace(clsCompactAddress.State) ? clsCompactAddress.State : null;
        }

        public string FindParcelZipCode()
        {
            var clsCompactAddress = FindParcelCompactAddress();
            if (clsCompactAddress == null)
            {
                return null;
            }
            return !string.IsNullOrWhiteSpace(clsCompactAddress.PostalCode) ? clsCompactAddress.PostalCode : null;
        }
    }
}
