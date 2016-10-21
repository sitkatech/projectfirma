using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="DetailAddress">
    <xsd:complexContent>
      <xsd:extension base="Address">
        <xsd:sequence>
          <xsd:element ref="Keys" minOccurs="0"/>
          <xsd:element ref="IdentifierDisplay" minOccurs="0"/>
          <xsd:element name="addressFormat" type="addressFormatEnum" form="qualified" id="gov_address_addressformat" minOccurs="0"/>
          <xsd:element name="houseNumber" type="text" form="qualified" id="gov_address_housenumber" minOccurs="0"/>
          <xsd:element name="houseNumberFraction" type="text" form="qualified" id="gov_address_housenumberfraction" minOccurs="0"/>
          <xsd:element name="streetDirection" type="directionEnum" form="qualified" id="gov_address_streetdirection" minOccurs="0"/>
          <xsd:element name="streetName" type="text" form="qualified" id="gov_address_streetname"/>
          <xsd:element name="streetSuffix" type="text" form="qualified" id="gov_address_streetsuffix" minOccurs="0"/>
          <xsd:element name="streetSuffixDirection" type="directionEnum" form="qualified" id="gov_address_streetsuffixdirection" minOccurs="0"/>
          <xsd:element name="unit" type="text" form="qualified" id="gov_address_unit" minOccurs="0"/>
          <xsd:element name="unitEnd" type="text" form="qualified" id="gov_address_unit_end" minOccurs="0"/>
          <xsd:element name="unitType" type="text" form="qualified" id="gov_address_unittype" minOccurs="0"/>
          <xsd:element name="urbanization" type="text" form="qualified" id="gov_address_urbanization" minOccurs="0"/>
          <xsd:element ref="City"/>
          <xsd:element ref="CityIdentifier" minOccurs="0"/>
          <xsd:element ref="County" minOccurs="0"/>
          <xsd:element ref="State" minOccurs="0"/>
          <xsd:element ref="PostalCode" minOccurs="0"/>
          <xsd:element ref="Country" minOccurs="0"/>
          <xsd:element ref="Alias" minOccurs="0"/>
          <xsd:element ref="GISObjects" minOccurs="0"/>
          <xsd:element ref="AdditionalInformation" minOccurs="0"/>
          <xsd:element ref="ParcelIds" minOccurs="0"/>
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
    public class clsDetailAddress : clsAddress
    {
        // Members
        public clsKeys Keys { get; set; }

        private string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        private addressFormatEnum? _addressFormat = null;
        public addressFormatEnum? addressFormat
        {
            get
            {
                if (_addressFormat.HasValue)
                {
                    return _addressFormat.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _addressFormat = value; }
        }
        public bool addressFormatSpecified
        {
            get { return _addressFormat != null; }
        }

        private string _houseNumber = null;
        public string houseNumber
        {
            get { return _houseNumber; }
            set { _houseNumber = value; }
        }

        private string _houseNumberFraction = null;
        public string houseNumberFraction
        {
            get { return _houseNumberFraction; }
            set { _houseNumberFraction = value; }
        }

        private directionEnum? _streetDirection = null;
        [XmlIgnore]
        public directionEnum? streetDirection
        {
            get
            {
                if (_streetDirection.HasValue)
                {
                    return _streetDirection.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _streetDirection = value; }
        }
        [XmlElement("streetDirection")]
        public string streetDirectionString
        {
            get
            {
                if (_streetDirection.HasValue)
                {
                    return _streetDirection.Value.ToString();
                }
                else
                {
                    return null;
                }
            }
            set 
            {
                if (value != null && value != "")
                {
                    _streetDirection = (directionEnum)Enum.Parse(typeof(directionEnum), value, true);
                }
                else
                {
                    _streetDirection = null;
                }
            }
        }
        public bool streetDirectionStringSpecified
        {
            get { return _streetDirection != null; }
        }

        private string _streetName = null;
        public string streetName
        {
            get { return _streetName; }
            set { _streetName = value; }
        }

        private string _streetSuffix = null;
        public string streetSuffix
        {
            get { return _streetSuffix; }
            set { _streetSuffix = value; }
        }

        private directionEnum? _streetSuffixDirection = null;
        [XmlIgnore]
        public directionEnum? streetSuffixDirection
        {
            get
            {
                if (_streetSuffixDirection.HasValue)
                {
                    return _streetSuffixDirection.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _streetSuffixDirection = value; }
        }
        [XmlElement("streetSuffixDirection")]
        public string streetSuffixDirectionString
        {
            get
            {
                if (_streetSuffixDirection.HasValue)
                {
                    return _streetSuffixDirection.Value.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != null && value != "")
                {
                    _streetSuffixDirection = (directionEnum)Enum.Parse(typeof(directionEnum), value, true);
                }
                else
                {
                    _streetSuffixDirection = null;
                }
            }
        }
        public bool streetSuffixDirectionStringSpecified
        {
            get { return _streetSuffixDirection != null; }
        }

        private string _unit = null;
        public string unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        private string _unitEnd = null;
        public string unitEnd
        {
            get { return _unitEnd; }
            set { _unitEnd = value; }
        }

        private string _unitType = null;
        public string unitType
        {
            get { return _unitType; }
            set { _unitType = value; }
        }

        private string _urbanization = null;
        public string urbanization
        {
            get { return _urbanization; }
            set { _urbanization = value; }
        }

        private string _City = null;
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public clsCityIdentifier CityIdentifier { get; set; }

        private string _County = null;
        public string County
        {
            get { return _County; }
            set { _County = value; }
        }

        private string _State = null;
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        private string _PostalCode = null;
        public string PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = value; }
        }

        string _Country = null;  // Max length is 3
        public string Country
        {
            get { return _Country; }
            set
            {
                if (value != null && value.Length > 3)
                {
                    _Country = value.Substring(0, 3);
                }
                else
                {
                    _Country = value;
                }
            }
        }

        private string _Alias = null;
        public string Alias
        {
            get { return _Alias; }
            set { _Alias = value; }
        }

        public clsGISObjects GISObjects { get; set; }
        public clsAdditionalInformation AdditionalInformation { get; set; }
        public clsParcelIds ParcelIds { get; set; }

        private bool _isPrimary = true;
        [XmlAttribute("isPrimary")]
        public bool isPrimary
        {
            get { return _isPrimary; }
            set { _isPrimary = value; }
        }
        // Constructors
        public clsDetailAddress()
        {
        }
    }
}
