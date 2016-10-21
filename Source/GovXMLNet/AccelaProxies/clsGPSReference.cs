// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="GPSReference">
		<xsd:complexContent>
			<xsd:extension base="SpatialDescriptor">
				<xsd:sequence>
					<xsd:element name="latitude" type="latitudeType" form="qualified" id="gov_gpsreference_latitude"/>
					<xsd:element name="longitude" type="longitudeType" form="qualified" id="gov_gpsreference_longitude"/>
					<xsd:element name="elevation" type="xsd:decimal" form="qualified" id="gov_gpsreference_elevation" minOccurs="0"/>
					<xsd:element name="description" type="text" form="qualified" id="gov_gpsreference_description" minOccurs="0"/>
					<xsd:element name="source" type="text" form="qualified" id="gov_gpsreference_source" minOccurs="0"/>
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
    public class clsGPSReference : clsSpatialDescriptor
    {
        // Methods
        private decimal _latitude;
        public decimal latitude
        {
            get { return _latitude; }
            set
            {
                if (value < -90)
                {
                    _latitude = 0;
                }
                else if (value > 90)
                {
                    _latitude = 0;
                }
                else
                {
                    _latitude = value;
                }
            }
        }

        private decimal _longitude;
        public decimal longitude
        {
            get { return _longitude; }
            set
            {
                if (value < -180)
                {
                    _longitude = 0;
                }
                else if (value > 180)
                {
                    _longitude = 0;
                }
                else
                {
                    _longitude = value;
                }
            }
        }

        private decimal _elevation;
        public decimal elevation
        {
            get { return _elevation; }
            set { _elevation = value; }
        }

        private string _description = null;
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        /* should be inherited from clsSpatialDescriptor
        private string _source = null;
        public string source
        {
            get { return _source; }
            set { _source = value; }
        }
        */

        // Constructors
        public clsGPSReference()
        {
        }
    }
}
