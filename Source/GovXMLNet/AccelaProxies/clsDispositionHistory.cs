using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="DispositionHistory">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence>
          <xsd:element ref="Keys" />
          <xsd:element ref="Status" />
          <xsd:element ref="InspectionDate" minOccurs="0" />
          <xsd:element ref="InspectionTime" minOccurs="0" />
          <xsd:element ref="ResultComment" minOccurs="0" />
          <xsd:element ref="Date" />
          <xsd:element ref="Time" />
          <xsd:element ref="RecordedBy" />
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
    public class clsDispositionHistory : clsElement
    {
        // Members
        public clsKeys Keys { get; set; }
        public clsStatus Status { get; set; }

        [XmlIgnore]
        public DateTime? InspectionDateTime { get; set; }  // This member is used for both the date and time fields
        [XmlElement("InspectionDate")]
        public string InspectionDateString
        {
            get
            {
                if (InspectionDateTime.HasValue)
                {
                    return InspectionDateTime.Value.ToString(Constants.cDateFormat);
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
                    if (InspectionDateTime != null)
                    {
                        InspectionDateTime = td + InspectionDateTime.Value.TimeOfDay;
                    }
                    else
                    {
                        InspectionDateTime = td;
                    }
                }
            }
        }
        public bool InspectionDateStringSpecified
        {
            get { return InspectionDateTime != null; }
        }

        [XmlElement("InspectionTime")]
        public string InspectionTimeString
        {
            get
            {
                if (InspectionDateTime.HasValue)
                {
                    return InspectionDateTime.Value.ToString(Constants.cTimeFormat);
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
                    if (InspectionDateTime != null)
                    {
                        InspectionDateTime = InspectionDateTime.Value.Date + td.TimeOfDay;
                    }
                    else
                    {
                        InspectionDateTime = td;
                    }
                }

            }
        }
        public bool InspectionTimeStringSpecified
        {
            get { return InspectionDateTime != null; }
        }

        private string _ResultComment = null;
        public string ResultComment
        {
            get { return _ResultComment; }
            set { _ResultComment = value; }
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

        private string _RecordedBy = null;
        public string RecordedBy
        {
            get { return _RecordedBy; }
            set { _RecordedBy = value; }
        }


        // Constructors
        public clsDispositionHistory()
        {
        }
    }
}
