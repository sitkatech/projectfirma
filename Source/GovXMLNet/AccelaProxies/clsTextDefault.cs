using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="TextDefault">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence>
          <xsd:element name="Name" type="xsd:string" form="qualified" minOccurs="0"/>
          <xsd:element name="ShortComment" type="xsd:string" form="qualified" minOccurs="0"/>
          <xsd:element name="LongComment" type="xsd:string" form="qualified" minOccurs="0"/>
          <xsd:element name="ResolutionAction" type="xsd:string" form="qualified" minOccurs="0"/>
          <xsd:element name="PublicDisplayMessage" type="xsd:string" form="qualified" minOccurs="0"/>
          <xsd:element name="DisplayConditionNotice" type="xsd:string" form="qualified" minOccurs="0"/> <!-- Bob had this has a boolean but xsd has it as a string and bob's code below has string Y N <xsd:element name="DisplayConditionNotice" type="xsd:string" form="qualified" minOccurs="0"/> -->
          <xsd:element name="IncludeInConditionName" type="xsd:boolean" form="qualified" minOccurs="0"/>
          <xsd:element name="IncludeInShortDescription" type="xsd:boolean" form="qualified" minOccurs="0"/>
          <xsd:element name="Inheritable" type="xsd:boolean" form="qualified" minOccurs="0"/>
          <xsd:element ref="SeverityLevel"/>
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
    public class clsTextDefault : clsElement
    {
        // Members
        private clsKeys Keys { get; set; }    // Added because found in response of GetConditionTypes

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

        private bool? _IncludeInShortDescription = null;
        [XmlIgnore]
        public bool? IncludeInShortDescription
        {
            get
            {
                if (_IncludeInShortDescription.HasValue)
                {
                    return _IncludeInShortDescription.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _IncludeInShortDescription = value; }
        }
        [XmlElement("IncludeInShortDescription")]
        public string IncludeInShortDescriptionString
        {
            get
            {
                if (_IncludeInShortDescription.HasValue)
                {
                    if (_IncludeInShortDescription.Value == true)
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
                    _IncludeInShortDescription = true;
                }
                else if (value != null && value.Length > 0 && value.Substring(0, 1).ToUpper() == "N")
                {
                    _IncludeInShortDescription = false;
                }
                else
                {
                    _IncludeInShortDescription = null;
                }
            }
        }
        public bool IncludeInShortDescriptionStringSpecified
        {
            get { return _IncludeInShortDescription != null; }
        }

        private bool? _Inheritable = null;
        [XmlIgnore]
        public bool? Inheritable
        {
            get
            {
                if (_Inheritable.HasValue)
                {
                    return _Inheritable.Value;
                }
                else
                {
                    return null;
                }
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
                    if (_Inheritable.Value == true)
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
                    _Inheritable = true;
                }
                else if (value != null && value.Length > 0 && value.Substring(0, 1).ToUpper() == "N")
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

        public clsSeverityLevel SeverityLevel { get; set; }
        public clsAdditionalInformation AdditionalInformation { get; set; }

        // Constructors
        public clsTextDefault()
        {
        }
    }
}
