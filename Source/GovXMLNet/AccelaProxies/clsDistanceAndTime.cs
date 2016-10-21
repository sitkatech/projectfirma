using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="DistanceAndTime">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence>
          <xsd:element ref="Keys" minOccurs="0"/>
          <xsd:element ref="IdentifierDisplay" minOccurs="0"/>
          <xsd:element ref="Date"/>
          <xsd:element ref="LastUpdateDate"/>
          <xsd:element name="distance" form="qualified" minOccurs="0">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="start" type="xsd:double" form="qualified" minOccurs="0"/>
                <xsd:element name="end" type="xsd:double" form="qualified" minOccurs="0"/>
                <xsd:element name="total" type="xsd:double" form="qualified"/>
                <xsd:element ref="UnitOfMeasurement" minOccurs="0"/>
              </xsd:sequence>
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="time" form="qualified" minOccurs="0">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="start" type="xsd:time" form="qualified" minOccurs="0"/>
                <xsd:element name="end" type="xsd:time" form="qualified" minOccurs="0"/>
                <xsd:element name="total" type="distanceTimeSpecialType" form="qualified"/>
                <xsd:element ref="UnitOfMeasurement" minOccurs="0"/>
              </xsd:sequence>
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="vehicleId" type="text" form="qualified" minOccurs="0"/>
          <xsd:element ref="RecordedBy" minOccurs="0"/>
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
    public class clsDistanceAndTime : clsElement
    {
        // Members
        public clsKeys Keys { get; set; }

        private string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        [XmlIgnore]
        public DateTime Date { get; set; }
        [XmlElement("Date")]
        public string DateString
        {
            get { return Date.ToString(Constants.cDateFormat); }
            set
            {
                DateTime td;
                if (DateTime.TryParse(value, out td))
                {
                    Date = td;
                }
            }
        }


        [XmlIgnore]
        public DateTime LastUpdateDate { get; set; }
        [XmlElement("LastUpdateDate")]
        public string LastUpdateDateString
        {
            get { return LastUpdateDate.ToString(Constants.cDateFormat); }
            set
            {
                DateTime td;
                if (DateTime.TryParse(value, out td))
                {
                    LastUpdateDate = td;
                }
            }
        }

        // Since this is indented it needs to go into it's own class
        public lctDistanceAndTimeDistance distance { get; set; }
        // Since this is indented it needs to go into it's own class
        public lctDistanceAndTimeTime time { get; set; }

        private string _vehicleId = null;
        public string vehicleId
        {
            get { return _vehicleId; }
            set { _vehicleId = value; }
        }

        private string _RecordedBy = null;
        public string RecordedBy
        {
            get { return _RecordedBy; }
            set { _RecordedBy = value; }
        }

        // Constructors
        public clsDistanceAndTime()
        {
        }
    }
}
