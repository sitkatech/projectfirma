using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="Worksheet">
		<xsd:complexContent>
			<xsd:extension base="Attachment">
				<xsd:sequence>
					<xsd:element name="contextType" type="datasetChangeEnum" form="qualified" minOccurs="0"/>
					<xsd:element ref="Description" minOccurs="0"/>
					<xsd:element ref="Date" minOccurs="0"/>
					<xsd:element ref="Time" minOccurs="0"/>
					<xsd:element ref="Fee" minOccurs="0"/>
					<xsd:element ref="Workitems" minOccurs="0"/>
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
    public class clsWorksheet : clsAttachment
    {
        // Members
        private datasetChangeEnum? _contextType = null;
        public datasetChangeEnum? contextType
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

        private string _Description = null;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        [XmlIgnore]
        public DateTime? dateTime = null;  // This member is used for both the date and time fields
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


        public clsFee Fee { get; set; }

        public clsDataType DataType { get; set; }

        public clsWorkitems Workitems { get; set; }

        private string _RecordedBy = null;
        public string RecordedBy
        {
            get { return _RecordedBy; }
            set { _RecordedBy = value; }
        }

        // Constructors
        public clsWorksheet()
        {
        }
    }
}
