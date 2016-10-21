using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="Document">
    <xsd:complexContent>
      <xsd:extension base="Attachment">
        <xsd:sequence>
          <xsd:element name="contextType" type="dataitemChangeEnum" form="qualified" minOccurs="0"/>
          <xsd:element name="autodownload" type="text" minOccurs="0"/>
          <xsd:element ref="CAPId" minOccurs="0"/>
          <xsd:element ref="InspectionId" minOccurs="0"/>
          <xsd:element ref="Type" minOccurs="0"/>
          <xsd:element ref="Description" minOccurs="0"/>
          <xsd:element ref="Date" minOccurs="0"/>
          <xsd:element ref="Time" minOccurs="0"/>
          <xsd:element ref="Status" minOccurs="0"/>
          <xsd:element ref="DocumentLocators" minOccurs="0"/>
          <xsd:element ref="AdditionalInformation" minOccurs="0"/>
          <xsd:element name="content" type="xsd:base64Binary" form="qualified" minOccurs="0"/>
          <xsd:element ref="EDMSAdapter" minOccurs="0"/>
          <xsd:element name="displayImage" type="xsd:string" minOccurs="0" maxOccurs="1" />
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
    public class clsDocument : clsAttachment
    {
        // Members

        private dataitemChangeEnum? _contextType = null;
        public dataitemChangeEnum? contextType
        {
            get
            {
                if (_contextType.HasValue)
                {
                    return _contextType.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _contextType = value; }
        }
        public bool contextTypeSpecified
        {
            get { return _contextType != null; }
        }

        private string _autodownload = null;
        public string autodownload
        {
            get { return _autodownload; }
            set { _autodownload = value; }
        }

        public clsCAPId CAPId { get; set; }
        public clsInspectionId InspectionId { get; set; }
        public clsType Type { get; set; }

        private string _Description = null;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        [XmlIgnore]
        public DateTime? dateTime { get; set; }  // This member is used for both the date and time fields
        [XmlElement("Date")]
        public string DateString
        {
            get
            {
                if (dateTime.HasValue)
                {
                    return dateTime.Value.ToString(Constants.cDateFormat);
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
                    if (dateTime != null)
                    {
                        dateTime = td + dateTime.Value.TimeOfDay;
                    }
                    else
                    {
                        dateTime = td;
                    }
                }
            }
        }
        public bool DateStringSpecified
        {
            get { return dateTime != null; }
        }

        [XmlElement("Time")]
        public string TimeString
        {
            get
            {
                if (dateTime.HasValue)
                {
                    return dateTime.Value.ToString(Constants.cTimeFormat);
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
                    if (dateTime != null)
                    {
                        dateTime = dateTime.Value.Date + td.TimeOfDay;
                    }
                    else
                    {
                        dateTime = td;
                    }
                }

            }
        }
        public bool TimeStringSpecified
        {
            get { return dateTime != null; }
        }

        public clsStatus Status { get; set; }
        public clsDocumentLocators DocumentLocators { get; set; }
        public clsAdditionalInformation AdditionalInformation { get; set; }

        private byte[] _content;
        public byte[] content
        {
            get { return _content; }
            set { _content = value; }
        }

        public string _EDMSAdapter = null;
        public string EDMSAdapter
        {
            get { return _EDMSAdapter; }
            set { _EDMSAdapter = value; }
        }

        public string _displayImage = null;
        public string displayImage
        {
            get { return _displayImage; }
            set { _displayImage = value; }
        }


        
        // Constructors
        public clsDocument()
        {
        }
    }
}
