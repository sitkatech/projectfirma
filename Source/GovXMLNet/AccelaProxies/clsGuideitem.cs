using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="Guideitem">
    <xsd:complexContent>
      <xsd:extension base="Attachment">
        <xsd:sequence>
          <xsd:element name="contextType" type="dataitemChangeEnum" form="qualified"/>
          <xsd:element ref="Type" minOccurs="0"/>
          <xsd:element ref="Description" minOccurs="0"/>
          <xsd:element ref="DescriptionEnumeration" minOccurs="0" maxOccurs="1"/>
          <xsd:element ref="Date" minOccurs="0"/>
          <xsd:element ref="Time" minOccurs="0"/>
          <xsd:element ref="DataType" minOccurs="0"/>
          <xsd:element ref="Value" minOccurs="0"/>
          <xsd:element name="Status" minOccurs="0">
            <xsd:complexType>
              <xsd:complexContent>
                <xsd:extension base="Enumeration"/>
              </xsd:complexContent>
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="Text" type="xsd:string" minOccurs="0"/>
          <xsd:element name="applicability" type="text" form="qualified" minOccurs="0"/>
          <xsd:element ref="EnumerationStatus" minOccurs="0" maxOccurs="1"/>
          <xsd:element ref="StatusEnumerationListId" minOccurs="0" maxOccurs="1"/>
          <xsd:element name="applicabilityEnumerationListId" type="enumerationListIdentifier" form="qualified" minOccurs="0"/>
          <xsd:element name="correctionCode" type="text" form="qualified" minOccurs="0"/>
          <xsd:element name="violationCode" type="text" form="qualified" minOccurs="0"/>
          <xsd:element ref="RecordedBy" minOccurs="0"/>
          <xsd:element name="defaultValue" type="xsd:Integer" minOccurs="0"/>
          <xsd:element name="maxValue" type="xsd:double" minOccurs="0"/>
          <xsd:element name="class" type="xsd:string" minOccurs="0"/>
          <xsd:element ref="StandardCommentsGroupIds" minOccurs="0"/>
          <xsd:element ref="AdditionalInformation" minOccurs="0"/>
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
    public class clsGuideitem : clsAttachment
    {
        // Members
        private dataitemChangeEnum _contextType;
        public dataitemChangeEnum contextType
        {
            get { return _contextType; }
            set { _contextType = value; }
        }

        public clsType Type { get; set; }

        private string _Description = null;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public clsDescriptionEnumeration DescriptionEnumeration { get; set; }

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
            get { return dateTime != null && dateTime.Value.TimeOfDay.Ticks > 0; }
        }

        public clsDataType DataType { get; set; }

        private string _Value = null;
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        public clsEnumeration Status { get; set; }

        private string _Text = null;
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }

        private string _applicability = null;
        public string applicability
        {
            get { return _applicability; }
            set { _applicability = value; }
        }

        public clsEnumerationStatus EnumerationStatus { get; set; }
        //public clsStatusEnumerationListId StatusEnumerationListId { get; set; }
        private string _StatusEnumerationListId = null;
        public string StatusEnumerationListId
        {
            get { return _StatusEnumerationListId; }
            set { _StatusEnumerationListId = value; }
        }

        private string _applicabilityEnumerationListId = null;
        public string applicabilityEnumerationListId
        {
            get { return _applicabilityEnumerationListId; }
            set { _applicabilityEnumerationListId = value; }
        }

        private string _correctionCode = null;
        public string correctionCode
        {
            get { return _correctionCode; }
            set { _correctionCode = value; }
        }

        private string _violationCode = null;
        public string violationCode
        {
            get { return _violationCode; }
            set { _violationCode = value; }
        }

        private string vRecordedBy = null;
        public string RecordedBy
        {
            get { return vRecordedBy; }
            set { vRecordedBy = value; }
        }


        private int? _defaultValue = null;
        public int? defaultValue
        {
            get
            {
                if (_defaultValue.HasValue)
                {
                    return _defaultValue.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _defaultValue = value; }
        }
        public bool defaultValueSpecified
        {
            get { return _defaultValue != null; }
        }


        private double? _maxValue = null;
        public double? maxValue
        {
            get
            {
                if (_maxValue.HasValue)
                {
                    return _maxValue.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _maxValue = value; }
        }
        public bool maxValueSpecified
        {
            get { return _maxValue != null; }
        }

        private string _Class = null;
        [XmlElement(ElementName = "class")]
        public string Class
        {
            get { return _Class; }
            set { _Class = value; }
        }

        public clsStandardCommentsGroupIds StandardCommentGroupIds { get; set; }
        public clsAdditionalInformation AdditionalInformation { get; set; }

        private bool _carryOverFlag = false;
        [XmlIgnore]
        public bool carryOverFlag
        {
            get { return _carryOverFlag; }
            set { _carryOverFlag = value; }
        }
        [XmlElement("carryOverFlag")]
        public string carryOverFlagString
        {
            get
            {
                if (_carryOverFlag == true)
                {
                    return "Y";
                }
                else
                {
                    return "N";
                }
            }
            set
            {
                if (value != null && value.Length > 0 && value.Substring(0, 1).ToUpper() == "Y")
                {
                    _carryOverFlag = true;
                }
                else
                {
                    _carryOverFlag = false;
                }
            }
        }

        // Constructors
        public clsGuideitem()
        {
        }
    }
}
