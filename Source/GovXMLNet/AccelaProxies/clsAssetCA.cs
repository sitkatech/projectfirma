using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
	<xsd:complexType name="AssetCA">
		<xsd:complexContent>
			<xsd:extension base="Entity">
				<xsd:sequence>
					<xsd:element ref="Asset" />
					<xsd:element ref="AssetCAType" />
					<xsd:element name="ScheduleDate" type="xsd:string"/>
					<xsd:element name="ScheduleTime" type="xsd:string"/>
					<xsd:element name="InspectionDate" type="xsd:string"/>
					<xsd:element name="InspectionTime" type="xsd:string"/>
					<xsd:element name="TimeSpent" type="xsd:double"/>
					<xsd:element name="comment" type="xsd:string"/>
					<xsd:element name="AssetCAId" type="xsd:string"/>
					<xsd:element ref="Department" />
					<xsd:element ref="StaffPerson" />
					<xsd:element ref="AdditionalInformation" />
					<xsd:element name="Observation" type="AdditionalInformation" />
                </xsd:sequence>
			</xsd:extension>
		</xsd:complexContent>
	</xsd:complexType>
*/

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 4/11/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class clsAssetCA : clsEntity
    {
        // Members
        public clsAsset Asset { get; set; }
        public clsAssetCAType AssetCAType { get; set; }

        [XmlIgnore]
        public DateTime? ScheduledDateTime { get; set; }  // This member is used for both the date and time fields
        [XmlElement("ScheduleDate")]
        public string ScheduleDateString
        {
            get
            {
                if (ScheduledDateTime.HasValue)
                {
                    return ScheduledDateTime.Value.ToString(Constants.cDateFormat);
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
                    if (ScheduledDateTime != null)
                    {
                        ScheduledDateTime = td + ScheduledDateTime.Value.TimeOfDay;
                    }
                    else
                    {
                        ScheduledDateTime = td;
                    }
                }
            }
        }
        public bool ScheduleDateStringSpecified
        {
            get { return ScheduledDateTime != null; }
        }

        [XmlElement("ScheduleTime")]
        public string ScheduleTimeString
        {
            get
            {
                if (ScheduledDateTime.HasValue)
                {
                    return ScheduledDateTime.Value.ToString(Constants.cTimeFormat);
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
                    if (ScheduledDateTime != null)
                    {
                        ScheduledDateTime = ScheduledDateTime.Value.Date + td.TimeOfDay;
                    }
                    else
                    {
                        ScheduledDateTime = td;
                    }
                }

            }
        }
        public bool ScheduleTimeStringSpecified
        {
            get { return ScheduledDateTime != null; }
        }


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
        public bool InspectionDateSpecified
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


        private double? _TimeSpent = null;
        public double? TimeSpent
        {
            get
            {
                if (_TimeSpent.HasValue)
                {
                    return _TimeSpent.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _TimeSpent = value; }
        }
        public bool TimeSpentSpecified
        {
            get { return _TimeSpent != null; }
        }

        private string _comment = null;
        public string comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        private string _AssetCAId = null;
        public string AssetCAId
        {
            get { return _AssetCAId; }
            set { _AssetCAId = value; }
        }

        public clsDepartment Department { get; set; }
        public clsStaffPerson StaffPerson { get; set; }
        public clsAdditionalInformation AdditionalInformation { get; set; }
        public clsAdditionalInformation Observation { get; set; }


        // Constructors
        public clsAssetCA()
        {
        }
    }
}
