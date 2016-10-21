using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
    <xsd:complexType name="TimeAccounting">
      <xsd:complexContent>
        <xsd:extension base="Identifier">
          <xsd:sequence>
            <xsd:element ref="TimeAccountingGroup" minOccurs="0"/>
            <xsd:element ref="TimeAccountingType" minOccurs="0"/>
            <xsd:element name="startTime" type="xsd:string" form="qualified" minOccurs="0"/>
            <xsd:element name="endTime" type="xsd:string" form="qualified" minOccurs="0"/>
            <xsd:element name="duration" type="xsd:string" form="qualified" minOccurs="0"/>
            <xsd:attribute name="action" type="dataitemChangeEnum" use="optional"/>
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
    public class clsTimeAccounting : clsIdentifier
    {
        // Members
        public clsTimeAccountingGroup TimeAccountingGroup { get; set; }
        public clsTimeAccountingType TimeAccountingType { get; set; }

        [XmlIgnore]
        public DateTime? startTime { get; set; }
        [XmlElement("startTime")]
        public string startTimeString
        {
            get
            {
                if (startTime.HasValue)
                {
                    return startTime.Value.ToString(Constants.cDateFormat); ;
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
                    startTime = td;
                }
                else
                {
                    startTime = null;
                }
            }
        }
        public bool startTimeStringSpecified
        {
            get { return startTime != null; }
        }

        [XmlIgnore]
        public DateTime? endTime { get; set; }
        [XmlElement("endTime")]
        public string endTimeString
        {
            get
            {
                if (endTime.HasValue)
                {
                    return endTime.Value.ToString(Constants.cDateFormat); ;
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
                    endTime = td;
                }
                else
                {
                    endTime = null;
                }
            }
        }
        public bool endTimeStringSpecified
        {
            get { return endTime != null; }
        }

        private double? _duration = null;
        public double? duration
        {
            get
            {
                if (_duration.HasValue)
                {
                    return _duration.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _duration = value; }
        }
        public bool durationSpecified
        {
            get { return _duration != null; }
        }


        private dataitemChangeEnum _action = dataitemChangeEnum.ForceExclusion;  // Must use ForceExlusion since this is an attribute
        [XmlAttribute("action")]
        public dataitemChangeEnum action
        {
            get { return _action; }
            set { _action = value; }
        }
        public bool actionSpecified
        {
            get { return _action != dataitemChangeEnum.ForceExclusion; }
        }

        // Constructors
        public clsTimeAccounting()
        {
        }

    }
}
