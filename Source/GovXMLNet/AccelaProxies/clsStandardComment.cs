using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="StandardComment">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence>
          <xsd:element ref="Keys" minOccurs="0"/>
          <xsd:element ref="IdentifierDisplay"/>
          <xsd:element ref="Type" minOccurs="0"/>
          <xsd:element ref="Date" minOccurs="0"/>
          <xsd:element ref="Time" minOccurs="0"/>
          <xsd:element name="Text" type="xsd:string"/>
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
    public class clsStandardComment : clsElement
    {
        // Members
        public clsKeys Keys { get; set; }

        private string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        private clsType _Type = null;
        public clsType Type
        {
            get { return _Type; }
            set { _Type = value; }
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
        public bool DateSpecified
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

        private string _Text = null;
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }


        // Constructors
        public clsStandardComment()
        {
        }
    }
}
