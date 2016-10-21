// Defined in AccelaGovXMLDataObjects

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
    public class clsPLSS : clsSpatialDescriptor
    {
        // Members
        private string _surveyName = null;
        public string surveyName
        {
            get { return _surveyName; }
            set { _surveyName = value; }
        }

        public lctPLSSInitialPoint initialPoint { get; set; }

        private string _range = null;
        public string range
        {
            get { return _range; }
            set { _range = value; }
        }

        private string _township = null;
        public string township
        {
            get { return _township; }
            set { _township = value; }
        }

        private string _section = null;
        public string section
        {
            get { return _section; }
            set { _section = value; }
        }

        private string _subidvision = null;
        public string subidvision
        {
            get { return _subidvision; }
            set { _subidvision = value; }
        }

        private string _referenceAddress = null;
        public string referenceAddress
        {
            get { return _referenceAddress; }
            set { _referenceAddress = value; }
        }

        private string _referenceEntity = null;
        public string referenceEntity
        {
            get { return _referenceEntity; }
            set { _referenceEntity = value; }
        }

        private string _referenceLandType = null;
        public string referenceLandType
        {
            get { return _referenceLandType; }
            set { _referenceLandType = value; }
        }

        // Constructors
        public clsPLSS()
        {
        }
    }
}
