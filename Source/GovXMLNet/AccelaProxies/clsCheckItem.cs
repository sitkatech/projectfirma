using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="Checkitem">
    <xsd:complexContent>
      <xsd:extension base="Attachment">
        <xsd:sequence>
          <xsd:element name="contextType" type="dataitemChangeEnum" form="qualified"/>
          <xsd:element ref="Type" minOccurs="0"/>
          <xsd:element ref="Description" minOccurs="0"/>
          <xsd:element ref="SeverityLevel" minOccurs="0"/>
          <xsd:element ref="Status" minOccurs="0"/>
          <xsd:element ref="ApplyDate" minOccurs="0"/>
          <xsd:element ref="EffectiveDate" minOccurs="0"/>
          <xsd:element ref="ExpirationDate" minOccurs="0"/>
          <xsd:element ref="Date" minOccurs="0"/>
          <xsd:element ref="Time" minOccurs="0"/>
          <xsd:element ref="DataType" minOccurs="0"/>
          <xsd:element ref="Value" minOccurs="0"/>
          <xsd:element name="Text" type="text" minOccurs="0"/>
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
    public class clsCheckItem : clsAttachment
    {
        // Members
        private dataitemChangeEnum _contextType;
        public dataitemChangeEnum contextType
        {
            get { return _contextType; }
            set { _contextType = value; }
        }

        public clsType Type { get; set; }

        string _Description = null;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public clsStatus Status { get; set; }

        [XmlIgnore]
        public DateTime? ApplyDate { get; set; }
        [XmlElement("ApplyDate")]
        public string ApplyDateString
        {
            get
            {
                if (ApplyDate.HasValue)
                {
                    return ApplyDate.Value.ToString(Constants.cDateFormat); ;
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
                    ApplyDate = td;
                }
                else
                {
                    ApplyDate = null;
                }
            }
        }
        public bool ApplyDateStringSpecified
        {
            get { return ApplyDate != null; }
        }

        [XmlIgnore]
        public DateTime? EffectiveDate { get; set; }
        [XmlElement("EffectiveDate")]
        public string EffectiveDateString
        {
            get
            {
                if (EffectiveDate.HasValue)
                {
                    return EffectiveDate.Value.ToString(Constants.cDateFormat); ;
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
                    EffectiveDate = td;
                }
                else
                {
                    EffectiveDate = null;
                }
            }
        }
        public bool EffectiveDateStringSpecified
        {
            get { return EffectiveDate != null; }
        }

        [XmlIgnore]
        public DateTime? ExpirationDate { get; set; }
        [XmlElement("ExpirationDate")]
        public string ExpirationDateString
        {
            get
            {
                if (ExpirationDate.HasValue)
                {
                    return ExpirationDate.Value.ToString(Constants.cDateFormat); ;
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
                    ExpirationDate = td;
                }
                else
                {
                    ExpirationDate = null;
                }
            }
        }
        public bool ExpirationDateStringSpecified
        {
            get { return ExpirationDate != null; }
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

        private string _Value = null;
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        private string _Text = null;
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }

        private string _RecordedBy = null;
        public string RecordedBy
        {
            get { return _RecordedBy; }
            set { _RecordedBy = value; }
        }

        // Constructors
        public clsCheckItem()
        {
        }
    }
}
