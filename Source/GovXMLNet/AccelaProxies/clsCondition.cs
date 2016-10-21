using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="Condition">
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
          <xsd:element name="Text" type="xsd:string" minOccurs="0"/>
          <xsd:element ref="RecordedBy" minOccurs="0"/>
          <xsd:element name="OpenCondition" type="xsd:boolean" form="qualified" minOccurs="0"/>
          <xsd:element name="DisplayConditionNotice" type="xsd:string" form="qualified" minOccurs="0"/> <!-- XSD claims boolean but it is Y N string field in practice <xsd:element name="DisplayConditionNotice" type="xsd:boolean" form="qualified" minOccurs="0"/> -->
          <xsd:element name="IncludeInConditionName" type="xsd:string" form="qualified" minOccurs="0"/> <!-- XSD claims boolean but it is Y N string field in practice <xsd:element name="IncludeInConditionName" type="xsd:boolean" form="qualified" minOccurs="0"/> -->
          <xsd:element name="Inheritable" type="xsd:boolean" form="qualified" minOccurs="0"/>
          <xsd:element name="Name" type="xsd:string" form="qualified" minOccurs="0"/>
          <xsd:element name="ShortComment" type="xsd:string" form="qualified" minOccurs="0"/>
          <xsd:element name="LongComment" type="xsd:string" form="qualified" minOccurs="0"/>
          <xsd:element name="ResolutionAction" type="xsd:string" form="qualified" minOccurs="0"/>
          <xsd:element name="PublicDisplayMessage" type="xsd:string" form="qualified" minOccurs="0"/>
          <xsd:element ref="ReadOnly" minOccurs="0"/>
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
    public class clsCondition : clsAttachment
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

        public clsSeverityLevel SeverityLevel { get; set; }
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
                    return ApplyDate.Value.ToString(Constants.cDateFormat);
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
                    return EffectiveDate.Value.ToString(Constants.cDateFormat);
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
                    return ExpirationDate.Value.ToString(Constants.cDateFormat);
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


        public clsDataType DataType { get; set; }

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

        private bool? _OpenCondition = null;
        public bool? OpenCondition
        {
            get
            {
                if (_OpenCondition.HasValue)
                {
                    return _OpenCondition.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _OpenCondition = value; }
        }
        public bool OpenConditionSpecified
        {
            get { return _OpenCondition != null; }
        }

        private bool? _DisplayConditionNotice = null;
        [XmlIgnore]
        public bool? DisplayConditionNotice
        {
            get
            {
                if (_DisplayConditionNotice.HasValue)
                {
                    return _DisplayConditionNotice.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _DisplayConditionNotice = value; }
        }
        [XmlElement("DisplayConditionNotice")]
        public string DisplayConditionNoticeString
        {
            get
            {
                if (_DisplayConditionNotice.HasValue)
                {
                    if (_DisplayConditionNotice.Value == true)
                    {
                        return "Y";
                    }
                    else
                    {
                        return "N";
                    }
                }
                else
                {
                    return null;
                }
            }
            set 
            {
                if (value != null && value.Length > 0 && value.Substring(0,1).ToUpper() == "Y")
                {
                    _DisplayConditionNotice = true;
                }
                else if (value != null && value.Length > 0 && value.Substring(0, 1).ToUpper() == "N")
                {
                    _DisplayConditionNotice = false;
                }
                else
                {
                    _DisplayConditionNotice = null;
                }
            }
        }
        public bool DisplayConditionNoticeStringSpecified
        {
            get { return _DisplayConditionNotice != null; }
        }


        private bool? _IncludeInConditionName = null;
        [XmlIgnore]
        public bool? IncludeInConditionName
        {
            get
            {
                if (_IncludeInConditionName.HasValue)
                {
                    return _IncludeInConditionName.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _IncludeInConditionName = value; }
        }
        [XmlElement("IncludeInConditionName")]
        public string IncludeInConditionNameString
        {
            get
            {
                if (_IncludeInConditionName.HasValue)
                {
                    if (_IncludeInConditionName.Value == true)
                    {
                        return "Y";
                    }
                    else
                    {
                        return "N";
                    }
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != null && value.Length > 0 && value.Substring(0, 1).ToUpper() == "Y")
                {
                    _IncludeInConditionName = true;
                }
                else if (value != null && value.Length > 0 && value.Substring(0, 1).ToUpper() == "N")
                {
                    _IncludeInConditionName = false;
                }
                else
                {
                    _IncludeInConditionName = null;
                }
            }
        }
        public bool IncludeInConditionNameStringSpecified
        {
            get { return _IncludeInConditionName != null; }
        }


        private bool? _Inheritable;
        [XmlIgnore]
        public bool? Inheritable
        {
            get
            {
                if (_Inheritable.HasValue)
                {
                    return _Inheritable.Value;
                }
                return null;
            }
            set { _Inheritable = value; }
        }
        [XmlElement("Inheritable")]
        public string InheritableString
        {
            get
            {
                if (_Inheritable.HasValue)
                {
                    if (_Inheritable.Value)
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
                    _Inheritable = true;
                }
                else if (!string.IsNullOrEmpty(value) && value.Substring(0, 1).ToUpper() == "N")
                {
                    _Inheritable = false;
                }
                else
                {
                    _Inheritable = null;
                }
            }
        }
        public bool InheritableStringSpecified
        {
            get { return _Inheritable != null; }
        }

        private string _Name = null;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _ShortComment = null;
        public string ShortComment
        {
            get { return _ShortComment; }
            set { _ShortComment = value; }
        }

        private string _LongComment = null;
        public string LongComment
        {
            get { return _LongComment; }
            set { _LongComment = value; }
        }

        private string _ResolutionAction = null;
        public string ResolutionAction
        {
            get { return _ResolutionAction; }
            set { _ResolutionAction = value; }
        }

        private string _PublicDisplayMessage = null;
        public string PublicDisplayMessage
        {
            get { return _PublicDisplayMessage; }
            set { _PublicDisplayMessage = value; }
        }

        private bool? _ReadOnly = null;
        public bool? ReadOnly
        {
            get
            {
                if (_ReadOnly.HasValue)
                {
                    return _ReadOnly.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _ReadOnly = value; }
        }
        public bool ReadOnlySpecified
        {
            get { return _ReadOnly != null; }
        }

        public clsAdditionalInformation AdditionalInformation { get; set; }

        // Constructors
        public clsCondition()
        {
        }
    }
}
