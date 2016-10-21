using System;
using System.Xml.Serialization;

// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="GetAvailableInspectionDates">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element ref="CAPId"/>
					<xsd:element ref="InspectionTypeId"/>
					<xsd:element name="startDate" type="calendarDate" minOccurs="0"/>
					<xsd:element name="availableDatesCount" type="xsd:nonNegativeInteger" minOccurs="0"/>
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
    public class msgGetAvailableInspectionDates : clsOperationRequest
    {
        // Members
        public clsCAPId CAPId { get; set; }
        public clsInspectionTypeId InspectionTypeId { get; set; }

        private DateTime? _startDate = null;
        [XmlIgnore]
        public DateTime? startDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        [XmlElement("startDate")]
        public string startDateString
        {
            get
            {
                if (_startDate.HasValue)
                {
                    return _startDate.Value.ToString(Constants.cDateFormat); ;
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
                    _startDate = td;
                }
                else
                {
                    _startDate = null;
                }
            }
        }
        public bool startDateStringSpecified
        {
            get { return _startDate != null; }
        }

        private uint? _availableDatesCount = null;
        public uint? availableDatesCount
        {
            get
            {
                if (_availableDatesCount.HasValue)
                {
                    return _availableDatesCount.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _availableDatesCount = value; }
        }
        public bool availableDatesCountSpecified
        {
            get { return _availableDatesCount != null; }
        }


        // Constructors
        public msgGetAvailableInspectionDates()
        {
        }
    }
}
