// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="ConditionType">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence>
          <xsd:element ref="Keys"/>
          <xsd:element ref="IdentifierDisplay" minOccurs="0"/>
          <xsd:element ref="Dispositions" minOccurs="0"/>
          <xsd:element ref="SeverityLevels" minOccurs="0"/>
          <xsd:element ref="StandardCommentsGroupIds" minOccurs="0"/>
          <xsd:element ref="TextDefaults" minOccurs="0"/>
          <xsd:element name="NameLength" type="xsd:long" form="qualified" minOccurs="0"/>
          <xsd:element name="ShortCommentLength" type="xsd:long" form="qualified" minOccurs="0"/>
          <xsd:element name="LongCommentLength" type="xsd:long" form="qualified" minOccurs="0"/>
          <xsd:element name="ResolutionActionLength" type="xsd:long" form="qualified" minOccurs="0"/>
          <xsd:element name="PublicDisplayMessageLength" type="xsd:long" form="qualified" minOccurs="0"/>
          <xsd:element ref="AdditionalInformationGroupIds" minOccurs="0"/>
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
    public class clsConditionType : clsElement
    {
        // Members
        public clsKeys Keys { get; set; }

        private string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        public clsDispositions Dispositions { get; set; }
        public clsSeverityLevels SeverityLevels { get; set; }
        public clsStandardCommentsGroupIds StandardCommentsGroupIds { get; set; }
        public clsTextDefaults TextDefaults { get; set; }

        private long? _NameLength = null;
        public long? NameLength
        {
            get
            {
                if (_NameLength.HasValue)
                {
                    return _NameLength.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _NameLength = value; }
        }
        public bool NameLengthSpecified
        {
            get { return _NameLength != null; }
        }

        private long? _ShortCommentLength = null;
        public long? ShortCommentLength
        {
            get
            {
                if (_ShortCommentLength.HasValue)
                {
                    return _ShortCommentLength.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _ShortCommentLength = value; }
        }
        public bool ShortCommentLengthSpecified
        {
            get { return _ShortCommentLength != null; }
        }

        private long? _LongCommentLength = null;
        public long? LongCommentLength
        {
            get
            {
                if (_LongCommentLength.HasValue)
                {
                    return _LongCommentLength.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _LongCommentLength = value; }
        }
        public bool LongCommentLengthSpecified
        {
            get { return _LongCommentLength != null; }
        }


        private long? _ResolutionActionLength = null;
        public long? ResolutionActionLength
        {
            get
            {
                if (_ResolutionActionLength.HasValue)
                {
                    return _ResolutionActionLength.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _ResolutionActionLength = value; }
        }
        public bool ResolutionActionLengthSpecified
        {
            get { return _ResolutionActionLength != null; }
        }


        private long? _PublicDisplayMessageLength = null;
        public long? PublicDisplayMessageLength
        {
            get
            {
                if (_PublicDisplayMessageLength.HasValue)
                {
                    return _PublicDisplayMessageLength.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _PublicDisplayMessageLength = value; }
        }
        public bool PublicDisplayMessageLengthSpecified
        {
            get { return _PublicDisplayMessageLength != null; }
        }

        public clsAdditionalInformationGroupIds AdditionalInformationGroupIds { get; set; }

        // Constructors
        public clsConditionType()
        {
        }
    }
}
