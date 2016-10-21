using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="Guidesheet">
    <xsd:complexContent>
      <xsd:extension base="Attachment">
        <xsd:sequence>
          <xsd:element name="contextType" type="datasetChangeEnum" form="qualified"/>
          <xsd:element ref="Type" minOccurs="0"/>
          <xsd:element ref="GuidesheetGroups" minOccurs="0"/>
          <xsd:element name="Label" type="text" minOccurs="0"/>
          <xsd:element ref="Description" minOccurs="0"/>
          <xsd:element ref="Date" minOccurs="0"/>
          <xsd:element ref="Time" minOccurs="0"/>
          <xsd:element ref="Guideitems" minOccurs="0"/>
          <xsd:element name="Text" type="xsd:string" minOccurs="0"/>
          <xsd:element ref="RecordedBy" minOccurs="0"/>
          <xsd:element ref="EnumerationLists" minOccurs="0"/>
          <xsd:element ref="StandardCommentsGroupIds" minOccurs="0"/>
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
    public class clsGuidesheet : clsAttachment
    {
        // Members
        private datasetChangeEnum _contextType;
        public datasetChangeEnum contextType
        {
            get { return _contextType; }
            set { _contextType = value; }
        }

        public clsType Type { get; set; }
        public clsGuidesheetGroups GuidesheetGroups { get; set; }

        private string _Label = null;
        public string Label
        {
            get { return _Label; }
            set { _Label = value; }
        }

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
            get { return dateTime != null  && dateTime.Value.TimeOfDay.Ticks > 0; }
        }


        public clsGuideitems Guideitems { get; set; }

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

        public clsEnumerationLists EnumerationLists { get; set; }
        public clsStandardCommentsGroupIds StandardCommentsGroupIds { get; set; }

        // Constructors
        public clsGuidesheet()
        {
        }
    }
}
