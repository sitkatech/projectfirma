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
    public class lctDistanceAndTimeDistance
    {
        // Members
        private double? _start = null;
        public double? start
        {
            get
            {
                if (_start.HasValue)
                {
                    return _start.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _start = value; }
        }
        public bool startSpecified
        {
            get { return _start != null; }
        }

        private double? _end = null;
        public double? end
        {
            get
            {
                if (_end.HasValue)
                {
                    return _end.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _end = value; }
        }
        public bool endSpecified
        {
            get { return _end != null; }
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
        public lctDistanceAndTimeDistance()
        {
        }
    }
}
