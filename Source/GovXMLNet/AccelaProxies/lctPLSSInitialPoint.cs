// Defined in AccelaGovXMLDataObjects
// It is defined internally to this definition

/* Version Last Modified: 6.7
	<xsd:complexType name="PLSS">
		<xsd:complexContent>
			<xsd:extension base="SpatialDescriptor">
				<xsd:sequence>
					<xsd:element name="surveyName" type="text" form="qualified" minOccurs="0"/>
					<xsd:element name="initialPoint" form="qualified" minOccurs="0">
						<xsd:complexType>
							<xsd:sequence>
								<xsd:sequence minOccurs="0">
									<xsd:element name="baseline" type="xsd:string" form="qualified"/>
									<xsd:element name="principalMeridian" type="xsd:string" form="qualified"/>
								</xsd:sequence>
								<xsd:sequence minOccurs="0">
									<xsd:element name="latitude" type="latitudeType" form="qualified"/>
									<xsd:element name="longitude" type="longitudeType" form="qualified"/>
								</xsd:sequence>
							</xsd:sequence>
						</xsd:complexType>
					</xsd:element>
					<xsd:element name="range" type="text" form="qualified" id="gov_parcel_plss_range"/>
					<xsd:element name="township" type="text" form="qualified" id="gov_parcel_plss_township"/>
					<xsd:element name="section" type="text" form="qualified" id="gov_parcel_plss_section"/>
					<xsd:element name="subdivision" type="text" form="qualified" id="gov_parcel_plss_subdivision" minOccurs="0" maxOccurs="unbounded"/>
					<xsd:element name="referenceAddress" type="text" form="qualified" minOccurs="0"/>
					<xsd:element name="referenceEntity" type="text" form="qualified" minOccurs="0"/>
					<xsd:element name="referenceLandType" type="text" form="qualified" minOccurs="0"/>
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
    public class lctPLSSInitialPoint
    {
        // Members
        private string _baseline = null;
        public string baseline
        {
            get { return _baseline; }
            set { _baseline = value; }
        }

        private string _principalMeridian = null;
        public string principalMeridian
        {
            get { return _principalMeridian; }
            set { _principalMeridian = value; }
        }


        private decimal? _latitude = null;
        public decimal? latitude
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
        public bool latitudeSpecified
        {
            get { return _latitude != null; }
        }

        private decimal? _longitude = null;
        public decimal? longitude
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
        public bool longitudeSpecified
        {
            get { return _longitude != null; }
        }

        // Constructors
        public lctPLSSInitialPoint()
        {
        }
    }
}
