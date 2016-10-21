// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="MapReference">
		<xsd:complexContent>
			<xsd:extension base="SpatialDescriptor">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element name="map" type="text" form="qualified" id="gov_parcel_map_map" minOccurs="0"/>
					<xsd:element name="tract" type="text" form="qualified" id="gov_parcel_map_tract" minOccurs="0"/>
					<xsd:element name="block" type="text" form="qualified" id="gov_parcel_map_block" minOccurs="0"/>
					<xsd:element name="lot" type="text" form="qualified" id="gov_parcel_map_lot" minOccurs="0"/>
					<xsd:element name="subdivision" type="text" form="qualified" id="gov_parcel_map_subdivision" minOccurs="0"/>
					<xsd:element name="referenceAddress" type="text" form="qualified" minOccurs="0"/>
					<xsd:element name="referenceEntity" type="text" form="qualified" minOccurs="0"/>
					<xsd:element name="referenceLandType" type="text" form="qualified" minOccurs="0"/>
					<xsd:element name="section" type="text" form="qualified" id="gov_parcel_map_section" minOccurs="0"/>
					<xsd:element name="township" type="text" form="qualified" id="gov_parcel_map_township" minOccurs="0"/>
					<xsd:element name="range" type="text" form="qualified" id="gov_parcel_map_range" minOccurs="0"/>
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
    public class clsMapReference : clsSpatialDescriptor
    {
        // Messages
        private string _map = null;
        public string map
        {
            get { return _map; }
            set { _map = value; }
        }

        private string _tract = null;
        public string tract
        {
            get { return _tract; }
            set { _tract = value; }
        }

        private string _block = null;
        public string block
        {
            get { return _block; }
            set { _block = value; }
        }

        private string _lot = null;
        public string lot
        {
            get { return _lot; }
            set { _lot = value; }
        }

        private string _subdivision = null;
        public string subdivision
        {
            get { return _subdivision; }
            set { _subdivision = value; }
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

        private string _section = null;
        public string section
        {
            get { return _section; }
            set { _section = value; }
        }

        private string _township = null;
        public string township
        {
            get { return _township; }
            set { _township = value; }
        }

        private string _range = null;
        public string range
        {
            get { return _range; }
            set { _range = value; }
        }

        // Constructors
        public clsMapReference()
        {
        }
    }
}
