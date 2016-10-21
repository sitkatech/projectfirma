using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="DistanceAndTime">
		<xsd:complexContent>
			<xsd:extension base="element">
				<xsd:sequence>
					<xsd:element ref="Keys" minOccurs="0"/>
					<xsd:element ref="IdentifierDisplay" minOccurs="0"/>
					<xsd:element ref="Date"/>
					<xsd:element name="distance" form="qualified" minOccurs="0">
						<xsd:complexType>
							<xsd:sequence>
								<xsd:element name="start" type="xsd:double" form="qualified" minOccurs="0"/>
								<xsd:element name="end" type="xsd:double" form="qualified" minOccurs="0"/>
								<xsd:element name="total" type="xsd:double" form="qualified"/>
								<xsd:element ref="UnitOfMeasurement" minOccurs="0"/>
							</xsd:sequence>
						</xsd:complexType>
					</xsd:element>
					<xsd:element name="time" form="qualified" minOccurs="0">
						<xsd:complexType>
							<xsd:sequence>
								<xsd:element name="start" type="xsd:time" form="qualified" minOccurs="0"/>
								<xsd:element name="end" type="xsd:time" form="qualified" minOccurs="0"/>
								<xsd:element name="total" type="distanceTimeSpecialType" form="qualified"/>
								<xsd:element ref="UnitOfMeasurement" minOccurs="0"/>
							</xsd:sequence>
						</xsd:complexType>
					</xsd:element>
					<xsd:element name="vehicleId" type="text" form="qualified" minOccurs="0"/>
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
    public class lctDistanceAndTimeTime : clsElement
    {
        // Members
        [XmlIgnore]
        public DateTime? start = null; 
        [XmlElement("start")]
        public string startString
        {
            get
            {
                if (start.HasValue)
                {
                    return start.Value.ToString(Constants.cTimeFormat);
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
                    start = td;
                }

            }
        }
        public bool startStringSpecified
        {
            get { return start != null; }
        }


        [XmlIgnore]
        public DateTime? end = null; 
        [XmlElement("end")]
        public string endString
        {
            get
            {
                if (end.HasValue)
                {
                    return end.Value.ToString(Constants.cTimeFormat);
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
                    end = td;
                }

            }
        }
        public bool endStringSpecified
        {
            get { return end != null; }
        }


        private double _total;  
        public double total
        {
            get { return _total; }
            set { _total = value; }
        }

        private string _UnitOfMeasurement = null;
        public string UnitOfMeasurement
        {
            get { return _UnitOfMeasurement; }
            set { _UnitOfMeasurement = value; }
        }

        // Constructors
        public lctDistanceAndTimeTime()
        {
        }
    }
}
